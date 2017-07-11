using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using IVX.DataModel;
using IVX.Live.WSDataReceiveServices.Interop;

namespace IVX.Live.WSDataReceiveServices
{
    public class  WSDataReceiveServices
    {
        public event Action<TrafficePlateInfo> OnPlateReceived;
        public event Action<BehaviorInfo> OnBehaviorReceived;
        public event Action<TrafficeEventInfoV3_1> OnTrafficEventReceived;
        public event Action<List<FaceAlarmInfoV3_1>> OnFaceAlarmReceived;

            IVXWSProtocol wsprotocol ;
        public void StartService(uint port)
        {
            wsprotocol = new IVXWSProtocol();
            wsprotocol.EventDataReceived += wsprotocol_EventDataReceived;
            wsprotocol.Init(port);
        }

        void wsprotocol_EventDataReceived(string strReqType, byte[] strReqMsg)
        {
            if(strReqType == "IAX3-1")
                ProcessRequest(strReqMsg);
        }
        

        
        public void StopService()
        {
            wsprotocol.Uninit();
            wsprotocol = null;
        }
        public void Clearup()
        {
            if (wsprotocol != null)
                StopService();
        }

        private void ProcessRequest(byte[] strReq)
        {
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            //xdoc.LoadXml(strReq);xdoc.Load()
            System.IO.MemoryStream ms = new System.IO.MemoryStream(strReq);
            xdoc.Load(ms);
            System.Xml.XmlNode item = xdoc.SelectSingleNode("//Root/Head");

            Head req = DataModel.Common.DeserilizeObject<Head>(item.OuterXml);

            System.Xml.XmlNode itemData = xdoc.SelectSingleNode("//Root/Request");

            switch ((EnumProtocolType)req.MsgCmd)
            {
                case EnumProtocolType.SEND_HEARTBEAT:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_PLATE_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_TRAFFIC_EVENT:
                    DoReceiveNOTE_UPLOAD_TRAFFIC_EVENT(itemData);
                    break;
                case EnumProtocolType.NOTE_UPLOAD_TRAFFIC_PARAM:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_BEHAVIOR_EVENT:
                    DoReceiveNOTE_UPLOAD_BEHAVIOR_EVENT(itemData);
                    break;
                case EnumProtocolType.NOTE_UPLOAD_FACECONTROL_EVENT:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_MOVEOBJINFO_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_MOVEFEATURE_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_COLORFEATURE_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_SCENEMARK_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_CROWD_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_PEOPLECOUNT_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT:
                    break;
                case EnumProtocolType.NOTE_IMAGE_SEARCH_DATA:
                    break;
                case EnumProtocolType.NOTE_TRAFFIC_FEATURE_PARAM_DATA:
                    break;
                case EnumProtocolType.NOTE_IMAGE_SEARCH_STD_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA:
                    break;
                case EnumProtocolType.NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA:
                    DoReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(itemData);
                    break;
                case EnumProtocolType.SMS_MSG_FACE_ALARM_DATA_NOTIFY:
                    DoReceiveSMS_MSG_FACE_ALARM_DATA_NOTIFY(itemData);
                    break;
                case EnumProtocolType.TIMEOUT:
                    break;
                default:
                    break;
            }
        }

