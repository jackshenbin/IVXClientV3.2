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
    public partial class ucBehaviourEventAlarm : UserControl
    {

        #region 私有变量
        DataReceiveViewModel m_viewModel;

        List<BehaviorProperty> behaviorEventList = new List<BehaviorProperty>();
        SearchItemV3_1 m_currTask = null;
        #endregion

        #region 属性


        #endregion


        #region 构造
        public ucBehaviourEventAlarm()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        public void Clear()
        {
            m_viewModel.Close();
        }


        #endregion

        #region 事件响应

		private void SetTreeArg() {
			if (DesignMode) return;
			ucTaskFileSystem1.HasRootNode = false;
			ucTaskFileSystem1.HasCheck = false;
			//行为事件
			ucTaskFileSystem1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM;
			ucTaskFileSystem1.HasHistoryTask = false;
			ucTaskFileSystem1.TreeTitle = "行为事件监测点";
		}

        private void FormPlayHistory_Load(object sender, EventArgs e)
        {
            List<Control> clist = CreateFilterControl();
            flowLayoutPanelEvent.Controls.AddRange(clist.ToArray());

            if (DesignMode)
                return;
			SetTreeArg();
			ucTaskFileSystem1.InitTree();
            ucTaskFileSystem1.SelectedTaskChanged += ucTaskFileSystem1_SelectedTask;
            m_viewModel = new DataReceiveViewModel(Framework.Environment.LocalCommIP, Framework.Environment.BehaviourDataReceivePort);
            if (m_viewModel.InitTask != null)
            {
                buttonItem1.Text = "报警数据源：" + m_viewModel.InitTask.CameraID;
                ucTaskFileSystem1.SetSelectedTask(m_viewModel.InitTask.ToSearchItem());
            }
            m_viewModel.BehaviorEventReceived += m_viewModel_BehaviorEventReceived;
            //advTreeTrafficEvent.DataSource = trafficEventList;
		
        }

        void m_viewModel_BehaviorEventReceived(BehaviorInfo obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<BehaviorInfo>(m_viewModel_BehaviorEventReceived), obj);
            }
            else
            {
                if (behaviorEventList.Count >= 50)
                {
                    var item = behaviorEventList[behaviorEventList.Count - 1];
                    item.Dispose();
                    behaviorEventList.RemoveAt(behaviorEventList.Count - 1);
                    advTreeBehaviourEvent.Nodes.RemoveAt(behaviorEventList.Count - 1);
                }
                var property = new BehaviorProperty(obj);
                behaviorEventList.Insert(0, property);
                //advTreeTrafficEvent.RefreshItems();
                DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node(property.EventType);
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.StartTime));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.EndTime));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.ObjectId));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.ObjType));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.CameraCode));
                n.Tag = property;
                advTreeBehaviourEvent.Nodes.Insert(0, n);
            }
        }

        private List<Control> CreateFilterControl()
        {
            List<Control> clist = new List<Control>();

            foreach (BehaviorType item in Enum.GetValues(typeof(BehaviorType)))
            {
                DevComponents.DotNetBar.Controls.CheckBoxX c = new DevComponents.DotNetBar.Controls.CheckBoxX();
                c.Text = DataModel.Constant.BehaviorTypeInfo.Single(it => it.Type == item).Name;
                if (item == BehaviorType.None)
                {
                    c.Text = "全部";
                    c.Checked = true;
                }
                if (item == BehaviorType.AlarmCountBreakIn) continue;
                if (item == BehaviorType.AlarmCountBreakOut) continue;
                if (item == BehaviorType.AlarmCountPasslineNeg) continue;
                if (item == BehaviorType.AlarmCountPasslinePos) continue;

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
                if (m_viewModel != null)
                {
                    m_viewModel.BehaviourFilterType = (BehaviorType)c.Tag;
                }

            }
        }

        void ucTaskFileSystem1_SelectedTask(SearchItemV3_1 obj)
        {
            if (m_currTask != null)
                m_viewModel.Unsubscribe(m_currTask.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM);

            if (obj != null)
            {
                m_viewModel.Subscribe(obj.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM);
                m_currTask = obj;
                buttonItem1.Text = "报警数据源：" + obj.CameraID;
            }
            else
            { 
                m_currTask = null;
                buttonItem1.Text = "";
            }
        }



        private void advTreeTrafficEvent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (advTreeBehaviourEvent.SelectedNode != null)
            {
                FormSingleBehaviourEvnetDetail f = new FormSingleBehaviourEvnetDetail();
                f.Init(behaviorEventList);
                f.ShowResult(advTreeBehaviourEvent.SelectedNode.Tag as BehaviorProperty);
                f.ShowDialog();

            }
        }

        internal void StartWithTaskAction(SearchItemV3_1 searchItemV3_1)
        {
            ucTaskFileSystem1.SetSelectedTask(searchItemV3_1);
            ucTaskFileSystem1_SelectedTask(searchItemV3_1);
        }
        #endregion




        private void checkBoxItemEvent_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            behaviorEventList.Clear();
            advTreeBehaviourEvent.Nodes.Clear();
        }

        #region 私有函数

        #endregion






    }
}
