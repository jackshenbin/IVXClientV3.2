using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using MyLog4Net;
using System.Xml;


namespace IVX.Live.SearchServices
{
    public class SearchServices
    {
        // public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        // public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        // public event Action<string> DisConnected;
        // public event Action<string> Connected;
        public event Action<string> FireMessage;
        public event Action<SearchResultSummaryV3_1,string> SearchFinished;
		public event Action<List<SearchResultFace>> SearchFaceFinished;
        #region Fields
        public  bool IsConnected { get; set; }
        public List<uint> ReadyList { get; set; }
        private SearchWebserviceClientProtocol SearchProtocol = null;
        public string WebserviceUrl { get; set; }
        private string ServerIP { get; set; }

        #endregion

        #region Constructors

        public SearchServices(string url)
        {
            IsConnected = false;
            WebserviceUrl = url;
            SearchProtocol = new SearchWebserviceClientProtocol();
        }

        #endregion

        #region Public Functions
        public void Init(string serverip,uint serverport)
        {
            SearchProtocol.Init(string.Format(WebserviceUrl,serverip,serverport));
                  IsConnected = true;
                  ServerIP = serverip;
                  ReadyList = new List<uint>();
        }

        public uint ADD_TASK(SearchParaV3_1 seachparam,SearchItemV3_1 searchitem)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices ADD_TASK CameraID:{0},FeatureType:{1},BeginTimeMilliSec:{2},EndTimeMilliSec:{3}", seachparam.CameraID, seachparam[SDKConstant.bColorSearch], seachparam.StartTime, seachparam.EndTime));
            System.Drawing.Rectangle objdetailrect = (System.Drawing.Rectangle)seachparam[SDKConstant.ObjDetailRect];
            System.Drawing.Rectangle objrect = (System.Drawing.Rectangle)seachparam[SDKConstant.ObjRect];
            SMS_MSG_ADD_TASK_REQ req = new SMS_MSG_ADD_TASK_REQ()
            {
                CameraID = seachparam.CameraID,
                BeginTimeMilliSec = Convert.ToUInt64(seachparam.StartTime.Subtract(Common.ZEROTIME).TotalMilliseconds),
                EndTimeMilliSec = Convert.ToUInt64(seachparam.EndTime.Subtract(Common.ZEROTIME).TotalMilliseconds),
                SortType = (uint)seachparam.SortType,
                FeatureType = (uint)(E_SEARCH_FEATURE_TYPE)seachparam[SDKConstant.FeatureType],
                ObjDetailRect = string.Format("{0},{1},{2},{3}",objdetailrect.X,objdetailrect.Y,objdetailrect.Width,objdetailrect.Height),
                ObjFilterType = (uint)(E_SEARCH_OBJ_FILTER_TYPE)seachparam[SDKConstant.ObjFilterType],
                ObjRect = string.Format("{0},{1},{2},{3}", objrect.X, objrect.Y, objrect.Width, objrect.Height),
                PictureData = (string)seachparam[SDKConstant.PictureData],
                ResultNumRange = seachparam.ResultNumRange,
                Similar = seachparam.Similar,
                PassLineSet = new List<PassLineSet>(),
                RegionSet = new List<RegionSet>(),
                StructFeatureSet = new StructFeatureSet(),
            }; 
            List<PassLine> passlinelist = seachparam[SDKConstant.PassLineSet] as List<PassLine>;
            if (passlinelist.Count == 0)
            {
                passlinelist.Add(new PassLine()
                {
                    DirectLineEnd = new System.Drawing.Point(),
                    DirectLineStart = new System.Drawing.Point(),
                    PassLineEnd = new System.Drawing.Point(),
                    PassLineStart = new System.Drawing.Point(),
                    PassLineType = 0,
                });
            } 
            foreach (PassLine line in passlinelist)
            {

                req.PassLineSet.Add(new PassLineSet()
                    {
                        PassLineType = line.PassLineType,
                        PassLineBeginPoint = string.Format("{0},{1}", line.PassLineStart.X, line.PassLineStart.Y),
                        PassLineEndPoint = string.Format("{0},{1}", line.PassLineEnd.X, line.PassLineEnd.Y),
                        DirectLineBeginPoint = string.Format("{0},{1}", line.DirectLineEnd.X, line.DirectLineEnd.Y),
                        DirectLineEndPoint = string.Format("{0},{1}", line.DirectLineStart.X, line.DirectLineStart.Y),
                    });
            }
            List<BreakRegion> breaklist = seachparam[SDKConstant.RegionSet] as List<BreakRegion>;
            if (breaklist.Count == 0)
            {
                List<System.Drawing.Point> ps = new List<System.Drawing.Point>();
                ps.Add(new System.Drawing.Point());
                breaklist.Add(new BreakRegion()
                {
                    RegionPointList = ps,
                    RegionType = 0,
                });
            }
            foreach (BreakRegion reg in breaklist)
            {
                req.RegionSet.Add(new RegionSet()
                    {
                        RegionType = reg.RegionType,
                        RegionPointSet = reg.RegionPointList.Select<System.Drawing.Point, string>(item => string.Format("{0},{1}", item.X, item.Y)).ToList(),
                    });
            }
            req.StructFeatureSet = new StructFeatureSet()
            {
                DownBodyColor = (uint)seachparam[SDKConstant.DownBodyColor],
                DriverIsPhoneing = (uint)seachparam[SDKConstant.DriverIsPhoneing],
                DriverIsSafebelt = (uint)seachparam[SDKConstant.DriverIsSafebelt],
                DriverIsSunVisor = (uint)seachparam[SDKConstant.DriverIsSunVisor],
                PassengerIsSafebelt = (uint)seachparam[SDKConstant.PassengerIsSafebelt],
                PassengerIsSunVisor = (uint)seachparam[SDKConstant.PassengerIsSunVisor],
                PlateColor = (uint)seachparam[SDKConstant.PlateColor],
                PlateNo = (string)seachparam[SDKConstant.PlateNo],
                PlateNumRow = (uint)seachparam[SDKConstant.PlateNumRow],
                UpBodyColor = (uint)seachparam[SDKConstant.UpBodyColor],
                VehicleColor = (uint)seachparam[SDKConstant.VehicleColor],
                VehicleLabel = (uint)seachparam[SDKConstant.VehicleLabel],
                VehicleLabelDetail = (uint)seachparam[SDKConstant.VehicleLabelDetail],
                VehicleType = (uint)seachparam[SDKConstant.VehicleType],
                VehicleTypeDetail = (uint)seachparam[SDKConstant.VehicleTypeDetail],
                 BagType = (uint)seachparam[SDKConstant.BagType],
                 
            };
            if (req.StructFeatureSet.PlateNo.Length > 0 && req.StructFeatureSet.PlateNo != "11111111")
            { req.StructFeatureSet.PlateNo = "*" + req.StructFeatureSet.PlateNo + "*"; }
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_ADD_TASK_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices ADD_TASK message:{0}",message));

            string rsp = Send(message);
            uint id = 0;
            if (string.IsNullOrEmpty(rsp))
                return 0;

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);

            id = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/MatchTaskId").InnerText);

