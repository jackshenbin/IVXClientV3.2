using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    /// <summary>
    /// 任务详细信息
    /// </summary>
    [Serializable]
    public class TaskInfoV3_1 : ICloneable
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public UInt32 TaskId { get; set; }
        /// <summary>
        /// 任务名
        /// </summary>
        public string TaskName { get; set; }
        public UInt32 Priority { get; set; }
        public TaskFileType FileType { get; set; }
        public TaskType TaskType { get; set; }
        public UInt64 FileSize { get; set; }
        public string DeviceName { get; set; }
        public E_VDA_NET_STORE_DEV_PROTOCOL_TYPE DeviceType { get; set; }
        public E_VDA_NET_STORE_DEV_PROTOCOL_TYPE ProtocolType { get; set; }
        public string DeviceIP { get; set; }
        public UInt32 DevicePort { get; set; }
        public string LoginUser { get; set; }
        public string LoginPwd { get; set; }
        public string ChannelID { get; set; }
        public string CameraID { get; set; }
        public List<StatusInfoV3_1> StatusList { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StoreIP { get; set; }
        public UInt32 StorePort { get; set; }
        public string OriFilePath { get; set; }
        public UInt32 UserHandle { get; set; }
        public UInt32 Order { get; set; }
        public override string ToString()
        {
            if (this.TaskType == DataModel.TaskType.Realtime)
            {
                var strlist = this.TaskName.Split(new char[]{'_'},3, StringSplitOptions.RemoveEmptyEntries);
                string camName = this.TaskName;
                if (strlist.Length > 2)
                    camName =strlist[2];


                //int index = this.TaskName.LastIndexOf("_相机");
                //string camName = (index < 0) ? this.TaskName : this.TaskName.Substring(index + 1);
                return camName;
            }
            else
                return TaskName;
        }

        public SearchItemV3_1 ToSearchItem()
        {
            string name = this.TaskName;
            if (this.TaskType == DataModel.TaskType.Realtime)
            {
                var strlist = this.TaskName.Split(new char[] { '_' }, 3, StringSplitOptions.RemoveEmptyEntries);
                if (strlist.Length > 2)
                    name = strlist[2];
                else
                    name = this.CameraID;
            }
            //int index = this.TaskName.LastIndexOf("_相机");
            //string camName = (index < 0) ? this.CameraID : this.TaskName.Substring(index + 1);
            return new SearchItemV3_1()
            {
                CameraID = this.CameraID,
                CameraName = name,
                SearchHandle = 0,
                TaskId = this.TaskId,
                TaskName = this.TaskName,
                AdjustTime = this.StartTime,
            };
        }

        public object Clone()
        {
            List<StatusInfoV3_1> info = new List<StatusInfoV3_1>();
            info.AddRange(this.StatusList.ToArray());
            return new TaskInfoV3_1()
            {
                TaskId = this.TaskId,
                StatusList = info,
                CameraID = this.CameraID,
                ChannelID = this.ChannelID,
                DeviceIP = this.DeviceIP,
                DeviceName = this.DeviceName,
                DevicePort = this.DevicePort,
                DeviceType = this.DeviceType,
                EndTime = this.EndTime,
                FileSize = this.FileSize,
                FileType = this.FileType,
                LoginPwd = this.LoginPwd,
                LoginUser = this.LoginUser,
                Order = this.Order,
                OriFilePath = this.OriFilePath,
                Priority = this.Priority,
                ProtocolType = this.ProtocolType,
                StartTime = this.StartTime,
                StoreIP = this.StoreIP,
                TaskName = this.TaskName,
                StorePort = this.StorePort,
                TaskType = this.TaskType,
                UserHandle = this.UserHandle,
            };
        }


        public override bool Equals(object obj)
        {
            TaskInfoV3_1 temp = obj as TaskInfoV3_1;
            if (temp == null)
                return false;

            if (temp.StatusList.Count != this.StatusList.Count)
                return false;
            foreach (var it in temp.StatusList)
            {
                if (!this.StatusList.Exists(
                    xx=>xx.AlgthmType == it.AlgthmType 
                    && xx.AnalyseParam==it.AnalyseParam
                    && xx.LeftTime == it.LeftTime 
                    && xx.Progress==it.Progress 
                    && xx.Status ==it.Status))
                    return false;
            }
            foreach (var it in this.StatusList)
            {
                if (!temp.StatusList.Exists(
                    xx=>xx.AlgthmType == it.AlgthmType 
                    && xx.AnalyseParam==it.AnalyseParam
                    && xx.LeftTime == it.LeftTime 
                    && xx.Progress==it.Progress 
                    && xx.Status ==it.Status))
                    return false;
            }
            return (temp.TaskId == this.TaskId &&
             temp.CameraID == this.CameraID &&
             temp.ChannelID == this.ChannelID &&
             temp.DeviceIP == this.DeviceIP &&
             temp.DeviceName == this.DeviceName &&
             temp.DevicePort == this.DevicePort &&
             temp.DeviceType == this.DeviceType &&
             temp.EndTime == this.EndTime &&
             temp.FileSize == this.FileSize &&
             temp.FileType == this.FileType &&
             temp.LoginPwd == this.LoginPwd &&
             temp.LoginUser == this.LoginUser &&
             temp.Order == this.Order &&
             temp.OriFilePath == this.OriFilePath &&
             temp.Priority == this.Priority &&
             temp.ProtocolType == this.ProtocolType &&
             temp.StartTime == this.StartTime &&
             temp.StoreIP == this.StoreIP &&
             temp.TaskName == this.TaskName &&
             temp.StorePort == this.StorePort &&
             temp.TaskType == this.TaskType &&
             temp.UserHandle == this.UserHandle);
        }

        
    };
}
