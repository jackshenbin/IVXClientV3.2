using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.WebViewModel
{
    public class SearchMoveObjectWebViewModel
    {

        Dictionary<Tuple<uint, string>, SearchResultSummaryV3_1> searchlist = new Dictionary<Tuple<uint, string>, SearchResultSummaryV3_1>();

        public SearchResultSummaryV3_1 StartSearch(string serverIp, uint serverPort, SearchItemV3_1 searchItem, SearchParaV3_1 param)
        {
            SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
            m_SearchService.Init(serverIp, serverPort);
            m_SearchService.SearchFinished += SearchService_SearchFinished;

            param.CameraID = searchItem.CameraID;
            if (searchItem.IsHistoryTask)
            {
                if (param.StartTime != DataModel.Common.ZEROTIME)
                {
                    if (param.StartTime < searchItem.AdjustTime)
                        param.StartTime = Common.ZEROTIME;
                    else
                        param.StartTime = Common.ZEROTIME.AddSeconds(param.StartTime.Subtract(searchItem.AdjustTime).TotalSeconds);
                }
                if (param.EndTime != DataModel.Common.MAXTIME)
                {
                    if (param.EndTime < searchItem.AdjustTime)
                        param.EndTime = Common.ZEROTIME;
                    else
                        param.EndTime = Common.ZEROTIME.AddSeconds(param.EndTime.Subtract(searchItem.AdjustTime).TotalSeconds);
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
            uint m_searchHandle = m_SearchService.ADD_TASK(param, searchItem);
                searchlist.Add(new Tuple< uint,string>(m_searchHandle,serverIp), new SearchResultSummaryV3_1()
                {
                    SearchPara = param,
                    SearchSessionID = m_searchHandle,
                    SearchResultSingleSummaryList = null,
                    SearchVM = this,
                    SearchItem = searchItem,
                    SearchStatus =  E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_RUNING,
                    ObjectRect =  "",
                });
                DateTime st = DateTime.Now;
            while(true)
            {
                if (searchlist[new Tuple<uint, string>(m_searchHandle, serverIp)].SearchResultSingleSummaryList != null)
                    break;
                if (DateTime.Now.Subtract(st).TotalSeconds > 60)
                    break;
            }
            return searchlist[new Tuple<uint, string>(m_searchHandle, serverIp)];
        }
        public SearchResultRecordV3_1 GetSearchResultDetail(string serverIp, uint serverPort, string cameraId, uint matchTaskId, SearchResultRecordV3_1 record)
        {
            SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
            m_SearchService.Init(serverIp, serverPort);

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
            var list = m_SearchService.GET_OBJ_DETAIL_INFO(cameraId, matchTaskId, listTiny);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            return null;
        }
        public List<SearchResultRecordV3_1> GetSearchResultDetail(string serverIp, uint serverPort, string cameraId, uint matchTaskId, List<SearchResultRecordV3_1> recordlist)
        {
            SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
            m_SearchService.Init(serverIp, serverPort);

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
            var list = m_SearchService.GET_OBJ_DETAIL_INFO(cameraId, matchTaskId, listTiny);

            return list;
        }

        void SearchService_SearchFinished(SearchResultSummaryV3_1 obj,string serverip)
        {
            if(searchlist.ContainsKey(new Tuple< uint,string>(obj.SearchSessionID,serverip)))
            {
                searchlist[new Tuple<uint, string>(obj.SearchSessionID, serverip)].SearchResultSingleSummaryList = obj.SearchResultSingleSummaryList;
                searchlist[new Tuple<uint, string>(obj.SearchSessionID, serverip)].ObjectRect = obj.ObjectRect;
                searchlist[new Tuple<uint, string>(obj.SearchSessionID, serverip)].SearchStatus = obj.SearchStatus;
            }
        }
    }
}
