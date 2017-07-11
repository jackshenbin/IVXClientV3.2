using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.ViewModel
{
    public class DataReceiveViewModel
    {
        public event Action<TrafficeEventInfoV3_1> TrafficEventReceived;
        public event Action<TrafficePlateInfo> TrafficPlateReceived;
        public event Action<BehaviorInfo> BehaviorEventReceived;

        private DataReceiveServices.DataReceiveService m_dataReceiveService = null;
        //private WSDataReceiveServices.WSDataReceiveServices m_dataReceiveService = null;
        
        private uint m_serverPort = 0;
        private string m_serverIp = ""; 
        private bool m_isInited = false;

        private Dictionary<Tuple<uint, E_VIDEO_ANALYZE_TYPE>, uint> m_transEventList = new Dictionary<Tuple<uint, E_VIDEO_ANALYZE_TYPE>, uint>();

        public TaskInfoV3_1 InitTask = null;
        public E_TRAFFIC_EVENT_TYPE TrafficFilterType = E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_None;
        public BehaviorType BehaviourFilterType = BehaviorType.None;
        public string PlateFilter = "*";
        public DataReceiveViewModel(string serverIp, uint serverPort)
        {
            if (m_dataReceiveService == null)
            {
                m_serverIp = serverIp;
				m_serverPort = serverPort;
                m_dataReceiveService = new DataReceiveServices.DataReceiveService(m_serverPort);
                //m_dataReceiveService = new WSDataReceiveServices.WSDataReceiveServices();
                //m_dataReceiveService.StartService("0.0.0.0", m_serverPort);
                m_dataReceiveService.OnTrafficEventReceived += m_dataReceiveService_OnTrafficEventReceived;
                m_dataReceiveService.OnPlateReceived += m_dataReceiveService_OnPlateReceived;
                m_dataReceiveService.OnBehaviorReceived += m_dataReceiveService_OnBehaviorReceived;
                InitEventList();
                m_isInited = true;
            }
            else
                m_isInited = true;
        }

        void m_dataReceiveService_OnBehaviorReceived(BehaviorInfo obj)
        {
            if (obj == null)
                return;

            if (BehaviorEventReceived != null && (BehaviourFilterType == BehaviorType.None || BehaviourFilterType == obj.EventType))
            {
                    BehaviorEventReceived(obj);
            }
        }

        public void Close()
        {
            if (m_dataReceiveService != null)
            {
                m_dataReceiveService.OnTrafficEventReceived -= m_dataReceiveService_OnTrafficEventReceived;
                m_dataReceiveService.OnPlateReceived -= m_dataReceiveService_OnPlateReceived;
                m_dataReceiveService.OnBehaviorReceived -= m_dataReceiveService_OnBehaviorReceived;
                m_dataReceiveService.Clearup();
                m_dataReceiveService = null;
            }
            foreach (var item in m_transEventList)
            {
                Framework.Container.Instance.CommService.DEL_TRANS_EVENT(item.Value);
            }
            m_serverIp = "";
            m_serverPort = 0;
            m_transEventList = new Dictionary<Tuple<uint, E_VIDEO_ANALYZE_TYPE>, uint>();
        }
        void m_dataReceiveService_OnPlateReceived(TrafficePlateInfo obj)
        {
            if (obj == null)
                return;

            if (TrafficPlateReceived != null)
            {
                bool need = false;
                if (PlateFilter == "*")
                { need = true; }
                else if (PlateFilter.Length > 2 && PlateFilter[0] == '*' && PlateFilter[PlateFilter.Length - 1] == '*')
                {
                    need = obj.PlateNum.Contains(PlateFilter.Trim('*'));
                }
                else
                {
                    need = obj.PlateNum == PlateFilter;
                }

                if(need)
                    TrafficPlateReceived(obj);
            }
        }

        void m_dataReceiveService_OnTrafficEventReceived(TrafficeEventInfoV3_1 obj)
        {

                if (obj == null)
                    return;

                if (TrafficEventReceived != null && (TrafficFilterType == E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_None || TrafficFilterType == obj.EventType))
                    TrafficEventReceived(obj);
        }

        private void InitEventList()
        {
            var list =Framework.Container.Instance.CommService.GET_TRANS_EVENT_LIST();
            foreach (var item in list)
            {
                if (item.ReceiveIp == m_serverIp && item.ReceivePort == m_serverPort)
                {
                    m_transEventList.Add(new Tuple<uint,E_VIDEO_ANALYZE_TYPE>(item.TaskID,item.AnalyseType), item.EventID);
                    InitTask = Framework.Container.Instance.CommService.GET_TASK(item.TaskID);
                }
            }
        }
        public void Subscribe(uint taskid,E_VIDEO_ANALYZE_TYPE type)
        {
            if (m_transEventList.ContainsKey(new Tuple<uint,E_VIDEO_ANALYZE_TYPE>(taskid,type)))
                return;

            uint eventid = Framework.Container.Instance.CommService.ADD_TRANS_EVENT(taskid, 0, E_TRANCE_STORE_TYPE.E_TRANCE_STORE_LOCAL, m_serverIp, m_serverPort, E_TRANS_PROTOCOL_TYPE.E_TRANS_PROTOCOL_TCP,type);
            //uint eventid = Framework.Container.Instance.CommService.ADD_TRANS_EVENT(taskid, 0, E_TRANCE_STORE_TYPE.E_TRANCE_STORE_LOCAL, m_serverIp, m_serverPort, E_TRANS_PROTOCOL_TYPE.E_TRANS_PROTOCOL_WEBSERVICE);
            m_transEventList.Add(new Tuple<uint,E_VIDEO_ANALYZE_TYPE>(taskid,type),eventid);
        }
        public void Unsubscribe(uint taskid, E_VIDEO_ANALYZE_TYPE type)
        {
            if (m_transEventList.ContainsKey(new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(taskid, type)))
            {
                Framework.Container.Instance.CommService.DEL_TRANS_EVENT(m_transEventList[new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(taskid, type)]);

                m_transEventList.Remove(new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(taskid, type));
            }
        }
    }
}
