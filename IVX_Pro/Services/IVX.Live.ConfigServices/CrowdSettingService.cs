using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using System.Diagnostics;
using System.Data;
using IVX.Live.ConfigServices.Interop;


namespace IVX.Live.ConfigServices
{
    public class CrowdSettingService
    {
        public event EventHandler DisConnected;
        public event EventHandler AnalyseStatChanged;

        private IVXRealtimeProtocol m_protocol;

        private uint m_loginIDRias = 0;
        private uint m_loginIDAdps = 0;
        private List<AdpsInfo> m_lastEvent = new List<AdpsInfo>();

        private IVXRealtimeProtocol IVXProtocol
        {
            get
            {
                return m_protocol;
            }
        }
        public string RTRISServerIP { get; set; }
        public uint RTRISPort { get; set; }

        public string ServerIP { get; set; }
        public string LocalIP { get; set; }
        public uint LocalPort { get; set; }

        #region Constructors
        public CrowdSettingService(IVXRealtimeProtocol protocol)
        {
            m_protocol = protocol;
            IVXProtocol.EventDisConnectd += IVXProtocol_EventDisConnectd;
            //IVXProtocol.EventAnalyseStateChanged += IVXProtocol_EventAnalyseStateChanged; 
            ServerIP = "";
            LocalIP = "";
            LocalPort = 0;
        }

        void IVXProtocol_EventAnalyseStateChanged(uint dwLoginID, uint dwAnalysisID, E_IASSDK_REAL_ANALYZE_STATUS_TYPE eStatusType, ulong qwContext)
        {
            if (AnalyseStatChanged != null)
            {
                AnalyseStatChanged(dwAnalysisID, null);
            }
        }

        void IVXProtocol_EventDisConnectd(uint dwLoginID, ulong qwContext)
        {
            if (DisConnected != null)
                DisConnected(null, null);
        }

        #endregion

        #region Public helper functions
        public bool InitLoginServer(string ridsip, uint ridsport, string adpisip, uint adpisport)
        {
            bool ret = false;
            ret = LoginRiasServer(ridsip, ridsport);
            if(ret)
                ret = LoginAdpsServer(adpisip, adpisport);

            return ret;
        }
        public void UninitServer()
        {
           LogoutRiasServer();
           LogoutAdpsServer();
           m_loginIDRias = 0;
           m_loginIDAdps = 0;
        }

        public List<RealAnalyseInfo> GetAllCrowd()
        {
            List<RealAnalyseInfo> ret = new List<RealAnalyseInfo>();
            List<RealAnalyseInfo> list = GetAllRealAnalysis();
            foreach (var item in list)
            {
                if (item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD)
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        public RealAnalyseInfo GetRealAnalyseBy(uint statid)
        {
            return IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginIDRias, statid);
        }
        public uint  AddCrowd(RealtimeCameraInfo cam, List<System.Drawing.Point> region, float area, uint time)
        {
            if (GetRealAnalyseCapableLeft() > 0)
            {
                AdpsServerUnitInfo unit = GetOneProcessAdps();
                string pChannelId = cam.CameraID;

                RealAnalyseParam param = new RealAnalyseParam()
                {
                    eAlgthmType =  E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD,
                    realCameraInfo = new RealCameraInfo()
                    {
                        dwDevicePort = (ushort)cam.PlatPort,
                        dwDeviceType = (uint)cam.ProtocolType,
                        szCameraID = cam.CameraID,
                        szChannelID = cam.CameraChannelID,
                        szDeviceIP = cam.PlatIP,
                        szLoginPwd = cam.Password,
                        szLoginUser = cam.UserName,

                    },
                    dwAnalysisPlanID = Convert.ToUInt32(DateTime.Now.Subtract(new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0)).TotalMilliseconds / 100),
                    szAnalysisParam = BuildAnalyseParamByCollect(region, area, time),
                    szArsIp = unit.szServerIp,
                    wArsPort = unit.wServerPort,
                };

                return  AddRealAnalyse(param);
            }
            else
                return 0;
        }

