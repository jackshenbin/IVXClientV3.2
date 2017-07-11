using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using System.Diagnostics;
using System.Data;
using IVX.Live.DataReceiveServices;

namespace IVX.Live.DataReceiveServices
{
    public class DataReceiveService
    {
        private Interop.Protocol realtimereceive = new Interop.Protocol();
        //public event Action<Interop.NOTE_UPLOAD_CROWD_DATA> OnCrowdReceived;
        public event Action<TrafficePlateInfo> OnPlateReceived;
        public event Action<BehaviorInfo> OnBehaviorReceived;
        //public event Action<Interop.NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT> OnPeopleCountAlarmReceived;
        //public event Action<Interop.NOTE_UPLOAD_PEOPLECOUNT_DATA> OnPeopleCountReceived;
        //public event Action<Interop.NOTE_TRAFFIC_FEATURE_PARAM_DATA> OnTrafficFeatureParamReceived;
        public event Action<TrafficeEventInfoV3_1> OnTrafficEventReceived;
        

        #region Constructors
        public DataReceiveService(uint port)
        {
            realtimereceive.OnReceiveNOTE_UPLOAD_CROWD_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_CROWD_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_PLATE_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_PLATE_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM += realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM;
            realtimereceive.OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT;
            realtimereceive.OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA += realtimereceive_OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA;
           
            realtimereceive.Open((int)port);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_CROWD_DATA(Interop.Protocol tcp, Interop.NOTE_UPLOAD_CROWD_DATA obj)
        {
            string msg = string.Format("CameraCode:{0},TimeSec:{1},"
                   + "PeopleCount:{2},"
                   + "Area:{3},"
                   , obj.CameraCode
                   , obj.TimeSec
                   , obj.PeopleCount
                   , obj.Area
                   );

            MyLog4Net.Container.Instance.Log.Debug(msg);
            //if (OnCrowdReceived != null)
            //    OnCrowdReceived(obj);
        }
        void realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT(Interop.Protocol tcp, Interop.NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT obj)
        {
            string msg = string.Format("DetectRegionID:{1}," + Environment.NewLine
                   + "BehaviorType:{2}," + Environment.NewLine
                   + "ObjectTotalNum:{3}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.DetectRegionID
                   , obj.BehaviorType
                   , obj.ObjectTotalNum
                   );
            MyLog4Net.Container.Instance.Log.Debug(msg);
            //if (OnPeopleCountAlarmReceived != null)
            //    OnPeopleCountAlarmReceived(obj);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM(Interop.Protocol tcp, Interop.NOTE_UPLOAD_TRAFFIC_PARAM obj)
        {
            string msg = string.Format("StatiIctisTime:{1}," + Environment.NewLine
                               + "RoadWayNum:{2}," + Environment.NewLine
                               + "TrafficFluxBig:{3}," + Environment.NewLine
                               + "TrafficFluxMiddle:{4}," + Environment.NewLine
                               + "TrafficFluxSmall:{5}," + Environment.NewLine
                               + "TrafficFluxUnMotor:{6}," + Environment.NewLine
                               + "TrafficFluxPerson:{7}," + Environment.NewLine
                               + "TrafficFlux:{8}," + Environment.NewLine
                               + "AvgVehiSpeed:{9}," + Environment.NewLine
                               + "AvgOccupyRatio:{10}," + Environment.NewLine
                               + "QueueLen:{11}," + Environment.NewLine
                               + "AvgVehiDistance:{12}," + Environment.NewLine
                               , obj.CameraCode
                               , obj.StatiIctisTime
                               , obj.RoadWayNum
                               , obj.TrafficFluxBig
                               , obj.TrafficFluxMiddle
                               , obj.TrafficFluxSmall
                               , obj.TrafficFluxUnMotor
                               , obj.TrafficFluxPerson
                               , obj.TrafficFlux
                               , obj.AvgVehiSpeed
                               , obj.AvgOccupyRatio
                               , obj.QueueLen
                               , obj.AvgVehiDistance
                               );
            MyLog4Net.Container.Instance.Log.Debug(msg);


        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT(Interop.Protocol tcp, Interop.NOTE_UPLOAD_TRAFFIC_EVENT obj)
        {
            string msg = string.Format("EventType:{1}," + Environment.NewLine
                                          + "StartTime:{2}," + Environment.NewLine
                                          + "EndTime:{3}," + Environment.NewLine
                                          + "ObjRoadWayNum:{4}," + Environment.NewLine
                                          + "EventImgInfo.Count:{5}," + Environment.NewLine
                                          + "Reliability:{6}," + Environment.NewLine
                                          + "PlateNum:{7}," + Environment.NewLine
                                          + "PlateNumRow:{8}," + Environment.NewLine
                                          + "PlateColor:{9}," + Environment.NewLine
                                           + "VehicleColor:{10}," + Environment.NewLine
                                           + "VehicleType:{11}," + Environment.NewLine
                                           + "VehicleTypeDetail:{12}," + Environment.NewLine
                                           + "VehicleLabel:{13}," + Environment.NewLine
                                           + "VehicleLabelDetail:{14}," + Environment.NewLine
                                           + "VehicleSpeed:{15}," + Environment.NewLine
                                           + "Direction:{16}," + Environment.NewLine
                                          , obj.CameraCode
                                          , obj.EventType
                                          , obj.StartTime
                                          , obj.EndTime
                                          , obj.ObjRoadWayNum
                                          , obj.EventImgInfo.Count
                                          , obj.Reliability
                                          , obj.PlateNum
                                          , obj.PlateNumRow
                                          , obj.PlateColor
                                           , obj.VehicleColor
                                           , obj.VehicleType
                                           , obj.VehicleTypeDetail
                                           , obj.VehicleLabel
                                           , obj.VehicleLabelDetail
                                           , obj.VehicleSpeed
                                           , obj.Direction
                                          );
            MyLog4Net.Container.Instance.Log.Debug(msg);

            DataModel.TrafficeEventInfoV3_1 info = new DataModel.TrafficeEventInfoV3_1()
            { 
                ComposeImgURL = "",
                 EventId = DateTime.Now.Ticks,
                  EventImgURLInfo = new List<Tuple<System.Drawing.Rectangle,string>>(),
                CameraCode = obj.CameraCode,
                ComposeImgData = obj.ComposeImg,
                Direction = (E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE)obj.Direction,
                EndTime = obj.EndTime,
                EventImgInfo = new List<Tuple<System.Drawing.Rectangle, System.IO.MemoryStream>>(),
                EventType = (E_TRAFFIC_EVENT_TYPE)obj.EventType,
                EventVideoUrl = obj.EventVideoUrl,
                ObjRoadWayNum = obj.ObjRoadWayNum,
                PlateColor = obj.PlateColor,
                PlateNum = obj.PlateNum,
                PlateNumRow = (E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE)obj.PlateNumRow,
                Reliability = obj.Reliability,
                StartTime = obj.StartTime,
                VehicleColor = obj.VehicleColor,
                VehicleLabel = obj.VehicleLabel,
                VehicleLabelDetail = obj.VehicleLabelDetail,
                VehicleSpeed = obj.VehicleSpeed,
                VehicleType = (E_VDA_SEARCH_VEHICLE_TYPE)obj.VehicleType,
                VehicleTypeDetail = (E_VDA_SEARCH_VEHICLE_DETAIL_TYPE)obj.VehicleTypeDetail,
            };
            foreach (var item in obj.EventImgInfo)
            {
                info.EventImgInfo.Add(new Tuple<System.Drawing.Rectangle, System.IO.MemoryStream>(item.EventObjRect, item.EventImgData));
            }
            if (OnTrafficEventReceived != null)
                OnTrafficEventReceived(info);

        }
        void realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(Interop.Protocol tcp, Interop.NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA obj)
        {
            string msg = string.Format("PlateNum:{1}," + Environment.NewLine
                   + "PlateNumRow:{2}," + Environment.NewLine
                   + "PlateColor:{3}," + Environment.NewLine
                   + "VehicleType:{4}," + Environment.NewLine
                   + "VehicleTypeDetail:{5}," + Environment.NewLine
                   + "VehicleLabel:{6}," + Environment.NewLine
                   + "VehicleLabelDetail:{7}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.PlateNum
                   , obj.PlateNumRow
                   , obj.PlateColor
                   , obj.VehicleType
                   , obj.VehicleTypeDetail
                   , obj.VehicleLabel
                   , obj.VehicleLabelDetail
                   );
            MyLog4Net.Container.Instance.Log.Debug(msg);

            DataModel.TrafficePlateInfo info = new DataModel.TrafficePlateInfo()
            {
                PlateId = DateTime.Now.Ticks,
                CameraCode = obj.CameraCode,
                EndTime = obj.EndTimeMilliSec,
                PlateColor = obj.PlateColor,
                PlateNum = obj.PlateNum,
                PlateNumRow = (E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE)obj.PlateNumRow,
                Reliability = obj.PlateReliability,
                StartTime = obj.BeginTimeMilliSec,
                VehicleLabel = obj.VehicleLabel,
                VehicleLabelDetail = obj.VehicleLabelDetail,
                VehicleType = (E_VDA_SEARCH_VEHICLE_TYPE)obj.VehicleType,
                VehicleTypeDetail = (E_VDA_SEARCH_VEHICLE_DETAIL_TYPE)obj.VehicleTypeDetail,
                ObjId = obj.ObjId,
                ObjImg = obj.ObjImg,
                ObjRect = obj.ObjRect,
                OriginalImage = obj.OriginalImage,
                PlateImg = obj.PlateImg,
                PlateRect = obj.PlateRect,
                VehicleColorInfo = new List<uint>(),
            };
            foreach (var item in obj.VehicleColorInfo)
            {
                info.VehicleColorInfo.Add(item.VehicleColor);
            }
            if (OnPlateReceived != null)
                OnPlateReceived(info);
        }


        void realtimereceive_OnReceiveNOTE_UPLOAD_PLATE_DATA(Interop.Protocol tcp, Interop.NOTE_UPLOAD_PLATE_DATA obj)
        {
            string msg = string.Format("TimeStamp:{1}," + Environment.NewLine
                   + "ObjectType:{2}," + Environment.NewLine
                   + "Reliability:{3}," + Environment.NewLine
                   + "PlateNum:{4}," + Environment.NewLine
                   + "PlateNumRow:{5}," + Environment.NewLine
                   + "PlateColor:{6}," + Environment.NewLine
                   + "VehicleColor:{7}," + Environment.NewLine
                   + "VehicleType:{8}," + Environment.NewLine
                   + "VehicleTypeDetail:{9}," + Environment.NewLine
                   + "VehicleLabel:{10}," + Environment.NewLine
                   + "VehicleLabelDetail:{11}," + Environment.NewLine
                   + "VehicleSpeed:{12}," + Environment.NewLine
                   + "Direction:{13}," + Environment.NewLine
                   + "RoadWayNum:{14}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.TimeStamp
                   , obj.ObjectType
                   , obj.Reliability
                   , obj.PlateNum
                   , obj.PlateNumRow
                   , obj.PlateColor
                   , obj.VehicleColor
                   , obj.VehicleType
                   , obj.VehicleTypeDetail
                   , obj.VehicleLabel
                   , obj.VehicleLabelDetail
                   , obj.VehicleSpeed
                   , obj.Direction
                   , obj.RoadWayNum
                   );
            MyLog4Net.Container.Instance.Log.Debug(msg);

            //if (OnPlateReceived != null)
            //    OnPlateReceived(obj);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA(Interop.Protocol tcp, Interop.NOTE_UPLOAD_MOVEOBJINFO_DATA obj)
        {
            string msg = string.Format("ObjectId:{1}," + Environment.NewLine
                   + "ObjType:{2}," + Environment.NewLine
                   + "BeginTime:{3}," + Environment.NewLine
                   + "EndTime:{4}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.ObjectId
                   , obj.ObjType
                   , obj.BeginTime
                   , obj.EndTime
                   );

            MyLog4Net.Container.Instance.Log.Debug(msg);

        }


        void realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA(Interop.Protocol tcp, Interop.NOTE_UPLOAD_PEOPLECOUNT_DATA obj)
        {
            string msg = string.Format("DetectRegionID:{1}," + Environment.NewLine
                   + "BehaviorType:{2}," + Environment.NewLine
                   + "ObjectTotalNum:{3}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.DetectRegionID
                   , obj.BehaviorType
                   , obj.ObjectTotalNum
                   );

            MyLog4Net.Container.Instance.Log.Debug(msg);

            //if (OnPeopleCountReceived != null)
            //    OnPeopleCountReceived(obj);

        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT(Interop.Protocol tcp, Interop.NOTE_UPLOAD_BEHAVIOR_EVENT obj)
        {
            string msg = string.Format("ObjectId:{1}," + Environment.NewLine
                + "EventType:{2}," + Environment.NewLine
                + "StartTime:{3}," + Environment.NewLine
                + "EndTime:{4}," + Environment.NewLine
                + "EventObjRect:{5}," + Environment.NewLine
                + "ObjType:{6}," + Environment.NewLine
                + "ObjNum:{7}," + Environment.NewLine
                        //+ "Image:{10}," + Environment.NewLine
                        //+ "Reserved:{11}," + Environment.NewLine
                , obj.CameraCode
                , obj.ObjectId
                , obj.EventType
                , obj.StartTime
                , obj.EndTime
                , obj.EventObjRect
                , obj.ObjType
                , obj.ObjNum
                        //, obj.Image
                        //, obj.Reserved
                );
            MyLog4Net.Container.Instance.Log.Debug(msg);

            BehaviorInfo info = new BehaviorInfo()
            {
                CameraID = obj.CameraCode,
                EventObjRect = obj.EventObjRect,
                EventType = (BehaviorType)obj.EventType,
                Image = obj.Image,
                ObjectId = obj.ObjectId,
                ObjNum = obj.ObjNum,
                ObjType = (E_SEARCH_RESULT_OBJECT_TYPE)obj.ObjType,
                 EndTime = obj.EndTime,
                  StartTime = obj.StartTime,
                   EventVideoUrl = obj.EventVideoUrl,
            };
            if (OnBehaviorReceived != null)
                OnBehaviorReceived(info);
        }
        void realtimereceive_OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA(Interop.Protocol tcp, Interop.NOTE_TRAFFIC_FEATURE_PARAM_DATA obj)
        {
            string msg = string.Format("MoveObjId:{1}," + Environment.NewLine
                + "ObjectType:{2}," + Environment.NewLine
                + "TimeStamp:{3}," + Environment.NewLine
                , obj.CameraCode
                , obj.MoveObjId
                , obj.ObjectType
                , obj.TimeStamp
                );
            MyLog4Net.Container.Instance.Log.Debug(msg);
            //if (OnTrafficFeatureParamReceived != null)
            //    OnTrafficFeatureParamReceived(obj);
        }
        #endregion

        #region Public helper functions

        public void Clearup()
        {
            realtimereceive.OnReceiveNOTE_UPLOAD_CROWD_DATA -= realtimereceive_OnReceiveNOTE_UPLOAD_CROWD_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT -= realtimereceive_OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA -= realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA -= realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_PLATE_DATA -= realtimereceive_OnReceiveNOTE_UPLOAD_PLATE_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT -= realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM -= realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM;
            realtimereceive.OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT -= realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT;
            realtimereceive.OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA -= realtimereceive_OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA;

            realtimereceive.Close();
        }
        #endregion

        #region Event handlers

        #endregion
    }
}
