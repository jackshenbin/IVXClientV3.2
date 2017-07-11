using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.Reflection;
using System.IO;

namespace IVX.Live.ViewModel
{
    public class SingleTaskViewModel
    {
        private DataModel.TaskInfoV3_1 m_task;

        private bool isPaused { get; set; }
        public DataModel.TaskInfoV3_1 CurrentTask
        {
            get { return m_task; }
            set { m_task = value; }
        }

        public SingleTaskViewModel()
        {
        }

        public bool Submit()
        {
            if (!Validate())
                return false;

            Framework.Container.Instance.CommService.MDF_TASK(m_task.TaskId, m_task.Priority, m_task.StartTime, m_task.EndTime,m_task.TaskName);
            return true;
        }


        public bool ReAnalyse(E_VIDEO_ANALYZE_TYPE type, string analyseparam,uint splitTime=0)
        { 
            if (!Validate())
                return false;

            Framework.Container.Instance.CommService.TASK_REANALYSE(m_task.TaskId, type, analyseparam, splitTime);

            return true;
        }
        public bool DeleteAnalyse(E_VIDEO_ANALYZE_TYPE type)
        { 
            if (!Validate())
                return false;

            Framework.Container.Instance.CommService.DEL_TASK_ANALYSETYPE(m_task.TaskId, type);

            return true;
        }

        public bool AddAnalyse(E_VIDEO_ANALYZE_TYPE type)
        {
            if (!Validate())
                return false;

            Framework.Container.Instance.CommService.ADD_TASK_ANALYSETYPE(m_task.TaskId, type, GetDefaultAnalyseParam(type));
            return true;
        }
        public void PauseTask()
        {
            Framework.Container.Instance.CommService.PAUSE_REALTIME_TASK(m_task.TaskId);
        }

        public void ResumeTask()
        {
            Framework.Container.Instance.CommService.RESUME_REALTIME_TASK(m_task.TaskId);
        }

        public int CalcProgress(IVX.DataModel.E_VDA_TASK_STATUS stat, int progress)
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
                    totalprogress = 200 + (int)(progress / 5);
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED:
                    totalprogress = 0;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT:
                    totalprogress = 400;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING:
                    totalprogress = 500 + (int)(progress*2 / 5);
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH:
                    totalprogress = 1000;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED:
                    totalprogress = 500;
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

        private bool Validate()
        {
            return true;
        }
        private string GetDefaultAnalyseParam(E_VIDEO_ANALYZE_TYPE type)
        {
            string path = Framework.Container.ExecutingPath;
            if (string.IsNullOrEmpty(path))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                path = Directory.GetParent(asm.Location).FullName;
            }

            string configFile = Path.Combine(path, "AnalyseParam\\" + type.ToString() + ".xml");
            string param = "";
            if (File.Exists(configFile))
            {
                param = File.ReadAllText(configFile);
            }

            return param;
        }

        //private void StartPlay()
        //{
        //    switch (m_task.TaskType)
        //    {
        //        case TaskType.None:
        //            break;
        //        case TaskType.History:
        //            //var taskmss =  Framework.Container.Instance.CommService.QUERY_TASK_MSS(new List<uint>(){ m_task.TaskId});
        //            //if (taskmss != null && taskmss.Count >= 1)
        //            //{
        //            //    m_playHandle = m_player.ocx_VodSdk_PlayBackVideo(taskmss[0].MssHostIp, (ushort)(taskmss[0].MssHostPort), taskmss[0].VideoPath, (uint)(m_hWnd.ToInt32()), 0);
        //            //    m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_START, 0);
        //            //}
        //            break;
        //        case TaskType.Realtime:
        //        case TaskType.Project:
        //            //server = new ConfigServices.DIOService(Framework.Container.Instance.IVXProtocol);
        //            //server.StartRealPlay(m_hWnd, m_task.ChannelID, "");
        //            //m_playHandle = m_hWnd.ToInt32();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private void ResumePlay()
        //{
        //    switch (m_task.TaskType)
        //    {
        //        case TaskType.None:
        //            break;
        //        case TaskType.History:
        //            //m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_RESUME, 0);
        //            break;
        //        case TaskType.Realtime:
        //        case TaskType.Project:
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //private void PausePlay()
        //{
        //    switch (m_task.TaskType)
        //    {
        //        case TaskType.None:
        //            break;
        //        case TaskType.History:
        //            //m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_PAUSE, 0);
        //            break;
        //        case TaskType.Realtime:
        //        case TaskType.Project:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //internal bool StopPlay()
        //{
        //    switch (m_task.TaskType)
        //    {
        //        case TaskType.None:
        //            break;
        //        case TaskType.History:
        //            //m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_STOP, 0);
        //            //m_player.ocx_VodSdk_StopPlayBack(m_playHandle);
        //            break;
        //        case TaskType.Realtime:
        //        case TaskType.Project:
        //            server.StopRealPlay((IntPtr)m_playHandle);
        //            break;
        //        default:
        //            break;
        //    }
        //    return true;
        //}

        //internal bool PlayOrPause()
        //{
        //    if (m_playHandle == 0)
        //        StartPlay();
        //    else
        //    {
        //        if (isPaused)
        //        { ResumePlay(); }
        //        else
        //        { PausePlay(); }
        //    }
        //    return true;
        //}

        //internal System.Drawing.Image SnapImage()
        //{
        //    System.Drawing.Image img = null;
        //    switch (m_task.TaskType)
        //    {
        //        case TaskType.None:
        //            break;
        //        case TaskType.History:
                    
        //            //string base64img  = m_player.ocx_VodSdk_GrabPictureData(m_playHandle,1);
        //            //byte[] btimg =  Convert.FromBase64String(base64img);
        //            //System.IO.MemoryStream ms = new System.IO.MemoryStream(btimg);
        //            //img = System.Drawing.Bitmap.FromStream(ms);
        //            break;
        //        case TaskType.Realtime:
        //        case TaskType.Project:
        //            img = server.SnapPicture((IntPtr)m_playHandle);
        //            break;
        //        default:
        //            break;
        //    }
        //    return img;
        //}




    }
}