        public bool AddDefaultEvent(string cameraCode)
        {
            RealAnalyseInfo anainfo = GetAllCrowd().Find(item => item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);

            AdpsInfo adpsinfo = GetAllEvents().Find(item => item.tEventParam.szCameraID == cameraCode && item.tEventParam.szReceiveIp == ServerIP && item.tEventParam.dwAnalyseType == (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD);
            if (adpsinfo != null)
                return true;

            AdpsParam adps = new AdpsParam()
            {
                dwAnalyseType = (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD,
                szReceiveIp = RTRISServerIP,
                wReceivePort = (ushort)RTRISPort,
                szServerIp = anainfo.realAnalyseParam.szArsIp,
                wServerPort = anainfo.realAnalyseParam.wArsPort,
                szCameraID = anainfo.realAnalyseParam.realCameraInfo.szCameraID,
                dwTaskUnitID = anainfo.realAnalyseParam.dwAnalysisPlanID,
                dwTaskType = 1,
                dwStoreStyle = 1,
                dwProtocolType = 1,
                dwMergeStyle = 0,
            };

            return AddEvent(adps) > 0;
 
        }
        public bool Subscribe(string cameraCode)
        {
            
            RealAnalyseInfo anainfo = GetAllCrowd().Find(item => item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);

            AdpsInfo adpsinfo = GetAllEvents().Find(item => item.tEventParam.szCameraID == cameraCode && item.tEventParam.szReceiveIp == LocalIP && item.tEventParam.dwAnalyseType == (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD);
            if (adpsinfo != null)
                return true;

            AdpsParam adps = new AdpsParam()
                {
                    dwAnalyseType = (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD,
                    szReceiveIp = LocalIP,
                    wReceivePort = (ushort)LocalPort,
                    szServerIp = anainfo.realAnalyseParam.szArsIp,
                    wServerPort = anainfo.realAnalyseParam.wArsPort,
                    szCameraID = anainfo.realAnalyseParam.realCameraInfo.szCameraID,
                    dwTaskUnitID = anainfo.realAnalyseParam.dwAnalysisPlanID,
                    dwTaskType = 1,
                    dwStoreStyle = 1,
                    dwProtocolType = 1,
                    dwMergeStyle = 0,
                };

            return AddEvent(adps)>0;
 
        }

        public bool UnSubscribe(string cameraCode)
        {
            AdpsInfo anainfo = GetAllEvents().Find(item => item.tEventParam.szCameraID == cameraCode && item.tEventParam.dwAnalyseType == (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD && item.tEventParam.szReceiveIp == LocalIP);
            if (anainfo!=null)
                DelEvent(anainfo.dwEventID);
            return true;
        }



        public bool UpdateCrowd(RealtimeCameraInfo cam, List<System.Drawing.Point> region, float area, uint time)
        {
            bool ret = false;
            //List<CrowdCameraInfo> list = CameraManagementService.GetCamerasByGroupID(0);
            //CrowdCameraInfo cam = list.Find(item => item.CameraCode == cameraCode);
            if (cam != null)
            {
                RealAnalyseInfo info = GetAllCrowd().Find(item => item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD && item.realAnalyseParam.realCameraInfo.szCameraID == cam.CameraID);
                if (info != null)
                {
                    SaveEvent(cam.CameraID);
                    DelCrowd(cam.CameraID);
                    uint id = AddCrowd(cam, region, area, time);
                    RecoverEvent(id);
                }
                else
                {
                    ret = false ;
                }
            }
            else
                ret = false;


            return ret;
        }

        public bool DelCrowd(string cameraCode)
        {
            RealAnalyseInfo info = GetAllCrowd().Find(item => item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD && item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);
            bool ret = true ;
            if (info != null)
                ret = DelRealAnalyse(info.dwAnalysisID);
            return ret;
        }

        public bool CrowdExists(string cameraCode)
        {
            RealAnalyseInfo info = GetAllCrowd().Find(item => item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD && item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);
            
            return info!=null;
        }
        public uint GetRealAnalyseCapable()
        {
            uint count = 0;
            IVXProtocol.IasSdk_GetServiceCapacity(m_loginIDRias, out count);
            return count;
        }

        public uint GetRealAnalyseCapableLeft()
        {
            uint total = 0;
            uint count = 0;
            IVXProtocol.IasSdk_GetServiceCapacity(m_loginIDRias, out total);
            IVXProtocol.IasSdk_GetRTAnalysisNum(m_loginIDRias, out count);
            return total - count;
        }

        public void Clearup()
        {
            LogoutAdpsServer(); 
            LogoutRiasServer();
        }
        #endregion

        #region private helper functions

        private string BuildAnalyseParamByCollect(List<System.Drawing.Point> AnalyseAreaExParam,float CollectArea,uint CollectTimeInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            sb.AppendLine("<AlgorithmInitParam>");
            sb.AppendLine("<AlgorithmType>CrowdAnalyse</AlgorithmType>");
            if (AnalyseAreaExParam.Count > 0)
            {
                sb.AppendLine("<CheckRegion>");
                sb.AppendLine("<PointNum>" + AnalyseAreaExParam .Count+ "</PointNum>");
                sb.AppendLine("<PointSet>");
                foreach (var item in AnalyseAreaExParam)
                {
                    sb.AppendLine("<Point>");
                    sb.AppendLine("<X>" + item.X+ "</X>");
                    sb.AppendLine("<Y>" + item.Y + "</Y>");
                    sb.AppendLine("</Point>");
                    
                }
                sb.AppendLine("</PointSet>");
                sb.AppendLine("<Area>"+CollectArea.ToString("0.##")+"</Area>");
                sb.AppendLine("</CheckRegion>");
            }

            sb.AppendLine("<TimelyReportTimeInterval>" + CollectTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("</AlgorithmInitParam>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }

        private bool LoginRiasServer(string ip, uint port)
        {
            if (m_loginIDRias > 0)
                IVXProtocol.IasSdk_Logout(m_loginIDRias);

            IVXProtocol.IasSdk_Login(ip, (ushort)port, out m_loginIDRias);
            string ver = IVXProtocol.IasSdk_GetServerVersion(m_loginIDRias);

            return (m_loginIDRias > 0);

        }

        private void LogoutRiasServer()
        {
            if (m_loginIDRias > 0)
                IVXProtocol.IasSdk_Logout(m_loginIDRias);
            m_loginIDRias = 0;

        }

        private RealAnalyseInfo GetRealAnalysisByID(uint realAnalysisID)
        {
            try
            {
                return IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginIDRias, realAnalysisID);
            }
            catch (SDKCallException ex)
            {
                return null;
            }

        }

        private List<RealAnalyseInfo> GetAllRealAnalysis()
        {

            uint count = 0;
            IVXProtocol.IasSdk_GetRTAnalysisNum(m_loginIDRias, out count);
            //RealAnalyseInfo temp = Framework.Container.Instance.IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginIDRias, 1);
            return IVXProtocol.IasSdk_GetRTAnalysisList(m_loginIDRias, count);
        }


        private uint AddRealAnalyse(RealAnalyseParam param)
        {
            uint anaID = 0;
           IVXProtocol.IasSdk_AddRTAnalysis(m_loginIDRias, param, out anaID);
            return anaID;
        }

        private bool DelRealAnalyse(uint analyseID)
        {
            if (analyseID > 0)
            {
                var ana =IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginIDRias, analyseID);
                if (ana != null)
                    DelEventBy(ana.realAnalyseParam.dwAnalysisPlanID, ana.realAnalyseParam.realCameraInfo.szCameraID, Convert.ToUInt32(ana.realAnalyseParam.eAlgthmType));
                IVXProtocol.IasSdk_DelAnalysis(m_loginIDRias, analyseID);
                return true;
            }
            else
            {
                return true;
            }
        }


        private void SaveEvent(string cameraCode)
        {
            m_lastEvent = new List<AdpsInfo>();
            foreach (var item in GetAllEvents())
            {
                if (item.tEventParam.dwAnalyseType == Convert.ToUInt32(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD)
                    && item.tEventParam.szCameraID == cameraCode)
                    m_lastEvent.Add(item);
            }
        }
        private void RecoverEvent(uint analyseID)
        {
            RealAnalyseInfo info = GetAllCrowd().Find(item => item.dwAnalysisID == analyseID);
            if (info != null)
            {
                foreach (var item in m_lastEvent)
                {
                    item.tEventParam.dwTaskUnitID = info.realAnalyseParam.dwAnalysisPlanID;
                    AddEvent(item.tEventParam);
                }
            }
        }

#if !Debug
        private bool LoginAdpsServer(string ip, uint port)
        {
            if (m_loginIDAdps > 0)
                IVXProtocol.AdpsSdk_Logout(m_loginIDAdps);

            IVXProtocol.AdpsSdk_Login(ip, (ushort)port, out m_loginIDAdps);
            string ver = IVXProtocol.AdpsSdk_GetSdkVersion();
            return (m_loginIDAdps > 0);
        }

        private void LogoutAdpsServer()
        {
            if (m_loginIDAdps > 0)
                IVXProtocol.AdpsSdk_Logout(m_loginIDAdps);
            m_loginIDAdps = 0;
        }

        private AdpsInfo GetAdpsEventByID(uint eventID)
        {
            return IVXProtocol.AdpsSdk_GetEventInfoByID(m_loginIDAdps, eventID);
        }

        private List<AdpsInfo> GetAllEvents()
        {
            uint count = 0;
            IVXProtocol.AdpsSdk_GetEventNum(m_loginIDAdps, out count);
            return IVXProtocol.AdpsSdk_GetEventList(m_loginIDAdps, count);
        }

        private AdpsServerUnitInfo GetOneProcessAdps()
        {
            //return new AdpsServerUnitInfo() { dwServerID = 1, szDescription = "", szServerIp = "192.168.1.1", wIsUsed = 1, wServerPort = 6021, wServerType = 1, };
            return IVXProtocol.AdpsSdk_GetProcessUnitInfo(m_loginIDAdps);
        }

        private uint AddEvent(AdpsParam param)
        {
            uint anaID = 0;
            IVXProtocol.AdpsSdk_AddEvent(m_loginIDAdps, param, out anaID);
            return anaID;
        }

        private uint EditEvent(uint anaID, AdpsParam param)
        {
            IVXProtocol.AdpsSdk_UpdateEvent(m_loginIDAdps, param, anaID);
            return anaID;
        }

        private bool DelEvent(uint eventID)
        {
            if (eventID > 0)
            {
                return IVXProtocol.AdpsSdk_DelEvent(m_loginIDAdps, eventID);
            }
            else
            {
                return true;
            }
        }
        private bool DelEventBy(uint dwTaskUnitID, string szCameraID, uint dwAnalyseType)
        {
            bool ret = true;
            foreach (var item in GetAllEvents())
            {
                if (item.tEventParam.dwTaskUnitID == dwTaskUnitID && item.tEventParam.szCameraID == szCameraID && item.tEventParam.dwAnalyseType == dwAnalyseType)
                    ret = ret && IVXProtocol.AdpsSdk_DelEvent(m_loginIDAdps, item.dwEventID);
            }
            return ret;
        }
#endif
        #endregion
        

    }
}
