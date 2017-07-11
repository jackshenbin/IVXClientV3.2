using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace IVX.DataModel {
	public delegate List<VBrandInfo> GetVehicleBrandFunc();

	public class Constant {
		public static GetVehicleBrandFunc getVehicleBrandFunc;
		public static List<VBrandInfo> VBrandList = null;
		public static readonly Size DEFAULTSIZE_THUMBNAIL = new Size(90, 90);
		private static TaskPriorityInfo[] s_TaskPriorityInfos;
		private static TaskStatusInfo[] s_TaskStatusInfos;
		private static TaskFileTypeInfo[] s_TaskFileTypeInfos;
		private static TaskTypeInfo[] s_TaskTypeInfos;
		private static AnalyzeStatusInfo[] s_AnalyzeStatusInfos;
		private static TaskUnitTypeInfo[] s_TaskUnitTypeInfos;
		private static UserRoleTypeInfo[] s_UserRoleTypeInfos;

		private static TaskUnitImportStatusInfo[] s_TaskUnitImportStatusInfos;

		private static LogTypeInfo[] s_LogTypeInfos;

		private static DownloadStatusInfo[] s_DownloadStatusInfos;

		private static LogLevelInfo[] s_LogLevelInfos;

		private static LogDetailTypeInfo[] s_LogDetailTypeInfos;

		private static AccessProtocolTypeInfo[] s_AccessProtocolTypeInfos;

		private static TranceProtocolTypeInfo[] s_TranceProtocolTypeInfos;

		public static readonly string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

		public static readonly string DATETIME_ZERO = "0000-00-00 00:00:00";

		public readonly static uint VOLUMESIZE_K = 1 << 10;
		public readonly static uint VOLUMESIZE_M = 1 << 20;
		public readonly static uint VOLUMESIZE_G = 1 << 30;

		public static readonly Color COLOR_FONT = Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));

		public const string Common_SearchType = "searchType";
		public const string Common_TargetColor = "clrTargetColor";
		public const string Common_ColorSimilarRate = "dColorSimilarRate";
		public const string Common_OBJECT_TYPE = "eObjeType";

		public const string Common_bIsMixSearch = "bIsMixSearch";
		public const string Common_nTimeout = "nTimeout";
		public const string Common_ResourceList = "ResourceList";
		public const string Common_SearchBegin = "SearchBegin";
		public const string Common_SearchEnd = "SearchEnd";

		public const string Crossborder_PTBegin = "ptBegin"; //越界线起点
		public const string Crossborder_ptEnd = "ptEnd";					//越界线终点
		public const string Crossborder_eDirectionType = "eDirectionType";//越界线方向
		public const string Crossborder_ptDirectBegin = "ptDirectBegin";			//越界方向线起点
		public const string Crossborder_ptDirectEnd = "ptDirectEnd";

		public const string Crossframe_pPoint = "pPoint";					//闯入闯出顶点坐标数组
		public const string Crossframe_nPointSize = "nPointSize";					//闯入闯出顶点数量（一般就4个点）
		public const string Crossframe_eDirectionType = "eDirectionType";//闯入闯出方向

		public const string CommonCopare_dSimilarRate = "dSimilarRate";
		public const string CommonCopare_rtMainRectange = "rtMainRectange";	//主框（必须有一个主框）

		public const string CommonCopare_nSubRectangeSize = "nSubRectangeSize";  // 子框数组大小（可以为0，也可为多个）

		public const string CommonCopare_partSubRectange = "partSubRectange";	//子框（可以为0，也可为多个）
		public const string CommonCopare_eMethod = "eMethod";//比对方法
		public const string CommonCopare_nPicWidth = "nPicWidth";			//图像宽
		public const string CommonCopare_nPicHeight = "nPicHeight";			//图像高
		public const string CommonCopare_nPicData = "nPicData";			//图像数据（RGB）
		public const string CommonCopare_nPicDataSize = "nPicDataSize";		//图像数据大小

		public const string Vehicle_nPageNum = "nPageNum";					//页码（从1开始）
		public const string Vehicle_szCardNum = "szCardNum";	//车牌号码("00000000")
		public const string Vehicle_nCarType = "nCarType";					//车辆类型(-1:不限；1:小车；2:中车；3:大车；4:其它车型)
		public const string Vehicle_nCarDetailType = "nCarDetailType";				//车型细分(-1:不限；1:大型货车；2:大型客车；3:中型客车；4:小型客车；5两轮车；6其他)
		public const string Vehicle_nCarLogo = "nCarLogo";					//车标
		public const string Vehicle_nCardStruct = "nCardStruct";				//车牌结构(-1:不限；1:单行；2：双行；3其他)
		public const string Vehicle_clrCarColor = "clrCarColor";			//车身颜色
		public const string Vehicle_clrCardColor = "clrCardColor";			//车牌颜色
		public const string Vehicle_bSortKind = "bSortKind";					//排序类型(0:升序；1:降序)
		public const string Vehicle_szSortName = "szSortName";

		public readonly static VideoSupplierDeviceInfo VIDEOSUPPLIERDEVICEINFO_DUMMY = new VideoSupplierDeviceInfo() {
			DeviceName = "无",
			Id = 0
		};

		public static VehicleTypeInfo[] s_VehicleTypeInfos;

		public static SearchResultObjectTypeInfo[] s_SearchResultObjectTypeInfos;

		public static VehicleDetailTypeInfo[] s_VehicleDetailTypeInfos;

		public static VehiclePlateTypeInfo[] s_VehiclePlateTypeInfos;

		public static TaskPriorityInfo[] TaskPriorityInfos {
			get {
				if (s_TaskPriorityInfos == null) {
					s_TaskPriorityInfos = new TaskPriorityInfo[]
                    {
                        new TaskPriorityInfo(TaskPriority.Highest, "最高"),
                        new TaskPriorityInfo(TaskPriority.High, "高"),
                        new TaskPriorityInfo(TaskPriority.Normal, "标准"),
                        new TaskPriorityInfo(TaskPriority.Low, "低"),
                        new TaskPriorityInfo(TaskPriority.Lowest, "最低")
                    };
				}
				return s_TaskPriorityInfos;
			}
		}

		static AnalyzeStatusInfo[] AnalyzeStatusInfos {
			get {
				if (s_AnalyzeStatusInfos == null) {
					s_AnalyzeStatusInfos = new AnalyzeStatusInfo[]
                    {
                        new AnalyzeStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_NOUSE, ""),
                        new AnalyzeStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_WAIT, "等待"),
                        new AnalyzeStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_EXECUTING, "分析中"),
                        new AnalyzeStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_FINISH, "√"),
                        new AnalyzeStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_FAILED, "失败")
                    };
				}
				return s_AnalyzeStatusInfos;
			}
		}

		public static TaskStatusInfo[] TaskStatusInfos {
			get {
				if (s_TaskStatusInfos == null) {
					s_TaskStatusInfos = new TaskStatusInfo[]
                            {
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE, ""),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_WAITING, "开始处理"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_WAIT, "导入等待"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING, "导入中"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED, "导入失败"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT, "分析等待"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING, "分析中"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH, "分析完成"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED, "分析失败"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND, "分析暂停"),
                                new TaskStatusInfo(E_VDA_TASK_STATUS.E_TASK_STATUS_BEEN_DELETE, "已删除"),
                            };
				}
				return s_TaskStatusInfos;
			}
		}
		public static TaskFileTypeInfo[] TaskFileTypeInfos {
			get {
				if (s_TaskFileTypeInfos == null) {
					s_TaskFileTypeInfos = new TaskFileTypeInfo[]
                            {
                                new TaskFileTypeInfo( TaskFileType.None, "无效"),
                                new TaskFileTypeInfo( TaskFileType.LocalFile, "本地导入"),
                                new TaskFileTypeInfo( TaskFileType.FtpHttpFile, "FTP导入"),
                                new TaskFileTypeInfo( TaskFileType.PlateFile, "平台导入"),
                            };
				}
				return s_TaskFileTypeInfos;
			}
		}

		public static TaskTypeInfo[] TaskTypeInfos {
			get {
				if (s_TaskTypeInfos == null) {
					s_TaskTypeInfos = new TaskTypeInfo[]
                            {
                                new TaskTypeInfo( TaskType.None, "无效"),
                                new TaskTypeInfo( TaskType.History, "离线任务"),
                                new TaskTypeInfo( TaskType.Realtime, "在线任务"),
                                new TaskTypeInfo( TaskType.Project, "计划任务"),
                            };
				}
				return s_TaskTypeInfos;
			}
		}

		public static TaskUnitTypeInfo[] TaskUnitTypeInfos {
			get {
				if (s_TaskUnitTypeInfos == null) {
					s_TaskUnitTypeInfos = new TaskUnitTypeInfo[]
                            {
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_UNKNOW, "未知类型"),
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_CLIENT_VIDEO_FILE, "本地视频"),
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_FILESERVER_VIDEO_FILE, "服务器视频"),
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_NETSTORE_VIDEO_FILE, "存储设备视频"),
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_CLIENT_PIC_PACKAGE, "本地图片"),
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_FILESERVER_PIC_PACKAGE, "服务器图片"),
                                new TaskUnitTypeInfo(E_VDA_TASK_UNIT_TYPE.E_TASKUNIT_TYPE_ANALYSED_VIDEO, "已分析视频"),
                            };
				}
				return s_TaskUnitTypeInfos;
			}
		}

		public static TaskUnitImportStatusInfo[] TaskUnitImportStatusInfos {
			get {
				if (s_TaskUnitImportStatusInfos == null) {
					s_TaskUnitImportStatusInfos = new TaskUnitImportStatusInfo[]
                    {
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_NOUSE,""),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_IMPORT_WAIT,"导入等待"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_IMPORT_READY,"导入准备"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_IMPORT_EXECUTING	,"导入中"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_IMPORT_FINISH		,"导入完成"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_IMPORT_FAILED			,"导入失败"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_PREANALYSE_WAIT			,"预分析等待"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_PREANALYSE_EXECUTING	,"预分析中"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_PREANALYSE_FINISH	,"预分析完成"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_PREANALYSE_FAILED		,"预分析失败"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_WAIT			,"分析等待"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_EXECUTING		,"分析中"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_FINISH		,"分析完成"),
                        new TaskUnitImportStatusInfo(E_VDA_TASK_UNIT_STATUS.E_TASK_UNIT_ANALYSE_FAILED		,"分析失败"),
                    };
				}
				return s_TaskUnitImportStatusInfos;
			}
		}

		public static UserRoleTypeInfo[] UserRoleTypeInfos {
			get {
				if (s_UserRoleTypeInfos == null) {
					s_UserRoleTypeInfos = new UserRoleTypeInfo[]
                            {
                                new UserRoleTypeInfo(E_VDA_USER_ROLE_TYPE.E_ROLE_TYPE_NORMAL, "普通用户"),
                                new UserRoleTypeInfo(E_VDA_USER_ROLE_TYPE.E_ROLE_TYPE_LEADER, "组长"),
                                new UserRoleTypeInfo(E_VDA_USER_ROLE_TYPE.E_ROLE_TYPE_ADMIN, "管理员"),
                                new UserRoleTypeInfo(E_VDA_USER_ROLE_TYPE.E_ROLE_TYPE_SUPPER, "超级管理员"),
                            };
				}
				return s_UserRoleTypeInfos;
			}
		}


		public static LogTypeInfo[] LogTypeInfos {
			get {
				if (s_LogTypeInfos == null) {
					s_LogTypeInfos = new LogTypeInfo[]
                            {
                                new LogTypeInfo(E_VDA_LOG_TYPE.E_LOG_TYPE_NOUSE, "其他"),
                                new LogTypeInfo(E_VDA_LOG_TYPE.E_LOG_TYPE_MANAGER, "管理日志"),
                                new LogTypeInfo(E_VDA_LOG_TYPE.E_LOG_TYPE_OPERATE, "操作日志"),
                                new LogTypeInfo(E_VDA_LOG_TYPE.E_LOG_TYPE_SYSTEM, "系统日志"),
                            };
				}
				return s_LogTypeInfos;
			}
		}

		public static DownloadStatusInfo[] DownloadStatusInfos {
			get {
				if (s_DownloadStatusInfos == null) {
					s_DownloadStatusInfos = new DownloadStatusInfo[]
                            {
                                new DownloadStatusInfo(VideoDownloadStatus.NOUSE, "未知"),
                                new DownloadStatusInfo(VideoDownloadStatus.Trans_Wait, "等待转码"),
                                new DownloadStatusInfo(VideoDownloadStatus.Trans_Normal, "正在转码"),
                                new DownloadStatusInfo(VideoDownloadStatus.Trans_Finish, "完成转码 "),
                                new DownloadStatusInfo(VideoDownloadStatus.Trans_Failed, "转码失败"),
                                new DownloadStatusInfo(VideoDownloadStatus.Download_Wait, "等待导出"),
                                new DownloadStatusInfo(VideoDownloadStatus.Download_Normal, "正在导出"),
                                new DownloadStatusInfo(VideoDownloadStatus.Download_Finish, "完成导出"),
                                new DownloadStatusInfo(VideoDownloadStatus.Download_Failed, "导出失败")
                            };
				}
				return s_DownloadStatusInfos;
			}
		}


		public static LogLevelInfo[] LogLevelInfos {
			get {
				if (s_LogLevelInfos == null) {
					s_LogLevelInfos = new LogLevelInfo[]
                            {
                                new LogLevelInfo(E_VDA_LOG_LEVEL.E_LOG_LEVEL_NOUSE, "其他"),
                                new LogLevelInfo(E_VDA_LOG_LEVEL.E_LOG_LEVEL_COMMON, "普通"),
                                new LogLevelInfo(E_VDA_LOG_LEVEL.E_LOG_LEVEL_WARN, "警告"),
                                new LogLevelInfo(E_VDA_LOG_LEVEL.E_LOG_LEVEL_ERROR, "错误"),
                            };
				}
				return s_LogLevelInfos;
			}
		}

		public static LogDetailTypeInfo[] LogDetailTypeInfos {
			get {
				if (s_LogDetailTypeInfos == null) {
					s_LogDetailTypeInfos = new LogDetailTypeInfo[]
                            {
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_NOUSE, "其他"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_TASK_MANAGE, "任务管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_USER_LOGIN, "用户登录"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_USER_LOGOUT, "用户登出"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_START_SERACH, "开始检索"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_STOP_SERACH, "停止检索"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_START_PLAYBACK, "开始点播"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_CLOSE_PLAYBACK, "关闭点播"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_START_BRIEF_VOD, "开始摘要点播"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_CLOSE_BRIEF_VOD, "关闭摘要点播"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_ENTER_CASE, "进入案件"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_LEAVE_CASE, "离开案件"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_CAMERA_MANAGE, "监控点管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_CAMERA_GROUP_MANAGE, "监控点组管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_CASE_MANAGE, "案件管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_NET_STORE_MANAGE, "网络设备管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_USER_MANAGE, "用户管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_USER_GROUP_MANAGE, "用户组管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_SERVER_MANAGE, "服务器管理"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_TASKUNIT_STATUS, "任务单元状态"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_BRIEF_VOD_STATUS, "摘要点播状态"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_PLAYBACK_STATUS, "视频点播状态"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_IAS_STATUS, "智能检索状态"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_SERVER_STATUS, "服务器状态"),
                                new LogDetailTypeInfo(E_VDA_LOG_DETAIL.E_LOG_DETAIL_EXPORT_STATUS, "导出状态"),                            
                            };
				}
				return s_LogDetailTypeInfos;
			}
		}

		public static AccessProtocolTypeInfo[] AccessProtocolTypeInfos {
			get {
				if (s_AccessProtocolTypeInfos == null) {
					s_AccessProtocolTypeInfos = new AccessProtocolTypeInfo[]
                            {
                                // new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE,		"其他协议类型"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL, "OnVif协议接入"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL, "GB28181协议接入"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_BCSYS_PLAT,	"博康系统平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_H3C_PLAT, "华三平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_PLAT, "海康平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NETPOSA_PLAT, "东方网力平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_IMOS_PLAT, "宇视平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DHPLAT_DEV,	"大华平台接入"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ISOC_PLAT,	"索贝平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_VISS_PLAT,	"VISS平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_WB_PLAT,	"北京机场平台"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_DEV, "海康设备接入"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DH_DEV, "大华设备接入"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_SANYO_IPC_DEV, "三洋IPC"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE, "服务器共享视频"),
                                new AccessProtocolTypeInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_FTP_FILE, "FTP共享视频"),
                            };
				}
				return s_AccessProtocolTypeInfos;
			}
		}

		public static TranceProtocolTypeInfo[] TransProtocolTypeInfos {
			get {
				if (s_TranceProtocolTypeInfos == null) {
					s_TranceProtocolTypeInfos = new TranceProtocolTypeInfo[]
                            {
                                new TranceProtocolTypeInfo(E_TRANS_PROTOCOL_TYPE.E_TRANS_PROTOCOL_NONE, "无转发"),
                                new TranceProtocolTypeInfo(E_TRANS_PROTOCOL_TYPE.E_TRANS_PROTOCOL_TCP, "TCP协议输出"),
                                new TranceProtocolTypeInfo(E_TRANS_PROTOCOL_TYPE.E_TRANS_PROTOCOL_WEBSERVICE,	"WebService协议输出"),
                            };
				}
				return s_TranceProtocolTypeInfos;
			}
		}

		public static IasRealAnalyzeStatusTypeInfo[] IasRealAnalyzeStatusTypeInfo {
			get {
				return new IasRealAnalyzeStatusTypeInfo[]
                {
                    new IasRealAnalyzeStatusTypeInfo(E_IASSDK_REAL_ANALYZE_STATUS_TYPE.E_IASSDK_REAL_ANALYSE_FAILURE, "分析失败"),
                    new IasRealAnalyzeStatusTypeInfo(E_IASSDK_REAL_ANALYZE_STATUS_TYPE.E_IASSDK_REAL_ANALYSE_RUNNING, "分析进行中"),
                };
			}
		}
		public static VideoAnalyzeTypeInfo[] VideoAnalyzeTypeInfo {
			get {
				return new VideoAnalyzeTypeInfo[]
                {        
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE, ""),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC, "动态人脸"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF, "摘要"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM, "运动物"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD, "交通事件"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM, "行为"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD, "大客流"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE, "动态车牌"),
                    new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT, "人员计数"),
                    //new VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH, "以图搜图算法"),
                };
			}
		}

		public static TypeInfo<BehaviorType>[] BehaviorTypeInfo {
			get {
				return new TypeInfo<BehaviorType>[]
                {
                    new TypeInfo<BehaviorType>(BehaviorType.None, ""),
                    new TypeInfo<BehaviorType>(BehaviorType.Mass, "聚集"),
                    new TypeInfo<BehaviorType>(BehaviorType.FlyLeaflet, "撒传单"),
                    new TypeInfo<BehaviorType>(BehaviorType.Banner, "拉横幅"),
                    new TypeInfo<BehaviorType>(BehaviorType.Run, "奔跑"),
                    new TypeInfo<BehaviorType>(BehaviorType.BreakIn, "闯入"),
                    new TypeInfo<BehaviorType>(BehaviorType.BreakOut, "闯出"),
                    new TypeInfo<BehaviorType>(BehaviorType.PasslinePos, "正向越界"),
                    new TypeInfo<BehaviorType>(BehaviorType.PasslineNeg, "逆向越界"),
                    new TypeInfo<BehaviorType>(BehaviorType.AlarmCountBreakIn, "闯入计数"),
                    new TypeInfo<BehaviorType>(BehaviorType.AlarmCountBreakOut, "闯出计数"),
                    new TypeInfo<BehaviorType>(BehaviorType.AlarmCountPasslinePos, "正向越界计数"),
                    new TypeInfo<BehaviorType>(BehaviorType.AlarmCountPasslineNeg, "逆向越界计数"),
                };
			}
		}


		public class TypeInfo<T> {
			public T Type { get; set; }

			public uint NType {
				get {
					return Convert.ToUInt32(Type);
				}
			}

			public string Name { get; set; }

			public TypeInfo(T type, string name) {
				Type = type;
				Name = name;
			}

			public override string ToString() {
				return Name;
			}
		}

		public static TypeInfo<E_VDA_SERVER_TYPE>[] ServerTypeInfos {
			get {
				return new TypeInfo<E_VDA_SERVER_TYPE>[]
                {
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_NONE, "未知"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_VDM, "VDM服务器"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_MSS, "媒体服务器"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_IAS, "分析服务器"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_ADPIS, "转发服务器"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_RTRIS, "存储/检索服务器"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_BRIEF, "摘要服务器"),
                    new TypeInfo<E_VDA_SERVER_TYPE>(E_VDA_SERVER_TYPE.E_SERVER_TYPE_VIAS, "虚拟分析服务器"),
                };
			}
		}


		public static TypeInfo<E_SEARCH_RESULT_OBJECT_TYPE>[] SearchResultObjectTypeInfos {
			get {
				return new TypeInfo<E_SEARCH_RESULT_OBJECT_TYPE>[]
                {
                    new TypeInfo<E_SEARCH_RESULT_OBJECT_TYPE>(E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_NOUSE, "未知"),
                    new TypeInfo<E_SEARCH_RESULT_OBJECT_TYPE>(E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_PASSAGER, "行人"),
                    new TypeInfo<E_SEARCH_RESULT_OBJECT_TYPE>(E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_TWOWHEEL, "两轮车"),
                    new TypeInfo<E_SEARCH_RESULT_OBJECT_TYPE>(E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_VEHICLE, "机动车"),
                };
			}
		}

		public static TypeInfo<E_VDA_SERVER_STATUS>[] ServerStatusInfos {
			get {
				return new TypeInfo<E_VDA_SERVER_STATUS>[]
                {
                    new TypeInfo<E_VDA_SERVER_STATUS>(E_VDA_SERVER_STATUS.E_STATUS_DELETED, "删除"),
                    new TypeInfo<E_VDA_SERVER_STATUS>(E_VDA_SERVER_STATUS.E_STATUS_INUSE, "启用"),
                    new TypeInfo<E_VDA_SERVER_STATUS>(E_VDA_SERVER_STATUS.E_STATUS_UNUSE, "未知"),
                };
			}
		}

		public class ColorDefine {
			public Color Col { get; set; }
			public int ID { get; set; }

		}
		public static TypeInfo<ColorDefine>[] MoveObjectColorInfos {
			get {
				return new TypeInfo<ColorDefine>[]
                {
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = int.MaxValue},"未设置"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = 0},"其他"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Black, ID = 1},"黑色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.White, ID = 2},"白色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.LightGray, ID = 3},"灰色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Red, ID = 4},"红色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Yellow, ID = 5},"黄色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Blue, ID = 6},"蓝色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Orange, ID = 7},"橙色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Brown, ID = 8},"棕色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Green, ID = 9},"绿色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Gold, ID = 49},"花色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = 50},"未知"),
                };
			}
		}
		public static TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>[] BagTypeInfos {
			get {
				return new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>[]
                {
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>(E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_NOUSE,"未设置"),
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>(E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_NO,"无背包"),
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>(E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_KITBAG,"背包"),
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>(E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_HANDBAG,"拎包"),
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>(E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_SATCHEL,"挎包"),
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_BAG_TYPE>(E_MOVE_OBJ_PEOPLE_BAG_TYPE.E_MOVE_OBJ_PEOPLE_BEG_TYPE_UNKNOWN,"未知"),
                };
			}
		}



		public static TypeInfo<ColorDefine>[] VehicleColorInfos {
			get {
				return new TypeInfo<ColorDefine>[]
                {
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = int.MaxValue},"未设置"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.White, ID = 1},"白色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Silver, ID = 2},"黑色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Black, ID = 3},"黑色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Red, ID = 4},"红色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Purple, ID = 5},"紫色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Blue, ID = 6},"蓝色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Yellow, ID = 7},"黄色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Green, ID = 8},"绿色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Brown, ID = 9},"褐色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Pink, ID = 10},"粉红色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.LightGray, ID = 11},"灰色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = 12},"其他"),
                };
			}
		}



		public static TypeInfo<ColorDefine>[] PlateColorInfos {
			get {
				return new TypeInfo<ColorDefine>[]
                {
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = int.MaxValue},"未设置"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Blue, ID = 1},"蓝色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Black, ID = 2},"黑色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Yellow, ID = 3},"黄色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.White, ID = 4},"白色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Green, ID = 5},"绿色"),
                    new TypeInfo<ColorDefine>(new ColorDefine(){ Col = Color.Transparent, ID = 6},"其他"),
                };
			}
		}
		public static TypeInfo<E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE>[] VehiclePlateTypeInfos {
			get {
				return new TypeInfo<E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE>[]
                {
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE>(E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_NOUSE,"未设置"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE>(E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_SINGLE,"单排"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE>(E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_DOUBLE,"双排"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE>(E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE.E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_OTHER,"其他"),
                };
			}
		}

		public static TypeInfo<E_DRIVER_FEATURE_TYPE>[] VehicleDriverFeatureTypeInfos {
			get {
				return new TypeInfo<E_DRIVER_FEATURE_TYPE>[]
                {
                    new TypeInfo<E_DRIVER_FEATURE_TYPE>(E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOUSE,"未设置"),
                    new TypeInfo<E_DRIVER_FEATURE_TYPE>(E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_HAVE,"有"),
                    new TypeInfo<E_DRIVER_FEATURE_TYPE>(E_DRIVER_FEATURE_TYPE.E_DRIVER_FEATURE_TYPE_NOTHAVE,"无"),
                };
			}
		}

		public static TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>[] VehicleTypeInfos {
			get {
				return new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>[]
                {
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>(E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_NOUSE,"未设置"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>(E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_LARGE_BUS,"大型客车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>(E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_LARGE_TRUCTK,"大型货车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>(E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_MIDDLE_BUS,"中型客车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>(E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_SMALL_BUS,"小型客车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_TYPE>(E_VDA_SEARCH_VEHICLE_TYPE.E_SEARCH_VEHICLE_TYPE_SMALL_TRUCK,"小型货车"),
                };
			}
		}

		public static TypeInfo<E_TRANCE_STORE_TYPE>[] TransStoreTypeInfos {
			get {
				return new TypeInfo<E_TRANCE_STORE_TYPE>[]
                {
                    new TypeInfo<E_TRANCE_STORE_TYPE>(E_TRANCE_STORE_TYPE.E_TRANCE_STORE_NOUSE,"未设置"),
                    new TypeInfo<E_TRANCE_STORE_TYPE>(E_TRANCE_STORE_TYPE.E_TRANCE_STORE_LOCAL,"本地存储"),
                    new TypeInfo<E_TRANCE_STORE_TYPE>(E_TRANCE_STORE_TYPE.E_TRANCE_STORE_SHARE,"共享存储"),
                };
			}
		}


		public static TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>[] VehicleDetailTypeInfos {
			get {
				return new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>[]
                {
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_NOUSE,"未设置"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_101,"其他类型大型客车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_201,"集装箱货车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_202,"油罐车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_203,"卡车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_204,"吊车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_205,"拖车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_206,"水泥车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_207,"其他类型大型货车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_301,"面包车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_302,"MPV"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_303,"其他类型中型客车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_401,"SUV"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_402,"其他类型小型客车"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_501,"依维柯"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_502,"皮卡"),
                    new TypeInfo<E_VDA_SEARCH_VEHICLE_DETAIL_TYPE>(E_VDA_SEARCH_VEHICLE_DETAIL_TYPE.E_SEARCH_VEHICLE_DETAIL_TYPE_503,"其他类型小型货车"),
                };
			}
		}

		public static TypeInfo<long>[] VehicleLabelInfos {
			get {
				int retCount = 0, CurCount = 0;
				// return new TypeInfo<long>[0];
				if (getVehicleBrandFunc != null) {
					VBrandList = getVehicleBrandFunc();
				}
				for (int i = 0; i < VBrandList.Count; i++) {
					if (VBrandList[i].ParentID == 0) {
						retCount++;
					}
				}
				TypeInfo<long>[] retval = new TypeInfo<long>[retCount + 1];
				CurCount = 0;
				retval[CurCount++] = new TypeInfo<long>(int.MaxValue, "未设置");
				for (int i = 0; i < VBrandList.Count; i++) {
					if (VBrandList[i].ParentID == 0) {
						retval[CurCount++] = new TypeInfo<long>(VBrandList[i].SubID, VBrandList[i].Name);
					}
				}
				return retval;
			}
		}

		public static TypeInfo<long>[] GetVehicleDetailLabelInfosByParentId(long id) {
			//return new TypeInfo<long>[0];
			int retCount = 0, CurCount = 0;
			for (int i = 0; i < VBrandList.Count; i++) {
				if (VBrandList[i].ParentID == id) {
					retCount++;
				}
			}
			TypeInfo<long>[] retval = new TypeInfo<long>[retCount + 1];
			retval[CurCount++] = new TypeInfo<long>(int.MaxValue, "未设置");
			for (int i = 0; i < VBrandList.Count; i++) {
				if (VBrandList[i].ParentID == id) {
					retval[CurCount++] = new TypeInfo<long>(VBrandList[i].SubID, VBrandList[i].Name);
				}
			}
			return retval;
		}

		public static TypeInfo<E_TRAFFIC_EVENT_TYPE>[] TrafficEventTypeInfos {
			get {
				return new TypeInfo<E_TRAFFIC_EVENT_TYPE>[]
                {
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_None, "未知"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NoReverse, "逆行"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_Jam, "阻塞"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_PassagerCross, "行人横穿"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarCross, "车辆横穿"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarFast, "车辆超速"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarLow, "车辆低速"),
                    new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_CarStop, "车辆停泊"),

        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_ON_MOTORWAY, "机占非"),
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_PASSING, "禁行"),
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_TURNAROUND, "禁止调头"), 
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_LEFT, "禁止左转"), 
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_RIGHT, "禁止右转"), 
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_NO_STRAIGHT, "禁止直行"), 
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_PRESS_LINE, "压线"), 
        new TypeInfo<E_TRAFFIC_EVENT_TYPE>(E_TRAFFIC_EVENT_TYPE.E_TRAFFIC_EVENT_TYPE_ON_BUSWAY, "占用公交车道"),

                };
			}
		}

		public static TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>[] DriveDirectionTypeInfos {
			get {
				return new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>[]
                {
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_NOUSE, "未知"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_W , "由东向西"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_E , "由西向东"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_N , "由南向北"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_S , "由北向南"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_NW, "由东南向西北"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_SE, "由西北向东南"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_SW, "由东北向西南"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_NE, "由西南向东北"),
                    new TypeInfo<E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE>(E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE.E_DRIVE_DIRECTION_TYPE_Other, "其他"),	

                };
			}
		}


		public static TypeInfo<E_BRIEF_STATE>[] BriefStateTypeInfos {
			get {
				return new TypeInfo<E_BRIEF_STATE>[]
                {
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_FINISHED, "摘要合成完成"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_ORIGINAL_INDEX_ERROR, "原始索引错误"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_SYNTH_INDEX_ERROR, "无合成索引内存空间"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_GET_OBJECT_RELATE_DATA_ERROR, "获取目标关联数据错误"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_SET_OBJECT_RELATE_DATA_ERROR, "设置目标关联数据错误"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_SYNTHESIZE_FAILED, "摘要算法合成失败"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_BRIEF_OBJECT_NULL, "无摘要目标"), 
                    new TypeInfo<E_BRIEF_STATE>(E_BRIEF_STATE.E_BRIEF_STATE_STOPSYNTH, "停止摘要合成"), 
                };
			}
		}

        public static TypeInfo<E_MOVE_OBJ_PEOPLE_GENDER_TYPE>[] PeopleSexTypeInfos
        {
			get {
                return new TypeInfo<E_MOVE_OBJ_PEOPLE_GENDER_TYPE>[]
                {
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_GENDER_TYPE>(E_MOVE_OBJ_PEOPLE_GENDER_TYPE.E_MOVE_OBJ_PEOPLE_GENDER_TYPE_ALL, "全部"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_GENDER_TYPE>(E_MOVE_OBJ_PEOPLE_GENDER_TYPE.E_MOVE_OBJ_PEOPLE_GENDER_TYPE_FEMALE, "女"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_GENDER_TYPE>(E_MOVE_OBJ_PEOPLE_GENDER_TYPE.E_MOVE_OBJ_PEOPLE_GENDER_TYPE_MALE, "男"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_GENDER_TYPE>(E_MOVE_OBJ_PEOPLE_GENDER_TYPE.E_MOVE_OBJ_PEOPLE_GENDER_TYPE_UNKNOWN, "未知"), 
                };
			}
		}


        public static TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>[] PeopleAgeTypeInfos
        {
			get {
                return new TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>[]
                {
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>(E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_ALL, "全部"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>(E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_AGEDNESS, "老年"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>(E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_INFANCY, "幼年"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>(E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_MIDLIFE, "中年"), 
                    new TypeInfo<E_MOVE_OBJ_PEOPLE_AGE_TYPE>(E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_UNKNOWN, "未知"), 
                };
			}
		}

        public static TypeInfo<E_PEOPLE_NATION>[] PeopleNationTypeInfos
        {
            get
            {
                return new TypeInfo<E_PEOPLE_NATION>[]
                {
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.汉族,            "汉族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.回族,            "回族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.壮族,            "壮族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.满族,            "满族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.维吾尔族,        "维吾尔族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.苗族,            "苗族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.彝族,            "彝族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.土家族,          "土家族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.藏族,            "藏族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.蒙古族,          "蒙古族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.侗族,            "侗族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.布依族,          "布依族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.瑶族,            "瑶族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.白族,            "白族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.朝鲜族,          "朝鲜族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.哈尼族,          "哈尼族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.黎族,            "黎族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.哈萨克族,        "哈萨克族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.傣族,            "傣族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.畲族,            "畲族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.傈僳族,          "傈僳族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.东乡族,          "东乡族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.仡佬族,          "仡佬族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.拉祜族,          "拉祜族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.佤族,            "佤族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.水族,            "水族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.纳西族,          "纳西族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.羌族,            "羌族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.土族,            "土族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.仫佬族,          "仫佬族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.锡伯族,          "锡伯族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.柯尔克孜族,      "柯尔克孜族"            ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.景颇族,          "景颇族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.达斡尔族,        "达斡尔族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.撒拉族,          "撒拉族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.布朗族,          "布朗族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.毛南族,          "毛南族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.塔吉克族,        "塔吉克族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.普米族,          "普米族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.阿昌族,          "阿昌族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.怒族,            "怒族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.鄂温克族,        "鄂温克族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.京族,            "京族"                  ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.基诺族,          "基诺族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.德昂族,          "德昂"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.保安族,          "保安族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.俄罗斯族,        "俄罗斯族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.裕固族,          "裕固族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.乌孜别克族,      "乌孜别克族"            ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.门巴族,          "门巴族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.鄂伦春族,        "鄂伦春族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.独龙族,          "独龙族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.赫哲族,          "赫哲族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.高山族,          "高山族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.珞巴族,          "珞巴族"                ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.塔塔尔族,        "塔塔尔族"              ),
       new TypeInfo<E_PEOPLE_NATION>(E_PEOPLE_NATION.未知,            "未知"                  ),
                };
            }
        } 

	}
}



