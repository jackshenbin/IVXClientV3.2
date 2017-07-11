using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.Live.CommServices {
	public enum SDKCallExceptionCode {
		EndpointNotFound = 1,
		NetDispatcherFault = 2,
        NoSuchResult=29,
		UserNotLogin = 65592,
		Other = 0xff,
	}
    public enum MessageCmd
    {
        //1.4.1 登录相关
        VDM_MSG_LOGIN_REQ = 0x0A000000,	//登录VDM请求
        VDM_MSG_LOGIN_RSP = 0x0B000000,	//登录VDM回复
        VDM_MSG_LOGOUT_REQ = 0x0A000001,	//登出VDM请求
        VDM_MSG_LOGOUT_RSP = 0x0B000001,	//登出VDM回复
        VDM_MSG_GET_VERSION_REQ = 0x0A000002,//获取服务器版本信息请求
        VDM_MSG_GET_VERSION_RSP = 0x0B000002,//获取服务器版本信息回复
        VDM_MSG_ADD_USER_REQ = 0x0A000003,	//添加用户信息请求
        VDM_MSG_ADD_USER_RSP = 0x0B000003,	//添加用户信息回复
        VDM_MSG_DEL_USER_REQ = 0x0A000004,	//删除用户信息请求
        VDM_MSG_DEL_USER_RSP = 0x0B000004,	//删除用户信息回复
        VDM_MSG_MDF_USER_REQ = 0x0A000005,	//修改用户信息请求
        VDM_MSG_MDF_USER_RSP = 0x0B000005,	//修改用户信息回复
        VDM_MSG_GET_USER_LIST_REQ = 0x0A000006, 	//获取用户信息列表请求
        VDM_MSG_GET_USER_LIST_RSP = 0x0B000006,	//获取用户信息列表回复
        //1.4.2 服务器相关
        VDM_MSG_ADD_SVERVER_REQ = 0x0A100000,   	//添加服务器请求
        VDM_MSG_ADD_SVERVER_RSP = 0x0B100000,   	//添加服务器回复
        VDM_MSG_DEL_SVERVER_REQ = 0x0A100010,  		//删除服务器请求
        VDM_MSG_DEL_SVERVER_RSP = 0x0B100010,   	//删除服务器回复
        VDM_MSG_MDF_SVERVER_REQ = 0x0A100020,  		//修改服务器请求
        VDM_MSG_MDF_SVERVER_RSP = 0x0B100020,   	//修改服务器回复
        VDM_MSG_GET_SVERVER_REQ = 0x0A100030,  		//获取服务器请求
        VDM_MSG_GET_SVERVER_RSP = 0x0B100030,   	//获取服务器回复
        VDM_MSG_GET_SVERVER_LIST_REQ = 0x0A100040,  //获取服务器列表请求
        VDM_MSG_GET_SVERVER_LIST_RSP = 0x0B100040,  //获取服务器列表回复

        VDM_MSG_ADD_NET_STORE_REQ = 0x0A100050,  //添加平台设备请求
        VDM_MSG_ADD_NET_STORE_RSP = 0x0B100050,  //添加平台设备回复
        VDM_MSG_DEL_NET_STORE_REQ = 0x0A100060,	//删除平台设备请求
        VDM_MSG_DEL_NET_STORE_RSP = 0x0B100060,  //删除平台设备回复
        VDM_MSG_GET_NET_STORE_LIST_REQ = 0x0A100070,//获取列表请求
        VDM_MSG_GET_NET_STORE_LIST_RSP = 0x0B100070, //获取列表回复
        VDM_MSG_GET_CAMERA_LIST_REQ = 0x0A100080,  //获取相机列表请求
        VDM_MSG_GET_CAMERA_LIST_RSP = 0x0B100080,    //获取相机列表回复
        VDM_MSG_ADD_CAMERA_REQ = 0x0A100090, 		 //添加相机列表请求
        VDM_MSG_ADD_CAMERA_RSP = 0x0B100090, 		 //添加相机列表回复
        VDM_MSG_DEL_CAMERA_REQ = 0x0A1000A0, 		 //删除相机列表请求
        VDM_MSG_DEL_CAMERA_RSP = 0x0B1000A0,  	 //删除相机列表回复
        VDM_MSG_GET_LOG_LIST_REQ = 0x0A1000B0,  	 //检索日志列表请求
        VDM_MSG_GET_LOG_LIST_RSP = 0x0B1000B0,   	 //检索日志列表回复
        VDM_MSG_GET_VEHICLE_BRAND_LIST_REQ = 0x0A1000C0, //获取车标列表请求
        VDM_MSG_GET_VEHICLE_BRAND_LIST_RSP = 0x0B1000C0, //获取车标列表回复
        VDM_MSG_GET_STORE_SERVER_LIST_REQ = 0x0A1000D0,//获取存储服务器列表请求
        VDM_MSG_GET_STORE_SERVER_LIST_RSP = 0x0B1000D0,//获取存储服务器列表回复
        VDM_MSG_EXTRACT_BLACK_FACE_FEATURE_REQ = 0x0A1000E0,		//提取黑名单人脸图片特征信息请求
        VDM_MSG_EXTRACT_BLACK_FACE_FEATURE_RSP = 0x0B1000E0,   	//提取黑名单人脸图片特征信息回复
        VDM_MSG_BACK_BLACK_FACE_FEATURE_REQ = 0x0A100100,  	//返回黑名单人脸图片特征信息请求
        VDM_MSG_BACK_BLACK_FACE_FEATURE_RSP = 0x0B100100,   	//返回黑名单人脸图片特征信息回复
        VDM_MSG_UPDATE_BLACK_FACE_FEATURE_REQ = 0x0A100110,		//更新黑名单人脸图片特征信息请求
        VDM_MSG_UPDATE_BLACK_FACE_FEATURE_RSP = 0x0B100110,   	//更新黑名单人脸图片特征信息回复
        VDM_MSG_GET_BLACK_FACE_FEATURE_REQ = 0x0A100120,   	//获取黑名单人脸图片特征信息请求
        VDM_MSG_GET_BLACK_FACE_FEATURE_RSP = 0x0B100120,     //获取黑名单人脸图片特征信息回复
        VDM_MSG_ADD_BLACK_FACE_FEATURE_REQ = 0x0A100130, 		//添加黑名单人脸图片特征信息请求
        VDM_MSG_ADD_BLACK_FACE_FEATURE_RSP = 0x0B100130,    	//添加黑名单人脸图片特征信息回复

        //1.4.3 任务相关
        VDM_MSG_ADD_TASK_REQ = 0x0A200000,  		//添加任务请求
        VDM_MSG_ADD_TASK_RSP = 0x0B200000,  		//添加任务请求
        VDM_MSG_DEL_TASK_REQ = 0x0A200010, 		//删除任务请求
        VDM_MSG_DEL_TASK_RSP = 0x0B200010,  		//删除任务回复
        VDM_MSG_MDF_TASK_REQ = 0x0A200020, 		//修改任务请求
        VDM_MSG_MDF_TASK_RSP = 0x0B200020, 		//修改任务回复
        VDM_MSG_GET_TASK_REQ = 0x0A200030, 		//获取任务信息请求
        VDM_MSG_GET_TASK_RSP = 0x0B200030,  		//获取任务信息回复
        VDM_MSG_GET_TASK_LIST_REQ = 0x0A200040,   	//获取任务信息列表请求
        VDM_MSG_GET_TASK_LIST_RSP = 0x0B200040,   	//获取任务信息列表回复
        VDM_MSG_GET_TASK_PROGRESS_REQ = 0x0A200050, //获取任务进度请求
        VDM_MSG_GET_TASK_PROGRESS_RSP = 0x0B200050, //获取任务进度回复
        VDM_MSG_GET_DOWN_LOAD_LIST_REQ = 0x0A200060, //获取下载任务列表请求
        VDM_MSG_GET_DOWN_LOAD_LIST_RSP = 0x0B200060, //获取下载任务列表回复
        VDM_MSG_TASK_ANALYSE_RESULT_REQ = 0x0A200070, //任务分析结果请求
        VDM_MSG_TASK_ANALYSE_RESULT_RSP = 0x0B200070, //任务分析结果回复
        VDM_MSG_TASK_PAGING_REQ = 0x0A200080, //任务分页结果
        VDM_MSG_TASK_PAGING_RSP = 0x0B200080, //任务分页结果
        VDM_MSG_TASK_REANALYSE_REQ = 0x0A200090, //任务重新分析请求
        VDM_MSG_TASK_REANALYSE_RSP = 0x0B200090, //任务重新分析回复
        VDM_MSG_GET_RESULT_STORE_LIST_REQ = 0x0A2000A0, //获取结果存储列表请求
        VDM_MSG_GET_RESULT_STORE_LIST_RSP = 0x0B2000A0, //获取结果存储列表回复
        VDM_MSG_ADD_TASK_ANALYSETYPE_REQ = 0x0A2000B0,//添加任务分析算法请求
        VDM_MSG_ADD_TASK_ANALYSETYPE_RSP = 0x0B2000B0,//添加任务分析算法回复
        VDM_MSG_DEL_TASK_ANALYSETYPE_REQ = 0x0A2000C0,//删除任务分析算法请求
        VDM_MSG_DEL_TASK_ANALYSETYPE_RSP = 0x0B2000C0,//删除任务分析算法回复
        //1.4.4 模板相关
        VDM_MSG_ADD_TEMPLATE_REQ = 0x0A300000,   	//添加模板请求
        VDM_MSG_ADD_TEMPLATE_RSP = 0x0B300000,    	//添加模板回复
        VDM_MSG_DEL_TEMPLATE_REQ = 0x0A300010,   	//删除模板请求
        VDM_MSG_DEL_TEMPLATE_RSP = 0x0B300010,    	//删除模板回复
        VDM_MSG_MDF_TEMPLATE_REQ = 0x0A300020,   	//修改模板请求
        VDM_MSG_MDF_TEMPLATE_RSP = 0x0B300020,    	//修改模板回复
        VDM_MSG_GET_TEMPLATE_REQ = 0x0A300030,   	//查询模板请求
        VDM_MSG_GET_TEMPLATE_RSP = 0x0B300030,    	//查询模板回复
        VDM_MSG_GET_TEMPLATE_LIST_REQ = 0x0A300040,  //查询模板列表请求
        VDM_MSG_GET_TEMPLATE_LIST_RSP = 0x0B300040,  //查询模板列表回复
        //1.4.5 转发事件相关
        VDM_MSG_ADD_TRANS_EVENT_REQ = 0x0A400000,    //添加转发事件请求
        VDM_MSG_ADD_TRANS_EVENT_RSP = 0x0B400000,    //添加转发事件回复
        VDM_MSG_DEL_TRANS_EVENT_REQ = 0x0A400010,   	//删除转发事件请求
        VDM_MSG_DEL_TRANS_EVENT_RSP = 0x0B400010,    //删除转发事件回复
        VDM_MSG_MDF_TRANS_EVENT_REQ = 0x0A400020,   	//修改转发事件请求
        VDM_MSG_MDF_TRANS_EVENT_RSP = 0x0B400020,    //修改转发事件回复
        VDM_MSG_GET_TRANS_EVENT_REQ = 0x0A400030,   	//获取转发事件请求
        VDM_MSG_GET_TRANS_EVENT_RSP = 0x0B400030,      //获取转发事件回复
        VDM_MSG_GET_TRANS_EVENT_LIST_REQ = 0x0A400040, //获取转发列表请求
        VDM_MSG_GET_TRANS_EVENT_LIST_RSP = 0x0B400040, //获取转发列表回复
        VDM_MSG_GET_TASK_EVENT_LIST_REQ = 0x0A400050, //获取任务转发事件请求
        VDM_MSG_GET_TASK_EVENT_LIST_RSP = 0x0B400050, //获取任务转发事件回复
        VDM_MSG_DEL_TASK_EVENT_LIST_REQ = 0x0A400060,//删除任务转发事件请求
        VDM_MSG_DEL_TASK_EVENT_LIST_RSP = 0x0B400060,//删除任务转发事件回复

        //1.4.6 媒体相关
        VDM_MSG_TASK_PROGRESS_NTF = 0x0A500000, //任务进度通知请求
        VDM_MSG_TASK_PROGRESS_RSP = 0x0B500000, //任务进度通知回复
        VDM_MSG_MSS_REQUEST_TASK_REQ = 0x0A500010, //媒体请求任务请求
        VDM_MSG_MSS_REQUEST_TASK_RSP = 0x0B500010, //媒体请求任务回复
        VDM_MSG_REQUEST_VIDEO_STREAM_REQ = 0x0A500020, //媒体请求码流请求
        VDM_MSG_REQUEST_VIDEO_STREAM_RSP = 0x0B500020, //媒体请求码流回复
        VDM_MSG_SEND_VIDEO_STREAM_REQ = 0x0A500030, //送码流请求
        VDM_MSG_SEND_VIDEO_STREAM_RSP = 0x0B500030, //发送码流回复
        VDM_MSG_ADD_MSS_TASK_REQ = 0x0A500040, //添加媒体任务请求
        VDM_MSG_ADD_MSS_TASK_RSP = 0x0B500040, //添加媒体任务回复
        VDM_MSG_DEL_MSS_TASK_REQ = 0x0A500050, //删除媒体任务请求
        VDM_MSG_DEL_MSS_TASK_RSP = 0x0B500050, //删除媒体任务回复
        VDM_MSG_QUERY_TASK_MSS_REQ = 0x0A500060, //查询任务媒体请求
        VDM_MSG_QUERY_TASK_MSS_RSP = 0x0B500060, //查询任务媒体回复
        VDM_MSG_QUERY_BRIEF_TASK_REQ = 0x0A500070, //查询摘要任务任务请求
        VDM_MSG_QUERY_BRIEF_TASK_RSP = 0x0B500070, //查询摘要任务任务回复
        //1.4.7 黑名单相关
        VDM_MSG_ADD_BLACK_LIST_DATA_REQ = 0x0A900000, 		//添加黑名单列表信息请求
        VDM_MSG_ADD_BLACK_LIST_DATA_RSP = 0x0B900000,    	//添加黑名单列表信息回复
        VDM_MSG_DEL_BLACK_LIST_DATA_REQ = 0x0A900010,   	//删除黑名单列表信息请求
        VDM_MSG_DEL_BLACK_LIST_DATA_RSP = 0x0B900010,    	//删除黑名单列表信息回复
        VDM_MSG_MDF_BLACK_LIST_DATA_REQ = 0x0A900020, 		//修改黑名单列表信息请求
        VDM_MSG_MDF_BLACK_LIST_DATA_RSP = 0x0B900020,    	//修改黑名单列表信息回复
        VDM_MSG_GET_BLACK_LIST_DATA_REQ = 0x0A900030,   	//获取黑名单列表信息请求
        VDM_MSG_GET_BLACK_LIST_DATA_RSP = 0x0B900030,     //获取黑名单列表信息回复
        VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ = 0x0A900040, 		//添加黑名单人脸图片信息请求
        VDM_MSG_ADD_BLACK_FACE_PICTURE_RSP = 0x0B900040,    	//添加黑名单人脸图片信息回复
        VDM_MSG_DEL_BLACK_FACE_PICTURE_REQ = 0x0A900050,   	//删除黑名单人脸图片信息请求
        VDM_MSG_DEL_BLACK_FACE_PICTURE_RSP = 0x0B900050,    	//删除黑名单人脸图片信息回复
        VDM_MSG_MDF_BLACK_FACE_PICTURE_REQ = 0x0A900060, 		//修改黑名单人脸图片信息请求
        VDM_MSG_MDF_BLACK_FACE_PICTURE_RSP = 0x0B900060,    	//修改黑名单人脸图片信息回复
        VDM_MSG_GET_BLACK_FACE_PICTURE_REQ = 0x0A900070,   	//获取黑名单人脸图片信息请求
        VDM_MSG_GET_BLACK_FACE_PICTURE_RSP = 0x0B900070,     //获取黑名单人脸图片信息回复	
    }

	public class Head {
		public string Version { get; set; }
		public string Context { get; set; }
		public ulong Sequence { get; set; }
		public ulong MsgCmd { get; set; }

	}

	public class ErrorMsg {
		public uint Result { get; set; }
		public string ResultDescription { get; set; }
	}

	public class VDM_MSG_LOGIN_REQ {
		public string UserName { get; set; }
		public string PassWord { get; set; }
		public string UserSerIp { get; set; }
		public uint UserSerPort { get; set; }
	}
	public class VDM_MSG_LOGOUT_REQ {
		public uint LoginHandle { get; set; }
	}
	public class VDM_MSG_GET_TASK_LIST_REQ {
	}

	public class VDM_MSG_GET_DOWN_LOAD_LIST_REQ {
	}
	public class VDM_MSG_GET_TASK_PROGRESS_REQ {
		public uint TaskId { get; set; }
	}
	public class TaskInfo {
		public string TaskName { get; set; }
		public uint Priority { get; set; }
		public uint TaskId { get; set; }
		public uint TaskType { get; set; }
		public uint FileType { get; set; }
		public UInt64 FileSize { get; set; }
		public string DeviceName { get; set; }
		public uint DeviceType { get; set; }
		public uint ProtocolType { get; set; }
		public string DeviceIP { get; set; }
		public uint DevicePort { get; set; }
		public string LoginUser { get; set; }
		public string LoginPwd { get; set; }
		public string ChannelID { get; set; }
		public string CameraID { get; set; }
		public string OriFilePath { get; set; }
		public uint StartTime { get; set; }
		public uint EndTime { get; set; }
		public string StoreIP { get; set; }
		public uint StorePort { get; set; }
		public uint UserHandle { get; set; }
		public uint Order { get; set; }
		public List<StatusInfo> StatusList { get; set; }
		public uint AlgthmType { get; set; }
		public string AnalyseParam { get; set; }
	}

	public class StatusInfo {
		public uint AlgthmType { get; set; }
		public uint Status { get; set; }
		public uint Progress { get; set; }
		public string AnalyseParam { get; set; }
		public uint LeftTime { get; set; }

	}

	public class ServerInfo {
		public string ServerIP { get; set; }
		public uint ServerId { get; set; }
		public uint ServerPort { get; set; }
		public uint ServerType { get; set; }
		public uint Status { get; set; }
		public string Description { get; set; }

	}
	public class NetStoreInfo {
		public string NetName { get; set; }
		public uint NetHandle { get; set; }
		public uint ConnectType { get; set; }
		public string NetStoreIP { get; set; }
		public uint NetStorePort { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }
		public string Rest { get; set; }
	}

	public class CameraInfo {
		public uint ID { get; set; }
		public string Name { get; set; }
		public string CameraID { get; set; }
		public uint Coord_X { get; set; }
		public uint Coord_Y { get; set; }
		public uint NetStoreDevId { get; set; }
		public string NetDevChannel { get; set; }
	}
	public class VDM_MSG_ADD_TASK_REQ {
		public List<TaskInfo> TaskList { get; set; }
	}
	public class VDM_MSG_TASK_REANALYSE_REQ {
		public uint TaskId { get; set; }
		public uint AnalyseType { get; set; }
		public string AnalyseParam { get; set; }
		public uint SplitTime { get; set; }
		public string Other { get; set; }
	}
	public class VDM_MSG_ADD_TASK_ANALYSETYPE_REQ {
		public uint TaskId { get; set; }
		public uint AnalyseType { get; set; }
		public string AnalyseParam { get; set; }
		public uint SplitTime { get; set; }
		public string Other { get; set; }
	}
	public class VDM_MSG_DEL_TASK_ANALYSETYPE_REQ {
		public uint TaskId { get; set; }
		public uint AnalyseType { get; set; }
	}
	public class VDM_MSG_ADD_NET_STORE_REQ {
		public List<NetStoreInfo> NetStoreList { get; set; }
	}
	public class VDM_MSG_ADD_CAMERA_REQ {
		public List<CameraInfo> CameraList { get; set; }
	}
	public class VDM_MSG_ADD_SVERVER_REQ {
		public List<ServerInfo> ServerList { get; set; }
	}

	public class VDM_MSG_GET_SVERVER_REQ {
		public uint ServerId { get; set; }
	}
	public class VDM_MSG_DEL_SVERVER_REQ {
		public uint ServerId { get; set; }
	}
	public class VDM_MSG_TASK_PAGING_REQ {
		public uint PagerNum { get; set; }
		public uint EveryPagerCount { get; set; }
		public uint Order { get; set; }
		public List<uint> TaskType { get; set; }
		public List<uint> AnalyseType { get; set; }
		public List<uint> TaskStatus { get; set; }
	}
	public class VDM_MSG_ADD_TRANS_EVENT_REQ {
		public uint TaskId { get; set; }
		public uint TemplateId { get; set; }
		public uint StoreType { get; set; }
		public string StoreServerIP { get; set; }
		public uint StoreServerPort { get; set; }
		public uint TransProtocol { get; set; }
		public uint AnalyseType { get; set; }
	}
	public class TransEvent {
		public uint EventId { get; set; }
		public uint TaskId { get; set; }
		public uint TemplateId { get; set; }
		public uint StoreType { get; set; }
		public string StoreServerIP { get; set; }
		public uint StoreServerPort { get; set; }
		public uint TransProtocol { get; set; }
		public uint AnalyseType { get; set; }
	}


	public class VDM_MSG_GET_LOG_LIST_REQ {
		public UInt32 StartTime { get; set; }
		public UInt32 EndTime { get; set; }
		public UInt32 LogLevel { get; set; }
		public string OptName { get; set; }
		public UInt32 LogType { get; set; }
		public UInt32 SortKind { get; set; }
		public UInt32 StartMum { get; set; }
		public UInt32 LogCount { get; set; }

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<Request>");
			sb.AppendLine("<StartTime>" + StartTime + "</StartTime>");
			sb.AppendLine("<EndTime>" + EndTime + "</EndTime>");
			sb.AppendLine("<LogLevel>" + LogLevel + "</LogLevel>");
			sb.AppendLine("<OptName>" + OptName + "</OptName>");
			sb.AppendLine("<LogType>" + LogType + "</LogType>");
			sb.AppendLine("<SortType>" + SortKind + "</SortType>");
			sb.AppendLine("<StartMum>" + StartMum + "</StartMum>");
			sb.AppendLine("<LogCount>" + LogCount + "</LogCount>");
			sb.AppendLine("</Request>");
			return sb.ToString();
		}
	}

	// 用户信息 ---用于 添加  
	public class VDM_MSG_ADD_USER_INFO_REQ {
		public string UserName;
		public string Password;
		public UInt32 UserRole;
		public UInt32 RightMask;
		public string other;
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<Request>");
			sb.AppendLine("<UserName>" + UserName + "</UserName>");
			sb.AppendLine("<Password>" + Password + "</Password>");
			sb.AppendLine("<UserRole>" + UserRole + "</UserRole>");
			sb.AppendLine("<RightMask>" + RightMask + "</RightMask>");
			sb.AppendLine("<Other>" + other + "</Other>");
			sb.AppendLine("</Request>");
			return sb.ToString();
		}
	}

	// 用户信息 ---用于 修改
	public class VDM_MSG_MOD_USER_INFO_REQ {
		public UInt32 UserHandle;
		public string UserName;
		public string Password;
		public UInt32 UserRole;
		public UInt32 RightMask;
		public string other;
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<Request>");
			sb.AppendLine("<UserHandle>" + UserHandle + "</UserHandle>");
			sb.AppendLine("<UserName>" + UserName + "</UserName>");
			sb.AppendLine("<Password>" + Password + "</Password>");
			sb.AppendLine("<UserRole>" + UserRole + "</UserRole>");
			sb.AppendLine("<RightMask>" + RightMask + "</RightMask>");
			sb.AppendLine("<Other>" + other + "</Other>");
			sb.AppendLine("</Request>");
			return sb.ToString();
		}
	}

	// 黑名单信息 ---用于 添加
	public class VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ {
		public UInt32 LibHandel;
		public UInt32 PicHandel;
		public string picData;
		public string Name;			//	姓名（string）
		public string Id;
		public string PeopleCard;	//身份证号
		public string PeopleNation;	//	民族	（UINT32）
		public UInt32 PeopleAge;	//	年龄
		public UInt32 PeopleSex;	//	性别	性别
		public UInt32 PeopleHeight; //	身高	
		public UInt32 PeopleWeight; //	体重	
		public UInt32 BloodType;	//	血型	
		public string Address;		//	地址	
		public string other;
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<BlackListHandle>" + LibHandel + "</BlackListHandle>");
			sb.AppendLine("<PictureData>" + picData + "</PictureData>");
			sb.AppendLine("<PeopleName>" + Name + "</PeopleName>");
			sb.AppendLine("<PeopleCard>" + PeopleCard + "</PeopleCard>");
			//sb.AppendLine("<PeopleNation>" + PeopleNation + "</PeopleNation>");
			sb.AppendLine("<PeopleNation>" + "汉族" + "</PeopleNation>");
			sb.AppendLine("<PeopleAge >" + PeopleAge + "</PeopleAge>");
			sb.AppendLine("<PeopleSex >" + PeopleSex + "</PeopleSex>");
			sb.AppendLine("<PeopleHeight >" + PeopleHeight + "</PeopleHeight>");
			sb.AppendLine("<PeopleWeight  >" + PeopleWeight + "</PeopleWeight>");
			sb.AppendLine("<BloodType >" + BloodType + "</BloodType>");
			sb.AppendLine("<Address >" + "Address" + "</Address>");
			sb.AppendLine("<Other>" + "other" + "</Other>");
			return sb.ToString();
		}
	}

	// 黑名单信息 ---用于 修改
	public class VDM_MSG_MDF_BLACK_FACE_PICTURE_REQ {

		public UInt32 LibHandel;
		public UInt32 PicHandel;
		public string picData;
		public string Name;			//	姓名（string）
		public string Id;
		public string PeopleCard;	//身份证号
		public string PeopleNation;	//	民族	（UINT32）
		public UInt32 PeopleAge;	//	年龄
		public UInt32 PeopleSex;	//	性别	性别
		public UInt32 PeopleHeight; //	身高	
		public UInt32 PeopleWeight; //	体重	
		public UInt32 BloodType;	//	血型	
		public string Address;		//	地址	
		public string other;

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<PictureHandle>" + PicHandel + "</PictureHandle>");
			sb.AppendLine("<BlackListHandle>" + LibHandel + "</BlackListHandle>");
			sb.AppendLine("<PictureData>" + picData + "</PictureData>");
			sb.AppendLine("<PeopleName>" + Name + "</PeopleName>");
			sb.AppendLine("<PeopleCard>" + PeopleCard + "</PeopleCard>");
			// sb.AppendLine("<PeopleNation>" + PeopleNation + "</PeopleNation>");
			sb.AppendLine("<PeopleNation>" + "汉族" + "</PeopleNation>");
			sb.AppendLine("<PeopleAge >" + PeopleAge + "</PeopleAge>");
			sb.AppendLine("<PeopleSex >" + PeopleSex + "</PeopleSex>");
			sb.AppendLine("<PeopleHeight >" + PeopleHeight + "</PeopleHeight>");
			sb.AppendLine("<PeopleWeight  >" + PeopleWeight + "</PeopleWeight>");
			sb.AppendLine("<BloodType >" + BloodType + "</BloodType>");
			sb.AppendLine("<Address >" + "Address" + "</Address>");
			sb.AppendLine("<Other>" + "other" + "</Other>");
			return sb.ToString();
		}
	}
}
