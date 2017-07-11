using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class TaskManagementMAViewModel
    {
        public event Action<uint, string, string, uint, UInt64> UpLoadLocalFile;
        public event Action<int, uint, IVX.DataModel.E_VDA_TASK_STATUS, uint> UpdateTaskProgress;
        public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        public event Action<DataModel.TaskInfoV3_1> TaskModified;

        public uint TotalCount { get; private set; }

        public TaskManagementMAViewModel()
        {
            Framework.Container.Instance.CommService.TaskAdded += CommService_TaskAdded;
            Framework.Container.Instance.CommService.TaskDeleted += CommService_TaskDeleted;
            Framework.Container.Instance.CommService.TaskMonified += CommService_TaskMonified;
            Framework.Container.Instance.CommService.UpLoadLocalFile += CommService_UpLoadLocalFile;
        }

        public void Clear()
        {
            Framework.Container.Instance.CommService.TaskAdded -= CommService_TaskAdded;
            Framework.Container.Instance.CommService.TaskDeleted -= CommService_TaskDeleted;
            Framework.Container.Instance.CommService.TaskMonified -= CommService_TaskMonified;
            Framework.Container.Instance.CommService.UpLoadLocalFile -= CommService_UpLoadLocalFile;
        }
        void CommService_TaskMonified(TaskInfoV3_1 obj)
        {
            if (obj.TaskType == TaskType.History)
            {

                System.Diagnostics.Trace.WriteLine("CommService_TaskMonified " + obj.TaskId + " " + obj.ToString());
                if (TaskModified != null)
                {
                    TaskModified(obj);
                }
            }
        }
        void CommService_UpLoadLocalFile(UploadTaskInfoV3_1 item)
        {
                if (UpLoadLocalFile != null)
                    UpLoadLocalFile(item.TaskId, item.OriFilePath, item.MssServerIp, item.MssServerPort, item.SendSize);
        }

        void CommService_TaskDeleted(TaskInfoV3_1 obj)
        {
            if (obj.TaskType == TaskType.History)
            {

                System.Diagnostics.Trace.WriteLine("CommService_TaskDeleted " +obj.TaskId +" "+ obj.ToString());
                TotalCount--;
                if (TaskDeleted != null)
                    TaskDeleted(obj);
            }
        }

        void CommService_TaskAdded(TaskInfoV3_1 obj)
        {
            if (obj.TaskType == TaskType.History)
            {

                System.Diagnostics.Trace.WriteLine("CommService_TaskAdded " + obj.TaskId + " " + obj.ToString());
                TotalCount++;
                if (TaskAdded != null)
                    TaskAdded(obj);
            }
        }

        public List<TaskInfoV3_1> GetAllTask()
        {
            var list = Framework.Container.Instance.CommService.GET_TASK_LIST();
            if (list != null)
                list = list.Where(it => it.TaskType == TaskType.History).ToList();
            TotalCount = list != null ? (uint)list.Count : 0;
            return list;

        }

		public List<SearchItemV3_1> GetAllFaceEventTaskItems() {
			List<SearchItemV3_1> list = new List<SearchItemV3_1>();
			Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
				item => {
					if (item.TaskType == TaskType.Realtime) {
						if (item.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC)) {
							list.Add(item.ToSearchItem());
						}
					}
				}
				);
			return list;
		}

		public List<SearchItemV3_1> GetAllMoveObjectSearchItems() {
			List<SearchItemV3_1> list = new List<SearchItemV3_1>();
			Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
				item => {
                    if (item.TaskType == TaskType.History)
                    {
                        if (item.StatusList.Exists(xx =>xx.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH &&( xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE)))
                            list.Add(item.ToSearchItem());
                    }
                    if(item.TaskType == TaskType.Realtime)
                    {
                        if (item.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE))
                            list.Add(item.ToSearchItem());
                    }
				}
				);
			return list;
		}
        public List<SearchItemV3_1> GetAllTrafficEventTaskItems()
        {
            List<SearchItemV3_1> list = new List<SearchItemV3_1>();
            Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
                item =>
                {
                    if (item.TaskType == TaskType.Realtime)
                    {

                        if (item.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD))
                        {
                            list.Add(item.ToSearchItem());
                        }
                    }
                }
                );
            return list;
        }

        public List<SearchItemV3_1> GetAllCrowdEventTaskItems()
        {
            List<SearchItemV3_1> list = new List<SearchItemV3_1>();
            Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
                item =>
                {                   
                    if (item.TaskType == TaskType.History)
                    {
                        if (item.StatusList.Exists(xx =>(xx.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING || xx.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH) &&( xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD)))
                            list.Add(item.ToSearchItem());
                    }
                    if(item.TaskType == TaskType.Realtime)
                    {
                        if (item.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD))
                            list.Add(item.ToSearchItem());
                    }

                }
                );
            return list;
        }

        public List<SearchItemV3_1> GetAllCrowdEventRealTimeTaskItems()
        {
            List<SearchItemV3_1> list = new List<SearchItemV3_1>();
            Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
                item =>
                {
                    if (item.TaskType == TaskType.Realtime)
                    {
                        // 判断当前 任务状态
                        if (item.StatusList.Exists(xx =>(xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD)))
                        {
                            list.Add(item.ToSearchItem());

                        }
                    }
                }
                );
            return list;
        }

		public List<SearchItemV3_1> GetAllBehaviourHistoryTaskItems() {
			List<SearchItemV3_1> list = new List<SearchItemV3_1>();
			Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
				item => {
					if (item.TaskType == TaskType.Realtime)
                    {
                        // 判断当前 任务状态
                        if (item.StatusList.Exists(xx =>(xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM)))
                        {
						list.Add(item.ToSearchItem());
					    }
                    }
				}
				);
			return list;
		}

        public List<SearchItemV3_1> GetAllBehaviourEventTaskItems()
        {
            List<SearchItemV3_1> list = new List<SearchItemV3_1>();
            Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
                item =>
                {
                    if (item.TaskType == TaskType.Realtime)
                    {
                        // 判断当前 任务状态
                        if (item.StatusList.Exists(xx => (xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM)))
                        {
                            list.Add(item.ToSearchItem());
                        }
                    }
                }
                );
            return list;
        }
        public void DeleteTask(uint taskid)
        {
            Framework.Container.Instance.CommService.DEL_TASK(new List<uint>() { taskid});
        }
        public void DeleteTaskAnalyseType(uint taskid,E_VIDEO_ANALYZE_TYPE analysetype)
        {
            Framework.Container.Instance.CommService.DEL_TASK_ANALYSETYPE(taskid,analysetype);
        }

        public TaskInfoV3_1 GetTaskInfo(uint taskid)
        {
            return Framework.Container.Instance.CommService.GET_TASK(taskid);
        }

        public void ReImport(TaskInfoV3_1 task)
        {
            Framework.Container.Instance.CommService.ADD_TASK(new List<TaskInfoV3_1>() { task});
            DeleteTask(task.TaskId);
        }

        public string GetActionURL(E_VDA_TASK_STATUS status, E_VIDEO_ANALYZE_TYPE analysetype, TaskType tasktype)
        {
            string url = "";
            if (status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH)
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
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF:
                        url = "<a href=\"E_TASK_ACTION_TYPE_BRIEF\">摘要播放</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
                        url = "<a href=\"E_TASK_ACTION_TYPE_PEOPLE_SEARCH\">行人检索</a> <a href=\"E_TASK_ACTION_TYPE_VEHICLE_SEARCH\">车辆检索</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
                        url = "<a href=\"E_TASK_ACTION_TYPE_VEHICLE_SEARCH\">车辆检索</a> ";
                        if (tasktype == TaskType.Realtime)
                            url += "<a href=\"E_TASK_ACTION_TYPE_TRAFFIC_EVENT\">交通事件</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE:
                        url = "<a href=\"E_TASK_ACTION_TYPE_DYNMIC_VEHICLE_SEARCH\">动态车辆</a> ";
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD:
                        if (tasktype == TaskType.Realtime)
                            url = "<a href=\"E_TASK_ACTION_TYPE_CROWD\">大客流</a> ";
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

        public int CalcProgress(E_VDA_TASK_STATUS stat, int progress,bool iscomb = true)
        {
            int totalprogress = 0;
            switch (stat)
            {
                case E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE:
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_WAITING:
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_WAIT:
                    totalprogress = 100;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING:
                    totalprogress = iscomb?(200 + (int)(progress / 5)):progress;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED:
                    totalprogress = 0;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT:
                    totalprogress = iscomb?400:100;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING:
                    totalprogress = iscomb?(500 + (int)(progress * 2 / 5)):progress;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH:
                    totalprogress = 1000;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED:
                    totalprogress = iscomb?500:0;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND:
                    totalprogress = 0;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_BEEN_DELETE:
                    totalprogress = 0;
                    break;
                default:
                    break;
            }
            return totalprogress;
        }

    }

}
