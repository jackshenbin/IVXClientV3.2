using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// using IVX.Live.Config.Framework;

using IVX.DataModel;
using System.Diagnostics;
using IVX.Live.ConfigServices.Interop;

namespace IVX.Live.ConfigServices
{
    public class AdpsEventService
    {
        private uint m_loginID = 0;

        private IVXRealtimeProtocol m_protocol;

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

        #region Constructors

        public AdpsEventService(IVXRealtimeProtocol protocol)
        {
            m_protocol = protocol;
        }

        #endregion

        #region Public helper functions

        public bool LoginServer(string ip, uint port)
        {
            if (m_loginID > 0)
                IVXProtocol.AdpsSdk_Logout(m_loginID);

            IVXProtocol.AdpsSdk_Login(ip, (ushort)port, out m_loginID);
            string ver = IVXProtocol.AdpsSdk_GetSdkVersion();
            return (m_loginID > 0);
        }

        public void LogoutServer()
        {
            if (m_loginID > 0)
                IVXProtocol.AdpsSdk_Logout(m_loginID);
            m_loginID = 0;
        }

        public AdpsInfo GetAdpsEventByID(uint eventID)
        {
            return IVXProtocol.AdpsSdk_GetEventInfoByID(m_loginID, eventID);
        }

        public List<AdpsInfo> GetAllEvents()
        {
            //List<AdpsInfo> list = new List<AdpsInfo>();
            //for (int i = 0; i < 6; i++)
            //{
            //    AdpsInfo info = new AdpsInfo()
            //    {
            //        dwEventID = (uint)i,
            //        eStatusType = (uint)(i%2),
            //        tEventParam = new AdpsParam()
            //        {
            //            dwAnalyseType = (uint)(i % 5),
            //            dwMergeStyle = (uint)(i % 3),
            //            dwProtocolType = (uint)(i % 10),
            //            dwStoreStyle = (uint)(i % 2),
            //            dwTaskType = (uint)(i % 2),
            //            dwTaskUnitID = (uint)i,
            //            szCameraID = i.ToString(),
            //            szReceiveIp = "192.168.1."+i,
            //            szServerIp = "192.168.2." + i,
            //            wReceivePort = (ushort)(5410 + i),
            //            wServerPort = (ushort)(5420 + i),
            //        },
            //    };

                
            //    list.Add(info);
            //}
            //return list;

            uint count = 0;
            IVXProtocol.AdpsSdk_GetEventNum(m_loginID, out count);
            return IVXProtocol.AdpsSdk_GetEventList(m_loginID, count);
        }

        public AdpsServerUnitInfo GetOneProcessAdps()
        {
            //return new AdpsServerUnitInfo() { dwServerID = 1, szDescription = "", szServerIp = "192.168.1.1", wIsUsed = 1, wServerPort = 6021, wServerType = 1, };
            return IVXProtocol.AdpsSdk_GetProcessUnitInfo(m_loginID);
        }
        
        public uint AddEvent(AdpsParam param)
        {
            uint anaID=0;
            IVXProtocol.AdpsSdk_AddEvent(m_loginID, param, out anaID);
            return anaID;
        }

        public uint EditEvent(uint anaID,AdpsParam param)
        {
            IVXProtocol.AdpsSdk_UpdateEvent(m_loginID, param, anaID);
            return anaID;
        }

        public bool DelEvent(uint eventID)
        {
            if (eventID > 0)
            {
                return IVXProtocol.AdpsSdk_DelEvent(m_loginID, eventID);
            }
            else
            {
                return true;
            }
        }

        public bool DelEventBy(uint dwTaskUnitID, string szCameraID, uint dwAnalyseType)
        {
            bool ret = true;
            foreach (var item in GetAllEvents())
	        {
                if (item.tEventParam.dwTaskUnitID == dwTaskUnitID && item.tEventParam.szCameraID == szCameraID && item.tEventParam.dwAnalyseType == dwAnalyseType)
                    ret =ret &&  DelEvent(item.dwEventID);
	        }
            return ret;
        }

        public List<MergeTemplateInfo> GetAllMergeModel()
        {
            //List<MergeTemplateInfo> list = new List<MergeTemplateInfo>();
            //for (int i = 1; i < 4; i++)
            //{
            //    list.Add(new MergeTemplateInfo() { TemplateID = (uint)i, TemplateContent = "sfadsf", TemplateName = "saf" + i });
            //}
            //return list;

            uint pdwTemplateNum = 0;
            IVXProtocol.AdpsSdk_GetTemplateNum(m_loginID,out pdwTemplateNum);
            return IVXProtocol.AdpsSdk_GetTemplateList(m_loginID, pdwTemplateNum);
            
        }

        public MergeTemplateInfo GetMergeModelByID(uint dwTemplateHandle)
        {
            return IVXProtocol.AdpsSdk_GetTemplateInfoByID(m_loginID, dwTemplateHandle);
        }

        public bool DelMergeModel(uint dwTemplateHandle)
        {
            IVXProtocol.AdpsSdk_DelTemplate(m_loginID, dwTemplateHandle);
            return true;
        }

        public uint AddMergeModel(string name, string content)
        {
            uint id = 0;
            IVXProtocol.AdpsSdk_AddTemplate(m_loginID, name, content, out id);
            return id;
        }

        public bool UpdateMergeModel(uint id, string name, string content)
        {
            IVXProtocol.AdpsSdk_UpdateTemplate(m_loginID, id, name, content);
            return true;
        }

        #endregion
        
        #region Event handlers

        #endregion
    }
}
