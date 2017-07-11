using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class TaskManagementViewModel
    {
        public event Action<uint, IVX.DataModel.E_VDA_TASK_STATUS, uint> UpdateTaskProgress;
        public event Action<uint, string, string, uint, UInt64> UpLoadLocalFile;

        public TaskManagementViewModel()
        {
        }

        public string GetTaskTimeLineKeyValue(DataModel.TaskInfoV3_1 item)
        {
            string type = CalcTimelineType(item.StartTime);
            return type;
        }
        public SortedDictionary<string, TaskTimeLine> GetTaskTimeLine()
        {
            SortedDictionary<string, TaskTimeLine> timeline = new SortedDictionary<string, TaskTimeLine>(new TimeLineSort());
            foreach (var item in Framework.Container.Instance.CommService.GET_TASK_LIST())
            {
                string type = CalcTimelineType(item.StartTime);
                if (!timeline.ContainsKey(type))
                {
                    timeline.Add(type, new TaskTimeLine() { TaskList = new List<DataModel.TaskInfoV3_1>(), Type = type, });
                }
                //if (timeline[type].TaskList.Count<=100)
                    timeline[type].TaskList.Add(item);

            }
            
            return timeline;
        }
        public TaskTimeLine GetTaskTimeLineByKey(string key)
        {
            TaskTimeLine timeline = new TaskTimeLine();
            timeline.Type = key;
            timeline.TaskList = new List<TaskInfoV3_1>();
            foreach (var item in Framework.Container.Instance.CommService.GET_TASK_LIST())
            {
                string type = CalcTimelineType(item.StartTime);
                if (type == key)
                {
                    timeline.TaskList.Add(item);
                }
            }

            return timeline;

        }
        private class TimeLineSort : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return -x.CompareTo(y);
            }
        }
        private string CalcTimelineType(DateTime time)
        {

            return time.ToString("yyyy/MM/dd");
            //if (time.CompareTo(DateTime.Now.AddMonths(-2))<0)
            //    return TimeLineType.Earlier;
            //else if (time.CompareTo(DateTime.Now.AddMonths(-1))<0)
            //    return TimeLineType.TwoMonthsAgo;
            //else if (time.CompareTo(DateTime.Now.AddDays(-14))< 0)
            //    return TimeLineType.LastMonth;
            //else if (time.CompareTo(DateTime.Now.AddDays(-7))< 0)
            //    return TimeLineType.TwoWeeksAgo;
            //else if (time.CompareTo(DateTime.Now.AddDays(-2))< 0)
            //    return TimeLineType.LastWeek;
            //else if ((time.Year == DateTime.Today.AddDays(-1).Year) && (time.Year == DateTime.Today.AddDays(-1).Year) && (time.Year == DateTime.Today.AddDays(-1).Year))
            //    return TimeLineType.Yesterday;
            //else if ((time.Year == DateTime.Today.Year) && (time.Year == DateTime.Today.Year) && (time.Year == DateTime.Today.Year))
            //    return TimeLineType.Today;
            //int indexw = (int)DateTime.Today.DayOfWeek;
            //if (indexw > 1)
            //    if (time.Date.CompareTo(DateTime.Today.AddDays(-indexw)) > 0 && time.Date.CompareTo(DateTime.Today.AddDays(-2)) <= 0)
            //        return TimeLineType.ThisWeek;
        }
        public void GetTaskProgress()
        {

            List<uint> idlist = Framework.Container.Instance.CommService.GET_TASK_LIST().Select(item=>item.TaskId).ToList();
            List<DataModel.TaskProgressInfoV3_1> progresslist =
                Framework.Container.Instance.CommService.GET_TASK_PROGRESS(idlist);
            foreach (var item in progresslist)
            {
                if (UpdateTaskProgress != null)
                    UpdateTaskProgress(item.TaskId, item.Status, item.Progress);
            }
            foreach (IVX.DataModel.UploadTaskInfoV3_1 item in Framework.Container.Instance.CommService.GET_DOWN_LOAD_LIST())
            {
                if (UpLoadLocalFile != null)
                    UpLoadLocalFile(item.TaskId, item.OriFilePath, item.MssServerIp, item.MssServerPort, item.SendSize);
            }
        }


        public void DeleteTask(uint taskid)
        {
            Framework.Container.Instance.CommService.DEL_TASK(new List<uint>() { taskid});
        }


    }
    public class TaskTimeLine
    {
        public string Type { get; set; }
        public List<IVX.DataModel.TaskInfoV3_1> TaskList{get;set;}
        public override string ToString()
        {
            string msg = Type;
            if (DateTime.Today.ToString("yyyy/MM/dd").CompareTo(msg) == 0)
                msg = "今天（" + msg + "）";
            if (DateTime.Today.AddDays(-1).ToString("yyyy/MM/dd").CompareTo(msg) == 0)
                msg = "昨天（" + msg + "）";
            //switch (Type)
            //{
            //    case TimeLineType.Today:
            //        msg = "今天（" + DateTime.Now.ToString("yyyy/MM/dd") + "）";
            //        break;
            //    case TimeLineType.Yesterday:
            //        msg = "昨天（" + DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + "）";
            //        break;
            //    case TimeLineType.ThisWeek:
            //        msg = "本周";
            //        break;
            //    case TimeLineType.LastWeek:
            //        msg = "上周";
            //        break;
            //    case TimeLineType.TwoWeeksAgo:
            //        msg = "两周前";
            //        break;
            //    case TimeLineType.LastMonth:
            //        msg = "上个月";
            //        break;
            //    case TimeLineType.TwoMonthsAgo:
            //        msg = "两个月前";
            //        break;
            //    case TimeLineType.Earlier:
            //        msg = "更早";
            //        break;
            //    default:
            //        break;
            //}
            return msg + "（" + TaskList.Count + "任务）"; ;
        }
    }
    public enum TimeLineType
	{
	    Today,
        Yesterday,
        ThisWeek,
        LastWeek,
        TwoWeeksAgo,
        LastMonth,
        TwoMonthsAgo,
        Earlier,
	}
}
