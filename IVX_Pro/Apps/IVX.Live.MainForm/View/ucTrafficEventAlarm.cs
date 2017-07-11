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
using DevComponents.AdvTree;

namespace IVX.Live.MainForm.View
{
    public partial class ucTrafficEventAlarm : UserControl
    {

        #region 私有变量
        DataReceiveViewModel m_viewModel;

        List<TrafficeEventProperty> trafficEventList = new List<TrafficeEventProperty>();
        List<TrafficePlateProperty> trafficPlateList = new List<TrafficePlateProperty>();
        SearchItemV3_1 m_currTask = null;
        #endregion

        #region 属性


        #endregion


        #region 构造
        public ucTrafficEventAlarm()
        {
            InitializeComponent();
            comboBoxEx1.SelectedIndex = 0;
        }
        #endregion

        #region 公共函数
        public void Clear()
        {
            m_viewModel.Close();
        }


        #endregion

        #region 事件响应

        private void FormPlayHistory_Load(object sender, EventArgs e)
        {
            List<Control> clist = CreateFilterControl();
            flowLayoutPanelEvent.Controls.AddRange(clist.ToArray());
            if (DesignMode)
                return;
			SetTreeArg();
			ucTaskFileSystem1.InitTree();
            ucTaskFileSystem1.SelectedTaskChanged += ucTaskFileSystem1_SelectedTask;
            m_viewModel = new DataReceiveViewModel(Framework.Environment.LocalCommIP, Framework.Environment.TrafficEventDataReceivePort);
            if (m_viewModel.InitTask != null)
            {
                buttonItem1.Text = "报警数据源：" + m_viewModel.InitTask.CameraID;
                ucTaskFileSystem1.SetSelectedTask(m_viewModel.InitTask.ToSearchItem());
            }
            m_viewModel.TrafficEventReceived += m_viewModel_TrafficEventReceived;
            m_viewModel.TrafficPlateReceived += m_viewModel_TrafficPlateReceived;
            //advTreeTrafficEvent.DataSource = trafficEventList;
        }

		private void SetTreeArg() {
			if (DesignMode) return;
			ucTaskFileSystem1.HasRootNode = false;
			ucTaskFileSystem1.HasCheck = false;
			//交通事件报警
			ucTaskFileSystem1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD;
			ucTaskFileSystem1.HasHistoryTask = false;
			ucTaskFileSystem1.TreeTitle = "交通事件列表";
		}

        private List<Control> CreateFilterControl()
        {
            List<Control> clist = new List<Control>();

            foreach (E_TRAFFIC_EVENT_TYPE item in Enum.GetValues(typeof(E_TRAFFIC_EVENT_TYPE)))
            {
                DevComponents.DotNetBar.Controls.CheckBoxX c = new DevComponents.DotNetBar.Controls.CheckBoxX();
                c.Text = DataModel.Constant.TrafficEventTypeInfos.Single(it => it.Type == item).Name;
                if (item == E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_None)
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
                if (m_viewModel != null)
                {
                    m_viewModel.TrafficFilterType = (E_TRAFFIC_EVENT_TYPE)c.Tag;
                }

            }
        }

        void ucTaskFileSystem1_SelectedTask(SearchItemV3_1 obj)
        {
            if (m_currTask != null)
                m_viewModel.Unsubscribe(m_currTask.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD);

            if (obj != null)
            {
                m_viewModel.Subscribe(obj.TaskId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD);
                m_currTask = obj;
                buttonItem1.Text = "报警数据源：" + obj.CameraID;
            }
            else
            { 
                m_currTask = null;
                buttonItem1.Text = "";
            }
        }

        void m_viewModel_TrafficPlateReceived(TrafficePlateInfo obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<TrafficePlateInfo>(m_viewModel_TrafficPlateReceived), obj);
            }
            else
            {
                if (trafficPlateList.Count >= 50)
                {
                    var item = trafficPlateList[trafficPlateList.Count - 1];
                    item.Dispose();
                    trafficPlateList.RemoveAt(trafficPlateList.Count - 1);
                    advTreeTrafficPlate.Nodes.RemoveAt(trafficPlateList.Count - 1);
                }
                var property = new TrafficePlateProperty(obj);
                trafficPlateList.Insert(0, property);
                //advTreeTrafficEvent.RefreshItems();
                DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node(property.PlateNum);
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.StartTime));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.EndTime));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleColor));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleType));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleTypeDetail));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleLabel));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleLabelDetail));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.CameraCode));
                n.Tag = property;
                advTreeTrafficPlate.Nodes.Insert(0,n);
            }
        }

        void m_viewModel_TrafficEventReceived(TrafficeEventInfoV3_1 obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<TrafficeEventInfoV3_1>(m_viewModel_TrafficEventReceived), obj);
            }
            else
            {
                if (trafficEventList.Count >= 50)
                {
                    var item = trafficEventList[trafficEventList.Count - 1];
                    item.Dispose();
                    trafficEventList.RemoveAt(trafficEventList.Count - 1);
                    advTreeTrafficEvent.Nodes.RemoveAt(trafficEventList.Count - 1);
                }
                var property = new TrafficeEventProperty(obj);
                trafficEventList.Insert(0, property);
                //advTreeTrafficEvent.RefreshItems();
                DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node(property.EventType);
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.StartTime));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.EndTime));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.PlateNum));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleColor));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleType));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleTypeDetail));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleLabel));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleLabelDetail));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.VehicleSpeed));
                n.Cells.Add(new DevComponents.AdvTree.Cell(property.CameraCode));
                n.Tag = property;
                advTreeTrafficEvent.Nodes.Insert(0,n);
            }
        }

        private void advTreeTrafficEvent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (advTreeTrafficEvent.SelectedNode != null)
            {
                FormSingleTrafficEventDetail f = new FormSingleTrafficEventDetail();
                f.Init(trafficEventList);
                f.ShowResult(advTreeTrafficEvent.SelectedNode.Tag as TrafficeEventProperty);
                f.ShowDialog();

            }
        }

        private void advTreeTrafficPlate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (advTreeTrafficPlate.SelectedNode != null)
            {
                FormSingleTrafficPlateDetail f = new FormSingleTrafficPlateDetail();
                f.Init(trafficPlateList);
                f.ShowResult(advTreeTrafficPlate.SelectedNode.Tag as TrafficePlateProperty);
                f.ShowDialog();

            }
        }

        internal void StartWithTaskAction(SearchItemV3_1 searchItemV3_1)
        {
            ucTaskFileSystem1.SetSelectedTask(searchItemV3_1);
            ucTaskFileSystem1_SelectedTask(searchItemV3_1);
        }
        #endregion

        private void textBoxPlate_TextChanged(object sender, EventArgs e)
        {
            ChangePlateFilter();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPlate.Visible = (comboBoxEx1.SelectedIndex != 0);

            ChangePlateFilter();
        }

        private void ChangePlateFilter()
        {
            string filter = "*";
            switch (comboBoxEx1.SelectedIndex)
            {
                case 0: filter = "*";
                    break;
                case 1: filter = "*" + textBoxPlate.Text + "*";
                    break;
                case 2: filter = textBoxPlate.Text;
                    break;
                default:
                    break;
            }
            if(m_viewModel!=null)
                m_viewModel.PlateFilter = filter;
        }

        private void checkBoxItemEvent_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void checkBoxItemPlate_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            trafficPlateList.Clear();
            trafficEventList.Clear();
            advTreeTrafficEvent.Nodes.Clear();
            advTreeTrafficPlate.Nodes.Clear();
        }

        #region 私有函数

        #endregion


    }
}
