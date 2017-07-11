using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class RealtimeTaskManagementMAViewModel
    {
        public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        public event Action<DataModel.TaskInfoV3_1> TaskModified;

        public uint TotalCount { get; private set; }
        public RealtimeTaskManagementMAViewModel()
        {
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
            if (obj.TaskType == TaskType.Realtime)
            {

                System.Diagnostics.Trace.WriteLine("CommService_TaskMonified " + obj.ToString());

                if (TaskModified != null)
                {
                    TaskModified(obj);
                }
            }
        }

        void CommService_TaskDeleted(TaskInfoV3_1 obj)
        {
            if (obj.TaskType == TaskType.Realtime)
            {
                System.Diagnostics.Trace.WriteLine("CommService_TaskDeleted " + obj.ToString());
                TotalCount--;
                if (TaskDeleted != null)
                    TaskDeleted(obj);
            }
        }

        void CommService_TaskAdded(TaskInfoV3_1 obj)
        {
            if (obj.TaskType == TaskType.Realtime)
            {

                System.Diagnostics.Trace.WriteLine("CommService_TaskAdded " + obj.ToString());
                TotalCount++;
                if (TaskAdded != null)
                    TaskAdded(obj);
            }
        }

        public E_VDA_TASK_STATUS TaskShowStatus { get; set; }

        public List<TaskInfoV3_1> GetAllTask()
        {
            var list = Framework.Container.Instance.CommService.GET_TASK_LIST();
            if (list != null)
                list = list.Where(it => it.TaskType == TaskType.Realtime).ToList();
            TotalCount = list != null ? (uint)list.Count : 0;
            return list;

        }

        public void PauseOrResumeTask(uint taskid)
        {
            var task = Framework.Container.Instance.CommService.GET_TASK(taskid);
            if (task.StatusList.Count > 0)
            {
                E_VDA_TASK_STATUS stat = task.StatusList[0].Status;
                if (stat == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND)
                {
                    Framework.Container.Instance.CommService.RESUME_REALTIME_TASK(taskid);
                }
                else if (stat == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING)
                {
                    Framework.Container.Instance.CommService.PAUSE_REALTIME_TASK(taskid);
                }
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

        public string GetActionURL(E_VDA_TASK_STATUS status, E_VIDEO_ANALYZE_TYPE analysetype, TaskType tasktype)
        {
            string url = "";
            if (status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING || status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND)
            {
                switch (analysetype)
                {
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC:
                        url += "<a href=\"E_TASK_ACTION_TYPE_DYNMIC_FACE_CONTROL\">人脸布控</a> <a href=\"E_TASK_ACTION_TYPE_DYNMIC_FACE_ALARM\">人脸报警</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF:
                        url += "<a href=\"E_TASK_ACTION_TYPE_BRIEF\">摘要播放</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
                        url += "<a href=\"E_TASK_ACTION_TYPE_PEOPLE_SEARCH\">行人检索</a> <a href=\"E_TASK_ACTION_TYPE_VEHICLE_SEARCH\">车辆检索</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
                        url += "<a href=\"E_TASK_ACTION_TYPE_VEHICLE_SEARCH\">车辆检索</a> ";
                        if (tasktype == TaskType.Realtime)
                            url += "<a href=\"E_TASK_ACTION_TYPE_TRAFFIC_EVENT\">交通事件</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE:
                        url += "<a href=\"E_TASK_ACTION_TYPE_DYNMIC_VEHICLE_SEARCH\">动态车辆</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD:
                        if (tasktype == TaskType.Realtime)
                            url += "<a href=\"E_TASK_ACTION_TYPE_CROWD\">大客流</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH:
                        break;
                    default:
                        break;
                }
            }
            return url;
        }


    }

}
