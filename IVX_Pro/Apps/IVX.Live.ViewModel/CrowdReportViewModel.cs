using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class CrowdReportViewModel
    {
        public event EventHandler ReportSearchFinished;
        SearchViewModelBase m_vm;
        TaskInfoV3_1 curTask; 
        public CrowdReportViewModel()
        {
            curTask = null; 
        }


        public void Start(UInt32 startTime, UInt32 endTime, SearchItemV3_1 item, UInt32 timeInterVel)
        {
            /*
             * 订阅 CrowdReportEvent 事件
             * 
             * start
             */
            string cameraId = item.CameraID;
            var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD);
            if(info == null)
            {
                List<CrowdStatistic> crowdInfoList = new List<CrowdStatistic> {};
                //notify UI
                if (ReportSearchFinished != null)
                {
                    ReportSearchFinished((object)crowdInfoList, null);
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
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdReportEvent>().Subscribe(OnSearchResultReturned, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
            m_vm.StartCrowdReport(startTime, endTime, cameraId, timeInterVel);
        }

        public void Stop()
        {
            /*
             * 取消 CrowdReportEvent 事件
             * 
             * stop
             */
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdReportEvent>().Unsubscribe(OnSearchResultReturned);
        }

        public bool TimeIsLong(uint startTime, uint endTime, CrowdTimeType timeType)
        {
        
            switch (timeType)
            {
                case CrowdTimeType.MONTH:
                    if ((endTime - startTime) > 12 * 31 * 24 * 3600)
                    {
                        return true;
                    }
                    break;
                case CrowdTimeType.DAY:
                    if ((endTime - startTime) > 31 * 24 * 3600)
                    {
                        return true;
                    }
                    break;
                case CrowdTimeType.HOUR:
                    if ((endTime - startTime) > 24 * 3600)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
        public void OnSearchResultReturned(List<CrowdStatistic> crowdInfoList)
        {
            string time = null;
            string[] str;
            string[] hourStr;
            string newTime = null;
            //累加时间 
            if (curTask.TaskType == TaskType.History)
            {
                uint beginTime = DataModel.Common.ConvertLinuxTime(curTask.StartTime);
                foreach (CrowdStatistic item in crowdInfoList)
                {
                    time  = item.TimeTag;
                    str = time.Split('-');
                    // newTime is DateTime
                    if (time.Length == 13)
                    {
                        newTime = str[0] + "/" + str[1] + "/" + str[2] + ":00:00";
                    }
                    else if (time.Length == 10)
                    {
                        newTime = str[0] + "/" + str[1] + "/" + str[2] + "00:00:00";
                    }
                    else if (time.Length == 7)
                    {
                        newTime = str[0] + "/" + str[1] + "01 00:00:00";
                    }
                    DateTime dTime = new DateTime();
                    DateTime.TryParse(newTime, out dTime);
                    uint uTime = DataModel.Common.ConvertLinuxTime(dTime);
                    uTime += beginTime;
                    time = DataModel.Common.ConvertLinuxTime(uTime).ToString();
                    // newTime is DateTime
                    if (item.TimeTag.Length == 13)
                    {
                        str = time.Split('/');
                        hourStr = str[2].Split(':');
                        newTime = str[0] + "-" + str[1] + "-" + hourStr[0];
                    }
                    else if (item.TimeTag.Length == 10)
                    {
                        str = time.Split('/');
                        hourStr = str[2].Split(' ');
                        newTime = str[0] + "-" + str[1] + "-" + hourStr[0];
                    }
                    else if (item.TimeTag.Length == 7)
                    {
                        str = time.Split('/');
                        newTime = str[0] + "-" + str[1];
                    }
                    item.TimeTag = newTime;
                }
            }

            //notify UI
            if (ReportSearchFinished != null)
            {
                ReportSearchFinished((object)crowdInfoList, null);
            }
        }
    }
}
