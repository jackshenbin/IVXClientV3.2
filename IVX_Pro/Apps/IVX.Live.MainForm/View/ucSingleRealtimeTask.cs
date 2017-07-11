using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSingleRealtimeTask : UserControl
    {
        [Category("event")]
        public new event EventHandler Click;

        [Category("event")]
        public event EventHandler TaskPlay;

        [Category("event")]
        public event EventHandler TaskDeleteClick;

        [Category("event")]
        public event EventHandler PauseResumeClick;

        [Category("event")]
        public event Action<ucSingleRealtimeTask, E_TASK_ACTION_TYPE> TaskDoAction;

        private int TipShowTime = 4;

        public ucSingleRealtimeTask()
        {
            InitializeComponent();
            buttonTaskInfo.Tag = "Info";
            buttonPlay.Tag = "Play";
            buttonReAnalyse.Tag = "ReAnalyse";
            buttonBrief.Tag = E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_BRIEF;
            buttonMoveObj.Tag = E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_PEOPLE_SEARCH;
            buttonVehicle.Tag = E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_VEHICLE_SEARCH;
            buttonCrowd.Tag = E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_CROWD;
            buttonTrafficEvent.Tag = E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaskInfoV3_1 Task { get; private set; }
        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            SetMouseOverStyle();
        }

        private void tableLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            SetMouseOverStyle();
        }

        private void SetMouseOverStyle()
        { 
            Point last = MousePosition;
            Rectangle rect = tableLayoutPanel1.RectangleToScreen(tableLayoutPanel1.DisplayRectangle);
            bool contain = rect.Contains(last);
            int newval = contain ? 1 : 0;
            if (panelEx1.Style.BorderWidth != newval)
                panelEx1.Style.BorderWidth = newval;
        }

        private void reflectionImage4_Click(object sender, EventArgs e)
        {
            if (Task == null || Task.TaskId == 0)
                return;

            if (DevComponents.DotNetBar.MessageBoxEx.Show("是否要删除任务 [" + Task.TaskId + "]" + Task.ToString() + "？", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                if (TaskDeleteClick != null)
                    TaskDeleteClick(this, e);
            }
        }

        private void reflectionImage3_Click(object sender, EventArgs e)
        {
            //if (Click != null)
            //    Click(this, e);
            flowLayoutPanel1.Visible = true;

        }

        private void ucSingleHistoryTask_Load(object sender, EventArgs e)
        {

        }

        public void Init(DataModel.TaskInfoV3_1 task,IVX.DataModel.E_VDA_TASK_STATUS stat, int progress)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<DataModel.TaskInfoV3_1,IVX.DataModel.E_VDA_TASK_STATUS, int>(Init), task,stat, progress);
            }
            else
            {
                this.Visible = (task != null);

                if(task!=null)
                {
                    Task = task;
                    labelTaskId.Text = task.TaskId.ToString();
                    labelAnalyseType.Text = "DataModel.Constant.VideoAnalyzeTypeInfo.Single(item => item.Type == task.AlgthmType).Name";
                    labelName.Text = task.ToString();
                    labelCameraId.Text = "";
                    BuildTooltipBody();
                }
                labelStatus.Text = DataModel.Constant.TaskStatusInfos.Single(item => item.Status == stat).Name;
                if (stat == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND)
                {
                    reflectionImage1.Image = Properties.Resources.播放1; 
                    reflectionImage1.Enabled = true; 
                    this.toolTip1.SetToolTip(this.reflectionImage1, "继续分析");
                }
                else if (stat == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING)
                {
                    reflectionImage1.Image = Properties.Resources.暂停1; 
                    reflectionImage1.Enabled = true; 
                    this.toolTip1.SetToolTip(this.reflectionImage1, "暂停分析");
                }
                else
                { reflectionImage1.Image = null; reflectionImage1.Enabled = false; }


            }
        }
        private void BuildTooltipBody()
        {
            buttonPlay.Visible = false;
            buttonReAnalyse.Visible = false;
            buttonBrief.Visible = false;
            buttonMoveObj.Visible = false;
            buttonVehicle.Visible = false;
            buttonTaskInfo.Visible = false;
            buttonCrowd.Visible = false;
            buttonTrafficEvent.Visible = false;

            int n = 0;
            buttonTaskInfo.Visible = true; n++;
            if (!Task.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE))
            {
                buttonPlay.Visible = true; n++;
            }
            //if (Task.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED)
            //{
                //buttonReAnalyse.Visible = true; n++;
            //}
            foreach (var item in Task.StatusList)
            {
                if (item.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    continue;

                if (item.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND
                    || item.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING)
                {
                    switch (item.AlgthmType)
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
                            buttonBrief.Visible = true; n++;
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
                            buttonMoveObj.Visible = true; n++;
                            buttonVehicle.Visible = true; n++;
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
                            buttonTrafficEvent.Visible = true; n++;
                            buttonVehicle.Visible = true; n++;
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD:
                            buttonCrowd.Visible = true; n++;
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT:
                            break;
                        case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH:
                            break;
                        default:
                            break;
                    }
                }
            }
            flowLayoutPanel1.Width = 3 + n * 44;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            DevComponents.DotNetBar.ButtonX bt = sender as DevComponents.DotNetBar.ButtonX;
            if (bt.Tag == null)
                return;

            if (bt.Tag is string)
            {
                switch (bt.Tag.ToString())
                {
                    case "Play":
                        if (TaskPlay != null)
                            TaskPlay(this, null);
                        break;
                    case "ReImport":
                        break;
                    case "ReAnalyse":
                        break;
                    case "Info":
                        if (Click != null)
                            Click(this, null);
                        break;
                    default:
                        break;
                }
            }
            if (bt.Tag is E_TASK_ACTION_TYPE)
            {
                if (TaskDoAction != null)
                    TaskDoAction(this, (E_TASK_ACTION_TYPE)bt.Tag);

            }
        }

        private void reflectionImage1_Click(object sender, EventArgs e)
        {
            if (PauseResumeClick != null)
                PauseResumeClick(this, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Visible)
            {
                if (!flowLayoutPanel1.RectangleToScreen(flowLayoutPanel1.DisplayRectangle).Contains(MousePosition))
                    TipShowTime--;
                else
                    TipShowTime = 4;
                if (TipShowTime <= 0)
                {
                    flowLayoutPanel1.Visible = false;
                    TipShowTime = 4;
                }
            }

        }


    }
}
