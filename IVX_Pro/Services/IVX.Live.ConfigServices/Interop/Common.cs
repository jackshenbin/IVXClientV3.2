using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IVX.Live.ConfigServices.Interop
{

    internal partial class IVXRealtimeSDKProtocol
    {
        #region 常量定义


#if DEBUG
        const string DLLPATH = @"librvod\iassdk.dll";
#else
        const string DLLPATH = @"librvod\iassdk.dll";
#endif

        #endregion
    }
    internal partial class IVXAdpsSDKProtocol
    {
        #region 常量定义


#if DEBUG
        const string DLLPATH = @"librvod\adpssdk.dll";
#else
        const string DLLPATH = @"librvod\adpssdk.dll";
#endif

        #endregion
    }
    internal partial class IVXDrawSDKProtocol
    {
        #region 常量定义


#if DEBUG
        const string DLLPATH = @"librvod\picoverlay_d.dll";
#else
        const string DLLPATH = @"librvod\picoverlay.dll";
#endif

        #endregion
    }
    internal partial class IVXDIOSDKProtocol
    {
        #region 常量定义

        //错误码（随着功能完善不断增加）
        public enum eDIOErrorCode
        {
            DIO_OK = 0,
        DIOERR_INIT_FAILED = 1,//初始化模块失败
        DIOERR_UNINIT_FAILED = 2,//反初始化模块失败
        DIOERR_NOT_INIT = 3,//未初始化
        DIOERR_IP_POINTER_NULL = 4,//IP指针为空
        DIOERR_IP_ADDRESS_INVALID = 5,//IP地址非法
        DIOERR_USER_POINTER_NULL = 6,//用户名指针为空
        DIOERR_USER_INVALID = 7,//用户名非法
        DIOERR_PWD_POINTER_NULL =8,//密码指针为空
        DIOERR_NEW_DEVICE_FAILED = 9,//new一个设备失败
        DIOERR_LOGIN_DEVICE_FAILED = 10, //登录设备失败
        DIOERR_LOGINID_OUTRANGE = 11, //登录ID超出范围
        DIOERR_INVALID_LOGINID = 12, //非法的登录ID
        DIOERR_LOGOUT_DEVICE_FAILED = 13, //登出设备失败
        DIOERR_QUERYCHNLST_FAILED = 14, //查询通道列表失败
        DIOERR_QUERY_NOT_END = 15, //未查询完
        DIOERR_NA_OPERATION = 16, //操作不支持
        DIOERR_INVALID_QUERYCHNLIST_HANDLE = 17, //非法的通道列表查询句柄
        DIOERR_QUERYSTRMFILE_FAILED = 18, //查询录像文件失败
        DIOERR_INVALID_QUERYSTRMFILE_HANDLE = 19, //非法的录像文件查询句柄
        DIOERR_INVALID_QUERYSTRMFILE_DATE = 20, //非法的查询时间段
        DIOERR_QUERYSTRMFILE_NO_FILE = 21, //没有找到录像文件
        DIOERR_QUERYSTRMFILE_GETNEXT_FAILED = 22, //查找下一个录像文件失败
        DIOERR_NOT_QUERYSTRMFILE = 23, //未查询录像文件
        DIOERR_CHANNEL_ID_POINTER_NULL = 24, //通道ID指针为空
        DIOERR_CHANNEL_ID_INVALID = 25, //通道ID非法
        DIOERR_SAVEFILENAME_POINTER_NULL = 26, //保存文件名指针为空
        DIOERR_SAVEFILENAME_INVALID = 27, //保存文件名非法
        DIOERR_NEW_CHANNEL_FAILED = 28, //new一个通道失败
        DIOERR_CHANNELID_OUTRANGE = 29, //通道id超出范围
        DIOERR_GET_RECORD_BY_TIME_FAILED = 30, //通过时间获取文件失败
        DIOERR_DOWNLOAD_FAILED = 31, //下载录像失败
        DIOERR_INVALID_STRMID = 32, //非法的码流ID
        DIOERR_STOP_DOWNLOAD_FAILED = 33, //停止下载录像失败
        DIOERR_GET_DOWNLOAD_PERCENT_FAILED = 34, //获取下载录像进度失败
        DIOERR_NOT_LOAD_PROC = 35, //未加载函数
        DIOERR_NOT_IMPLEMENT = 36, //未实现
        DIOERR_VERSION_BUFFER_POINTER_NULL = 37, //版本号缓冲区指针为空
        DIOERR_VERSION_BUFFER_LEN_NOT_ENOUGH = 38, //版本号缓冲区长度不足
        DIOERR_LOGINID_POINTER_NULL = 39, //登录ID的指针为空
        DIOERR_QUERYCHNLIST_HANDLE_POINTER_NULL = 40, //查询通道句柄的指针为空
        DIOERR_CHNINFO_POINTER_NULL = 41, //通道信息结构体的指针为空
        DIOERR_QUERYCHNLIST_OVERFLAG_POINTER_NULL = 42, //查询通道标志的指针为空
        DIOERR_CHNSTATUS_POINTER_NULL = 43, //通道状态结构体的指针为空
        DIOERR_RECORDFILE_QUERYCONDITION_POINTER_NULL = 44, //录像文件查询条件结构体的指针为空
        DIOERR_RECORDFILE_QUERYLIST_HANDLE_POINTER_NULL = 45, //录像文件查询句柄的指针为空
        DIOERR_RECORDFILE_INFO_POINTER_NULL = 46, //录像文件信息结构体的指针为空
        DIOERR_QUERY_RECORDFILE_OVERFLAG_POINTER_NULL = 47, //查询录像文件的标志的指针为空
        DIOERR_CALLBACKFUN_POINTER_NULL = 48, //回调函数指针为空
        DIOERR_USER_CONTEXT_POINTER_NULL = 49, //用户上下文指针为空
        DIOERR_STRMID_POINTER_NULL = 50, //码流ID的指针为空
        DIOERR_PLAYBACKCONDITION_BYFILE_POINTER_NULL = 51, //按录像回放条件的指针为空
        DIOERR_PLAYBACKCONDITION_BYTIME_POINTER_NULL = 52, //按时间回复条件的指针为空
        DIOERR_PLAYCTRL_OUTPARAM_POINTER_NULL = 53, //播放控制的输出参数的指针为空
        DIOERR_DEVICE_FILE_ID_POINTER_NULL = 54, //设备文件ID的指针为空
        DIOERR_TIME_INFO_POINTER_NULL = 55, //时间信息的指针为空
        DIOERR_DOWNLOAD_PERCENT_POINTER_NULL = 56, //下载进度的指针为空
        DIOERR_DOWNLOAD_CTRL_TYPE_OUTOFRANGE = 57, //下载控制类型越界
        DIOERR_PLAY_CTRL_TYPE_OUTOFRANGE = 58, //播放控制类型越界
        DIOERR_PTZ_CTRL_TYPE_OUTOFRANGE = 59, //PTZ控制类型越界
        DIOERR_FREE_MODULE_HANDLE_NULL = 60, //释放模块时句柄为空
        DIOERR_FREE_MODULE_FAILED = 61, //释放模块失败
        DIOERR_GET_SDK_BY_SDKID_FAILED = 62, //根据SdkId获取Sdk失败
        DIOERR_NO_AVAILABLE_LOGINID = 63, //没有可用的登录ID
        DIOERR_NO_AVAILABLE_QUERYCHNID = 64, //没有可用的查询通道ID
        DIOERR_NO_AVAILABLE_QUERYSTRMID = 65, //没有可用的查询录像ID
        DIOERR_NO_AVAILABLE_STRMID = 66, //没有可用的码流ID
        DIOERR_RESTORE_LOGINID_FAILED = 67, //回收登录ID失败
        DIOERR_RESTORE_QUERYCHNID_FAILED = 68, //回收查询通道ID失败
        DIOERR_RESTORE_QUERYSTRMID_FAILED = 69, //回收查询录像ID失败
        DIOERR_RESTORE_STRMID_FAILED = 70, //回收码流ID失败
        DIOERR_QUERY_CHANNEL_STATUS_FAILED = 71, //查询通道状态失败
        DIOERR_QUERYSTRMFILE_EXCEPTION = 72, //查找录像时发生异常
        DIOERR_CLOSE_QUERYSTRMFILEHANDLE_FAILED = 73, //关闭查询录像句柄失败
        DIOERR_REALPLAY_FAILED = 74, //播放实时码流失败
        DIOERR_PLAYBACK_BYFILE_FAILED = 75, //按文件回放失败
        DIOERR_PLAYBACK_BYTIME_FAILED = 76, //按时间回放失败
        DIOERR_PLAYBACK_CONTROL_FAILED = 77, //播放控制失败
        DIOERR_INVALID_PLAY_CONTROL_CMD = 78, //非法的播放控制命令
        DIOERR_PTZ_CONTROL_FAILED = 79, //ptz控制失败
        DIOERR_INVALID_PTZ_CONTROL_CMD = 80, //非法的ptz控制命令
        DIOERR_GETFILE_BYNAME_FAILED = 81, //按文件名获取文件失败
        DIOERR_STREAMTYPE_OUTOFRANGE = 82, //码流类型越界
        DIOERR_INIT_ERROR_LOG_FAILED = 83, //初始化错误日志失败
        DIOERR_SET_EXCEPTION_CALLBACK_FUNCTION_FAILED = 84, //设置异常回调函数失败
        DIOERR_SNAP_PICTURE_BUF_POINTER_NULL	= 85, //抓图缓冲区指针为空
         DIOERR_SNAP_PICTURE_BUF_REAL_LEN_POINTER_NULL	= 86, //抓图缓冲区实际长度指针为空
         DIOERR_SNAP_PICTURE_BUF_TYPE_POINTER_NULL		= 87, //抓图缓冲区类型指针为空
         DIOERR_SNAP_PICTURE_FAILED						= 88, //抓图失败
   
        }
        public static readonly int DIO_OK = 0; //无错误
        public static readonly int DIO_ERRBASE = 0;



#if DEBUG
        const string DLLPATH = @"lib\dio.dll";
#else
        const string DLLPATH = @"lib\dio.dll";
#endif

        #endregion
    }
    internal partial class IVXStreamIOSDKProtocol
    {
        #region 常量定义

        //错误码（随着功能完善不断增加）
        public enum eStreamIOErrorCode
        {
            DIO_OK = 0,
        DIOERR_INIT_FAILED = 1,//初始化模块失败
        DIOERR_UNINIT_FAILED = 2,//反初始化模块失败
        DIOERR_NOT_INIT = 3,//未初始化
        DIOERR_IP_POINTER_NULL = 4,//IP指针为空
        DIOERR_IP_ADDRESS_INVALID = 5,//IP地址非法
        DIOERR_USER_POINTER_NULL = 6,//用户名指针为空
        DIOERR_USER_INVALID = 7,//用户名非法
        DIOERR_PWD_POINTER_NULL =8,//密码指针为空
        DIOERR_NEW_DEVICE_FAILED = 9,//new一个设备失败
        DIOERR_LOGIN_DEVICE_FAILED = 10, //登录设备失败
        DIOERR_LOGINID_OUTRANGE = 11, //登录ID超出范围
        DIOERR_INVALID_LOGINID = 12, //非法的登录ID
        DIOERR_LOGOUT_DEVICE_FAILED = 13, //登出设备失败
        DIOERR_QUERYCHNLST_FAILED = 14, //查询通道列表失败
        DIOERR_QUERY_NOT_END = 15, //未查询完
        DIOERR_NA_OPERATION = 16, //操作不支持
        DIOERR_INVALID_QUERYCHNLIST_HANDLE = 17, //非法的通道列表查询句柄
        DIOERR_QUERYSTRMFILE_FAILED = 18, //查询录像文件失败
        DIOERR_INVALID_QUERYSTRMFILE_HANDLE = 19, //非法的录像文件查询句柄
        DIOERR_INVALID_QUERYSTRMFILE_DATE = 20, //非法的查询时间段
        DIOERR_QUERYSTRMFILE_NO_FILE = 21, //没有找到录像文件
        DIOERR_QUERYSTRMFILE_GETNEXT_FAILED = 22, //查找下一个录像文件失败
        DIOERR_NOT_QUERYSTRMFILE = 23, //未查询录像文件
        DIOERR_CHANNEL_ID_POINTER_NULL = 24, //通道ID指针为空
        DIOERR_CHANNEL_ID_INVALID = 25, //通道ID非法
        DIOERR_SAVEFILENAME_POINTER_NULL = 26, //保存文件名指针为空
        DIOERR_SAVEFILENAME_INVALID = 27, //保存文件名非法
        DIOERR_NEW_CHANNEL_FAILED = 28, //new一个通道失败
        DIOERR_CHANNELID_OUTRANGE = 29, //通道id超出范围
        DIOERR_GET_RECORD_BY_TIME_FAILED = 30, //通过时间获取文件失败
        DIOERR_DOWNLOAD_FAILED = 31, //下载录像失败
        DIOERR_INVALID_STRMID = 32, //非法的码流ID
        DIOERR_STOP_DOWNLOAD_FAILED = 33, //停止下载录像失败
        DIOERR_GET_DOWNLOAD_PERCENT_FAILED = 34, //获取下载录像进度失败
        DIOERR_NOT_LOAD_PROC = 35, //未加载函数
        DIOERR_NOT_IMPLEMENT = 36, //未实现
        DIOERR_VERSION_BUFFER_POINTER_NULL = 37, //版本号缓冲区指针为空
        DIOERR_VERSION_BUFFER_LEN_NOT_ENOUGH = 38, //版本号缓冲区长度不足
        DIOERR_LOGINID_POINTER_NULL = 39, //登录ID的指针为空
        DIOERR_QUERYCHNLIST_HANDLE_POINTER_NULL = 40, //查询通道句柄的指针为空
        DIOERR_CHNINFO_POINTER_NULL = 41, //通道信息结构体的指针为空
        DIOERR_QUERYCHNLIST_OVERFLAG_POINTER_NULL = 42, //查询通道标志的指针为空
        DIOERR_CHNSTATUS_POINTER_NULL = 43, //通道状态结构体的指针为空
        DIOERR_RECORDFILE_QUERYCONDITION_POINTER_NULL = 44, //录像文件查询条件结构体的指针为空
        DIOERR_RECORDFILE_QUERYLIST_HANDLE_POINTER_NULL = 45, //录像文件查询句柄的指针为空
        DIOERR_RECORDFILE_INFO_POINTER_NULL = 46, //录像文件信息结构体的指针为空
        DIOERR_QUERY_RECORDFILE_OVERFLAG_POINTER_NULL = 47, //查询录像文件的标志的指针为空
        DIOERR_CALLBACKFUN_POINTER_NULL = 48, //回调函数指针为空
        DIOERR_USER_CONTEXT_POINTER_NULL = 49, //用户上下文指针为空
        DIOERR_STRMID_POINTER_NULL = 50, //码流ID的指针为空
        DIOERR_PLAYBACKCONDITION_BYFILE_POINTER_NULL = 51, //按录像回放条件的指针为空
        DIOERR_PLAYBACKCONDITION_BYTIME_POINTER_NULL = 52, //按时间回复条件的指针为空
        DIOERR_PLAYCTRL_OUTPARAM_POINTER_NULL = 53, //播放控制的输出参数的指针为空
        DIOERR_DEVICE_FILE_ID_POINTER_NULL = 54, //设备文件ID的指针为空
        DIOERR_TIME_INFO_POINTER_NULL = 55, //时间信息的指针为空
        DIOERR_DOWNLOAD_PERCENT_POINTER_NULL = 56, //下载进度的指针为空
        DIOERR_DOWNLOAD_CTRL_TYPE_OUTOFRANGE = 57, //下载控制类型越界
        DIOERR_PLAY_CTRL_TYPE_OUTOFRANGE = 58, //播放控制类型越界
        DIOERR_PTZ_CTRL_TYPE_OUTOFRANGE = 59, //PTZ控制类型越界
        DIOERR_FREE_MODULE_HANDLE_NULL = 60, //释放模块时句柄为空
        DIOERR_FREE_MODULE_FAILED = 61, //释放模块失败
        DIOERR_GET_SDK_BY_SDKID_FAILED = 62, //根据SdkId获取Sdk失败
        DIOERR_NO_AVAILABLE_LOGINID = 63, //没有可用的登录ID
        DIOERR_NO_AVAILABLE_QUERYCHNID = 64, //没有可用的查询通道ID
        DIOERR_NO_AVAILABLE_QUERYSTRMID = 65, //没有可用的查询录像ID
        DIOERR_NO_AVAILABLE_STRMID = 66, //没有可用的码流ID
        DIOERR_RESTORE_LOGINID_FAILED = 67, //回收登录ID失败
        DIOERR_RESTORE_QUERYCHNID_FAILED = 68, //回收查询通道ID失败
        DIOERR_RESTORE_QUERYSTRMID_FAILED = 69, //回收查询录像ID失败
        DIOERR_RESTORE_STRMID_FAILED = 70, //回收码流ID失败
        DIOERR_QUERY_CHANNEL_STATUS_FAILED = 71, //查询通道状态失败
        DIOERR_QUERYSTRMFILE_EXCEPTION = 72, //查找录像时发生异常
        DIOERR_CLOSE_QUERYSTRMFILEHANDLE_FAILED = 73, //关闭查询录像句柄失败
        DIOERR_REALPLAY_FAILED = 74, //播放实时码流失败
        DIOERR_PLAYBACK_BYFILE_FAILED = 75, //按文件回放失败
        DIOERR_PLAYBACK_BYTIME_FAILED = 76, //按时间回放失败
        DIOERR_PLAYBACK_CONTROL_FAILED = 77, //播放控制失败
        DIOERR_INVALID_PLAY_CONTROL_CMD = 78, //非法的播放控制命令
        DIOERR_PTZ_CONTROL_FAILED = 79, //ptz控制失败
        DIOERR_INVALID_PTZ_CONTROL_CMD = 80, //非法的ptz控制命令
        DIOERR_GETFILE_BYNAME_FAILED = 81, //按文件名获取文件失败
        DIOERR_STREAMTYPE_OUTOFRANGE = 82, //码流类型越界
        DIOERR_INIT_ERROR_LOG_FAILED = 83, //初始化错误日志失败
        DIOERR_SET_EXCEPTION_CALLBACK_FUNCTION_FAILED = 84, //设置异常回调函数失败
            DIOERR_GB28181 = 85, //gb28181内部错误
            DIOERR_QUERY_END = 86, //查询完
            DIOERR_RTSP_URL_NULL = 87, //RTSP地址传入为空
            DIOERR_RTSP_URLLEN_TOOLONG = 88, //RTSP地址长度太长
            DIOERR_RTSP_LIVE555_INIT_FAILED = 89, //LIVE555初始化失败
            DIOERR_RTSP_OPEN_RTSP_FAILED = 90, //RTSP码流打开失败
            DIOERR_RTSP_CONNECT_RTSP_PORT_FAILED = 91, //连接RTSP码流端口失败
            DIOERR_OSA_INIT_FAILED = 92, //初始化OSA库失败
            DIOERR_CTL_INIT_FAILED = 93, //初始化CTL库失败
            DIOERR_NULL_PARAM = 94, //参数不能为空
            DIOERR_INVALID_PLAYCTRL_PARAM = 95, //非法的点播控制参数
            DIOERR_QUERYDATE_INTV_TOOLARGE = 96, //查询时间段跨度太大

            DIOERR_DLL_FILE_NOTFOUND = 97, //指定路径下未找到动态库文件
            DIOERR_LOAD_DLL_FAILED = 98, //加载动态库失败
            DIOERR_GET_DLL_FUNC_ADDR_FAILED = 99, //获取动态库函数地址失败
            DIOERR_CALL_3SDK_ERROR = 100, //调用第三方Sdk错误
            DIOERR_INNER_ERROR = 101, //内部错误
            DIOERR_FILE_NOT_EXIST = 102, //文件不存在

            STREAMERR_GB_PORITER = 1300,//GB类的单实例化失败
            STREAMERR_DH_PORITER = 1301,//DH类的单实例化失败
            STREAMERR_RTP_PORITER = 1302,//GB类的单实例化失败
            STREAMERR_NO_FITTYPE = 1303,//依据LoginId没有找到对应的设备类型
            STREAMERR_NO_FITDIO = 1304,//依据StrmId没有找到对应的DIOID
            STREAMERR_NO_FITRTP = 1305,//依据StrmId没有找到对应的RTPID
            STREAMERR_GET_DEVNUM = 1306,//GET_DEVNUM failed
            STREAMERR_GET_DEVINFO = 1307,//GET_DEVINFO failed
            STREAMERR_GET_CHLNUM = 1308,//GET_CHLNUM failed
            STREAMERR_GET_CHLINFO = 1309,//GET_CHLINFO failed
            STREAMERR_OPENINPUTSTRM = 1310,//BM_OpenInputStrmWnd 调用failed
            STREAMERR_INPUTDATA = 1311,//BM_InputData 调用failed
            STREAMERR_RTPTRANSOPEN = 1312,//RTPTrans_OpenSrc 调用failed
            STREAMERR_RTPSTOP = 1313,//RTPTrans_OpenSrc 调用failed
        }
        public static readonly int StreamIO_OK = 0; //无错误
        public static readonly int StreamIO_ERRBASE = 0;

        public static readonly bool StreamIO_SIP_TYPE = true;



#if DEBUG
        const string DLLPATH = @"lib\streamsdk.dll";
#else
        const string DLLPATH = @"lib\streamsdk.dll";
#endif

        #endregion
    }
    internal partial class IVXRVODSDKProtocol
    {
        #region 常量定义

#if DEBUG
        const string DLLPATH = @"librvod\rvodsdk.dll";
#else
        const string DLLPATH = @"librvod\rvodsdk.dll";
#endif

        #endregion
    }
}
