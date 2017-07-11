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

namespace IVX.Live.MainForm.View
{
    public partial class ucCrowdHistory : UserControl
    {
        CrowdViewModel m_crowdVM;
        SearchItemV3_1  cameraItem;
        public ucCrowdHistory()
        {
            InitializeComponent();
        }

        private void ucCrowdHistory_Load(object sender, EventArgs e)
        {
            m_crowdVM = new CrowdViewModel();
            m_crowdVM.SearchFinished  += ucCrowdSearchFinsh;
            dateTimeStart.Value = DateTime.Now.AddHours(-1);
            dateTimeEnd.Value   = DateTime.Now;
			SetTreeArg();
			m_crowdCamerTree.InitTree();
			
        }

		private void SetTreeArg() {
			if (DesignMode) return;
			m_crowdCamerTree.HasRootNode = false;
			m_crowdCamerTree.HasCheck = true;
			//大客流
			m_crowdCamerTree.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD;
			m_crowdCamerTree.HasHistoryTask = false;
			m_crowdCamerTree.TreeTitle = "历史大客流监控点";
		}

		public void RefreshTaskRoot() 
		{

		}

        // 查询 返回函数
        void ucCrowdSearchFinsh(object corwdInfoObj, EventArgs e)
        {
            m_crowdVM.Stop();
            List<CrowdInfo> crowdInfoList = (List<CrowdInfo>)corwdInfoObj;
            if(crowdInfoList.Count == 0) 
            {
                MessageBoxEx.Show("大客流历史-查询错误:无结果数据", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MyLog4Net.Container.Instance.Log.Debug("ucCrowdHistory SearchFinsh "+" not have any Data");
                return;
            }

            else if (crowdInfoList.Count == 1)
            {
                if (crowdInfoList[0].CameraID == "OutTime")
                {
                    MessageBoxEx.Show("大客流历史-查询错误:连接服务超时", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    MyLog4Net.Container.Instance.Log.Debug("ucCrowdHistory SearchFinsh outTime");
                    return;
                }
            }
            string cameraId = crowdInfoList[0].CameraID;
            crowdInfoList[0].CameraID = cameraItem.CameraName;
            m_crowdSingleHistory.RefreshInfo(crowdInfoList);
            MyLog4Net.Container.Instance.Log.Debug("ucCrowdHistory SearchFinsh " + cameraId);
        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            StopThread();
            m_crowdVM.SearchFinished -= ucCrowdSearchFinsh;
        }

        public void StopThread()
        {
            if (m_crowdSingleHistory != null)
            {
                m_crowdSingleHistory.Stop();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            StopThread();
			if (!m_crowdCamerTree.IsHasChecked)
            {
                MessageBoxEx.Show("请选择一个查询目标");
                return;
            }
            // 根据选中的个数 添加 tableItem
            var serList = m_crowdCamerTree.GetCheckTSearchList();
			if (serList.Count > 0) {
				cameraItem = serList[0];
				Start();
			}
        }

        private void Start()
        {
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
            try
            {
                m_crowdVM.Start(startTime, endTime, cameraItem);
            }
            catch (SDKCallException ex)
            {
                //请求出错 终止线程 
                m_crowdVM.Stop();
                MessageBoxEx.Show("大客流历史-查询错误[" + ex.ErrorCode + "]:" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MyLog4Net.Container.Instance.Log.Debug("ucCrowdHistory searchBtn_Click" + ex.ToString());
            }
        }
        public void StartWithTaskAction(SearchItemV3_1 item)
        {
            StopThread();
            cameraItem = item;
            Start();
        }
    }
}
