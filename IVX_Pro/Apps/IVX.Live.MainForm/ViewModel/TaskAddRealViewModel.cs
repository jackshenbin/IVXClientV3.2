using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.MainForm.ViewModel
{
    class TaskAddRealViewModel
    {
        public DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Channel { get; set; }


        private DataTable m_TaskList;
        
        public DataTable TaskList
        {
            get
            {
                if (m_TaskList == null)
                {
                    m_TaskList = new DataTable("TaskList");
                    m_TaskList.Columns.Add("TaskName");
                    m_TaskList.Columns.Add("FileType", typeof(UInt32));
                    m_TaskList.Columns.Add("FileSize", typeof(UInt64));
                    m_TaskList.Columns.Add("AlgthmType", typeof(UInt32));
                    m_TaskList.Columns.Add("StartTime", typeof(DateTime));
                    m_TaskList.Columns.Add("EndTime", typeof(DateTime));
                    m_TaskList.Columns.Add("OriFilePath");
                    m_TaskList.Columns.Add("FileSizeView");

                }
                return m_TaskList;
            }
            set { m_TaskList = value; }
        }

        
        public void AddFile(string fullname, string name, UInt64 filesize, uint type)
        {
            m_TaskList.Rows.Add(name, type, filesize, 0, DateTime.Now, DateTime.Now, fullname, DataModel.Common.GetByteSizeInUnit(filesize));
        }

        public void AddFile(string fullname, string name, UInt64 filesize, uint type,DateTime st ,DateTime et)
        {
            m_TaskList.Rows.Add(name, type, filesize, 0, st,et, fullname, DataModel.Common.GetByteSizeInUnit(filesize));
        }
        public void DelFile(object obj)
        {
            DataRowView row = obj as DataRowView;
            if (row != null)
            {
                DataRow r = row.Row;
                m_TaskList.Rows.Remove(r);
            }
        }

        private bool Validate()
        {
            if (m_TaskList.Rows.Count <= 0)
                return false;


            return true;

        }

        public List<object[]> InitFileList(string  channel, DateTime st, DateTime et)
        {
            List<object[]> list = new List<object[]>();
            ConfigServices.DIOService server = new ConfigServices.DIOService(Framework.Container.Instance.IVXProtocol);
            server.Login(Protocol, IP, (ushort)Port, User, Pass);
            IVX.Live.ConfigServices.Interop.TDIO_ChannelInfo chinfo = new ConfigServices.Interop.TDIO_ChannelInfo();
            chinfo.szChannelId = channel;
            chinfo.szChannelName = channel;
            chinfo.szRest = "0";
            foreach (ConfigServices.Interop.TDIO_StrmFileInfo item in server.GetFileListByTime(chinfo, st, et))
            {
                string filefullname = string.Format("{0}`{1}`{2}`{3}`{4}`{5}", server.m_currIP, server.m_currPort, (int)server.m_connType, server.m_currUser, server.m_currPass, chinfo.szChannelId);
                string filename = string.Format("{0}-{1}", DataModel.Common.ConvertLinuxTime(item.tStart).ToString("yyyyMMddHHmmss"), DataModel.Common.ConvertLinuxTime(item.tStop).ToString("yyyyMMddHHmmss"));
                string filesize = item.qwFileSize.ToString();
                string fst = item.tStart.ToString();
                string fet = item.tStop.ToString();

                list.Add(new object[] { filefullname, filename, filesize, fst, fet });
            }

            return list;
        }

        public bool Submit(string param)
        {
            if (!Validate())
                return false;

            List<TaskInfoV3_1> tasklist = new List<TaskInfoV3_1>();
            foreach (DataRow item in m_TaskList.Rows)
            {
                string channelID = "";
                string deviceIP = "";
                string deviceName = "";
                uint devicePort = 0;
                DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE deviceType = E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE;
                DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE protocolType = E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE;
                string loginUser = "";
                string loginPwd = "";
                uint type = (UInt32)item["FileType"];
                if (type == 3)
                {
                    string[] platitems = item["OriFilePath"].ToString().Split('`');
                    deviceName = item["OriFilePath"].ToString();
                    deviceIP = platitems[0];
                    devicePort = Convert.ToUInt32( platitems[1]);
                    deviceType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)Convert.ToInt32(platitems[2]);
                    protocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)Convert.ToInt32(platitems[2]);
                    loginUser = platitems[3];
                    loginPwd = platitems[4];
                    channelID = platitems[5];
                }
                tasklist.Add(new TaskInfoV3_1()
                {
                    TaskId = 0,
                    TaskType =  TaskType.History,
                    TaskName = item["TaskName"].ToString(),
                    StorePort = 0,
                    StoreIP = "",
                    Status = 0,
                    ProtocolType = protocolType,
                    OriFilePath = item["OriFilePath"].ToString(),
                    LoginUser = loginUser,
                    AlgthmType = (E_VIDEO_ANALYZE_TYPE)Convert.ToInt32(item["AlgthmType"]),
                    AnalyseParam = "",
                    CameraID = item["TaskName"].ToString(),
                    ChannelID = channelID,
                    DeviceIP = deviceIP,
                    DeviceName = deviceName,
                    DevicePort = devicePort,
                    DeviceType =  deviceType,
                    EndTime = (DateTime)item["EndTime"],
                    FileSize = (UInt64)item["FileSize"],
                    FileType = (TaskFileType)Convert.ToInt32( item["FileType"]),
                    LoginPwd = loginPwd,
                    StartTime = (DateTime)item["StartTime"],
                });
            }
            IVX.Live.MainForm.Framework.Container.Instance.CommService.ADD_TASK(tasklist);


            return true;
        }
    }
}
