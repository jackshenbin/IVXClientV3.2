using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.MainForm.ViewModel
{
    class TaskAddViewModel
    {

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

        public bool Submit()
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
