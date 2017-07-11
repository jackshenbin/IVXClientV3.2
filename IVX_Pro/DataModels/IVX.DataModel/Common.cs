using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net.NetworkInformation;
using System.Net;

namespace IVX.DataModel
{
    #region 枚举类型定义
    public enum TaskFileType
    {        
        None = 0,
        LocalFile = 1,
        FtpHttpFile=2,
        PlateFile=3,
    }
    //[Flags]
    //public enum TaskShowStatus
    //{
    //    None = 0,
    //    Import = 1,
    //    Analyse = 2,
    //    Finish = 4,
    //    Failed = 8,
    //}

    public enum TaskType
    {
        None = 0,
        Realtime = 1,
        History = 2,
        Project = 3,
    }

    public enum DeviceType
    {
        None = 0,

    }
    public enum ProtocolType
    {
        None = 0,

    }
    [FlagsAttribute]
    public enum TreeShowObjectFilter
    {
        NoUse = 0,
        Object = 1,
        Face = 2,
        Car = 4,
        Brief = 8,
    }

    //码流状态
    public enum ERVODSDK_STREAM_STATUS
    {
        E_STREAM_STATUS_FINISH,	 //码流回调完成
    };
    public enum BehaviorType
    {
        Mass = 0,//聚集 = 0,
        FlyLeaflet,//撒传单,
        Banner,//拉横幅,
        Run,//奔跑,
        BreakIn,//目标闯入,
        BreakOut,//目标闯出,
        PasslinePos,//目标正向越界,
        PasslineNeg,//目标逆向越界,
        AlarmCountBreakIn=10,//目标闯入,
        AlarmCountBreakOut,//目标闯出,
        AlarmCountPasslinePos,//目标正向越界,
        AlarmCountPasslineNeg,//目标逆向越界,
        None=1000,

    }
    public enum AnalyseTypeDetail
    {
        AnalyseTypeDitailNone,
        /// <summary>
        /// 运动物
        /// </summary>
        AnalyseTypeDitailObject,
        /// <summary>
        /// 人脸
        /// </summary>
        AnalyseTypeDitailFace,
        ///// <summary>
        ///// 车牌
        ///// </summary>
        //AnalyseTypeDitailVehicle,
        /// <summary>
        /// 行为事件
        /// </summary>
        AnalyseTypeDitailBehaviour,
        /// <summary>
        /// 人群聚集
        /// </summary>
        AnalyseTypeDitailCollect,
        /// <summary>
        /// 交通事件
        /// </summary>
        AnalyseTypeDitailAccidentAlarm,
    }
    public enum DrawGraphType
    {
        None = 0,
        //AnalyseArea = 1,
        PassLine = 2,
        PassRegion,
        VehicleRegion,
        VehicleFluxLine1 = 5,
        VehicleFluxLine2,
        VehicleFluxLine3,
        VehicleFluxLine4,
        VehicleFluxLine5,
        VehicleFluxLine6,
        DriveWay1 = 11,
        DriveWay2,
        DriveWay3,
        DriveWay4,
        DriveWay5,
        DriveWay6,
        FarArea = 21,
        NearArea,
        ImageSC,
        AnalyseAreaEx = 31,
        PeopleCountLine = 32,
        GlobaRegion = 40,
        ParticalRegion = 41,
        ChangeChannelLine = 50,
        PressChannelLine = 51,
        StopLine = 52,
        SecondLine = 53,
        NoStraightLine = 54,
        NoLeftLine = 55,
        NoRightLine = 56,
        NoTurnAroundLine = 57,
    }
    [Flags]
    public enum BehaviourSubType
    {
        None = 0,
        PassLine = 1,
        PassRegion = 2,
        Runing = 4,
        Banner = 8,
        FlyLeaflet = 16,
        Mass = 32,

    }
    [Flags]
    public enum AccidentAlarmSubType
    {
        None = 0,
        CheckJam = 2,
        Flux = 128,
    }

    public enum eSNAP_TYPE
    {
        SNAP_ANY = 0,                    // 任意格式（BMP或JPEG）
        SNAP_BMP,
        SNAP_JPEG
    };
    public enum eSTRM_DEVICE_TYPE
    {
        STRM_DEVICE_TYPE_UNKNOWN = 0,	// 未知类型
        STRM_DEVICE_TYPE_BOCOM,
        STRM_DEVICE_TYPE_STD,			// 标准码流
        STRM_DEVICE_TYPE_HK,		    // 海康码流
        STRM_DEVICE_TYPE_DH,			// 大华码流
        STRM_DEVICE_TYPE_H3C,			// 华三码流
        STRM_DEVICE_TYPE_NET,			// 网力码流
        STRM_DEVICE_TYPE_TRANSCODE
    };
    //服务单元类型
    public enum E_ADPSSDK_SERVER_UNIT_TYPE
    {
	    E_ADPSSDK_SERVER_UNIT_ONE = 1,		//单路分析
	    E_ADPSSDK_SERVER_UNIT_TWO = 2,		//两路分析
    };
    //抓图缓冲区的类型
    public enum EDIO_SnapPictureBufType
    {
	    DIO_SNAP_PICTURE_BUF_TYPE_BMP = 0,		//bmp
	    DIO_SNAP_PICTURE_BUF_TYPE_JPG,			//jpg
    };

    //实时分析状态
    public enum E_IASSDK_REAL_ANALYZE_STATUS_TYPE
    {
        E_IASSDK_REAL_ANALYSE_RUNNING = 0,		//分析进行中
        E_IASSDK_REAL_ANALYSE_FAILURE = 1,		//分析失败
    };
    // 视频分析类型
    enum E_IASSDK_VIDEO_ANALYZE_TYPE
    {
        //需要存储分析数据的算法
        E_R_IASSDK_MOVEOBJ_ANALYSE = 0,								//运动物分析算法
        E_R_IASSDK_VEHICLE_ANALYSE,									//车辆分析算法
        E_R_IASSDK_FACE_ANALYSE,									//人脸分析算法
        E_R_IASSDK_BRIEF_ANALYSE,									//摘要分析算法

        E_R_IASSDK_PLAT_MOVEOBJ_ANALYSE,								//平台运动物算法 
        E_R_IASSDK_PLAT_CROSSROAD_ANALYSE,							//平台电警卡口算法

        //报警算法
        E_R_IASSDK_ACCIDENT_ALARM = 128,							//交通事故报警算法
        E_R_IASSDK_BEHAVIOR_ALARM,									//行为报警算法

        //特效算法
        E_R_IASSDK_WIPE_OFF_FOG_SPECIFICNESS = 256,					//去雾特效算法
        E_R_IASSDK_CROWD_ANALYSE,									//人群聚集算法
        E_R_IASSDK_PEOPLE_COUNT,									//数人头算法


        E_R_IASSDK_IMAGE_ANALYSE = 512,									//二次识别算法

    };

    // 视频分析类型
    public enum E_VIDEO_ANALYZE_TYPE
    {
        E_ANALYZE_NOUSE = 0, // 无效算法 
        E_ANALYZE_MOVEOBJ = 1, // 运动物分析(旧) 
        E_ANALYZE_VEHICLE = 2, // 车辆分析 
        E_ANALYZE_FACE = 3, // 人脸分析 
        E_ANALYZE_BRIEAF = 4, // 摘要分析 
        E_ANALYZE_MOVEOBJ_PLATFORM = 5, // 平台运动物分析 
        E_ANALYZE_CROSSROAD = 6, // 平台电警卡口 
        E_ANALYZE_DYNAMIC_VEHICLE = 7, // 动态背景车牌提取算法 
        E_ANALYZE_ACCIDENT_ALARM = 128, // 交通事故报警 
        E_ANALYZE_BEHAVIOR_ALARM = 129, // 行为报警算法 

        E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG = 256, // 去雾特效 
        E_ANALYZE_CROWD = 257, // 人群聚集 
        E_ANALYZE_PERSON_COUNT = 258, // 人员计数 

        E_ANALYZE_IMAGE_SEARCH = 512, // 以图搜图 
        E_ANALYZE_FACE_DYNAMIC = 513, // 动态人脸
    };


    enum E_ANALYZE_TYPE_OCX
    {
        E_MOVEOBJ_ANALYSE =0,								//平台运动物算法 
        E_BEHAVIOR_PASSLINE = 1,									//越界
        E_BEHAVIOR_BREAKAREA =2,									//区域入侵
        E_BEHAVIOR_Run = 3,									//奔跑
        E_BEHAVIOR_Banner = 4,									//拉横幅
        E_BEHAVIOR_FlyLeaflet = 5,									//撒传单
        E_BEHAVIOR_Mass = 6,									//聚集
        E_CROWD_ANALYSE = 7,									//人群聚集算法

    };

    //服务单元类型
    public enum E_IASSDK_SERVER_UNIT_TYPE
    {
        E_IASSDK_ANALYSIS_UNIT_UNKNOW = 0,
        E_IASSDK_ANALYSIS_UNIT_ONE = 1,		//单路分析
        E_IASSDK_ANALYSIS_UNIT_TWO = 2,		//两路分析
    };
    public enum E_LOGIN_RESULT
    {
        LOGIN_SUCCESS = 0,		//登录成功
        LOGIN_IPPORT_ERROR,		//IP地址或端口号不正确
        LOGIN_USERNAME_INPUT,	//请输入用户名......
        LOGIN_PASSWORD_INPUT,	//请输入密码......
        //LOGIN_CONNECTING,			//正在连接服务器.......
        //LOGIN_CHECKING,			//服务器连接成功，正在验证用户......
        LOGIN_ERROR,			//连接不上服务器
        LOGIN_CHECK_ERROR,		//用户验证失败
        LOGIN_USER_ERROR,		//用户名不存在
        LOGIN_PASSWORD_ERROR,	//用户密码错误
        LOGIN_USER_TOOMANY,		//超过服务器支持的连接数
        LOGIN_USER_EXIST,		//该用户已经登录
    };
    public enum E_OBJECT_TYPE
    {
        SEARCH_ALL_OBJECT = 0,	//所有目标（或不确定）
        SEARCH_VEHICLE_OBJECT,	//车
        SEARCH_HUMAN_OBJECT		//人
    };

