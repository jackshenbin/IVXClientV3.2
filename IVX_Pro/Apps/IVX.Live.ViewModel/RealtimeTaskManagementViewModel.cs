using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class RealtimeTaskManagementViewModel
    {
        public event Action<int, uint, IVX.DataModel.E_VDA_TASK_STATUS, uint> UpdateTaskProgress;
        public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        public event Action<DataModel.TaskInfoV3_1> TaskModified;

        public uint TotalCount { get; private set; }
        public uint TotalPage
        {
            get
            {
                if (TotalCount > 0)
                {
                    return (TotalCount % CountPerPage == 0) ? (TotalCount / CountPerPage)  :( TotalCount / CountPerPage)+1;
                }
                else
                    return 0;
            }
        }
        public uint CurrentPageIndex { get; set; }
        public uint CountPerPage { get; set; }

        private List<uint> m_lastTaskidList = new List<uint>();
        public RealtimeTaskManagementViewModel()
        {
            CurrentPageIndex = 0;
            CountPerPage = 10;
            Framework.Container.Instance.CommService.TaskAdded += CommService_TaskAdded;
            Framework.Container.Instance.CommService.TaskDeleted += CommService_TaskDeleted;
            Framework.Container.Instance.CommService.TaskMonified += CommService_TaskMonified;
        }
        public void Clear()
        {
            Framework.Container.Instance.CommService.TaskAdded -= CommService_TaskAdded;
            Framework.Container.Instance.CommService.TaskDeleted -= CommService_TaskDeleted;
            Framework.Container.Instance.CommService.TaskMonified -= CommService_TaskMonified;

        }
        void CommService_TaskMonified(TaskInfoV3_1 obj)
        {
            System.Diagnostics.Trace.WriteLine("CommService_TaskMonified " + obj.ToString());
            if (obj.StatusList.Count > 0)
            {
                E_VDA_TASK_STATUS s = obj.StatusList[0].Status;
                uint p = obj.StatusList[0].Progress;
                int index = m_lastTaskidList.IndexOf(obj.TaskId);
                if (index >= 0)
                {
                    if (s != TaskShowStatus)
                    {
                        if (TaskModified != null)
                        {
                            TaskModified(obj);
                        }
                    }
                    else
                    {
                        if (UpdateTaskProgress != null)
                            UpdateTaskProgress(index, obj.TaskId, s, p);
                    }
                }
                if (s == TaskShowStatus && TaskModified != null)
                {
                    TaskModified(obj);
                }
            }
        }

        void CommService_TaskDeleted(TaskInfoV3_1 obj)
        {
            System.Diagnostics.Trace.WriteLine("CommService_TaskDeleted " + obj.ToString());

            if (m_lastTaskidList.Contains(obj.TaskId) && TaskDeleted != null)
                TaskDeleted(obj);

        }

        void CommService_TaskAdded(TaskInfoV3_1 obj)
        {
            System.Diagnostics.Trace.WriteLine("CommService_TaskAdded " + obj.ToString());
            if (TaskAdded != null)
                TaskAdded(obj);
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
            uint totalcount = 0;
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {

                CurrentPageIndex--;
                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                }
                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            }
            TotalCount = totalcount;
            if (timeline != null)
                m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();

            return timeline;

        }
        public List<TaskInfoV3_1> LastPage()
        {
            if (CurrentPageIndex == 0 || CountPerPage == 0)
                return new List<TaskInfoV3_1>();

            CurrentPageIndex = TotalPage;
            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            uint totalcount = 0;
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {

                CurrentPageIndex--;
                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                }
                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            }
            TotalCount = totalcount;
            if (timeline != null)
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
            }
            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            uint totalcount = 0;
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {
                CurrentPageIndex--;
                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                }

                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            }
            TotalCount = totalcount;
            if (timeline != null)
                m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();

            return timeline;

        }
        public List<TaskInfoV3_1> FirstPage()
        {
            if (CurrentPageIndex == 0 || CountPerPage == 0)
                return new List<TaskInfoV3_1>();

            CurrentPageIndex = 1;

            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            uint totalcount = 0;
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {
                CurrentPageIndex--;
                if (CurrentPageIndex < 1)
                {
                    CurrentPageIndex = 1;
                }

                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            }
            TotalCount = totalcount;
            if (timeline != null)
                m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();

            return timeline;

        }

        public List<TaskInfoV3_1> FrashPage()
        {
            if (CurrentPageIndex == 0 || CountPerPage == 0)
                return new List<TaskInfoV3_1>();

            List<TaskInfoV3_1> timeline = new List<TaskInfoV3_1>();
            //0不排序，1时间升序，2时间降序
            uint totalcount = 0;
            timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);

            while ((timeline == null || timeline.Count == 0) && CurrentPageIndex != 1)
            {

                CurrentPageIndex--;
                if (CurrentPageIndex <= 1)
                    CurrentPageIndex = 1;
                timeline = Framework.Container.Instance.CommService.TASK_PAGING(CurrentPageIndex, CountPerPage, E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC, GetTaskType(), GetAnalyseType(), GetTaskStatus(), out totalcount);
            }
            TotalCount = totalcount;
            if (timeline != null)
                m_lastTaskidList = timeline.Select(it => it.TaskId).ToList();
            return timeline;

        }
        public void FrashProgress()
        {
            return;
            //List<DataModel.TaskProgressInfoV3_1> progresslist =
            //    Framework.Container.Instance.CommService.GET_TASK_PROGRESS(m_lastTaskidList);
            //for (int i = 0; i < CountPerPage; i++)
            //{
            //    if (progresslist.Count <= i)
            //    {
            //        if (UpdateTaskProgress != null)
            //            UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
            //    }
            //    else
            //    {
            //        var item = progresslist[i];
            //        if (UpdateTaskProgress != null)
            //            UpdateTaskProgress(i, item.TaskId, item.Status, item.Progress);
            //    }
            //}

        }
        public void PauseOrResumeTask(uint taskid)
        {
            var task = Framework.Container.Instance.CommService.GET_TASK(taskid);
            if (task.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND)
            {
                Framework.Container.Instance.CommService.RESUME_REALTIME_TASK(taskid);
            }
            else if (task.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING)
            {
                Framework.Container.Instance.CommService.PAUSE_REALTIME_TASK(taskid);
            }
        }

        public void DeleteTask(uint taskid)
        {
            Framework.Container.Instance.CommService.DEL_TASK(new List<uint>() { taskid});
        }

        public TaskInfoV3_1 GetTaskInfo(uint taskid)
        {
            return Framework.Container.Instance.CommService.GET_TASK(taskid);
        }

        public CameraInfoV3_1 GetCameraInfo(string cameraId)
        {
            return Framework.Container.Instance.CommService.GET_CAMERA_LIST().SingleOrDefault(item => item.CameraID == cameraId);
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
            list.Add((uint)TaskType.Realtime);

            return list;
        }

        private List<uint> GetAnalyseType()
        {
            List<uint> list = new List<uint>();

            return list;
        }
    }

}
