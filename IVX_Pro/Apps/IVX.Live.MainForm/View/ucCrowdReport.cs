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
using DevComponents.DotNetBar;

namespace IVX.Live.MainForm.View {

	public partial class ucCrowdReport : UserControl {
		CrowdReportViewModel m_crowdVM;
		Dictionary<string, ucCrowdSingleReport> m_crowdReportDic;
		CrowdTimeType timeType;
		public ucCrowdReport() {
			InitializeComponent();
		}

		private void SetTreeArg() {
			if (DesignMode) return;
			m_crowdCameraTree.HasRootNode = false;
			m_crowdCameraTree.HasCheck = true;
			//大客流 统计
			m_crowdCameraTree.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD;
			m_crowdCameraTree.HasHistoryTask = false;
			m_crowdCameraTree.TreeTitle = "大客流统计监控点";
		}

		private void ucCrowdReport_Load(object sender, EventArgs e) {
			if (DesignMode) {
				return;
			}
			m_crowdReportDic = new Dictionary<string, ucCrowdSingleReport> { };
			m_crowdVM = new CrowdReportViewModel();
			m_crowdVM.ReportSearchFinished += ucCrowdSearchFinsh;
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
			comboBoxEx1.Text = "小时";
			SetTreeArg();
			m_crowdCameraTree.InitTree();
		}


		// 查询 返回函数
		void ucCrowdSearchFinsh(object corwdInfoObj, EventArgs e) {
			List<CrowdStatistic> crowdInfoList = (List<CrowdStatistic>)corwdInfoObj;
			if (crowdInfoList.Count == 0) {
				MessageBoxEx.Show("大客流历史-查询错误:无结果数据", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				MyLog4Net.Container.Instance.Log.Debug("ucCrowdReport SearchFinsh not have any Data");
				return;
			}
			else if (crowdInfoList.Count == 1) {
				if (crowdInfoList[0].CameraID == "OutTime") {
					MessageBoxEx.Show("大客流历史-查询错误:连接服务超时", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					MyLog4Net.Container.Instance.Log.Debug("ucCrowdReport SearchFinsh outTime");
					return;
				}
			}
			m_crowdVM.Stop();
			string cameraId = crowdInfoList[0].CameraID;
			//刷新 
			m_crowdSingleReport.RefreshInfo(crowdInfoList, timeType);
			MyLog4Net.Container.Instance.Log.Debug("ucCrowdReport SearchFinsh " + cameraId);
		}

		private void searchBtn_Click(object sender, EventArgs e) {
			if (comboBoxEx1.Text == "月") {
				timeType = CrowdTimeType.MONTH;
			}
			else if (comboBoxEx1.Text == "天") {
				timeType = CrowdTimeType.DAY;
			}
			else if (comboBoxEx1.Text == "小时") {
				timeType = CrowdTimeType.HOUR;
			}
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
			if (m_crowdVM.TimeIsLong(startTime, endTime, timeType)) {
				MessageBoxEx.Show("时间跨度太大");
				return;
			}

			if (!m_crowdCameraTree.IsHasChecked) {
				MessageBoxEx.Show("请选择一个查询目标");
				return;
			}
			// 根据选中的个数 添加 tableItem
			var serList = m_crowdCameraTree.GetCheckTSearchList();
			SearchItemV3_1 cameraItem = null;
			if (serList.Count > 0) {
				cameraItem = serList[0];
			}
			if (cameraItem == null) {
				MessageBoxEx.Show("请重新选择一个目标");
				return;
			}
			try {
				m_crowdVM.Start(startTime, endTime, cameraItem, (uint)timeType);
			}
			catch (SDKCallException ex) {
				MessageBoxEx.Show("大客流统计-查询错误[" + ex.ErrorCode + "]:" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				//请求出错 终止线程 
				m_crowdVM.Stop();
				MyLog4Net.Container.Instance.Log.Debug("ucCrowdReport searchBtn_Click" + ex.ToString());
			}
		}


	}
}
