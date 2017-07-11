using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormPlayHistoryNew : IVX.Live.MainForm.UILogics.FormBase
    {
        private SearchMoveObjectViewModel m_viewModel;
        private SearchViewModelBase SearchVM { get; set; }
        private List<SearchResultRecordV3_1> SearchResult { get; set; }
        private SearchType SearchType { get; set; }
        private uint SearchHandle = 0;
        private E_VDA_SEARCH_STATUS SearchStatus { get; set; }
        private bool NeedShowTimeLine { get; set; }
        public FormPlayHistoryNew(DataModel.TaskInfoV3_1 task)
        {
            InitializeComponent();
            ucPlayHistory1.Task = task;
            ucPlayHistory1.VideoPos += ucPlayHistory1_VideoPos;
            timeTrackControl1.Tag = task;
            timeTrackControl1.OnDoubleClick += timeTrackControl1_OnDoubleClick;
            panel1.Visible = ucPlayHistory1.ShowGotoCompare = NeedShowTimeLine = task.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM);
            timeTrackControl1.TimeTrackModel = TimeTrackControl.TimeTrackModel.Seconds;
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Subscribe(OnSearchResultReturned, Microsoft.Practices.Prism.Events.ThreadOption.PublisherThread);
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchBeginEvent>().Subscribe(OnSearchBegin, Microsoft.Practices.Prism.Events.ThreadOption.PublisherThread);
        }

        void ucPlayHistory1_VideoPos(uint obj)
        {   
            if(NeedShowTimeLine)
            {
            DataModel.TaskInfoV3_1 task = timeTrackControl1.Tag as DataModel.TaskInfoV3_1;

            timeTrackControl1.CurrentTime = task.StartTime.AddSeconds(obj);
            }
        }

        void timeTrackControl1_OnDoubleClick(TimeTrackControl.TimeTrackControl.TrackObjectDoubleClickEventArgs obj)
        {
            ucPlayHistory1.SetPos(obj.CurrentTime);
            //string msg = "";
            //if (obj.SelectedObject != null)
            //    msg = string.Format("time = {0}, obj = id:{1},appeartime:{2}", obj.CurrentTime.ToString("yyyy-MM-dd HH:mm:ss"), obj.SelectedObject.UserData, obj.SelectedObject.AppearTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //else
            //    msg = string.Format("time = {0}, obj = null", obj.CurrentTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //MessageBox.Show(msg);

        }
        private void OnSearchBegin(SearchItemGroup items)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<SearchItemGroup>(OnSearchBegin), items);
            }
            else
            {
                if (items.SearchType == SearchType)
                {
                    DataModel.TaskInfoV3_1 task = timeTrackControl1.Tag as DataModel.TaskInfoV3_1;

                    foreach (var item in items.SearchItems)
                    {
                        if (task.TaskId == item.TaskId)
                        {
                            SearchHandle = item.SearchHandle;
                            DateTime end = (task.EndTime - task.StartTime).TotalMinutes > 30 ? task.EndTime : task.StartTime.AddMinutes(30);
                            timeTrackControl1.Init(task.StartTime, end);
                            break;
                        }
                    }
                }
            }
        }

        private void OnSearchResultReturned(SearchResultSummaryV3_1 summary)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<SearchResultSummaryV3_1>(OnSearchResultReturned), summary);
            }
            else
            {
                //if(summary.SearchItem.CameraID == SearchCameraId)
                if (summary.SearchSessionID == SearchHandle)
                {
                    SearchResult = summary.SearchResultSingleSummaryList;
                    SearchVM = (SearchViewModelBase)summary.SearchVM;
                    SearchStatus = summary.SearchStatus;
                    List<TimeTrackControl.TimeTrackObject> list = new List<TimeTrackControl.TimeTrackObject>();
                    foreach (var item in SearchResult)
                    {
                        list.Add(new TimeTrackControl.TimeTrackObject() { AppearTime = item.BeginTime.Add(item.AdjustTime.Subtract(new DateTime())), DisppearTime = item.EndTime.Add(item.AdjustTime.Subtract(new DateTime())), ObjectTime = item.BeginTime, UserData = item, });
                    }
                    timeTrackControl1.SetTimetrackObject(list);
                    labelPerson.Text = "行人 ： " + SearchResult.Count(item => item.ObjType == E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_PASSAGER);
                    labelVehclie.Text = "车辆 ： " + SearchResult.Count(item => item.ObjType == E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_VEHICLE);
                    labelTwowheel.Text = "两轮车 ： " + SearchResult.Count(item => item.ObjType == E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_TWOWHEEL);
                }
            }
        }
        private void FormSingleTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            m_viewModel = new SearchMoveObjectViewModel();
            SearchType = DataModel.SearchType.VideoPlayNormal;
            m_viewModel.SearchFinished += m_viewModel_SearchFinished;
            m_viewModel.ObjFilterType = DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_PASSAGER
                | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_VEHICLE
                | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_OTHER
                | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_TWOWHEEL;
            new System.Threading.Thread(() => { System.Threading.Thread.Sleep(200); DoPlay(); }).Start();
        }
        private void DoPlay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(DoPlay));
            }
            else
            {
                StartGetTimeline();
            }
        }

        void m_viewModel_SearchFinished(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler(m_viewModel_SearchFinished), sender, e);
            }
            else
            {
                timeTrackControl1.Enabled = true;
            }
        }
        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucPlayHistory1.Clear();
        }

        private void ucPlayHistory1_CloseThis(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartGetTimeline()
        {
            if (!NeedShowTimeLine)
                return;

            DataModel.TaskInfoV3_1 task = timeTrackControl1.Tag as DataModel.TaskInfoV3_1;
            m_viewModel.SearchItems = new DataModel.SearchItemGroup()
            {
                SearchItems = new List<DataModel.SearchItemV3_1>(),
                SearchType = this.SearchType,
            };
                m_viewModel.SearchItems.SearchItems.Add(task.ToSearchItem());

                m_viewModel.PassLineSet = new List<PassLine>();
                m_viewModel.RegionSet = new List<BreakRegion>();
                m_viewModel.PictureData = new System.Drawing.Bitmap(1, 1);
                m_viewModel.StartTime = DataModel.Common.ZEROTIME;
            m_viewModel.StopTime = DataModel.Common.MAXTIME;
            timeTrackControl1.Enabled = false;
            string msg = "";
            if (m_viewModel.Commit(out msg))
            {

            }
            else
            {
                timeTrackControl1.Enabled = false;
                labelMsg.Text = msg;
            }
        }


       

    }
}
