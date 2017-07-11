using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucPlayHistory : UserControl
    {
        public event Action<string> PictureSaved4OCX;
        public event EventHandler VideoStartSave4OCX;
        public event EventHandler CloseThis;
        public event Action<uint> VideoPos;

        #region 私有变量

        private Form formfull = new Form();

        private System.Drawing.Point PlayWindowLocation = new System.Drawing.Point(0, 0);

        private System.Drawing.Size PlayWindowSize = new System.Drawing.Size(1280, 1024);


        private PlayHistoryViewModel m_viewModel;

        #endregion

        #region 属性
        [DefaultValue(false)]
        public bool ShowGotoCompare { get { return buttonGotoCompare.Visible; } set { buttonGotoCompare.Visible = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaskInfoV3_1 Task { get; set; }
        [DefaultValue(false)]
        public bool IsPlay4OCX { get; set; }

        [DefaultValue("")]
        public string OCX_MssHostIp { get; set; }
        [DefaultValue(0)]
        public uint OCX_MssHostPort { get; set; }
        [DefaultValue("")]
        public string OCX_VideoPath { get; set; }
        [DefaultValue("")]
        public string OCX_TaskName { get; set; }
        [DefaultValue(0)]
        public int OCX_StartSecond { get; set; }
        [DefaultValue(0)]
        public int OCX_EndSecond { get; set; }
        #endregion


        #region 构造
        public ucPlayHistory()
        {
            InitializeComponent();
            PlayWindowSize = Screen.PrimaryScreen.Bounds.Size;
            PlayWindowLocation = Screen.PrimaryScreen.Bounds.Location;
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<BriefObjectPlayBackEvent>().Subscribe(OnBriefObjectPlayBackEvent, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
        }
        #endregion

        #region 公共函数
        public void Clear()
        {
            ucSinglePlayWnd1.StopPlayBack();
            ucSinglePlayWnd1.UnInit();
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<BriefObjectPlayBackEvent>().Unsubscribe(OnBriefObjectPlayBackEvent);

        }

        public void StartPlay(uint taskid,DateTime starttime,DateTime endtime)
        {
            var mssinfo = m_viewModel.GetMssTaskInfo(taskid);
            if (mssinfo != null)
            {
                ucSinglePlayWnd1.MSS_IP = mssinfo.MssHostIp;
                ucSinglePlayWnd1.MSS_Port = mssinfo.MssHostPort;
                ucSinglePlayWnd1.MSS_Path = mssinfo.VideoPath;
                //ucSinglePlayWnd1.VideoName = Task.TaskName;
                Task = m_viewModel.GetTaskInfo(taskid);
                int st = Convert.ToInt32(starttime.Subtract(new DateTime()).TotalSeconds);
                int et = Convert.ToInt32(endtime.Subtract(new DateTime()).TotalSeconds);
                ucSinglePlayWnd1.StartPlayBack(mssinfo.MssHostIp, mssinfo.MssHostPort, mssinfo.VideoPath, st, et);
            }
            else
                DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
        public void SetPos(DateTime time)
        {
            uint pos = Convert.ToUInt32( 1000*time.Subtract(Task.StartTime).TotalSeconds / (Task.EndTime-Task.StartTime).TotalSeconds);
            ucSinglePlayWnd1.SetPosition(pos); 
        }
        #endregion

        #region 事件响应
        private void wnd_DragDrop(object sender, DragEventArgs e)
        {
            ucSinglePlayWnd p = sender as ucSinglePlayWnd;
            

            Type dataType = typeof(DevComponents.AdvTree.Node);

            if (e.Data.GetDataPresent(dataType))
            {
                DevComponents.AdvTree.Node node = (DevComponents.AdvTree.Node)e.Data.GetData(dataType);
                TaskInfoV3_1 task = node.Tag as TaskInfoV3_1;
                if (task != null)
                {
                    TaskMSSInfoV3_1 mssinfo = m_viewModel.GetMssTaskInfo( task.TaskId );
                    if (mssinfo != null )
                    {
                        p.VideoName = task.TaskName;
                        p.StartPlayBack(mssinfo.MssHostIp, mssinfo.MssHostPort, mssinfo.VideoPath,0,0);
                    }
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                
            }

        }

        private void labelX2_DragEnter(object sender, DragEventArgs e)
        {
            Type dataType = typeof(DevComponents.AdvTree.Node);

            if (e.Data.GetDataPresent(dataType))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            { 
                e.Effect = DragDropEffects.None;
            }

        }

        private void FormPlayHistory_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new PlayHistoryViewModel();
            //CreatePlayWnd();
            
            ucSinglePlayWnd1.Init();
            UpdataTime();
            SetButtonStatus();
            SetPlayStatusText();

            new System.Threading.Thread(() => { System.Threading.Thread.Sleep(200); DoPlay(); }).Start();

        }
        private void DoPlay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(DoPlay));
            }
            else
            {
                btnPlay_Click(this, null);
            }
        }

        private void OnBriefObjectPlayBackEvent(VodInfo info)
        {
            if (IsPlay4OCX)
            {
                ucSinglePlayWnd1.MSS_IP = OCX_MssHostIp;
                ucSinglePlayWnd1.MSS_Port = OCX_MssHostPort;
                ucSinglePlayWnd1.MSS_Path = OCX_VideoPath;
                ucSinglePlayWnd1.VideoName = OCX_TaskName;
                int st = OCX_StartSecond;
                int et = OCX_EndSecond;
                ucSinglePlayWnd1.StartPlayBack(OCX_MssHostIp, OCX_MssHostPort, OCX_VideoPath, st, et);

            }
            else
            {
                StartPlay(info.VideoTaskUnitID, info.StartTime, info.EndTime);
                //var mssinfo = m_viewModel.GetMssTaskInfo(info.VideoTaskUnitID);
                //if (mssinfo != null)
                //{
                //    ucSinglePlayWnd1.MSS_IP = mssinfo.MssHostIp;
                //    ucSinglePlayWnd1.MSS_Port = mssinfo.MssHostPort;
                //    ucSinglePlayWnd1.MSS_Path = mssinfo.VideoPath;
                //    //ucSinglePlayWnd1.VideoName = Task.TaskName;
                //    Task = m_viewModel.GetTaskInfo(info.VideoTaskUnitID);
                //    int st = Convert.ToInt32( info.StartTime.Subtract(new DateTime()).TotalSeconds);
                //    int et = Convert.ToInt32(info.EndTime.Subtract(new DateTime()).TotalSeconds);
                //    ucSinglePlayWnd1.StartPlayBack(mssinfo.MssHostIp, mssinfo.MssHostPort, mssinfo.VideoPath, st, et);
                //}
                //else
                //    DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        void ucSinglePlayWnd_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ucSinglePlayWnd wnd = sender as ucSinglePlayWnd;
            if (e.PropertyName == "VideoStatus" )
            {
                SetButtonStatus();
            }
            if (e.PropertyName == "VideoStatusString")
            {
                    SetPlayStatusText();
            }
            if (e.PropertyName == "VideoTime")
            {
                    UpdataTime();
            }

        }

        void ucSinglePlayWnd_MouseDoubleClickEx(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                FullScreen();
        }

        void ucSinglePlayWnd_MouseClickEx(object sender, MouseEventArgs e)
        {
        }


        private void buttonX4_Click(object sender, EventArgs e)
        {
            ucSinglePlayWnd1.SpeedUp();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (IsPlay4OCX)
            {
                ucSinglePlayWnd1.MSS_IP = OCX_MssHostIp;
                ucSinglePlayWnd1.MSS_Port = OCX_MssHostPort;
                ucSinglePlayWnd1.MSS_Path = OCX_VideoPath;
                ucSinglePlayWnd1.VideoName = OCX_TaskName;
                ucSinglePlayWnd1.PlayStartTime = OCX_StartSecond;
                ucSinglePlayWnd1.PlayEndTime = OCX_EndSecond;
                ucSinglePlayWnd1.PlayOrPauseOrResume();

            }
            else
            {
                if (Task != null)
                {
                    var mssinfo = m_viewModel.GetMssTaskInfo(Task.TaskId);
                    if (mssinfo != null)
                    {
                        ucSinglePlayWnd1.MSS_IP = mssinfo.MssHostIp;
                        ucSinglePlayWnd1.MSS_Port = mssinfo.MssHostPort;
                        ucSinglePlayWnd1.MSS_Path = mssinfo.VideoPath;
                        ucSinglePlayWnd1.VideoName = Task.TaskName;
                        ucSinglePlayWnd1.PlayOrPauseOrResume();
                    }
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ucSinglePlayWnd1.StopPlayBack();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            ucSinglePlayWnd1.SpeedDown();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

            string fileName = "";
            if (IsPlay4OCX)
            {
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "视频截图";
                fileName = IVX.Live.MainForm.Framework.Environment.PictureSavePath.TrimEnd('\\') + '\\'
                    + OCX_TaskName.Trim().Replace(".", "_").Replace(":", "_") + type + time + ".jpg";

            }
            string retval = ucSinglePlayWnd1.GrabPictureData(fileName);

            if (!string.IsNullOrEmpty(retval))
            {
                if (IsPlay4OCX && PictureSaved4OCX != null)
                {
                    PictureSaved4OCX(retval);
                }
            }

        }        
        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (IsPlay4OCX)
            { 
                if (IsPlay4OCX && PictureSaved4OCX != null)
                {
                    VideoStartSave4OCX(this,e);
                }
            }
            else
            {
                FormExportVideo f = new FormExportVideo(Task);
                f.ShowDialog();
            }  
            return;
            string MSS_IP = "";
            uint MSS_Port = 0;
            string MSS_Path = "";
            if (IsPlay4OCX)
            {
                //MSS_IP = OCX_MssHostIp;
                //MSS_Port = OCX_MssHostPort;
                //MSS_Path = OCX_VideoPath;
                return;
            }
            else
            {
                var mssinfo = m_viewModel.GetMssTaskInfo(Task.TaskId);
                if (mssinfo != null)
                {
                    MSS_IP = mssinfo.MssHostIp;
                    MSS_Port = mssinfo.MssHostPort;
                    MSS_Path = mssinfo.VideoPath;
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            string type = "视频导出";
            string fileName = Task.TaskName.Replace(".", "_").Replace(":", "_") + type + ".mp4";
            bool needSave = true;

            fileName = Framework.Environment.VideoSavePath.TrimEnd('\\') + "\\" + fileName;
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.RestoreDirectory = true;

            sfd.Filter = "*.mp4|*.mp4|全部文件|*.*";
            sfd.FileName = System.IO.Path.GetFileName(fileName);

            sfd.InitialDirectory = Framework.Environment.VideoSavePath;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = sfd.FileName;
            }
            else
            {
                needSave = false;
            }

            if (needSave)
            {

                DownloadInfo downloadInfo = new DownloadInfo()
                {
                    VideoTaskUnitID = Task.TaskId,
                    IsDownloadAllFile = true,
                    LocalSaveFilePath = fileName,
                    StartTime = Task.StartTime,
                    EndTime = Task.EndTime,
                };
                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<AddVideoDownloadEvent>().Publish(downloadInfo);
                if (CloseThis != null)
                    CloseThis(sender, e);
            }

        }

        private void buttonGotoCompare_Click(object sender, EventArgs e)
        {
            Image img= ucSinglePlayWnd1.GrabPictureData(false);
            if (img != null)
            {
                FormSelectCompareParam f = new FormSelectCompareParam(true);

                f.InitPicture(img, new SelectedPictureParam());

                if (f.ShowDialog() == DialogResult.OK)
                {
                    BeginSearchInfo info = new BeginSearchInfo()
                    {
                        Image = f.PictureParam.DemoPicture,
                        PictureParam = f.PictureParam,
                         SearchItem = Task.ToSearchItem(),
                          IsRealtimeTask = false,
                    };
                    if (!f.PictureParam.IsVehicle)
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(
                            new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormPeopleSearch", Title = "行人检索", Discription = "行人检索" }, info));
                    else
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(
                            new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormVehicleSearch", Title = "车辆检索", Discription = "车辆检索" }, info));
                    if (CloseThis != null)
                        CloseThis(sender, e);

                }

            }
        }

        #endregion

        #region 私有函数
        private void FullScreen()
        {
            if (panelEx5.Parent == formfull)
            {
                panelEx5.Parent = panelWin;
                //formfull.PreviewKeyDown -= formfull_PreviewKeyDown;
                formfull.TopMost = false;
                formfull.Close();

            }
            else
            {
                formfull = new Form();
                formfull.KeyPreview = true;
                formfull.BackColor = Color.FromArgb(32, 32, 32);
                formfull.ForeColor = Color.FromArgb(180, 180, 180);
                formfull.TopMost = true;
                formfull.ShowInTaskbar = false;
                formfull.Size = PlayWindowSize;
                formfull.StartPosition = FormStartPosition.Manual;
                formfull.Location = PlayWindowLocation;
                formfull.FormBorderStyle = FormBorderStyle.None;
                panelEx5.Parent = formfull;
                formfull.KeyDown += formfull_KeyDown;
                formfull.Show();
            }
        }
        void formfull_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && panelEx5.Parent == formfull)
            {
                panelEx5.Parent = panelWin;
                formfull.TopMost = false;
                formfull.KeyDown -= formfull_KeyDown;
                formfull.Close();
            }

        }

        private void UpdataTime()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdataTime));
            }
            else
            {
                LabelTime.Text = ucSinglePlayWnd1.VideoTimeStr;
                if(VideoPos!=null)
                    VideoPos(ucSinglePlayWnd1.VideoTime);
            }
        }

        private void SetPlayStatusText()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetPlayStatusText));
            }
            else
            {
                LabelStatus.Text = ucSinglePlayWnd1.VideoStatusString;
            }
        }
        private void SetButtonStatus()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetButtonStatus));
            }
            else
            {
                switch (ucSinglePlayWnd1.VideoStatus)
                {
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO:
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        buttonSpeedUp.Enabled = false;
                        buttonSpeedDown.Enabled = false;
                        buttonBackword.Enabled = false;
                        buttonGotoCompare.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SEEK_ERROR:
                        ucSinglePlayWnd1.StopPlayBack();
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        buttonSpeedUp.Enabled = false;
                        buttonSpeedDown.Enabled = false;
                        buttonBackword.Enabled = false;
                        buttonGotoCompare.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.暂停1;
                        buttonPlay.HoverImage = Properties.Resources.暂停4;
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        buttonSpeedUp.Enabled = true;
                        buttonSpeedDown.Enabled = true;
                        buttonBackword.Enabled = true;
                        buttonGotoCompare.Enabled = true;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                        ucSinglePlayWnd1.StopPlayBack();
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        buttonSpeedUp.Enabled = false;
                        buttonSpeedDown.Enabled = false;
                        buttonBackword.Enabled = false;
                        buttonGotoCompare.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY:
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        buttonSpeedUp.Enabled = true;
                        buttonSpeedDown.Enabled = true;
                        buttonBackword.Enabled = true;
                        buttonGotoCompare.Enabled = true;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_BACKWORD:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        buttonSpeedUp.Enabled = false ;
                        buttonSpeedDown.Enabled = false ;
                        buttonBackword.Enabled = true;
                        buttonGotoCompare.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void buttonBackword_Click(object sender, EventArgs e)
        {
            ucSinglePlayWnd1.BackwordPlay();
        }






    }
}
