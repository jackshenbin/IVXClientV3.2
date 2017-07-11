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
    public partial class FormSingleTask : IVX.Live.MainForm.UILogics.FormBase
    {
        private bool isInited = false;
        private DataModel.TaskInfoV3_1 m_task;
        private SingleTaskViewModel m_viewModel;
        List<DevComponents.DotNetBar.ButtonItem> list = new List<DevComponents.DotNetBar.ButtonItem>();

        bool m_isChanged = false;

        public uint TaskId { get { return m_task.TaskId; } }
        public FormSingleTask(DataModel.TaskInfoV3_1 task)
        {
            InitializeComponent();
            m_task = task;
            //buttonItem1.Enabled = !(task.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF || task.AlgthmType== E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE);
            //buttonReAnalyse.Enabled = (task.Status!= E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING && task.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT);
            //comboBoxExSplitTime.SelectedIndex = 0;
        }
        public void Init()
        {
            var all = Constant.VideoAnalyzeTypeInfo.Where
                (
                item => item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT
                ).Select(it => it.Type).ToList();
            //textBoxAnlyse.Text = "DataModel.Constant.VideoAnalyzeTypeInfo.Single(item => item.Type == m_viewModel.CurrentTask.AlgthmType).Name";
            textBoxFilePath.Text = m_viewModel.CurrentTask.OriFilePath;
            textBoxFileSize.Text = DataModel.Common.GetByteSizeInUnit(m_viewModel.CurrentTask.FileSize);
            textBoxFileType.Text = DataModel.Constant.TaskFileTypeInfos.Single(item => item.Status == m_viewModel.CurrentTask.FileType).Name;
            textBoxTaskId.Text = m_viewModel.CurrentTask.TaskId.ToString();
            textBoxTaskName.Text = m_viewModel.CurrentTask.TaskName;
            //textBoxTaskStatus.Text = "DataModel.Constant.TaskStatusInfos.Single(item => item.Status == m_viewModel.CurrentTask.Status).Name";
            textBoxTaskType.Text = DataModel.Constant.TaskTypeInfos.Single(item => item.Status == m_viewModel.CurrentTask.TaskType).Name;
            comboBoxPriority.SelectedIndex = (int)(m_viewModel.CurrentTask.Priority - 1);
            dateTimeEnd.Value = m_viewModel.CurrentTask.EndTime;
            dateTimeStart.Value = m_viewModel.CurrentTask.StartTime;
            //progressBarTaskProgress.Value = m_viewModel.CurrentProgress;
            TitleText = string.Format("[{0}] {1}", m_viewModel.CurrentTask.TaskId, m_viewModel.CurrentTask.TaskName);
            isInited = true;
            advTree1.Nodes.Clear();
            foreach (var item in m_viewModel.CurrentTask.StatusList)
            {
                if (item.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    continue;

                all.Remove(item.AlgthmType);
                DevComponents.AdvTree.Node sn = new DevComponents.AdvTree.Node();
                DevComponents.DotNetBar.ButtonItem buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
                buttonItem1.Text = "";
                buttonItem1.Click += buttonItem1_Click;
                buttonItem1.Image = Properties.Resources.remove_analyse_24;
                buttonItem1.Tag = item;
                sn.HostedItem = buttonItem1;
                sn.Cells.Add(new DevComponents.AdvTree.Cell(DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == item.AlgthmType).Name));
                sn.Cells.Add(new DevComponents.AdvTree.Cell(DataModel.Constant.TaskStatusInfos.Single(it => it.Status == item.Status).Name));

                int progress = m_viewModel.CalcProgress(item.Status, (int)item.Progress);
                DevComponents.DotNetBar.ProgressBarItem sprogressBarItem = new DevComponents.DotNetBar.ProgressBarItem();
                sprogressBarItem.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                sprogressBarItem.ChunkGradientAngle = 0F;
                sprogressBarItem.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
                sprogressBarItem.RecentlyUsed = false;
                sprogressBarItem.Maximum = 1000;
                sprogressBarItem.TextVisible = true;
                sprogressBarItem.Value = progress;
                if (sprogressBarItem.Value < sprogressBarItem.Maximum)
                    sprogressBarItem.Text = (m_viewModel.CurrentTask.Order > 0) ? "" : string.Format("剩余时间:{0}", TimeSpan.FromSeconds(item.LeftTime));
                else
                    sprogressBarItem.Text = "";
                DevComponents.AdvTree.Cell sc2 = new DevComponents.AdvTree.Cell();
                sc2.HostedItem = sprogressBarItem;

                sn.Cells.Add(sc2);

                DevComponents.DotNetBar.ButtonItem buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
                buttonItem2.Text = "选择切分方式";
                DevComponents.DotNetBar.ButtonItem sbuttonItem0 = new DevComponents.DotNetBar.ButtonItem();
                sbuttonItem0.Text = "按默认切分";
                sbuttonItem0.Click += buttonItem2_Click;
                sbuttonItem0.Tag = new Tuple<E_VIDEO_ANALYZE_TYPE, uint>(item.AlgthmType, 0);
                buttonItem2.SubItems.Add(sbuttonItem0);
                DevComponents.DotNetBar.ButtonItem sbuttonItem1 = new DevComponents.DotNetBar.ButtonItem();
                sbuttonItem1.Text = "按5分钟切分";
                sbuttonItem1.Click += buttonItem2_Click;
                sbuttonItem1.Tag = new Tuple<E_VIDEO_ANALYZE_TYPE, uint>(item.AlgthmType, 300);
                buttonItem2.SubItems.Add(sbuttonItem1);
                DevComponents.DotNetBar.ButtonItem sbuttonItem2 = new DevComponents.DotNetBar.ButtonItem();
                sbuttonItem2.Text = "按10分钟切分";
                sbuttonItem2.Click += buttonItem2_Click;
                sbuttonItem2.Tag = new Tuple<E_VIDEO_ANALYZE_TYPE, uint>(item.AlgthmType, 600);
                buttonItem2.SubItems.Add(sbuttonItem2);
                DevComponents.DotNetBar.ButtonItem sbuttonItem3 = new DevComponents.DotNetBar.ButtonItem();
                sbuttonItem3.Text = "按20分钟切分";
                sbuttonItem3.Click += buttonItem2_Click;
                sbuttonItem3.Tag = new Tuple<E_VIDEO_ANALYZE_TYPE, uint>(item.AlgthmType, 1200);
                buttonItem2.SubItems.Add(sbuttonItem3);
                DevComponents.DotNetBar.ButtonItem sbuttonItem4 = new DevComponents.DotNetBar.ButtonItem();
                sbuttonItem4.Text = "按30分钟切分";
                sbuttonItem4.Click += buttonItem2_Click;
                sbuttonItem4.Tag = new Tuple<E_VIDEO_ANALYZE_TYPE, uint>(item.AlgthmType, 1800);
                buttonItem2.SubItems.Add(sbuttonItem4);
                DevComponents.DotNetBar.ButtonItem sbuttonItem5 = new DevComponents.DotNetBar.ButtonItem();
                sbuttonItem5.Text = "不切分";
                sbuttonItem5.Click += buttonItem2_Click;
                sbuttonItem5.Tag = new Tuple<E_VIDEO_ANALYZE_TYPE, uint>(item.AlgthmType, int.MaxValue);
                buttonItem2.SubItems.Add(sbuttonItem5);

                buttonItem2.AutoExpandOnClick = true;
                buttonItem2.ShowSubItems = false;
                buttonItem2.ExpandChange += buttonItem_ExpandChange;
                DevComponents.AdvTree.Cell sc3 = new DevComponents.AdvTree.Cell();
                sc3.HostedItem = buttonItem2;
                sn.Cells.Add(sc3);

                DevComponents.DotNetBar.ButtonItem buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
                buttonItem3.Text = "重新分析";
                buttonItem3.Click += buttonItem3_Click;
                buttonItem3.Tag = item;
                if (item.AlgthmType != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF)
                {
                    DevComponents.DotNetBar.ButtonItem sbuttonItem6 = new DevComponents.DotNetBar.ButtonItem();
                    sbuttonItem6.Text = "设置分析参数并重新分析...";
                    sbuttonItem6.Click += sbuttonItem6_Click;
                    sbuttonItem6.Tag = item;
                    buttonItem3.SubItems.Add(sbuttonItem6);
                }
                buttonItem3.AutoExpandOnClick = false;
                buttonItem3.ExpandChange += buttonItem_ExpandChange;
                DevComponents.AdvTree.Cell sc4 = new DevComponents.AdvTree.Cell();
                sc4.HostedItem = buttonItem3;
                sn.Cells.Add(sc4);

                sn.Tag = item;
                advTree1.Nodes.Add(sn);
            }

            DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
            DevComponents.DotNetBar.ButtonItem buttonItem = new DevComponents.DotNetBar.ButtonItem();
            buttonItem.Text = "";
            buttonItem.Image = Properties.Resources.add__analyse_24;
            foreach (var item in all)
            {
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    continue;
                DevComponents.DotNetBar.ButtonItem buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
                buttonItem1.Text = "添加 " + DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == item).Name + " 算法";
                buttonItem1.Click += buttonItem_Click;
                buttonItem1.Tag = item;
                buttonItem.SubItems.Add(buttonItem1);
            }
            buttonItem.AutoExpandOnClick = true;
            buttonItem.ShowSubItems = false;
            buttonItem.ExpandChange += buttonItem_ExpandChange;
            n.Visible = (buttonItem.SubItems.Count > 0);

            //buttonItem.Tag = new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(item.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE);
            n.HostedItem = buttonItem;
            n.Cells.Add(new DevComponents.AdvTree.Cell());
            n.Cells.Add(new DevComponents.AdvTree.Cell());
            n.Cells.Add(new DevComponents.AdvTree.Cell());
            n.Cells.Add(new DevComponents.AdvTree.Cell());
            n.Cells.Add(new DevComponents.AdvTree.Cell());

            advTree1.Nodes.Add(n);
        }

        void buttonItem_ExpandChange(object sender, EventArgs e)
        {

            DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
            if (buttonItem != null)
            {
                if (buttonItem.Expanded)
                {
                    foreach (var item in list)
                    {
                        item.Expanded = false;
                    }
                    list.Clear();

                    list.Add(buttonItem);
                }
            }
        }

        void sbuttonItem6_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
                if (sender != null)
                {
                    var s = buttonItem.Tag as StatusInfoV3_1;
                    if (s != null)
                    {

                        FormEditHistoryAnalyseParam f = new FormEditHistoryAnalyseParam(m_viewModel.CurrentTask, s.AlgthmType, s.AnalyseParam);
                        if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            //m_viewModel.CurrentTask.AnalyseParam = f.Task.AnalyseParam;
                            bool ret = m_viewModel.ReAnalyse(f.AlgthmType, f.AnalyseParam);
                            if (ret)
                            {
                                //m_isSplitTimeChanged = false;
                                //this.highlighter1.SetHighlightColor(this.comboBoxExSplitTime, DevComponents.DotNetBar.Validator.eHighlightColor.None);

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
        void buttonItem3_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
                if (sender != null)
                {
                    var s = buttonItem.Tag as StatusInfoV3_1;
                    if (s != null)
                    {

                            bool ret = m_viewModel.ReAnalyse(s.AlgthmType, "");
                            if (ret)
                            {
                                //m_isSplitTimeChanged = false;
                                //this.highlighter1.SetHighlightColor(this.comboBoxExSplitTime, DevComponents.DotNetBar.Validator.eHighlightColor.None);

                            }

                    }
                }
            }
            catch (SDKCallException ex)
            {
                MessageBoxEx.Show("当前状态无法进行重新分析,[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME);
            }
        }
        void buttonItem2_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
            if (sender != null)
            {
                var s = buttonItem.Tag as Tuple<E_VIDEO_ANALYZE_TYPE,uint>;
                if (s != null)
                {
                    bool ret = m_viewModel.ReAnalyse(s.Item1, "", s.Item2);
                }
            }

        }

        void buttonItem1_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
            if (sender != null)
            {
                var s = buttonItem.Tag as StatusInfoV3_1;
                if (s != null)
                {
                    m_viewModel.DeleteAnalyse(s.AlgthmType);
                }
            }
        }
        void buttonItem_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem buttonItem = sender as DevComponents.DotNetBar.ButtonItem;
            if (sender != null)
            {
                var s = (E_VIDEO_ANALYZE_TYPE)buttonItem.Tag;
                m_viewModel.AddAnalyse(s);
            }
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
                    this.highlighter1.SetHighlightColor(this.dateTimeStart, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                    this.highlighter1.SetHighlightColor(this.dateTimeEnd, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                    this.highlighter1.SetHighlightColor(this.textBoxTaskName, DevComponents.DotNetBar.Validator.eHighlightColor.None);

                }
            }
            //if(m_isSplitTimeChanged)
            //{
            //    bool ret = m_viewModel.ReAnalyse(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE,"");
            //    if (ret)
            //    {
            //        m_isSplitTimeChanged = false;
            //        this.highlighter1.SetHighlightColor(this.comboBoxExSplitTime, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            //    }
            //}
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            if (!isInited)
                return;


            m_viewModel.CurrentTask.StartTime = dateTimeStart.Value;
            this.highlighter1.SetHighlightColor(this.dateTimeStart, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            m_isChanged = true;
        }

        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!isInited)
                return;


            m_viewModel.CurrentTask.EndTime = dateTimeEnd.Value;
            this.highlighter1.SetHighlightColor(this.dateTimeEnd, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            m_isChanged = true;

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
            foreach (var item in list)
            {
                item.Expanded = false;
            }
            list.Clear();

        }

        private void textBoxTaskName_TextChanged(object sender, EventArgs e)
        {
            if (!isInited)
                return;


            m_viewModel.CurrentTask.TaskName = textBoxTaskName.Text;
            this.highlighter1.SetHighlightColor(this.textBoxTaskName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            m_isChanged = true;

        }




        private void buttonTransEvent_Click(object sender, EventArgs e)
        {
            FormTransEventList f = new FormTransEventList();
            f.TaskId = m_viewModel.CurrentTask.TaskId;
            f.ShowDialog();
        }

        //private void comboBoxExSplitTime_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (!isInited)
        //        return;

        //    m_viewModel.SplitTime = Convert.ToUInt32(((DevComponents.Editors.ComboItem)comboBoxExSplitTime.SelectedItem).Value);
        //    this.highlighter1.SetHighlightColor(this.comboBoxExSplitTime, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
        //    m_isSplitTimeChanged = true;

        //}



    }
}
