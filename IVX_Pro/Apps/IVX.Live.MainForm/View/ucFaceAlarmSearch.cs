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
	public partial class ucFaceAlarmSearch : UserControl {

		FaceAlarmSearchViewModel m_vm;
		List<BlackListLib>  m_list;
		public List<ucBlackPicbox> m_PanpelPicList;
		public static int PerPanelCount;

		public ucFaceAlarmSearch() {
			InitializeComponent();
			m_PanpelPicList = new List<ucBlackPicbox> {};
			m_vm = new FaceAlarmSearchViewModel();
			m_vm.SearchFinished += m_faceResultPanel.m_viewModel_SearchFinished;
		}

		private void SetTreeArg() {
			if (DesignMode) return;
			ucTaskTreeBase1.HasRootNode = true;
			ucTaskTreeBase1.HasCheck = true;
			//历史行为事件
			ucTaskTreeBase1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC;
			ucTaskTreeBase1.HasHistoryTask = false;
			ucTaskTreeBase1.TreeTitle = "人脸布控监测点";
		}

		private void buttonX3_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-12);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void ucFaceAlarmSearch_Load(object sender, EventArgs e) {
			if (DesignMode) return;
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
			SetBlackListPanel();
			SetTreeArg();
			ucTaskTreeBase1.InitTree();
		}

		public void SetBlackListPanel() {
			blackListbox.Items.Clear();
			m_list  = BlackListViewModel.Instance.GetBlackList();
			foreach(var item in m_list)
			{
				blackListbox.Items.Add(item.Name);
			}
		}

		private void searchBtn_Click(object sender, EventArgs e) {
			if (!ucTaskTreeBase1.IsHasChecked) {
				MessageBox.Show("请选择一个监测点");
				return;
			}
			//设置时间
			uint startTime = DataModel.Common.ConvertLinuxTime(dateTimeStart.Value);
			uint endTime = DataModel.Common.ConvertLinuxTime(dateTimeEnd.Value);
			CheckTime ret = DataModel.Common.CheckDataTime(dateTimeStart.Value, dateTimeEnd.Value);
			if (ret == CheckTime.START_INVALID) {
				MessageBox.Show("开始时间不正常!");
				return;
			}
			else if (ret == CheckTime.END_INVALID) {
				MessageBox.Show("结束时间不正常!");
				return;
			}
			if (endTime - startTime > 7 * 24 * 60 * 60) {
				MessageBox.Show("时间跨度不能大于七天!");
				return;
			}
			// 清除 上次 查询结果
			// m_faceResultPanel.Clear();
			// 相机列表 
			List<string> creamIdList =  ucTaskTreeBase1.GetCheckTCameraIDList();
			if (creamIdList ==  null) {
				creamIdList = ucTaskTreeBase1.GetAllCameraIDList();
			}
 			// 黑名单列表 
			string blackListStr = GetBlackListStr();
			m_vm.StartFaceAlarmSearch(creamIdList, blackListStr, startTime, endTime);
			m_faceResultPanel.StartWait();
		}

		public string GetBlackListStr()
		{
			string blackListStr = "";
			foreach (var item in blackListbox.CheckedItems) {
				foreach (var lib in m_list) {
					if (lib.Name == item.ToString()) {
						blackListStr += lib.Handel.ToString()+",";
					}
				}
			}
			return blackListStr.Remove(blackListStr.Length - 1);
		}

		private void m_faceResultPanel_Load(object sender, EventArgs e) {
			// m_vm.Test_SearchFinsh();
		}

		private void buttonX1_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

	}
}
