using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SingleSearchDitailResultViewModel
    {
        private SearchViewModelBase SearchVM { get; set; }
        public List<SearchResultRecordTiny> SearchResult { get; set; }
        public SingleSearchDitailResultViewModel()
        {

        }
        public  SearchResultRecordV3_1 GetSearchResultDetail(SearchResultRecordTiny recordtiny)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            SearchResultRecordV3_1 r = new SearchResultRecordV3_1()
            {
                    BeginTime = DateTime.Now.AddSeconds(-36),
                    EndTime = DateTime.Now,
                    OriginalPic = System.Drawing.Image.FromFile("C:\\compare.jpg"),
                    DownBodyColor = (uint)E_MOVEOBJ_COLOR.E_MOVEOBJ_COLOR_ONBIKE,
                    ObjRect = new System.Drawing.Rectangle(300, 100, 650, 650),
                    DriverIsPhoneing = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOTHAVE,
                    DriverIsPhoneingConf = 80,
                    DriverIsSafebelt = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOTHAVE,
                    DriverIsSafebeltConf = 70,
                    DriverIsSunVisor = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_HAVE,
                    DriverIsSunVisorConf = 90,
                    ObjDetailRect = new System.Drawing.Rectangle(650,250,150,150),
                    ObjKey = 0xffff,
                    ObjType = E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_TWOWHEEL,
                    OriginalPicURL = "",
                    PassengerIsSafebelt = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_HAVE,
                    PassengerIsSafebeltConf = 60,
                    PassengerIsSunVisor = E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NONE,
                    PassengerIsSunVisorConf = 0,
                    PlateColor = (int)E_VDA_SEARCH_VEHICLE_PLATE_COLOR_TYPE.E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_BLUE,
                    PlateNo = "沪ASB110",
                    PlateNumRow = E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_SINGLE,
                    PlatePic = System.Drawing.Image.FromFile("C:\\plant.jpg"),
                    PlatePicURL = "",
                    PlateRect = new System.Drawing.Rectangle(550,640,152,40),
                    Similar = 80,
                    ThumbPic = System.Drawing.Image.FromFile("C:\\obj.jpg"),
                    ThumbPicURL = "",
                    UpBodyColor = (uint)E_MOVEOBJ_COLOR.E_MOVEOBJ_COLOR_BLUE,
                    VehicleColor = (uint)E_VDA_SEARCH_VEHICLE_COLOR_TYPE.E_SEARCH_VEHICLE_COLOR_TYPE_BLACK,
                    VehicleLabel = 1,
                    VehicleLabelDetail = (uint)E_VDA_SEARCH_VEHICLE_PLATE_COLOR_TYPE.E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_GREEN,
                    VehicleType = E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_SMALL_BUS,
                    VehicleTypeDetail = E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_203,

                };
                
            
            return r;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////


            if (SearchVM == null)
                return new SearchResultRecordV3_1();

            List<SearchResultRecordTiny> tinylist = new List<SearchResultRecordTiny>();
            tinylist.Add(recordtiny);
            List<SearchResultRecordV3_1> detail = SearchVM.GetSearchResultDetail(tinylist);
            if (detail != null && detail.Count > 0)
            {
                detail.ForEach(item => item.ThumbPic = Common.GetImage(item.ThumbPicURL));
                detail.ForEach(item => item.PlatePic = Common.GetImage(item.PlatePicURL));
                detail.ForEach(item => item.OriginalPic = Common.GetImage(item.OriginalPicURL));
            return detail[0];
            }
            else
                return new SearchResultRecordV3_1();
        }

        public void Clear()
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchFinishedEvent>().Unsubscribe(OnSearchResultReturned);
            
        }
    }
}