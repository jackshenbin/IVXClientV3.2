using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.MainForm.ViewModel
{
    class SingleTaskViewModel
    {
        private int m_playHandle = 0;
        IVX.Live.ConfigServices.DIOService server;
        private DataModel.TaskInfoV3_1 m_task;
        private bool isPaused { get; set; }
        public DataModel.TaskInfoV3_1 CurrentTask
        {
            get { return m_task; }
            set { m_task = value; }
        }
        public int CurrentProgress { get; set; }

        public SingleTaskViewModel()
        {
        }

        public bool Submit()
        {
            if (!Validate())
                return false;

            Framework.Container.Instance.CommService.MDF_TASK(m_task.TaskId, m_task.Priority, m_task.StartTime, m_task.EndTime);
            return true;
        }

        private bool Validate()
        {
            return true;
        }

        private void StartPlay()
        {
            switch (m_task.TaskType)
            {
                case TaskType.None:
                    break;
                case TaskType.History:
                    //var taskmss =  Framework.Container.Instance.CommService.QUERY_TASK_MSS(new List<uint>(){ m_task.TaskId});
                    //if (taskmss != null && taskmss.Count >= 1)
                    //{
                    //    m_playHandle = m_player.ocx_VodSdk_PlayBackVideo(taskmss[0].MssHostIp, (ushort)(taskmss[0].MssHostPort), taskmss[0].VideoPath, (uint)(m_hWnd.ToInt32()), 0);
                    //    m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_START, 0);
                    //}
                    break;
                case TaskType.Realtime:
                case TaskType.Project:
                    //server = new ConfigServices.DIOService(Framework.Container.Instance.IVXProtocol);
                    //server.StartRealPlay(m_hWnd, m_task.ChannelID, "");
                    //m_playHandle = m_hWnd.ToInt32();
                    break;
                default:
                    break;
            }
        }

        private void ResumePlay()
        {
            switch (m_task.TaskType)
            {
                case TaskType.None:
                    break;
                case TaskType.History:
                    //m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_RESUME, 0);
                    break;
                case TaskType.Realtime:
                case TaskType.Project:
                    break;
                default:
                    break;
            }
        }
        private void PausePlay()
        {
            switch (m_task.TaskType)
            {
                case TaskType.None:
                    break;
                case TaskType.History:
                    //m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_PAUSE, 0);
                    break;
                case TaskType.Realtime:
                case TaskType.Project:
                    break;
                default:
                    break;
            }
        }

        internal bool StopPlay()
        {
            switch (m_task.TaskType)
            {
                case TaskType.None:
                    break;
                case TaskType.History:
                    //m_player.ocx_VodSdk_PlayBackControl(m_playHandle, (int)E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_STOP, 0);
                    //m_player.ocx_VodSdk_StopPlayBack(m_playHandle);
                    break;
                case TaskType.Realtime:
                case TaskType.Project:
                    server.StopRealPlay((IntPtr)m_playHandle);
                    break;
                default:
                    break;
            }
            return true;
        }

        internal bool PlayOrPause()
        {
            if (m_playHandle == 0)
                StartPlay();
            else
            {
                if (isPaused)
                { ResumePlay(); }
                else
                { PausePlay(); }
            }
            return true;
        }

        internal System.Drawing.Image SnapImage()
        {
            System.Drawing.Image img = null;
            switch (m_task.TaskType)
            {
                case TaskType.None:
                    break;
                case TaskType.History:
                    
                    //string base64img  = m_player.ocx_VodSdk_GrabPictureData(m_playHandle,1);
                    //byte[] btimg =  Convert.FromBase64String(base64img);
                    //System.IO.MemoryStream ms = new System.IO.MemoryStream(btimg);
                    //img = System.Drawing.Bitmap.FromStream(ms);
                    break;
                case TaskType.Realtime:
                case TaskType.Project:
                    img = server.SnapPicture((IntPtr)m_playHandle);
                    break;
                default:
                    break;
            }
            return img;
        }
    }
}
