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
	public delegate void SearchFinshInvoke(object obj);
	public partial class ucTrafficEventSearch : UserControl {
		public string m_serType;
		private List<string> m_cameraIDList;
		TrafficEventViewModel m_vm;
		SearchFinshInvoke m_searFinshFunc;
		List<TrafficeEventInfoV3_1> m_TrafficList;
		List<TrafficeEventProperty> m_EventList;
		public ucTrafficEventSearch() {
			InitializeComponent();
		}

		private void SetTreeArg() {
			ucTrafficCameraTree1.HasRootNode = true;
			ucTrafficCameraTree1.HasCheck = true;
			// 历史交通事件列表
			ucTrafficCameraTree1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD;
			ucTrafficCameraTree1.HasHistoryTask = false;
			ucTrafficCameraTree1.TreeTitle = "历史交通事件列表";
		}

		private void ucTrafficEventSearch_Load(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
			m_vm = new TrafficEventViewModel();
			m_vm.SearchFinished += ucTrafficSearchFinsh;
			m_searFinshFunc += new SearchFinshInvoke(SearchFinshFunc);
			m_EventList = new List<TrafficeEventProperty> { };
			SetTreeArg();
			ucTrafficCameraTree1.InitTree();
		}

		public void Clear() {
			m_vm.SearchFinished -= ucTrafficSearchFinsh;
			m_searFinshFunc -= new SearchFinshInvoke(SearchFinshFunc);
		}

		// 查询 返回函数
		void ucTrafficSearchFinsh(object TrafficInfoListObj, EventArgs e) {
			Invoke(m_searFinshFunc, TrafficInfoListObj);
		}

		private void SearchFinshFunc(object TrafficInfoListObj) {

			m_TrafficList = (List<TrafficeEventInfoV3_1>)TrafficInfoListObj;
			if (m_TrafficList.Count == 0) {
				this.searchBtn.Enabled = true;
				MyLog4Net.Container.Instance.Log.Debug("ucTrafficEventSearch SearchFinshFunc " + " not have any Data");
				noDataLabel.Visible = true;
				return;
			}
			MyLog4Net.Container.Instance.Log.Debug("ucTrafficEventSearch SearchFinshFunc end");
			int id = 0;
			foreach (var item in m_TrafficList) {
				TrafficeEventProperty proItem = new TrafficeEventProperty(item);
				dataGridViewX1.Rows.Add(item.CameraCode,
									  proItem.EventType,
									  item.StartTime,
									  item.EndTime,
									  item.PlateNum,
									  proItem.VehicleColor,
									  proItem.VehicleType,
									  proItem.VehicleLabel);
				dataGridViewX1.Rows[id].Tag = proItem;
				item.EventId = id++;
				m_EventList.Add(proItem);
			}
			this.searchBtn.Enabled = true;
			MyLog4Net.Container.Instance.Log.Debug("ucTrafficEventSearch SearchFinshFunc Add Data End");
		}

		private void searchBtn_Click(object sender, EventArgs e) {
			if (!ucTrafficCameraTree1.IsHasChecked) {
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
			if (ret == CheckTime.START_INVALID) {
				MessageBox.Show("开始时间不正常!");
				return;
			}
			else if (ret == CheckTime.END_INVALID) {
				MessageBox.Show("结束时间不正常!");
				return;
			}
			if (endTime - startTime > 24 * 60 * 60) {
				MessageBox.Show("时间跨度不能大于一天!");
				return;
			}

			noDataLabel.Visible = false;
			dataGridViewX1.Rows.Clear();
			m_EventList.Clear();
			//设置ID
			m_cameraIDList = ucTrafficCameraTree1.GetCheckTCameraIDList();
			//开始查询
			m_vm.Search(m_cameraIDList, startTime, endTime, m_serType);
			this.searchBtn.Enabled = false;
		}

		private void SetSearchType() {
			m_serType = "";
			if (this.checkBoxXALl.Checked) {
				m_serType = "0";
				return;
			}
			if (checkBoxX1.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NoReverse).ToString() + ",";
			}
			if (checkBoxX2.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_Jam).ToString() + ",";
			}
			if (checkBoxX3.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_PassagerCross).ToString() + ",";
			}
			if (checkBoxX4.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarCross).ToString() + ",";
			}
			if (checkBoxX5.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarFast).ToString() + ",";
			}
			if (checkBoxX6.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarLow).ToString() + ",";
			}
			if (checkBoxX7.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarStop).ToString() + ",";
			}
			if (checkBoxX8.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_ON_MOTORWAY).ToString() + ",";
			}
			if (checkBoxX9.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_PASSING).ToString() + ",";
			}
			if (checkBoxX10.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_TURNAROUND).ToString() + ",";
			}
			if (checkBoxX11.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_LEFT).ToString() + ",";
			}
			if (checkBoxX12.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_RIGHT).ToString() + ",";
			}
			if (checkBoxX13.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_STRAIGHT).ToString() + ",";
			}
			if (checkBoxX14.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_PRESS_LINE).ToString() + ",";
			}
			if (checkBoxX15.Checked) {
				m_serType += ((int)E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_ON_BUSWAY).ToString() + ",";
			}

			if (m_serType.Length > 1) {
				m_serType = m_serType.Substring(0, m_serType.Length - 1);
			}
		}


		private void SetCheck(bool flag) {
			checkBoxX1.Checked = flag;
			checkBoxX2.Checked = flag;
			checkBoxX3.Checked = flag;
			checkBoxX4.Checked = flag;
			checkBoxX5.Checked = flag;
			checkBoxX6.Checked = flag;
			checkBoxX7.Checked = flag;
			checkBoxX8.Checked = flag;
			checkBoxX9.Checked = flag;
			checkBoxX10.Checked = flag;
			checkBoxX11.Checked = flag;
			checkBoxX12.Checked = flag;
			checkBoxX13.Checked = flag;
			checkBoxX14.Checked = flag;
			checkBoxX15.Checked = flag;
		}

		private void checkBoxXALl_CheckedChanged(object sender, EventArgs e) {
			if (this.checkBoxXALl.Checked) {
				SetCheck(true);
			}
			else {
				SetCheck(false);
			}
		}

		private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			//获取当前的数据  并显示
			if (dataGridViewX1.CurrentRow.Tag is TrafficeEventProperty) {
				TrafficeEventProperty item = (TrafficeEventProperty)dataGridViewX1.CurrentRow.Tag;
				FormSingleTrafficEventDetail f = new FormSingleTrafficEventDetail();
				f.Text = "历史交通事件信息查看";
				f.Init(m_EventList);
				f.ShowResult(item);
				f.ShowDialog();
			}
		}

		private void reSet_Click(object sender, EventArgs e) {
			checkBoxXALl.Checked = true;
			SetCheck(true);
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX3_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-12);
			dateTimeEnd.Value = DateTime.Now;
		}
	}
}
