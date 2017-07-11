using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// // using IVX.Live.Config.Framework;

using IVX.DataModel;
using System.Diagnostics;
using IVX.Live.ConfigServices.Interop;

namespace IVX.Live.ConfigServices
{
    public class RealtimeAnalyseService
    {
        public event EventHandler AnalyseAdded;
        public event EventHandler AnalyseDeleted;
        public event EventHandler AnalyseStateChanged;
        public event EventHandler DisConnected;

        private uint m_loginID = 0;

        private IVXRealtimeProtocol m_protocol;

        private AdpsEventService m_AdpsEventService;

        public bool IsLogin
        {
            get { return m_loginID > 0; }
        }

        private IVXRealtimeProtocol IVXProtocol
        {
            get
            {
                return m_protocol;
            }
        }
        
        private AdpsEventService AdpsEventService
        {
            get
            {
                return m_AdpsEventService;
            }
        }

        #region Constructors

        public RealtimeAnalyseService(IVXRealtimeProtocol protocol, AdpsEventService adpsEventService)
        {
            m_protocol = protocol;
            m_AdpsEventService = adpsEventService;
            IVXProtocol.EventDisConnectd += IVXProtocol_EventDisConnectd;
            IVXProtocol.EventAnalyseStateChanged += IVXProtocol_EventAnalyseStateChanged;
        }

        void IVXProtocol_EventAnalyseStateChanged(uint dwLoginID, uint dwAnalysisID, E_IASSDK_REAL_ANALYZE_STATUS_TYPE eStatusType, ulong qwContext)
        {
            if (AnalyseStateChanged != null && dwLoginID == m_loginID)
                AnalyseStateChanged(dwAnalysisID,null);
        }

        void IVXProtocol_EventDisConnectd(uint dwLoginID, ulong qwContext)
        {
            if (DisConnected != null )
                DisConnected(null, null);
        }

        #endregion

        #region Public helper functions

        public bool LoginServer(string ip, uint port)
        {
            if (m_loginID > 0)
                IVXProtocol.IasSdk_Logout(m_loginID);
            
            IVXProtocol.IasSdk_Login(ip, (ushort)port, out m_loginID);
            string ver = IVXProtocol.IasSdk_GetServerVersion(m_loginID);

            return (m_loginID > 0);
            
        }

        public void LogoutServer()
        {
            if (m_loginID > 0)
                IVXProtocol.IasSdk_Logout(m_loginID);
            m_loginID = 0;

        }

        public RealAnalyseInfo GetRealAnalysisByID(uint realAnalysisID)
        {
            try
            {
                return IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginID, realAnalysisID);
            }
            catch (SDKCallException ex)
            {
                return null;
            }

        }

        public List<RealAnalyseInfo> GetAllRealAnalysis()
        {
            //List<RealAnalyseInfo> list = new List<RealAnalyseInfo>();
            //for (int i = 1; i < 18; i++)
            //{
            //    RealAnalyseInfo info = new RealAnalyseInfo()
            //    {
            //        dwAnalysisID = (uint)i,
            //        realAnalyseServerInfo = new RealAnalyseServerUnitInfo()
            //        {
            //            dwServerID = (uint)i,
            //            szServerIp = "192.168.2."+i,
            //            wServerPort = (ushort)(5420+i),
            //            serverType = E_IASSDK_SERVER_UNIT_TYPE.E_IASSDK_ANALYSIS_UNIT_TWO,
            //        },
            //        realAnalyseParam = new RealAnalyseParam()
            //        {
            //            dwAnalysisPlanID = (uint)i,
            //            eAlgthmType =  (E_IASSDK_VIDEO_ANALYZE_TYPE)(i%5),
            //            szAnalysisParam = "",
            //            szArsIp = "192.168.1." + i,
            //            wArsPort = (ushort)(5410 + i),
            //            realCameraInfo = new RealCameraInfo()
            //            {
            //                dwDevicePort = 37777,
            //                dwDeviceType = 1025,
            //                szCameraID = i.ToString(),
            //                szChannelID = i.ToString(),
            //                szDeviceIP = "192.168.88.250",
            //                szLoginPwd ="admin",
            //                szLoginUser = "admin",
            //            },
            //        },
            //        dwConSerialNum = (uint)(i%2),
            //        eStatusType =  (E_IASSDK_REAL_ANALYZE_STATUS_TYPE)(i%2),

            //    };
            //    list.Add(info);
            //}
            //return list;

            uint count = 0;
            IVXProtocol.IasSdk_GetRTAnalysisNum(m_loginID, out count);
            //RealAnalyseInfo temp = IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginID, 1);
            return IVXProtocol.IasSdk_GetRTAnalysisList(m_loginID, count);
        }

        
        public uint AddRealAnalyse(RealAnalyseParam param)
        {
            uint anaID=0;
            IVXProtocol.IasSdk_AddRTAnalysis(m_loginID, param, out anaID);
            if (AnalyseAdded != null)
                AnalyseAdded(anaID, null);
            return anaID;
        }

        public bool DelRealAnalyse(uint analyseID)
        {
            if (analyseID > 0)
            {
                var ana= IVXProtocol.IasSdk_GetRTAnalysisInfoByID(m_loginID,analyseID);
                if(ana!=null)
                    AdpsEventService.DelEventBy(ana.realAnalyseParam.dwAnalysisPlanID, ana.realAnalyseParam.realCameraInfo.szCameraID, Convert.ToUInt32(ana.realAnalyseParam.eAlgthmType));
                IVXProtocol.IasSdk_DelAnalysis(m_loginID, analyseID);
                if (AnalyseDeleted != null)
                    AnalyseDeleted(analyseID, null);
                return true;
            }
            else
            {
                if (AnalyseDeleted != null)
                    AnalyseDeleted(analyseID, null);
                return true;
            }
        }
        
        public uint GetRealAnalyseCapable()
        {
            uint count = 0;
            IVXProtocol.IasSdk_GetServiceCapacity(m_loginID, out count);
            return count;
        }

        public uint GetRealAnalyseCapableLeft()
        {
            uint total = 0;
            uint count = 0;
            IVXProtocol.IasSdk_GetServiceCapacity(m_loginID, out total);
            IVXProtocol.IasSdk_GetRTAnalysisNum(m_loginID,out count);
            return total - count;
        }


        #endregion
        
        #region Event handlers

        #endregion
    }
}
