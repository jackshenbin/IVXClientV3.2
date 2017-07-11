using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SingleSearchResultPanelViewModel
    {
        public event EventHandler SearchFinished;
        private int m_pageCount = 25;

        public int PAGE_COUNT
        {
            get { return m_pageCount; }
            set { if(value>=16)m_pageCount = value; }
        }
        private int m_pageIndex = 0;
        public uint SearchHandle { get; set; }
        //public string SearchCameraId { get; set; }
        public bool CanPriv { get; set; }
        public bool CanNext { get; set; }
        private SearchViewModelBase SearchVM { get; set; }
        public List<SearchResultRecordV3_1> SearchResult { get; set; }
        public int TotalPageCount
        {
            get
            {
                if (SearchResult != null && SearchResult.Count > 0)
                {
                    return (SearchResult.Count % m_pageCount ==0 )?(SearchResult.Count / m_pageCount)-1: SearchResult.Count / m_pageCount;
                }
                else
                    return 0;
            }
        }

        public int TotalCount
        { 
            get
            {
                if(SearchResult!=null && SearchResult.Count>0)
                    return SearchResult.Count;
                else
                    return 0;
            }
        }
        public E_VDA_SEARCH_STATUS SearchStatus { get; set; }
        public SingleSearchResultPanelViewModel()
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Subscribe(OnSearchResultReturned, Microsoft.Practices.Prism.Events.ThreadOption.PublisherThread);   
            
        }

        public void OnSearchResultReturned(SearchResultSummaryV3_1 summary)
        {
            //if(summary.SearchItem.CameraID == SearchCameraId)
            if (summary.SearchSessionID == SearchHandle)
            {
                SearchResult = summary.SearchResultSingleSummaryList;
                SearchVM = (SearchViewModelBase)summary.SearchVM;
                SearchStatus = summary.SearchStatus;
                m_pageIndex = 0;
                if (SearchFinished!=null)
                {
                    SearchFinished(this, null); 
                }
            }
        }
        public List<SearchResultRecordV3_1> FirstPage()
        {
            m_pageIndex = 0;
            return GetSearchResultDetail();
        }
        public List<SearchResultRecordV3_1> LastPage()
        {
            m_pageIndex = TotalPageCount;
            return GetSearchResultDetail();
        }

        public List<SearchResultRecordV3_1> NextPage()
        {
            m_pageIndex++;
            if (m_pageIndex > TotalPageCount)
                m_pageIndex = TotalPageCount;
            return GetSearchResultDetail();
        }

        public List<SearchResultRecordV3_1> PrivPage()
        {
            m_pageIndex--;
            if (m_pageIndex < 0)
                m_pageIndex = 0;

            return GetSearchResultDetail();
        }

        private List<SearchResultRecordV3_1> GetSearchResultDetail()
        {

            if (SearchVM == null)
                return new List<SearchResultRecordV3_1>();

            int startindex = m_pageIndex * m_pageCount;
            int getcount = m_pageCount;
            var start = SearchResult.ElementAtOrDefault(startindex);
            var end = SearchResult.ElementAtOrDefault(startindex + getcount);
            if (start == null)
                return new List<SearchResultRecordV3_1>();
            if (end == null)
                getcount = SearchResult.Count - startindex;

            List < SearchResultRecordV3_1 > detail = SearchResult.GetRange(startindex, getcount);
            List<SearchResultRecordV3_1> tempdetail = SearchVM.GetSearchResultDetail(detail);
            detail.ForEach(item =>
            {
                MyLog4Net.Container.Instance.Log.Debug("item.ObjKey = " + item.ObjKey + " item.ObjType =" + item.ObjType);

                var find = tempdetail.SingleOrDefault(it => it.ObjKey == item.ObjKey && it.ObjType == item.ObjType);
                if(find!=null)
                {
                    var t = find;
                    if (t != null)
                    {
                        item.AdjustTime = t.AdjustTime;
                        item.BeginTime = t.BeginTime;
                        item.DownBodyColor = t.DownBodyColor;
                        item.DriverIsPhoneing = t.DriverIsPhoneing;
                        item.DriverIsPhoneingConf = t.DriverIsPhoneingConf;
                        item.DriverIsSafebelt = t.DriverIsSafebelt;
                        item.DriverIsSafebeltConf = t.DriverIsSafebeltConf;
                        item.DriverIsSunVisor = t.DriverIsSunVisor;
                        item.DriverIsSunVisorConf = t.DriverIsSunVisorConf;
                        item.EndTime = t.EndTime;
                        item.ObjDetailRect = t.ObjDetailRect;
                        item.ObjKey = t.ObjKey;
                        item.ObjRect = t.ObjRect;
                        item.ObjType = t.ObjType;
                        item.OriginalPicURL = t.OriginalPicURL;
                        item.PassengerIsSafebelt = t.PassengerIsSafebelt;
                        item.PassengerIsSafebeltConf = t.PassengerIsSafebeltConf;
                        item.PassengerIsSunVisor = t.PassengerIsSunVisor;
                        item.PassengerIsSunVisorConf = t.PassengerIsSunVisorConf;
                        item.PlateColor = t.PlateColor;
                        item.PlateNo = t.PlateNo;
                        item.PlateNumRow = t.PlateNumRow;
                        item.PlatePicURL = t.PlatePicURL;
                        item.PlateRect = t.PlateRect;
                        item.Similar = t.Similar;
                        item.ThumbPicURL = t.ThumbPicURL;
                        item.UpBodyColor = t.UpBodyColor;
                        item.VehicleColor = t.VehicleColor;
                        item.VehicleLabel = t.VehicleLabel;
                        item.VehicleLabelDetail = t.VehicleLabelDetail;
                        item.VehicleType = t.VehicleType;
                        item.VehicleTypeDetail = t.VehicleTypeDetail;
                        item.BegType = t.BegType;
                        item.CameraID = t.CameraID;
                    }
                }

            });
            detail.ForEach(item => { if (item.ThumbPic == null)item.ThumbPic = Common.GetImage(item.ThumbPicURL); });
            detail.ForEach(item => { if (item.PlatePic == null)item.PlatePic = Common.GetImage(item.PlatePicURL); });
            //detail.ForEach(item => item.OriginalPic = Common.GetImage(item.OriginalPicURL));
            return detail;
        }
        public SearchResultRecordV3_1 GetResultById(ulong ObjKey,E_SEARCH_RESULT_OBJECT_TYPE ObjType)
        {
            if (SearchResult == null)
                return null;
            var find = SearchResult.SingleOrDefault(it => it.ObjKey == ObjKey && it.ObjType == ObjType);
            return find;
        }
        public void GetResultDetail(SearchResultRecordV3_1 item)
        {
            if (string.IsNullOrEmpty(item.OriginalPicURL))
            {
                var t = SearchVM.GetSearchResultDetail(item);
                if (t != null)
                {
                    item.AdjustTime = t.AdjustTime;
                    item.BeginTime = t.BeginTime;
                    item.DownBodyColor = t.DownBodyColor;
                    item.DriverIsPhoneing = t.DriverIsPhoneing;
                    item.DriverIsPhoneingConf = t.DriverIsPhoneingConf;
                    item.DriverIsSafebelt = t.DriverIsSafebelt;
                    item.DriverIsSafebeltConf = t.DriverIsSafebeltConf;
                    item.DriverIsSunVisor = t.DriverIsSunVisor;
                    item.DriverIsSunVisorConf = t.DriverIsSunVisorConf;
                    item.EndTime = t.EndTime;
                    item.ObjDetailRect = t.ObjDetailRect;
                    item.ObjKey = t.ObjKey;
                    item.ObjRect = t.ObjRect;
                    item.ObjType = t.ObjType;
                    item.OriginalPicURL = t.OriginalPicURL;
                    item.PassengerIsSafebelt = t.PassengerIsSafebelt;
                    item.PassengerIsSafebeltConf = t.PassengerIsSafebeltConf;
                    item.PassengerIsSunVisor = t.PassengerIsSunVisor;
                    item.PassengerIsSunVisorConf = t.PassengerIsSunVisorConf;
                    item.PlateColor = t.PlateColor;
                    item.PlateNo = t.PlateNo;
                    item.PlateNumRow = t.PlateNumRow;
                    item.PlatePicURL = t.PlatePicURL;
                    item.PlateRect = t.PlateRect;
                    item.Similar = t.Similar;
                    item.ThumbPicURL = t.ThumbPicURL;
                    item.UpBodyColor = t.UpBodyColor;
                    item.VehicleColor = t.VehicleColor;
                    item.VehicleLabel = t.VehicleLabel;
                    item.VehicleLabelDetail = t.VehicleLabelDetail;
                    item.VehicleType = t.VehicleType;
                    item.VehicleTypeDetail = t.VehicleTypeDetail;

                }
            }

        }

        public TaskInfoV3_1 GetTaskInfo(uint taskid)
        {
            return Framework.Container.Instance.CommService.GET_TASK(taskid);
        }
        public void Clear()
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Unsubscribe(OnSearchResultReturned);
            if (SearchResult != null)
            {
                SearchResult.ForEach(item => item.Dispose());
                SearchResult = null;
            }
        }
    }
}