    ///// <summary>
    ///// 任务状态
    ///// </summary>
    //public enum E_VDA_TASK_STATUS
    //{
    //    /// <summary>
    //    /// 任务未知状态
    //    /// </summary>
    //    E_TASK_NOUSE = 0,
    //    /// <summary>
    //    /// 任务等待
    //    /// </summary>
    //    E_TASK_WAIT = 1,
    //    /// <summary>
    //    /// 任务执行
    //    /// </summary>
    //    E_TASK_EXECUTING = 2,
    //    /// <summary>
    //    /// 任务完成
    //    /// </summary>
    //    E_TASK_FINISH = 3,
    //    /// <summary>
    //    /// 任务失败
    //    /// </summary>
    //    E_TASK_FAILED = 4,
    //};
    /// <summary>
    /// 任务状态
    /// </summary>
    public enum E_VDA_TASK_STATUS
    {
        E_TASK_STATUS_NOUSE = 0, // 任务未知状态（不限） 
        E_TASK_STATUS_WAITING = 1, // 任务等待中（仅限历史任务有效） 
        E_TASK_STATUS_IMPORT_WAIT = 2, // 任务等待导入（仅限历史任务有效） 
        E_TASK_STATUS_IMPORT_EXECUTING = 3, // 任务正在导入（仅限历史任务有效） 
        E_TASK_STATUS_IMPORT_FAILED = 4, // 任务导入失败（仅限历史任务有效） 
        E_TASK_STATUS_ANALYSE_WAIT = 5, // 任务等待分析（不限） 
        E_TASK_STATUS_ANALYSE_EXECUTING = 6, // 任务正在分析（不限） 
        E_TASK_STATUS_ANALYSE_FINISH = 7, // 任务分析完成（仅限历史任务有效） 
        E_TASK_STATUS_ANALYSE_FAILED = 8, // 任务分析失败（仅限历史任务有效） 
        E_TASK_STATUS_ANALYSE_SUSPEND = 9, // 任务已暂停（仅限实时、计划任务有效） 
        E_TASK_STATUS_BEEN_DELETE = 10, // 任务已被删除
    };

    /// <summary>
    /// 任务单元类型
    /// </summary>
    public enum E_VDA_TASK_UNIT_TYPE
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        E_TASKUNIT_TYPE_UNKNOW = 0,
        /// <summary>
        /// 客户端导入视频文件
        /// </summary>
        E_TASKUNIT_TYPE_CLIENT_VIDEO_FILE = 1,
        /// <summary>
        /// 服务器导入视频文件
        /// </summary>
        E_TASKUNIT_TYPE_FILESERVER_VIDEO_FILE = 2,
        /// <summary>
        /// 网络存储导入视频文件
        /// </summary>
        E_TASKUNIT_TYPE_NETSTORE_VIDEO_FILE = 3,
        /// <summary>
        /// 客户端导入图片包
        /// </summary>
        E_TASKUNIT_TYPE_CLIENT_PIC_PACKAGE = 4,
        /// <summary>
        /// 服务器导入图片包
        /// </summary>
        E_TASKUNIT_TYPE_FILESERVER_PIC_PACKAGE = 5,
        /// <summary>
        /// 共享磁盘
        /// </summary>
        E_TASKUNIT_TYPE_SHARE_DISK = 6,

