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
    public partial class FormRealtimeTaskManagementMA : IVX.Live.MainForm.UILogics.FormBase
    {
        #region 私有变量
        FormSingleRealtimeTask m_currentShownTask = null;
        RealtimeTaskManagementMAViewModel m_viewModel = null;
        private bool isClosed = false;
        private System.Threading.Thread m_thGetTaskProgress;
        #endregion
        #region 属性

        #endregion
        #region 构造
        public FormRealtimeTaskManagementMA()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            
        }
        #endregion

        #region 事件响应
        private void FormRealtimeTaskManagement_Load(object sender, EventArgs e)
        {
            //List<Control> clist = CreateFilterControl();
            //flowLayoutPanel2.Controls.AddRange(clist.ToArray());

            if (DesignMode)
                return;

            m_viewModel = new RealtimeTaskManagementMAViewModel();
            m_viewModel.TaskAdded += m_viewModel_TaskAdded;
            m_viewModel.TaskDeleted += m_viewModel_TaskDeleted;
            m_viewModel.TaskModified += m_viewModel_TaskModified;

            m_thGetTaskProgress = new System.Threading.Thread(thGetTaskProgress);
            m_thGetTaskProgress.Start();
        }


        void m_viewModel_TaskModified(TaskInfoV3_1 obj)
        {
            if (isClosed)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<TaskInfoV3_1>(m_viewModel_TaskModified), obj);
            }
            else
            {
                try
                {
                    var node = advTree1.FindNodeByText(obj.TaskId.ToString());
                    if (node != null)
                    {
                        int index = node.Index;
                        var newnode = AddTaskTreeNode(obj);
                        newnode.Expanded = node.Expanded;
                        advTree1.Nodes.RemoveAt(index);
                        advTree1.Nodes.Insert(index, newnode);

                        if (m_currentShownTask != null && m_currentShownTask.Created && m_currentShownTask.TaskId == obj.TaskId)
                            m_currentShownTask.UpdateTask(obj);

                    }
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.Error("m_viewModel_UpdateTaskProgress" + ex);

                    return;
                }

            }
        }

        void m_viewModel_TaskDeleted(TaskInfoV3_1 obj)
        {
            var node = advTree1.FindNodeByText(obj.TaskId.ToString());
            if (node != null)
            {
                advTree1.Nodes.Remove(node);
            }
            PageNavigatorChanged();
        }

        void m_viewModel_TaskAdded(TaskInfoV3_1 item)
        {
            DevComponents.AdvTree.Node n = AddTaskTreeNode(item);
            advTree1.Nodes.Add(n);
            PageNavigatorChanged();
        }

        private DevComponents.AdvTree.Node AddTaskTreeNode(TaskInfoV3_1 item)
        {

            DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node(item.TaskId.ToString());
            DevComponents.AdvTree.Cell c = new DevComponents.AdvTree.Cell();
            //c.Images.Image = global::IVX.Live.MainForm.Properties.Resources.bkjpg;
            c.Images.ImageIndex = 0;

            c.Text = item.ToString();
            E_VDA_TASK_STATUS totalstatus = 0;
            E_VIDEO_ANALYZE_TYPE totalalaysetype = 0;
            foreach (var s in item.StatusList)
            {
                totalstatus = s.Status;
                totalalaysetype = s.AlgthmType;
            }

            n.Cells.Add(c);

            string anaurl = DataModel.Constant.TaskStatusInfos.Single(it => it.Status == totalstatus).Name;
            if (totalstatus == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING)
                anaurl += " <a href=\"E_TASK_ACTION_TYPE_SUNPEND\">暂停分析</a> ";

            if (totalstatus == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND)
                anaurl += " <a href=\"E_TASK_ACTION_TYPE_CONTINUE\">继续分析</a> ";

            if (totalstatus == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED || totalstatus == E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)
                anaurl = "<font color=\"#ff0000\" ><b>" + anaurl + "</b></font>";

            DevComponents.AdvTree.Cell cellana = new DevComponents.AdvTree.Cell(anaurl);
            cellana.TagString = DataModel.Constant.TaskStatusInfos.Single(it => it.Status == totalstatus).Name;
            n.Cells.Add(cellana);
            n.Cells.Add(new DevComponents.AdvTree.Cell(DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == totalalaysetype).Name));


            DevComponents.AdvTree.Cell c1 = new DevComponents.AdvTree.Cell();
            string url = "<a href=\"E_TASK_ACTION_TYPE_INFO\">查看信息</a> ";
            if ((E_VDA_TASK_STATUS)totalstatus >= E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT)
                url += "<a href=\"E_TASK_ACTION_TYPE_PLAYBACK\">视频播放</a> ";
            url += m_viewModel.GetActionURL(totalstatus, totalalaysetype, item.TaskType);
            //url += "<a href=\"E_TASK_ACTION_TYPE_DELETE\">删除任务</a>";
            c1.Text = url;
            n.Cells.Add(c1);

            DevComponents.DotNetBar.ButtonItem sbuttonItem = new DevComponents.DotNetBar.ButtonItem();
            sbuttonItem.Text = "";// "删除任务";
            sbuttonItem.Click += sbuttonItem_Click;
            //sbuttonItem.Image = Properties.Resources._305_Close_24x24_72;
            sbuttonItem.Symbol = "";// "/uf014";
            sbuttonItem.Tooltip = "删除任务";
            //sbuttonItem.Tag = new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(item.TaskId, totalalaysetype);

            DevComponents.AdvTree.Cell c2 = new DevComponents.AdvTree.Cell();
            c2.HostedItem = sbuttonItem;
            n.Cells.Add(c2);
            n.Tag = item;
            return n;
        }

        void sbuttonItem_Click(object sender, EventArgs e)
        {
            buttonDelItem_Click();
        }


        private void FormTaskManagement_MdiChildActivate(object sender, EventArgs e)
        {
            BuildTaskList(m_viewModel.GetAllTask());
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
                var list = m_viewModel.GetAllTask();
                if (list != null)
                {
                    BuildTaskList(list);
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
                labelCountInfo.Text = string.Format("总记录数 {0} 条", m_viewModel.TotalCount);

            }
        }


        private void BuildTaskList(List<TaskInfoV3_1> list)
        {
            if (list != null)
            {
                List<DevComponents.AdvTree.Node> ns = new List<DevComponents.AdvTree.Node>();
                foreach (var item in list)
                {
                    DevComponents.AdvTree.Node n = AddTaskTreeNode(item);
                    ns.Add(n);
                }
                advTree1.SuspendLayout();
                advTree1.Nodes.AddRange(ns.ToArray());
                advTree1.ResumeLayout();
                PageNavigatorChanged();
            }
        }

        void buttonTaskPlay_Click()
        {
            uint id = 0;
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {  
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
            }
            if (id != 0)
            {
                FormPlayRealtime f = new FormPlayRealtime(m_viewModel.GetTaskInfo(id));
                f.ShowDialog();
            }
        }

        void buttonTaskPauseResume_Click()
        {
            uint id = 0;
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
            }
            if (id != 0)
            {
                m_viewModel.PauseOrResumeTask(id);
                    
            }
        }
        void uctask_TaskDoAction(E_TASK_ACTION_TYPE arg2)
        {            uint id = 0;
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
            }
            if (id != 0)
            {
                var task = m_viewModel.GetTaskInfo(id);

                var cam = m_viewModel.GetCameraInfo(task.CameraID);

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
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormCrowdReatime", Title = "实时大客流", Discription = "实时大客流" }, task));
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_BRIEF:
                        FormPlayBriefNew f = new FormPlayBriefNew(task);
                        f.ShowDialog();
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT:
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormTrafficEventAlarm", Title = "交通事件", Discription = "交通事件" }, task));
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT_SEARCH:
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_INFO:
                        ShowSingleTask();
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_PLAYBACK:
                        buttonTaskPlay_Click();
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_DELETE:
                        buttonDelItem_Click();
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_SUNPEND:
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_CONTINUE:
                        buttonTaskPauseResume_Click();
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_DYNMIC_FACE_ALARM:
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormFaceAlarm", Title = "人脸报警", Discription = "人脸报警" }, task));
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_DYNMIC_FACE_CONTROL:
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormFaceAlarmControl", Title = "人脸布控", Discription = "人脸布控" }, task));
                        break;
                    default:
                        break;
                }
            }
        }

        void buttonDelItem_Click()
        {
            uint id = 0;
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
                if (id != 0)
                {
                    string str = "[" + id + "]" + m_viewModel.GetTaskInfo(id).ToString();
                    string msg = "是否要删除任务:" + str + " ？" ;
                    if (DevComponents.DotNetBar.MessageBoxEx.Show(msg, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                         == System.Windows.Forms.DialogResult.Yes)
                    {
                            m_viewModel.DeleteTask(id);

                    }
                }
            }
        }




        private void ShowSingleTask()
        {            
            TaskInfoV3_1 t =null;
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
                t = advTree1.SelectedNode.Tag as TaskInfoV3_1;
            if (t != null)
            {

                m_currentShownTask = new FormSingleRealtimeTask(t);
                m_currentShownTask.WindowState = FormWindowState.Normal;
                m_currentShownTask.StartPosition = FormStartPosition.CenterParent;
                if (m_currentShownTask.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
                m_currentShownTask = null;
            }
        }

        #endregion

        #region FormBase
        public override void UpdateUI()
        {
            BuildTaskList(m_viewModel.GetAllTask());
        }

        public override void Clear()
        {
            MyLog4Net.Container.Instance.Log.Debug("FormRealtimeTaskManagement Clear enter");

            isClosed = true;

            m_viewModel.TaskAdded -= m_viewModel_TaskAdded;
            m_viewModel.TaskDeleted -= m_viewModel_TaskDeleted;
            m_viewModel.TaskModified -= m_viewModel_TaskModified;

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



        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Controls.CheckBoxX c = sender as DevComponents.DotNetBar.Controls.CheckBoxX;
            if (c != null && c.Checked)
            {
                foreach (DevComponents.AdvTree.Node item in advTree1.Nodes)
	            {
                    var visible = (item.Cells[4].Text == DataModel.Constant.TaskStatusInfos.Single(it => it.Status == (E_VDA_TASK_STATUS)c.Tag).Name);
                    if ((E_VDA_TASK_STATUS)c.Tag == E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE)
                        visible = true;
                    item.Visible = visible;
                } 
            }
        }

        private void advTree1_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
                E_TASK_ACTION_TYPE t = (E_TASK_ACTION_TYPE)Enum.Parse(typeof(E_TASK_ACTION_TYPE), e.HRef);

                uctask_TaskDoAction(t);
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            index = 0;
            Search(textBoxSearch.Text);
        }

        private void textBoxSearch_ButtonCustomClick(object sender, EventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        int index = 0;
        void Search(string text)
        {
            int tempindex = 0;
            int i = 0;
            for (i = 0; i < advTree1.Nodes.Count; i++)
            {
                DevComponents.AdvTree.Node item = advTree1.Nodes[i];
                string temp = item.Cells[1].Text + item.Cells[2].TagString + item.Cells[3].Text;
                temp = temp + string.Join("", WinFormAppUtil.Common.PinYinConverterHelp.GetTotalPingYin(temp).FirstPingYin);
                if (temp.Contains(text))
                {
                    if (tempindex >= index && item.Visible)
                    {
                        item.SetSelectedCell(item.Cells[0], DevComponents.AdvTree.eTreeAction.Mouse);
                        index++;
                        break;
                    }
                    else
                    {
                        tempindex++;
                    }
                }
            }
            if (i == advTree1.Nodes.Count)
            { index = 0; }
        }

    }
}