        private void DoReceiveSMS_MSG_FACE_ALARM_DATA_NOTIFY(XmlNode itemData)
        {

            System.Xml.XmlNode itemCameraCode = itemData.SelectSingleNode("CameraID");
            string CameraID = itemCameraCode.InnerXml;
            System.Xml.XmlNode itemOriFacePicPath = itemData.SelectSingleNode("OriFacePicPath");
            string OriFacePicPath = itemOriFacePicPath.InnerXml;
            System.Xml.XmlNode itemFacePosition = itemData.SelectSingleNode("FacePosition");
            string[] faceposition = itemFacePosition.InnerXml.Split(',');
            System.Drawing.Rectangle FacePosition = new System.Drawing.Rectangle(Convert.ToInt32( faceposition[0])
                , Convert.ToInt32(faceposition[1])
                , Convert.ToInt32(faceposition[2])
                , Convert.ToInt32(faceposition[3]));
            FacePosition = new System.Drawing.Rectangle(FacePosition.X - FacePosition.Width, FacePosition.Y - FacePosition.Height, 3 * FacePosition.Width, 5 * FacePosition.Height);

            System.Xml.XmlNode itemStartTimeSec = itemData.SelectSingleNode("BeginTime");
            uint StartTimeSec = Convert.ToUInt32(itemStartTimeSec.InnerXml);
            DateTime BeginTime = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec);
            System.Xml.XmlNode itemEndTimeSec = itemData.SelectSingleNode("EndTime");
            uint EndTimeSec = Convert.ToUInt32(itemEndTimeSec.InnerXml);
            DateTime EndTime = DataModel.Common.ZEROTIME.AddSeconds(EndTimeSec);

            List<FaceAlarmInfoV3_1> list = new List<FaceAlarmInfoV3_1>();
            foreach (System.Xml.XmlNode item in itemData.SelectNodes("AlarmList/AlarmInfo"))
            {
                FaceAlarmInfoV3_1 info = new FaceAlarmInfoV3_1();
                System.Xml.XmlNode itemBlackListHandle = item.SelectSingleNode("BlackListHandle");
                info.BlackListHandle = Convert.ToUInt32(itemBlackListHandle.InnerXml);
                info.CameraID = CameraID;
                info.OriFacePicPath = OriFacePicPath;
                info.FacePosition = FacePosition;
                info.BeginTime = BeginTime;
                info.EndTime = EndTime;

                info.BlackListPicInfo = new Dictionary<BlackItem,uint>();
                foreach (System.Xml.XmlNode subitem in item.SelectNodes("BlackListPicInfo"))
                {
                    BlackItem blpi = new BlackItem();
                    System.Xml.XmlNode itemPictureHandle = subitem.SelectSingleNode("PictureHandle");
                    blpi.PicHandel = Convert.ToUInt32(itemPictureHandle.InnerXml);
                    System.Xml.XmlNode itemPicturePath = subitem.SelectSingleNode("PicturePath");
                    blpi.PictureUrl = itemPicturePath.InnerXml;
                    System.Xml.XmlNode itemSimilar = subitem.SelectSingleNode("Similar");
                    uint Similar = Convert.ToUInt32(itemSimilar.InnerXml);
                    System.Xml.XmlNode itemPeopleName = subitem.SelectSingleNode("PeopleName");
                    blpi.Name = itemPeopleName.InnerXml;
                    System.Xml.XmlNode itemPeopleCard = subitem.SelectSingleNode("PeopleCard");
                    blpi.PeopleCard = itemPeopleCard.InnerXml;
                    System.Xml.XmlNode itemPeopleNation = subitem.SelectSingleNode("PeopleNation");
                    blpi.PeopleNation = ((E_PEOPLE_NATION) Convert.ToUInt32(itemPeopleNation.InnerXml)).ToString();
                    System.Xml.XmlNode itemPeopleAge = subitem.SelectSingleNode("PeopleAge");
                    blpi.PeopleAge = Convert.ToUInt32(itemPeopleAge.InnerXml);
                    System.Xml.XmlNode itemPeopleSex = subitem.SelectSingleNode("PeopleSex");
                    blpi.PeopleSex =  (uint)(E_PEOPLE_SEX) Convert.ToUInt32(itemPeopleSex.InnerXml);
                    System.Xml.XmlNode itemPeopleHeight = subitem.SelectSingleNode("PeopleHeight");
                    blpi.PeopleHeight = Convert.ToUInt32(itemPeopleHeight.InnerXml);
                    System.Xml.XmlNode itemPeopleWeight = subitem.SelectSingleNode("PeopleWeight");
                    blpi.PeopleWeight = Convert.ToUInt32(itemPeopleWeight.InnerXml);
                    System.Xml.XmlNode itemBloodType = subitem.SelectSingleNode("BloodType");
                    blpi.BloodType = (uint) (E_PEOPLE_BLOODTYPE) Convert.ToUInt32(itemBloodType.InnerXml);
                    System.Xml.XmlNode itemAddress = subitem.SelectSingleNode("Address");
                    blpi.Address = itemAddress.InnerXml;

                    info.BlackListPicInfo.Add(blpi, Similar);
                }
                list.Add(info);
            }

