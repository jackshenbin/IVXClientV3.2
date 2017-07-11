using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAppUtil.Common;
using System.IO;
using IVX.Live.ViewModel;
using DevComponents.AdvTree;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucTaskTreelist : UserControl
    {

        public event Action<SearchItemV3_1> SelectedTaskChanged;

        public E_VIDEO_ANALYZE_TYPE AnalyseFilter { get; set; }
        public bool ShowCheckBox { get; set; }
        public bool HasNodeChecked
        {
            get
            {
                bool isHasCheck = false;
                foreach (Node node in advTreeUnSel.Nodes)
                {
                    if (node.Checked)
                    {
                        return true;
                    }
                }
                return isHasCheck;
            }
        }

        public bool HasNodeSelected
        {
            get
            {
                return advTreeUnSel.SelectedNode != null;
            }
        }

        public string Title
        {
            get { return columnHeader1.Text; }
            set { columnHeader1.Text = value; }
        }

        [DefaultValue(4)]
        public int SelectImageIndex { get; set; }

        [DefaultValue(5)]
        public int CheckImageIndex { get; set; }

        [DefaultValue(-1)]
        public int NormalImageIndex { get; set; }

        TaskManagementMAViewModel m_viewModel;

        #region Constructors

        public ucTaskTreelist()
        {
            InitializeComponent();
            m_viewModel = new TaskManagementMAViewModel();
            SelectImageIndex = 4;
            CheckImageIndex = 5;
            NormalImageIndex = -1;
            AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
        }


        #endregion

        #region Private helper functions


        private void InitTree(AdvTree tree, List<SearchItemV3_1> list)
        {
            advTreeUnSel.Nodes.Clear();
            foreach (SearchItemV3_1 si in list)
            {
                Node node = tree.FindNodeByName(tree.Name + "_" + si.CameraID);
                if (node == null)
                {
                    Node newnode = new Node(si.CameraName);
                    newnode.Name = tree.Name + "_" + si.CameraID;
                    newnode.Tag = si;
                    newnode.ImageIndex = NormalImageIndex;
                    if (ShowCheckBox)
                    {
                        newnode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                        newnode.CheckBoxVisible = true;
                    }
                    tree.Nodes.Add(newnode);
                }
            }
        }


        private void advTreeUnSel_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            SelectedNode(e.Node);
        }

        private void SelectedNode(Node e)
        {
            bool isselected = e.ImageIndex == SelectImageIndex;
            foreach (Node n in advTreeUnSel.Nodes)
            {
                n.ImageIndex = NormalImageIndex;
            }
            if (!isselected)
            {
                e.ImageIndex = SelectImageIndex;
                if (SelectedTaskChanged != null)
                {
                    SearchItemV3_1 si = e.Tag as SearchItemV3_1;
                    SelectedTaskChanged(si);
                }
            }
            else
            {
                if (SelectedTaskChanged != null)
                {
                    SelectedTaskChanged(null);
                }
            }
        }
        private void CheckedNode(Node e)
        {
            e.Checked = true;
        }

        private void advTree1_AfterCheck(object sender, AdvTreeCellEventArgs e)
        { 
			//如果通过代码 设置 check 则不执行 鼠标判断
			if (e.Action == eTreeAction.Code) return;
            foreach (Node node in advTreeUnSel.Nodes)
            {
				if (node.Checked && node.IsMouseOver) 
				{
					node.Checked = true;
				}
				else
				{
					node.Checked = false;
				}
            }
        }
        #endregion



        #region Public helper function
        public void InitTaskRoot()
        {
            List<SearchItemV3_1> list = null;
            switch (AnalyseFilter)
            {
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
                    list = m_viewModel.GetAllTrafficEventTaskItems();
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
                    list = m_viewModel.GetAllBehaviourEventTaskItems();
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD:
                    list = m_viewModel.GetAllCrowdEventRealTimeTaskItems();
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT:
                    break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH:
                    break;
                default:
                    break;
            }
            InitTree(advTreeUnSel, list);
        }

        public void SetSelectedTask(SearchItemV3_1 item)
        {
			if (item == null) return;
            Node node = advTreeUnSel.FindNodeByName(advTreeUnSel.Name + "_" + item.CameraID);
            if (node != null)
            {
                SelectedNode(node);
            }
        }

        public void SetCheckedTask(SearchItemV3_1 item)
        {
			if (item == null) return;
            Node node = advTreeUnSel.FindNodeByName(advTreeUnSel.Name + "_" + item.CameraID);
            if (node != null)
            {
                CheckedNode(node);
            }
        }


        public SearchItemV3_1 GetCheckedTask()
        {
            SearchItemV3_1 searchItem = null;
            foreach (Node node in advTreeUnSel.Nodes)
            {
                if (node.Checked && node.Tag is SearchItemV3_1)
                {
                    searchItem = (SearchItemV3_1)node.Tag;
                    break;
                }
            }
            return searchItem;
        }

        public SearchItemV3_1 GetSelectedTask()
        {
            Node node = advTreeUnSel.SelectedNode;
            if (node == null)
                return null;
			if (node.ImageIndex != SelectImageIndex)
				return null;
            return (SearchItemV3_1)node.Tag;
        }

		public SearchItemV3_1 GetHighLightTask()
		{
			Node node = advTreeUnSel.SelectedNode;
			if (node == null)
				return null;
			return (SearchItemV3_1)node.Tag;
		}

		public void SetHighLightTask(SearchItemV3_1 si) 
		{
			if (si == null) return;
			Node node = advTreeUnSel.FindNodeByName(advTreeUnSel.Name + "_" + si.CameraID);
			if (node != null) {
				advTreeUnSel.SelectedNode = node;
				advTreeUnSel.Select();
			}
		}

		public void RefreshTaskRoot()
		{
			SearchItemV3_1 CheckItem = null;
			if (ShowCheckBox)
			{
				CheckItem = GetCheckedTask();
			}
			SearchItemV3_1 selectItem = GetSelectedTask();
			SearchItemV3_1 highLightItem = GetHighLightTask();
			InitTaskRoot();
			// setSelect
			SetSelectedTask(selectItem);
			SetHighLightTask(highLightItem);
			// SetCheck
			if (ShowCheckBox)
			{
				SetCheckedTask(CheckItem);
			}
		}
        #endregion
    }
}
