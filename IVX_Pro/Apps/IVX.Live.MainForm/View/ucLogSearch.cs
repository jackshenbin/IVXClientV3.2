using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;
using DevComponents.DotNetBar;

namespace IVX.Live.MainForm.View {

	public partial class ucLogSearch : UserControl {
		public LogViewModel m_Vm;
		SearchFinshInvoke m_searFinshFunc;
		LogSearchParam m_parm;
		private bool SearchStart;

		public ucLogSearch() {
			InitializeComponent();
			SearchStart = false;
		}

		private void searchBtn_Click(object sender, EventArgs e) 
		{
			noDataLabel.Visible = false;
			searchBtn.Enabled = false;
			// 清除上次查询的数据
			logDataList.Rows.Clear();
			m_parm = new LogSearchParam();
			m_parm.BeginTime = dateTimeStart.Value;
			m_parm.EndTime   = dateTimeEnd.Value;
			CheckTime ret = DataModel.Common.CheckDataTime(dateTimeStart.Value, dateTimeEnd.Value);
			if (ret == CheckTime.START_INVALID) {
				MessageBox.Show("开始时间不正常!");
				return;
			}
			else if (ret == CheckTime.END_INVALID) {
				MessageBox.Show("结束时间不正常!");
				return;
			}
			m_parm.LogLevel  = GetLogLevel();
			m_parm.LogType   = GetLogType();
			// 默认使用降序
			m_parm.SortKind  = E_VDA_LOG_SORT_TYPE.E_LOG_SORT_TYPE_TIME_DESC;
			m_parm.OptName = this.opeName.Text;
			m_parm.StartMum = 0;
			m_parm.LogCount = 100;
			m_Vm.GetLogInfoList(m_parm);
			SearchStart = true;
		}

		private void ucLogSearch_Load(object sender, EventArgs e) {
			logTypeComb.SelectedIndex = 0;
			logLevelcomb.SelectedIndex = 0;

			if ((E_VDA_USER_ROLE_TYPE)Framework.Environment.CurUserInfo.UserRoleType == E_VDA_USER_ROLE_TYPE.E_ROLE_TYPE_NORMAL) 
			{
				labelX1.Visible = false;
				opeName.Visible = false;
				this.opeName.Text = Framework.Environment.CurUserInfo.UserName;
			}

			m_Vm = new LogViewModel();
			m_Vm.SearchFinished += SearchFinsh;
			m_searFinshFunc += new SearchFinshInvoke(SearchFinshInvokeFun);
			dateTimeStart.Value = DateTime.Now.AddDays(-1);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void SearchFinsh(object logInfoListObj,EventArgs e)
		{
			Invoke(m_searFinshFunc, logInfoListObj);
		}

		public void Clear()
		{
			m_Vm.Clear();
		}

		private void SearchFinshInvokeFun(object logInfoListObj) 
		{
			searchBtn.Enabled = true;
			List<LogSearchResultInfo> logInfoList = (List<LogSearchResultInfo>)logInfoListObj;
			if (logInfoList == null) {
				SearchStart = false;
				if (logDataList.Rows.Count == 0) {
					noDataLabel.Visible = true;
				}
				return;
			}
			else if (logInfoList.Count == 1) {
				SearchStart = false;
				if (logInfoList[0].OptName == "SDKError") {
					if (logDataList.Rows.Count == 0) {
						noDataLabel.Visible = true;
					}
					return;
				}
			}

			//展示 查询 结果
			foreach (var logItem in logInfoList) {
				logDataList.Rows.Add(logItem.OptName,
									 logItem.LogTime,
									 DataModel.Constant.LogLevelInfos.Single(item => item.Type == logItem.Level).Name,
									 DataModel.Constant.LogTypeInfos.Single(item => item.Type == logItem.LogType).Name,
									 logItem.Description);
			}
			m_Vm.Stop();
			
		}


		private E_VDA_LOG_TYPE GetLogType() 
		{
			switch (logTypeComb.SelectedIndex)
			{
				case 0:
					return E_VDA_LOG_TYPE.E_LOG_TYPE_NOUSE;
				case 1:
					return E_VDA_LOG_TYPE.E_LOG_TYPE_SYSTEM;	
				case 2:
					return E_VDA_LOG_TYPE.E_LOG_TYPE_OPERATE;
				case 3:
					return E_VDA_LOG_TYPE.E_LOG_TYPE_MANAGER;
			    default:
					return E_VDA_LOG_TYPE.E_LOG_TYPE_NOUSE;
			}
		}

		private E_VDA_LOG_LEVEL GetLogLevel() 
		{
			switch (logLevelcomb.SelectedIndex)
			{
				case 0:
					return E_VDA_LOG_LEVEL.E_LOG_LEVEL_NOUSE;
				case 1:
					return E_VDA_LOG_LEVEL.E_LOG_LEVEL_COMMON;
				case 2:
					return E_VDA_LOG_LEVEL.E_LOG_LEVEL_WARN;
				case 3:
					return E_VDA_LOG_LEVEL.E_LOG_LEVEL_ERROR;
				default:
					return E_VDA_LOG_LEVEL.E_LOG_LEVEL_NOUSE;
			}
		}

		private void logDataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void logDataList_Scroll(object sender, ScrollEventArgs e)
		{
			if (!SearchStart) return;

			// 如果已加载到底部 
			if(e.ScrollOrientation == ScrollOrientation.VerticalScroll
				&& (e.NewValue + logDataList.DisplayedRowCount(false) == logDataList.Rows.Count)) 
			{
				m_parm.StartMum += 100;
				m_Vm.GetLogInfoList(m_parm);
			}
		}

		private void logDataList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{

		}
	}
}
