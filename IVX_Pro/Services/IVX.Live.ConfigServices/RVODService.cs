using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using IVX.DataModel;
using System.Diagnostics;
using IVX.Live.ConfigServices.Interop;
using System.Drawing;


namespace IVX.Live.ConfigServices
{
    public class RVODService
    {
        private IVXRealtimeProtocol m_protocol;


        private IVXRealtimeProtocol IVXProtocol
        {
            get
            {
                return m_protocol;
            }
        }

        public RVODService(IVXRealtimeProtocol protocol)
        {
            m_protocol = protocol;
        }

        private Dictionary<IntPtr, uint> PlayHandleList = new Dictionary<IntPtr, uint>();

        public void Cleanup()
        {
        }

        public List<RVODFileInfo> GetRVODFileList(string ip,uint port)
        {
            List<RVODFileInfo> list = new List<RVODFileInfo>();
            uint queryHandle = 0;
            uint count = IVXProtocol.RvodSdk_GetVideoResourceTotalNum(ip, port, out queryHandle);
            while (true)
            {
                RVODFileInfo info = IVXProtocol.RvodSdk_QueryNextVideoResource(queryHandle);
                if (info == null)
                    break;
                info.ServerIP = ip;
                info.ServerPort = port;
                list.Add(info);
            }
            return list;
        }

        public uint StartRVODPlay(IntPtr hWnd, RVODFileInfo info)
        {
            StopRVODPlay(hWnd);
            if (info == null || string.IsNullOrEmpty(info.VodFileName))
                return 0;

            uint ret= IVXProtocol.RvodSdk_PlayBackVideo(hWnd, info);
            System.Threading.Thread.Sleep(1000);
            uint outval=0;
            IVXProtocol.RvodSdk_PlayBackControl(ret, 1, 0, out outval);
            if (ret > 0)
                PlayHandleList.Add(hWnd, ret);
            return ret;
        }

        public void StopRVODPlay(IntPtr hWnd)
        {
            if(PlayHandleList.ContainsKey(hWnd))
            {
                IVXProtocol.RvodSdk_StopPlayBack(PlayHandleList[hWnd]);
                PlayHandleList.Remove(hWnd);
            }
        }

        public Image SnapPicture(IntPtr hWnd)
        {
            if (PlayHandleList.ContainsKey(hWnd))
            {
                return IVXProtocol.RvodSdk_GrabPictureData(PlayHandleList[hWnd]);
            }
            else
                return null;
        }


    }
}
