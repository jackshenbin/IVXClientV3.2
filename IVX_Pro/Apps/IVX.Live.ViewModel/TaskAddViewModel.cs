using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.Reflection;
using System.IO;

namespace IVX.Live.ViewModel
{
    public class TaskAddViewModel
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
                    m_TaskList.Columns.Add("AlgthmParam");
                    m_TaskList.Columns.Add("StartTime", typeof(DateTime));
                    m_TaskList.Columns.Add("EndTime", typeof(DateTime));
                    m_TaskList.Columns.Add("OriFilePath");
                    m_TaskList.Columns.Add("SplitTime", typeof(UInt32));
                    m_TaskList.Columns.Add("FileSizeView");

                }
                return m_TaskList;
            }
            set { m_TaskList = value; }
        }

        private string UpdateName(string name)
        {
            int index = 0;
            string ret = name;
            for (int i = 0; i < m_TaskList.Rows.Count; i++)
            {
                if (m_TaskList.Rows[i]["TaskName"].ToString().IndexOf(name) == 0)
                {
                    int tempindex = 0;
                    string temp = m_TaskList.Rows[i]["TaskName"].ToString().Replace(name, "");
                    if (string.IsNullOrEmpty(temp))
                    {
                        tempindex = 1;
                        index = Math.Max(index, tempindex);
                    }
                    if (temp.IndexOf('_') == 0)
                    {
                        temp = temp.Replace("_", "");
                        if (int.TryParse(temp, out tempindex))
                        {
                            index = Math.Max(index, tempindex);
                        }
                    }
                }
            }
            if (index > 0)
                ret = name + "_" + (index+1);
            return ret;
        }

        public void AddFile(string fullname, string name, UInt64 filesize, uint type, uint analysetype, DateTime st = new DateTime(), DateTime et = new DateTime(),uint splitTime=0)
        {
            if(st == new DateTime()) st = DateTime.Now;
            if (et == new DateTime()) et = DateTime.Now;

            name = UpdateName(name);
            m_TaskList.Rows.Add(name, type, filesize, analysetype, "", st, et, fullname, splitTime,DataModel.Common.GetByteSizeInUnit(filesize));
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

        public void DelFile(string filename)
        {
            foreach (DataRow item in m_TaskList.Rows)
            {
                if (item["TaskName"].ToString() == filename)
                {
                    m_TaskList.Rows.Remove(item);
                    break;
                }
            }
        }

        private bool Validate()
        {
            if (m_TaskList.Rows.Count <= 0)
                return false;


            return true;

        }
        private string GetDefaultAnalyseParam(E_VIDEO_ANALYZE_TYPE type)
        {
            string path = Framework.Container.ExecutingPath;
            if (string.IsNullOrEmpty(path))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                path = Directory.GetParent(asm.Location).FullName;
            }

            string configFile = Path.Combine(path, "AnalyseParam\\" + type.ToString() + ".xml");
            string param = "";
            if (File.Exists(configFile))
            {
                param = File.ReadAllText(configFile);
            }

            return param;
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
                if (type == (uint)TaskFileType.PlateFile)
                {
                    string[] platitems = item["OriFilePath"].ToString().Split('`');
                    deviceName = item["OriFilePath"].ToString();
                    deviceIP = platitems[0];
                    devicePort = Convert.ToUInt32(platitems[1]);
                    deviceType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)Convert.ToInt32(platitems[2]);
                    protocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)Convert.ToInt32(platitems[2]);
                    loginUser = platitems[3];
                    loginPwd = platitems[4];
                    channelID = platitems[5];
                }
                string param = item["AlgthmParam"].ToString();
                if (string.IsNullOrEmpty(param))
                    param = GetDefaultAnalyseParam((E_VIDEO_ANALYZE_TYPE)Convert.ToInt32(item["AlgthmType"]));
                var task = new TaskInfoV3_1()
                {
                    TaskId = 0,
                    TaskType = TaskType.History,
                    TaskName = item["TaskName"].ToString(),
                    StorePort = 0,
                    StoreIP = "",
                    ProtocolType = protocolType,
                    OriFilePath = item["OriFilePath"].ToString(),
                    LoginUser = loginUser,
                    CameraID = item["TaskName"].ToString(),
                    ChannelID = channelID,
                    DeviceIP = deviceIP,
                    DeviceName = deviceName,
                    DevicePort = devicePort,
                    DeviceType = deviceType,
                    EndTime = (DateTime)item["EndTime"],
                    FileSize = (UInt64)item["FileSize"],
                    FileType = (TaskFileType)Convert.ToInt32(item["FileType"]),
                    LoginPwd = loginPwd,
                    StartTime = (DateTime)item["StartTime"],
                    StatusList = new List<StatusInfoV3_1>(),
                    UserHandle = 0,
                    Priority = 0,
                    Order = 0,
                };
                task.StatusList.Add(new StatusInfoV3_1()
                    {
                        AlgthmType = (E_VIDEO_ANALYZE_TYPE)Convert.ToInt32(item["AlgthmType"]),
                        AnalyseParam = param,
                        Progress = 0,
                        Status = 0,
                    LeftTime = 0,
                    });
                tasklist.Add(task);
            }
            var retlist = Framework.Container.Instance.CommService.ADD_TASK(tasklist);
            foreach (DataRow item in m_TaskList.Rows)
            {
                try
                {
                    var key = retlist.Single(it => it.Value == item["TaskName"].ToString());
                    Framework.Container.Instance.CommService.TASK_REANALYSE(key.Key, (E_VIDEO_ANALYZE_TYPE)Convert.ToInt32(item["AlgthmType"]), "", Convert.ToUInt32(item["SplitTime"].ToString()));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return true;
        }
    }
}
