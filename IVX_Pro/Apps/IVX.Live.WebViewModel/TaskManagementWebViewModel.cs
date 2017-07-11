using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.WebViewModel
{
    public class TaskManagementWebViewModel
    {
        public event Action<uint, string, string, uint, UInt64> UpLoadLocalFile;

        public uint TotalCount { get; private set; }

        public TaskManagementWebViewModel()
        {
            Framework.Container.Instance.CommService.UpLoadLocalFile += CommService_UpLoadLocalFile;
        }

        public void Clear()
        {
            Framework.Container.Instance.CommService.UpLoadLocalFile -= CommService_UpLoadLocalFile;
        }
        void CommService_UpLoadLocalFile(UploadTaskInfoV3_1 item)
        {
                if (UpLoadLocalFile != null)
                    UpLoadLocalFile(item.TaskId, item.OriFilePath, item.MssServerIp, item.MssServerPort, item.SendSize);
        }


        public List<TaskInfoV3_1> GetTaskPage(uint userhandel, uint page, uint perpagecount)
        {
            uint totalCount = 0;
            var list = Framework.Container.Instance.CommService.TASK_PAGING(userhandel, page, perpagecount, out totalCount);
            var progresslist = Framework.Container.Instance.CommService.GET_TASK_PROGRESS_BASE(userhandel,
                list.Where(it =>
                (it.TaskType == TaskType.History
                && it.StatusList.Exists(xx => xx.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED
                && xx.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH
                && xx.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)))
                .Select(it => it.TaskId).ToList());

            for (int i = 0; i < list.Count; i++)
            {
                var task = progresslist.Find(it => it.TaskId == list[i].TaskId);
                if (task != null)
                {
                    foreach (var item in task.StatusList)
                    {
                        var s = list[i].StatusList.Find(xx => xx.AlgthmType == item.AlgthmType);
                        if (s != null)
                        {
                            s.Progress = item.Progress;
                            s.Status = item.Status;
                        }
                        else
                        {
                            list[i].StatusList.Add(new StatusInfoV3_1()
                            {
                                AlgthmType = item.AlgthmType,
                                AnalyseParam = "",
                                Progress = item.Progress,
                                Status = item.Status,
                            });
                        }
                    }
                }
            }

            TotalCount = totalCount;
            return list;
        }


        public void DeleteTask(uint userhandel,uint taskid)
        {
            Framework.Container.Instance.CommService.DEL_TASK(userhandel,new List<uint>() { taskid});
        }
        public void DeleteTaskAnalyseType(uint userhandel, uint taskid, E_VIDEO_ANALYZE_TYPE analysetype)
        {
            Framework.Container.Instance.CommService.DEL_TASK_ANALYSETYPE(userhandel,taskid,analysetype);
        }

        public TaskInfoV3_1 GetTaskInfo(uint userhandel, uint taskid)
        {
            var info = Framework.Container.Instance.CommService.GET_TASK(userhandel,taskid);
            var progresslist = Framework.Container.Instance.CommService.GET_TASK_PROGRESS_BASE(userhandel,
    new List<uint>() { info.TaskId});

                var task = progresslist.Find(it => it.TaskId == info.TaskId);
                if (task != null)
                {
                    foreach (var item in task.StatusList)
                    {
                        var s = info.StatusList.Find(xx => xx.AlgthmType == item.AlgthmType);
                        if (s != null)
                        {
                            s.Progress = item.Progress;
                            s.Status = item.Status;
                        }
                        else
                        {
                            info.StatusList.Add(new StatusInfoV3_1()
                            {
                                AlgthmType = item.AlgthmType,
                                AnalyseParam = "",
                                Progress = item.Progress,
                                Status = item.Status,
                            });
                        }
                    }
            }
                return info;
        }
        public TaskMSSInfoV3_1 GetPlayMssTaskInfo(uint userhandel, uint taskid)
        {
            List<TaskMSSInfoV3_1> mssinfo = Framework.Container.Instance.CommService.QUERY_TASK_MSS(userhandel,new List<uint>() { taskid });
            if (mssinfo != null && mssinfo.Count > 0)
                return mssinfo[0];
            else

                return null;
        }
        public TaskBriefMSSInfoV3_1 GetBriefMssTaskInfo(uint userhandel, uint taskid)
        {
            List<TaskBriefMSSInfoV3_1> mssinfo = Framework.Container.Instance.CommService.QUERY_BRIEF_TASK(userhandel,new List<uint>() { taskid });
            if (mssinfo != null && mssinfo.Count > 0)
                return mssinfo[0];
            else

                return null;
        }

        public void ReImport(uint userhandel, TaskInfoV3_1 task)
        {
            Framework.Container.Instance.CommService.ADD_TASK(userhandel,new List<TaskInfoV3_1>() { task});
            DeleteTask(userhandel,task.TaskId);
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
