using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormSingleRealtimeTask : IVX.Live.MainForm.UILogics.FormBase
    {
        private bool isInited = false;
        private DataModel.TaskInfoV3_1 m_task;
        private SingleTaskViewModel m_viewModel;

        bool m_isChanged = false;

        public uint TaskId { get { return m_task.TaskId; } }
        public FormSingleRealtimeTask(DataModel.TaskInfoV3_1 task)
        {
            InitializeComponent();
            m_task = task;
            //buttonItem1.Enabled = task.AlgthmType != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF;
        }
        public void Init()
        {
            E_VDA_TASK_STATUS totalstatus = 0;
            E_VIDEO_ANALYZE_TYPE totalalaysetype = 0;
            foreach (var s in m_viewModel.CurrentTask.StatusList)
            {
                totalstatus = s.Status;
                totalalaysetype = s.AlgthmType;
            } 
            textBoxAnlyse.Text = DataModel.Constant.VideoAnalyzeTypeInfo.Single(item => item.Type == totalalaysetype).Name;
            textBoxFilePath.Text = m_viewModel.CurrentTask.OriFilePath;
            textBoxTaskId.Text = m_viewModel.CurrentTask.TaskId.ToString();
            textBoxTaskName.Text = m_viewModel.CurrentTask.TaskName;
            textBoxTaskStatus.Text = DataModel.Constant.TaskStatusInfos.Single(item => item.Status == totalstatus).Name;
            int index = m_viewModel.CurrentTask.TaskName.LastIndexOf('_');
            string camName = (index < 0) ? m_viewModel.CurrentTask.TaskName : m_viewModel.CurrentTask.TaskName.Substring(index + 1);
            textBoxCameraID.Text = camName;
            textBoxTaskType.Text = DataModel.Constant.TaskTypeInfos.Single(item => item.Status == m_viewModel.CurrentTask.TaskType).Name;
            comboBoxPriority.SelectedIndex = (int)(m_viewModel.CurrentTask.Priority - 1);
            TitleText = string.Format("[{0}] {1}", m_viewModel.CurrentTask.TaskId, m_viewModel.CurrentTask.TaskName);
            isInited = true;
            foreach (var item in m_viewModel.CurrentTask.StatusList)
            {
                if (item.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    continue;
                DevComponents.DotNetBar.ButtonItem buttonItem = new ButtonItem();
                buttonItem.GlobalItem = false;
                buttonItem.Text = "设置分析参数并重新分析...";
                buttonItem.Click += new System.EventHandler(this.buttonItem1_Click);
                buttonItem.Tag = item;
                buttonReAnalyse.SubItems.Add(buttonItem); buttonReAnalyse.SplitButton = true;
            }
            buttonReAnalyse.Refresh();
        }
        public void UpdateTask(TaskInfoV3_1 info)
        {
            m_viewModel.CurrentTask = info;
            //textBoxTaskStatus.Text = DataModel.Constant.TaskStatusInfos.Single(item => item.Status == stat).Name;
            //progressBarTaskProgress.Value = m_viewModel.CalcProgress(stat, progress);

            //if (progressBarTaskProgress.Value < progressBarTaskProgress.Maximum)
            //    progressBarTaskProgress.Text = (order > 0) ? string.Format("等待排序号:{0}", order) : string.Format("剩余时间:{0}", TimeSpan.FromSeconds(lefttime));
            //else
            //    progressBarTaskProgress.Text = "";

            //buttonReAnalyse.Enabled = (stat != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING && stat != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT);
            Init();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInited)
                return;

            m_viewModel.CurrentTask.Priority = Convert.ToUInt32(((DevComponents.Editors.ComboItem)comboBoxPriority.SelectedItem).Value);
            this.highlighter1.SetHighlightColor(this.comboBoxPriority, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            m_isChanged = true;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (m_isChanged)
            {
                bool ret = m_viewModel.Submit();
                if (ret)
                {
                    m_isChanged = false;
                    this.highlighter1.SetHighlightColor(this.comboBoxPriority, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                    this.highlighter1.SetHighlightColor(this.textBoxTaskName, DevComponents.DotNetBar.Validator.eHighlightColor.None);

                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }


        private void FormSingleTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new ViewModel.SingleTaskViewModel();
            m_viewModel.CurrentTask = m_task;
            Init();
        }

        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBoxTaskName_TextChanged(object sender, EventArgs e)
        {
            if (!isInited)
                return;


            m_viewModel.CurrentTask.TaskName = textBoxTaskName.Text;
            this.highlighter1.SetHighlightColor(this.textBoxTaskName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            m_isChanged = true;

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

            try
            {
                DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
                if (sender != null)
                {
                    var s = buttonItem.Tag as StatusInfoV3_1;
                    if (s != null)
                    {
                        if ((Program.PRODUCT_TYPE & Framework.Environment.E_PRODUCT_TYPE.PuDong_PRODUCT) > 0)
                        {
                            FormEditRealtimeAnalyseParamNoDIO f = new FormEditRealtimeAnalyseParamNoDIO(m_viewModel.CurrentTask.TaskId, s.AlgthmType, s.AnalyseParam);
                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                //m_viewModel.CurrentTask.AnalyseParam = f.Task.AnalyseParam;
                                m_viewModel.PauseTask();
                                bool ret = m_viewModel.ReAnalyse(f.AlgthmType, f.AnalyseParam);
                                if (ret)
                                {

                                }
                                m_viewModel.ResumeTask();

                            }

                        }
                        else
                        {
                            FormEditRealtimeAnalyseParam f = new FormEditRealtimeAnalyseParam(m_viewModel.CurrentTask, s.AlgthmType, s.AnalyseParam);
                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                //m_viewModel.CurrentTask.AnalyseParam = f.Task.AnalyseParam;
                                m_viewModel.PauseTask();
                                bool ret = m_viewModel.ReAnalyse(f.AlgthmType, f.AnalyseParam);
                                if (ret)
                                {

                                }
                                m_viewModel.ResumeTask();

                            }
                        }
                    }
                }
            }
            catch (SDKCallException ex)
            {
                MessageBoxEx.Show("当前状态无法进行重新分析,[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME);
            }
        }

        private void buttonReAnalyse_Click(object sender, EventArgs e)
        {
            try
            {
                E_VDA_TASK_STATUS totalstatus = 0;
                E_VIDEO_ANALYZE_TYPE totalalaysetype = 0;
                foreach (var s in m_viewModel.CurrentTask.StatusList)
                {
                    totalstatus = s.Status;
                    totalalaysetype = s.AlgthmType;
                } 

                m_viewModel.PauseTask();
                bool ret = m_viewModel.ReAnalyse(totalalaysetype,"");
                m_viewModel.ResumeTask();
            }
            catch (SDKCallException ex)
            {
                MessageBoxEx.Show("当前状态无法进行重新分析,[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME);
            }
        }

        private void buttonTransEvent_Click(object sender, EventArgs e)
        {
            FormTransEventList f = new FormTransEventList();
            f.TaskId = m_viewModel.CurrentTask.TaskId;
            f.ShowDialog();

        }



    }
}
