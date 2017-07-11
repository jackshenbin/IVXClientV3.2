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
using System.Windows.Forms.DataVisualization.Charting;

namespace IVX.Live.MainForm.View {
	public partial class ucTrafficFluxStatisticSearch : UserControl {
		TrafficFluxStatisticViewModel m_vm;
		TrafficTimeType timeType;
		private List<string> m_cameraIDList;
		SearchFinshInvoke m_searFinshFunc;
		Dictionary<string, Series> dicSeries;
		public ucTrafficFluxStatisticSearch() {
			InitializeComponent();
			dicSeries = new Dictionary<string, Series> {};
		}

		private void SetTreeArg() {
			ucTrafficCameraTree1.HasRootNode = false;
			ucTrafficCameraTree1.HasCheck = true;
			ucTrafficCameraTree1.MuliteCheck = true;
			// 历史交通事件列表
			ucTrafficCameraTree1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD;
			ucTrafficCameraTree1.HasHistoryTask = false;
			ucTrafficCameraTree1.TreeTitle = "统计交通流量列表";
		}

		private void ucTrafficFluxStatisticSearch_Load(object sender, EventArgs e) {
			if (DesignMode) {
				return;
			}
			m_vm = new TrafficFluxStatisticViewModel();
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
			comboBoxEx1.Text = "小时";
			m_vm.SearchFinished += ucTrafficSearchFinsh;
			m_searFinshFunc += new SearchFinshInvoke(SearchFinshFunc);
			SetTreeArg();
			ucTrafficCameraTree1.InitTree();
		}

		void ucTrafficSearchFinsh(object TrafficInfoListObj, EventArgs e) {
			Invoke(m_searFinshFunc, TrafficInfoListObj);
		}

		private void SearchFinshFunc(object TrafficInfoListObj) {
			MyLog4Net.Container.Instance.Log.Debug("TrafficFluxStatistic SearchFinshFunc ");
			List<TrafficFluxStatisticInfo> TrafficList = (List<TrafficFluxStatisticInfo>)TrafficInfoListObj;
			ClearData();
			if (TrafficList == null || TrafficList.Count == 0) {
				//无结果数据
				this.searchBtn.Enabled = true;
				MyLog4Net.Container.Instance.Log.Debug("ucTrafficFluxStatisticSearch SearchFinshFunc " + " not have any Data");
				MessageBox.Show("历史交通流量-查询错误[无结果数据]:", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			else {
				MyLog4Net.Container.Instance.Log.Debug("ucTrafficFluxStatisticSearch SearchFinshFunc end");
				ShowChart(TrafficList);
			}
			this.searchBtn.Enabled = true;
			MyLog4Net.Container.Instance.Log.Debug("ucTrafficFluxStatisticSearch SearchFinshFunc Add Datae end");
		}
		private void ShowChart(List<TrafficFluxStatisticInfo> TrafficList) {
			Series retSeries = null;
			string cId = "";
			string curTimeTag = null;
			string[] dayStr = null;
			string[] str = null;
			foreach (var item in TrafficList) {
				cId = item.CameraID;
				if (!dicSeries.TryGetValue(cId, out retSeries)) {
					retSeries = new Series();
					retSeries.ChartType = SeriesChartType.Spline;
					retSeries.Name = cId;
					retSeries.BorderWidth = 6;
					retSeries.IsValueShownAsLabel = true;
					retSeries.ChartArea = "ChartArea1";
					retSeries.Enabled = true;
					dicSeries[cId] = retSeries;
					chart1.Series.Add(retSeries);
				}
				switch (timeType) {
					case TrafficTimeType.MONTH:
						dayStr = item.TimeTag.Split('-');
						curTimeTag = dayStr[1];
						break;
					case TrafficTimeType.DAY:
						dayStr = item.TimeTag.Split('-');
						curTimeTag = dayStr[2];
						break;
					case TrafficTimeType.HOUR:
						str = item.TimeTag.Split(' ');
						dayStr = str[0].Split('-');
						curTimeTag = str[1];
						break;
					default:
						break;
				}
				retSeries.Points.AddXY(curTimeTag, item.TrafficFlux);
			}
		}

		private void ClearData() {
			//清除 上次数据
			foreach (var item in dicSeries) {
				item.Value.Points.Clear();
			}
			dicSeries.Clear();
			chart1.Series.Clear();
		}
		private void searchBtn_Click(object sender, EventArgs e) {
			if (!ucTrafficCameraTree1.IsHasChecked) {
				MessageBox.Show("请选择一个监测点");
				return;
			}
			if (comboBoxEx1.Text == "月") {
				timeType = TrafficTimeType.MONTH;
			}
			else if (comboBoxEx1.Text == "天") {
				timeType = TrafficTimeType.DAY;
			}
			else if (comboBoxEx1.Text == "小时") {
				timeType = TrafficTimeType.HOUR;
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
			if (m_vm.TimeIsLong(startTime, endTime, timeType)) {
				MessageBoxEx.Show("时间跨度太大");
				return;
			}
			//开始查询
			m_cameraIDList = ucTrafficCameraTree1.GetCheckTCameraIDList();
			m_vm.Search(m_cameraIDList, startTime, endTime, (uint)timeType);
			this.searchBtn.Enabled = false;
		}

		public void Clear() {
			m_vm.SearchFinished -= ucTrafficSearchFinsh;
			m_searFinshFunc -= new SearchFinshInvoke(SearchFinshFunc);
		}

		private void reSet_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
			comboBoxEx1.Text = "小时";
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddYears(-1);
			dateTimeEnd.Value = DateTime.Now;
			comboBoxEx1.Text = "月";
		}

		private void buttonX1_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddMonths(-1);
			dateTimeEnd.Value = DateTime.Now;
			comboBoxEx1.Text = "天";
		}

	}
}
