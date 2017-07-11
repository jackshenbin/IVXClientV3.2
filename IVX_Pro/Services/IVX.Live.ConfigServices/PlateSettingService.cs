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
    public class PlateSettingService
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
        public PlateSettingService(IVXRealtimeProtocol protocol)
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

        public List<RealAnalyseInfo> GetAllPlate()
        {
            List<RealAnalyseInfo> ret = new List<RealAnalyseInfo>();
            List<RealAnalyseInfo> list = GetAllRealAnalysis();
            foreach (var item in list)
            {
                if (item.realAnalyseParam.eAlgthmType ==  E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD)
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
        public uint  AddPlate(RealtimeCameraInfo cam, List<System.Drawing.Point> region, 
            List<DriveWayRegion> driveWayRegion,
            List<System.Drawing.Rectangle> carPlateRegion,
            bool noplat,
            AccidentAlarmSubType accidentType, 
            uint carFast, 
            uint carStop, 
            uint carLow, 
            uint fluxTime)
        {
            if (GetRealAnalyseCapableLeft() > 0)
            {
                AdpsServerUnitInfo unit = GetOneProcessAdps();
                string pChannelId = cam.CameraID;

                RealAnalyseParam param = new RealAnalyseParam()
                {
                    eAlgthmType = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD,
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
                    dwAnalysisPlanID = Convert.ToUInt32(DateTime.Now.Subtract(new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0)).TotalMilliseconds / 10),
                    szAnalysisParam = BuildAnalyseParamByAccidentAlarm(region, driveWayRegion, carPlateRegion, noplat,accidentType, carFast,  carStop,  carLow,  fluxTime),
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
            RealAnalyseInfo anainfo = GetAllPlate().Find(item => item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);

            AdpsInfo adpsinfo = GetAllEvents().Find(item => item.tEventParam.szCameraID == cameraCode && item.tEventParam.szReceiveIp == ServerIP && item.tEventParam.dwAnalyseType == (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD);
            if (adpsinfo != null)
                return true;

            AdpsParam adps = new AdpsParam()
            {
                dwAnalyseType = (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD,
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
            
            RealAnalyseInfo anainfo = GetAllPlate().Find(item => item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);

            AdpsInfo adpsinfo = GetAllEvents().Find(item => item.tEventParam.szCameraID == cameraCode && item.tEventParam.szReceiveIp == LocalIP && item.tEventParam.dwAnalyseType == (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD);
            if (adpsinfo != null)
                return true;

            AdpsParam adps = new AdpsParam()
                {
                    dwAnalyseType = (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD,
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
            AdpsInfo anainfo = GetAllEvents().Find(item => item.tEventParam.szCameraID == cameraCode && item.tEventParam.dwAnalyseType == (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD && item.tEventParam.szReceiveIp == LocalIP);
            if (anainfo!=null)
                DelEvent(anainfo.dwEventID);
            return true;
        }



        public bool UpdatePlate(RealtimeCameraInfo cam, List<System.Drawing.Point> region, List<DriveWayRegion> driveWayRegion,
            List<System.Drawing.Rectangle> carPlateRegion,
            bool noplat,
            AccidentAlarmSubType accidentType,
            uint carFast,
            uint carStop,
            uint carLow,
            uint fluxTime)
        {
            bool ret = false;
            if (cam != null)
            {
                RealAnalyseInfo info = GetAllPlate().Find(item => item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD && item.realAnalyseParam.realCameraInfo.szCameraID == cam.CameraID);
                if (info != null)
                {
                    SaveEvent(cam.CameraID);
                    DelPlate(cam.CameraID);
                    uint id = AddPlate(cam, region, driveWayRegion, carPlateRegion,noplat,accidentType,carFast,carStop,carLow,fluxTime);
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

        public bool DelPlate(string cameraCode)
        {
            RealAnalyseInfo info = GetAllPlate().Find(item => item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD && item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);
            bool ret = true ;
            if (info != null)
                ret = DelRealAnalyse(info.dwAnalysisID);
            return ret;
        }

        public bool PlateExists(string cameraCode)
        {
            RealAnalyseInfo info = GetAllPlate().Find(item => item.realAnalyseParam.eAlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD && item.realAnalyseParam.realCameraInfo.szCameraID == cameraCode);
            
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

        private string BuildAnalyseParamByAccidentAlarm(
            List<System.Drawing.Point> AnalyseAreaExParam, 
            List<DriveWayRegion> DriveWayRegionParam,
            List<System.Drawing.Rectangle> CarPlateAreaParam,
            bool VehicleNoplatInclude,
            AccidentAlarmSubType AccidentAlarmSubType, 
            uint CarFast, 
            uint CarStop, 
            uint CarLow, 
            uint FluxTimelyReportTimeInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            sb.AppendLine("<AlgorithmInitParam>");
            sb.AppendLine("<AlgorithmType>Crossroad</AlgorithmType>");
            if (AnalyseAreaExParam.Count > 0)
            {
                sb.AppendLine("<RoadRegion>");
                sb.AppendLine("<RoadNum>1</RoadNum>");
                sb.AppendLine("<RoadInfo>");
                sb.AppendLine("<PointNum>" + AnalyseAreaExParam.Count + "</PointNum>");
                sb.AppendLine("<PointSet>");
                foreach (var item in AnalyseAreaExParam)
                {
                    sb.AppendLine("<Point>");
                    sb.AppendLine("<X>" + item.X + "</X>");
                    sb.AppendLine("<Y>" + item.Y + "</Y>");
                    sb.AppendLine("</Point>");

                }
                sb.AppendLine("</PointSet>");
                sb.AppendLine("</RoadInfo>");
                sb.AppendLine("</RoadRegion>");
            }

            sb.AppendLine("<ChannelRegion>");
            sb.AppendLine("<ChannelNum>" + DriveWayRegionParam.Count + "</ChannelNum>");
            DriveWayRegionParam.ForEach(item => { sb.AppendLine(item.ToXMLString()); });
            sb.AppendLine("</ChannelRegion>");

            //if (CarPlateAreaParam.Count > 0)
            sb.AppendLine(BuildAnalyseParamByCarPlate(CarPlateAreaParam[0], VehicleNoplatInclude));
            //else
            //{
            //    Rectangle rect = new Rectangle(0, 2 * DrawImage.Height / 3, DrawImage.Width, DrawImage.Height - 2 * DrawImage.Height / 3);

            //    sb.AppendLine(BuildAnalyseParamByCarPlate(rect));
            //}

            sb.AppendLine("<Accident>");
            sb.AppendLine(BuildAnalyseParamByCheckNoReverse(AccidentAlarmSubType));
            sb.AppendLine(BuildAnalyseParamByCheckJam(AccidentAlarmSubType));
            sb.AppendLine(BuildAnalyseParamByCheckPassagerCross(AccidentAlarmSubType));
            sb.AppendLine(BuildAnalyseParamByCheckCarCross(AccidentAlarmSubType));
            sb.AppendLine(BuildAnalyseParamByCheckCarFast(AccidentAlarmSubType,CarFast));
            sb.AppendLine(BuildAnalyseParamByCheckCarLow(AccidentAlarmSubType,CarLow));
            sb.AppendLine(BuildAnalyseParamByCheckCarStop(AccidentAlarmSubType,CarStop));
            sb.AppendLine("</Accident>");

            sb.AppendLine(BuildAnalyseParamByFlux(AccidentAlarmSubType,FluxTimelyReportTimeInterval));

            sb.AppendLine("</AlgorithmInitParam>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCarPlate(System.Drawing.Rectangle rect, bool VehicleNoplatInclude)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CarPlate>");
            sb.AppendLine("<CarPlateCheckRegion>");
            sb.AppendLine("<LTPoint>");
            sb.AppendLine("<X>" + rect.X + "</X>");
            sb.AppendLine("<Y>" + rect.Y + "</Y>");
            sb.AppendLine("</LTPoint>");
            sb.AppendLine("<Width>" + rect.Width + "</Width>");
            sb.AppendLine("<Height>" + rect.Height + "</Height>");
            sb.AppendLine("</CarPlateCheckRegion>");
            sb.AppendLine("<CheckNoCarPlate>" + VehicleNoplatInclude.ToString().ToUpper() + "</CheckNoCarPlate>");
            sb.AppendLine("</CarPlate>");

            return sb.ToString();
        }

        private string BuildAnalyseParamByCheckNoReverse(AccidentAlarmSubType AccidentAlarmSubType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoReverse>" + ((AccidentAlarmSubType.CheckNoReverse & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</CheckNoReverse>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckJam(AccidentAlarmSubType AccidentAlarmSubType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckJam>" + ((AccidentAlarmSubType.CheckJam & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</CheckJam>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckPassagerCross(AccidentAlarmSubType AccidentAlarmSubType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckPassagerCross>" + ((AccidentAlarmSubType.CheckPassagerCross & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</CheckPassagerCross>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarCross(AccidentAlarmSubType AccidentAlarmSubType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarCross>" + ((AccidentAlarmSubType.CheckCarCross & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</CheckCarCross>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarFast(AccidentAlarmSubType AccidentAlarmSubType, uint CarFast)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarFast>");
            sb.AppendLine("<Enable>" + ((AccidentAlarmSubType.CheckCarFast & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</Enable>");
            sb.AppendLine("<Limen>" + CarFast + "</Limen>");
            sb.AppendLine("</CheckCarFast>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarLow(AccidentAlarmSubType AccidentAlarmSubType, uint CarLow)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarLow>");
            sb.AppendLine("<Enable>" + ((AccidentAlarmSubType.CheckCarLow & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</Enable>");
            sb.AppendLine("<Limen>" + CarLow + "</Limen>");
            sb.AppendLine("</CheckCarLow>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarStop(AccidentAlarmSubType AccidentAlarmSubType, uint CarStop)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarStop>");
            sb.AppendLine("<Enable>" + ((AccidentAlarmSubType.CheckCarStop & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</Enable>");
            sb.AppendLine("<Limen>" + CarStop + "</Limen>");
            sb.AppendLine("</CheckCarStop>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByFlux(AccidentAlarmSubType AccidentAlarmSubType, uint FluxTimelyReportTimeInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Flux>");
            sb.AppendLine("<Enable>" + ((AccidentAlarmSubType.Flux & AccidentAlarmSubType) > 0).ToString().ToUpper() + "</Enable>");
            sb.AppendLine("<TimelyReportTimeInterval>" + FluxTimelyReportTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("</Flux>");

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
                var ana = IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginIDRias, analyseID);
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
                if (item.tEventParam.dwAnalyseType == Convert.ToUInt32(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD)
                    && item.tEventParam.szCameraID == cameraCode)
                    m_lastEvent.Add(item);
            }
        }
        private void RecoverEvent(uint analyseID)
        {
            RealAnalyseInfo info = GetAllPlate().Find(item => item.dwAnalysisID == analyseID);
            if (info != null)
            {
                foreach (var item in m_lastEvent)
                {
                    item.tEventParam.dwTaskUnitID = info.realAnalyseParam.dwAnalysisPlanID;
                    AddEvent(item.tEventParam);
                }
            }
        }

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
                    ret = ret && DelEvent(item.dwEventID);
            }
            return ret;
        }

        #endregion
        

    }
}
