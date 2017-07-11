using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.ViewModel
{
    public class SubscribeViewModel
    {
        Dictionary<Tuple<string, E_VIDEO_ANALYZE_TYPE>, SearchServices.SearchServices> m_searchServiceMap;

        Dictionary<Tuple<string, E_VIDEO_ANALYZE_TYPE>, SearchServices.SearchServices> SearchServiceMap
        {
            get
            {
                if (m_searchServiceMap == null)
                {
                    m_searchServiceMap = new Dictionary<Tuple<string, E_VIDEO_ANALYZE_TYPE>, SearchServices.SearchServices>();
                    var list = Framework.Container.Instance.CommService.GET_TASK_LIST();
                    if (list != null)
                        list = list.Where(it => it.TaskType == TaskType.Realtime).ToList();
                    foreach (var item in list)
                    {
                        var info = item.StatusList.FirstOrDefault(it => it.AlgthmType != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE);
                        if (info != null)
                        {
                            E_VIDEO_ANALYZE_TYPE type = info.AlgthmType;
                            var rs = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(item.CameraID, type);
                            SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
                            m_SearchService.Init(rs.StoreIP, rs.StortPort);

                            m_searchServiceMap.Add(new Tuple<string, E_VIDEO_ANALYZE_TYPE>(item.CameraID, type), m_SearchService);
                        }
                    }
                }
                return m_searchServiceMap;
            }
        }

        public string UserName { get; set; }
        public string ClientIP { get; set; }
        public uint ClientPort { get; set; }
        public DataTable FaceSubscribe
        {
            get
            {
                DataTable t = new DataTable();
                var key = t.Columns.Add("ID", typeof(int)); ;
                t.PrimaryKey = new DataColumn[] { key };
                t.Columns.Add("CameraID");
                t.Columns.Add("BlackListLibs");
                t.Columns.Add("SubscribeInfos", typeof(List<SubscribeInfo>));
                var list = Framework.Container.Instance.CommService.GET_TASK_LIST();
                if (list != null)
                    list = list.Where(it => it.TaskType == TaskType.Realtime && it.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)).ToList();
                int id = 1;
                foreach (TaskInfoV3_1 item in list)
                {
                    if (SearchServiceMap.ContainsKey(new Tuple<string, E_VIDEO_ANALYZE_TYPE>(item.CameraID, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)))
                    {
                        SearchServices.SearchServices m_SearchService =
                          SearchServiceMap[new Tuple<string, E_VIDEO_ANALYZE_TYPE>(item.CameraID, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)];
                        try
                        {
                            var sublist = m_SearchService.GET_SUBSCRIBE_DATA(UserName).Where(it => it.CameraID == item.CameraID);
                            StringBuilder sb = new StringBuilder();
                            var blhlist = sublist.Select(it => it.BlackListHandle).ToList();
                            foreach (var h in blhlist)
                            {
                                var bl = BlackListLibs.FirstOrDefault(zz => zz.Handel == h);
                                if(bl!=null)
                                    sb.Append(bl.Name+" ");
                            }

                            t.Rows.Add(id, item.CameraID, sb.ToString().Trim(), sublist.ToList());
                        }
                        catch (SDKCallException)
                        {
                            t.Rows.Add(id, item.CameraID, "", new List<SubscribeInfo>());
                        }
                        catch (Exception)
                        { }
                    }

                    id++;
                }
                //List<SubscribeInfo> s = new List<SubscribeInfo>();
                //s.Add(new SubscribeInfo(){ BlackListHandle = 1, CameraID = "cam1", ClientIP ="127.0.0.1", ClientPort =8090, DataType =1, SubscribeHandle=1, UserName = "admin"});
                //s.Add(new SubscribeInfo(){ BlackListHandle = 2, CameraID = "cam1", ClientIP ="127.0.0.1", ClientPort =8090, DataType =1, SubscribeHandle=3, UserName = "admin"});
                //List<SubscribeInfo> s2 = new List<SubscribeInfo>();
                //s2.Add(new SubscribeInfo(){ BlackListHandle = 2, CameraID = "cam2", ClientIP ="127.0.0.1", ClientPort =8090, DataType =1, SubscribeHandle=2, UserName = "admin"});
                //t.Rows.Add(1, "cam1", "hei ming dan 1, hei ming dan 2", s);
                //t.Rows.Add(2, "cam2", "hei ming dan 2", s2);
                return t;
            }
        }

        public List<BlackListLib> BlackListLibs
        {
            get
            {
                return  Framework.Container.Instance.CommService.GET_BLACK_LIST();
            }
            set { }
        }

        public uint SubscribeFaceAlarm(string cameraId,uint blacklist)
        {
            if (SearchServiceMap.ContainsKey(new Tuple<string, E_VIDEO_ANALYZE_TYPE>(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)))
            {
                SearchServices.SearchServices m_SearchService =
                    SearchServiceMap[new Tuple<string, E_VIDEO_ANALYZE_TYPE>(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)];
                return Subscribe(m_SearchService, cameraId, WSDataReceiveServices.EnumProtocolType.SMS_MSG_FACE_ALARM_DATA_NOTIFY, blacklist);
            }
            return 0;
        }
        public void UnsubscribeFaceAlarm(string cameraId, uint subscribeHandle)
        {
            if (SearchServiceMap.ContainsKey(new Tuple<string, E_VIDEO_ANALYZE_TYPE>(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)))
            {
                SearchServices.SearchServices m_SearchService =
                    SearchServiceMap[new Tuple<string, E_VIDEO_ANALYZE_TYPE>(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)];
                Unsubscribe(m_SearchService, subscribeHandle);
            }
        }
        uint Subscribe(SearchServices.SearchServices searchService, string cameraId, WSDataReceiveServices.EnumProtocolType type, uint subscibrparam=0)
        {
            return searchService.ADD_SUBSCRIBE_DATA(UserName, ClientIP, ClientPort, cameraId, (uint)type, subscibrparam);
        }
        void Unsubscribe(SearchServices.SearchServices searchService,uint subscribeHandle)
        {
            searchService.DEL_SUBSCRIBE_DATA(subscribeHandle);
        }
    }
}
