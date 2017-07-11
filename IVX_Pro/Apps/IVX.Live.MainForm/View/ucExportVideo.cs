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
    public partial class ucExportVideo : UserControl
    {
        public event EventHandler OnOK;
        #region 私有变量

        private Form formfull = new Form();

        private System.Drawing.Point PlayWindowLocation = new System.Drawing.Point(0, 0);

        private System.Drawing.Size PlayWindowSize = new System.Drawing.Size(1280, 1024);


        private PlayHistoryViewModel m_viewModel;

        #endregion

        #region 属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaskInfoV3_1 Task { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartTime { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EndTime { get; set; }


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
        public ucExportVideo()
        {
            InitializeComponent();
            PlayWindowSize = Screen.PrimaryScreen.Bounds.Size;
            PlayWindowLocation = Screen.PrimaryScreen.Bounds.Location;
        }
        #endregion

        #region 公共函数
        public void Clear()
        {
            ucSinglePlayWnd1.StopPlayBack();
            ucSinglePlayWnd1.UnInit();

        }


        #endregion

        #region 事件响应

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

        private void buttonX1_Click(object sender, EventArgs e)
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

            ucSinglePlayWnd1.GrabPictureData();
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
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SEEK_ERROR:
                        ucSinglePlayWnd1.StopPlayBack();
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.暂停1;
                        buttonPlay.HoverImage = Properties.Resources.暂停4;
                        buttonStop.Enabled = true;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                        ucSinglePlayWnd1.StopPlayBack();
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY:
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage =  Properties.Resources.播放4;
                        buttonStop.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (StartTime == new DateTime())
                StartTime = Task.StartTime;

            if (EndTime == new DateTime())
                EndTime = Task.EndTime;

            string time = StartTime.ToString("yyyyMMddHHmmss") + "_" + EndTime.ToString("yyyyMMddHHmmss");
            string type = "视频导出";
            string fileName = Task.TaskName.Replace(".", "_").Replace(":", "_") + type + time + ".mp4";
            bool needSave = true;

            fileName = Framework.Environment.VideoSavePath.TrimEnd('\\') + "\\" + fileName;
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.RestoreDirectory = true;

            sfd.Filter = "*.*|*.*";
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
                    IsDownloadAllFile = false,
                    LocalSaveFilePath = fileName,
                    StartTime = StartTime,
                    EndTime = EndTime,
                };
                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<AddVideoDownloadEvent>().Publish(downloadInfo);

            }
            if (needSave && OnOK != null)
                OnOK(this, e);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int times = ucSinglePlayWnd1.GetVideoTime();
            var time = new DateTime().AddSeconds( ucSinglePlayWnd1.GetVideoTime());
            labelStart.Text = time.ToLongTimeString();
            StartTime = Task.StartTime.AddSeconds(times);
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            int times = ucSinglePlayWnd1.GetVideoTime();
            var time = new DateTime().AddSeconds( ucSinglePlayWnd1.GetVideoTime());
            labelEnd.Text = time.ToLongTimeString();
            EndTime = Task.StartTime.AddSeconds(times);

        }





    }
}
