using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using IVX.DataModel;
using IVX.Live.ConfigServices.Interop;

namespace IVX.Live.ConfigServices
{
    public class DIOService
    {
        private int m_loginId = -1;

        public int LoginId
        {
            get { return m_loginId; }
        }
        private static AccessProtocolTypeInfo[] s_AccessProtocolTypeInfos;

        private Dictionary<UInt64, IntPtr> m_DTVideoHandleList = new Dictionary<UInt64, IntPtr>();
        private Dictionary<IntPtr, string> m_DTWindowHandle2Camera = new Dictionary<IntPtr, string>();
        private Dictionary<UInt64, int> m_DTPlayState = new Dictionary<ulong, int>();

        public E_VDA_NET_STORE_DEV_PROTOCOL_TYPE m_connType;
        public string m_currIP;
        public string m_currCh;
        public uint m_currPort;
        public string m_currUser;
        public string  m_currPass;
        private IVXRealtimeProtocol m_protocol;

        private IVXRealtimeProtocol IVXProtocol
        {
            get
            {
                return m_protocol;
            }
        }

        public DIOService(IVXRealtimeProtocol protocol)
        {
            m_protocol = protocol;
            m_loginId = -1;
            m_protocol.EventPlayStateChanged += new DelegatePlayStateChanged(m_protocol_EventPlayStateChanged);
        }

        void m_protocol_EventPlayStateChanged(ulong ubiStrmID, int dwPlayState)
        {
            if (!m_DTPlayState.ContainsKey(ubiStrmID))
            {
                m_DTPlayState.Add(ubiStrmID, dwPlayState);
            }
            else
                m_DTPlayState[ubiStrmID] = dwPlayState;
        }

