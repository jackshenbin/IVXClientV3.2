using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SettingViewModel
    {

        public DataTable ServerList
        {
            get 
            {
                DataTable t = new DataTable();
                var key = t.Columns.Add("ServerId");
                t.PrimaryKey = new DataColumn[] { key };
                t.Columns.Add("ServerType");
                t.Columns.Add("ServerIP");
                t.Columns.Add("ServerPort");
                t.Columns.Add("Status");
                t.Columns.Add("Description");
                foreach(var item in Framework.Container.Instance.CommService.GET_SVERVER_LIST())
                {
                    var serverType = Constant.ServerTypeInfos.FirstOrDefault(it => it.Type == item.ServerType);
                    string serverTypeStr = serverType == null ? "服务器" : serverType.ToString();
                    var status = Constant.ServerStatusInfos.FirstOrDefault(it => it.Type == item.Status);
                    string statusStr = status == null ? "未知" : status.ToString();
                    t.Rows.Add(item.ServerId, serverTypeStr, item.ServerIP, item.ServerPort, statusStr, item.Description);
                }
                return t; 
            }
        }
        private List<CameraInfoV3_1> m_cameraList;

        List<CameraInfoV3_1> CameraList
        {
            get
            {
                if (m_cameraList == null)
                    m_cameraList = Framework.Container.Instance.CommService.GET_CAMERA_LIST();
                return m_cameraList;
            }
        }
        public DataTable CameraInfoList
        {
            get
            {
                DataTable t = new DataTable();
                var key = t.Columns.Add("ID");
                t.PrimaryKey = new DataColumn[] { key };
                t.Columns.Add("CameraName");
                t.Columns.Add("CameraID");
                t.Columns.Add("VideoSupplierChannelID");
                t.Columns.Add("PosCoordX");
                t.Columns.Add("PosCoordY");
                foreach (var item in CameraList)
                {
                    t.Rows.Add(item.ID, item.CameraName, item.CameraID, item.VideoSupplierChannelID, item.PosCoordX, item.PosCoordY);
                }
                return t;
            }
        }

        public DataTable GetCameraListByVideoSupplierID(uint id)
        {                
            DataTable t = new DataTable();
                var key = t.Columns.Add("ID");
                t.PrimaryKey = new DataColumn[] { key };
                t.Columns.Add("CameraName");
                t.Columns.Add("CameraID");
                t.Columns.Add("VideoSupplierChannelID");
                t.Columns.Add("PosCoordX");
                t.Columns.Add("PosCoordY");
                foreach (var item in CameraList.FindAll(it => it.VideoSupplierDeviceID == id))
                {
                    t.Rows.Add(item.ID,item.CameraName,  item.CameraID,item.VideoSupplierChannelID, item.PosCoordX, item.PosCoordY);
                }
                return t; 

        }
        public DataTable VideoSupplierList
        {
            get
            {
                DataTable t = new DataTable();
                var key = t.Columns.Add("Id");
                t.PrimaryKey = new DataColumn[] { key };
                t.Columns.Add("DeviceName");
                t.Columns.Add("ProtocolType");
                t.Columns.Add("IP");
                t.Columns.Add("Port");
                t.Columns.Add("UserName");
                t.Columns.Add("Password");
                foreach (var item in Framework.Container.Instance.CommService.GET_NET_STORE_LIST())
                {
                    var ProtocolType = Constant.AccessProtocolTypeInfos.FirstOrDefault(it => it.Type == item.ProtocolType);
                    string ProtocolTypeStr = ProtocolType == null ? "" : ProtocolType.ToString();
                    t.Rows.Add(item.Id,item.DeviceName, ProtocolTypeStr, item.IP, item.Port, item.UserName,item.Password);
                }
                return t; 
            }
        }


        public void DelVideoSupplierByID(uint id)
        {
            Framework.Container.Instance.CommService.DEL_NET_STORE(id);
        }

        public bool AddVideoSupplier(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE type, string name, string ip, uint port, string username, string password)
        {
            uint ret = Framework.Container.Instance.CommService.ADD_NET_STORE(type, name, ip, port, username, password);
            return ret == 0;
        }

        public bool AddServer(string ip, uint port, E_VDA_SERVER_TYPE type,string des)
        {
            uint ret = Framework.Container.Instance.CommService.ADD_SVERVER(ip,port,type, des);
            return ret == 0;

        }

        public void DelServerByID(uint id)
        {
            Framework.Container.Instance.CommService.DEL_SVERVER(id);
        }
        public bool AddCamera(uint netstoreid,string channel, string name, string cameraId,double x,double y)
        {
            uint ret = Framework.Container.Instance.CommService.ADD_CAMERA(netstoreid,channel, name, cameraId,x,y);
            return ret == 0;

        }

        public void DelCameraByID(uint id)
        {
            Framework.Container.Instance.CommService.DEL_CAMERA(id);
        }

        public void FlushCameraList()
        { 
            m_cameraList = null;
            var list = CameraList;
        }


        public DataTable GetTransEventListByID(uint taskid)
        {
            DataTable t = new DataTable();
            var key = t.Columns.Add("EventID");
            t.PrimaryKey = new DataColumn[] { key };
            t.Columns.Add("TaskID");
            t.Columns.Add("MergeStyle");
            t.Columns.Add("StoreStyle");
            t.Columns.Add("ReceiveIp");
            t.Columns.Add("ReceivePort");
            t.Columns.Add("ProtocolType");
            t.Columns.Add("AnalyseType");
            foreach (var item in Framework.Container.Instance.CommService.GET_TASK_EVENT_LIST(taskid))
            {
                var protocolType = Constant.TransProtocolTypeInfos.FirstOrDefault(it => it.Type == item.ProtocolType);
                string protocolTypeStr = protocolType == null ? "未知" : protocolType.ToString();
                var storeStyle = Constant.TransStoreTypeInfos.FirstOrDefault(it => it.Type == item.StoreStyle);
                string storeStyleStr = storeStyle == null ? "未知" : storeStyle.ToString();
                var anatype = Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == item.AnalyseType);
                string anatypeStr = anatype == null ? "未知" : anatype.Name;
                t.Rows.Add(item.EventID, item.TaskID, item.MergeStyle, storeStyleStr, item.ReceiveIp, item.ReceivePort, protocolTypeStr, anatypeStr);
            }
            return t;
        }

        public bool AddTransEvent(uint taskId, uint templateId, E_TRANCE_STORE_TYPE storeType, string storeServerIP, uint storeServerPort, E_TRANS_PROTOCOL_TYPE transProtocol,E_VIDEO_ANALYZE_TYPE analyseType)
        {
            uint ret = Framework.Container.Instance.CommService.ADD_TRANS_EVENT(taskId, templateId, storeType, storeServerIP, storeServerPort, transProtocol, analyseType);
            return ret == 0;
        }

        public void DelTransEventByID(uint id)
        {
            Framework.Container.Instance.CommService.DEL_TRANS_EVENT(id);
        }

        public bool AddCameraListByVideoSupplier(uint VideoSupplierId)
        {
            var row = Framework.Container.Instance.CommService.GET_NET_STORE_LIST().Find(it=>it.Id == VideoSupplierId);
            if (row != null)
            {
                float x = 121.48f;
                float y = 31.23f;
                Random r = new Random();
                ConfigServices.DIOService server = new ConfigServices.DIOService(Framework.Container.Instance.IVXProtocol);
                server.Login(row.ProtocolType, row.IP, (ushort)row.Port, row.UserName, row.Password);
                List<CameraInfoV3_1> list = new List<CameraInfoV3_1>();
                foreach (ConfigServices.Interop.TDIO_ChannelInfo item in server.GetChannelList())
                {
                    list.Add(new CameraInfoV3_1()
                        { CameraID = item.szChannelId,
                             CameraName = item.szChannelName,
                              PosCoordX = x,
                              PosCoordY = y,
                               VideoSupplierChannelID = item.szChannelId,
                                VideoSupplierDeviceID = VideoSupplierId,
                        });

                        x+=((float)r.NextDouble()-0.5f)/5f;
                        y += ((float)r.NextDouble() - 0.5f) / 5f;
                }
                Framework.Container.Instance.CommService.ADD_CAMERA_LIST(list);
            }
            return true;
        }
    }
}