            SearchResultSummaryV3_1 result = new SearchResultSummaryV3_1()
            {
                ObjectRect = "",
                SearchResultSingleSummaryList = null,
                SearchSessionID = id,
                SearchStatus = 0,
                SearchItem = searchitem,
            };
            new System.Threading.Thread(thGetTask).Start(result);
            
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices ADD_TASK retVal MatchTaskId:{0}", id));
            
            return id;
        }

        private void DEL_TASK(uint matchTaskId)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices DEL_TASK matchTaskId:{0}", matchTaskId));
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_DEL_TASK_REQ>(MessageCmd.SMS_MSG_DEL_TASK_REQ, new SMS_MSG_DEL_TASK_REQ() {  MatchTaskId = matchTaskId});
            string rsp = Send(message);
            if (string.IsNullOrEmpty(rsp))
                return ;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices DEL_TASK retVal "));  
        }

		private void DEL_FACE_TASK(uint matchTaskId) {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices DEL_FACE_TASK matchTaskId:{0}", matchTaskId));
			string message = SearchProtocol.BuildProtocolBody<SMS_MSG_DEL_TASK_REQ>(MessageCmd.SMS_MSG_DEL_FACE_TASK_REQ, new SMS_MSG_DEL_TASK_REQ() { MatchTaskId = matchTaskId });
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices END DEL_FACE_TASK"));
		}


        private List<ObjInfoSet> GET_TASK_STATE(uint matchTaskId, out E_VDA_SEARCH_STATUS stat,out string objrect)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_TASK_STATE matchTaskId:{0}", matchTaskId));
            stat = 0;
            objrect = "0,0,0,0";


            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_GET_TASK_STATE_REQ>(MessageCmd.SMS_MSG_GET_TASK_STATE_REQ, new SMS_MSG_GET_TASK_STATE_REQ()
            {
                MatchTaskId = matchTaskId,
            });
            string rsp = Send(message);

            if (string.IsNullOrEmpty(rsp))
                return new List<ObjInfoSet>();

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);

            stat = (E_VDA_SEARCH_STATUS)Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/TaskStatus").InnerText);
            objrect = xdoc.SelectSingleNode("//Root/Response/ObjRect").InnerText;
            List<ObjInfoSet> retval = new List<ObjInfoSet>();
            if (stat == E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH)
            {
                foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/ObjInfoSet"))
                {
                    ObjInfoSet info = new ObjInfoSet();
                    info.ObjKey = Convert.ToUInt64(item.SelectSingleNode("ObjKey").InnerText);
                    info.ObjType = Convert.ToUInt32(item.SelectSingleNode("ObjType").InnerText);
                    info.BeginTimeMilliSec = Convert.ToUInt64(item.SelectSingleNode("BeginTimeMilliSec").InnerText);
                    info.EndTimeMilliSec = Convert.ToUInt64(item.SelectSingleNode("EndTimeMilliSec").InnerText);
                    info.ObjDetailRect = item.SelectSingleNode("ObjDetailRect").InnerText;
                    info.Similar = Convert.ToUInt32(item.SelectSingleNode("Similar").InnerText);
                    retval.Add(info);
                    //MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_TASK_STATE ObjKey:{0},ObjType:{1}", info.ObjKey, info.ObjType));
                }
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_TASK_STATE retVal count:{0},stat:{1},objrect:{2}", retval.Count,stat,objrect));

            return retval;
        }

        public List<SearchResultRecordV3_1> GET_OBJ_DETAIL_INFO(string cameraId,uint matchTaskId, List<SearchResultRecordTiny> records)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_OBJ_DETAIL_INFO matchTaskId:{0},cameraId:{1}", matchTaskId, cameraId));

          /*  <Request>
      	<MatchTaskId>23</MatchTaskId>
		<ObjKeySet>
			<ObjKey>23</ObjKey>
			<ObjType>1</ObjType>
</ObjKeySet>
<ObjKeySet>
			<!--下一个目标节点>
</ObjKeySet>
   </Request>
            */

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + cameraId + "</CameraID>");
            sb.AppendLine("<MatchTaskId>"+matchTaskId+"</MatchTaskId>");
            
            records.ForEach(item =>
            {
                sb.AppendLine("<ObjKeySet> <ObjKey>" + item.ObjectKey + "</ObjKey> <ObjType>" + (uint)item.ObjectType + "</ObjType> </ObjKeySet>");
            });
            sb.AppendLine("</Request>");
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_OBJ_DETAIL_INFO_REQ, sb.ToString());
            //MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_OBJ_DETAIL_INFO msg:{0}", message));
            string rsp = Send(message);

            if (string.IsNullOrEmpty(rsp))
                return new List<SearchResultRecordV3_1>();

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);

            List<SearchResultRecordV3_1> retval = new List<SearchResultRecordV3_1>();
            foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/ObjDetailInfoSet"))
            {
                ObjDetailInfoSet temp = DataModel.Common.DeserilizeObject<ObjDetailInfoSet>(item.OuterXml);
                var fndobj = records.FirstOrDefault(it => it.ObjectKey == temp.ObjKey && (uint)it.ObjectType == temp.ObjType);
                temp.ObjDetailRect = (fndobj == null )? "0,0,0,0" : string.Format("{0},{1},{2},{3}",fndobj.ObjectDetailRect.X,fndobj.ObjectDetailRect.Y,fndobj.ObjectDetailRect.Width,fndobj.ObjectDetailRect.Height);
                SearchResultRecordV3_1 info = new SearchResultRecordV3_1()
                {
                    BeginTime = DataModel.Common.ZEROTIME.AddMilliseconds(temp.BeginTimeMilliSec),
                    EndTime = DataModel.Common.ZEROTIME.AddMilliseconds(temp.EndTimeMilliSec),
                    DownBodyColor = temp.DownBodyColor,
                    DriverIsPhoneing = (E_DRIVER_FEATURE_TYPE)temp.DriverIsPhoneing,
                    DriverIsPhoneingConf = temp.DriverIsPhoneingConf,
                    DriverIsSafebelt = (E_DRIVER_FEATURE_TYPE)temp.DriverIsSafebelt,
                    DriverIsSafebeltConf = temp.DriverIsSafebeltConf,
                    DriverIsSunVisor = (E_DRIVER_FEATURE_TYPE)temp.DriverIsSunVisor,
                    DriverIsSunVisorConf = temp.DriverIsSunVisorConf,
                    ObjKey = temp.ObjKey,
                    ObjType = (E_SEARCH_RESULT_OBJECT_TYPE) temp.ObjType,
                    ObjDetailRect = new System.Drawing.Rectangle(
                        Convert.ToInt32(temp.ObjDetailRect.Split(new char[]{','})[0]),
                        Convert.ToInt32(temp.ObjDetailRect.Split(new char[]{','})[1]),
                        Convert.ToInt32(temp.ObjDetailRect.Split(new char[]{','})[2]),
                        Convert.ToInt32(temp.ObjDetailRect.Split(new char[]{','})[3])),
                    ObjRect = new System.Drawing.Rectangle(
                        Convert.ToInt32(temp.ObjRect.Split(new char[] { ',' })[0]),
                        Convert.ToInt32(temp.ObjRect.Split(new char[] { ',' })[1]),
                        Convert.ToInt32(temp.ObjRect.Split(new char[] { ',' })[2]),
                        Convert.ToInt32(temp.ObjRect.Split(new char[] { ',' })[3])),
                    OriginalPicURL = temp.OriginalPicURL,
                    PassengerIsSafebelt = (E_DRIVER_FEATURE_TYPE)temp.PassengerIsSafebelt,
                    PassengerIsSafebeltConf = temp.PassengerIsSafebeltConf,
                    PassengerIsSunVisor = (E_DRIVER_FEATURE_TYPE)temp.PassengerIsSunVisor,
                    PassengerIsSunVisorConf = temp.PassengerIsSunVisorConf,
                    PlateColor = temp.PlateColor,
                    PlateNo = temp.PlateNo,
                    PlateNumRow = (E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE)temp.PlateNumRow,
                    PlatePicURL = temp.PlatePicURL,
                    PlateRect = new System.Drawing.Rectangle(
                        Convert.ToInt32(temp.PlateRect.Split(new char[] { ',' })[0]),
                        Convert.ToInt32(temp.PlateRect.Split(new char[] { ',' })[1]),
                        Convert.ToInt32(temp.PlateRect.Split(new char[] { ',' })[2]),
                        Convert.ToInt32(temp.PlateRect.Split(new char[] { ',' })[3])),
                    Similar = (fndobj!=null)?fndobj.Similar:0,
                    ThumbPicURL = temp.ThumbPicURL,
                    UpBodyColor = temp.UpBodyColor,
                    VehicleColor = temp.VehicleColor,
                    VehicleLabel =  temp.VehicleLabel,
                    VehicleLabelDetail = temp.VehicleLabelDetail,
                    VehicleType = (E_VDA_SEARCH_VEHICLE_TYPE)temp.VehicleType,
                    VehicleTypeDetail = (E_VDA_SEARCH_VEHICLE_DETAIL_TYPE)temp.VehicleTypeDetail,
                    AdjustTime = (fndobj != null) ? fndobj.AdjustTime : new DateTime(),
                    BegType = (E_MOVE_OBJ_PEOPLE_BAG_TYPE) temp.BagType,
                     CameraID = cameraId,
                };
                retval.Add(info);
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_OBJ_DETAIL_INFO retVal count:{0}", retval.Count));

            return retval;
        }

        private void thGetTask(object obj)
        {
            SearchResultSummaryV3_1 summary = obj as SearchResultSummaryV3_1;
            if (summary == null)
                return;
            List<ObjInfoSet> retval =new List<ObjInfoSet>();
            System.Threading.Thread.Sleep(200);
            
            while (true)
            {
                E_VDA_SEARCH_STATUS stat = E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_RUNING;
                string objrect = "";
                if (ReadyList.Contains(summary.SearchSessionID))
                {
                    retval = GET_TASK_STATE(summary.SearchSessionID, out stat, out objrect);
                    summary.SearchStatus = stat;
                }
                if (stat ==  E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR)
                {
                    summary.SearchResultSingleSummaryList = new List<SearchResultRecordV3_1>();
                    summary.ObjectRect = objrect;
                    break;
                }
                if (stat ==  E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH)
                {
                    var temp = new List<SearchResultRecordTiny>();
                    retval.ForEach(item =>
                    {
                        temp.Add(new SearchResultRecordTiny()
                        {
                            ObjectKey = item.ObjKey,
                            ObjectType = (E_SEARCH_RESULT_OBJECT_TYPE) item.ObjType,
                            TargetStartTs = new DateTime().AddMilliseconds(item.BeginTimeMilliSec),
                            TargetEndTs = new DateTime().AddMilliseconds(item.EndTimeMilliSec),
                            ObjectDetailRect =new System.Drawing.Rectangle(
                                Convert.ToInt32( item.ObjDetailRect.Split(new char[]{','})[0]),
                                Convert.ToInt32( item.ObjDetailRect.Split(new char[]{','})[0]),
                                Convert.ToInt32( item.ObjDetailRect.Split(new char[]{','})[0]),
                                Convert.ToInt32( item.ObjDetailRect.Split(new char[]{','})[0])),
                                AdjustTime = summary.SearchItem.AdjustTime,
                                 Similar = item.Similar,
                        });
                    });

                    List<SearchResultRecordV3_1> recordlist =new List<SearchResultRecordV3_1>();

                    temp.ForEach(item =>
                    {
                        recordlist.Add(new SearchResultRecordV3_1()
                            {
                                AdjustTime = item.AdjustTime,
                                BeginTime = item.TargetStartTs,
                                EndTime = item.TargetEndTs,
                                Similar = item.Similar,
                                ObjType = item.ObjectType,
                                ObjKey = item.ObjectKey,
                                ObjDetailRect = item.ObjectDetailRect,
                            });
                    });

                    //int index = 0;
                    //int count = 500;
                    //if (temp.Count > 0)
                    //{
                    //    for (int i = 0; i < 1000; i++)
                    //    {
                    //        int getcount = count;
                    //        bool finish = false;
                    //        if (temp.Count <= index + count)
                    //        {
                    //            getcount = temp.Count - index;
                    //            finish = true;
                    //        }
                    //        var temp1 = temp.GetRange(index, getcount);
                    //        recordlist.AddRange(GET_OBJ_DETAIL_INFO(summary.SearchSessionID, temp1));
                    //        index += getcount;
                    //        if (finish)
                    //            break;
                    //    }
                    //}

                    summary.SearchResultSingleSummaryList = recordlist;
                    summary.ObjectRect = objrect;
                    break;
                }
                System.Threading.Thread.Sleep(20);
            }

            if (SearchFinished != null)
            {
                SearchFinished(summary,ServerIP);
            }
            DEL_TASK(summary.SearchSessionID);
        }

		private List<ObjInfoSet> GET_FACE_TASK_STATUS(uint matchTaskId, out E_VDA_SEARCH_STATUS stat, out string objrect) {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_TASK_STATE matchTaskId:{0}", matchTaskId));
			stat = 0;
			objrect = "0,0,0,0";

			string message = SearchProtocol.BuildProtocolBody<SMS_MSG_GET_TASK_STATE_REQ>(MessageCmd.SMS_MSG_GET_FACE_TASK_STATE_REQ, new SMS_MSG_GET_TASK_STATE_REQ() {
				MatchTaskId = matchTaskId,
			});
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<ObjInfoSet>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			stat = (E_VDA_SEARCH_STATUS)Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/TaskStatus").InnerText);
			objrect = xdoc.SelectSingleNode("//Root/Response/ObjRect").InnerText;
			List<ObjInfoSet> retval = new List<ObjInfoSet>();
			if (stat == E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH) {
				foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/ObjInfoSet")) {
					ObjInfoSet info = new ObjInfoSet();
					info.ObjKey = Convert.ToUInt64(item.SelectSingleNode("ObjKey").InnerText);
					info.BeginTimeMilliSec = Convert.ToUInt64(item.SelectSingleNode("BeginTimeMilliSec").InnerText);
					info.EndTimeMilliSec = Convert.ToUInt64(item.SelectSingleNode("EndTimeMilliSec").InnerText);
					info.ObjDetailRect = item.SelectSingleNode("ObjDetailRect").InnerText;
					info.Similar = Convert.ToUInt32(item.SelectSingleNode("Similar").InnerText);
					retval.Add(info);
				}
			}
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices GET_TASK_STATE retVal count:{0},stat:{1},objrect:{2}", retval.Count, stat, objrect));

			return retval;
		}

		private List<SearchResultFace> GetFaceDetaliInfo(SearchParaFace facePara, List<ObjInfoSet> objInfoList) {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices START　GetFaceDetaliInfo ----"));
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<Request>");
			sb.AppendLine("<CameraID>" + facePara.CameraID + "</CameraID>");
			sb.AppendLine("<MatchTaskId>" + facePara.matchTaskId + "</MatchTaskId>");
			foreach (var item in objInfoList) {
				sb.AppendLine("<ObjKeySet>");
				sb.AppendLine("<ObjKey>" + item.ObjKey + "</ObjKey>");
				sb.AppendLine("</ObjKeySet>");
			}
			sb.AppendLine("</Request>");
			string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_FACE_OBJ_DETALL_REQ, sb.ToString());
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices END  　GetFaceDetaliInfo ----"));
			List<SearchResultFace> faceResultList = new List<SearchResultFace> {};
			if (string.IsNullOrEmpty(rsp))
				return faceResultList;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/ObjDetailInfoSet");
			foreach (XmlNode valueNode in xmlNodes) {
				SearchResultFace item = new SearchResultFace();
				item.ObjKey = Convert.ToUInt64(valueNode.SelectSingleNode("ObjKey").InnerText);
				foreach (var objItem in objInfoList)
				{
					if(item.ObjKey == objItem.ObjKey){
						item.Similar = objItem.Similar;
						break;
					}
				}
				item.CameraID = facePara.CameraID;
				item.BeginTimeMilliSec =  Convert.ToUInt64(valueNode.SelectSingleNode("BeginTimeMilliSec").InnerText);
				item.BeginTimeMilliSec /= 1000;
				item.EndTimeMilliSec =  Convert.ToUInt64(valueNode.SelectSingleNode("EndTimeMilliSec").InnerText);
				item.EndTimeMilliSec /= 1000;
				item.OriFacePicPath = valueNode.SelectSingleNode("OriFacePicPath ").InnerText;
				item.FacePosition = valueNode.SelectSingleNode("FacePosition").InnerText;
				item.PeopleNation = Convert.ToUInt32(valueNode.SelectSingleNode("PeopleNation").InnerText);
				item.PeopleAge = Convert.ToUInt32(valueNode.SelectSingleNode("PeopleAge").InnerText);
				item.PeopleSex = Convert.ToUInt32(valueNode.SelectSingleNode("PeopleSex").InnerText);
				faceResultList.Add(item);
			}
			return faceResultList;
		}

		private void thGetFaceTask(object facePara) {
			SearchParaFace t_facePara = (SearchParaFace)facePara;
			string objrect = "";
			List<ObjInfoSet> objInfoList = null;
			System.Threading.Thread.Sleep(200);
			List<SearchResultFace> resultList = null;
			while (true) {
				E_VDA_SEARCH_STATUS stat = E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_RUNING;
				objInfoList = GET_FACE_TASK_STATUS(t_facePara.matchTaskId, out stat, out objrect);
				if (stat == E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR) {
					break;
				}
				if (stat == E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH) {
					// 查询详细
					resultList = GetFaceDetaliInfo(t_facePara, objInfoList);
					if (SearchFaceFinished != null) {
						SearchFaceFinished(resultList);
					}
					break;
				}
				System.Threading.Thread.Sleep(20);
			}
			DEL_FACE_TASK(t_facePara.matchTaskId);
		}

		public uint ADD_FACE_TASK(SearchParaFace para) {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices START　ADD_FACE_TASK "));
			uint matchTaskId = 0;
			SMS_MSG_ADD_FACE_TASK_REQ req = new SMS_MSG_ADD_FACE_TASK_REQ() {
				CameraID = para.CameraID,
				startTime = para.startTime,
				endTime = para.endTime,
				ResultNumRange = 1000,//para.ResultNumRange,
				Similar= para.Similar,
				picData = para.picData,
				ObjRect = para.ObjRect,

				PeopleNation = para.PeopleNation,
				EndAge = para.EndAge,
				BeginAge = para.BeginAge,
				SortType = (uint)para.SortType,
			};
			string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_ADD_FACE_TASK_REQ, req.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices ADD_FACE_TASK END"));

			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return 0;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			para.matchTaskId = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/MatchTaskId").InnerText);
			new System.Threading.Thread(thGetFaceTask).Start(para);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices ADD_TASK retVal MatchTaskId:{0}", matchTaskId));
			return para.matchTaskId;
		}

        public CrowdInfo GET_HOTIMAGE_REAL_DATA(string cameraId)
        {
            SMS_MSG_GET_HOTIMAGE_REAL_DATA_REQ req = new SMS_MSG_GET_HOTIMAGE_REAL_DATA_REQ() { CameraID = cameraId };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_HOTIMAGE_REAL_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_HOTIMAGE_REAL_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_HOTIMAGE_REAL_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp))
                return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            CrowdInfo crowdInfo = new CrowdInfo();
            crowdInfo.CameraID = cameraId;
            crowdInfo.TimeSec = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/TimeSec").InnerText);
            crowdInfo.HotImageURL = xdoc.SelectSingleNode("//Root/Response/PseudHotImgUrl").InnerText;
            crowdInfo.DirectionImageURL = xdoc.SelectSingleNode("//Root/Response/CrowdDirectionMapImgUrl").InnerText;
            crowdInfo.OriginaloImageURL = xdoc.SelectSingleNode("//Root/Response/OriginalImgUrl").InnerText;
            crowdInfo.PeopleCount = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/PeopleCount").InnerText);
            crowdInfo.RegionArea = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Area").InnerText);
            string str = xdoc.SelectSingleNode("//Root/Response/CrowdDetectRegionPointSet").InnerText;
            // add poit item
            crowdInfo.RegionPoints = new List<System.Drawing.Point> { };
            string[] ponitSetStr = str.Split(' ');
            foreach (string PointStr in ponitSetStr)
            {
                string[] point = PointStr.Split(',');
                System.Drawing.Point pointItem = new System.Drawing.Point(int.Parse(point[0]), int.Parse(point[1]));
                crowdInfo.RegionPoints.Add(pointItem);
            }
            return crowdInfo;
        }

        public List<CrowdInfo> GET_HOTIMAGE_HISTORY_DATA(UInt32 startTime, UInt32 endTime, string cameraId)
        {
            SMS_MSG_GET_HOTIMAGE_HISTORY_DATA_REQ req = new SMS_MSG_GET_HOTIMAGE_HISTORY_DATA_REQ()
            {
                CameraID = cameraId,
                BeginTimeSec = startTime,
                EndTimeSec = endTime
            };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_HOTIMAGE_HISTORY_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_HOTIMAGE_HISTORY_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_HOTIMAGE_HISTORY_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp))
                return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<CrowdInfo> crowdInfoList = new List<CrowdInfo> { };
            //存入数据
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
            // 从2开始是 DataSet
            foreach (XmlNode valueNode in xmlNodes)
            {
                CrowdInfo crowdInfo = new CrowdInfo();
                crowdInfo.CameraID = cameraId;
                crowdInfo.TimeSec = Convert.ToUInt32(valueNode.SelectSingleNode("TimeSec").InnerText);
                crowdInfo.HotImageURL = valueNode.SelectSingleNode("PseudHotImgUrl").InnerText;
                crowdInfo.DirectionImageURL = valueNode.SelectSingleNode("CrowdDirectionMapImgUrl").InnerText;
                crowdInfo.OriginaloImageURL = valueNode.SelectSingleNode("OriginalImgUrl").InnerText;
                crowdInfo.PeopleCount = Convert.ToUInt32(valueNode.SelectSingleNode("PeopleCount").InnerText);
                crowdInfo.RegionArea = Convert.ToUInt32(valueNode.SelectSingleNode("Area").InnerText);
                string str = valueNode.SelectSingleNode("CrowdDetectRegionPoint").InnerText;
                //add point item
                crowdInfo.RegionPoints = new List<System.Drawing.Point> { };
                string[] ponitSetStr = str.Split(' ');
                foreach (string PointStr in ponitSetStr)
                {
                    string[] point = PointStr.Split(',');
                    System.Drawing.Point pointItem = new System.Drawing.Point(int.Parse(point[0]), int.Parse(point[1]));
                    crowdInfo.RegionPoints.Add(pointItem);
                }
                crowdInfoList.Add(crowdInfo);
            }
            return crowdInfoList;
        }

        public List<CrowdStatistic> GET_HOTIMAGE_REPORT_DATA(UInt32 startTime, UInt32 endTime, string cameraId, UInt32 timeInterval)
        {
            SMS_MSG_GET_HOTIMAGE_STATISTIC_DATA_REQ req = new SMS_MSG_GET_HOTIMAGE_STATISTIC_DATA_REQ()
            {
                CameraID = cameraId,
                BeginTimeSec = startTime,
                EndTimeSec = endTime,
                TimeInterval = timeInterval
            };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_HOTIMAGE_STATISTIC_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_HOTIMAGE_REPORT_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_HOTIMAGE_REPORT_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp))
                return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<CrowdStatistic> CrowdStatisticList = new List<CrowdStatistic> { };
            //存入数据
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
            // 从2开始是 DataSet
            foreach (XmlNode valueNode in  xmlNodes)
            {
                CrowdStatistic crowdStatistic = new CrowdStatistic();
                crowdStatistic.CameraID = cameraId;
                crowdStatistic.TimeTag = valueNode.SelectSingleNode("TimeTag").InnerText;
                crowdStatistic.PeopleCountArg = Convert.ToUInt32(valueNode.SelectSingleNode("PeopleCountArg").InnerText);
                CrowdStatisticList.Add(crowdStatistic);
            }
            return CrowdStatisticList;
        }

        public List<TrafficeEventInfoV3_1> GET_TRAFFIC_EVENT_DATA(string cameraId, UInt32 startTime, UInt32 endTime, string type)
        {
            SMS_MSG_GET_EVENT_HISTORY_DATA_REQ req = new SMS_MSG_GET_EVENT_HISTORY_DATA_REQ()
            {
                CameraID = cameraId,
                BeginTimeSec = startTime,
                EndTimeSec = endTime,
                EventType = type
            };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_EVENT_HISTORY_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_TRAFFIC_EVENT_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_TRAFFIC_EVENT_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp)) return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<TrafficeEventInfoV3_1> trafficEventList = new List<TrafficeEventInfoV3_1> { };
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
            foreach (XmlNode valueNode in xmlNodes)
            {
                TrafficeEventInfoV3_1 trafficInfo = new TrafficeEventInfoV3_1();
                trafficInfo.CameraCode = valueNode.SelectSingleNode("CameraID").InnerText;
                trafficInfo.StartTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("BeginTimeSec").InnerText));
                trafficInfo.EndTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("EndTimeSec").InnerText));
                trafficInfo.EventType = (E_TRAFFIC_EVENT_TYPE)Convert.ToUInt32(valueNode.SelectSingleNode("EventType").InnerText);
                //-----添加EventImgURLInfo
                string imgUrl = valueNode.SelectSingleNode("EventImgUrl").InnerText;
                string strRect = valueNode.SelectSingleNode("EventObjRect").InnerText;
                string[] rectArry = strRect.Split(',');
                System.Drawing.Rectangle rectItem = new System.Drawing.Rectangle(Convert.ToInt32(rectArry[0]),
                                                                                 Convert.ToInt32(rectArry[1]),
                                                                                 Convert.ToInt32(rectArry[2]),
                                                                                 Convert.ToInt32(rectArry[3]));
                trafficInfo.EventImgURLInfo = new List<Tuple<System.Drawing.Rectangle, string>> { };
                trafficInfo.EventImgURLInfo.Add(new Tuple<System.Drawing.Rectangle, string>(rectItem, imgUrl));
                //---添加EventImgURLInfo
                trafficInfo.EventImgInfo = new List<Tuple<System.Drawing.Rectangle, System.IO.MemoryStream>> { };
                trafficInfo.ComposeImgURL = valueNode.SelectSingleNode("ComposeImgUrl").InnerText;
                trafficInfo.EventVideoUrl = valueNode.SelectSingleNode("EventVideoUrl").InnerText;
                trafficInfo.PlateNum = valueNode.SelectSingleNode("PlateNo").InnerText;
                trafficInfo.VehicleColor = Convert.ToUInt32(valueNode.SelectSingleNode("VehicleColor").InnerText);
                trafficInfo.VehicleType = (E_VDA_SEARCH_VEHICLE_TYPE)Convert.ToUInt32(valueNode.SelectSingleNode("VehicleType").InnerText);
                trafficInfo.VehicleLabel = Convert.ToUInt32(valueNode.SelectSingleNode("VehicleLabel").InnerText);
                trafficEventList.Add(trafficInfo);
            }
            return trafficEventList;
        }

        public List<TrafficFluxHistoryInfo> GET_TRAFFICFLUX_HISTORY_DATA(string cameraId, UInt32 startTime, UInt32 endTime)
        {
            SMS_MSG_GET_TRAFFIC_HISTORY_DATA_REQ req = new SMS_MSG_GET_TRAFFIC_HISTORY_DATA_REQ()
            {
                CameraID = cameraId,
                BeginTimeSec = startTime,
                EndTimeSec = endTime,
            };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_TRAFFIC_HISTORY_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_TRAFFICFLUX_HISTORY_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_TRAFFICFLUX_HISTORY_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp)) return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<TrafficFluxHistoryInfo> trafficEventList = new List<TrafficFluxHistoryInfo> { };
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
            foreach (XmlNode valueNode in xmlNodes)
            {
                TrafficFluxHistoryInfo trafficInfo = new TrafficFluxHistoryInfo();
                trafficInfo.CameraID = valueNode.SelectSingleNode("CameraID").InnerText ;
                trafficInfo.StatiIctisTime = Convert.ToUInt32(valueNode.SelectSingleNode("StatiIctisTime").InnerText);
                trafficInfo.RoadWayNum = Convert.ToUInt32(valueNode.SelectSingleNode("RoadWayNum").InnerText);
                trafficInfo.TrafficFluxBig = Convert.ToUInt32(valueNode.SelectSingleNode("TrafficFluxBig").InnerText);
                trafficInfo.TrafficFluxMiddle = Convert.ToUInt32(valueNode.SelectSingleNode("TrafficFluxMiddle").InnerText);
                trafficInfo.TrafficFluxSmall = Convert.ToUInt32(valueNode.SelectSingleNode("TrafficFluxSmall").InnerText);
                trafficInfo.TrafficFlux = Convert.ToUInt32(valueNode.SelectSingleNode("TrafficFlux").InnerText);
                trafficInfo.AvgVehiSpeed = Convert.ToUInt32(valueNode.SelectSingleNode("AvgVehiSpeed").InnerText);
                trafficInfo.AvgOccupyRatio = Convert.ToUInt32(valueNode.SelectSingleNode("AvgOccupyRatio").InnerText);
                trafficInfo.QueueLen = Convert.ToUInt32(valueNode.SelectSingleNode("QueueLen").InnerText);
                trafficInfo.AvgVehiDistance = Convert.ToUInt32(valueNode.SelectSingleNode("AvgVehiDistance").InnerText);
                trafficEventList.Add(trafficInfo);
            }
            return trafficEventList;
        }

        public List<TrafficFluxStatisticInfo> GET_TRAFFICFLUX_STATISTIC_DATA(string cameraId, UInt32 startTime, UInt32 endTime, UInt32 TimeInterval)
        {
            SMS_MSG_GET_TRAFFIC_STATISTIC_DATA_REQ req = new SMS_MSG_GET_TRAFFIC_STATISTIC_DATA_REQ()
            {
                CameraID = cameraId,
                BeginTimeSec = startTime,
                EndTimeSec = endTime,
                TimeInterval = TimeInterval,
            };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_TRAFFIC_STATISTIC_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_TRAFFICFLUX_STATISTIC_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_TRAFFICFLUX_STATISTIC_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp)) return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<TrafficFluxStatisticInfo> trafficFluxList = new List<TrafficFluxStatisticInfo> { };
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
            foreach (XmlNode valueNode in xmlNodes)
            {
                TrafficFluxStatisticInfo trafficInfo = new TrafficFluxStatisticInfo();
                trafficInfo.CameraID = cameraId;
                trafficInfo.TimeTag = valueNode.SelectSingleNode("TimeTag").InnerText;
                trafficInfo.TrafficFlux = Convert.ToUInt32(valueNode.SelectSingleNode("TrafficFlux").InnerText);
                trafficFluxList.Add(trafficInfo);
            }
            return trafficFluxList;
        }

        public List<DynamicTrafficPlateInfo> GET_PLATE_DYNAMIC_VEHICLE_DATA(string cameraId, UInt32 startTime, UInt32 endTime)
        {
            SMS_MSG_GET_PLATE_DYNAMIC_VEHICLE_DATA_REQ req = new SMS_MSG_GET_PLATE_DYNAMIC_VEHICLE_DATA_REQ()
            {
                CameraID = cameraId,
                BeginTimeSec = startTime,
                EndTimeSec = endTime,
            };
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_PLATE_DYNAMIC_VEHICLE_DATA_REQ, req.ToString());
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_PLATE_DYNAMIC_VEHICLE_DATA " + cameraId);
            string rsp = Send(message);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_PLATE_DYNAMIC_VEHICLE_DATA " + cameraId);
            if (string.IsNullOrEmpty(rsp)) return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<DynamicTrafficPlateInfo> trafficList = new List<DynamicTrafficPlateInfo> { };
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
            long id = DateTime.Now.Ticks;
            foreach (XmlNode valueNode in xmlNodes)
            {
                DynamicTrafficPlateInfo info = new DynamicTrafficPlateInfo();
                info.PlateId = id++;
                info.CameraCode = valueNode.SelectSingleNode("CameraCode").InnerText;
                info.StartTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("BeginTimeSec").InnerText));
                info.EndTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("EndTimeSec").InnerText));
                info.PlateNum = valueNode.SelectSingleNode("PlateNum").InnerText;
                info.Reliability = Convert.ToUInt32( valueNode.SelectSingleNode("PlateNumConf").InnerText);
                info.PlateColor = Convert.ToUInt32(valueNode.SelectSingleNode("PlateColor").InnerText);
                string strRect = valueNode.SelectSingleNode("PlateRect").InnerText;
                string[] rectArry = strRect.Split(',');
                System.Drawing.Rectangle rectItem = new System.Drawing.Rectangle(Convert.ToInt32(rectArry[0]),
                                                                                 Convert.ToInt32(rectArry[1]),
                                                                                 Convert.ToInt32(rectArry[2]),
                                                                                 Convert.ToInt32(rectArry[3]));
                info.PlateRect = rectItem;
                info.PlateImgUrl = valueNode.SelectSingleNode("PlateImgUrl").InnerText;
                info.OrgImgUrl = valueNode.SelectSingleNode("OrgImgUrl").InnerText;
                trafficList.Add(info);
            }
            return trafficList;
        }

		public List<BehaviorInfo> GET_BEHAVIOUR_HISTORY_DATA(string cameraId, UInt32 startTime, UInt32 endTime, string type) 
		{
			SMS_MSG_GET_BEHAVIOUR_HISTORY_DATA_REQ req = new SMS_MSG_GET_BEHAVIOUR_HISTORY_DATA_REQ()
			{
				CameraID = cameraId,
				BeginTimeSec = startTime,
				EndTimeSec = endTime,
				EventType = type
			};
			string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_BEHAVIOUR_HISTORY_DATA_REQ, req.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_BEHAVIOUR_HISTORY_DATA " + cameraId);
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_BEHAVIOUR_HISTORY_DATA " + cameraId);
			if (string.IsNullOrEmpty(rsp)) return null;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			List<BehaviorInfo> behaviorInfoList = new List<BehaviorInfo> { };
			XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/DataInfoSet");
			foreach (XmlNode valueNode in xmlNodes) 
		    {
				BehaviorInfo behaviorInfo = new BehaviorInfo();
				behaviorInfo.CameraID = valueNode.SelectSingleNode("CameraID").InnerText;
				behaviorInfo.StartTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("BeginTimeSec").InnerText));
				behaviorInfo.EndTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("EndTimeSec").InnerText));
				behaviorInfo.EventType = (BehaviorType)Convert.ToUInt32(valueNode.SelectSingleNode("EventType").InnerText);
				behaviorInfo.EventImgUrl = valueNode.SelectSingleNode("EventImgUrl").InnerText;
				// 目标矩形
				string strRect = valueNode.SelectSingleNode("EventObjRect").InnerText;
				string[] rectArry = strRect.Split(',');
				System.Drawing.Rectangle rectItem = new System.Drawing.Rectangle(Convert.ToInt32(rectArry[0]),
																				 Convert.ToInt32(rectArry[1]),
																				 Convert.ToInt32(rectArry[2]),
																				 Convert.ToInt32(rectArry[3]));
				behaviorInfo.EventObjRect = rectItem;
				behaviorInfo.EventVideoUrl = valueNode.SelectSingleNode("EventVideoUrl").InnerText;
				behaviorInfoList.Add(behaviorInfo);
			}
			return behaviorInfoList;
		}

        public List<SubscribeInfo> GET_SUBSCRIBE_DATA(string username) 
		{
            SMS_MSG_GET_SUBSCRIBE_DATA_REQ req = new SMS_MSG_GET_SUBSCRIBE_DATA_REQ()
			{
				UserName = username,
			};
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_GET_SUBSCRIBE_DATA_REQ>(MessageCmd.SMS_MSG_GET_SUBSCRIBE_DATA_REQ, req);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_SUBSCRIBE_DATA username" + username);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp)) return null;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
            List<SubscribeInfo> infoList = new List<SubscribeInfo> { };
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/SubscribeInfo");
			foreach (XmlNode valueNode in xmlNodes) 
		    {
                SubscribeInfo info = new SubscribeInfo();
				info.CameraID = valueNode.SelectSingleNode("CameraID").InnerText;
                info.SubscribeHandle = Convert.ToUInt32(valueNode.SelectSingleNode("SubscribeHandle").InnerText);
                info.UserName = valueNode.SelectSingleNode("UserName").InnerText;
                info.ClientIP = valueNode.SelectSingleNode("ClientIP").InnerText;
                info.ClientPort = Convert.ToUInt32(valueNode.SelectSingleNode("ClientPort").InnerText);
                info.DataType = Convert.ToUInt32(valueNode.SelectSingleNode("DataType").InnerText);
                info.BlackListHandle = Convert.ToUInt32(valueNode.SelectSingleNode("BlackListHandle").InnerText);
				infoList.Add(info);
			}
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_SUBSCRIBE_DATA count:" + infoList.Count);
			return infoList;
		}
        public uint ADD_SUBSCRIBE_DATA(string username, string clientIP, uint clientPort, string cameraId, uint type, uint subscibrparam = 0) 
		{
            SMS_MSG_ADD_SUBSCRIBE_DATA_REQ req = new SMS_MSG_ADD_SUBSCRIBE_DATA_REQ()
            {
                UserName = username,
                BlackListHandle = subscibrparam,
                CameraID = cameraId,
                ClientIP = clientIP,
                ClientPort = clientPort,
                DataType = type,
            };
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_ADD_SUBSCRIBE_DATA_REQ>(MessageCmd.SMS_MSG_ADD_SUBSCRIBE_DATA_REQ, req);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start ADD_SUBSCRIBE_DATA username" + username);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp)) return 0;

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
            XmlNode xmlNodes = xdoc.SelectSingleNode("//Root/Response/SubscribeHandle");
            uint id = Convert.ToUInt32(xmlNodes.InnerText);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   ADD_SUBSCRIBE_DATA ret id:" + id);
			return id;
		}
        public void DEL_SUBSCRIBE_DATA(uint subscribeHandle) 
		{
            SMS_MSG_DEL_SUBSCRIBE_DATA_REQ req = new SMS_MSG_DEL_SUBSCRIBE_DATA_REQ()
            {
                SubscribeHandle = subscribeHandle,
            };
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_DEL_SUBSCRIBE_DATA_REQ>(MessageCmd.SMS_MSG_DEL_SUBSCRIBE_DATA_REQ, req);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start DEL_SUBSCRIBE_DATA subscribeHandle" + subscribeHandle);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp)) 
                return ;

            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   DEL_SUBSCRIBE_DATA ret :" + 0);
		}



        public uint ADD_FACE_CONTORL_DATA(string cameraId, uint controlThreshold, uint blackListHandle, uint controlNation = 1000, uint controlSex = 3, uint beginAge = 0, uint endAge = 0)
        {
            SMS_MSG_ADD_FACE_CONTORL_DATA_REQ req = new SMS_MSG_ADD_FACE_CONTORL_DATA_REQ()
            {
                BlackListHandle = blackListHandle.ToString(),
                CameraID = cameraId,
                BeginAge = beginAge,
                ControlNation = controlNation.ToString(),
                ControlSex = controlSex,
                ControlThreshold = controlThreshold,
                EndAge = endAge,
            };
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_ADD_FACE_CONTORL_DATA_REQ>(MessageCmd.SMS_MSG_ADD_FACE_CONTORL_DATA_REQ, req);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices start ADD_FACE_CONTORL_DATA cameraId:{0},controlThreshold:{1},blackListHandle:{2}", cameraId, controlThreshold, blackListHandle));
            string rsp = Send(message);
            if (string.IsNullOrEmpty(rsp)) return 0;

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            XmlNode xmlNodes = xdoc.SelectSingleNode("//Root/Response/FaceControlHandle");
            uint id = Convert.ToUInt32(xmlNodes.InnerText);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   ADD_FACE_CONTORL_DATA ret id:" + id);
            return id;

        }
        public void DEL_FACE_CONTORL_DATA(uint faceControlHandle) 
		{
            SMS_MSG_DEL_FACE_CONTORL_DATA_REQ req = new SMS_MSG_DEL_FACE_CONTORL_DATA_REQ()
            {
                FaceControlHandle = faceControlHandle,
            };
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_DEL_FACE_CONTORL_DATA_REQ>(MessageCmd.SMS_MSG_DEL_FACE_CONTORL_DATA_REQ, req);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start DEL_FACE_CONTORL_DATA faceControlHandle" + faceControlHandle);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp)) 
                return ;

            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   DEL_FACE_CONTORL_DATA ret :" + 0);
		}
        public void MDF_FACE_CONTORL_DATA(uint faceControlHandle, string cameraId, uint controlThreshold, uint blackListHandle, string controlNation = "1000", uint controlSex = 3, uint beginAge = 0, uint endAge = 0)
        {
            SMS_MSG_MDF_FACE_CONTORL_DATA_REQ req = new SMS_MSG_MDF_FACE_CONTORL_DATA_REQ()
            { FaceControlHandle = faceControlHandle,
                BlackListHandle = blackListHandle.ToString(),
                CameraID = cameraId,
                BeginAge = beginAge,
                ControlNation = controlNation,
                ControlSex = controlSex,
                ControlThreshold = controlThreshold,
                EndAge = endAge,
            };
            string message = SearchProtocol.BuildProtocolBody<SMS_MSG_MDF_FACE_CONTORL_DATA_REQ>(MessageCmd.SMS_MSG_MDF_FACE_CONTORL_DATA_REQ, req);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("SearchServices start MDF_FACE_CONTORL_DATA faceControlHandle:{3},cameraId:{0},controlThreshold:{1},blackListHandle:{2}", cameraId, controlThreshold, blackListHandle, faceControlHandle));
            string rsp = Send(message);
            if (string.IsNullOrEmpty(rsp)) 
                return ;

            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   MDF_FACE_CONTORL_DATA ret ");
        }
        public List<FaceControlInfo> GET_FACE_CONTORL_DATA() 
		{
            string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_FACE_CONTORL_DATA_REQ, "");
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_FACE_CONTORL_DATA ");
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp)) 
                return null;
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<FaceControlInfo> infoList = new List<FaceControlInfo> { };
            XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/FaceControlList/FaceControlInfo");
            foreach (XmlNode valueNode in xmlNodes)
            {
                FaceControlInfo info = new FaceControlInfo();
                info.CameraID = valueNode.SelectSingleNode("CameraID").InnerText;
                string[] bl = valueNode.SelectSingleNode("BlackListHandle").InnerText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                info.BlackListHandle = bl.Select(it => Convert.ToUInt32(it)).ToList();
                string[] nations = valueNode.SelectSingleNode("ControlNation").InnerText.Split(',');
                info.ControlNation = new List<E_PEOPLE_NATION>();
                foreach (var item in nations)
                {
                    info.ControlNation.Add((E_PEOPLE_NATION)Convert.ToUInt32( item));
                }
                info.BeginAge = Convert.ToUInt32(valueNode.SelectSingleNode("BeginAge").InnerText);
                info.EndAge =Convert.ToUInt32(valueNode.SelectSingleNode("EndAge").InnerText);
                info.ControlSex = (E_MOVE_OBJ_PEOPLE_GENDER_TYPE)Convert.ToUInt32(valueNode.SelectSingleNode("ControlSex").InnerText);
                info.ControlThreshold = Convert.ToUInt32(valueNode.SelectSingleNode("ControlThreshold").InnerText);
                info.FaceControlHandle = Convert.ToUInt32(valueNode.SelectSingleNode("FaceControlHandle").InnerText);
                infoList.Add(info);
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices End   GET_FACE_CONTORL_DATA ret :" + 0);
            return infoList;
		}

		public List<FaceAlarmInfoV3_1> GET_FACE_ALARM_HISTORY_DATA(string cameraId, UInt32 startTime, UInt32 endTime, string blackListStr) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<Request>");
			sb.AppendLine("<CameraID>" + cameraId + "</CameraID>");
			sb.AppendLine("<BlackListHandle>" + blackListStr + "</BlackListHandle>");
			sb.AppendLine("<BeginTime>" + startTime + "</BeginTime>");
			sb.AppendLine("<EndTime>" + endTime + "</EndTime>");
			sb.AppendLine("</Request>");
			string message = SearchProtocol.BuildProtocolBody(MessageCmd.SMS_MSG_GET_FACE_ALARM_HISTORY_DATA_REQ, sb.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices start GET_FACE_ALARM_HISTORY_DATA" + cameraId);
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("SearchServices end   GET_FACE_ALARM_HISTORY_DATA" + cameraId);
			if (string.IsNullOrEmpty(rsp)) return null;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			List<FaceAlarmInfoV3_1> faceSearchList = new List<FaceAlarmInfoV3_1> { };
			XmlNodeList picInfoNodes = xdoc.SelectNodes("//Root/Response/PictureInfo");

			foreach (XmlNode valueNode in picInfoNodes) {
				FaceAlarmInfoV3_1 faceData = new FaceAlarmInfoV3_1();
				faceData.OriFacePicPath = valueNode.SelectSingleNode("OriFacePicPath").InnerText;
				string positionStr = valueNode.SelectSingleNode("FacePosition").InnerText;
				string[] posStrs = positionStr.Split(',');
				faceData.FacePosition = new System.Drawing.Rectangle(Convert.ToInt32(posStrs[0]),
																	Convert.ToInt32(posStrs[1]),
																	Convert.ToInt32(posStrs[2]),
																	Convert.ToInt32(posStrs[3]));
				faceData.BeginTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("BeginTime").InnerText));
				faceData.EndTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("EndTime").InnerText));
				faceData.CameraID = valueNode.SelectSingleNode("CameraID").InnerText;

				XmlNodeList blackLibNodes = valueNode.SelectNodes("AlarmList/AlarmInfo");

				foreach (XmlNode blackLib in blackLibNodes) {
					FaceAlarmInfoV3_1 faceAInfo = new FaceAlarmInfoV3_1();
					faceAInfo.OriFacePicPath = faceData.OriFacePicPath;
					faceAInfo.FacePosition = faceData.FacePosition;
					faceAInfo.BeginTime = faceData.BeginTime;
					faceAInfo.EndTime = faceData.EndTime;
					faceAInfo.CameraID = faceData.CameraID;
					faceAInfo.BlackListHandle = Convert.ToUInt32(blackLib.SelectSingleNode("BlackListHandle").InnerText);
					faceAInfo.BlackListPicInfo = new Dictionary<BlackItem, uint> { };
					XmlNodeList blackItemNodes = blackLib.SelectNodes("BlackListPicInfo");

					foreach (XmlNode blackItem in blackItemNodes) {
						BlackItem item = new BlackItem { };
						item.PicHandel = Convert.ToUInt32(blackItem.SelectSingleNode("PictureHandle").InnerText);
						item.PictureUrl = blackItem.SelectSingleNode("PicturePath").InnerText;
						UInt32 Similar = Convert.ToUInt32(blackItem.SelectSingleNode("Similar").InnerText);
						item.Name = blackItem.SelectSingleNode("PeopleName").InnerText;
						item.PeopleCard = blackItem.SelectSingleNode("PeopleCard").InnerText;
						item.PeopleNation = blackItem.SelectSingleNode("PeopleNation").InnerText;
						item.PeopleAge = Convert.ToUInt32(blackItem.SelectSingleNode("PeopleAge").InnerText);
						item.PeopleSex = Convert.ToUInt32(blackItem.SelectSingleNode("PeopleSex").InnerText);
						item.PeopleHeight = Convert.ToUInt32(blackItem.SelectSingleNode("PeopleHeight").InnerText);
						item.PeopleWeight = Convert.ToUInt32(blackItem.SelectSingleNode("PeopleWeight").InnerText);
						item.BloodType = Convert.ToUInt32(blackItem.SelectSingleNode("BloodType").InnerText);
						item.Address = blackItem.SelectSingleNode("Address").InnerText;
						faceAInfo.BlackListPicInfo.Add(item, Similar);
					}
					faceSearchList.Add(faceAInfo);
				}
			}
			return faceSearchList;
		}
        #endregion

        #region Private Functions

        private ErrorMsg GetErrorMsg(string rsp)
        {
            if (string.IsNullOrEmpty(rsp))
                return new ErrorMsg() { Result = 1, ResultDescription = "无此消息", };

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            ErrorMsg err = new ErrorMsg()
            {
                Result = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText),
                ResultDescription = xdoc.SelectSingleNode("//Root/Response/Describe").InnerText,
            };
            return err;
        }

        private string Send(string msg)
        {
            string rsp;
            try
            {
                rsp =  SearchProtocol.SendProtocol(msg);
                if (FireMessage != null)
                    FireMessage("服务器：【" + ServerIP + "】连接成功");

            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.ErrorWithDebugView(ex.ToString());

                if (ex.ErrorCode == (uint)SDKCallExceptionCode.EndpointNotFound)
                {
                    if (FireMessage != null)
                        FireMessage("连接服务器异常");
                }
                else if (ex.ErrorCode == (uint)SDKCallExceptionCode.NetDispatcherFault)
                {
                    if (FireMessage != null)
                        FireMessage("数据解析异常，请重试");
                }
                else if (ex.ErrorCode == (uint)SDKCallExceptionCode.Other)
                { 
                    if (FireMessage != null)
                        FireMessage("连接服务器异常，未知原因");
                }
                return "";
            }
            ErrorMsg err = GetErrorMsg(rsp);
            if (err.Result != 0)
            {
                throw new SDKCallException(err.Result, err.ResultDescription);
            }
            return rsp;
        }



        #endregion



    }
}
