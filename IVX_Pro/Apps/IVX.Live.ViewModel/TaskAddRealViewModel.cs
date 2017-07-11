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
    public class TaskAddRealViewModel
    {
        public DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Channel { get; set; }
        public string CameraID { get; set; }

        public string CameraName { get; set; }
        public E_VIDEO_ANALYZE_TYPE AnalyseType { get; set; }

        
        private bool Validate()
        {

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
            string AnalyseTypename = DataModel.Constant.VideoAnalyzeTypeInfo.Single(item => item.Type == AnalyseType).Name;
            List<TaskInfoV3_1> tasklist = new List<TaskInfoV3_1>();

            if (string.IsNullOrEmpty(param))
                param = GetDefaultAnalyseParam(AnalyseType);

            var task = new TaskInfoV3_1()
                {
                    TaskId = 0,
                    TaskType = TaskType.Realtime,
                    TaskName = "实时_" + AnalyseTypename + "_" + CameraName,
                    StorePort = 0,
                    StoreIP = "",
                    ProtocolType = Protocol,
                    OriFilePath = "",
                    LoginUser = User,
                    CameraID = CameraID,
                    ChannelID = Channel,
                    DeviceIP = IP,
                    DeviceName = IP + "_" + Port,
                    DevicePort = Port,
                    DeviceType = Protocol,
                    EndTime = new DateTime(),
                    FileSize = 0,
                    FileType = TaskFileType.None,
                    LoginPwd = Pass,
                    StartTime = new DateTime(),
                    StatusList = new List<StatusInfoV3_1>(),
                    Order = 0,
                    Priority = 0,
                    UserHandle = 0,
                };
            task.StatusList.Add(new StatusInfoV3_1()
            {
                AlgthmType = AnalyseType,
                AnalyseParam = param,
                Status = 0,
                Progress = 0,
                LeftTime = 0,
            });
            tasklist.Add(task);

            Framework.Container.Instance.CommService.ADD_TASK(tasklist);

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


    }
}
