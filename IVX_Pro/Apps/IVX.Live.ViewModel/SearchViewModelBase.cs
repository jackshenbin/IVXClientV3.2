using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.ViewModel
{
    public class SearchViewModelBase:INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        private SearchServices.SearchServices m_SearchService = null;

        private SearchParaV3_1 m_searchParam;
        private uint m_searchHandle;
        private bool m_isInited = false;

        //Crowd
        private System.Threading.Thread thCrowdRealtime;
        private bool isRunRealTh;
        public string CameraId { get; set; }
        public uint RealThreadTime { get; set;}

        //Traffic 
        public string TraffficCameraId { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec { get; set; }
        public UInt32 TimeInterval { get; set; }
        public string EventTypeList { get; set; }

		// Behavior
		public string BehaviorCameraId { get; set; }
        private SearchServices.SearchServices SearchService
        {
            get
            {
                if (m_SearchService == null)
                {
                    m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
                }
                return m_SearchService;
            }
        }
		// Face 
		public string FaceCameraId { get; set; }
		public string BlackListStr { get; set; }

        public SearchItemV3_1 SearchItem { get; set; }

        public SearchViewModelBase(string serverIp,uint serverPort)
        {
           SearchService.Init(serverIp, serverPort);
           SearchService.SearchFinished += SearchService_SearchFinished;
            m_isInited = true;
            // Crowd
            thCrowdRealtime = null;
            isRunRealTh = false;
            RealThreadTime = 30;
        }

        void SearchService_SearchFinished(SearchResultSummaryV3_1 obj,string serverIp)
        {
            if (obj.SearchSessionID == m_searchHandle)
            {
                SearchResultSummaryV3_1 summary = new SearchResultSummaryV3_1()
                {
                    SearchPara = m_searchParam,
                    SearchSessionID = m_searchHandle,
                    SearchResultSingleSummaryList = obj.SearchResultSingleSummaryList,
                    SearchVM = this,
                    SearchItem = this.SearchItem,
                    SearchStatus = obj.SearchStatus,
                     ObjectRect = obj.ObjectRect,
                };
                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Publish(summary);
            }
        }
        public void SearchReady()
        {
            SearchService.ReadyList.Add(m_searchHandle);
        }

        public uint StartSearch(SearchParaV3_1 param)
        {
            m_searchParam = param;
            param.CameraID = SearchItem.CameraID;
            m_searchHandle = 0;
            if(SearchItem.IsHistoryTask)
            {
                if (param.StartTime != DataModel.Common.ZEROTIME)
                {
                    if (param.StartTime < SearchItem.AdjustTime)
                        param.StartTime = Common.ZEROTIME;
                    else
                        param.StartTime = Common.ZEROTIME.AddSeconds(param.StartTime.Subtract(SearchItem.AdjustTime).TotalSeconds);
                }
                if (param.EndTime != DataModel.Common.MAXTIME)
                {
                    if (param.EndTime < SearchItem.AdjustTime)
                        param.EndTime = Common.ZEROTIME;
                    else
                        param.EndTime = Common.ZEROTIME.AddSeconds(param.EndTime.Subtract(SearchItem.AdjustTime).TotalSeconds);
                }
                param.ResultNumRange = int.MaxValue;
            }
            var comparesort = (E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL | E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL | E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PASSLINE);
            param.SortType = (((E_SEARCH_FEATURE_TYPE)param[SDKConstant.FeatureType] & comparesort) > 0) ? SortType.SimilarityDes : SortType.TimeAsc;

            if (((E_SEARCH_FEATURE_TYPE)param[SDKConstant.FeatureType] & E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL) > 0
                 && ((E_SEARCH_FEATURE_TYPE)param[SDKConstant.FeatureType] & E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL) > 0)
            {
                param[SDKConstant.FeatureType] = (E_SEARCH_FEATURE_TYPE)param[SDKConstant.FeatureType] ^ E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL;
            }
            if (m_isInited)
                m_searchHandle = SearchService.ADD_TASK(param,SearchItem);
            return m_searchHandle;
        }
        public SearchResultRecordV3_1 GetSearchResultDetail(SearchResultRecordV3_1 record)
        {
            List<SearchResultRecordTiny> listTiny = new List<SearchResultRecordTiny>();
            listTiny.Add(new SearchResultRecordTiny
            {
                AdjustTime = record.AdjustTime,
                ObjectDetailRect = record.ObjDetailRect,
                ObjectKey = record.ObjKey,
                ObjectType = record.ObjType,
                Similar = record.Similar,
                TargetEndTs = record.EndTime,
                TargetStartTs = record.BeginTime,
            });
            var list = SearchService.GET_OBJ_DETAIL_INFO(m_searchParam.CameraID, m_searchHandle, listTiny);
            if (list != null && list.Count > 0)
            {
                return  list[0];
            }
            return null;
        }
        public List<SearchResultRecordV3_1> GetSearchResultDetail(List<SearchResultRecordV3_1> recordlist)
        {
            List<SearchResultRecordTiny> listTiny = new List<SearchResultRecordTiny>();
            foreach (var record in recordlist)
            {
                if (string.IsNullOrEmpty(record.OriginalPicURL))
                {
                    listTiny.Add(new SearchResultRecordTiny
                    {
                        AdjustTime = record.AdjustTime,
                        ObjectDetailRect = record.ObjDetailRect,
                        ObjectKey = record.ObjKey,
                        ObjectType = record.ObjType,
                        Similar = record.Similar,
                        TargetEndTs = record.EndTime,
                        TargetStartTs = record.BeginTime,
                    });
                }
            }
            var list = SearchService.GET_OBJ_DETAIL_INFO(m_searchParam.CameraID, m_searchHandle, listTiny);

            return list;
        }

        public void ClosetSearch()
        {
            m_searchParam = null;
            if (m_isInited)
                SearchService.SearchFinished -= SearchService_SearchFinished;

            //    SearchService.DEL_TASK(m_searchHandle);
        }

        #region SearchCrowd
        public void StartCrowdRealtime(string cameraId)
        {
            CameraId = cameraId;
            if (thCrowdRealtime == null)
            {
                thCrowdRealtime = new System.Threading.Thread(thGetCrowdRealtime);
                isRunRealTh = true;
                // if Create thCrowdRealtime error
                //else run thCrowdRealtime
                thCrowdRealtime.Start();
            }
        }

        public void thGetCrowdRealtime(object cameraId)
        {
            while (isRunRealTh)
            {
                try
                {
                    CrowdInfo crowdInfo = SearchService.GET_HOTIMAGE_REAL_DATA(CameraId);
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdRealTimeEvent>().Publish(crowdInfo);
                    // publish Event
                    for (int i = 0; i < RealThreadTime; i++)
                    {
                        if (isRunRealTh)
                            System.Threading.Thread.Sleep(100);
                        else
                            break;
                    } 
                }
                catch (SDKCallException ex)
                {
                    CrowdInfo crowdInfo = new CrowdInfo();
                    crowdInfo.CameraID = "SDKError";
                    crowdInfo.DirectionImageURL = "大客流实时-查询错误[" + ex.ErrorCode + "]:" + ex.Message;
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdRealTimeEvent>().Publish(crowdInfo);
                    break;
                }
            }
            isRunRealTh = false;
            // set RealTime thread
            thCrowdRealtime = null;
        }

        public void StopCrowdRealtime()
        {
             isRunRealTh = false;
        }

        public void StartCrowd(UInt32 startTime, UInt32 endTime, string cameraId)
        {
            List<CrowdInfo> crowdInfoList = SearchService.GET_HOTIMAGE_HISTORY_DATA(startTime, endTime, cameraId);
            if (crowdInfoList == null)
            {
                crowdInfoList = new List<CrowdInfo> { };
                CrowdInfo info = new CrowdInfo();
                info.CameraID = "OutTime";
                crowdInfoList.Add(info);
            }
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdEvent>().Publish(crowdInfoList);
        }

        public void StopCrowd()
        {

        }

        public void StartCrowdReport(UInt32 startTime, UInt32 endTime, string cameraId, UInt32 timeInterVel)
        {
            List<CrowdStatistic> crowdStatisticList = SearchService.GET_HOTIMAGE_REPORT_DATA(startTime, endTime, cameraId, timeInterVel);

            if (crowdStatisticList == null)
            {
                crowdStatisticList = new List<CrowdStatistic> { };
                CrowdStatistic info = new CrowdStatistic();
                info.CameraID = "OutTime";
                crowdStatisticList.Add(info);
            }
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<CrowdReportEvent>().Publish(crowdStatisticList);
        }

        public void StopCrowdReport()
        {

        }

        #endregion

        #region SearchTraffic
        // 查詢交通歷史事件
        public List<TrafficeEventInfoV3_1> SearchTrafficEvent(string cameraId, UInt32 BeginTimeSec, UInt32 EndTimeSec, string EventTypeList)
        {
            List<TrafficeEventInfoV3_1> trafficInfoList = null;
            try
            {
                if (cameraId.Contains("ip"))
                {
                    trafficInfoList = SearchService.GET_TRAFFIC_EVENT_DATA("", BeginTimeSec, EndTimeSec, EventTypeList);
                }
                else
                {
                    trafficInfoList = SearchService.GET_TRAFFIC_EVENT_DATA(cameraId, BeginTimeSec, EndTimeSec, EventTypeList);
                }
            }
            catch(Exception ex)
            {
				MyLog4Net.Container.Instance.Log.Debug("Error SearchViewModelBase SearchTrafficEvent:" + ex.ToString());
            }
            return trafficInfoList;
        }
        //查询交通流量历史
        public List<TrafficFluxHistoryInfo> SearchTrafficFlux(string cameraId, UInt32 BeginTimeSec, UInt32 EndTimeSec)
        {
           List<TrafficFluxHistoryInfo> trafficInfoList = null;
           try
           {
                if (cameraId.Contains("ip"))
                {
                    trafficInfoList = SearchService.GET_TRAFFICFLUX_HISTORY_DATA("", BeginTimeSec, EndTimeSec);
                }
                else
                {
                    trafficInfoList = SearchService.GET_TRAFFICFLUX_HISTORY_DATA(cameraId, BeginTimeSec, EndTimeSec);
                }
            }
            catch(Exception ex)
            {
				MyLog4Net.Container.Instance.Log.Debug("Error SearchViewModelBase SearchTrafficFlux:" + ex.ToString());
            }
            return trafficInfoList;
        }

        //查询交通流量历史
        public List<TrafficFluxStatisticInfo> SearchTrafficFluxStatistic(string cameraId, UInt32 BeginTimeSec, UInt32 EndTimeSec, UInt32 TimeInterval)
        {
            List<TrafficFluxStatisticInfo> trafficInfoList = null;
            try
            {
                trafficInfoList = SearchService.GET_TRAFFICFLUX_STATISTIC_DATA(cameraId, BeginTimeSec, EndTimeSec, TimeInterval);
            }
            catch (Exception ex)
            {
				MyLog4Net.Container.Instance.Log.Debug("Error SearchViewModelBase SearchTrafficFluxStatistic:" + ex.ToString());
            }
            return trafficInfoList;
        }
        #endregion

		#region SearchBehavior
		// 行为历史事件
		public List<BehaviorInfo> SearchBehaviorHistoryEvent(string cameraId, UInt32 BeginTimeSec, UInt32 EndTimeSec, string EventTypeList)
		{
			List<BehaviorInfo> behaviorInfoList = null;
			try 
			{
				if (cameraId.Contains("ip")) {
					behaviorInfoList = SearchService.GET_BEHAVIOUR_HISTORY_DATA("", BeginTimeSec, EndTimeSec, EventTypeList);
				}
				else {
					behaviorInfoList = SearchService.GET_BEHAVIOUR_HISTORY_DATA(cameraId, BeginTimeSec, EndTimeSec, EventTypeList);
				}
			}
			catch (Exception ex)
			{
				MyLog4Net.Container.Instance.Log.Debug("Error SearchViewModelBase SearchBehaviorHistoryEvent:" + ex.ToString());
			}
			return behaviorInfoList;
		}
		#endregion

		#region SearchFace
		public List<FaceAlarmInfoV3_1> SearchFaceAlarm(string cameraId, UInt32 BeginTimeSec, UInt32 EndTimeSec, string BlackListStr) {
			List<FaceAlarmInfoV3_1> FaceAlarmList = null;
			try {
				FaceAlarmList = SearchService.GET_FACE_ALARM_HISTORY_DATA(cameraId, BeginTimeSec, EndTimeSec, BlackListStr);
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error SearchViewModelBase SearchFaceAlarm:" + ex.ToString());
			}
			return FaceAlarmList;
		}
		#endregion

	}
}
