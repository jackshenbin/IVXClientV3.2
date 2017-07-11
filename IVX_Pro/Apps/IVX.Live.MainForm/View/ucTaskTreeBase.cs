using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using DevComponents.AdvTree;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View {
	public partial class ucTaskTreeBase : UserControl {
		TaskManagementMAViewModel m_viewModel;
		RealtimeTaskManagementMAViewModel m_RealViewModel;
		public event Action<SearchItemV3_1> SelectedTaskChanged;
		public bool HasRootNode { get; set; }
		public bool HasCheck { get; set; }
		public bool MuliteCheck { get; set; }
		public bool HasHistoryTask { get; set; }     // 是否需要历史任务
		public int CameraImageIndex { get; set; }
		public int AlarmImageIndex { get; set; }
		public int NormalImageIndex { get; set; }
		public E_VIDEO_ANALYZE_TYPE AnalyseFilter { get; set; }

		public string TreeTitle {
			get { return this.columnHeader1.Text; }
			set { this.columnHeader1.Text = value; }
		}

		public bool IsHasChecked {
			get {
				bool ret = false;
				NodeCollection nodeCollet = null;
				if (HasRootNode) {
					if (advTree1.Nodes[0].Checked) {
						return true;
					}
					nodeCollet = advTree1.Nodes[0].Nodes;
				}
				else {
					nodeCollet = advTree1.Nodes;
				}

				foreach (Node node in nodeCollet) {
					if (node.Checked) {
						return true;
					}
				}
				return ret;
			}
		}

		public ucTaskTreeBase() {
			InitializeComponent();
			HasRootNode = false;
			HasCheck = false;
			CameraImageIndex = 0;
			AlarmImageIndex = 1;
			NormalImageIndex = -1;
			HasHistoryTask = false;
			MuliteCheck = false;
            m_viewModel = new TaskManagementMAViewModel();
			m_RealViewModel = new RealtimeTaskManagementMAViewModel();
			m_viewModel.TaskAdded += ViewModel_TaskAdd;
			m_viewModel.TaskDeleted += ViewModel_TaskDel;
			m_viewModel.TaskModified += ViewModel_TaskMdf;

			m_RealViewModel.TaskAdded += ViewModel_TaskAdd;
			m_RealViewModel.TaskDeleted += ViewModel_TaskDel;
			m_RealViewModel.TaskModified += ViewModel_TaskMdf;
		}

		// uc onload Call InitTree
		public void InitTree() {
			var taskList = GetTaskList();
			if (HasRootNode) {
				InitTree(advTree1, taskList);
			}
			else {
				InitTreeNormal(advTree1, taskList);
			}
		}

		public List<SearchItemV3_1> GetTaskList() {
			List<SearchItemV3_1> list = null;
			switch (AnalyseFilter) {
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE:
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ:
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE:
					break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC:
					list = m_viewModel.GetAllFaceEventTaskItems();
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF:
					break;
				// 运动物检索
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
					list = m_viewModel.GetAllMoveObjectSearchItems();
					break;
				// 交通事件 --全部实时
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
					list = m_viewModel.GetAllTrafficEventTaskItems();
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
					break;
				// 行为 --全部实时
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
					list = m_viewModel.GetAllBehaviourEventTaskItems();
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
					break;
				//大客流 --全部实时
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
			return list;
		}

		private void InitTree(AdvTree tree, List<SearchItemV3_1> list) {
			tree.Nodes.Clear();
			Node rootNode = new Node("");
			rootNode.Name = "查询全部"; // tree.Name + "_" + si.CameraID;
			rootNode.Text = "查询全部";
			rootNode.ImageIndex = CameraImageIndex;
			rootNode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
			rootNode.CheckBoxVisible = true;
			rootNode.Checked = false;
			rootNode.ExpandAll();
			tree.Nodes.Add(rootNode);
			foreach (SearchItemV3_1 si in list) {
				Node node = tree.FindNodeByName(si.CameraID);
				if (node == null) {
                    Node newnode = new Node("[" + si.TaskId + "]" + si.CameraName);
					newnode.Name = si.CameraID; // tree.Name + "_" + si.CameraID;
					newnode.Tag = si;
					newnode.ImageIndex = CameraImageIndex;
					newnode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
					newnode.CheckBoxVisible = true;
					rootNode.Nodes.Add(newnode);
				}
			}
		}

		//普通tree 分为 有check 无check
		private void InitTreeNormal(AdvTree tree, List<SearchItemV3_1> list) {
			tree.Nodes.Clear();
			foreach (SearchItemV3_1 si in list) {
				Node node = tree.FindNodeByName(si.CameraID);
				if (node == null) {
                    Node newnode = new Node("[" + si.TaskId + "]" + si.CameraName);
					newnode.Name = si.CameraID;  // tree.Name + "_" + si.CameraID;
					newnode.Tag = si;
					if (HasCheck) {
						newnode.ImageIndex = CameraImageIndex;
						newnode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
						newnode.CheckBoxVisible = true;
					}
					tree.Nodes.Add(newnode);
				}
			}
		}

		/// <summary>
		/// 获取资源树上的所有相机名
		/// </summary>
		/// <returns></returns>
		public List<string> GetAllCameraIDList() {
			List<string> CameraIDList = new List<string> { };
			NodeCollection nodeCollect = GetTreeNodeCollect();
			foreach (Node node in nodeCollect) {
				if (node.Checked && node.Tag is SearchItemV3_1) {
					string id = ((SearchItemV3_1)node.Tag).CameraID;
					CameraIDList.Add(id);
				}
			}
			return CameraIDList;
		}

		private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e) {
			if (HasCheck || HasRootNode) return;
			SelectedNode(e.Node);
		}

		private void advTree1_AfterCheck(object sender, AdvTreeCellEventArgs e) {
			if (e.Action == eTreeAction.Code)
				return;
			// HasRootNode
			if (HasRootNode) {
				Node rootNodes = advTree1.Nodes[0];
				if (rootNodes.IsSelected) {
					foreach (Node node in rootNodes.Nodes) {
						node.Checked = rootNodes.Checked;
					}
				}
				return;
				//不带root 带check
			} if (HasCheck) {
				if (MuliteCheck) {
					return;
				}
				foreach (Node node in advTree1.Nodes) {
					if (node.Checked && node.IsMouseOver) {
						node.Checked = true;
					}
					else {
						node.Checked = false;
					}
				}
				return;
			}
		}

		/// <summary>
		/// 报警时 执行的操作 
		/// </summary>
		/// <param name="e"></param>
		private void SelectedNode(Node e) {
			bool isselected = e.ImageIndex == AlarmImageIndex;
			foreach (Node n in advTree1.Nodes) {
				n.ImageIndex = NormalImageIndex;
			}
			if (!isselected) {
				e.ImageIndex = AlarmImageIndex;
				if (SelectedTaskChanged != null) {
					SearchItemV3_1 si = e.Tag as SearchItemV3_1;
					SelectedTaskChanged(si);
				}
			}
			else {
				if (SelectedTaskChanged != null) {
					SelectedTaskChanged(null);
				}
			}
		}

		/// <summary>
		/// null 查询全部
		/// count = 1 查询单个
		/// count > 1 查询多个
		/// </summary>
		/// <returns></returns>
		public List<string> GetCheckTCameraIDList() {
			List<string> CameraIDList = new List<string> { };
			if (HasRootNode && advTree1.Nodes[0].Checked) {
				// 如果选择全部查询时 return null
				return null;
			}
			NodeCollection nodeCollect = GetTreeNodeCollect();
			foreach (Node node in nodeCollect) {
				if (node.Checked && node.Tag is SearchItemV3_1) {
					string id = ((SearchItemV3_1)node.Tag).CameraID;
					CameraIDList.Add(id);
				}
			}
			return CameraIDList;
		}

		/// <summary>
		/// null 查询全部
		/// count = 1 查询单个
		/// count > 1 查询多个
		/// </summary>
		/// <returns></returns>
		public List<SearchItemV3_1> GetCheckTSearchList() {
			List<SearchItemV3_1> SearchList = new List<SearchItemV3_1> { };
			if (HasRootNode && advTree1.Nodes[0].Checked) {
				//如果选择全部查询时 return null
					return null;
			}
			NodeCollection nodeCollect = GetTreeNodeCollect();
			foreach (Node node in nodeCollect) {
				if (node.Checked && node.Tag is SearchItemV3_1) {
					SearchList.Add((SearchItemV3_1)node.Tag);
				}
			}
			return SearchList;
		}

		private void ViewModel_TaskMdf(TaskInfoV3_1 obj) {
			//当前 算法类型一致 
			if (IsMySelfAnalyzeType(obj)) {
				// &&含有该 任务
				Node mdfNode = null;
				if (HasTask(obj, out mdfNode)) {
					NodeMdf(obj.ToSearchItem(), mdfNode);
				}
				// 不含有该 任务
				else {
					//添加该任务
					NodeAdd(obj.ToSearchItem());
				}
			}
			//当前 算法类型 不一致 ----删除的情况
			else {
				Node delNode = null;
				if (HasTask(obj, out delNode)) {
					NodeDelete(delNode);
				}
			}
		}

		private void ViewModel_TaskDel(TaskInfoV3_1 obj) {
			if (!IsMySelfAnalyzeType(obj)) return;
			Node delNode = null;
			if (HasTask(obj, out delNode)) {
				NodeDelete(delNode);
			}
		}

		private void ViewModel_TaskAdd(TaskInfoV3_1 obj) {
			Node item = null;
			if (!IsMySelfAnalyzeType(obj) || HasTask(obj, out item)) return;
			NodeAdd(obj.ToSearchItem());
		}

		private void NodeDelete(Node delNode) {
			if (delNode == null) return;
			if (HasRootNode) {
				Node rootNodes = advTree1.Nodes[0];
				rootNodes.Nodes.Remove(delNode);
			}
			else {
				advTree1.Nodes.Remove(delNode);
			}
		}

		private void NodeAdd(SearchItemV3_1 si) {
            Node newnode = new Node("[" + si.TaskId + "]" + si.CameraName);
			newnode.Name = si.CameraID; // tree.Name + "_" + si.CameraID;
			newnode.Tag = si;
			if (HasRootNode) {
				Node rootNodes = advTree1.Nodes[0];
				rootNodes.Nodes.Add(newnode);
			}
			else {
				if (HasCheck) {
					newnode.ImageIndex = CameraImageIndex;
					newnode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
					newnode.CheckBoxVisible = true;
				}
				advTree1.Nodes.Add(newnode);
			}
		}

		private void NodeMdf(SearchItemV3_1 si, Node mdfNode) {
			mdfNode.Tag = si;
            mdfNode.Text = "[" + si.TaskId + "]" + si.CameraName;
			mdfNode.Name = si.CameraID;
		}

		// 是否已经在包含该任务
		public bool HasTask(TaskInfoV3_1 obj, out Node item) {
			bool ret = false;
			item = null;
			NodeCollection nodeCollect = GetTreeNodeCollect();
			foreach (Node node in nodeCollect) {
				if (((SearchItemV3_1)node.Tag).TaskId == obj.TaskId) {
					item = node;
					return true;
				}
			}
			return ret;
		}

		public void SetSelectedTask(SearchItemV3_1 item) {
			if (item == null) return;
			Node node = advTree1.FindNodeByName(item.CameraID);
			if (node != null) {
				SelectedNode(node);
			}
		}

		public void SetSingleCheckNode(SearchItemV3_1 item) {
			if (!HasCheck) return;
			NodeCollection nodeCollect = GetTreeNodeCollect();
			foreach (Node node in nodeCollect) {
				if (((SearchItemV3_1)node.Tag).CameraID == item.CameraID) {
					node.Checked = true;
				}
				else {
					node.Checked = false;
				}
			}
		}

		private NodeCollection GetTreeNodeCollect() {
			if (advTree1 == null)
				return null;
			if (HasRootNode) {
				return advTree1.Nodes[0].Nodes;
			}
			else {
				return advTree1.Nodes;
			}
		}

		private bool IsMySelfAnalyzeType(TaskInfoV3_1 TaskItem) {
			bool ret = false;
			if (TaskItem == null) return ret;
			switch (AnalyseFilter) {
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE:
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ:
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE:
					break;
                case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC:
					if (TaskItem.TaskType == TaskType.Realtime) {
							ret = true;
					}
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF:
					break;
				// 运动物检索
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
                    if(TaskItem.TaskType ==  TaskType.Realtime)
                    {
                        if (TaskItem.StatusList.Exists(xx => xx.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH && (xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE)))
                            ret = true;
                    }
                    if(TaskItem.TaskType == TaskType.History)
                    {
                        if (TaskItem.StatusList.Exists(xx => (xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE)))
                            ret = true;
                    }
					break;
				// 交通事件 --全部实时
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
                    if (TaskItem.TaskType == TaskType.Realtime)
                    {
                        if (TaskItem.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD))
                            ret = true;
                    }
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
					break;
				// 行为 --全部实时
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
					if (TaskItem.TaskType == TaskType.Realtime)
                    {
                        if (TaskItem.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM))
                            ret = true;
                    }
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD:
					if (TaskItem.TaskType == TaskType.Realtime)
                    {
                        if (TaskItem.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD))
                            ret = true;
                    }
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT:
					break;
				case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH:
					break;
				default:
					break;
			}
			return ret;
		}
	}
}