        /// <summary>
        /// 导入已分析视频
        /// </summary>
        E_TASKUNIT_TYPE_ANALYSED_VIDEO = 7
    };

    /// <summary>
    /// 任务单元导入状态
    /// </summary>
    public enum E_VDA_TASK_UNIT_STATUS
    {
        /// <summary>
        /// 任务单元未知状态
        /// </summary>
        E_TASK_UNIT_NOUSE = 0,
        /// <summary>
        /// 任务单元导入等待
        /// </summary>
        E_TASK_UNIT_IMPORT_WAIT = 1,
        /// <summary>
        /// 任务单元导入准备
        /// </summary>
        E_TASK_UNIT_IMPORT_READY = 2,
        /// <summary>
        /// 任务单元导入开始
        /// </summary>
        E_TASK_UNIT_IMPORT_EXECUTING = 3,
        /// <summary>
        /// 任务单元导入完成
        /// </summary>
        E_TASK_UNIT_IMPORT_FINISH = 4,
        /// <summary>
        /// 任务单元导入失败
        /// </summary>
        E_TASK_UNIT_IMPORT_FAILED = 5,
        /// <summary>
        /// 任务单元预分析等待
        /// </summary>
        E_TASK_UNIT_PREANALYSE_WAIT = 6,
        /// <summary>
        /// 任务单元预分析开始
        /// </summary>
        E_TASK_UNIT_PREANALYSE_EXECUTING = 7,
        /// <summary>
        /// 任务单元预分析完成
        /// </summary>
        E_TASK_UNIT_PREANALYSE_FINISH = 8,
        /// <summary>
        /// 任务单元预分析失败
        /// </summary>
        E_TASK_UNIT_PREANALYSE_FAILED = 9,
        /// <summary>
        /// 任务单元分析等待
        /// </summary>
        E_TASK_UNIT_ANALYSE_WAIT = 10,
        /// <summary>
        /// 任务单元分析开始
        /// </summary>
        E_TASK_UNIT_ANALYSE_EXECUTING = 11,
        /// <summary>
        /// 任务单元分析完成
        /// </summary>
        E_TASK_UNIT_ANALYSE_FINISH = 12,
        /// <summary>
        /// 任务单元分析失败
        /// </summary>
        E_TASK_UNIT_ANALYSE_FAILED = 13,
    };


    /// <summary>
    /// 全分析类型
    /// </summary>
    [Serializable]
    enum E_VDA_ANALYZE_TYPE
    {
        /// <summary>
        /// 目标检测(运动物分析算法)
        /// </summary>
        E_ANALYZE_OBJECT = 0x00000001,
        /// <summary>
        /// 车牌识别
        /// </summary>
        E_ANALYZE_VEHICLE = 0x00000002,
        /// <summary>
        /// 人脸检测
        /// </summary>
        E_ANALYZE_FACE = 0x00000004,
        /// <summary>
        /// 浓缩摘要
        /// </summary>
        E_ANALYZE_BRIEAF = 0x00000008,
        /// <summary>
        /// 车牌图片识别
        /// </summary>
        E_ANALYZE_VEHICLE_PIC = 0x00000010,
        /// <summary>
        /// 人脸图片检测
        /// </summary>
        E_ANALYZE_FACE_PIC = 0x00000020,
        /// <summary>
        /// 实时运动物分析算法
        /// </summary>
        E_R_ANALYZE_OBJECT = 0x00000100,
        /// <summary>
        /// 实时车牌分析算法
        /// </summary>
        E_R_ANALYZE_VEHICLE = 0x00000200,
        /// <summary>
        /// 实时人脸分析算法
        /// </summary>
        E_R_ANALYZE_FACE = 0x00000300,
        /// <summary>
        /// 实时摘要分析算法
        /// </summary>
        E_R_ANALYZE_BRIEAF = 0x00000400,
        /// <summary>
        /// 实时行为分析算法
        /// </summary>
        E_R_ANALYZE_BEHAVE = 0x00001000,
    };

    /*
    /// <summary>
    /// 任务单元分析状态
    /// </summary>
    public enum E_VDA_TASK_UNIT_ANALYZE_STATUS
    {
        /// <summary>
        /// 无分析任务
        /// </summary>
        E_TASKUNIT_NO_ANALYZE = 0,
        /// <summary>
        /// 等待导入中
        /// </summary>
        E_TASKUNIT_ANALYZE_WAIT = 1,
        /// <summary>
        /// 分析中
        /// </summary>
        E_TASKUNIT_ANALYZE,
        /// <summary>
        /// 完成
        /// </summary>
        E_TASKUNIT_ANALYZE_COMPLETE,
        /// <summary>
        /// 分析失败
        /// </summary>
        E_TASKUNIT_ANALYZE_FAILED,

    };
    */

    /// <summary>
    /// 服务器类型
    /// </summary>
    public enum E_VDA_SERVER_TYPE
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        E_SERVER_TYPE_NONE = 0,
        /// <summary>
        /// VDM服务器
        /// </summary>
        E_SERVER_TYPE_VDM = 1,
        /// <summary>
        /// 媒体服务器
        /// </summary>
        E_SERVER_TYPE_MSS = 11,
        /// <summary>
        /// 分析服务器
        /// </summary>
        E_SERVER_TYPE_IAS = 12,
        /// <summary>
        /// 转发服务器
        /// </summary>
        E_SERVER_TYPE_ADPIS = 23,
        /// <summary>
        /// 存储/检索服务器
        /// </summary>
        E_SERVER_TYPE_RTRIS=16,
        /// <summary>
        /// 摘要服务器
        /// </summary>
        E_SERVER_TYPE_BRIEF=24,
        /// <summary>
        /// 虚拟分析服务器
        /// </summary>
        E_SERVER_TYPE_VIAS=25,
    };
    /// <summary>
    /// 服务器状态类型
    /// </summary>
    public enum E_VDA_SERVER_STATUS
    {
        /// <summary>
        /// 未知状态
        /// </summary>
        E_STATUS_UNUSE = 0,
        /// <summary>
        /// 启用状态
        /// </summary>
        E_STATUS_INUSE=1,
        /// <summary>
        /// 删除状态
        /// </summary>
        E_STATUS_DELETED = 2,
    };

    /// <summary>
    /// 用户角色类型
    /// </summary>
    public enum E_VDA_USER_ROLE_TYPE
    {
		E_ROLE_TYPE_OTHER = 0,
		/// <summary>
		/// 管理员
		/// </summary>
		E_ROLE_TYPE_ADMIN = 0x1,
        /// <summary>
        /// 普通用户（组员）
        /// </summary>
		E_ROLE_TYPE_NORMAL = 0x2,
        /// <summary>
        /// 组长
        /// </summary>
        E_ROLE_TYPE_LEADER = 0x4,
        
        /// <summary>
        /// 超级管理员
        /// </summary>
        E_ROLE_TYPE_SUPPER = 0x8,
    };

    /// <summary>
    /// 会话状态
    /// </summary>
    public enum E_VDA_SESSION_STATUS
    {
        /// <summary>
        /// 会话离线
        /// </summary>
        E_SESSION_STATUS_OFFLINE = 0,
        /// <summary>
        /// 会话在线
        /// </summary>
        E_SESSION_STATUS_ONLINE,
    };

    /// <summary>
    /// 配置通知类型定义
    /// </summary>
    public enum E_VDA_SDK_CFG_NOTIFY_TYPE
    {
        /// <summary>
        /// 新增通知
        /// </summary>
        E_CFG_NOTIFY_TYPE_ADD = 1,
        /// <summary>
        /// 修改通知
        /// </summary>
        E_CFG_NOTIFY_TYPE_MDF = 2,
        /// <summary>
        /// 删除通知
        /// </summary>
        E_CFG_NOTIFY_TYPE_DEL = 3,
    };

    /// <summary>
    /// 播放速度
    /// </summary>
    public enum E_VDA_PLAY_SPEED
    {
        E_PLAYSPEED_SLOW16 = 1,
        E_PLAYSPEED_SLOW8,
        E_PLAYSPEED_SLOW4,
        E_PLAYSPEED_SLOW2,
        E_PLAYSPEED_NORMALSPEED,
        E_PLAYSPEED_FAST2,
        E_PLAYSPEED_FAST4,
        E_PLAYSPEED_FAST8,
        E_PLAYSPEED_FAST16,
    };


    /// <summary>
    /// 播放控制类型
    /// </summary>
    public enum E_VDA_PLAYCTRL_TYPE
    {
        E_PLAYCTRL_START = 1,		//开始播放
        E_PLAYCTRL_STOP = 2,	    //停止播放

        E_PLAYCTRL_PAUSE = 3,	        //暂停播放
        E_PLAYCTRL_RESUME = 4,			//恢复播放
        // 	E_PLAYCTRL_FAST,	        //快放
        // 	E_PLAYCTRL_SLOW,	        //慢放

        E_PLAYCTRL_SETSPEED = 11,	//设置播放速度, 见E_VDA_PLAY_SPEED
        E_PLAYCTRL_GETSPEED = 12,		//获取播放速度
        E_PLAYCTRL_STEP = 13,			//单帧前进
        E_PLAYCTRL_STEP_BACK = 14,		//单帧后退

        E_PLAYCTRL_SETTIME = 15,			//按绝对时间定位（必须是按时间范围播放）
        E_PLAYCTRL_GETTIME = 16,			//获取回放绝对时间
        E_PLAYCTRL_SETPOS = 17,	        //定位回放的进度（千分比整数值，801表示80.1%）
        E_PLAYCTRL_GETPOS = 18,	        //获取回放的进度
        E_PLAYCTRL_GETTIME_RANGE = 19,			//获取回放总时间
        E_PLAYCTRL_PLAY_BY_SEEK = 20,	//定位后播放
    };

    /// <summary>
    /// 播放状态
    /// </summary>
    public enum E_VDA_PLAY_STATUS
    {
        E_PLAY_STATUS_NOVIDEO =0,       //未播放
        E_PLAY_STATUS_NORMAL = 1,		//正常播放
        E_PLAY_STATUS_FINISH,	        //结束播放
        E_PLAY_STATUS_FAILED,	        //播放失败
        E_PLAY_STATUS_STARTPLAY_READY,	//开始播放准备就绪(StartPlay时触发)
        E_PLAY_STATUS_SYNTH_ERROR,		//合成失败
        E_PLAY_STATUS_SEEK_ERROR,		//无法定位    
        E_PLAY_STATUS_PAUSE,		//暂停  
        E_PLAY_STATUS_SPEED,		//变速  
        E_PLAY_STATUS_BACKWORD,		//倒放  
  
    };

    /// <summary>
    /// 下载状态
    /// </summary>
    public enum E_VDA_DOWNLOAD_STATUS
    {
        E_DOWNLOAD_STATUS_NOUSE = 0, //未知的导出状态 
        E_DOWNLOAD_STATUS_TRANS_CODE_WAIT = 1, //等待转码 
        E_DOWNLOAD_STATUS_TRANS_CODE_NORMAL, //正在转码 
        E_DOWNLOAD_STATUS_TRANS_CODE_FINISH, //完成转码 
        E_DOWNLOAD_STATUS_TRANS_CODE_FAILED, //转码失败 
        E_DOWNLOAD_STATUS_DOWN_LOAD_WAIT, //等待导出 
        E_DOWNLOAD_STATUS_DOWN_LOAD_NORMAL, //正在导出 
        E_DOWNLOAD_STATUS_DOWN_LOAD_FINISH, //完成导出 
        E_DOWNLOAD_STATUS_DOWN_LOAD_FAILED, //导出失败 
    };

    /// <summary>
    /// 导出结果
    /// </summary>
    public enum E_VDA_EXPORT_STATUS
    {
        E_EXPORT_STATUS_NORMAL = 1,		//正常导出
        E_EXPORT_STATUS_FINISH,	        //结束导出
        E_EXPORT_STATUS_FAILED,	        //导出失败
    }

    /// <summary>
    /// 抓图保存图片格式
    /// </summary>
    public enum E_VDA_GRAB_PIC_TYPE
    {
        E_GRAB_PIC_BMP = 0,	//bmp格式
        E_GRAB_PIC_JPG = 1,	//Jpg格式
    };

    public enum E_PICTURE_FORM_TYPE
    {
        E_PICTURE_FORM_OCX,//ocx
        E_PICTURE_FORM_SECRCH,//检索结果
        E_PICTURE_FORM_SECRCH_VIDEO,//检索回放
        E_PICTURE_FORM_BIREF,//摘要
        E_PICTURE_FORM_BRIEF_VIDEO,//摘要回溯
        E_PICTURE_FORM_VIDEOPLAY,//视频播放
        E_PICTURE_FORM_DOWNLOAD,//下载
    };

    /// <summary>
    /// 运动对象类型（用于人车分类）
    /// </summary>
    public enum E_VDA_MOVEOBJ_TYPE
    {

        E_VDA_MOVEOBJ_TYPE_ALL = 0,	    //0全部
        E_VDA_MOVEOBJ_TYPE_PEOPLE,		//人
        E_VDA_MOVEOBJ_TYPE_CAR,			//车
        E_VDA_MOVEOBJ_TYPE_UNKNOWN,     //未知
    }

    // 摘要合成状态 
    public enum E_BRIEF_STATE
    {
        E_BRIEF_STATE_FINISHED = 0, //摘要合成完成 
        E_BRIEF_STATE_ORIGINAL_INDEX_ERROR, //原始索引错误 
        E_BRIEF_STATE_SYNTH_INDEX_ERROR, //无合成索引内存空间 
        E_BRIEF_STATE_GET_OBJECT_RELATE_DATA_ERROR, //获取目标关联数据错误 
        E_BRIEF_STATE_SET_OBJECT_RELATE_DATA_ERROR, //设置目标关联数据错误 
        E_BRIEF_STATE_SYNTHESIZE_FAILED, //摘要算法合成失败 
        E_BRIEF_STATE_BRIEF_OBJECT_NULL, //无摘要目标 
        E_BRIEF_STATE_STOPSYNTH, //停止摘要合成 
    };

    /// <summary>
    /// 摘要播放对象密度
    /// </summary>
    public enum E_VDA_BRIEF_DENSITY
    {
        E_BRIEF_DENSITY_00 = 0,	//摘要密度0.0
        E_BRIEF_DENSITY_01,		//摘要密度0.1
        E_BRIEF_DENSITY_02,		//摘要密度0.2
        E_BRIEF_DENSITY_03,		//摘要密度0.3
        E_BRIEF_DENSITY_04,		//摘要密度0.4
        E_BRIEF_DENSITY_05,		//摘要密度0.5
        E_BRIEF_DENSITY_06,		//摘要密度0.6
        E_BRIEF_DENSITY_07,		//摘要密度0.7
        E_BRIEF_DENSITY_08,		//摘要密度0.8
        E_BRIEF_DENSITY_09,		//摘要密度0.9
        E_BRIEF_DENSITY_10,		//摘要密度1.0
    }

    /// <summary>
    /// 摘要播放控制类型
    /// </summary>
    public enum E_VDA_BRIEF_PLAYCTRL_TYPE
    {

        E_BRIEF_PLAYCTRL_START = 1,	//开始播放（进行摘要合成并播放）
        E_BRIEF_PLAYCTRL_STOP = 2,	    //停止播放

        E_BRIEF_PLAYCTRL_PAUSE = 3,	        //暂停播放
        E_BRIEF_PLAYCTRL_RESUME = 4,		//恢复播放

        E_BRIEF_PLAYCTRL_SETSPEED = 11,		//设置播放速度, 见E_VDA_PLAY_SPEED(目前复用视频播放的速度定义）
        E_BRIEF_PLAYCTRL_GETSPEED = 12,		//获取播放速度

        E_BRIEF_PLAYCTRL_SETPOS = 13,	        //定位回放的进度（千分比整数值，801表示80.1%）
        E_BRIEF_PLAYCTRL_GETPOS = 14,	        //获取回放的进度
        E_BRIEF_PLAYCTRL_GETTIME_RANGE = 19,	//获取播放时长(秒）
    }

    /// <summary>
    /// 摘要行为过滤类型
    /// </summary>
    public enum E_VDA_BRIEF_DRAW_FILTER_TYPE
    {
        GRAPH_TYPE_NULL = 0, //无图形 

        GRAPH_TYPE_ARROW_LINE=2, //越界线 
        GRAPH_TYPE_ARROW_FRAME=3, //闯入闯出框 

        GRAPH_TYPE_INTERESTED_AREA=7, //关注区域（感兴趣区域） 
        GRAPH_TYPE_UNINTERESTED_AREA=8, //屏蔽区域（无兴趣区域） 
    }

    /// <summary>
    /// 摘要播放叠加画图信息类型
    /// </summary>
    public enum E_VDA_BRIEF_PLAY_DRAW_TYPE
    {

        E_BRIEF_PLAY_DRAW_OBJ_FRAME = 0,	//叠加目标框
        E_BRIEF_PLAY_DRAW_OBJ_TIME = 1,			//叠加目标时间
        E_BRIEF_PLAY_DRAW_ACTION_FILTER = 2,	//叠加行为过滤
        E_BRIEF_PLAY_DRAW_AREA_FILTER = 3,		//叠加区域过滤
    }

    /// <summary>
    /// 摘要窗口鼠标操作类型
    /// </summary>
    public enum E_VDA_BRIEF_WND_MOUSE_OPT_TYPE
    {
        E_BRIEF_WND_MOUSE_LDown = 0,	//鼠标左键单击
        E_BRIEF_WND_MOUSE_LUp = 1,	//鼠标左键单击
        E_BRIEF_WND_MOUSE_RCLICK = 2,		//鼠标右键单击
        E_BRIEF_WND_MOUSE_LDCLICK = 3,		//鼠标左键双击
    }

    /// <summary>
    /// 播放窗口鼠标操作类型
    /// </summary>
    public enum E_VDA_PLAY_WND_MOUSE_OPT_TYPE
    {
        E_PLAY_WND_MOUSE_UNKNOW = 0,	//鼠标无效操作
        E_PLAY_WND_MOUSE_LCLICK = 1,	//鼠标左键单击
        E_PLAY_WND_MOUSE_LDCLICK = 2,		//鼠标左键双击
        E_PLAY_WND_MOUSE_RCLICK = 3,		//鼠标右键单击
        E_PLAY_WND_MOUSE_RDCLICK = 4,		//鼠标右键双击
    };
    /// <summary>
    /// 智能分析检索闯入闯出区域类型
    /// </summary>
    public enum E_VDA_SEARCH_BREAK_REGION_TYPE
    {
        E_SEARCH_BREAK_REGION_TYPE_NOUSE = 0,		//未知类型
        E_SEARCH_BREAK_REGION_TYPE_IN,				//闯入
        E_SEARCH_BREAK_REGION_TYPE_OUT,				//闯出
        E_SEARCH_BREAK_REGION_TYPE_DOUBLE,			//双向
    }

    /// <summary>
    /// 智能分析检索越界线类型
    /// </summary>
    public enum E_VDA_SEARCH_PASS_LINE_TYPE
    {
        E_SEARCH_PASS_LINE_TYPE_NOUSE = 0,		//未知类型
        E_SEARCH_PASS_LINE_TYPE_SINGLE,			//单向
        E_SEARCH_PASS_LINE_TYPE_DOUBLE,			//双向
    }

    /// <summary>
    /// 智能分析检索对象类型
    /// </summary>
    public enum E_VDA_SEARCH_OBJ_TYPE
    {
        E_SEARCH_OBJECT_TYPE_NOUSE = 0,			//无效类型
        E_SEARCH_OBJECT_TYPE_CAR,				//车辆
        E_SEARCH_OBJECT_TYPE_PEOPLE,			//人脸	
        E_SEARCH_OBJECT_TYPE_UNKNOW_MOVE_OBJ,	//未知运动物
        E_SEARCH_OBJECT_TYPE_FACE,				//人脸
    }

    /// <summary>
    /// 检索结果排序类型
    /// </summary>
    public enum E_VDA_SEARCH_SORT_TYPE
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        E_SEARCH_SORT_TYPE_NOUSE = 0,
        /// <summary>
        /// 相似度排序
        /// </summary>
        E_SEARCH_SORT_TYPE_SIMILAR,
        /// <summary>
        /// 时间升序
        /// </summary>
        E_SEARCH_SORT_TYPE_TIME_ASC,
        /// <summary>
        /// 时间降序
        /// </summary>
        E_SEARCH_SORT_TYPE_TIME_DESC,
    }

    /// <summary>
    /// 检索条件对象过滤类型
    /// </summary>
    public enum E_VDA_SEARCH_MOVE_OBJ_RANGE_FILTER_TYPE
    {
        E_SEARCH_MOVE_OBJ_RANGE_FILTER_NOUSE = 0,				//无效类型
        E_SEARCH_MOVE_OBJ_RANGE_FILTER_PASS_LINE,				//越界线过滤
        E_SEARCH_MOVE_OBJ_RANGE_FILTER_BREAK_REGION,			//闯入闯出区域过滤
    }
    /// <summary>
    /// 检索条件以图搜图算法过滤类型
    /// </summary>
    public enum E_VDA_SEARCH_IMAGE_FILTER_TYPE
    {
        /// <summary>
        /// 无效类型
        /// <summary>
        E_SEARCH_IMAGE_FILTER_NOUSE = 0,
        /// <summary>
        /// 按颜色算法特征过滤
        /// <summary>
        E_SEARCH_IMAGE_FILTER_BLOB,
        /// <summary>
        /// 按纹理算法特征过滤	
        /// <summary>
        E_SEARCH_IMAGE_FILTER_SURF,
        /// <summary>
        /// 按人脸算法特征过滤
        /// <summary>
        E_SEARCH_IMAGE_FILTER_FACE
    };

    /// <summary>
    /// 检索条件对象过滤类型
    /// <summary>
    public enum E_VDA_SEARCH_MOVE_OBJ_FILTER_TYPE
    {
        /// <summary>
        /// 无效类型
        /// <summary>
        E_SEARCH_MOVE_OBJ_FILTER_NOUSE = 0,
        /// <summary>
        /// 按全部运动物目标过滤
        /// <summary>
        E_SEARCH_MOVE_OBJ_FILTER_ALL_MOVE_OBJ,
        /// <summary>
        /// 按车过滤
        /// <summary>
        E_SEARCH_MOVE_OBJ_FILTER_CAR,
        /// <summary>
        /// 按人过滤	
        /// <summary>
        E_SEARCH_MOVE_OBJ_FILTER_PEOPLE
    };


    //网络实时视频码流类型 
    public enum E_VDA_NET_STREAM_TYPE_TYPE
    {
        E_DEV_STREAM_TYPE_MAIN = 0,//主码流 
        E_DEV_STREAM_TYPE_SUB, //子码流 
    };



    public enum E_PDO_MOUSE_EVENT
    {
        E_PDO_MOUSE_UNKNOW = 0,		//鼠标无效操作
        E_PDO_MOUSE_LCLICK = 1,		//鼠标左键单击
        E_PDO_MOUSE_LDCLICK = 2,	//鼠标左键双击
        E_PDO_MOUSE_RCLICK = 3,		//鼠标右键单击
        E_PDO_MOUSE_RDCLICK = 4,	//鼠标右键双击
    };

    // 图片文件格式
    public enum E_PDO_PIC_TYPE
    {
        E_PDO_PIC_UNKNOWN = 0, //不确定
        E_PDO_PIC_JPG = 1,	//Jpg格式
        E_PDO_PIC_BMP = 2,	//bmp格式,暂不支持
    };

    //叠加画图类型
    public enum E_PDO_DRAW_TYPE
    {
        E_PDO_DRAW_NONE = 0,		//不画任何内容
        E_PDO_DRAW_RECT = 1,		//画矩形
        E_PDO_DRAW_PASS_LINE,		//越界线过滤
        E_PDO_DRAW_BREAK_REGION,			//闯入闯出区域过滤
    };

    // 配置通知类型定义
    public enum E_VDA_RESOURCE_OPERATE_TYPE
    {
        E_RESOURCE_OPERATE_TYPE_NOUSE = 0,//未知类型
        E_RESOURCE_OPERATE_TYPE_ADD,	 //增加资源(服务器、相机、任务单元等)
        E_RESOURCE_OPERATE_TYPE_DEL,	 //删除资源(服务器、相机、任务单元等)
        E_RESOURCE_OPERATE_TYPE_MDF,	 //修改资源(服务器、相机、任务单元等)
    };
    //资源类型
    public enum E_VDA_RESOURCE_TYPE
    {
        E_RESOURCE_TYPE_NOUSE = 0,//无效类型
        E_RESOURCE_TYPE_SERVER,		//服务器
        E_RESOURCE_TYPE_NET_STORE,	//网络设备	
        E_RESOURCE_TYPE_CAMERA_GROUP,//相机组
        E_RESOURCE_TYPE_CAMERA,		//相机
        E_RESOURCE_TYPE_USER_GROUP,	//用户组
        E_RESOURCE_TYPE_USER,		//用户
        E_RESOURCE_TYPE_CASE,		//案件
        E_RESOURCE_TYPE_TASK,		//任务
        E_RESOURCE_TYPE_TASKUNIT,	//任务单元
        E_RESOURCE_TYPE_REAL_ANALYSIS_PLAN //实时分析计划
    };

    //////////////////////////////////////////////////////////////////////////
    //						日志枚举类型									//
    //////////////////////////////////////////////////////////////////////////
    //日志类型
    public enum E_VDA_LOG_TYPE
    {
        E_LOG_TYPE_NOUSE = 0,		//无效类型
        E_LOG_TYPE_SYSTEM,				//系统日志
        E_LOG_TYPE_OPERATE,				//操作日志
        E_LOG_TYPE_MANAGER,				//管理日志	
    };
    //日志级别
    public enum E_VDA_LOG_LEVEL
    {
        E_LOG_LEVEL_NOUSE = 0,		//无效类型
        E_LOG_LEVEL_COMMON,				//普通级别
        E_LOG_LEVEL_WARN,				//警告级别
        E_LOG_LEVEL_ERROR,				//错误级别	
    };

    //日志排序方式
    public enum E_VDA_LOG_SORT_TYPE
    {
        E_LOG_SORT_TYPE_NOUSE = 0,    //无效类型
        E_LOG_SORT_TYPE_TIME_ASC,		//按时间升序
        E_LOG_SORT_TYPE_TIME_DESC,		//按时间降序
    };

    //日志操作者类型
    public enum E_LOG_OPERATE_TYPE
    {
        E_LOG_OPERATE_TYPE_INVALID = 0,     //默认无效值
        E_LOG_OPERATE_TYPE_USER,			//用户
        E_LOG_OPERATE_TYPE_VDM,				//管理服务器
        E_LOG_OPERATE_TYPE_MSS,				//媒体存储服务器
        E_LOG_OPERATE_TYPE_IAS,				//智能分析服务器
        E_LOG_OPERATE_TYPE_SMS,				//检索比对服务器
        E_LOG_OPERATE_TYPE_SSS,				//结构化检索服务器
        E_LOG_OPERATE_TYPE_MSW,				//媒体接入网关服务器
        E_LOG_OPERATE_TYPE_UGW,				//用户接入网关服务器
        E_LOG_OPERATE_TYPE_PAS,				//预分析服务器服务器
        E_LOG_OPERATE_TYPE_IDS,				//分析调度服务器
        E_LOG_OPERATE_TYPE_SMDS,			//非结构化检索调度服务器
        E_LOG_OPERATE_TYPE_SSDS,			//结构化检索调度服务器	

    };

    //日志细分
    public enum E_VDA_LOG_DETAIL
    {
        E_LOG_DETAIL_NOUSE = 0,		  //无效类型
        E_LOG_DETAIL_TASK_MANAGE,		  //任务管理
        E_LOG_DETAIL_USER_LOGIN,		  //用户登录
        E_LOG_DETAIL_USER_LOGOUT,		  //用户登出
        E_LOG_DETAIL_START_SERACH,		  //开始检索
        E_LOG_DETAIL_STOP_SERACH,		  //停止检索
        E_LOG_DETAIL_START_PLAYBACK,	  //开始点播
        E_LOG_DETAIL_CLOSE_PLAYBACK,	  //关闭点播
        E_LOG_DETAIL_START_BRIEF_VOD,	  //开始摘要点播
        E_LOG_DETAIL_CLOSE_BRIEF_VOD,	  //关闭摘要点播
        E_LOG_DETAIL_ENTER_CASE,		  //进入案件
        E_LOG_DETAIL_LEAVE_CASE,		  //离开案件
        E_LOG_DETAIL_CAMERA_MANAGE,		  //相机管理
        E_LOG_DETAIL_CAMERA_GROUP_MANAGE, //相机组管理
        E_LOG_DETAIL_CASE_MANAGE,		  //案件管理
        E_LOG_DETAIL_NET_STORE_MANAGE,	  //网络设备管理
        E_LOG_DETAIL_USER_MANAGE,		  //用户管理
        E_LOG_DETAIL_USER_GROUP_MANAGE,	  //用户组管理
        E_LOG_DETAIL_SERVER_MANAGE,		  //服务器管理
        E_LOG_DETAIL_TASKUNIT_STATUS,	  //任务单元状态
        E_LOG_DETAIL_BRIEF_VOD_STATUS,	  //摘要点播状态
        E_LOG_DETAIL_PLAYBACK_STATUS,	  //视频点播状态
        E_LOG_DETAIL_IAS_STATUS,		  //智能检索状态
        E_LOG_DETAIL_SERVER_STATUS,		  //服务器状态
        E_LOG_DETAIL_EXPORT_STATUS,		  //导出状态
    }


    //public enum E_VDA_ACCESS_PTOTOCOL_TYPE
    //{
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_NOUSE = 0,		// 其他协议类型
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_RTSP_CLIENT,		// rtsp协议客户端接入库
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_TCPIP_CLIENT,		// tcpip
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_NETPOSA,				// 东方网力SDK接入
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_HK,					// 海康SDK接入
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_DH,				// 大华网力SDK接入
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_SANYO_IPC,			// 三洋IPC
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_BOCOM,				// VIS系统
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_BKSP,				// 博康系统平台
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_ONVIF,				// OnVif协议接入
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_GB28181,				// GB28181协议接入
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_SNMP,                //snmp协议
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_H3C,				//华三sdk
    //    E_VDA_ACCESS_PTOTOCOL_TYPE_HKPLAT = 1024            //海康平台
    //};


    //网络存储设备接入协议类型
    public enum E_VDA_NET_STORE_DEV_PROTOCOL_TYPE
    {
        E_DEV_PROTOCOL_CONTYPE_NONE = -1,//OnVif协议接入

        E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL = 0,//OnVif协议接入
        E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL,  //GB28181协议接入

        E_DEV_PROTOCOL_CONTYPE_BCSYS_PLAT = 32,	  //博康系统
        E_DEV_PROTOCOL_CONTYPE_H3C_PLAT,		  //华三平台
        E_DEV_PROTOCOL_CONTYPE_HK_PLAT,			  //海康平台
        E_DEV_PROTOCOL_CONTYPE_NETPOSA_PLAT,	  //东方网力平台
        E_DEV_PROTOCOL_CONTYPE_IMOS_PLAT, //宇视平台 
        E_DEV_PROTOCOL_CONTYPE_DHPLAT_DEV, //大华平台接入 
        E_DEV_PROTOCOL_CONTYPE_ISOC_PLAT, //索贝平台 
        E_DEV_PROTOCOL_CONTYPE_VISS_PLAT,
        E_DEV_PROTOCOL_CONTYPE_WB_PLAT, //对接机场 

        E_DEV_PROTOCOL_CONTYPE_HK_DEV = 1024,	  //海康设备接入
        E_DEV_PROTOCOL_CONTYPE_DH_DEV,			  //大华设备接入
        E_DEV_PROTOCOL_CONTYPE_SANYO_IPC_DEV,	  //三洋IPC
        E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE = 2048,	  //服务端共享视频
        E_DEV_PROTOCOL_CONTYPE_HTTP_FILE = 2049,	  //http视频
        E_DEV_PROTOCOL_CONTYPE_FTP_FILE = 2050,	  //ftp视频


    };




    public enum E_TRANS_PROTOCOL_TYPE
    {
        E_TRANS_PROTOCOL_NONE = 0,
        E_TRANS_PROTOCOL_TCP=1,
        E_TRANS_PROTOCOL_WEBSERVICE,
    }
    public enum E_TRANCE_STORE_TYPE
    {
        E_TRANCE_STORE_NOUSE = 0,
        E_TRANCE_STORE_LOCAL = 1,
        E_TRANCE_STORE_SHARE,
    }
    //实时分析计划状态
    public enum E_VDA_REAL_ANALYSIS_PLAN_STATUS
    {
        E_REAL_ANALYSIS_PLAN_STOP = 0,		//停用中
        E_REAL_ANALYSIS_PLAN_STARTING = 1,		//启用中
        E_REAL_ANALYSIS_PLAN_EXECUTING = 2,		//分析中
        E_REAL_ANALYSIS_PLAN_FAILED = 3,		//分析失败
    };
    public enum E_VDA_SEARCH_STATUS
    {
        E_VDA_SEARCH_STATUS_ERROR = 0,//0 失败
        E_VDA_SEARCH_STATUS_RUNING = 1,//1 检索中
        E_VDA_SEARCH_STATUS_FINISH = 2,//2 检索完成
        E_VDA_SEARCH_STATUS_ERROR_STARTFAILED = 3,// 启动检索失败
        E_VDA_SEARCH_STATUS_ERROR_NOSUCHITEM = 4,// 无此视频
    }

    [Flags]
    public enum E_SEARCH_FEATURE_TYPE
    {
        E_SEARCH_FEATURE_TYPE_NOUSE = 0,	//无效类型	
        E_SEARCH_FEATURE_TYPE_STRUCTURED = 1,//结构化特征
        E_SEARCH_FEATURE_TYPE_PASSLINE = 2,//越界闯入闯出
        E_SEARCH_FEATURE_TYPE_GLOBAL = 4,//全局特征
        E_SEARCH_FEATURE_TYPE_PARTICAL = 8,//局部特征
    }

    [Flags]
    public enum E_SEARCH_OBJ_FILTER_TYPE
    {
        E_SEARCH_OBJ_FILTER_TYPE_NOUSE=0,
        E_SEARCH_OBJ_FILTER_TYPE_VEHICLE = 1,//机动车
        E_SEARCH_OBJ_FILTER_TYPE_PASSAGER = 2,//人
        E_SEARCH_OBJ_FILTER_TYPE_TWOWHEEL = 4,//两轮车
        E_SEARCH_OBJ_FILTER_TYPE_OTHER = 8,//其他
    }

    //运动目标颜色
    public enum E_MOVEOBJ_COLOR
    {
        E_MOVEOBJ_COLOR_NOUSE = 0,	//无
        E_MOVEOBJ_COLOR_ONBIKE,		//红
        E_MOVEOBJ_COLOR_BLACK,		//黑
        E_MOVEOBJ_COLOR_WHITE,		//白
        E_MOVEOBJ_COLOR_GRAY,		//灰色
        E_MOVEOBJ_COLOR_RED,		//红
        E_MOVEOBJ_COLOR_YELLOW,	//黄
        E_MOVEOBJ_COLOR_BLUE,		//蓝
        E_MOVEOBJ_COLOR_ORANGE,	//橘黄
        E_MOVEOBJ_COLOR_BROWN,	//棕
        E_MOVEOBJ_COLOR_GREEN,		//绿
        E_MOVEOBJ_COLOR_MLITICOLOR=49,		//花
        E_MOVEOBJ_COLOR_OTHER=50,		//其它
    };

