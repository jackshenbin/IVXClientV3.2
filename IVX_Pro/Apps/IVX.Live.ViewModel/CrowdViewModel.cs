using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class CrowdViewModel
    {
        public event EventHandler SearchFinished;
        SearchViewModelBase m_vm;
        TaskInfoV3_1 curTask; 
        public CrowdViewModel()
        {
            // Get ip port
            curTask = null;
        }


        public void Start(UInt32 startTime, UInt32 endTime, SearchItemV3_1 item)
        {
          /*
           * 订阅 CrowdEvent 事件
           * start
           */
            string cameraId = item.CameraID;
            var info  = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD);
            if(info == null)
            {
                List<CrowdInfo> crowdInfoList = new List<CrowdInfo> {};
                //notify UI
                if (SearchFinished != null)
                {
                    SearchFinished((object)crowdInfoList, null);
                }
                return;
            }
            string ip = info.StoreIP;
            uint port = info.StortPort;
            m_vm = new SearchViewModelBase(ip, port);
            curTask = Framework.Container.Instance.CommService.GET_TASK(item.TaskId);
            if (curTask.TaskType == TaskType.History)
            {
                 uint beginTime = DataModel.Common.ConvertLinuxTime(curTask.StartTime);
                 if (startTime <= beginTime)
                 {
                     startTime = 0;
                 }
                 else
                 {
                     startTime -= beginTime;
                 }

                 if (endTime <= beginTime)
                 {
                     endTime = 0;
                 }
                 else
                 {
                     endTime -= beginTime;
                 }
            }
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdEvent>().Subscribe(OnSearchResultReturned, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
            m_vm.StartCrowd(startTime, endTime, cameraId);
        }

        public void Stop()
        {
            /*
             * 取消 CrowdEvent 事件
             * stop
             */
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdEvent>().Unsubscribe(OnSearchResultReturned);
         
        }

        public void OnSearchResultReturned(List<CrowdInfo> crowdInfoList)
        {
            //累加时间 
            if (curTask.TaskType == TaskType.History)
            {
                uint beginTime = DataModel.Common.ConvertLinuxTime(curTask.StartTime);
                foreach (CrowdInfo item in crowdInfoList)
                {
                    item.TimeSec += beginTime;
                }
            }
            //notify UI
            if (SearchFinished != null)
            {
                SearchFinished((object)crowdInfoList, null);
            }
        }
    }
}
