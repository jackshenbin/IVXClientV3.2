using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.ViewModel
{
    public class SearchMoveObjectViewModel
    {
        public event EventHandler SearchFinished;
        private Dictionary<string, bool> m_requestList = new Dictionary<string, bool>();
        public uint UpBodyColors
        {
            get { return Convert.ToUInt32(m_searchParam[SDKConstant.UpBodyColor]); }
            set { m_searchParam[SDKConstant.UpBodyColor] = value; }
        }
        public uint DownBodyColors
        {
            get { return Convert.ToUInt32(m_searchParam[SDKConstant.DownBodyColor]); }
            set { m_searchParam[SDKConstant.DownBodyColor] = value; }
        }
        public E_MOVE_OBJ_PEOPLE_BAG_TYPE PeopleBagType
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.BagType]);
                return (temp == int.MaxValue) ? E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_NOUSE : (E_MOVE_OBJ_PEOPLE_BAG_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.BagType]
                    = (value == E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }

        public E_DRIVER_FEATURE_TYPE DriverIsPhoneing
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.DriverIsPhoneing]);
                return (temp == int.MaxValue) ? E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE : (E_DRIVER_FEATURE_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.DriverIsPhoneing] 
                    = (value == E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public E_DRIVER_FEATURE_TYPE DriverIsSafebelt
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.DriverIsSafebelt]);
                return (temp == int.MaxValue) ? E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE : (E_DRIVER_FEATURE_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.DriverIsSafebelt]
                    = (value == E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public E_DRIVER_FEATURE_TYPE DriverIsSunVisor
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.DriverIsSunVisor]);
                return (temp == int.MaxValue) ? E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE : (E_DRIVER_FEATURE_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.DriverIsSunVisor]
                    = (value == E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public E_DRIVER_FEATURE_TYPE PassengerIsSafebelt
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.PassengerIsSafebelt]);
                return (temp == int.MaxValue) ? E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE : (E_DRIVER_FEATURE_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.PassengerIsSafebelt]
                    = (value == E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public E_DRIVER_FEATURE_TYPE PassengerIsSunVisor
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.PassengerIsSunVisor]);
                return (temp == int.MaxValue) ? E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE : (E_DRIVER_FEATURE_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.PassengerIsSunVisor]
                    = (value == E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public uint PlateColor
        {
            get { return Convert.ToUInt32(m_searchParam[SDKConstant.PlateColor]); }
            set { m_searchParam[SDKConstant.PlateColor] = value; }
        }
        public string PlateNo
        {
            get {
 
                string temp= Convert.ToString(m_searchParam[SDKConstant.PlateNo]);
                if (temp == "11111111")
                    temp = "";
                return temp;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_searchParam[SDKConstant.PlateNo] = "11111111";
                else
                    m_searchParam[SDKConstant.PlateNo] = value;
            }
        }
        public E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE PlateNumRow
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.PlateNumRow]);
                return (temp == int.MaxValue) ? E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_NOUSE : (E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.PlateNumRow]
                    = (value == E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public uint VehicleColor
        {
            get { return Convert.ToUInt32(m_searchParam[SDKConstant.VehicleColor]); }
            set { m_searchParam[SDKConstant.VehicleColor] = value; }
        }
        public uint VehicleLabel
        {
            get { return Convert.ToUInt32(m_searchParam[SDKConstant.VehicleLabel]); }
            set { m_searchParam[SDKConstant.VehicleLabel] = value; }
        }
        public uint VehicleLabelDetail
        {
            get { return Convert.ToUInt32(m_searchParam[SDKConstant.VehicleLabelDetail]); }
            set { m_searchParam[SDKConstant.VehicleLabelDetail] = value; }
        }
        public E_VDA_SEARCH_VEHICLE_TYPE VehicleType
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.VehicleType]);
                return (temp == int.MaxValue) ? E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_NOUSE : (E_VDA_SEARCH_VEHICLE_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.VehicleType]
                    = (value == E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }
        public E_VDA_SEARCH_VEHICLE_DETAIL_TYPE VehicleTypeDetail
        {
            get
            {
                var temp = Convert.ToUInt32(m_searchParam[SDKConstant.VehicleTypeDetail]);
                return (temp == int.MaxValue) ? E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_NOUSE : (E_VDA_SEARCH_VEHICLE_DETAIL_TYPE)temp;
            }
            set
            {
                m_searchParam[SDKConstant.VehicleTypeDetail]
                    = (value == E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_NOUSE) ? int.MaxValue : (uint)value;
            }
        }

        public DateTime StartTime
        {
            get { return m_searchParam.StartTime; }
            set { m_searchParam.StartTime = value; }
        }
        public DateTime StopTime
        {
            get { return m_searchParam.EndTime; }
            set { m_searchParam.EndTime = value; }
        }

        public E_SEARCH_FEATURE_TYPE FeatureType
        {
            get { return (E_SEARCH_FEATURE_TYPE)(m_searchParam[SDKConstant.FeatureType]); }
            set { m_searchParam[SDKConstant.FeatureType] = value; }
        }

        public System.Drawing.Rectangle ObjDetailRect
        {
            get { return (System.Drawing.Rectangle)m_searchParam[SDKConstant.ObjDetailRect]; }
            set { m_searchParam[SDKConstant.ObjDetailRect] = value; }
        }

        public E_SEARCH_OBJ_FILTER_TYPE ObjFilterType
        {
            get { return (E_SEARCH_OBJ_FILTER_TYPE)(m_searchParam[SDKConstant.ObjFilterType]); }
            set { m_searchParam[SDKConstant.ObjFilterType] = value; }
        }

        public System.Drawing.Rectangle ObjRect
        {
            get { return (System.Drawing.Rectangle)m_searchParam[SDKConstant.ObjRect]; }
            set { m_searchParam[SDKConstant.ObjRect] = value; }
        }

        public System.Drawing.Image PictureData
        {
            get {
                byte[] imgbyte = Convert.FromBase64String(Convert.ToString(m_searchParam[SDKConstant.PictureData]));
                return Common.GetImage(imgbyte,imgbyte.Length);
            }
            set { m_searchParam[SDKConstant.PictureData] =Convert.ToBase64String( Common.ImageToJpegBytes( value)); }
        }


        public List<PassLine> PassLineSet
        {
            get { return m_searchParam[SDKConstant.PassLineSet] as List<PassLine>; }
            set { m_searchParam[SDKConstant.PassLineSet] = value; }
        }

        public List<BreakRegion> RegionSet
        {
            get { return m_searchParam[SDKConstant.RegionSet] as List<BreakRegion>; }
            set { m_searchParam[SDKConstant.RegionSet] = value; }
        }


        private SearchParaV3_1 m_searchParam;

        public SearchItemGroup SearchItems { get; set; }

        public SearchMoveObjectViewModel()
        {
            m_searchParam = new SearchParaV3_1();
            StopTime = DataModel.Common.MAXTIME;
            StartTime = DataModel.Common.ZEROTIME;


            UpBodyColors = 0x7fffffff;
            DownBodyColors = 0x7fffffff;
            PeopleBagType = E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_UNKNOWN;
            DriverIsPhoneing = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE;// 0x7fffffff;
            DriverIsSafebelt = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE;// 0x7fffffff;
            DriverIsSunVisor = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE;// 0x7fffffff;
            PassengerIsSafebelt = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE;// 0x7fffffff;
            PassengerIsSunVisor = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE;// 0x7fffffff;
            PlateColor = 0x7fffffff;
            PlateNo = "11111111";
            PlateNumRow = E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_NOUSE;// 0x7fffffff;
            VehicleColor = 0x7fffffff;
            VehicleLabel = 0x7fffffff;
            VehicleLabelDetail = 0x7fffffff;
            VehicleType = E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_NOUSE;// 0x7fffffff;
            VehicleTypeDetail = E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_NOUSE;// 0x7fffffff;

            FeatureType =  E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_STRUCTURED;
            ObjDetailRect = new System.Drawing.Rectangle();
            ObjFilterType =  E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_VEHICLE| E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_PASSAGER| E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_TWOWHEEL;
            ObjRect = new System.Drawing.Rectangle();
            PictureData = new System.Drawing.Bitmap(1,1);

            PassLineSet = new List<PassLine>();

            RegionSet = new List<BreakRegion>();
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Subscribe(OnSearchResultReturned, Microsoft.Practices.Prism.Events.ThreadOption.PublisherThread);   

        }
        private void OnSearchResultReturned(SearchResultSummaryV3_1 summary)
        {
            if(m_requestList.ContainsKey(summary.SearchItem.CameraID))
                m_requestList.Remove(summary.SearchItem.CameraID);

            if(m_requestList.Count==0)
            {
                if (SearchFinished != null)
                {
                    SearchFinished(this, null);
                }
            }
        }
        private List<SearchViewModelBase> vms;

        private bool Validata(out string msg)
        {
            if (SearchItems.SearchItems.Count <= 0)
            {
                msg = "检索范围为空";
                return false;
            }
            if((FeatureType & E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PASSLINE)>0)
            {
                if (PassLineSet == new List<PassLine>() && RegionSet == new List<BreakRegion>())
                {
                    msg = "尚未绘制越界线或闯入闯出框";
                    return false;
                }
            }
            if((FeatureType & E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL)>0)
            {
                if (ObjRect == new System.Drawing.Rectangle())
                {
                    msg = "尚未绘制全局特征框";
                    return false;
                }
            }
            if((FeatureType & E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL)>0)
            {
                if (ObjDetailRect == new System.Drawing.Rectangle())
                {
                    msg = "尚未绘制局部特征框";
                    return false;
                }
            }

            foreach (var item in SearchItems.SearchItems)
            {
                if (!item.IsHistoryTask && StopTime.Subtract(StartTime).TotalMinutes > 12 * 60 + 1)
                {
                    msg = "实时视频检索不能超过 12 小时";
                    return false;
                }
            }

            if (StartTime.CompareTo(StopTime) > 0)
            {
                msg = "结束时间不能小于开始时间";
                return false;
            }
            msg = "";
            return true; 
        }
        public bool Commit(out string msg )
        {
            m_requestList = new Dictionary<string, bool>();
            msg = "";
            if (!Validata(out msg))
                return false;

            CloseSearch();
            vms = new List<SearchViewModelBase>();
            List<SearchItemV3_1> nosuch_error = new List<SearchItemV3_1>();
            List<SearchItemV3_1> start_error = new List<SearchItemV3_1>();

            foreach (var item in SearchItems.SearchItems)
            {
                m_requestList.Add(item.CameraID, false);
                item.SearchHandle = 0;
                var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(item.CameraID, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM);
                if (info == null)
                { 
                    info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(item.CameraID, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD);
                }
                if (info == null)
                { 
                    info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(item.CameraID, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE);
                }
                if (info==null || item.CameraID != info.CameraID)
                {
                    nosuch_error.Add(item);
                }
                else
                {
                    string ip = info.StoreIP;
                    uint port = info.StortPort;
                    SearchViewModelBase vm = new SearchViewModelBase(ip, port);
                    vm.SearchItem = item;
                    item.SearchHandle = vm.StartSearch((SearchParaV3_1)m_searchParam.Clone());
                    if (item.SearchHandle == 0)
                        start_error.Add(item);
                    vms.Add(vm);
                }
            }
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchBeginEvent>().Publish(SearchItems);
            foreach (SearchViewModelBase item in vms)
            {
                item.SearchReady();
            }
            foreach (var item in start_error)
            {
                SearchResultSummaryV3_1 summary = new SearchResultSummaryV3_1()
                {
                    SearchSessionID = 0,
                    SearchResultSingleSummaryList = new List<SearchResultRecordV3_1>(),
                    SearchVM = null,
                    SearchItem = item,
                    SearchStatus =  E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR_STARTFAILED,
                    ObjectRect =  "",
                };

                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Publish(summary);
                
            }

            ////////////////////////////////////////////////////////
            foreach (var item in nosuch_error)
            {

                SearchResultSummaryV3_1 summary = new SearchResultSummaryV3_1()
                {
                    SearchSessionID = 0,
                    SearchResultSingleSummaryList = new  List<SearchResultRecordV3_1>(),
                    SearchVM = null,
                    SearchItem = item,
                    SearchStatus = E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR_NOSUCHITEM,
                    ObjectRect = "",
                };

                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Publish(summary);

            }
            //foreach (var item in SearchItems.SearchItems)
            //{
            //    List<SearchResultRecordTiny> record = new List<SearchResultRecordTiny>();
            //    for (int i = 0; i < 123; i++)
            //    {
            //    record.Add(new SearchResultRecordTiny()
            //    {
            //        ObjectKey = (ulong)i,
            //        ObjectDetailRect = new System.Drawing.Rectangle(),
            //        ObjectType = E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_VEHICLE,
            //        TargetEndTs = DateTime.Now,
            //        TargetStartTs = DateTime.Now.AddSeconds(-60)
            //    });
                    
            //    }
            //    SearchResultSummaryV3_1 summary = new SearchResultSummaryV3_1()
            //    {
            //        SearchSessionID = 0xffff,
            //        SearchResultSingleSummaryList = record,
            //        SearchVM = new SearchViewModelBase("127.0.0.1", 9301),
            //        SearchItem = item,
            //        SearchStatus = E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH,
            //        ObjectRect = "0,0,0,0",
            //    };

            //    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Publish(summary);
                
            //}
            ////////////////////////////////////////////////////////////
            return true;
        }

        public void CloseSearch()
        {
            if (vms == null)
                return;

            foreach (var item in vms)
            {
                item.ClosetSearch();
            }
        }



    }
}
