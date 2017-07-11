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
    public partial class FormTaskManagement : IVX.Live.MainForm.UILogics.FormBase
    {
        #region 私有变量
        List<string> OpenedList = new List<string>();
        List<ucTaskInfo> ShownTaskList = new List<ucTaskInfo>();
        FormSingleTask m_currentShownTask = null;
        ucTaskInfo m_currentTask;
        TaskManagementViewModel m_viewModel = null;
        bool m_isInited = false;
        #endregion

        #region 构造
        public FormTaskManagement()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }
        #endregion

        #region 事件响应
        private void FormTaskManagement_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new TaskManagementViewModel();
            m_viewModel.UpdateTaskProgress += new Action<uint, IVX.DataModel.E_VDA_TASK_STATUS, uint>(m_viewModel_UpdateTaskProgress);
            m_viewModel.UpLoadLocalFile += new Action<uint, string, string, uint, ulong>(m_viewModel_UpLoadLocalFile);
            m_viewModel.TaskDeleted += new Action<DataModel.TaskInfoV3_1>(m_viewModel_TaskDeleted);
            m_viewModel.TaskAdded += new Action<DataModel.TaskInfoV3_1>(m_viewModel_TaskAdded);

            axfileupload1.SetMaxAbility((int)Framework.Environment.UploadAbility);
            BuildTaskList();
            m_isInited = true;
            new System.Threading.Thread(thGetTaskProgress).Start();
        }

        void m_viewModel_TaskAdded(DataModel.TaskInfoV3_1 obj)
        {
            if (!m_isInited)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<DataModel.TaskInfoV3_1>(m_viewModel_TaskAdded), obj);
            }
            else
            {
                string key = m_viewModel.GetTaskTimeLineKeyValue(obj);

                if (itemPanel1.GetItem("NullValueLabel") != null)
                    itemPanel1.Items.Remove("NullValueLabel");

                DevComponents.DotNetBar.ItemContainer itemContainer
                    = itemPanel1.GetItem("itemContainer_" + key) as DevComponents.DotNetBar.ItemContainer;
                if (itemContainer == null)
                {
                    itemContainer = AddContainerItem(key, new TaskTimeLine() { TaskList = new List<DataModel.TaskInfoV3_1>() { obj }, Type = key });
                }
                DevComponents.DotNetBar.LabelItem labelItem
                    = itemPanel1.GetItem("labelItem_" + key) as DevComponents.DotNetBar.LabelItem;
                labelItem.Text = "<b>" + m_viewModel.GetTaskTimeLineByKey(key).ToString() + "</b>";
                var item = AddButtonItem(itemContainer, obj);
                if (OpenedList.Contains(key))
                    ShownTaskList.Add(item);
                itemPanel1.Refresh();
            }
        }

        void m_viewModel_TaskDeleted(DataModel.TaskInfoV3_1 obj)
        {
            if (!m_isInited)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<DataModel.TaskInfoV3_1>(m_viewModel_TaskDeleted), obj);
            }
            else
            {
                string key = m_viewModel.GetTaskTimeLineKeyValue(obj);
                DevComponents.DotNetBar.ItemContainer itemContainer
                        = itemPanel1.GetItem("itemContainer_" + key) as DevComponents.DotNetBar.ItemContainer;
                DevComponents.DotNetBar.LabelItem labelItem
                        = itemPanel1.GetItem("labelItem_" + key) as DevComponents.DotNetBar.LabelItem;
                labelItem.Text = "<b>" + m_viewModel.GetTaskTimeLineByKey(key).ToString() + "</b>";
               
                if (itemContainer.SubItems.Contains("buttonItemTask_" + obj.TaskId))
                {
                    var item = itemContainer.SubItems["buttonItemTask_" + obj.TaskId] as ucTaskInfo;
                    if (item != null && ShownTaskList.Contains(item))
                        ShownTaskList.Remove(item);
                    itemContainer.SubItems.Remove("buttonItemTask_" + obj.TaskId);
                itemPanel1.Refresh();
                }

            }
        }

        void m_viewModel_UpLoadLocalFile(uint arg1, string arg2, string arg3, uint arg4, ulong arg5)
        {
            if (!m_isInited)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<uint,string,string, uint, ulong>(m_viewModel_UpLoadLocalFile), arg1, arg2, arg3,arg4,arg5);
            }
            else
            {
                MyLog4Net.Container.Instance.Log.DebugFormat("axfileupload1.AddTask {0},{1},{2}", arg1, arg2, string.Format("http://{0}:{1}", arg3, arg4));
                uint i = axfileupload1.AddTask(arg1,arg2,string.Format("http://{0}:{1}",arg3,arg4));
                Console.WriteLine(i.ToString());
                ucTaskInfo taskinfo = null;
                try
                {
                    taskinfo = ShownTaskList.Single(item => item.Name == "buttonItemTask_" + arg1);
                }
                catch (Exception)
                {
                    //BuildTaskList();
                    return;
                }
                
                if (taskinfo != null)
                {
                    taskinfo.Progress = 0;
                    taskinfo.TaskStat = IVX.DataModel.E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING;
                    //m_localUploadProgress.Add(taskinfo.TaskId, 0);
                    //new System.Threading.Thread(thStartLocalUpload).Start(taskinfo.TaskId);
                }

            }
        }

        void m_viewModel_UpdateTaskProgress(uint arg1, IVX.DataModel.E_VDA_TASK_STATUS arg2, uint arg3)
        {
            if (!m_isInited)
                return;

            if (InvokeRequired)
            {
                this.Invoke(new Action<uint, IVX.DataModel.E_VDA_TASK_STATUS, uint>(m_viewModel_UpdateTaskProgress), arg1, arg2, arg3);
            }
            else
            {
                ucTaskInfo taskinfo = null;
                try
                {
                    taskinfo = ShownTaskList.Single(item => item.Name == "buttonItemTask_" + arg1);
                }
                catch (Exception)
                {
                    //BuildTaskList();
                    return;
                }
                if (taskinfo != null)
                {
                    taskinfo.Progress = (int)arg3;
                    taskinfo.TaskStat = arg2;
                    if (m_currentShownTask != null && m_currentShownTask.Created && m_currentShownTask.TaskId == arg1)
                        m_currentShownTask.UpdateProgress(arg2, (int)arg3);
                }
                //if (taskinfo.TaskStat >= (uint)IVX.DataModel.E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)
                //{
                //    if (m_localUploadProgress.ContainsKey(arg1))
                //        m_localUploadProgress.Remove(arg1);
                //}
                //if (m_localUploadProgress.ContainsKey(arg1))
                //    m_localUploadProgress[arg1] =Math.Max(m_localUploadProgress[arg1] , arg3);

            }
        }

        private void FormTaskManagement_MdiChildActivate(object sender, EventArgs e)
        {
            BuildTaskList();
        }

        private void FormTaskManagement_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (m_currentTask != null)
            {
                m_viewModel.DeleteTask(m_currentTask.TaskId);

                DevComponents.DotNetBar.ItemContainer itemContainer
                    = m_currentTask.Parent as DevComponents.DotNetBar.ItemContainer;
                itemContainer.SubItems.Remove(m_currentTask);
                m_currentTask = null;
                m_viewModel.GetTaskProgress();
                itemPanel1.Refresh();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (m_currentTask == null)
                return;

            ShowSingleTask();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            FormAddLocalTask f = new FormAddLocalTask();
            f.WindowState = FormWindowState.Normal;
            //f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormAddFtpTask f = new FormAddFtpTask();
            f.WindowState = FormWindowState.Normal;
            //f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(UIFuncItemInfo.GISMAP);
        }

        #endregion

        #region 私有函数
        //private void thStartLocalUpload(object id)
        //{
        //    uint taskid = (uint)id;
        //    uint progress = 0;
        //    uint stat = (uint)IVX.DataModel.E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING;
        //    while(true)
        //    {
        //        System.Threading.Thread.Sleep(1000);
        //        if (m_localUploadProgress.ContainsKey(taskid))
        //            progress = m_localUploadProgress[taskid];
        //        else
        //            break;

        //        if(progress<250 && progress>=0)
        //        {
        //            progress = Math.Min(240, progress + 100);
        //        }
        //        else if (progress >= 250 && progress < 500)
        //        { 
        //            progress = Math.Min(490, progress + 100);
        //        }
        //        else if (progress >= 500 && progress < 750)
        //        {
        //            progress = Math.Min(740, progress + 100);
        //        }
        //        else
        //        { 
        //            progress = Math.Min(990, progress + 100);
        //        }
        //        m_viewModel_UpdateTaskProgress(taskid,stat , progress);
        //    }
        //}

        private void thGetTaskProgress()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("GetTaskProgress enter---!!");

            System.Threading.Thread.Sleep(2 * 1000);
            while (m_isInited)
            {
                MyLog4Net.Container.Instance.Log.DebugFormat("GetTaskProgress before");
                m_viewModel.GetTaskProgress();
                MyLog4Net.Container.Instance.Log.DebugFormat("GetTaskProgress after");
                for (int i = 0; i < 4; i++)
                {
                    MyLog4Net.Container.Instance.Log.DebugFormat("GetTaskProgress before Sleep");
                    System.Threading.Thread.Sleep(1000);
                    MyLog4Net.Container.Instance.Log.DebugFormat("GetTaskProgress after Sleep");
                    if (!m_isInited)
                    {
                        MyLog4Net.Container.Instance.Log.DebugFormat("GetTaskProgress break---!!");
                        break;
                    }
                }

            }
        }

        private void BuildTaskList()
        {
            MyLog4Net.Container.Instance.Log.Debug("BuildTaskList");

            string firstLabelItem = "";
            var timelinelist= m_viewModel.GetTaskTimeLine();
            itemPanel1.Visible = false; ;
            itemPanel1.Items.Clear();
            ShownTaskList.Clear();
            foreach (var item in timelinelist)
            {
                if(string.IsNullOrEmpty(firstLabelItem))
                    firstLabelItem = "labelItem_" + item.Key.ToString(); ;
                AddContainerItem(item.Key,item.Value);
                
            }

            if (timelinelist.Count == 0)
            {
                DevComponents.DotNetBar.LabelItem labelItem = new DevComponents.DotNetBar.LabelItem();
                labelItem.Name = "NullValueLabel";
                labelItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
                labelItem.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
                labelItem.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
                labelItem.PaddingBottom = 1;
                labelItem.PaddingLeft = 1;
                labelItem.PaddingRight = 1;
                labelItem.PaddingTop = 1;
                labelItem.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
                labelItem.Text = "<b>没有任务，请通过本地导入，HTTP/FTP导入或平台导入等方式添加文件</b>";
                labelItem.TextAlignment = StringAlignment.Center;
                labelItem.Font = new System.Drawing.Font("微软雅黑", 20);
                itemPanel1.Items.Add(labelItem);

            }


            itemPanel1.Visible = true; ;

            MyLog4Net.Container.Instance.Log.Debug("BuildTaskList ret");
            if (OpenedList.Count == 0 && !string.IsNullOrEmpty( firstLabelItem))
                OpenedList.Add(firstLabelItem);
            foreach (var item in OpenedList)
            {
                DevComponents.DotNetBar.LabelItem labelitem
                = itemPanel1.GetItem(item) as DevComponents.DotNetBar.LabelItem;
                if (labelitem != null)
                    OpenContent(labelitem);
            }
        }

        private DevComponents.DotNetBar.ItemContainer AddContainerItem(string key, TaskTimeLine item)
        {

            MyLog4Net.Container.Instance.Log.Debug("GetTaskTimeLine item:" + key);
            DevComponents.DotNetBar.LabelItem labelItem = new DevComponents.DotNetBar.LabelItem();
            DevComponents.DotNetBar.ItemContainer itemContainer = new DevComponents.DotNetBar.ItemContainer();
            labelItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            labelItem.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            labelItem.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            labelItem.Name = "labelItem_" + key;
            labelItem.PaddingBottom = 1;
            labelItem.PaddingLeft = 1;
            labelItem.PaddingRight = 1;
            labelItem.PaddingTop = 1;
            labelItem.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            labelItem.Text = "<b>" + item.ToString() + "</b>";
            labelItem.Symbol = "\uf054"; //"\uf078"
            labelItem.Click += new EventHandler(labelItem_Click);
            labelItem.Tag = key;
            itemContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer.MultiLine = true;
            itemContainer.Name = "itemContainer_" + key;

            //foreach (IVX.DataModel.TaskInfoV3_1 info in item.Value.TaskList)
            //{
            //    MyLog4Net.Container.Instance.Log.Debug("item.Value.TaskList item id:" + info.TaskId);

            //    ucTaskInfo buttonItem = new ucTaskInfo();
            //    buttonItem.Name = "buttonItemTask_" + info.TaskId;
            //    buttonItem.Text = "<b>" + info.TaskName + "</b>";

            //    buttonItem.Tooltip = "<b>["+info.TaskId+"]" + info.TaskName + "</b>"+Environment.NewLine + info.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            //    //if (itemContainer.SubItems.Count<100)
            //    //itemContainer.SubItems.Add(buttonItem);
            //    //else if (itemContainer.SubItems.Count == 100)
            //    //{
            //    //    ucTaskInfo buttonItemt = new ucTaskInfo();
            //    //    buttonItemt.Name = "buttonItemTask_" + item.Key.ToString();
            //    //    buttonItemt.Text = "<b>获取更多内容...</b>";

            //    //    itemContainer.SubItems.Add(buttonItemt);
            //    //}


            //    itemContainer.SubItems.Add(buttonItem);

            //}
            itemPanel1.Items.Add(labelItem);
            itemPanel1.Items.Add(itemContainer);
            return itemContainer;
        }

        private ucTaskInfo AddButtonItem(DevComponents.DotNetBar.ItemContainer itemContainer, IVX.DataModel.TaskInfoV3_1 info)
        {                
            if(itemContainer.SubItems.Contains("buttonItemTask_" + info.TaskId))
                return (ucTaskInfo)itemContainer.SubItems["buttonItemTask_" + info.TaskId];

            MyLog4Net.Container.Instance.Log.Debug("item.Value.TaskList item id:" + info.TaskId);

            ucTaskInfo buttonItem = new ucTaskInfo();
            buttonItem.Name = "buttonItemTask_" + info.TaskId;
            buttonItem.Text = info.TaskName;
            buttonItem.Progress = 0;
            buttonItem.TaskId = info.TaskId;
            buttonItem.TaskStat = info.Status;
            if (info.Status == IVX.DataModel.E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH)
                buttonItem.Progress = 1000;

            buttonItem.Tooltip = "[" + info.TaskId + "]" + Environment.NewLine + info.TaskName + "" + Environment.NewLine + info.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            buttonItem.Checked = false;
            buttonItem.Click += new EventHandler(buttonItem_Click);
            buttonItem.DBClick += new EventHandler(buttonItem_DBClick);
            //if (itemContainer.SubItems.Count<100)
            //itemContainer.SubItems.Add(buttonItem);
            //else if (itemContainer.SubItems.Count == 100)
            //{
            //    ucTaskInfo buttonItemt = new ucTaskInfo();
            //    buttonItemt.Name = "buttonItemTask_" + item.Key.ToString();
            //    buttonItemt.Text = "<b>获取更多内容...</b>";

            //    itemContainer.SubItems.Add(buttonItemt);
            //}
            if (ShownTaskList.Find(it => it.TaskId == buttonItem.TaskId) == null)
                ShownTaskList.Add(buttonItem);

            itemContainer.SubItems.Add(buttonItem);
            return buttonItem;
        }

        private void labelItem_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.LabelItem labelitem = sender as DevComponents.DotNetBar.LabelItem;
            if (labelitem != null)
            {
                if (labelitem.Symbol == "\uf078")
                {
                    CloseContent( labelitem);
                }
                else
                {
                    OpenContent( labelitem);

                }
            }
        }

        private void OpenContent(DevComponents.DotNetBar.LabelItem labelitem)
        {
            string key = labelitem.Tag.ToString();
            DevComponents.DotNetBar.ItemContainer itemContainer
                = itemPanel1.GetItem("itemContainer_" + key) as DevComponents.DotNetBar.ItemContainer;
            foreach (IVX.DataModel.TaskInfoV3_1 info in m_viewModel.GetTaskTimeLineByKey(key).TaskList)
            {
                AddButtonItem(itemContainer, info);

            }
            if (!OpenedList.Contains(labelitem.Name))
                OpenedList.Add(labelitem.Name);
            itemPanel1.Refresh();
            labelitem.Symbol = "\uf078";

        }

        private void CloseContent(DevComponents.DotNetBar.LabelItem labelitem)
        {
            string key = labelitem.Tag.ToString();

            DevComponents.DotNetBar.ItemContainer itemContainer
                = itemPanel1.GetItem("itemContainer_" + key) as DevComponents.DotNetBar.ItemContainer;
            foreach (var btn in itemContainer.SubItems)
            {
                ucTaskInfo buttonItem = btn as ucTaskInfo;
                if (buttonItem != null)
                {
                    if (m_currentTask!=null && m_currentTask.TaskId == buttonItem.TaskId)
                        m_currentTask = null;
                    if (ShownTaskList.Find(it => it.TaskId == buttonItem.TaskId) != null)
                        ShownTaskList.Remove(buttonItem);
                }
            }

            itemContainer.SubItems.Clear();
            itemPanel1.Refresh();
            if (OpenedList.Contains(labelitem.Name))
                OpenedList.Remove(labelitem.Name);
            labelitem.Symbol = "\uf054";

        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            ucTaskInfo buttonItem = sender as ucTaskInfo;

            SelectOneTask(buttonItem);
        }


        private void SelectOneTask(ucTaskInfo buttonItem)
        {
            buttonItem.Checked = true;
            m_currentTask = buttonItem;

            foreach (var item in ShownTaskList)
            {
                if (item.TaskId == buttonItem.TaskId)
                    continue;
                item.Checked = false;
            }
        }

        private void buttonItem_DBClick(object sender, EventArgs e)
        {
            ucTaskInfo buttonItem = sender as ucTaskInfo;

            SelectOneTask(buttonItem);

            ShowSingleTask();

        }

        private void ShowSingleTask()
        {
            TaskInfoV3_1 task = null;// m_viewModel.GetTaskInfo(m_currentTask.TaskId);
            if (task != null)
            {
                m_currentShownTask = new FormSingleTask(task, m_currentTask.Progress);
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
            //BuildTaskList();
            m_viewModel.GetTaskProgress();
        }

        public override void Clear()
        {
            m_isInited = false;
        }

        #endregion


    }
}