public enum E_MOVE_OBJ_PEOPLE_BAG_TYPE
{
	E_MOVE_OBJ_PEOPLE_BEG_TYPE_NO = 0,					//无背包
	E_MOVE_OBJ_PEOPLE_BEG_TYPE_KITBAG,					//背包
	E_MOVE_OBJ_PEOPLE_BEG_TYPE_HANDBAG,					//拎包
	E_MOVE_OBJ_PEOPLE_BEG_TYPE_SATCHEL,					//挎包
	E_MOVE_OBJ_PEOPLE_BEG_TYPE_UNKNOWN = 1000,			//未知
	E_MOVE_OBJ_PEOPLE_BEG_TYPE_NOUSE = int.MaxValue,			
};

//行人帽子类型枚举值
public enum E_MOVE_OBJ_PEOPLE_HAT_TYPE
{
	E_MOVE_OBJ_PEOPLE_HAT_TYPE_NO = 0,					//不戴帽子
	E_MOVE_OBJ_PEOPLE_HAT_TYPE_YES,						//戴帽子
	E_MOVE_OBJ_PEOPLE_HAT_TYPE_UNKNOWN = 1000,			//未知
};

//行人头发类型枚举值
public enum E_MOVE_OBJ_PEOPLE_HAIR_TYPE
{
	E_MOVE_OBJ_PEOPLE_HAIR_TYPE_SHORT = 0,				//短发
	E_MOVE_OBJ_PEOPLE_HAIR_TYPE_LONG,					//长发
	E_MOVE_OBJ_PEOPLE_HAIR_TYPE_UNKNOWN = 1000,			//未知
};

