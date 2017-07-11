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

namespace IVX.Live.MainForm.View
{
    public partial class ucTrafficFluxSearch : UserControl
    {
        TrafficFluxHistoryViewModel m_vm;
        SearchFinshInvoke m_searFinshFunc;
        private List<string> m_cameraIDList;
        public ucTrafficFluxSearch()
        {
            InitializeComponent();
        }

		private void SetTreeArg() {
			ucTrafficCameraTree1.HasRootNode = true;
			ucTrafficCameraTree1.HasCheck = true;
			// 历史交通事件列表
			ucTrafficCameraTree1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD;
			ucTrafficCameraTree1.HasHistoryTask = false;
			ucTrafficCameraTree1.TreeTitle = "历史交通流量列表";
		}

        private void searchBtn_Click(object sender, EventArgs e)
        {
			if (!ucTrafficCameraTree1.IsHasChecked)
            {
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
            if (endTime - startTime > 24 * 60 * 60)
            {
                MessageBox.Show("时间跨度不能大于一天!");
                return;
            }
			noDataLabel.Visible = false;
            //设置ID
            m_cameraIDList = ucTrafficCameraTree1.GetCheckTCameraIDList();
            //开始查询 
            m_vm.Search(m_cameraIDList, startTime, endTime);
            this.searchBtn.Enabled = false;
        }

        private void ucTrafficFluxSearch_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            dateTimeStart.Value = DateTime.Now.AddHours(-1);
            dateTimeEnd.Value = DateTime.Now;
            m_vm = new TrafficFluxHistoryViewModel();
            m_vm.SearchFinished += ucTrafficSearchFinsh;
            m_searFinshFunc += new SearchFinshInvoke(SearchFinshFunc);
			SetTreeArg();
			ucTrafficCameraTree1.InitTree();
        }

        void ucTrafficSearchFinsh(object TrafficInfoListObj, EventArgs e)
        {
            Invoke(m_searFinshFunc, TrafficInfoListObj);
        }

        private void SearchFinshFunc(object TrafficInfoListObj)
        {
			dataGridViewX1.Rows.Clear();
            List<TrafficFluxHistoryInfo> TrafficList = (List<TrafficFluxHistoryInfo>)TrafficInfoListObj;
            if (TrafficList.Count == 0)
            {
                this.searchBtn.Enabled = true;
                MyLog4Net.Container.Instance.Log.Debug("ucTrafficFluxSearch SearchFinshFunc " + " not have any Data");
				noDataLabel.Visible = true;
                return;
            }
            MyLog4Net.Container.Instance.Log.Debug("ucTrafficEventSearch SearchFinshFunc end");
            foreach (var item in TrafficList)
            {
				dataGridViewX1.Rows.Add(item.CameraID,
                                      Common.ConvertLinuxTime(item.StatiIctisTime),
                                      item.RoadWayNum,
                                      item.TrafficFluxBig,
                                      item.TrafficFluxMiddle,
                                      item.TrafficFluxSmall,
                                      item.TrafficFlux,
                                      item.AvgVehiSpeed,
                                      item.AvgOccupyRatio,
                                      item.QueueLen,
                                      item.AvgVehiDistance);
            }
            this.searchBtn.Enabled = true;
            MyLog4Net.Container.Instance.Log.Debug("ucTrafficEventSearch SearchFinshFunc Add Data End");
        }

        public void Clear()
        {
            m_vm.SearchFinished -= ucTrafficSearchFinsh;
            m_searFinshFunc -= new SearchFinshInvoke(SearchFinshFunc);
        }

		private void reSet_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX1_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-12);
			dateTimeEnd.Value = DateTime.Now;
		}
    }
}
