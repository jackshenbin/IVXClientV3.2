using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucPlayBrief : UserControl
    {
        public event Action<BriefMoveobjInfo> MoveObjectDClick4OCX;
        public event Action<string> PictureSaved4OCX;

        #region 私有变量
        private Form formfull = new Form();

        private System.Drawing.Point PlayWindowLocation = new System.Drawing.Point(0, 0);

        private System.Drawing.Size PlayWindowSize = new System.Drawing.Size(1280, 1024);

        private ViewModel.PlayBriefViewModel m_viewModel;

        #endregion
        #region 属性

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
        public string OCX_BriefDataPath { get; set; }
        [DefaultValue("")]
        public string OCX_BriefIndexPath { get; set; }
        [DefaultValue("")]
        public string OCX_TaskName { get; set; }
        [DefaultValue(0)]
        public int OCX_SrcVideoTotleTime { get; set; }

        public DateTime OCX_AdjustTime { get; set; }

        #endregion

        #region 构造
        public ucPlayBrief()
        {
            try
            {
                InitializeComponent();
                PlayWindowSize = Screen.PrimaryScreen.Bounds.Size;
                PlayWindowLocation = Screen.PrimaryScreen.Bounds.Location;
                OCX_AdjustTime = new DateTime(2000, 1, 1, 0, 0, 0);
                OCX_SrcVideoTotleTime = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }
        #endregion

        #region 公共函数
        public void Clear()
        {
            ucSingleBriefPlayWnd1.StopPlayBrief();
            ucSingleBriefPlayWnd1.UnInit();
        }
        #endregion

        #region 事件响应

        private void labelX2_DragDrop(object sender, DragEventArgs e)
        {
            ucSingleBriefPlayWnd p = sender as ucSingleBriefPlayWnd;

            Type dataType = typeof(DevComponents.AdvTree.Node);

            if (e.Data.GetDataPresent(dataType))
            {
                DevComponents.AdvTree.Node node = (DevComponents.AdvTree.Node)e.Data.GetData(dataType);
                TaskInfoV3_1 task = node.Tag as TaskInfoV3_1;
                if (task != null)
                {
                    TaskBriefMSSInfoV3_1 mssinfo = m_viewModel.GetMssTaskInfo(task.TaskId);
                    if (mssinfo != null)
                    {
                        p.VideoName = task.TaskName;

                        p.StartPlayBrief(mssinfo.MssHostIp, mssinfo.MssHostPort, mssinfo.BriefDataPath, mssinfo.BriefIndexPath);
                    }
                    //p.StartPlayBrief(1, "192.168.42.31", 12050, @"F:/Brief/440303581001东晓路罗湖区文化馆阶梯旁.data", @"F:/Brief/440303581001东晓路罗湖区文化馆阶梯旁.brief");
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

            m_viewModel = new ViewModel.PlayBriefViewModel();
            ucSingleBriefPlayWnd1.Init();
            UpdataTime();
            SetButtonStatus();
            SetPlayStatusText();
            switchButtonFilter.Value = true;
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
        void ucSinglePlayWnd_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ucSingleBriefPlayWnd wnd = sender as ucSingleBriefPlayWnd;
            if (e.PropertyName == "VideoStatus")
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
                FullScreen();
        }

        void ucSinglePlayWnd_MouseClickEx(object sender, MouseEventArgs e)
        {
            ucSingleBriefPlayWnd wnd = sender as ucSingleBriefPlayWnd;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (IsPlay4OCX)
            {
                ucSingleBriefPlayWnd1.MSS_IP = OCX_MssHostIp;
                ucSingleBriefPlayWnd1.MSS_Port = OCX_MssHostPort;
                ucSingleBriefPlayWnd1.MSS_Data_Path = OCX_BriefDataPath;
                ucSingleBriefPlayWnd1.MSS_Index_Path = OCX_BriefIndexPath;
                ucSingleBriefPlayWnd1.VideoName = OCX_TaskName;
                ucSingleBriefPlayWnd1.SrcVideoTotleTime = OCX_SrcVideoTotleTime;

                if (ucSingleBriefPlayWnd1.PlayOrPauseOrResume())
                {
                    ucSingleBriefPlayWnd1.SetAdjustTime(OCX_AdjustTime);
                    ucSingleBriefPlayWnd1.EnableShowObjectRect = buttonObjectRect.Checked;
                    ucSingleBriefPlayWnd1.EnableShowObjectTime = buttonObjectRect.Checked;
                    ucSingleBriefPlayWnd1.EnableShowActionFilter = buttonFilterRect.Checked;
                    ucSingleBriefPlayWnd1.EnableShowAreaFilter = buttonFilterRect.Checked;
                }
            }
            else
            {
                if (Task != null)
                {
                    var mssinfo = m_viewModel.GetMssTaskInfo(Task.TaskId);
                    if (mssinfo != null)
                    {
                        //ucSingleBriefPlayWnd1.MSS_IP = "192.168.42.31";
                        //ucSingleBriefPlayWnd1.MSS_Port = 12050;
                        //ucSingleBriefPlayWnd1.MSS_Data_Path = @"F:/Brief/440303581001东晓路罗湖区文化馆阶梯旁.data";
                        //ucSingleBriefPlayWnd1.MSS_Index_Path = @"F:/Brief/440303581001东晓路罗湖区文化馆阶梯旁.brief";
                        ucSingleBriefPlayWnd1.MSS_IP = mssinfo.MssHostIp;
                        ucSingleBriefPlayWnd1.MSS_Port = mssinfo.MssHostPort;
                        ucSingleBriefPlayWnd1.MSS_Data_Path = mssinfo.BriefDataPath;
                        ucSingleBriefPlayWnd1.MSS_Index_Path = mssinfo.BriefIndexPath;
                        ucSingleBriefPlayWnd1.VideoName = Task.TaskName;
                        ucSingleBriefPlayWnd1.SrcVideoTotleTime = Convert.ToInt32(Task.EndTime.Subtract(Task.StartTime).TotalSeconds);
                        //ucSingleBriefPlayWnd1.TaskId = 1;
                        //ucSingleBriefPlayWnd1.StartPlayBrief(1, "192.168.42.31", 12050, @"F:/Brief/440303581001东晓路罗湖区文化馆阶梯旁.data", @"F:/Brief/440303581001东晓路罗湖区文化馆阶梯旁.brief");
                        if (ucSingleBriefPlayWnd1.PlayOrPauseOrResume())
                        {
                            ucSingleBriefPlayWnd1.SetAdjustTime(Task.StartTime);
                            ucSingleBriefPlayWnd1.EnableShowObjectRect = buttonObjectRect.Checked;
                            ucSingleBriefPlayWnd1.EnableShowObjectTime = buttonObjectRect.Checked;
                            ucSingleBriefPlayWnd1.EnableShowActionFilter = buttonFilterRect.Checked;
                            ucSingleBriefPlayWnd1.EnableShowAreaFilter = buttonFilterRect.Checked;
                        }
                    }
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.StopPlayBrief();

        }

        private void switchButtonItem1_ValueChanged(object sender, EventArgs e)
        {
            //btnSetColor.Visible = switchButtonItem1.Value;
            //btnSetCompare.Visible = switchButtonFilter.Value;
            //btnSetDirection.Visible = switchButtonFilter.Value;
            btnSetInterest.Visible = switchButtonFilter.Value;
            btnSetSheild.Visible = switchButtonFilter.Value;
            //btnSetSize.Visible = switchButtonFilter.Value;
            //btnSetSpeed.Visible = switchButtonFilter.Value;
            buttonItemSet.Visible = switchButtonFilter.Value;

            bar1.Refresh();
            ucSingleBriefPlayWnd1.EnableDraw = switchButtonFilter.Value;
            ucSingleBriefPlayWnd1.SetObjectType(switchButtonFilter.Value?(E_VDA_MOVEOBJ_TYPE)sliderSize.Value:E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_ALL);
            if (!switchButtonFilter.Value)
                ucSingleBriefPlayWnd1.ClearDrawGraph();
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
            
        }


        private void sliderDensity_ValueChanged(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.SetDensity((E_VDA_BRIEF_DENSITY)sliderDensity.Value);
            ucSingleBriefPlayWnd1.StopPlayBrief();
            ucSingleBriefPlayWnd1.PlayOrPauseOrResume();
        }
        private void buttonGrab_Click(object sender, EventArgs e)
        {
            string fileName="";
            if (IsPlay4OCX)
            {
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "视频截图";
                fileName = IVX.Live.MainForm.Framework.Environment.PictureSavePath.TrimEnd('\\')+'\\'
                    + OCX_TaskName.Trim().Replace(".", "_").Replace(":", "_") + type + time + ".jpg";
 
            }
            string retval = ucSingleBriefPlayWnd1.GrabPictureData(fileName);
            if (!string.IsNullOrEmpty(retval))
            {
                if (IsPlay4OCX && PictureSaved4OCX!=null)
                {
                    PictureSaved4OCX(retval);
                }
            }
        }

        private void buttonSpeedUp_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.SpeedUp();
        }

        private void buttonSpeedDown_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.SpeedDown();

        }
        void ucSingleBriefPlayWnd1_MoveObjectClick(ucSingleBriefPlayWnd arg1, DataModel.BriefMoveobjInfo arg2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MoveObjID:"+arg2.MoveObjID);
            sb.AppendLine("MoveObjType:"+arg2.MoveObjType);
            sb.AppendLine("MoveObjColor:"+arg2.MoveObjColor);
            sb.AppendLine("BeginTimeS:"+arg2.BeginTimeS);
            sb.AppendLine("EndTimeS:" + arg2.EndTimeS);

            //MessageBox.Show(sb.ToString());
            VodInfo vod = new VodInfo()
            {
                EndTime = arg2.EndTimeS,
                IsPlayAllFile = false,
                PlayWnd = IntPtr.Zero,
                StartTime = arg2.BeginTimeS,
            };
            if (IsPlay4OCX)
            {
                vod.VideoTaskUnitID = 0;
                if (MoveObjectDClick4OCX != null) MoveObjectDClick4OCX(arg2);
            }
            else
            {
                vod.VideoTaskUnitID = Task.TaskId;
                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<BriefObjectPlayBackEvent>().Publish(vod);
            }
        }


        private void btnSetDirection_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.SetDrawType(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_ARROW_LINE);
        }

        private void btnSetSheild_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.SetDrawType(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_UNINTERESTED_AREA);
        }

        private void btnSetInterest_Click(object sender, EventArgs e)
        {

            ucSingleBriefPlayWnd1.SetDrawType(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_INTERESTED_AREA);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.EnableShowObjectTime = buttonObjectRect.Checked;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.EnableShowObjectRect = buttonFilterRect.Checked;
            //ucSingleBriefPlayWnd1.EnableShowActionFilter = buttonFilterRect.Checked;
            //ucSingleBriefPlayWnd1.EnableShowAreaFilter = buttonFilterRect.Checked;

        }

        private void sliderSize_ValueChanging(object sender, DevComponents.DotNetBar.CancelIntValueEventArgs e)
        {
            ucSingleBriefPlayWnd1.SetObjectType((E_VDA_MOVEOBJ_TYPE)e.NewValue);
        }

        private void buttonItemSet_Click(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.StopPlayBrief();
            ucSingleBriefPlayWnd1.PlayOrPauseOrResume();
        }


        private void ratingStar1_RatingChanged(object sender, EventArgs e)
        {
            ucSingleBriefPlayWnd1.SetDensity((E_VDA_BRIEF_DENSITY)(ratingStar1.Rating*2));
            ucSingleBriefPlayWnd1.StopPlayBrief();
            ucSingleBriefPlayWnd1.PlayOrPauseOrResume();
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
                LabelTime.Text = ucSingleBriefPlayWnd1.VideoTime;
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
                LabelStatus.Text = ucSingleBriefPlayWnd1.VideoStatusString;
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
                switch (ucSingleBriefPlayWnd1.VideoStatus)
                {
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO:
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage = Properties.Resources.播放4;
                        buttonPlay.Tooltip = "播放";
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        buttonSpeedUp.Enabled = false;
                        buttonSpeedDown.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SEEK_ERROR:
                        ucSingleBriefPlayWnd1.StopPlayBrief();
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage = Properties.Resources.播放4;
                        buttonPlay.Tooltip = "播放";
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        buttonSpeedUp.Enabled = false;
                        buttonSpeedDown.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.暂停1;
                        buttonPlay.HoverImage = Properties.Resources.暂停4;
                        buttonPlay.Tooltip = "暂停";
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        buttonSpeedUp.Enabled = true;
                        buttonSpeedDown.Enabled = true;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                        ucSingleBriefPlayWnd1.StopPlayBrief();
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage = Properties.Resources.播放4;
                        buttonPlay.Tooltip = "播放";
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        buttonSpeedUp.Enabled = false;
                        buttonSpeedDown.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY:
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE:
                        buttonPlay.Enabled = true;
                        buttonPlay.Image = Properties.Resources.播放1;
                        buttonPlay.HoverImage = Properties.Resources.播放4;
                        buttonPlay.Tooltip = "播放";
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        buttonSpeedUp.Enabled = true;
                        buttonSpeedDown.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void buttonItemUnSet_Click(object sender, EventArgs e)
        {
                ucSingleBriefPlayWnd1.ClearDrawGraph();

        }



    }
}
