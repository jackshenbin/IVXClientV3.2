using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.Live.SearchServices
{
    public enum SDKCallExceptionCode
    {
        EndpointNotFound = 1,
        NetDispatcherFault = 2,
		NoSuchResult = 29,
        UserNotLogin = 65592,
        Other = 0xff,
    }
    public enum MessageCmd
    {
        SMS_MSG_ADD_TASK_REQ = 0x0A800000,	//增加检索比对任务请求
        SMS_MSG_ADD_TASK_RSP = 0x0B800000,	//增加检索比对任务回复
        SMS_MSG_DEL_TASK_REQ = 0x0A800010,	//删除检索比对任务请求
        SMS_MSG_DEL_TASK_RSP = 0x0B800010,	//删除检索比对任务回复
        SMS_MSG_GET_TASK_STATE_REQ = 0x0A800020,	//查询检索任务状态请求
        SMS_MSG_GET_TASK_STATE_RSP = 0x0B800020,	//查询检索任务状态回复
        SMS_MSG_GET_OBJ_DETAIL_INFO_REQ = 0x0A800030,	//查询目标详细信息请求
        SMS_MSG_GET_OBJ_DETAIL_INFO_RSP = 0x0B800030,	//查询目标详细信息回复

        SMS_MSG_DEL_STORE_DATA_REQ = 0x0A800040,	//删除存储数据请求
        SMS_MSG_DEL_STORE_DATA_RSP = 0x0B800040,	//删除存储数据回复    

        SMS_MSG_GET_HOTIMAGE_REAL_DATA_REQ = 0x0A800050,	//获取热力图实时数据请求
        SMS_MSG_GET_HOTIMAGE_REAL_DATA_RSP = 0x0B800050,	//获取热力图实时数据回复

        SMS_MSG_GET_HOTIMAGE_HISTORY_DATA_REQ = 0x0A800060,	//获取热力图历史数据请求
        SMS_MSG_GET_HOTIMAGE_HISTORY_DATA_RSP = 0x0B800060,	//获取热力图历史数据回复

        SMS_MSG_GET_HOTIMAGE_STATISTIC_DATA_REQ = 0x0A800070,	//获取热力图统计数据请求
        SMS_MSG_GET_HOTIMAGE_STATISTIC_DATA_RSP = 0x0B800070,	//获取热力图统计数据回复

        SMS_MSG_GET_EVENT_HISTORY_DATA_REQ = 0x0A800080,	//获取交通事件历史数据请求
        SMS_MSG_GET_EVENT_HISTORY_DATA_RSP = 0x0B800080,	//获取交通事件历史数据回复

        SMS_MSG_GET_TRAFFIC_HISTORY_DATA_REQ = 0x0A800090,	//获取交通流量历史数据请求
        SMS_MSG_GET_TRAFFIC_HISTORY_DATA_RSP = 0x0B800090,	//获取交通流量历史数据回复

        SMS_MSG_GET_TRAFFIC_STATISTIC_DATA_REQ = 0x0A8000A0,	//获取交通流量统计数据请求
        SMS_MSG_GET_TRAFFIC_STATISTIC_DATA_RSP = 0x0B8000A0,	//获取交通流量统计数据回复

        SMS_MSG_GET_BEHAVIOUR_HISTORY_DATA_REQ = 0x0A8000B0,	//获取行为事件历史数据请求
        SMS_MSG_GET_PLATE_DYNAMIC_VEHICLE_DATA_REQ = 0x0A8000C0,	//获取动态背景车牌数据请求
        SMS_MSG_GET_PLATE_DYNAMIC_VEHICLE_DATA_RSP = 0x0B8000C0,	//获取动态背景车牌数据回复


        SMS_MSG_ADD_FACE_CONTORL_DATA_REQ = 0x0A8000D0,	//添加人脸布控请求
        SMS_MSG_ADD_FACE_CONTORL_DATA_RSP = 0x0B8000D0,	//添加人脸布控回复
        SMS_MSG_DEL_FACE_CONTORL_DATA_REQ = 0x0A8000E0,	//删除人脸布控请求
        SMS_MSG_DEL_FACE_CONTORL_DATA_RSP = 0x0B8000E0,	//删除人脸布控回复
        SMS_MSG_MDF_FACE_CONTORL_DATA_REQ = 0x0A800100,	//修改人脸布控请求
        SMS_MSG_MDF_FACE_CONTORL_DATA_RSP = 0x0B800100,	//修改人脸布控回复
        SMS_MSG_GET_FACE_CONTORL_DATA_REQ = 0x0A800110,	//查询人脸布控请求
        SMS_MSG_GET_FACE_CONTORL_DATA_RSP = 0x0B800110,	//查询人脸布控回复

        SMS_MSG_ADD_FACE_TASK_REQ = 0x0A800120,	//增加人脸检索比对请求
        SMS_MSG_ADD_FACE_TASK_RSP = 0x0B800120,	//增加人脸检索比对回复
        SMS_MSG_DEL_FACE_TASK_REQ = 0x0A800130,	//删除人脸检索比对请求
        SMS_MSG_DEL_FACE_TASK_RSP = 0x0B800130,	//删除人脸检索比对回复
        SMS_MSG_GET_FACE_TASK_STATE_REQ = 0x0A800140,//查询人脸检索比对状态请求
        SMS_MSG_GET_FACE_TASK_STATE_RSP = 0x0B800140,	//查询人脸检索比对状态回复
        SMS_MSG_GET_FACE_OBJ_DETALL_REQ = 0x0A800150,//获取人脸检索比对详细信息请求
        SMS_MSG_GET_FACE_OBJ_DETALL_RSP = 0x0B800150,	//获取人脸检索比对详细信息回复

        SMS_MSG_ADD_SUBSCRIBE_DATA_REQ = 0x0A800160,	//添加订阅信息请求
        SMS_MSG_ADD_SUBSCRIBE_DATA_RSP = 0x0B800160,	//添加订阅信息回复
        SMS_MSG_DEL_SUBSCRIBE_DATA_REQ = 0x0A800170,	//删除订阅信息请求
        SMS_MSG_DEL_SUBSCRIBE_DATA_RSP = 0x0B800170,	//删除订阅信息回复
        SMS_MSG_MDF_SUBSCRIBE_DATA_REQ = 0x0A800180,	//修改订阅信息接收地址请求
        SMS_MSG_MDF_SUBSCRIBE_DATA_RSP = 0x0B800180,	//修改订阅信息接收地址回复
        SMS_MSG_GET_SUBSCRIBE_DATA_REQ = 0x0A800190,	//查询订阅信息列表请求
        SMS_MSG_GET_SUBSCRIBE_DATA_RSP = 0x0B800190,	//查询订阅信息列表回复

        SMS_MSG_GET_FACE_ALARM_HISTORY_DATA_REQ = 0x0A8001A0,	//历史人脸报警数据查询请求
        SMS_MSG_GET_FACE_ALARM_HISTORY_DATA_RSP = 0x0B8001A0,	//历史人脸报警数据查询回复   
    }

    public class Head
    {
        public string Version { get; set; }
        public string Context { get; set; }
        public ulong Sequence { get; set; }
        public ulong MsgCmd { get; set; }

    }

    public class ErrorMsg
    {
        public uint Result { get; set; }
        public string ResultDescription { get; set; }
    }

    public class PassLineSet
    {
        public UInt32 PassLineType { get; set; }
        public string PassLineBeginPoint { get; set; }
        public string PassLineEndPoint { get; set; }
        public string DirectLineBeginPoint { get; set; }
        public string DirectLineEndPoint { get; set; }
    }
    public class RegionSet
    {
        public UInt32 RegionType { get; set; }
        public List<string> RegionPointSet { get; set; }
    }
    public class StructFeatureSet
    {
        public UInt32 UpBodyColor { get; set; }
        public UInt32 DownBodyColor { get; set; }
        public UInt32 BagType { get; set; }
        public string PlateNo { get; set; }
        public UInt32 PlateColor { get; set; }
        public UInt32 PlateNumRow { get; set; }
        public UInt32 VehicleLabel { get; set; }
        public UInt32 VehicleLabelDetail { get; set; }
        public UInt32 VehicleType { get; set; }
        public UInt32 VehicleTypeDetail { get; set; }
        public UInt32 VehicleColor { get; set; }
        public UInt32 DriverIsPhoneing { get; set; }
        public UInt32 DriverIsSafebelt { get; set; }
        public UInt32 PassengerIsSafebelt { get; set; }
        public UInt32 DriverIsSunVisor { get; set; }
        public UInt32 PassengerIsSunVisor { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<StructFeatureSet>");
            sb.AppendLine("<UpBodyColor>" + UpBodyColor + "</UpBodyColor>");
            sb.AppendLine("<DownBodyColor>" + DownBodyColor + "</DownBodyColor>");
            sb.AppendLine("<BagType>" + BagType + "</BagType>");
            sb.AppendLine("<PlateNo>" + PlateNo + "</PlateNo>");
            sb.AppendLine("<PlateColor>" + PlateColor + "</PlateColor>");
            sb.AppendLine("<PlateNumRow>" + PlateNumRow + "</PlateNumRow>");
            sb.AppendLine("<VehicleLabel>" + VehicleLabel + "</VehicleLabel>");
            sb.AppendLine("<VehicleLabelDetail>" + VehicleLabelDetail + "</VehicleLabelDetail>");
            sb.AppendLine("<VehicleType>" + VehicleType + "</VehicleType>");
            sb.AppendLine("<VehicleTypeDetail>" + VehicleTypeDetail + "</VehicleTypeDetail>");
            sb.AppendLine("<VehicleColor>" + VehicleColor + "</VehicleColor>");
            sb.AppendLine("<DriverIsPhoneing>" + DriverIsPhoneing + "</DriverIsPhoneing>");
            sb.AppendLine("<DriverIsSafebelt>" + DriverIsSafebelt + "</DriverIsSafebelt>");
            sb.AppendLine("<PassengerIsSafebelt>" + PassengerIsSafebelt + "</PassengerIsSafebelt>");
            sb.AppendLine("<DriverIsSunVisor>" + DriverIsSunVisor + "</DriverIsSunVisor>");
            sb.AppendLine("<PassengerIsSunVisor>" + PassengerIsSunVisor + "</PassengerIsSunVisor>");
            sb.AppendLine("</StructFeatureSet>");

            return sb.ToString();
        }
    }

    public class SMS_MSG_ADD_TASK_REQ
    {
        public string CameraID { get; set; }
        public UInt64 BeginTimeMilliSec { get; set; }
        public UInt64 EndTimeMilliSec { get; set; }
        public UInt32 ResultNumRange { get; set; }
        public UInt32 ObjFilterType { get; set; }
        public UInt32 FeatureType { get; set; }
        public UInt32 Similar { get; set; }
        public UInt32 SortType { get; set; }
        public List<PassLineSet> PassLineSet { get; set; }

        public List<RegionSet> RegionSet { get; set; }
        public StructFeatureSet StructFeatureSet { get; set; }

        public string PictureData { get; set; }
        public string ObjRect { get; set; }
        public string ObjDetailRect { get; set; }

        public override string ToString()
        {
            StringBuilder sbline = new StringBuilder();
            foreach (PassLineSet item in PassLineSet)
            {
                sbline.AppendLine("<PassLineSet>");
                sbline.AppendLine("<PassLineType>" + item.PassLineType + "</PassLineType>");
                sbline.AppendLine("<PassLineBeginPoint>" + item.PassLineBeginPoint + "</PassLineBeginPoint>");
                sbline.AppendLine("<PassLineEndPoint>" + item.PassLineEndPoint + "</PassLineEndPoint>");
                sbline.AppendLine("<DirectLineBeginPoint>" + item.DirectLineBeginPoint + "</DirectLineBeginPoint>");
                sbline.AppendLine("<DirectLineEndPoint>" + item.DirectLineEndPoint + "</DirectLineEndPoint>");
                sbline.AppendLine("</PassLineSet>");
            }

            StringBuilder sbregion = new StringBuilder();
            foreach (RegionSet item in RegionSet)
            {

                sbregion.AppendLine("<RegionSet>");
                sbregion.AppendLine("<RegionType>" + item.RegionType + "</RegionType>");
                sbregion.AppendLine("<RegionPointSet>");
                foreach (string itempoint in item.RegionPointSet)
                {
                    sbregion.AppendLine("<RegionPoint>" + itempoint + "</RegionPoint>");

                }
                sbregion.AppendLine("</RegionPointSet>");
                sbregion.AppendLine("</RegionSet>");

            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<StartTime>" + BeginTimeMilliSec + "</StartTime>");//<!—检索开始时间->
            sb.AppendLine("<EndTime>" + EndTimeMilliSec + "</EndTime>");//<!—检索结束时间->
            sb.AppendLine("<ResultNumRange>" + ResultNumRange + "</ResultNumRange>");
            sb.AppendLine("<ObjFilterType>" + ObjFilterType + "</ObjFilterType>");
            sb.AppendLine("<FeatureType>" + FeatureType + "</FeatureType>");
            sb.AppendLine("<Similar>" + Similar + "</Similar>");
            sb.AppendLine("<SortType>" + SortType + "</SortType>");
            sb.AppendLine(sbline.ToString());
            sb.AppendLine(sbregion.ToString());
            sb.AppendLine(StructFeatureSet.ToString());
            sb.AppendLine("<PictureData>" + PictureData + "</PictureData>");
            sb.AppendLine("<ObjRect>" + ObjRect + "</ObjRect>");
            sb.AppendLine("<ObjDetailRect>" + ObjDetailRect + "</ObjDetailRect>");
            sb.AppendLine("</Request>");

            return sb.ToString();
        }
    }

#region FACE_REQ
	public class SMS_MSG_ADD_FACE_TASK_REQ {
		public string CameraID { get; set; }
		public UInt32 startTime{ get; set; }
		public UInt32 endTime{ get; set; }
		public int ResultNumRange{ get; set; }
		public int Similar{ get; set; }
		public UInt32 SortType { get; set; }
		public string picData { get; set; }
		public string ObjRect { get; set; }
		public uint PeopleNation { get; set; }
		public uint PeopleSex { get; set; }
		public uint BeginAge { get; set; }
		public uint EndAge { get; set; }

		public override string ToString() {
		StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTime>" + startTime + "</BeginTime>");//<!—检索开始时间->
            sb.AppendLine("<EndTime>" + endTime + "</EndTime>");//<!—检索结束时间->
            sb.AppendLine("<ResultNumRange>" + ResultNumRange + "</ResultNumRange>");
			sb.AppendLine("<Similar>" + Similar + "</Similar>");
            sb.AppendLine("<SortType>" + SortType + "</SortType>");

			sb.AppendLine("<PictureData>" + picData + "</PictureData>");
			sb.AppendLine("<ObjRect>" + ObjRect + "</ObjRect>");
			sb.Append("<StructFeatureSet>");
			sb.AppendLine("<PeopleNation>" + PeopleNation+ "</PeopleNation>");
			sb.AppendLine("<PeopleSex>" + PeopleSex + "</PeopleSex>");
			sb.AppendLine("<BeginAge>" + BeginAge + "</BeginAge>");
			sb.AppendLine("<EndAge>" + EndAge + "</EndAge>");
			sb.Append("</StructFeatureSet>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
	}
#endregion 

#region HotImage_REQ
    public class SMS_MSG_GET_HOTIMAGE_REAL_DATA_REQ
    {
        public string CameraID { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }

    public class SMS_MSG_GET_HOTIMAGE_HISTORY_DATA_REQ
    {
        public string CameraID { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
            sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }

    public class SMS_MSG_GET_HOTIMAGE_STATISTIC_DATA_REQ
    {
        public string CameraID { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec { get; set; }
        public UInt32 TimeInterval { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
            sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
            sb.AppendLine("<TimeInterval>" + TimeInterval + "</TimeInterval>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }
#endregion 

	#region BehaviorEvent_REQ
	public class SMS_MSG_GET_BEHAVIOUR_HISTORY_DATA_REQ 
	{
		public string CameraID { get; set; }
		public UInt32 BeginTimeSec { get; set; }
		public UInt32 EndTimeSec { get; set; }
		public string EventType { get; set; }
		public override string ToString() 
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<Request>");
			sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
			sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
			sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
			sb.AppendLine("<EventType>" + EventType + "</EventType >");
			sb.AppendLine("</Request>");
			return sb.ToString();
		}
	}
	#endregion

	#region TrafficEvent_REQ
	public class SMS_MSG_GET_EVENT_HISTORY_DATA_REQ
    {
        public string CameraID     { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec  { get; set; }
        public string EventType  { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
            sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
            sb.AppendLine("<EventType>" + EventType + "</EventType >");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }

    public class SMS_MSG_GET_TRAFFIC_HISTORY_DATA_REQ
    {
        public string CameraID { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
            sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }

    public class SMS_MSG_GET_TRAFFIC_STATISTIC_DATA_REQ
    {
        public string CameraID { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec { get; set; }
        public UInt32 TimeInterval { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
            sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
            sb.AppendLine("<TimeInterval>" + TimeInterval + "</TimeInterval>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }
#endregion

    public class SMS_MSG_GET_SUBSCRIBE_DATA_REQ
    {
        public string UserName { get; set; }
    }
    public class SMS_MSG_DEL_SUBSCRIBE_DATA_REQ
    {
        public uint SubscribeHandle { get; set; }
    }
    public class SMS_MSG_ADD_SUBSCRIBE_DATA_REQ
    {
        public string UserName { get; set; }
        public string ClientIP { get; set; }
        public uint ClientPort { get; set; }
        public string CameraID { get; set; }
        public uint DataType { get; set; }
        public uint BlackListHandle { get; set; }
    }
    public class SMS_MSG_ADD_FACE_CONTORL_DATA_REQ
    {
        public string CameraID { get; set; }
        public uint ControlThreshold { get; set; }
        public string BlackListHandle { get; set; }
        public string ControlNation { get; set; }
        public uint ControlSex { get; set; }
        public uint BeginAge { get; set; }
        public uint EndAge { get; set; }
    }
    public class SMS_MSG_DEL_FACE_CONTORL_DATA_REQ
    {
        public uint FaceControlHandle { get; set; }
    }
    public class SMS_MSG_MDF_FACE_CONTORL_DATA_REQ
    {
        public uint FaceControlHandle { get; set; }
        public string CameraID { get; set; }
        public uint ControlThreshold { get; set; }
        public string BlackListHandle { get; set; }
        public string ControlNation { get; set; }
        public uint ControlSex { get; set; }
        public uint BeginAge { get; set; }
        public uint EndAge { get; set; }
    }
    public class SMS_MSG_GET_PLATE_DYNAMIC_VEHICLE_DATA_REQ
    {
        public string CameraID { get; set; }
        public UInt32 BeginTimeSec { get; set; }
        public UInt32 EndTimeSec { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Request>");
            sb.AppendLine("<CameraID>" + CameraID + "</CameraID>");
            sb.AppendLine("<BeginTimeSec>" + BeginTimeSec + "</BeginTimeSec>");
            sb.AppendLine("<EndTimeSec>" + EndTimeSec + "</EndTimeSec>");
            sb.AppendLine("</Request>");
            return sb.ToString();
        }
    }
    public class SMS_MSG_DEL_TASK_REQ
    {
        public UInt32 MatchTaskId { get; set; }

    }
    public class SMS_MSG_GET_TASK_STATE_REQ
    {
        public UInt32 MatchTaskId { get; set; }


    }

    public class ObjInfoSet
    {
        public UInt64 ObjKey { get; set; }
        public UInt64 BeginTimeMilliSec { get; set; }
        public UInt64 EndTimeMilliSec { get; set; }
        public UInt32 ObjType { get; set; }
        public string ObjDetailRect { get; set; }
        public UInt32 Similar { get; set; }
    }

    public class ObjKeySet
    {
        public UInt64 ObjKey { get; set; }
        public UInt32 ObjType { get; set; }
    }

    public class SMS_MSG_GET_OBJ_DETAIL_INFO_REQ
    {
        public UInt32 MatchTaskId { get; set; }
        public List<ObjKeySet> ObjKeySet { get; set; }

    }


	public class ObjDetailInfoSet {
		public UInt64 ObjKey { get; set; }
		public UInt32 ObjType { get; set; }
		public UInt64 BeginTimeMilliSec { get; set; }
		public UInt64 EndTimeMilliSec { get; set; }
		public UInt32 Similar { get; set; }
		public UInt32 UpBodyColor { get; set; }
		public UInt32 DownBodyColor { get; set; }
		public UInt32 BagType { get; set; }
		public string PlateNo { get; set; }
		public UInt32 PlateColor { get; set; }
		public UInt32 PlateNumRow { get; set; }
		public UInt32 VehicleLabel { get; set; }
		public UInt32 VehicleLabelDetail { get; set; }
		public UInt32 VehicleType { get; set; }
		public UInt32 VehicleTypeDetail { get; set; }
		public UInt32 VehicleColor { get; set; }
		public UInt32 DriverIsPhoneing { get; set; }
		public UInt32 DriverIsPhoneingConf { get; set; }
		public UInt32 DriverIsSafebelt { get; set; }
		public UInt32 DriverIsSafebeltConf { get; set; }
		public UInt32 PassengerIsSafebelt { get; set; }
		public UInt32 PassengerIsSafebeltConf { get; set; }
		public UInt32 DriverIsSunVisor { get; set; }
		public UInt32 DriverIsSunVisorConf { get; set; }
		public UInt32 PassengerIsSunVisor { get; set; }
		public UInt32 PassengerIsSunVisorConf { get; set; }
		public string OriginalPicURL { get; set; }
		public string ThumbPicURL { get; set; }
		public string PlatePicURL { get; set; }
		public string ObjRect { get; set; }
		public string ObjDetailRect { get; set; }
		public string PlateRect { get; set; }

	}
    }

