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
    public partial class FormTaskManagementMA : IVX.Live.MainForm.UILogics.FormBase
    {
        #region 私有变量
        List<string> OpenedList = new List<string>();
        FormSingleTask m_currentShownTask = null;
        TaskManagementMAViewModel m_viewModel = null;
        private bool isClosed = false;
        private System.Threading.Thread m_thGetTaskProgress;
        #endregion
        #region 属性

        #endregion
        #region 构造
        public FormTaskManagementMA()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }
        #endregion

        #region 事件响应
        private void FormTaskManagement_Load(object sender, EventArgs e)
        {
            //List<Control> clist = CreateFilterControl();
            //flowLayoutPanel2.Controls.AddRange(clist.ToArray());

            if (DesignMode)
                return;

            m_viewModel = new TaskManagementMAViewModel();
            m_viewModel.UpLoadLocalFile += new Action<uint, string, string, uint, ulong>(m_viewModel_UpLoadLocalFile);
            m_viewModel.TaskAdded +=m_viewModel_TaskAdded;
            m_viewModel.TaskDeleted+=m_viewModel_TaskDeleted;
            m_viewModel.TaskModified += m_viewModel_TaskModified;

            axfileupload1.Init();

            m_thGetTaskProgress = new System.Threading.Thread(thGetTaskProgress);
            m_thGetTaskProgress.Start();
            //BuildTaskList();
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
                    if(node!=null)
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
                    MyLog4Net.Container.Instance.Log.Error("m_viewModel_UpdateTask" + ex);

                    return;
                }

            }
        }

        void m_viewModel_TaskDeleted(TaskInfoV3_1 obj)
        {                                
            if (isClosed)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<TaskInfoV3_1>(m_viewModel_TaskDeleted), obj);
            }
            else
            {

                DevComponents.AdvTree.Node node = null;
                foreach (DevComponents.AdvTree.Node item in advTree1.Nodes)
                {
                    if (item.Text == obj.TaskId.ToString())
                    { node = item; break; }
                }
                if (node != null)
                {
                    advTree1.Nodes.Remove(node);
                }
                PageNavigatorChanged();
            }
        }

        void m_viewModel_TaskAdded(TaskInfoV3_1 obj)
        {
            if (isClosed)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<TaskInfoV3_1>(m_viewModel_TaskAdded), obj);
            }
            else
            {

                DevComponents.AdvTree.Node n = AddTaskTreeNode(obj);
                advTree1.Nodes.Add(n);
                PageNavigatorChanged();
            }
        }

        private DevComponents.AdvTree.Node AddTaskTreeNode(TaskInfoV3_1 item)
        {

            DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node(item.TaskId.ToString());
            DevComponents.AdvTree.Cell c = new DevComponents.AdvTree.Cell();
            //c.Images.Image = global::IVX.Live.MainForm.Properties.Resources.bkjpg;
            c.Images.ImageIndex = 0;

            c.Text = item.TaskName;
            uint totalprogress = 0;
            uint totalstatus = 0;
            string totalalaysetype = "";
            uint totaltime = 0;
            foreach (var s in item.StatusList)
            {
                if (s.AlgthmType != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                {
                    DevComponents.AdvTree.Node sn = new DevComponents.AdvTree.Node();
                    sn.Cells.Add(new DevComponents.AdvTree.Cell());
                    sn.Cells.Add(new DevComponents.AdvTree.Cell());

                    int progress = m_viewModel.CalcProgress(s.Status, (int)s.Progress,false);
                    DevComponents.DotNetBar.ProgressBarItem sprogressBarItem = new DevComponents.DotNetBar.ProgressBarItem();
                    sprogressBarItem.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    sprogressBarItem.ChunkGradientAngle = 0F;
                    sprogressBarItem.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
                    sprogressBarItem.RecentlyUsed = false;
                    sprogressBarItem.Maximum = 1000;
                    sprogressBarItem.TextVisible = true;
                    sprogressBarItem.Value = progress;
                    if (sprogressBarItem.Value < sprogressBarItem.Maximum)
                        sprogressBarItem.Text = (item.Order > 0||s.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED) ? "" : string.Format("剩余时间:{0}", TimeSpan.FromSeconds(s.LeftTime));
                    else
                        sprogressBarItem.Text = "";
                    DevComponents.AdvTree.Cell sc2 = new DevComponents.AdvTree.Cell();
                    sc2.HostedItem = sprogressBarItem;

                    sn.Cells.Add(sc2);
                    string status = DataModel.Constant.TaskStatusInfos.Single(it => it.Status == s.Status).Name;
                    if(s.Status ==  E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH)
                        status = "<font color=\"#5555ff\" >"+status+"</font>";
                    if(s.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED)
                        status = "<font color=\"#ff0000\" >"+status+"</font>";
                    sn.Cells.Add(new DevComponents.AdvTree.Cell(status));
                    sn.Cells.Add(new DevComponents.AdvTree.Cell(DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == s.AlgthmType).Name));

                    //DevComponents.DotNetBar.ButtonItem sbuttonItem = new DevComponents.DotNetBar.ButtonItem();
                    //sbuttonItem.Text = "删除";
                    //sbuttonItem.Click += buttonItem_Click;
                    //sbuttonItem.Tag = new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(item.TaskId, s.AlgthmType);
                    DevComponents.AdvTree.Cell sc1 = new DevComponents.AdvTree.Cell();
                    //sc1.HostedItem = sbuttonItem;
                    sc1.Text = m_viewModel.GetActionURL(s.Status, s.AlgthmType, item.TaskType);// +"<a href=\"del\">删除算法</a>";
                    sn.Cells.Add(sc1);
                    DevComponents.DotNetBar.ButtonItem sbuttonItem2 = new DevComponents.DotNetBar.ButtonItem();
                    sbuttonItem2.Text = "";
                    sbuttonItem2.Click += buttonItem_Click;
                    //sbuttonItem2.Image = Properties.Resources.remove_analyse_24;
                    sbuttonItem2.Symbol = "";//"/uf056";
                    sbuttonItem2.Tooltip = "删除算法";
                    //buttonItem.Tag = new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(item.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE);
                    DevComponents.AdvTree.Cell sc3 = new DevComponents.AdvTree.Cell();
                    sc3.HostedItem = sbuttonItem2;
                    sn.Cells.Add(sc3);
                    sn.Tag = new Tuple<uint, StatusInfoV3_1>(item.TaskId, s);
                    n.Nodes.Add(sn);
                }
                totalprogress += (uint)m_viewModel.CalcProgress(s.Status, (int)s.Progress);
                if (totalstatus == 0)
                    totalstatus = (uint)s.Status;
                else
                {
                    if (totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT
                        || s.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT)
                    {
                        if (totalstatus + (uint)s.Status == 10)
                            totalstatus = 5;
                        else if (totalstatus + (uint)s.Status == 11)
                            totalstatus = 6;
                        else if (totalstatus + (uint)s.Status == 12)
                            totalstatus = 5;
                        else if (totalstatus + (uint)s.Status == 13)
                            totalstatus = 5;
                        else
                            if(s.Status>0) totalstatus = Math.Min(totalstatus, (uint)s.Status);

                    }
                    else if (totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED
                    || s.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED)
                    {
                        if (totalstatus + (uint)s.Status >= 15)
                            totalstatus = 8;
                        else
                            if (s.Status > 0) totalstatus = Math.Min(totalstatus, (uint)s.Status);

                    }
                    else
                        if (s.Status > 0) totalstatus = Math.Min(totalstatus, (uint)s.Status);
                    
                }
                totalalaysetype += DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == s.AlgthmType).Name+" ";
                totaltime = Math.Max(totaltime, s.LeftTime);
            }

            if (item.StatusList.Count > 0)
                totalprogress /= (uint)item.StatusList.Count;
            else
            {
                totalprogress = 1000;
                totalstatus = (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH;
            }
            n.Cells.Add(c);
            n.Cells.Add(new DevComponents.AdvTree.Cell(item.StartTime.ToString()));

            DevComponents.DotNetBar.ProgressBarItem progressBarItem = new DevComponents.DotNetBar.ProgressBarItem();
            progressBarItem.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            progressBarItem.ChunkGradientAngle = 0F;
            progressBarItem.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            progressBarItem.RecentlyUsed = false;
            progressBarItem.Maximum = 1000;
            progressBarItem.TextVisible = true;
            progressBarItem.Value = (int)totalprogress;
            if (totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED || totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)
            {
                progressBarItem.Text = "";

            }
            else
            {
                if (progressBarItem.Value < progressBarItem.Maximum )
                    progressBarItem.Text = (item.Order > 0) ? string.Format("等待排序号:{0}", item.Order) : string.Format("剩余时间:{0}", TimeSpan.FromSeconds(totaltime));
                else
                    progressBarItem.Text = "";
            }
            DevComponents.AdvTree.Cell c2 = new DevComponents.AdvTree.Cell();
            c2.HostedItem = progressBarItem;

            n.Cells.Add(c2);
            string statusstr = DataModel.Constant.TaskStatusInfos.Single(it => it.NStatus == totalstatus).Name;
            if (totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH)
                statusstr = "<font color=\"#5555ff\" ><b>" + statusstr + "</b></font>";
            if (totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED || totalstatus == (uint)E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)
                statusstr = "<font color=\"#ff0000\" ><b>" + statusstr + "</b></font>";
            DevComponents.AdvTree.Cell cellstatus = new DevComponents.AdvTree.Cell(statusstr);
            cellstatus.TagString = DataModel.Constant.TaskStatusInfos.Single(it => it.NStatus == totalstatus).Name;
            n.Cells.Add(cellstatus);
            n.Cells.Add(new DevComponents.AdvTree.Cell(totalalaysetype.Trim()));
            DevComponents.AdvTree.Cell c1 = new DevComponents.AdvTree.Cell();
            string url = "<a href=\"E_TASK_ACTION_TYPE_INFO\">查看信息</a> ";
            if ((E_VDA_TASK_STATUS)totalstatus >= E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT)
                url += "<a href=\"E_TASK_ACTION_TYPE_PLAYBACK\">视频回放</a> ";
            //url += "<a href=\"E_TASK_ACTION_TYPE_DELETE\">删除任务</a>";
            c1.Text = url;
            n.Cells.Add(c1);

            DevComponents.DotNetBar.ButtonItem buttonItem = new DevComponents.DotNetBar.ButtonItem();
            buttonItem.Text = "";
            buttonItem.Click += buttonItem_Click;
            //buttonItem.Image = Properties.Resources._305_Close_24x24_72;
            buttonItem.Symbol = "";// "/uf014";
            buttonItem.Tooltip = "删除任务";
            //buttonItem.Tag = new Tuple<uint, E_VIDEO_ANALYZE_TYPE>(item.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE);
            DevComponents.AdvTree.Cell c3 = new DevComponents.AdvTree.Cell();
            c3.HostedItem = buttonItem;
            n.Cells.Add(c3);
            n.Tag = item;
            return n;
        }

        void buttonItem_Click(object sender, EventArgs e)
        {
            buttonDelItem_Click();
        }


        //void m_viewModel_TaskChanged(TaskInfoV3_1 obj)
        //{
        //    var list = m_viewModel.FrashPage();
        //    if (list != null)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            m_viewModel_UpdateTaskProgress(i, list[i].TaskId, list[i].Status, list[i].Progress);
        //        }
        //        //m_viewModel.FrashProgress();
        //        for (int i = list.Count; i < m_maxTaskCountPerPage; i++)
        //        {
        //            m_viewModel_UpdateTaskProgress(i, 0,  E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, 0);
        //        }
        //        PageNavigatorChanged();
        //    }
        //}



        private List<Control> CreateFilterControl()
        {
            List<Control> clist = new List<Control>();

            foreach (E_VDA_TASK_STATUS item in Enum.GetValues(typeof(E_VDA_TASK_STATUS)))
            {
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_BEEN_DELETE)
                    continue;
                if (item == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND)
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



        void m_viewModel_UpLoadLocalFile(uint arg1, string arg2, string arg3, uint arg4, ulong arg5)
        {
            MyLog4Net.Container.Instance.Log.Debug("FormTaskManagementNew m_viewModel_UpLoadLocalFile");

            if (isClosed)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<uint,string,string, uint, ulong>(m_viewModel_UpLoadLocalFile), arg1, arg2, arg3,arg4,arg5);
            }
            else
            {
                MyLog4Net.Container.Instance.Log.DebugFormat("axfileupload1.AddTask {0},{1},{2}", arg1, arg2, string.Format("http://{0}:{1}", arg3, arg4));

                bool i = axfileupload1.AddTask(arg1,arg2,string.Format("http://{0}:{1}",arg3,arg4));

            }
        }



        private void FormTaskManagement_MdiChildActivate(object sender, EventArgs e)
        {
            BuildTaskList(m_viewModel.GetAllTask());
        }

        private void FormTaskManagement_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonAddLocalTask_Click(object sender, EventArgs e)
        {
            FormAddLocalTask f = new FormAddLocalTask();
            f.WindowState = FormWindowState.Normal;
            //f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog();
        }

        private void buttonAddFtpTask_Click(object sender, EventArgs e)
        {
            FormAddFtpTask f = new FormAddFtpTask();
            f.WindowState = FormWindowState.Normal;
            //f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void buttonShowMap_Click(object sender, EventArgs e)
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu,object>(new SystemMenu { URL = "FormGisMap", Title = "电子地图", Discription = "地图选点添加" },null));
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
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<TaskInfoV3_1>>(BuildTaskList), list);
            }
            else
            {
                if (list != null)
                {
                    MyLog4Net.Container.Instance.Log.Debug("BuildTaskList enter");
                    advTree1.SuspendLayout();
                    foreach (var item in list)
                    {
                        DevComponents.AdvTree.Node n = AddTaskTreeNode(item);
                        advTree1.Nodes.Add(n);
                    }
                    advTree1.ResumeLayout();
                    PageNavigatorChanged();
                    MyLog4Net.Container.Instance.Log.Debug("BuildTaskList leave");
                }
            }
        }

        void buttonDelItem_Click()
        {
            E_VIDEO_ANALYZE_TYPE t = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
            uint id = 0;
            if (advTree1.SelectedNode.Tag is Tuple<uint, StatusInfoV3_1>)
            {
                id = (advTree1.SelectedNode.Tag as Tuple<uint, StatusInfoV3_1>).Item1;
                t = (advTree1.SelectedNode.Tag as Tuple<uint, StatusInfoV3_1>).Item2.AlgthmType;
            }
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {  
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
            }
            if (id != 0)
            {
                string str = "["+id+"]"+ m_viewModel.GetTaskInfo(id).ToString();
                string msg = "是否要删除任务:" + str + (t == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE ? " ？" : " 的 " + DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == t) + " 算法？");
                if (DevComponents.DotNetBar.MessageBoxEx.Show(msg, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                     == System.Windows.Forms.DialogResult.Yes)
                {
                    if (t == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                        m_viewModel.DeleteTask(id);
                    else
                        m_viewModel.DeleteTaskAnalyseType(id, t);

                }
            }
        }


        void uctask_ReImport(object sender, EventArgs e)
        {
            ucSingleHistoryTask uctask = sender as ucSingleHistoryTask;
            //m_currentTask = uctask;

            m_viewModel.ReImport(uctask.Task);
        }

        void buttonTaskPlay_Click()
        {           
            uint id = 0;
            if (advTree1.SelectedNode.Tag is Tuple<uint, StatusInfoV3_1>)
            {
                id = (advTree1.SelectedNode.Tag as Tuple<uint, StatusInfoV3_1>).Item1;
            }
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {  
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
            }
            if (id != 0)
            {
                FormPlayHistoryNew f = new FormPlayHistoryNew(m_viewModel.GetTaskInfo(id));
                f.ShowDialog();
            }
        }


        void uctask_TaskDoAction(E_TASK_ACTION_TYPE arg2)
        {
            uint id = 0;
            if (advTree1.SelectedNode.Tag is Tuple<uint, StatusInfoV3_1>)
            {
                id = (advTree1.SelectedNode.Tag as Tuple<uint, StatusInfoV3_1>).Item1;
            }
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
            {
                id = (advTree1.SelectedNode.Tag as TaskInfoV3_1).TaskId;
            }
            if (id != 0)
            {
                var task = m_viewModel.GetTaskInfo(id);
                switch (arg2)
                {
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_NONE:
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_PEOPLE_SEARCH:
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormPeopleSearch", Title = "行人检索", Discription = "行人检索" }, task));
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_VEHICLE_SEARCH:
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormVehicleSearch", Title = "车辆检索", Discription = "车辆检索" }, task));
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_CROWD:
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_BRIEF:
                        FormPlayBriefNew f = new FormPlayBriefNew(task);
                        f.ShowDialog();
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT:
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_TRAFFIC_EVENT_SEARCH:
                        break;
                    case E_TASK_ACTION_TYPE.E_TASK_ACTION_TYPE_DYNMIC_VEHICLE_SEARCH:
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormVehicleSearch", Title = "车辆检索", Discription = "车辆检索" }, task));
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
                    default:
                        break;
                }
            }
        }





        private void ShowSingleTask()
        {
            TaskInfoV3_1 t =null;
            if (advTree1.SelectedNode.Tag is Tuple<uint, StatusInfoV3_1>)
                t = m_viewModel.GetTaskInfo((advTree1.SelectedNode.Tag as Tuple<uint, StatusInfoV3_1>).Item1);
            if (advTree1.SelectedNode.Tag is TaskInfoV3_1)
                t = advTree1.SelectedNode.Tag as TaskInfoV3_1;
            if (t != null)
            {
                m_currentShownTask = new FormSingleTask(t);
                m_currentShownTask.WindowState = FormWindowState.Normal;
                m_currentShownTask.StartPosition = FormStartPosition.CenterParent;
                if (m_currentShownTask.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
            m_currentShownTask = null;
        }

        #endregion

        #region FormBase
        public override void UpdateUI()
        {
            BuildTaskList(m_viewModel.GetAllTask());
        }

        public override void Clear()
        {
            MyLog4Net.Container.Instance.Log.Debug("FormTaskManagementNew Clear enter");

            isClosed = true;

            m_viewModel.UpLoadLocalFile -= new Action<uint, string, string, uint, ulong>(m_viewModel_UpLoadLocalFile);
            m_viewModel.TaskAdded -= m_viewModel_TaskAdded;
            m_viewModel.TaskDeleted -= m_viewModel_TaskDeleted;
            m_viewModel.TaskModified -= m_viewModel_TaskModified;
            m_viewModel.Clear();

            MyLog4Net.Container.Instance.Log.Debug("FormTaskManagementNew Clear ");

        }

        #endregion







        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Controls.CheckBoxX c = sender as DevComponents.DotNetBar.Controls.CheckBoxX;
            if (c != null && c.Checked)
            {
                foreach (DevComponents.AdvTree.Node item in advTree1.Nodes)
                {
                   var visible = (item.Cells[4].Text == DataModel.Constant.TaskStatusInfos.Single(it => it.Status == (E_VDA_TASK_STATUS)c.Tag).Name);
                   if((E_VDA_TASK_STATUS)c.Tag ==  E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE)
                       visible = true;
                   item.Visible = visible;
                } 

            }
        }


        private void advTree1_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
            E_TASK_ACTION_TYPE t = (E_TASK_ACTION_TYPE)Enum.Parse(typeof(E_TASK_ACTION_TYPE),e.HRef);

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
                string temp = item.Cells[1].Text+item.Cells[4].TagString+item.Cells[5].Text;
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
