using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View {
	public partial class ucBehaviorEventSearch : UserControl 
	{
		public string m_serType;
		BehaviorEventViewModel m_vm;
		List<BehaviorInfo> m_behaviorList;
		SearchFinshInvoke m_searFinshFunc;
		private List<string> m_cameraIDList;
		List<BehaviorProperty> m_EventList;
		public ucBehaviorEventSearch() 
		{
			InitializeComponent();
		}

		private void SetTreeArg() {
			if (DesignMode) return;
			m_CameraTree.HasRootNode = true;
			m_CameraTree.HasCheck = true;
			//历史行为事件
			m_CameraTree.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM;
			m_CameraTree.HasHistoryTask = false;
			m_CameraTree.TreeTitle = "历史行为事件监测点";
		}

		private void ucBehaviorEventSearch_Load(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
			m_vm = new BehaviorEventViewModel();
			m_vm.SearchFinished += ucBehaviorSearchFinsh;
			m_searFinshFunc += new SearchFinshInvoke(SearchFinshFunc);
			m_EventList = new List<BehaviorProperty> {};
			SetTreeArg();
			m_CameraTree.InitTree();
		}

		// 查询 返回函数
		void ucBehaviorSearchFinsh(object BehaviorInfoListObj, EventArgs e) 
		{
			Invoke(m_searFinshFunc, BehaviorInfoListObj);
		}

		private void SearchFinshFunc(object BehaviorInfoListObj)
		{
			m_behaviorList = (List<BehaviorInfo>)BehaviorInfoListObj;
			if (m_behaviorList.Count == 0)
			{
				this.searchBtn.Enabled = true;
				MyLog4Net.Container.Instance.Log.Debug("ucBehaviorSearch SearchFinshFunc " + " not have any Data");
				noDataLabel.Visible = true;
				return;
			}
			MyLog4Net.Container.Instance.Log.Debug("ucBehaviorSearch SearchFinshFunc end");
			int id = 0;
			foreach (var item in m_behaviorList) {
				item.ObjectId = (uint)id;
				BehaviorProperty proItem = new BehaviorProperty(item);
				dataGridViewX1.Rows.Add(item.CameraID,
									  item.StartTime,
									  item.EndTime,
									  proItem.EventType);
				dataGridViewX1.Rows[id].Tag = proItem;
				id++;
				m_EventList.Add(proItem);
			}
			this.searchBtn.Enabled = true;
			MyLog4Net.Container.Instance.Log.Debug("ucBehaviorSearch SearchFinshFunc Add Data End");
		}

		private void searchBtn_Click(object sender, EventArgs e)
		{
			if (!m_CameraTree.IsHasChecked) {
				MessageBox.Show("请选择一个监测点");
				return;
			}

			//设置类型 
			SetSearchType();
			if (m_serType.Length < 1) {
				MessageBox.Show("请选择一个事件类型");
				return;
			}

			//设置时间
			uint startTime = DataModel.Common.ConvertLinuxTime(dateTimeStart.Value);
			uint endTime = DataModel.Common.ConvertLinuxTime(dateTimeEnd.Value);
			CheckTime ret = DataModel.Common.CheckDataTime(dateTimeStart.Value, dateTimeEnd.Value);
			if (ret == CheckTime.START_INVALID)
			{
				MessageBox.Show("开始时间不正常!");
				return;
			}
			else if (ret == CheckTime.END_INVALID) 
			{
				MessageBox.Show("结束时间不正常!");
				return;
			}

			if (endTime - startTime > 7*24 * 60 * 60) {
				MessageBox.Show("时间跨度不能大于七天!");
				return;
			}

			dataGridViewX1.Rows.Clear();
			m_EventList.Clear();
			//设置ID
			m_cameraIDList = m_CameraTree.GetCheckTCameraIDList();
			//开始查询
			m_vm.Search(m_cameraIDList, startTime, endTime, m_serType);
			this.searchBtn.Enabled = false;
			noDataLabel.Visible = false;
		}

		private void SetSearchType() {
			m_serType = "";
			if (this.checkBoxXALl.Checked) {
				m_serType = "1000";
				return;
			}
			if (checkBoxX1.Checked) {
				m_serType += ((int)BehaviorType.Mass).ToString() + ",";
			}
			if (checkBoxX2.Checked) {
				m_serType += ((int)BehaviorType.FlyLeaflet).ToString() + ",";
			}
			if (checkBoxX3.Checked) {
				m_serType += ((int)BehaviorType.Banner).ToString() + ",";
			}
			if (checkBoxX4.Checked) {
				m_serType += ((int)BehaviorType.Run).ToString() + ",";
			}
			if (checkBoxX5.Checked) {
				m_serType += ((int)BehaviorType.BreakIn).ToString() + ",";
			}
			if (checkBoxX6.Checked) {
				m_serType += ((int)BehaviorType.BreakOut).ToString() + ",";
			}
			if (checkBoxX7.Checked) {
				m_serType += ((int)BehaviorType.PasslinePos).ToString() + ",";
			}
			if (checkBoxX8.Checked) {
				m_serType += ((int)BehaviorType.PasslineNeg).ToString() + ",";
			}
			if (m_serType.Length > 1) {
				m_serType = m_serType.Substring(0, m_serType.Length - 1);
			}
		}

		private void checkBoxXALl_CheckedChanged(object sender, EventArgs e) 
		{
			SetCheck(this.checkBoxXALl.Checked);
		}

		private void SetCheck(bool flag) 
		{
			checkBoxX1.Checked = flag;
			checkBoxX2.Checked = flag;
			checkBoxX3.Checked = flag;
			checkBoxX4.Checked = flag;
			checkBoxX5.Checked = flag;
			checkBoxX6.Checked = flag;
			checkBoxX7.Checked = flag;
			checkBoxX8.Checked = flag;
		}

		private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//获取当前的数据  并显示
			if (dataGridViewX1.CurrentRow.Tag is BehaviorProperty) {
				BehaviorProperty item = (BehaviorProperty)dataGridViewX1.CurrentRow.Tag;
				FormSingleBehaviourEvnetDetail f = new FormSingleBehaviourEvnetDetail();
				f.ImageUseURL = true;
				f.Init(m_EventList);
				f.ShowResult(item);
				f.ShowDialog();
			}
		}

		private void buttonX1_Click(object sender, EventArgs e) {
			checkBoxXALl.Checked = true;
			SetCheck(true);
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddDays(-7);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX3_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

	}
}
