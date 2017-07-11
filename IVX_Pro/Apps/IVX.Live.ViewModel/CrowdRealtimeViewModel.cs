using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class CrowdRealtimeViewModel
    {
        public event EventHandler RealSearchFinished;
        SearchViewModelBase m_vm;
        TaskInfoV3_1 curTask; 
        public CrowdRealtimeViewModel()
        {
            m_vm = null;
        }

        public void Start(SearchItemV3_1 cameraItem)
        {
            /*
             * 订阅 CrowdRealTimeEvent 事件
             * start
             */
            string cameraId = "";
            if (cameraItem != null)
            {
                cameraId = cameraItem.CameraID;
            }
            if (m_vm == null)
            {
                var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD);
                if(info == null)
                {
                    // notify UI
                    if (RealSearchFinished != null)
                    {
                        CrowdInfo crowdInfo = new CrowdInfo();
                        crowdInfo.CameraID = "SDKError";
                        crowdInfo.DirectionImageURL = "大客流实时-查询错误:无结果数据";
                        RealSearchFinished((object)crowdInfo, null);
                    }
                    return;
                }
                string ip = info.StoreIP;
                uint port = info.StortPort;
                m_vm = new SearchViewModelBase(ip, port);
                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdRealTimeEvent>().Subscribe(OnSearchResultReturned, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
            }
            curTask = Framework.Container.Instance.CommService.GET_TASK(cameraItem.TaskId);
            m_vm.StartCrowdRealtime(cameraId);
        }

        public void Stop()
        {
            /*
             * 取消 CrowdRealTimeEvent 事件
             * stop
             */

            if (m_vm != null)
            {
                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdRealTimeEvent>().Unsubscribe(OnSearchResultReturned);
                m_vm.StopCrowdRealtime();
                m_vm = null;
            }
        }

        public void SetSearchTime(uint time)
        {
            if (m_vm != null)
            {
                m_vm.RealThreadTime = time;
            }
        }

        public void OnSearchResultReturned(CrowdInfo crowdInfo)
        {
            if (crowdInfo != null)
            {
                if (curTask.TaskType == TaskType.History)
                {
                    uint beginTime = DataModel.Common.ConvertLinuxTime(curTask.StartTime);
                    crowdInfo.TimeSec += beginTime;
                }
            }
            // notify UI
            if (RealSearchFinished != null)
            {
                RealSearchFinished((object)crowdInfo, null);
            }
        }
    }
}