//行人性别类型枚举值
public enum E_MOVE_OBJ_PEOPLE_GENDER_TYPE
{
    E_MOVE_OBJ_PEOPLE_GENDER_TYPE_MALE = 0,				//男性
    E_MOVE_OBJ_PEOPLE_GENDER_TYPE_FEMALE,				//女性
    E_MOVE_OBJ_PEOPLE_GENDER_TYPE_ALL,				//
    E_MOVE_OBJ_PEOPLE_GENDER_TYPE_UNKNOWN = 1000,		//未知
};

//行人年龄类型枚举值
public enum E_MOVE_OBJ_PEOPLE_AGE_TYPE
{
    E_MOVE_OBJ_PEOPLE_AGE_TYPE_MIDLIFE = 0,				//中年
    E_MOVE_OBJ_PEOPLE_AGE_TYPE_AGEDNESS,				//老年
    E_MOVE_OBJ_PEOPLE_AGE_TYPE_INFANCY,					//幼年
    E_MOVE_OBJ_PEOPLE_AGE_TYPE_ALL,					//
    E_MOVE_OBJ_PEOPLE_AGE_TYPE_UNKNOWN = 1000,			//未知
};

    public enum E_SEARCH_RESULT_OBJECT_TYPE
    {
        E_SEARCH_RESULT_OBJECT_TYPE_NOUSE = 0,//未知
        E_SEARCH_RESULT_OBJECT_TYPE_VEHICLE,//机动车
        E_SEARCH_RESULT_OBJECT_TYPE_PASSAGER,//行人
        E_SEARCH_RESULT_OBJECT_TYPE_TWOWHEEL,//二轮车
    }

    public enum E_DRIVER_FEATURE_TYPE
    {
        E_DRIVER_FEATURE_TYPE_NOUSE = 0,//未知
        E_DRIVER_FEATURE_TYPE_HAVE,//有
        E_DRIVER_FEATURE_TYPE_NOTHAVE,//没有
    }

    /// <summary>
    /// 车牌检索车型类型
    /// </summary>
    public enum E_VDA_SEARCH_VEHICLE_TYPE
    {
        // 1:不限；
        E_SEARCH_VEHICLE_TYPE_NOUSE = 0,
        // 1:小车；
        E_SEARCH_VEHICLE_TYPE_LARGE_BUS,
        // 2:中车；
        E_SEARCH_VEHICLE_TYPE_LARGE_TRUCTK,
        // 3:大车；
        E_SEARCH_VEHICLE_TYPE_MIDDLE_BUS,
        // 4:其它车型
        E_SEARCH_VEHICLE_TYPE_SMALL_BUS,
        // 小型货车
        E_SEARCH_VEHICLE_TYPE_SMALL_TRUCK,
    }


    /// <summary>
    /// 车牌检索车型细分
    /// </summary>
    public enum E_VDA_SEARCH_VEHICLE_DETAIL_TYPE
    {
        E_SEARCH_VEHICLE_DETAIL_TYPE_NOUSE = 0,//	未知
        E_SEARCH_VEHICLE_DETAIL_TYPE_101 = 101,//大型客车的其他子类型
        E_SEARCH_VEHICLE_DETAIL_TYPE_201 = 201,//集装箱货车
        E_SEARCH_VEHICLE_DETAIL_TYPE_202 = 202,//油罐车
        E_SEARCH_VEHICLE_DETAIL_TYPE_203 = 203,//卡车
        E_SEARCH_VEHICLE_DETAIL_TYPE_204 = 204,//吊车
        E_SEARCH_VEHICLE_DETAIL_TYPE_205 = 205,//拖车
        E_SEARCH_VEHICLE_DETAIL_TYPE_206 = 206,//水泥车
        E_SEARCH_VEHICLE_DETAIL_TYPE_207 = 207,//大型货车的其他子类型
        E_SEARCH_VEHICLE_DETAIL_TYPE_301 = 301,//面包车
        E_SEARCH_VEHICLE_DETAIL_TYPE_302 = 302,//MPV
        E_SEARCH_VEHICLE_DETAIL_TYPE_303 = 303,//中型客车的其他子类型
        E_SEARCH_VEHICLE_DETAIL_TYPE_401 = 401,//SUV
        E_SEARCH_VEHICLE_DETAIL_TYPE_402 = 402,//小型客车的其他子类型
        E_SEARCH_VEHICLE_DETAIL_TYPE_501 = 501,//依维柯
        E_SEARCH_VEHICLE_DETAIL_TYPE_502 = 502,//皮卡
        E_SEARCH_VEHICLE_DETAIL_TYPE_503 = 503,//小型货车的其他子类型

    }

    /// <summary>
    /// 车牌检索车身颜色
    /// </summary>
    public enum E_VDA_SEARCH_VEHICLE_COLOR_TYPE
    {
        E_SEARCH_VEHICLE_COLOR_TYPE_NOUSE = 0,		//无效类型	
        E_SEARCH_VEHICLE_COLOR_TYPE_WHITE = 1,		//白色
        E_SEARCH_VEHICLE_COLOR_TYPE_SILVER = 2,			//银色
        E_SEARCH_VEHICLE_COLOR_TYPE_BLACK = 3,		//黑色
        E_SEARCH_VEHICLE_COLOR_TYPE_RED = 4,			//红色
        E_SEARCH_VEHICLE_COLOR_TYPE_PURPLE = 5,			//紫色
        E_SEARCH_VEHICLE_COLOR_TYPE_BLUE = 6,		//蓝色
        E_SEARCH_VEHICLE_COLOR_TYPE_YELLOW = 7,			//黄色
        E_SEARCH_VEHICLE_COLOR_TYPE_GREEN = 8,		//绿色
        E_SEARCH_VEHICLE_COLOR_TYPE_BROWN = 9,		//褐色
        E_SEARCH_VEHICLE_COLOR_TYPE_PINK = 10,		//粉红色
        E_SEARCH_VEHICLE_COLOR_TYPE_GRAY = 11,		//灰色
        E_SEARCH_VEHICLE_COLOR_TYPE_OTHER = 12		//其它颜色
    }


    /// <summary>
    /// 车牌检索车牌颜色
    /// </summary>
    public enum E_VDA_SEARCH_VEHICLE_PLATE_COLOR_TYPE
    {
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_NOUSE = 0,		//无效类型	
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_BLUE = 1,		//蓝色
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_BLACK = 2,		//黑色
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_YELLOW = 3,		//黄色
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_WHITE = 4,		//白色	
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_GREEN = 4,		//绿色	
        E_SEARCH_VEHICLE_PLATE_COLOR_TYPE_OTHER = 5,		//其他
    }


    /// <summary>
    /// 车牌检索车牌结构
    /// </summary>
    public enum E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE
    {
        E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_NOUSE = 0,		//无效类型	
        E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_SINGLE = 1,		//其他
        E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_DOUBLE = 2,		//其他
        E_SEARCH_VEHICLE_PLATE_STRUCT_TYPE_OTHER = 3,		//其他
    }

    public enum E_TRAFFIC_EVENT_TYPE
    {
        E_TRAFFIC_EVENT_TYPE_None = 0,//未知 = 0,
        E_TRAFFIC_EVENT_TYPE_NoReverse,//逆行,
        E_TRAFFIC_EVENT_TYPE_Jam,//阻塞,
        E_TRAFFIC_EVENT_TYPE_PassagerCross,//行人横穿,
        E_TRAFFIC_EVENT_TYPE_CarCross,//车辆横穿,
        E_TRAFFIC_EVENT_TYPE_CarFast,//车辆超速,
        E_TRAFFIC_EVENT_TYPE_CarLow,//车辆低速,
        E_TRAFFIC_EVENT_TYPE_CarStop,//车辆停泊,
        E_TRAFFIC_EVENT_TYPE_ON_MOTORWAY, //机占非 
        E_TRAFFIC_EVENT_TYPE_NO_PASSING, //禁行 
        E_TRAFFIC_EVENT_TYPE_NO_TURNAROUND, //禁止调头 
        E_TRAFFIC_EVENT_TYPE_NO_LEFT, //禁止左转 
        E_TRAFFIC_EVENT_TYPE_NO_RIGHT, //禁止右转 
        E_TRAFFIC_EVENT_TYPE_NO_STRAIGHT, //禁止直行 
        E_TRAFFIC_EVENT_TYPE_PRESS_LINE, //压线 
        E_TRAFFIC_EVENT_TYPE_ON_BUSWAY, //占用公交车道
    }
    /// <summary>
    /// 车牌行驶方向
    /// </summary>
    public enum E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE
    {
        E_DRIVE_DIRECTION_TYPE_NOUSE = 0,
        E_DRIVE_DIRECTION_TYPE_W = 1,//	由东向西
        E_DRIVE_DIRECTION_TYPE_E = 2,//	由西向东	
        E_DRIVE_DIRECTION_TYPE_N = 3,//	由南向北
        E_DRIVE_DIRECTION_TYPE_S = 4,//	由北向南
        E_DRIVE_DIRECTION_TYPE_NW = 5,//	由东南向西北
        E_DRIVE_DIRECTION_TYPE_SE = 6,//	由西北向东南
        E_DRIVE_DIRECTION_TYPE_SW = 7,//	由东北向西南
        E_DRIVE_DIRECTION_TYPE_NE = 8,//	由西南向东北
        E_DRIVE_DIRECTION_TYPE_Other = 9,//	其他	
    }

	//开始时间 结束时间 检测
	public enum CheckTime
	{
		OK = 0,
		START_INVALID = 1,
		END_INVALID = 2,
	}

    //热力图统计 时间类型
    public enum CrowdTimeType
    {
        MONTH = 1,
        DAY = 2,
        HOUR = 3,
    }
    //热力图统计 时间类型
    public enum TrafficTimeType
    {
        MONTH = 1,
        DAY = 2,
        HOUR = 3,
    }
    public enum E_TASK_GET_SORT_TYPE
    {
        E_TASK_GET_SORT_TYPE_NOUSE = 0,    //无效类型
        E_TASK_GET_SORT_TYPE_TIME_ASC,		//按时间升序
        E_TASK_GET_SORT_TYPE_TIME_DESC,		//按时间降序
    };


    public enum E_TASK_ACTION_TYPE
    {
        E_TASK_ACTION_TYPE_NONE,
        E_TASK_ACTION_TYPE_INFO,
        E_TASK_ACTION_TYPE_DELETE,
        E_TASK_ACTION_TYPE_SUNPEND,
        E_TASK_ACTION_TYPE_CONTINUE,
        E_TASK_ACTION_TYPE_PLAYBACK,
        E_TASK_ACTION_TYPE_PEOPLE_SEARCH,
        E_TASK_ACTION_TYPE_VEHICLE_SEARCH,
        E_TASK_ACTION_TYPE_CROWD,
        E_TASK_ACTION_TYPE_BRIEF,
        E_TASK_ACTION_TYPE_TRAFFIC_EVENT,
        E_TASK_ACTION_TYPE_TRAFFIC_EVENT_SEARCH,
        E_TASK_ACTION_TYPE_DYNMIC_VEHICLE_SEARCH,
        E_TASK_ACTION_TYPE_DYNMIC_FACE_CONTROL,
        E_TASK_ACTION_TYPE_DYNMIC_FACE_ALARM,
    }

    public enum E_PEOPLE_NATION
    {
        汉族 = 1,
        回族 = 2,
        壮族 = 3,
        满族 = 4,
        维吾尔族 = 5,
        苗族 = 6,
        彝族 = 7,
        土家族 = 8,
        藏族 = 9,
        蒙古族 = 10,
        侗族 = 11,
        布依族 = 12,
        瑶族 = 13,
        白族 = 14,
        朝鲜族 = 15,
        哈尼族 = 16,
        黎族 = 17,
        哈萨克族 = 18,
        傣族 = 19,
        畲族 = 20,
        傈僳族 = 21,
        东乡族 = 22,
        仡佬族 = 23,
        拉祜族 = 24,
        佤族 = 25,
        水族 = 26,
        纳西族 = 27,
        羌族 = 28,
        土族 = 29,
        仫佬族 = 30,
        锡伯族 = 31,
        柯尔克孜族 = 32,
        景颇族 = 33,
        达斡尔族 = 34,
        撒拉族 = 35,
        布朗族 = 36,
        毛南族 = 37,
        塔吉克族 = 38,
        普米族 = 39,
        阿昌族 = 40,
        怒族 = 41,
        鄂温克族 = 42,
        京族 = 43,
        基诺族 = 44,
        德昂族 = 45,
        保安族 = 46,
        俄罗斯族 = 47,
        裕固族 = 48,
        乌孜别克族 = 49,
        门巴族 = 50,
        鄂伦春族 = 51,
        独龙族 = 52,
        赫哲族 = 53,
        高山族 = 54,
        珞巴族 = 55,
        塔塔尔族 = 56,
        未知 = 1000,

    }

    public enum E_PEOPLE_BLOODTYPE
    {
        A = 1,//A型血
        B = 2,//B型血
        AB = 3,//AB型血
        O = 4,//O型血
        未知 = 5,//未知血型

    }

    public enum E_PEOPLE_SEX
    {
        男=1,//男
        女=2,//女
        未知=3,//未知性别

    }

	public enum E_PICTURE_STATE {
		STATE_NONE = 0, // 0	未知状态	该图片数据并未处理
		STATE_ISSSER_OK = 1, // 1 下发成功	该图片数据下发到存储服务器成功
		STATE_ISSSER_FAIL = 2, // 2 下发失败	该图片数据下发到存储服务器失败
		STATE_FEATUER_OK = 3, // 3	提特征成功	该图片数据提取特征成功
		STATE_FEATUER_FAIL = 4, // 4	提特征失败	该图片数据提取特征失败
		STATE_FT_DISPATCH_OK = 5, // 5	下发特征成功	该图片特征数据下发成功
		STATE_FT_DISPATCH_FAIL = 6, // 6	下发特征失败	该图片特征数据下发失败
		STATE_NEED_UPDATE = 7,// 7	更新状态	该图片数据需要重新下发，提取特征         
	}
    #endregion

    public class Common
    {
        #region 常量定义

        public readonly static int TASKUNIT_MAXIMUM_SEARCH = 10;

        public readonly static uint VOLUMESIZE_K = 1 << 10;
        public readonly static uint VOLUMESIZE_M = 1 << 20;
        public readonly static uint VOLUMESIZE_G = 1 << 30;

        public readonly static TimeSpan TIMERANGE_PLATFORMVIDEOSEARCH = new TimeSpan(1, 0, 0, 0);

        public const int DEFAULE_CASE_ID = 1;

        public const int VDA_MAX_IPADDR_LEN = 32;
        public const int VDA_MAX_MACADDR_LEN = 32;
        public const int VDA_MAX_NAME_LEN = 32;
        public const int VDA_MAX_CAMERA_NAME_LEN = 128;
        public const int VDA_MAX_PWD_LEN = VDA_MAX_NAME_LEN;
        public const int VDA_MAX_VERSION_LEN = 32;
        public const int VDA_MAX_CFGDATA_LEN = 256;
        public const int VDA_MAX_FILEPATH_LEN = 256;
        public const int VDA_MAX_URL_LEN = 512;
        public const int VDA_MAX_DESCRIPTION_INFO_LEN = 256;	//描述信息文本长度
        public const int VDASDK_MAX_ADDR_NAME_LEN = (2 * VDA_MAX_NAME_LEN);  //地址名称长度

        public const int VDA_MAX_TIME_LEN = 32;

        public const int MAXFILE_PERDIR = 64;

        public const int VDA_VIDEO_ANALYZE_TYPE_NUM = 4;	//视频算法分析类型数量
        public const int VDA_PIC_ANALYZE_TYPE_NUM = 2;	//图片算法分析类型数量

        public const int VDASDK_MAX_IPADDR_LEN = VDA_MAX_IPADDR_LEN;
        public const int VDASDK_MAX_MACADDR_LEN = VDA_MAX_MACADDR_LEN;

        public const int VDASDK_MAX_NAME_LEN = VDA_MAX_NAME_LEN;

        public const int VDASDK_MAX_NET_STORE_DEV_NAME = 128;

        public const int VDASDK_MAX_PWD_LEN = VDA_MAX_PWD_LEN;
        public const int VDASDK_MAX_FILEPATH_LEN = VDA_MAX_FILEPATH_LEN;
        public const int VDASDK_MAX_URL_LEN = VDA_MAX_URL_LEN;
        public const int VDASDK_MAX_DESCRIPTION_INFO_LEN = VDA_MAX_DESCRIPTION_INFO_LEN;

        public const int VDASDK_VIDEO_ANALYZE_TYPE_NUM = VDA_VIDEO_ANALYZE_TYPE_NUM;	//视频算法分析类型数量
        public const int VDASDK_PIC_ANALYZE_TYPE_NUM = VDA_PIC_ANALYZE_TYPE_NUM;	//图片算法分析类型数量
        public const int VDASDK_ANALYZE_TYPE_MAXNUM = VDASDK_VIDEO_ANALYZE_TYPE_NUM;	//最大分析类型数量

        public const int VDASDK_MAX_TASK_UNIT_NAME_LEN = 255;

        public const int VDA_PASSLINE_MAXNUM = 8;	                //越界线最大数量
        public const int VDA_ONE_BREAK_REGION_POINT_MAXNUM = 64;	        //单个区域边界点最大数量
        public const int VDA_BREAK_REGION_MAXNUM = 1;	            //闯入闯出区域最大数量


        public const int PDO_POINT_ARRAY_SIZE = 32;
        public const int PDO_DRAW_RECT_MAXNUM = 8;	//绘制矩形的最大数量
        public const int PDO_FILEPATH_MAXLEN = 256;


        public static readonly DateTime ZEROTIME = new DateTime(1970, 1, 1).ToLocalTime();
        public static readonly DateTime MAXTIME = new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(uint.MaxValue);

        public static readonly int APPERR_BVODS_BRIEF_OBJECT_NULL = 0x10000 + 1012;//没有摘要目标

        public const int MAX_PIC_DATA_LEN = 1 * 1024 * 1024;

        public static int MOVE_OBJECT_TIME_OFFSET = 0;
        public static int CAR_OBJECT_TIME_OFFSET = 5;
        public static int BRIEF_OBJECT_TIME_OFFSET = 10;


        public const int IASSDK_MAX_VERSION_LEN = 32;
        public const int IASSDK_MAX_IPADDR_LEN = 32;
        public const int IASSDK_MAX_NAME_LEN = 64;
        public const int IASSDK_MAX_PWD_LEN = 64;
        public const int IASSDK_MAX_NET_STORE_DEV_NAME = 128;
        public const int IASSDK_MAX_FILEPATH_LEN = 256;
        public const int IASSDK_MAX_URL_LEN = 512;
        public const int IASSDK_MAX_ANALYSIS_PRARM_LENGTH = 4096;
        public const int IASSDK_VIDEO_ANALYZE_TYPE_NUM = 10;	//视频算法分析类型数量
        public const int IASSDK_PIC_ANALYZE_TYPE_NUM = 2;	//图片算法分析类型数量
        /// <summary>
        /// ////
        /// </summary>
        public const int IASSDK_MAX_DESCRIPTION_LEN = 256;////


        public const int ADPSSDK_MAX_VERSION_LEN = 32;
        public const int ADPSSDK_MAX_IPADDR_LEN = 32;
        public const int ADPSSDK_MAX_NAME_LEN = 64;
        public const int ADPSSDK_MAX_PWD_LEN = 64;
        public const int ADPSSDK_MAX_FILEPATH_LEN = 256;
        public const int ADPSSDK_MAX_URL_LEN = 512;
        public const int ADPSSDK_MAX_NET_STORE_DEV_NAME = 128;
        public const int ADPSSDK_MAX_DESCRIPTION_LEN = 256;
        public const int ADPSSDK_MAX_TEMPLATE_LEN = 10240;

        public const int DIO_DEVICE_ID_LEN = 48;		//设备ID长度
        public const int DIO_NAME_LEN = 256;	//名字长度
        public const int DIO_IPADDR_LEN = 64;	//IP长度
        public const int DIO_DOMAIN_CODE_LEN = 48;	//域编码长度
        public const int DIO_CHANNEL_ID_LEN = 128;	//通道ID（也即相机ID）长度
        public const int DIO_REST_LEN = 128;	//保留信息长度
        public const int DIO_FILE_ID_LEN = 1000;	//文件标识长度


        public const int SDK_MAX_IPADDR_LEN = 32;//IP地址长度
        public const int SDK_MAX_NAME_LEN = 32;//用户名长度
        public const int SDK_MAX_PWD_LEN = 32;//密码长度
        public const int SDK_CAMCODE_LEN = 64;//相机编号长度
        public const int SDK_CAMCODE_NUM = 8; //相机数量
        public const int SDK_FILE_PATH_LEN = 512; //文件路径长度

        public const string VIRTUAL_CAMERA_ID = "virtualcamera_";

        #endregion

        public readonly static ColorName COLOR_TRANSPARENT = new ColorName(Color.Transparent, "不限");
        public readonly static ColorName COLOR_WHITE = new ColorName(Color.White, "白色");
        public readonly static ColorName COLOR_SILVER = new ColorName(Color.Silver, "银色");
        public readonly static ColorName COLOR_BLACK = new ColorName(Color.Black, "黑色");
        public readonly static ColorName COLOR_RED = new ColorName(Color.Red, "红色");
        public readonly static ColorName COLOR_PURPL = new ColorName(Color.Purple, "紫色");
        public readonly static ColorName COLOR_BLUE = new ColorName(Color.Blue, "蓝色");
        public readonly static ColorName COLOR_ORANGE = new ColorName(Color.Orange, "橘黄");
        public readonly static ColorName COLOR_YELLOW = new ColorName(Color.Yellow, "黄色");
        public readonly static ColorName COLOR_GREEN = new ColorName(Color.Green, "绿色");
        public readonly static ColorName COLOR_BROWN = new ColorName(Color.Brown, "褐色");
        public readonly static ColorName COLOR_PINK = new ColorName(Color.Pink, "粉色");
        public readonly static ColorName COLOR_GRAY = new ColorName(Color.Gray, "灰色");

        public readonly static ColorName[] COLORNAMES_CLOTHES = new ColorName[]{
           COLOR_TRANSPARENT,
           COLOR_WHITE,
           COLOR_SILVER,
           COLOR_BLACK,
           COLOR_RED,    
           COLOR_PURPL,
           COLOR_BLUE,  
           COLOR_YELLOW,
           COLOR_GREEN,
           COLOR_BROWN,
           COLOR_PINK ,  
           COLOR_GRAY
        };

        public readonly static ColorName[] COLORNAMES_VEHICLEBODY = new ColorName[]{
           COLOR_TRANSPARENT,
           COLOR_WHITE,
           COLOR_SILVER,
           COLOR_BLACK,
           COLOR_RED,    
           COLOR_PURPL,
           COLOR_BLUE,  
           COLOR_YELLOW,
           COLOR_GREEN,
           COLOR_BROWN,
           COLOR_PINK ,  
           COLOR_GRAY
        };

        public readonly static ColorName[] COLORNAMES_VEHICLEPLATE = new ColorName[]{
           COLOR_TRANSPARENT,
           COLOR_BLUE,  
           COLOR_YELLOW,
           COLOR_WHITE,
           COLOR_BLACK,
        };

        public static Image Overlay(Image src, Rectangle rect1, Rectangle rect2 = new Rectangle(), Rectangle rect3 = new Rectangle())
        {
            Image temp = new Bitmap(src);
            Graphics gs = Graphics.FromImage(temp);
            gs.DrawRectangle(new Pen(Color.Red, 3), rect1);
            if (rect2 != new Rectangle())
                gs.DrawRectangle(new Pen(Color.Yellow, 2), rect2);
            if (rect3 != new Rectangle())
                gs.DrawRectangle(new Pen(Color.Blue, 2), rect3);
            gs.Dispose();
            return temp;
        }

        public static Image GetImage(IntPtr startAddress, int byteSize)
        {
            Image img = null;
            byte[] bytes = new byte[byteSize];
            IntPtr ptr = startAddress;

            try
            {
                Marshal.Copy(ptr, bytes, 0, byteSize);

                MemoryStream ms = new MemoryStream(bytes);
                Image imgTmp = Image.FromStream(ms);
                // 新创建一张Image， 从imgTmp构造， 因为用工具.NETMemoryProfiler 看到有时 bytes不能被回收
                img = new Bitmap(imgTmp);
                img.Save(Path.GetTempPath()+ "a.jpg");
                imgTmp.Dispose();
                ms.Dispose();
            }
            catch (Exception aex)
            {
                MyLog4Net.Container.Instance.Log.Error("Create image failed", aex);
                Debug.Assert(false, "Image.FromStream failed");
                img = null;
            }
            return img;
        }

        public static Image GetImage(byte[] startAddress, int index, int byteSize)
        {
            Image img = null;
            byte[] bytes = new byte[byteSize];
            Array.Copy(startAddress, index, bytes, 0, byteSize);
            try
            {
                MemoryStream ms = new MemoryStream(bytes);
                Image imgTmp = Image.FromStream(ms);
                // 新创建一张Image， 从imgTmp构造， 因为用工具.NETMemoryProfiler 看到有时 bytes不能被回收
                img = new Bitmap(imgTmp);
                img.Save(Path.GetTempPath() + "a.jpg");
                imgTmp.Dispose();
                ms.Dispose();
            }
            catch (Exception aex)
            {
                Debug.Assert(false, "Image.FromStream failed");
                img = null;
            }
            return img;
        }
        public static Image GetImage(byte[] startAddress, int byteSize)
        {
            return GetImage(startAddress, 0, byteSize);
        }

        public static Image GetImage( string url)
        {
            if (string.IsNullOrEmpty(url))
                return new Bitmap(1, 1);
            try
            {
                //url = @"http://oa.bocom.cn/__482572130046DFD0.nsf/GWNLoginForm/$FILE/logo.png";
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webres = webreq.GetResponse();
                System.Drawing.Image img = System.Drawing.Image.FromStream(webres.GetResponseStream());
                return img;
            }
            catch(Exception ex)
            {
                MyLog4Net.Container.Instance.Log.Error("error url :" + url+", ex:"+ex.ToString());
                return new Bitmap(1, 1);
            }
        }

        public static DateTime ConvertLinuxTime(uint linuxtime)
        {
            DateTime retTime = Common.ZEROTIME.AddSeconds(linuxtime);
            if (retTime < Common.ZEROTIME.AddYears(1))
                return new DateTime().AddSeconds(linuxtime);
            else
                return retTime;
        }

        public static UInt32 ConvertLinuxTime(DateTime dnettime)
        {
            if (dnettime < Common.ZEROTIME)
                return (uint)(dnettime.Subtract(new DateTime()).TotalSeconds);
            else
            {
                if (dnettime > Common.MAXTIME)
                    return (uint)(Common.MAXTIME.Subtract(Common.ZEROTIME).TotalSeconds);
                else
                    return (uint)(dnettime.Subtract(Common.ZEROTIME).TotalSeconds);
            }
        }

		public static CheckTime CheckDataTime(DateTime startTime, DateTime endTime) 
		{
			CheckTime ret = CheckTime.OK;
			if (startTime < new DateTime(2000, 1, 1) || startTime > new DateTime(2100, 1, 1)) 
			{
				ret = CheckTime.START_INVALID;
			}
			if (endTime < new DateTime(2000, 1, 1) || endTime > new DateTime(2100, 1, 1))
			{
				ret = CheckTime.END_INVALID;
			}
			return ret;
		}


        public static byte[] ImageToJpegBytes(Image img)
        {
            byte[] bytes = null;

            ImageFormat format = img.RawFormat;

            using (MemoryStream ms = new MemoryStream())
            {
                //if(format.Equals(ImageFormat.Jpeg) ||
                //    format.Equals(ImageFormat.Bmp) ||
                //    format.Equals(ImageFormat.Gif) ||
                //    format.Equals(ImageFormat.Icon))
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    bytes = new byte[ms.Length];

                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(bytes, 0, bytes.Length);
                }
            }

            return bytes;
        }

        /// <summary>
        /// 换算成 K, M, G Byte
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetByteSizeInUnit(ulong size)
        {
            string sRet;

            //if (size >= Constant.VOLUMESIZE_G)
            //{
            //    sRet = string.Format("{0} GB", size >> 30);
            //}
            //else 
            if (size >= Constant.VOLUMESIZE_M)
            {
                sRet = string.Format("{0} MB", size >> 20);
            }
            else if (size >= Constant.VOLUMESIZE_K)
            {
                sRet = string.Format("{0} KB", size >> 10);
            }
            else
            {
                sRet = string.Format("{0} Byte", size);
            }

            return sRet;
        }

        public static bool IsPortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint item in ipEndPoints)
            {
                if(item.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }

        #region 获取XML的序列化和反序列化

        /// <summary>
        /// 对象进行序列化生成XML
        /// </summary>
        /// <typeparam name="T">需要序列化的对象类型</typeparam>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>序列化后的XML</returns>
        public static string SerilizeObject<T>(T obj)
        {
            if (obj == null)
            {
                return "";
            }

            string ret = "";

            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    ret = "";
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(T));

                    XmlWriterSettings s = new XmlWriterSettings();
                    s.Encoding = Encoding.UTF8;
                    s.OmitXmlDeclaration = true;
                    //s.NamespaceHandling = NamespaceHandling.OmitDuplicates;
                    //s.Indent = true;

                    using (XmlWriter binaryWriter = XmlWriter.Create(stream, s))
                    {
                        System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                        ns.Add("", "");
                        serializer.Serialize(binaryWriter, obj, ns);

                        binaryWriter.Flush();
                    }
                    ret = Encoding.UTF8.GetString(stream.ToArray());

                }
                catch (Exception ex)
                {
                    Console.WriteLine("SerilizeAnObject Exception: {0}", ex.Message);
                }
                finally
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
            return ret;
        }

        /// <summary>
        /// XML反序列化生成对象
        /// </summary>
        /// <typeparam name="T">反序列化生成对象类型</typeparam>
        /// <param name="xml">XML内容</param>
        /// <returns>反序列化生成对象</returns>
        public static T DeserilizeObject<T>(string xml)
        {
            Type type = typeof(T);
            T obj = default(T);
            if (string.IsNullOrEmpty(xml))
            {
                return obj;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(xml);
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Position = 0L;
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(type);
                    using (System.Xml.XmlReader reader = new XmlTextReader(stream))
                    {
                        obj = (T)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DeserilizeAnObject Exception: {0}", ex.Message);
                }
                finally
                {
                    stream.Close();
                    stream.Dispose();
                }
            }

            return obj;
        }
        #endregion

    }

    public class SDKConstant
    {
        public static readonly string VehicleTypeDetail = "VehicleTypeDetail";
        public static readonly string VehicleType = "VehicleType";
        public static readonly string VehicleLabelDetail = "VehicleLabelDetail";
        public static readonly string VehicleLabel = "VehicleLabel";
        public static readonly string VehicleColor = "VehicleColor";
        public static readonly string PlateNumRow = "PlateNumRow";
        public static readonly string PlateNo = "PlateNo";
        public static readonly string PlateColor = "PlateColor";
        public static readonly string PassengerIsSunVisor = "PassengerIsSunVisor";
        public static readonly string PassengerIsSafebelt = "PassengerIsSafebelt";
        public static readonly string DriverIsSunVisor = "DriverIsSunVisor";
        public static readonly string DriverIsSafebelt = "DriverIsSafebelt";
        public static readonly string DriverIsPhoneing = "DriverIsPhoneing";
        public static readonly string RegionSet = "RegionSet";
        public static readonly string PassLineSet = "PassLineSet";
        public static readonly string PictureData = "PictureData";
        public static readonly string ObjRect = "ObjRect";
        public static readonly string ObjFilterType = "ObjFilterType";
        public static readonly string ObjDetailRect = "ObjDetailRect";
        public static readonly string FeatureType = "FeatureType";
        public static readonly string UpBodyColor = "UpBodyColor";
        public static readonly string DownBodyColor = "DownBodyColor";
        public static readonly string BagType = "BagType";

        public static readonly string dwStartTimeS = "dwStartTimeS";

        public static readonly string dwEndTimeS = "dwEndTimeS";

        public static readonly string dwSearchObjType = "dwSearchObjType";

        public static readonly string bColorSearch = "bColorSearch";

        public static readonly string dwSearchObjRGB = "dwSearchObjRGB";

        public static readonly string dwColorSimilar = "dwColorSimilar";

        public static readonly string dwRangeFilterType = "dwRangeFilterType";

        public static readonly string ptSearchPassLineList = "ptSearchPassLineList";

        public static readonly string dwAlgorithmFilterType = "dwAlgorithmFilterType";

        public static readonly string CompareImage = "CompareImage";

        public static readonly string CompareImageRect = "CompareImageRect";
        /// <summary>
        /// 绊线数量
        /// </summary>
        public static readonly string dwPassLineNum = "dwPassLineNum";

        /// <summary>
        /// 闯入闯出区域, TVDASDK_SEARCH_BREAK_RE_SEARCH_BREAK_REGIONGION
        /// </summary>
        public static readonly string tSearchBreakRegion = "tSearchBreakRegion";

        public static readonly string dwVehicleDetailType = "dwVehicleDetailType";
        public static readonly string dwVehicleColor = "dwVehicleColor";
        public static readonly string dwVehicleLogo = "dwVehicleLogo";
        public static readonly string szVehiclePlateName = "szVehiclePlateName";
        public static readonly string dwVehiclePlateStruct = "dwVehiclePlateStruct";
        public static readonly string dwVehiclePlateColor = "dwVehiclePlateColor";

        //internal static TVDASDK_SEARCH_TARGET TVDASDK_SEARCH_TARGET_Empty =
        //    new TVDASDK_SEARCH_TARGET() { dwCameraID =0, dwTaskUnitID = 0};

        //internal static TVDASDK_SEARCH_RESULT_OBJ_INFO TVDASDK_SEARCH_RESULT_OBJ_INFO_Empty =
        //    new TVDASDK_SEARCH_RESULT_OBJ_INFO { };

        public static readonly string dwVehicleType = "dwVehicleType";

    }
}
