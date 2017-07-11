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
    public partial class FormRealtimeTaskManagement : IVX.Live.MainForm.UILogics.FormBase
    {
        #region 私有变量
        List<string> OpenedList = new List<string>();
        FormSingleRealtimeTask m_currentShownTask = null;
        ucSingleRealtimeTask m_currentTask;
        RealtimeTaskManagementViewModel m_viewModel = null;
        uint m_maxTaskCountPerPage = 10;
        private int SingleHistoryTaskHeight = 50;
        private bool isClosed = false;
        private System.Threading.Thread m_thGetTaskProgress;
        #endregion
        #region 属性
        public uint MaxTaskCountPerPage
        {
            get { return m_maxTaskCountPerPage; }
            set
            {
                if (m_maxTaskCountPerPage != value)
                { 
                    m_maxTaskCountPerPage = value;
                    BuildTaskList(m_maxTaskCountPerPage);
                }
            }
        }

        #endregion
        #region 构造
        public FormRealtimeTaskManagement()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            
        }
        #endregion

        #region 事件响应
        private void FormRealtimeTaskManagement_Load(object sender, EventArgs e)
        {
            List<Control> clist = CreateFilterControl();
            flowLayoutPanel2.Controls.AddRange(clist.ToArray());

            if (DesignMode)
                return;

            m_viewModel = new RealtimeTaskManagementViewModel();
            m_viewModel.UpdateTaskProgress += new Action<int,uint, IVX.DataModel.E_VDA_TASK_STATUS, uint>(m_viewModel_UpdateTaskProgress);
            m_viewModel.TaskAdded += m_viewModel_TaskChanged;
            m_viewModel.TaskDeleted += m_viewModel_TaskChanged;
            m_viewModel.TaskModified += m_viewModel_TaskChanged;

            m_viewModel.CurrentPageIndex = 1;
            m_viewModel.CountPerPage = CalcMaxTaskCountPerPage();

            m_thGetTaskProgress = new System.Threading.Thread(thGetTaskProgress);
            m_thGetTaskProgress.Start();
        }



        void m_viewModel_TaskChanged(TaskInfoV3_1 obj)
        {
            var list = m_viewModel.FrashPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }
        private uint CalcMaxTaskCountPerPage()
        {
            int count = flowLayoutPanel1.Height / (SingleHistoryTaskHeight+6);
            if(count<=0)
                return m_maxTaskCountPerPage;
            return (uint)count;
        }


        void m_viewModel_UpdateTaskProgress(int index,uint arg1, IVX.DataModel.E_VDA_TASK_STATUS arg2, uint arg3)
        {
            if (isClosed)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<int,uint, IVX.DataModel.E_VDA_TASK_STATUS, uint>(m_viewModel_UpdateTaskProgress),index, arg1, arg2, arg3);
            }
            else
            {
                ucSingleRealtimeTask taskinfo = null;
                try
                {
                    if (flowLayoutPanel1.Controls.ContainsKey("ucSingleRealtimeTask_" + index))
                    {
                        taskinfo = flowLayoutPanel1.Controls["ucSingleRealtimeTask_" + index] as ucSingleRealtimeTask;
                    }
                    if (taskinfo != null)
                    {
                        if (arg1 == 0)
                            taskinfo.Init(null, arg2, (int)arg3);
                        else
                        taskinfo.Init(m_viewModel.GetTaskInfo(arg1), arg2, (int)arg3);
                        if (m_currentShownTask != null && m_currentShownTask.Created && m_currentShownTask.TaskId == arg1)
                            m_currentShownTask.UpdateProgress(arg2, (int)arg3);

                    }
                }
                catch (Exception)
                {
                    return;
                }

            }
        }

        private void FormTaskManagement_MdiChildActivate(object sender, EventArgs e)
        {
            BuildTaskList();
        }

        private void FormTaskManagement_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonShowMap_Click(object sender, EventArgs e)
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu,object>( new SystemMenu { URL = "FormGisMap", Title = "电子地图", Discription = "地图选点添加" },null));

        }

        #endregion

        #region 私有函数

        private void thGetTaskProgress()
        {
            //System.Threading.Thread.Sleep(1000);
            while (!isClosed)
            {
                var list = m_viewModel.FrashPage();
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                    }
                    //m_viewModel.FrashProgress();
                    for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                    {
                        m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                    }
                    PageNavigatorChanged();
                    break;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        System.Threading.Thread.Sleep(100); Application.DoEvents();
                        if (isClosed)
                            break;
                    }
                }

            }
        }
        private void PageNavigatorChanged()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(PageNavigatorChanged));
            }
            else
            {
                pageNavigatorEx1.Index = (int)m_viewModel.CurrentPageIndex;
                pageNavigatorEx1.MaxCount = (int)m_viewModel.TotalPage;
                labelCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_viewModel.TotalCount, m_viewModel.TotalPage);

            }
        }


        private void BuildTaskList()
        {
            BuildTaskList(m_maxTaskCountPerPage);
            var list = m_viewModel.FrashPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }

        private void BuildTaskList(uint count)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(BuildTaskList),count);
            }
            else
            {
                MyLog4Net.Container.Instance.Log.Debug("BuildTaskList RealtimeTask count:" + count);
                if (flowLayoutPanel1.Controls.Count == count)
                    return;
                while (flowLayoutPanel1.Controls.Count!= count)
                {
                    if (flowLayoutPanel1.Controls.Count > count)
                        flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
                    else if (flowLayoutPanel1.Controls.Count < count)
                    {
                        ucSingleRealtimeTask uctask = new ucSingleRealtimeTask();
                        uctask.Size = new System.Drawing.Size(flowLayoutPanel1.Width - 30, SingleHistoryTaskHeight);
                        uctask.Name = "ucSingleRealtimeTask_" + flowLayoutPanel1.Controls.Count;
                        uctask.Click += uctask_Click;
                        uctask.TaskPlay += uctask_TaskPlay;
                        uctask.TaskDeleteClick += uctask_TaskDeleteClick;
                        uctask.PauseResumeClick += uctask_PauseResumeClick;
                        uctask.TaskDoAction += uctask_TaskDoAction;
                        uctask.Visible = false;
                        this.flowLayoutPanel1.Controls.Add(uctask); 
                    }
                }
            }
        }
        void uctask_TaskPlay(object sender, EventArgs e)
        {
            ucSingleRealtimeTask uctask = sender as ucSingleRealtimeTask;
            m_currentTask = uctask;

            FormPlayRealtime f = new FormPlayRealtime(m_currentTask.Task);
            f.ShowDialog();
        }

        void uctask_PauseResumeClick(object sender, EventArgs e)
        {
            ucSingleRealtimeTask uctask = sender as ucSingleRealtimeTask;
            if (uctask != null)
            {
                m_viewModel.PauseOrResumeTask(uctask.Task.TaskId);
                    
            }
        }
        void uctask_TaskDoAction(ucSingleRealtimeTask arg1, E_TASK_ACTION_TYPE arg2)
        {
            var cam = m_viewModel.GetCameraInfo(arg1.Task.CameraID);

            switch (arg2)
            {
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_NONE:
                    break;
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_PEOPLE_SEARCH:
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormPeopleSearch", Title = "行人检索", Discription = "行人检索" }, cam));
                    break;
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_VEHICLE_SEARCH:
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormVehicleSearch", Title = "车辆检索", Discription = "车辆检索" }, cam));
                    break;
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_CROWD:
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormCrowdReatime", Title = "实时大客流", Discription = "实时大客流" }, arg1.Task));
                    break;
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_BRIEF:
                    FormPlayBriefNew f = new FormPlayBriefNew(arg1.Task);
                    f.ShowDialog();
                    break;
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT:
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormTrafficEventAlarm", Title = "交通事件", Discription = "交通事件" }, arg1.Task));
                    break;
                case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT_SEARCH:
                    break;
                default:
                    break;
            }
        }

        void uctask_TaskDeleteClick(object sender, EventArgs e)
        {
            ucSingleRealtimeTask uctask = sender as ucSingleRealtimeTask;
            if (uctask != null)
            {
                m_viewModel.DeleteTask(uctask.Task.TaskId);
                uctask.Init(new TaskInfoV3_1() { TaskId = 0, AlgthmType = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE, StartTime = new DateTime(), TaskName = "加载中...", Status = E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE }, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
            }
        }




        private void ShowSingleTask()
        {
            m_currentShownTask = new FormSingleRealtimeTask(m_currentTask.Task, 0);
            m_currentShownTask.WindowState = FormWindowState.Normal;
            m_currentShownTask.StartPosition = FormStartPosition.CenterParent;
            if (m_currentShownTask.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
            m_currentShownTask = null;
        }

        #endregion

        #region FormBase
        public override void UpdateUI()
        {
            BuildTaskList();
        }

        public override void Clear()
        {
            MyLog4Net.Container.Instance.Log.Debug("FormRealtimeTaskManagement Clear enter");

            isClosed = true;

            m_viewModel.UpdateTaskProgress -= new Action<int, uint, IVX.DataModel.E_VDA_TASK_STATUS, uint>(m_viewModel_UpdateTaskProgress);
            m_viewModel.TaskAdded -= m_viewModel_TaskChanged;
            m_viewModel.TaskDeleted -= m_viewModel_TaskChanged;
            m_viewModel.TaskModified -= m_viewModel_TaskChanged;

            int i = 0;
            for ( i = 0; i < 200; i++)
            {
                System.Threading.Thread.Sleep(100); Application.DoEvents();
                if (m_thGetTaskProgress.ThreadState == System.Threading.ThreadState.Stopped)
                    break;
            }
            MyLog4Net.Container.Instance.Log.Debug("FormRealtimeTaskManagement Clear exit i:" + i);


        }

        #endregion

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            var list = m_viewModel.NextPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }

        }

        private List<Control> CreateFilterControl()
        {
            List<Control> clist = new List<Control>();

            foreach (E_VDA_TASK_STATUS item in Enum.GetValues(typeof(E_VDA_TASK_STATUS)))
            {
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_BEEN_DELETE)
                    continue;
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING)
                    continue;
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)
                    continue;
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_WAIT)
                    continue;
                DevComponents.DotNetBar.Controls.CheckBoxX c = new DevComponents.DotNetBar.Controls.CheckBoxX();
                c.Text = DataModel.Constant.TaskStatusInfos.Single(it => it.Status == item).Name;
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE)
                {
                    c.Text = "全部";
                    c.Checked = true;
                }
                c.AutoSize = true;
                c.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
                c.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                c.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                c.CheckedChanged += checkBoxStatus_CheckedChanged;
                c.Tag = item;
                clist.Add(c);
            }
            return clist;
        }

        void uctask_Click(object sender, EventArgs e)
        {
            ucSingleRealtimeTask uctask = sender as ucSingleRealtimeTask;
            m_currentTask = uctask;
            ShowSingleTask();

        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            var list = m_viewModel.PrivPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            MaxTaskCountPerPage = CalcMaxTaskCountPerPage();
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                item.Width = flowLayoutPanel1.Width - 30;
            }
            if (m_viewModel != null && m_viewModel.CountPerPage != MaxTaskCountPerPage)
            {
                m_viewModel.CountPerPage = MaxTaskCountPerPage;
                var list = m_viewModel.FrashPage();
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                    }
                    //m_viewModel.FrashProgress();
                    for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                    {
                        m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                    }
                    PageNavigatorChanged();
                }
            }

        }

        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            //TaskShowStatus s = TaskShowStatus.None;
            //if (checkBoxAnalyse.Checked)
            //    s = TaskShowStatus.Analyse | s;
            //if(checkBoxFailed.Checked)
            //    s = TaskShowStatus.Failed | s;
            DevComponents.DotNetBar.Controls.CheckBoxX c = sender as DevComponents.DotNetBar.Controls.CheckBoxX;
            if (c != null && c.Checked)
            {
                if (m_viewModel != null)
                {
                    m_viewModel.CurrentPageIndex = 1;
                    m_viewModel.TaskShowStatus = (E_VDA_TASK_STATUS)c.Tag;
                    var list = m_viewModel.FrashPage();
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                        }
                        //m_viewModel.FrashProgress();
                        for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                        {
                            m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                        }
                        PageNavigatorChanged();
                    }
                }

            }
        }

        private void pageNavigatorEx1_FirstClick(object sender, EventArgs e)
        {
            var list = m_viewModel.FirstPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }

        private void pageNavigatorEx1_LastClick(object sender, EventArgs e)
        {
            var list = m_viewModel.LastPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }

        private void pageNavigatorEx1_NextClick(object sender, EventArgs e)
        {
            var list = m_viewModel.NextPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }

        private void pageNavigatorEx1_PrivClick(object sender, EventArgs e)
        {
            var list = m_viewModel.PrivPage();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
                }
                //m_viewModel.FrashProgress();
                for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
                {
                    m_viewModel_UpdateTaskProgress(i, 0, E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
                }
                PageNavigatorChanged();
            }
        }



    }
}