            if (OnFaceAlarmReceived != null)
                OnFaceAlarmReceived(list);
        }

        private void DoReceiveNOTE_UPLOAD_BEHAVIOR_EVENT(XmlNode itemData)
        {
            BehaviorInfo info = new BehaviorInfo();
            System.Xml.XmlNode itemCameraCode = itemData.SelectSingleNode("CameraCode");
            info.CameraID = itemCameraCode.InnerXml;
            System.Xml.XmlNode itemObjId = itemData.SelectSingleNode("ObjId");
            info.ObjectId = Convert.ToUInt32(itemObjId.InnerXml);
            System.Xml.XmlNode itemEventType = itemData.SelectSingleNode("EventType");
            info.EventType = (BehaviorType) Convert.ToUInt32(itemEventType.InnerXml);

            System.Xml.XmlNode itemStartTimeSec = itemData.SelectSingleNode("StartTimeSec");
            uint StartTimeSec = Convert.ToUInt32(itemStartTimeSec.InnerXml);
            System.Xml.XmlNode itemStartTimeMilliSec = itemData.SelectSingleNode("StartTimeMilliSec");
            uint StartTimeMilliSec = Convert.ToUInt32(itemStartTimeMilliSec.InnerXml);
            info.StartTime = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec).AddMilliseconds(StartTimeMilliSec);
            System.Xml.XmlNode itemEndTimeSec = itemData.SelectSingleNode("EndTimeSec");
            uint EndTimeSec = Convert.ToUInt32(itemEndTimeSec.InnerXml);
            System.Xml.XmlNode itemEndTimeMilliSec = itemData.SelectSingleNode("EndTimeMilliSec");
            uint EndTimeMilliSec = Convert.ToUInt32(itemEndTimeMilliSec.InnerXml);
            info.EndTime = DataModel.Common.ZEROTIME.AddSeconds(EndTimeSec).AddMilliseconds(EndTimeMilliSec);


            int EventObjCoordX = Convert.ToInt32(itemData.SelectSingleNode("EventObjCoordX").InnerXml);
            int EventObjCoordY = Convert.ToInt32(itemData.SelectSingleNode("EventObjCoordY").InnerXml);
            int EventObjWidth = Convert.ToInt32(itemData.SelectSingleNode("EventObjWidth").InnerXml);
            int EventObjHeight = Convert.ToInt32(itemData.SelectSingleNode("EventObjHeight").InnerXml);
            info.EventObjRect = new System.Drawing.Rectangle(EventObjCoordX, EventObjCoordY, EventObjWidth, EventObjHeight);
            System.Xml.XmlNode itemObjType = itemData.SelectSingleNode("ObjType");
            info.ObjType =( E_SEARCH_RESULT_OBJECT_TYPE) Convert.ToUInt32(itemObjType.InnerXml);
            System.Xml.XmlNode itemObjNum = itemData.SelectSingleNode("ObjNum");
            info.ObjNum = Convert.ToUInt32(itemObjNum.InnerXml);
            
