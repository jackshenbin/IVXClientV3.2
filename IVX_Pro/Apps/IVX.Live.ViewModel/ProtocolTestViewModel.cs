using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class ProtocolTestViewModel
    {
        public event Action<uint, string, string, uint, UInt64> UpLoadLocalFile;
        public event Action<int, uint, IVX.DataModel.E_VDA_TASK_STATUS, uint> UpdateTaskProgress;

        public event EventHandler ReachHead;
        public event EventHandler ReachTail;
        public event Action<string> FireMessage;

        public uint CurrentPageIndex { get; set; }
        public uint CountPerPage { get; set; }

        private List<uint> m_lastTaskidList = new List<uint>();
        public ProtocolTestViewModel()
        {
            CurrentPageIndex = 0;
            CountPerPage = 10;
            Framework.Container.Instance.CommService.FireMessage += CommService_FireMessage;
        }

        void CommService_FireMessage(string obj)
        {
            if (FireMessage != null)
                FireMessage(obj);
        }
        public E_VDA_TASK_STATUS TaskShowStatus { get; set; }

        //public List<TaskInfoV3_1> GetTaskList(uint countperpage)
        //{
        //    if (countperpage == 0)
        //        return new List<TaskInfoV3_1>(); 

        //    CountPerPage = countperpage;
        //    CurrentPageIndex = 1;
        //    List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
        //    //0不排序，1时间升序，2时间降序
        //    timeline = Framework.Container.Instance.CommService.TASK_PAGING(1, countperpage, 2, new List<uint>(), new List<uint>(), new List<uint>());
        //    m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();

        //    return timeline;
        //}
        public List<TaskInfoV3_1> NextPage()
        {
            if (CurrentPageIndex == 0 || CountPerPage == 0)
                return new List<TaskInfoV3_1>(); 

            CurrentPageIndex += 1;
            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, 2, GetTaskType(), GetAnalyseType(), GetTaskStatus());
            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex!=1)
            {
                if (ReachTail != null)
                    ReachTail(null, null);

                CurrentPageIndex--;
                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                    if (ReachHead != null)
                        ReachHead(null, null);
                }
                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, 2, GetTaskType(), GetAnalyseType(), GetTaskStatus());
            }
            m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();

            return timeline;

        }

        public List<TaskInfoV3_1> PrivPage()
        {
            if (CurrentPageIndex == 0 || CountPerPage == 0)
                return new List<TaskInfoV3_1>(); 

            CurrentPageIndex -= 1;
            if (CurrentPageIndex < 1)
            {
                CurrentPageIndex = 1;
                if (ReachHead != null)
                    ReachHead(null, null);
            }
            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, 2, GetTaskType(), GetAnalyseType(), GetTaskStatus());
            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {
                CurrentPageIndex--;
                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                    if (ReachHead != null)
                        ReachHead(null, null);
                }

                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, 2, GetTaskType(), GetAnalyseType(), GetTaskStatus());
            }
            m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();

            return timeline;

        }

        public List<TaskInfoV3_1> TASK_PAGING()
        {
            if (CurrentPageIndex == 0 || CountPerPage == 0)
                return new List<TaskInfoV3_1>(); 

            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, 2, GetTaskType(), GetAnalyseType(), GetTaskStatus());

            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {
                if (ReachTail != null)
                    ReachTail(null, null);

                CurrentPageIndex--;
                if (CurrentPageIndex <= 1)
                    CurrentPageIndex = 1;
                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, 2, GetTaskType(), GetAnalyseType(), GetTaskStatus());
            }
            m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();
            return timeline;

        }
        public void GET_DOWN_LOAD_LIST()
        {
            Framework.Container.Instance.CommService.GET_DOWN_LOAD_LIST();
        }

        public void GET_TASK_PROGRESS(List<TaskInfoV3_1> list)
        {
            List<uint> m_lastTaskidList = list.Select(it => it.TaskId).ToList();

            List<DataModel.TaskProgressInfoV3_1> progresslist =
                Framework.Container.Instance.CommService.GET_TASK_PROGRESS(m_lastTaskidList);
        }
        

        public void DeleteTask(uint taskid)
        {
            Framework.Container.Instance.CommService.DEL_TASK(new List<uint>() { taskid});
        }

        public TaskInfoV3_1 GetTaskInfo(uint taskid)
        {
            return Framework.Container.Instance.CommService.GET_TASK(taskid);
        }

        private List<uint> GetTaskStatus()
        {
            List<uint> list = new List<uint>();
            //if ((TaskShowStatus & TaskShowStatus.Import) > 0)
            //{
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_WAITING);
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING);
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_WAIT);
            //}
            //if ((TaskShowStatus & TaskShowStatus.Finish) > 0)
            //{
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH);
            //}
            //if ((TaskShowStatus & TaskShowStatus.Analyse) > 0)
            //{
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING);
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND);
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT);
            //}
            //if ((TaskShowStatus & TaskShowStatus.Failed) > 0)
            //{
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED);
            //    list.Add((uint)E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED);
            //}
            if (TaskShowStatus != E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE)
                list.Add((uint)TaskShowStatus);
            return list;
        }
        private List<uint> GetTaskType()
        {
            List<uint> list = new List<uint>(); 
            list.Add((uint)TaskType.History);

            return list;
        }

        private List<uint> GetAnalyseType()
        {
            List<uint> list = new List<uint>();

            return list;
        }
    }

}