        public int Login(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE dwConnType, string pIp,
    ushort uPort, string pUser, string pPassword)
        {
            MyLog4Net.Container.Instance.Log.Debug(string.Format("dioservice m_loginId:{5}, dwConnType:{0},pIp:{1},uPort:{2},pUser:{3},pPassword:{4}"
                , dwConnType, pIp, uPort, pUser, pPassword, m_loginId));
            
            if (m_loginId >= 0)
                return m_loginId;

            if (dwConnType == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
            {
                m_loginId = int.MaxValue;
            }
            else
            {
                uint logid = 0;
                IVXProtocol.DIOLoginDevice((uint)dwConnType, pIp, uPort, pUser, pPassword, 10, out logid);
                m_loginId = (int)logid;
            }
            if (m_loginId >= 0)
            {
                m_connType = dwConnType;
                m_currIP = pIp;
                m_currPort = uPort;
                m_currUser = pUser;
                m_currPass = pPassword;
            }
            return m_loginId;
        }

        public void Logout()
        {
            if (m_loginId == -1)
                return;

            if (m_connType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                IVXProtocol.DIOLogoutDevice((uint)m_loginId);

            m_loginId = -1;
            m_connType = E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE;
            m_currIP = "";
            m_currPort = 0;
            m_currUser = "";
            m_currPass = "";
        }

        public int GetGBPlatformLoginId(string gbPlatformId)
        {
            int loginId = -1;
            List<GBDevInfo> gblist = IVXProtocol.DIOQueryDeviceList(
                E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL);

            foreach (GBDevInfo item in gblist)
            {
                if (string.CompareOrdinal(item.DevId, gbPlatformId) == 0)
                {
                    loginId = item.LoginId;
                    break;
                }
            }
            return loginId;
        }

        public List<TDIO_ChannelInfo> GetChannelList()
        {
            if (m_loginId == -1)
                return new List<TDIO_ChannelInfo>();

#if DEMO
            List<TDIO_ChannelInfo> ret = new List<TDIO_ChannelInfo>();
            ret.Add(new TDIO_ChannelInfo() { szChannelId = "34", szChannelName = "hk_channel2" , szRest="0", });
            ret.Add(new TDIO_ChannelInfo() { szChannelId = "3", szChannelName = "dh_channel4", szRest = "0", });
            return ret;
#else
            
            List<TDIO_ChannelInfo> list = new List<TDIO_ChannelInfo>();
            switch (m_connType)
            {
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL:
                    list.Add(new TDIO_ChannelInfo() { szChannelId = "0", szChannelName = "ONVIF相机", szRest = m_loginId.ToString() });
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL:
                    List<GBDevInfo> gblist = IVXProtocol.DIOQueryDeviceList(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL);
                    foreach (GBDevInfo item in gblist)
                    {
                        list.AddRange(IVXProtocol.DIOQueryChannelList((uint)item.LoginId,item.DevId));
                    }
                    list.Sort((x, y) => x.szChannelName.CompareTo(y.szChannelName));
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_BCSYS_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_H3C_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NETPOSA_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_IMOS_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DHPLAT_DEV:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ISOC_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_VISS_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_WB_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_DEV:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DH_DEV:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_SANYO_IPC_DEV:
                    list = IVXProtocol.DIOQueryChannelList((uint)m_loginId);
                    break;
                //case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE:
                //    List<RVODFileInfo> filelist = GetRVODFileList(m_currIP, m_currPort);
                //    foreach (var item in filelist)
                //    {
                //        list.Add(new TDIO_ChannelInfo()
                //            {
                //                szChannelId = item.VodFileName,
                //                szChannelName = item.VodFileName,
                //                szRest = "0",
                //            });
                //    }
                //    break;
                default:
                    break;
            }
            return list;
#endif
        }
        //public List<TDIO_ChannelInfo> GetChannelList()
        //{
        //    if (m_loginId == 0)
        //        return new List<TDIO_ChannelInfo>();


        //    List<TDIO_ChannelInfo> list = new List<TDIO_ChannelInfo>();

        //    uint pdwQueryChnLstHandle = 0;
        //    Framework.Container.Instance.IVXProtocol.DIOQueryChannelList(m_loginId, out pdwQueryChnLstHandle);
        //    while (true)
        //    {
        //        RealtimeProtocol.TDIO_ChannelInfo info = new RealtimeProtocol.TDIO_ChannelInfo();
        //        uint pdwQueryOverFlag = 15;
        //        Framework.Container.Instance.IVXProtocol.DIOGetNextChannelInfo(pdwQueryChnLstHandle, out    info, out pdwQueryOverFlag);
        //        if (pdwQueryOverFlag == 0)
        //            break;
        //        else
        //        { 
        //        list.Add(info);
        //        }
        //    }

        //    Framework.Container.Instance.IVXProtocol.DIOCloseQueryChannelList(pdwQueryChnLstHandle);

        //    return list;
        //}

        public bool StartRealPlay(IntPtr hwnd, string channel,string  rest)
        {
            //return;/////////
            ////////////
            //////////////////
            /////////////////
            bool bRet = true; 
            if (m_DTWindowHandle2Camera.ContainsKey(hwnd))
            {
                if (string.CompareOrdinal(m_DTWindowHandle2Camera[hwnd], channel) == 0)
                {
                    return bRet;
                }
            }

            //if (m_connType == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
            //{
            //    bRet = false;

            //    RVODFileInfo info = new RVODFileInfo()
            //    { ServerIP = m_currIP,
            //         ServerPort = m_currPort,
            //          VodFileName = channel,
            //          VodFileSize = 0,
            //    };
            //    StartRVODPlay(hwnd, info);
            //    bRet = true;
            //}
            //else
            { 
                StopRealPlay(hwnd);

                bRet = false;

                UInt64 Strmhandle = 0;
                uint nRet = IVXProtocol.DIOStartRealPlayStrm(Convert.ToUInt32(rest), channel, hwnd, out Strmhandle);
                if (nRet == 0 && Strmhandle > 0)
                {
                    int count=50;
                    while (--count>0)
                    {
                        System.Threading.Thread.Sleep(100);
                        if (m_DTPlayState.ContainsKey(Strmhandle) && (m_DTPlayState[Strmhandle] == 1))
                        {
                            break;
                        }
                    }

                    m_DTVideoHandleList.Add(Strmhandle, hwnd);
                    m_DTWindowHandle2Camera.Add(hwnd, channel);
                    m_currCh = channel;
                    bRet = true;
                }
                //StopRealPlay(hwnd);
            }
            return bRet;
        }
        //public void StartRealPlay(IntPtr hwnd, string channel)
        //{
        //    StopRealPlay(hwnd);

        //    uint Strmhandle = 0;
        //    Framework.Container.Instance.IVXProtocol.DIORealPlay(m_loginId, channel, 0, (uint)hwnd.ToInt32(), hwnd, out Strmhandle);
        //    m_DTVideoHandleList.Add(Strmhandle, hwnd);
        //    m_currCh = channel;
        //    //StopRealPlay(hwnd);

        //}
        public System.Drawing.Image SnapPicture(IntPtr hwnd)
        {

            UInt64 handle = GetPlayHandleByhWnd(hwnd);
            if (handle > 0)
            {
                try
                {
                //if (m_connType == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                //{
                //return IVXProtocol.RvodSdk_GrabPictureData((uint)handle);
                //}
                //else
                {
                return IVXProtocol.DIOSnapPictureEx(handle);
                }

                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.Error(ex);
                    return null;
                }
            }
            else
                return null;
        }
        public void StopRealPlay(IntPtr hwnd)
        {
            if (!m_DTWindowHandle2Camera.ContainsKey(hwnd))
            {
                return;
            }

            //if (m_connType == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
            //{
            //    StopRVODPlay(hwnd);
            //}
            //else
            {
                UInt64 handle = GetPlayHandleByhWnd(hwnd);
                if (handle > 0)
                    IVXProtocol.DIOCloseStrm(handle);

                m_DTVideoHandleList.Remove(handle);
                m_DTWindowHandle2Camera.Remove(hwnd);
                m_DTPlayState.Remove(handle);
            }
            m_currCh = "";
        }


        public UInt64 GetPlayHandleByhWnd(IntPtr hWnd)
        {
            UInt64 playhandle = 0;
            foreach (KeyValuePair<UInt64, IntPtr> o in m_DTVideoHandleList)
            {
                if (o.Value == hWnd)
                {
                    playhandle = o.Key;
                    break;
                }
            }
            return playhandle;
        }

        public void Cleanup()
        {
            try
            {
                foreach (IntPtr o in m_DTVideoHandleList.Values.ToList())
                {
                    StopRealPlay(o);
                }
            }
            catch (SDKCallException)
            { }
            m_DTVideoHandleList.Clear();
            if(m_connType!= E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
            IVXProtocol.DIOLogoutDevice((uint)m_loginId);
            m_loginId = -1;
            //Framework.Container.Instance.IVXProtocol.DIOUninit();

        }

        public string UpdateVideoSupplierDeviceName(VideoSupplierDeviceInfo device)
        {

            AccessProtocolTypeInfo info = DataModel.Constant.AccessProtocolTypeInfos.First(item => item.Type == device.ProtocolType);
            device.DeviceName = string.Format("{0}【{1}:{2}】", info.Name, device.IP, device.Port);
            return device.DeviceName;
        }

        public bool GetPlayResolution(IntPtr hWnd, out UInt32 Width, out UInt32 Height)
        {

            ulong playhandle = GetPlayHandleByhWnd(hWnd);
            Width = 0;
            Height = 0;
            if (playhandle > 0)
            {
                try
                {
                    //if (m_connType == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                    //{
                    //    return IVXProtocol.GetRVodPlayResolution((uint)playhandle, out Width, out Height);
                    //}
                    //else
                    {
                        return IVXProtocol.GetPlayResolution(playhandle, out Width, out Height);
                    }
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.Error(ex);
                    Width = 1920;
                    Height = 1080;
                    return false;
                }
            }
            else
                return false;
        }

        //private List<RVODFileInfo> GetRVODFileList(string ip, uint port)
        //{
        //    List<RVODFileInfo> list = new List<RVODFileInfo>();
        //    uint queryHandle = 0;
        //    uint count = IVXProtocol.RvodSdk_GetVideoResourceTotalNum(ip, port, out queryHandle);
        //    while (true)
        //    {
        //        RVODFileInfo info = IVXProtocol.RvodSdk_QueryNextVideoResource(queryHandle);
        //        if (info == null)
        //            break;
        //        info.ServerIP = ip;
        //        info.ServerPort = port;
        //        list.Add(info);
        //    }
        //    return list;
        //}

        //private uint StartRVODPlay(IntPtr hWnd, RVODFileInfo info)
        //{
        //    StopRVODPlay(hWnd);
        //    if (info == null || string.IsNullOrEmpty(info.VodFileName))
        //        return 0;

        //    uint ret = IVXProtocol.RvodSdk_PlayBackVideo(hWnd, info);
        //    System.Threading.Thread.Sleep(200);
        //    uint outval = 0;
        //    IVXProtocol.RvodSdk_PlayBackControl(ret, 1, 0, out outval);
        //    if (ret > 0)
        //    {
        //        int count = 50;
        //        while (--count > 0)
        //        {
        //            System.Threading.Thread.Sleep(100);
        //            if (m_DTPlayState.ContainsKey(ret) && (m_DTPlayState[ret] == 1))
        //            {
        //                break;
        //            }
        //        }
        //        m_DTVideoHandleList.Add(ret,hWnd);
        //        m_DTWindowHandle2Camera.Add(hWnd, info.VodFileName);
        //    }
        //    return ret;
        //}

        //private void StopRVODPlay(IntPtr hWnd)
        //{
        //    UInt64 handle = GetPlayHandleByhWnd(hWnd);
        //    if (handle > 0)
        //    {
        //        IVXProtocol.RvodSdk_StopPlayBack((uint)handle);
        //        m_DTVideoHandleList.Remove(handle);
        //        m_DTWindowHandle2Camera.Remove(hWnd);
        //        m_DTPlayState.Remove(handle);
        //    }
        //    m_currCh = "";
        //}

        //private System.Drawing.Image SnapRVODPicture(IntPtr hWnd)
        //{
        //    UInt64 handle = GetPlayHandleByhWnd(hWnd);
        //    if (handle > 0)
        //    {
        //        return IVXProtocol.RvodSdk_GrabPictureData((uint)handle);
        //    }
        //    else
        //        return null;
        //}

        public List<TDIO_StrmFileInfo> GetFileListByTime(TDIO_ChannelInfo ch, DateTime st, DateTime et)
        {
            if (m_loginId == -1)
                return new List<TDIO_StrmFileInfo>();

            List<TDIO_StrmFileInfo> list = new List<TDIO_StrmFileInfo>();
            switch (m_connType)
            {
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_BCSYS_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_H3C_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NETPOSA_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_IMOS_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DHPLAT_DEV:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ISOC_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_VISS_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_WB_PLAT:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_DEV:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DH_DEV:
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_SANYO_IPC_DEV:
                    list = IVXProtocol.DIOQueryFileList((uint)m_loginId, ch.szChannelId, st, et);
                    break;
                default:
                    break;
            }
            return list;
        }
    }
}