            string ImageBuffer = itemData.SelectSingleNode("ImageBuffer").InnerXml;
            info.Image = new System.IO.MemoryStream(Convert.FromBase64String(ImageBuffer));
            if (OnBehaviorReceived != null)
                OnBehaviorReceived(info);

        }

        private void DoReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(XmlNode itemData)
        {
            DataModel.TrafficePlateInfo info = new DataModel.TrafficePlateInfo();
            System.Xml.XmlNode itemCameraCode = itemData.SelectSingleNode("CameraCode");
            info.CameraCode = itemCameraCode.InnerXml;
            System.Xml.XmlNode itemObjId = itemData.SelectSingleNode("ObjId");
            info.ObjId = Convert.ToUInt32(itemObjId.InnerXml);
            System.Xml.XmlNode itemBeginTimeMilliSec = itemData.SelectSingleNode("BeginTimeMilliSec");
            ulong BeginTimeMilliSec = Convert.ToUInt32(itemBeginTimeMilliSec.InnerXml);
            info.StartTime = DataModel.Common.ZEROTIME.AddMilliseconds(BeginTimeMilliSec);
            System.Xml.XmlNode itemEndTimeMilliSec = itemData.SelectSingleNode("EndTimeMilliSec");
            ulong EndTimeMilliSec = Convert.ToUInt32(itemEndTimeMilliSec.InnerXml);
            info.EndTime = DataModel.Common.ZEROTIME.AddMilliseconds(EndTimeMilliSec);
            System.Xml.XmlNode itemPlateNum = itemData.SelectSingleNode("PlateNum");
            info.PlateNum = itemPlateNum.InnerXml;
            System.Xml.XmlNode itemPlateReliability = itemData.SelectSingleNode("PlateReliability");
            info.Reliability = Convert.ToUInt32(itemPlateReliability.InnerXml);
            System.Xml.XmlNode itemPlateColor = itemData.SelectSingleNode("PlateColor");
            info.PlateColor = Convert.ToUInt32(itemPlateColor.InnerXml);
            System.Xml.XmlNode itemPlateNumRow = itemData.SelectSingleNode("PlateNumRow");
            info.PlateNumRow = (E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE)Convert.ToUInt32(itemPlateNumRow.InnerXml);
            System.Xml.XmlNode itemVehicleLabel = itemData.SelectSingleNode("VehicleLabel");
            info.VehicleLabel = Convert.ToUInt32(itemVehicleLabel.InnerXml);
            System.Xml.XmlNode itemVehicleLabelDetail = itemData.SelectSingleNode("VehicleLabelDetail");
            info.VehicleLabelDetail = Convert.ToUInt32(itemVehicleLabelDetail.InnerXml);
            System.Xml.XmlNode itemVehicleType = itemData.SelectSingleNode("VehicleType");
            info.VehicleType = (E_VDA_SEARCH_VEHICLE_TYPE)Convert.ToUInt32(itemVehicleType.InnerXml);
            System.Xml.XmlNode itemVehicleTypeDetail = itemData.SelectSingleNode("VehicleTypeDetail");
            info.VehicleTypeDetail = (E_VDA_SEARCH_VEHICLE_DETAIL_TYPE)Convert.ToUInt32(itemVehicleTypeDetail.InnerXml);

            var list = itemData.SelectNodes("DataInfoSet");
            info.VehicleColorInfo = new List<uint>();
            foreach (System.Xml.XmlNode item in list)
            {
                uint VehicleColor = Convert.ToUInt32(item.SelectSingleNode("VehicleColor").InnerXml);
                info.VehicleColorInfo.Add(VehicleColor);
            }
            int ObjRectX = Convert.ToInt32(itemData.SelectSingleNode("ObjRectX").InnerXml);
            int ObjRectY = Convert.ToInt32(itemData.SelectSingleNode("ObjRectY").InnerXml);
            int ObjRectWidth = Convert.ToInt32(itemData.SelectSingleNode("ObjRectWidth").InnerXml);
            int ObjRectHeight = Convert.ToInt32(itemData.SelectSingleNode("ObjRectHeight").InnerXml);
            System.Drawing.Rectangle ObjRect = new System.Drawing.Rectangle(ObjRectX, ObjRectY, ObjRectWidth, ObjRectHeight);
            info.ObjRect = ObjRect;

            string itemObjImgBuffer = itemData.SelectSingleNode("ObjImgBuffer").InnerXml;
            info.ObjImg = new System.IO.MemoryStream(Convert.FromBase64String(itemObjImgBuffer));

            int PlateRectX = Convert.ToInt32(itemData.SelectSingleNode("PlateRectX").InnerXml);
            int PlateRectY = Convert.ToInt32(itemData.SelectSingleNode("PlateRectY").InnerXml);
            int PlateRectWidth = Convert.ToInt32(itemData.SelectSingleNode("PlateRectWidth").InnerXml);
            int PlateRectHeight = Convert.ToInt32(itemData.SelectSingleNode("PlateRectHeight").InnerXml);
            System.Drawing.Rectangle PlateRect = new System.Drawing.Rectangle(PlateRectX, PlateRectY, PlateRectWidth, PlateRectHeight);
            info.PlateRect = PlateRect;

            string itemPlateImgBuffer = itemData.SelectSingleNode("PlateImgBuffer").InnerXml;
            info.PlateImg = new System.IO.MemoryStream(Convert.FromBase64String(itemPlateImgBuffer));

            string itemOriginalImageBuffer = itemData.SelectSingleNode("OriginalImageBuffer").InnerXml;
            info.OriginalImage = new System.IO.MemoryStream(Convert.FromBase64String(itemOriginalImageBuffer));

            info.PlateId = DateTime.Now.Ticks;

            if (OnPlateReceived != null)
                OnPlateReceived(info);

        }

        private void DoReceiveNOTE_UPLOAD_TRAFFIC_EVENT(System.Xml.XmlNode itemData)
        {
            DataModel.TrafficeEventInfoV3_1 info = new DataModel.TrafficeEventInfoV3_1();
            System.Xml.XmlNode itemCameraCode = itemData.SelectSingleNode("CameraCode");
            info.CameraCode = itemCameraCode.InnerXml;
            System.Xml.XmlNode itemEventType = itemData.SelectSingleNode("EventType");
            info.EventType = (DataModel.E_TRAFFIC_EVENT_TYPE)Convert.ToInt32( itemEventType.InnerXml);
            System.Xml.XmlNode itemStartTimeSec = itemData.SelectSingleNode("StartTimeSec");
            uint StartTimeSec = Convert.ToUInt32(itemStartTimeSec.InnerXml);
            System.Xml.XmlNode itemStartTimeMilliSec = itemData.SelectSingleNode("StartTimeMilliSec");
            uint StartTimeMilliSec = Convert.ToUInt32(itemStartTimeMilliSec.InnerXml);
            info.StartTime = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec).AddMilliseconds(StartTimeMilliSec);
            System.Xml.XmlNode itemEndTimeSec = itemData.SelectSingleNode("EndTimeSec");
            uint EndTimeSec = Convert.ToUInt32(itemEndTimeSec.InnerXml);
            System.Xml.XmlNode itemEndTimeMilliSec = itemData.SelectSingleNode("EndTimeMilliSec");
            uint EndTimeMilliSec = Convert.ToUInt32(itemEndTimeMilliSec.InnerXml);
            info.EndTime = DataModel.Common.ZEROTIME.AddSeconds(EndTimeSec).AddMilliseconds(EndTimeMilliSec);
            System.Xml.XmlNode itemObjRoadWayNum = itemData.SelectSingleNode("ObjRoadWayNum");
            info.ObjRoadWayNum = Convert.ToUInt32(itemObjRoadWayNum.InnerXml);

            var list = itemData.SelectNodes("DataInfoSet");
            info.EventImgInfo = new List<Tuple<System.Drawing.Rectangle, System.IO.MemoryStream>>();
            foreach (System.Xml.XmlNode item in list)
            {
                int itemEventObjCoordX = Convert.ToInt32(item.SelectSingleNode("EventObjCoordX").InnerXml);
                int itemEventObjCoordY = Convert.ToInt32(item.SelectSingleNode("EventObjCoordY").InnerXml);
                int itemEventObjWidth = Convert.ToInt32(item.SelectSingleNode("EventObjWidth").InnerXml);
                int itemEventObjHeight = Convert.ToInt32(item.SelectSingleNode("EventObjHeight").InnerXml);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(itemEventObjCoordX, itemEventObjCoordY, itemEventObjWidth, itemEventObjHeight);

                string itemEventImg1Data = item.SelectSingleNode("EventImg1Data").InnerXml;
                System.IO.MemoryStream stream = new System.IO.MemoryStream(Convert.FromBase64String(itemEventImg1Data));
                info.EventImgInfo.Add(new Tuple<System.Drawing.Rectangle, System.IO.MemoryStream>(rect, stream));
            }
            string ComposeImgData = itemData.SelectSingleNode("ComposeImgData").InnerXml;
            info.ComposeImgData = new System.IO.MemoryStream(Convert.FromBase64String(ComposeImgData));
            System.Xml.XmlNode itemEventVideoUrl = itemData.SelectSingleNode("EventVideoUrl");
            info.EventVideoUrl = itemEventVideoUrl.InnerXml;
            System.Xml.XmlNode itemReliability = itemData.SelectSingleNode("Reliability");
            info.Reliability = Convert.ToUInt32(itemReliability.InnerXml);
            System.Xml.XmlNode itemPlateNum = itemData.SelectSingleNode("PlateNum");
            info.PlateNum = itemPlateNum.InnerXml;
            System.Xml.XmlNode itemPlateNumRow = itemData.SelectSingleNode("PlateNumRow");
            info.PlateNumRow = (DataModel.E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE) Convert.ToUInt32(itemPlateNumRow.InnerXml);
            System.Xml.XmlNode itemPlateColor = itemData.SelectSingleNode("PlateColor");
            info.PlateColor = Convert.ToUInt32(itemPlateColor.InnerXml);
            System.Xml.XmlNode itemVehicleColor = itemData.SelectSingleNode("VehicleColor");
            info.VehicleColor = Convert.ToUInt32(itemVehicleColor.InnerXml);
            System.Xml.XmlNode itemVehicleType = itemData.SelectSingleNode("VehicleType");
            info.VehicleType = (DataModel.E_VDA_SEARCH_VEHICLE_TYPE) Convert.ToUInt32(itemVehicleType.InnerXml);
            System.Xml.XmlNode itemVehicleTypeDetail = itemData.SelectSingleNode("VehicleTypeDetail");
            info.VehicleTypeDetail = (DataModel.E_VDA_SEARCH_VEHICLE_DETAIL_TYPE) Convert.ToUInt32(itemVehicleTypeDetail.InnerXml);
            System.Xml.XmlNode itemVehicleLabel = itemData.SelectSingleNode("VehicleLabel");
            info.VehicleLabel = Convert.ToUInt32(itemVehicleLabel.InnerXml);
            System.Xml.XmlNode itemVehicleLabelDetail = itemData.SelectSingleNode("VehicleLabelDetail");
            info.VehicleLabelDetail = Convert.ToUInt32(itemVehicleLabelDetail.InnerXml);
            System.Xml.XmlNode itemVehicleSpeed = itemData.SelectSingleNode("VehicleSpeed");
            info.VehicleSpeed = Convert.ToUInt32(itemVehicleSpeed.InnerXml);
            System.Xml.XmlNode itemDirection = itemData.SelectSingleNode("Direction");
            info.Direction = (DataModel.E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE) Convert.ToUInt32(itemDirection.InnerXml);

            if (OnTrafficEventReceived != null)
                OnTrafficEventReceived(info);

        }

}
}
