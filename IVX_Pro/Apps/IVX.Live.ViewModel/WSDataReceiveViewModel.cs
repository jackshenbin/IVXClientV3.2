using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.ViewModel
{
    public class WSDataReceiveViewModel
    {
        public static event Action<TrafficeEventInfoV3_1> TrafficEventReceived;
        public static event Action<TrafficePlateInfo> TrafficPlateReceived;
        public static event Action<BehaviorInfo> BehaviorEventReceived;
        public static event Action<FaceAlarmInfoV3_1> FaceAlarmReceived;
        
        private static uint m_serverPort = 0;

        private static WSDataReceiveServices.WSDataReceiveServices m_dataReceiveService = null;

        //public static WSDataReceiveServices.WSDataReceiveServices DataReceiveService
        //{
        //    get
        //    {
        //        if (m_dataReceiveService == null)
        //        {
        //            m_dataReceiveService = new WSDataReceiveServices.WSDataReceiveServices();
        //            m_dataReceiveService.OnFaceAlarmReceived += m_dataReceiveService_OnFaceAlarmReceived;
        //            m_dataReceiveService.StartService(m_serverPort);
        //        }

        //        return m_dataReceiveService;
        //    }
        //}

        public WSDataReceiveViewModel(uint serverPort)
        {
            m_serverPort = serverPort;

            if (m_dataReceiveService == null)
            {
                m_dataReceiveService = new WSDataReceiveServices.WSDataReceiveServices();
                m_dataReceiveService.OnFaceAlarmReceived += m_dataReceiveService_OnFaceAlarmReceived;
                m_dataReceiveService.StartService(m_serverPort);
            }

        }

        static void  m_dataReceiveService_OnFaceAlarmReceived(List<FaceAlarmInfoV3_1> obj)
        {
            if (obj == null || obj.Count<=0)
                return;

            if (FaceAlarmReceived != null)
            {
                obj.ForEach(item=> FaceAlarmReceived(item));
            }
        }



        public void Close()
        {
            if (m_dataReceiveService != null)
            {
                m_dataReceiveService.OnFaceAlarmReceived-=m_dataReceiveService_OnFaceAlarmReceived;
                m_dataReceiveService.Clearup();
                m_dataReceiveService = null;
            }
            m_serverPort = 0;
        }



    }
}
