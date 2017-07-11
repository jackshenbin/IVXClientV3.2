using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using BOCOM.DataModel;
using BOCOM.RealtimeProtocol.Model;
using DataModel;
using System.Collections.Generic;

namespace BOCOM.RealtimeProtocol
{
    #region 基本结构体


    // 网络存储设备基本信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVDASDK_NET_STORE_DEV_BASE
    {
        public UInt32 dwDevicePort;							//连接端口号

        public UInt32 dwAccessProtocolType;					//接入厂商协议类型 E_VDA_ACCESS_PTOTOCOL_TYPE

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDASDK_MAX_NET_STORE_DEV_NAME)]
        public string szDeviceName;	//设备名称

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDASDK_MAX_IPADDR_LEN)]
        public string szDeviceIP;	//连接IP地址

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDASDK_MAX_NAME_LEN)]
        public string szLoginUser;		//登录用户

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDASDK_MAX_PWD_LEN)]
        public string szLoginPwd;		//登录密码
    };

    // 网络存储设备信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TVDASDK_NET_STORE_DEV_INFO
    {
        public UInt32 dwVideoSupplierDeviceId;							//网络存储设备ID
        public TVDASDK_NET_STORE_DEV_BASE tNetStoreDevBase;	//网络存储设备基本信息
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVDASDK_NET_STORE_DEV_LOGIN_INFO
    {
        public TVDASDK_NET_STORE_DEV_BASE tDevBase;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_ChannelInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_CHANNEL_ID_LEN)]
        public string szChannelId;  //通道Id
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_NAME_LEN)]
        public string szChannelName;//通道名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_REST_LEN)]
        public string szRest;		  //保留信息
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVDASDK_NET_STORE_DEV_FILE_CONDITION
    {
        public uint dwStartTime; //平台文件开始时间
        public uint dwEndTime;   //平台文件结束时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDA_MAX_FILEPATH_LEN)]
        public string szChannelId;  //通道Id
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVDASDK_NET_STORE_DEV_FILE_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDA_MAX_FILEPATH_LEN)]
        public string szFileId;	//第3方设备/平台上的文件标识
        public uint tStartTime;						//文件录像起始时间
        public uint tEndTime;						    //文件录像结束时间
        public ulong qwFileSize;						//文件大小
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDA_MAX_FILEPATH_LEN)]
        public string szRest;		//保留信息
    }

    //平台实时视频播放 
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVDASDK_NET_DEV_REAL_VOD_INFO
    {
        public IntPtr hPlayWnd;//平台实时视频播放窗口句柄 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.VDASDK_MAX_FILEPATH_LEN)]
        public string szChannelId;//实时视频所在的通道 
        public uint dwStrmType;//实时视频码流类型,见E_VDA_NET_STREAM_TYPE_TYPE 
    };
    //通道状态
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_ChannelStatus
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_CHANNEL_ID_LEN)]
        public string szChannelId;	//通道Id（也即相机编号）
        byte bSignalStatic;						//信号状态：0－正常，1－信号丢失
        byte bRecordStatic;						//录像状态：0－不录像；1－录像
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_REST_LEN)]
        public string szRest;				//保留信息
    };

    //文件查询条件
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_QueryFileCondition
    {
        public uint tStart;						//指定查询时间段
        public uint tStop;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_REST_LEN)]
        public string szRest;				//保留信息
    };

    //回放文件信息（请求历史码流时使用）
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_PlaybackFile
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_NAME_LEN)]
        public string szFileId;			//文件标识
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_REST_LEN)]
        public string szRest;				//保留信息
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_Version
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_NAME_LEN)]
        public string szVer;
    };

    //回放时间信息（请求历史码流时使用）
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_PlaybackTime
    {
        public uint tStart;
        public uint tStop;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_REST_LEN)]
        public string szRest;				//保留信息
    };

    //录像文件信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TDIO_StrmFileInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_FILE_ID_LEN)]
        public string szFileId;			//第3方设备/平台上的文件标识
        public uint tStart;						//文件录像起始时间
        public uint tStop;						//文件录像结束时间
        public ulong qwFileSize;						//文件大小
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.DIO_REST_LEN)]
        public string szRest;				//保留信息
    };

    #endregion

    #region 回调定义
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate int LPSTRMCALLBACK(uint dwStrmId, uint dwDataType, IntPtr pData, int nDataLen, IntPtr pUserContext);
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void LPEXCEPTIONCALLBACK(uint dwLoginId, IntPtr pUserContext);

    #endregion

    internal partial class IVXDIOSDKProtocol
    {

        /**
 * 功能：DIO模块初始化
 * 参数：
 * 返回值：DIO_OK成功，非DIO_OK失败
 */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOInit();

        /**
         * 功能：DIO模块反初始化
         * 参数：无
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOUninit();

        /**
         * 功能：登录第三方设备/平台
         * 参数：
         * dwConnType：具体第三方设备/平台的枚举值，参见EDIO_ConnectType
         * pIp：IP地址
         * uPort：端口号
         * pUser：用户名
         * pPassword：密码
         * dwTimeout：与此设备所有操作的超时时间
         * pdwLoginId：登录ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOLoginDevice(uint dwConnType, string pIp,
    ushort uPort, string pUser, string pPassword, uint dwTimeout, out uint pdwLoginId);

        /**
         * 功能：登出第三方设备/平台
         * 参数：
         * dwLoginId：登录ID
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOLogoutDevice(uint dwLoginId);

        /**
         * 功能：创建查询通道列表
         * 参数：
         * dwLoginId：登录ID
         * pdwQueryChnLstHandle：通道列表查询句柄（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOCreateQueryChannelList(uint dwLoginId, out uint pdwQueryChnLstHandle);

        /**
         * 功能：（从查询通道列表中依次）获取通道信息 
         * 参数：
         * dwQueryChnLstHandle：通道列表的查询句柄
         * ptChannelInfo：通道信息（输出参数）
         * pdwQueryOverFlag：查询完毕的标志，若查询完则返回DIO_OK，若未查询完则返回DIOERR_QUERY_NOT_END
         * 返回值：DIO_OK表示本次查询成功，其他值表示失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOGetNextChannelInfo(uint dwQueryChnLstHandle, out TDIO_ChannelInfo ptChannelInfo, out uint pdwQueryOverFlag);

        /**
         * 功能：关闭查询通道列表
         * 参数：
         * dwQueryChnLstHandle：通道列表的查询句柄
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIOCloseQueryChannelList(uint dwQueryChnLstHandle);

        /**
         * 功能：通道状态查询
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * ptDevStatus：通道Id对应的通道状态
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOQueryChannelStatus(uint dwLoginId, string pChannelId, out TDIO_ChannelStatus ptChannelStatus);




        /** 
 * 功能：创建查询录像文件列表
 * 参数：
 * dwLoginId：登录ID
 * pChannelId：通道Id
 * ptQueryCondition：查询录像的检索条件
 * pdwQueryStrmFilesHandle：录像查询句柄（输出参数）
 * 返回值：DIO_OK成功，非DIO_OK失败
 */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOCreateQueryStrmFilesList(uint dwLoginId, string pChannelId,
     TDIO_QueryFileCondition ptQueryCondition, out uint pdwQueryStrmFilesHandle);

        /**
         * 功能：（从查询录像文件列表中依次）获取录像文件信息
         * 参数：
         * dwQueryStrmFilesHandle：录像查询句柄
         * ptStrmFilesInfo：录像文件信息（输出参数）
         * pdwQueryOverFlag：查询完毕的标志，若查询完则返回DIO_OK，若未查询完则返回DIOERR_QUERY_NOT_END
         * 返回值：DIO_OK表示查询成功，其他值表示失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOGetNextFileInfo(uint dwQueryStrmFilesHandle, out TDIO_StrmFileInfo ptStrmFilesInfo, out uint pdwQueryOverFlag);

        /**
         * 功能：关闭查询录像文件列表
         * 参数：
         * dwQueryStrmFilesHandle：录像查询句柄
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOCloseQueryStrmFilesList(uint dwQueryStrmFilesHandle);

        /************************************************************************/
        /* 跟播放码流有关的接口函数                                             */
        /************************************************************************/
        /**
         * 功能：请求实时码流
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * dwStrmType：码流类型为0表示主码流，为1表示子码流
         * hWnd：窗口句柄（需要SDK解码时句柄设为有效值，仅取流不解码时可设为空）
         * fCallback：视频/音频回调函数（可为空）
         * pUserContext：用户上下文
         * pdwRealStrmId：实时码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint DIORealPlay(uint dwLoginId, string pChannelId, uint dwStrmType,
    uint hWnd, LPSTRMCALLBACK fCallback, IntPtr pUserContext, out uint pdwRealStrmId);

        /**
         * 功能：请求历史码流(根据文件加载）
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * ptRecFile：录像文件（请求条件）
         * hWnd：窗口句柄（需要SDK解码时句柄设为有效值，仅取流不解码时可设为空）
         * fCallback：视频/音频回调函数
         * pUserContext：用户上下文
         * pdwStrmId：码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOPlaybackByFile(uint dwLoginId, string pChannelId,
     TDIO_PlaybackFile ptRecFile, uint hWnd, LPSTRMCALLBACK fCallback, out IntPtr pUserContext, out uint pdwStrmId);

        /**
         * 功能：请求历史码流(根据时间段加载）
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * ptTime：时间段（请求条件）
         * hWnd：窗口句柄（需要SDK解码时句柄设为有效值，仅取流不解码时可设为空）
         * fCallback：视频/音频回调函数
         * pUserContext：用户上下文
         * pdwStrmId：码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOPlaybackByTime(uint dwLoginId, string pChannelId,
     TDIO_PlaybackTime ptTime, uint hWnd, LPSTRMCALLBACK fCallback, out IntPtr pUserContext, out uint pdwStrmId);

        /**
         * 功能：历史码流播放控制（实现播放、暂停、快进、获取播放进度等，控制命令dwCtrlCmd参见EDIO_PlayControlType定义）
         * 参数：
         * dwStrmId：码流ID
         * dwCtrlCmd：控制命令
         * dwInValue：控制命令的输入参数（用法参见EDIO_PlayControlType定义）
         * pdwOutValue：控制命令的输出参数（用法参见EDIO_PlayControlType定义）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOPlayCtrl(uint dwStrmId, uint dwCtrlCmd, uint dwInValue, out uint pdwOutValue);

        /**
         * 功能：关闭码流
         * 参数：
         * dwStrmId：码流ID
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOCloseStrm(uint dwStrmId);
        /************************************************************************/
        /* 跟控制摄像头有关的接口函数                                           */
        /************************************************************************/
        /**
         * 功能：PTZ控制
         * 参数：
         * dwRealStrmId：实时码流ID
         * dwPtzType：ptz控制命令，参见EDIO_PtzCtrl
         * dParam1：控制参数1
         * dParam2：控制参数2
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOPtzCtrl(uint dwRealStrmId, uint dwPtzType, double dParam1, double dParam2);

        /************************************************************************/
        /* 跟下载录像有关的接口函数                                             */
        /************************************************************************/
        /**
         * 功能：根据文件名开始下载
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * pDevFileId：设备上的文件Id
         * pSavedFile：下载后保存的文件名
         * pdwStrmId：码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOStartDownloadByFileSF(uint dwLoginId, string pChannelId,
    string pDevFileId, string pSavedFile, out uint pdwStrmId);

        /**
         * 功能：根据文件名开始下载（下载码流通过回调fCallback返回到上层）
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * pDevFileId：设备上的文件Id
         * fCallback：回调函数指针
         * pUserContext：用户上下文
         * pdwStrmId：码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOStartDownloadByFileCB(uint dwLoginId, string pChannelId,
    string pDevFileId, LPSTRMCALLBACK fCallback, out IntPtr pUserContext, out uint pdwStrmId);

        /** 
         * 功能：根据时间等信息开始下载（下载码流通过回调fCallback返回到上层）
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * ptStartTime：开始时间
         * ptEndTime：结束时间
         * pSavedFile：下载后保存的文件名（可含路径）
         * pdwStrmId：码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOStartDownloadByTimeSF(uint dwLoginId, string pChannelId,
     uint ptStartTime, uint ptEndTime, string pSavedFile, out  uint pdwStrmId);

        /** 
         * 功能：根据时间等信息开始下载
         * 参数：
         * dwLoginId：登录ID
         * pChannelId：通道Id
         * ptStartTime：开始时间
         * ptEndTime：结束时间
         * fCallback：回调函数指针
         * pUserContext：用户上下文
         * pdwStrmId：码流ID（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOStartDownloadByTimeCB(uint dwLoginId, string pChannelId,
    uint ptStartTime, uint ptEndTime, LPSTRMCALLBACK fCallback, out IntPtr pUserContext, out uint pdwStrmId);

        /** 
         * 功能：下载控制（暂停下载、恢复下载）
         * 参数：
         * dwStrmId：码流ID
         * dwDownloadCtrlType：下载控制命令，参见EDIO_DownloadCtrl
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIODownloadCtrl(uint dwStrmId, uint dwDownloadCtrlType);

        /** 
         * 功能：停止下载（停止并且关闭码流）
         * 参数：
         * dwStrmId：码流ID
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOStopDownload(uint dwStrmId);

        /**
         * 功能：获取文件下载百分比
         * 参数：
         * dwStrmId：码流ID
         * pdwPercent：下载的进度（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOGetDownloadFilePercent(uint dwStrmId, out uint pdwPercent);
        /**
         * 功能：设置异常回调函数（当有底层有异常时能及时通知上层）
         * 参数：
         * dwLoginId：登录ID
         * fCallback：异常回调函数
         * pUserContext：用户上下文
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOSetExceptionCallbackFun(uint dwLoginId, LPEXCEPTIONCALLBACK fCallback, out uint pUserContext);

        /************************************************************************/
        /* 跟获取版本信息有关的接口函数                                         */
        /************************************************************************/
        /** 
         * 功能：获取DIO模块版本信息
         * 参数：
         * szVersion：版本号缓冲区（输出参数）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOGetVer(out TDIO_Version ver);


                /************************************************************************/
        /* 跟抓图有关的接口函数                                                 */
        /************************************************************************/
        /**
         * 功能：根据码流抓图
         * 参数：
         * dwStrmId：码流ID
         * pPicBuf：图片缓冲区（外部申请）
         * dwPicBufMaxLen：图片缓冲区的最大长度（也即缓冲区的初始长度）
         * pdwPicBufRealLen：图片缓冲区的实际长度（即使函数调用失败，也会返回缓冲区的实际长度）
         * pdwPicBufType：图片缓冲区的类型（类型参见EDIO_SnapPictureBufType）
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern uint DIOSnapPicture(uint dwStrmId, IntPtr pPicBuf, uint dwPicBufMaxLen, out uint pdwPicBufRealLen, out uint pdwPicBufType);

    }


    public partial class IVXRealtimeProtocol
    {

        #region 网络存储设备

        public uint DIOInit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            return retVal;

        }

        public uint DIOUninit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOUninit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOUninit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOUninit ret:" + retVal);
            return retVal;

        }

        public  uint DIOLoginDevice(uint dwConnType, string pIp,
    ushort uPort, string pUser, string pPassword, uint dwTimeout, out uint pdwLoginId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOLoginDevice ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOLoginDevice(dwConnType,pIp,uPort,pUser,pPassword,dwTimeout,out pdwLoginId);

            if (retVal > 0)
            {
                pdwLoginId = 0;
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOLoginDevice ret:" + retVal);
            return retVal;

        }

        public  uint DIOLogoutDevice(uint dwLoginId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOLogoutDevice ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOLogoutDevice(dwLoginId);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOLogoutDevice ret:" + retVal);
            return retVal;

        }

        public  uint DIOCreateQueryChannelList(uint dwLoginId, out uint pdwQueryChnLstHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOCreateQueryChannelList ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOCreateQueryChannelList(dwLoginId,out pdwQueryChnLstHandle);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOCreateQueryChannelList ret:" + retVal);
            return retVal;

        }

        public uint DIOGetNextChannelInfo(uint dwQueryChnLstHandle, out TDIO_ChannelInfo ptChannelInfo, out uint pdwQueryOverFlag)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOGetNextChannelInfo ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOGetNextChannelInfo(dwQueryChnLstHandle,out ptChannelInfo,out pdwQueryOverFlag);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOGetNextChannelInfo ret:" + retVal);
            return retVal;

        }

        public uint DIOCloseQueryChannelList(uint dwQueryChnLstHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOCloseQueryChannelList ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOCloseQueryChannelList(dwQueryChnLstHandle);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOCloseQueryChannelList ret:" + retVal);
            return retVal;

        }

        public  uint DIOQueryChannelStatus(uint dwLoginId, string pChannelId, out TDIO_ChannelStatus ptChannelStatus)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            ptChannelStatus = new TDIO_ChannelStatus();
            return retVal;

        }



        public  uint DIOCreateQueryStrmFilesList(uint dwLoginId, string pChannelId,
     TDIO_QueryFileCondition ptQueryCondition, out uint pdwQueryStrmFilesHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pdwQueryStrmFilesHandle = 0;
            return retVal;

        }

        public uint DIOGetNextFileInfo(uint dwQueryStrmFilesHandle, out TDIO_StrmFileInfo ptStrmFilesInfo, out uint pdwQueryOverFlag)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            ptStrmFilesInfo = new TDIO_StrmFileInfo();
            pdwQueryOverFlag = 0;
            return retVal;

        }

        public uint DIOCloseQueryStrmFilesList(uint dwQueryStrmFilesHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            return retVal;

        }

        public  uint DIORealPlay(uint dwLoginId, string pChannelId, uint dwStrmType,
    uint hWnd, IntPtr pUserContext, out uint pdwRealStrmId)
        {
            m_LPSTRMCALLBACK = OnLPSTRMCALLBACK;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIORealPlay ");
            UInt32 retVal = IVXDIOSDKProtocol.DIORealPlay(dwLoginId, pChannelId, dwStrmType, hWnd, m_LPSTRMCALLBACK, pUserContext, out pdwRealStrmId);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIORealPlay ret:" + retVal);
            return retVal;

        }

        public  uint DIOPlaybackByFile(uint dwLoginId, string pChannelId,
     TDIO_PlaybackFile ptRecFile, uint hWnd, out IntPtr pUserContext, out uint pdwStrmId)
        {
            LPSTRMCALLBACK fCallback;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pUserContext = IntPtr.Zero;
            pdwStrmId = 0;
            return retVal;

        }

        public  uint DIOPlaybackByTime(uint dwLoginId, string pChannelId,
     TDIO_PlaybackTime ptTime, uint hWnd, out IntPtr pUserContext, out uint pdwStrmId)
        {
            LPSTRMCALLBACK fCallback;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pUserContext = IntPtr.Zero;
            pdwStrmId = 0;
            return retVal;

        }

        public uint DIOPlayCtrl(uint dwStrmId, uint dwCtrlCmd, uint dwInValue, out uint pdwOutValue)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pdwOutValue = 0;
            return retVal;

        }

        public  uint DIOCloseStrm(uint dwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOCloseStrm ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOCloseStrm(dwStrmId);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOCloseStrm ret:" + retVal);
            return retVal;

        }
        public  uint DIOPtzCtrl(uint dwRealStrmId, uint dwPtzType, double dParam1, double dParam2)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            return retVal;

        }

        public  uint DIOStartDownloadByFileSF(uint dwLoginId, string pChannelId,
    string pDevFileId, string pSavedFile, out uint pdwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pdwStrmId = 0;
            return retVal;

        }

        public  uint DIOStartDownloadByFileCB(uint dwLoginId, string pChannelId,
    string pDevFileId, out IntPtr pUserContext, out uint pdwStrmId)
        {
            LPSTRMCALLBACK fCallback;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pUserContext = IntPtr.Zero;
            pdwStrmId = 0;
            return retVal;

        }

        public  uint DIOStartDownloadByTimeSF(uint dwLoginId, string pChannelId,
     uint ptStartTime, uint ptEndTime, string pSavedFile, out  uint pdwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pdwStrmId = 0;
            return retVal;

        }

        public  uint DIOStartDownloadByTimeCB(uint dwLoginId, string pChannelId,
    uint ptStartTime, uint ptEndTime, out IntPtr pUserContext, out uint pdwStrmId)
        {
            LPSTRMCALLBACK fCallback;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pUserContext = IntPtr.Zero;
            pdwStrmId = 0;
            return retVal;

        }

        public uint DIODownloadCtrl(uint dwStrmId, uint dwDownloadCtrlType)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            return retVal;

        }

        public  uint DIOStopDownload(uint dwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            return retVal;

        }

        public  uint DIOGetDownloadFilePercent(uint dwStrmId, out uint pdwPercent)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pdwPercent = 0;
            return retVal;

        }
        public uint DIOSetExceptionCallbackFun(uint dwLoginId,  out IntPtr pUserContext)
        {LPEXCEPTIONCALLBACK fCallback;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            pUserContext = IntPtr.Zero;
            return retVal;

        }

        public  uint DIOGetVer(out TDIO_Version ver)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOInit ret:" + retVal);
            ver = new TDIO_Version();
            return retVal;

        }
        public  System.Drawing.Image DIOSnapPicture(uint dwStrmId)
        {
            //System.Drawing.Image t = new System.Drawing.Bitmap(1920, 1080);
            // System.Drawing.Graphics.FromImage(t).DrawString("DIOSnapPicture",new System.Drawing.Font("宋体",30), System.Drawing.Brushes.Red,new System.Drawing.PointF(100,100));
            //return t;
            uint dwPicBufMaxLen =DataModel.Common.MAX_PIC_DATA_LEN;
            IntPtr pPicBuf = Marshal.AllocHGlobal((int)dwPicBufMaxLen); 
            uint pdwPicBufRealLen=0;
            uint pdwPicBufType=0;

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOSnapPicture ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOSnapPicture(dwStrmId,pPicBuf,dwPicBufMaxLen,out pdwPicBufRealLen,out pdwPicBufType);
            if ((retVal > 0) && pdwPicBufRealLen > dwPicBufMaxLen && dwPicBufMaxLen > 0)
            {
                if (pPicBuf != IntPtr.Zero)
                    Marshal.FreeHGlobal(pPicBuf);

                dwPicBufMaxLen = pdwPicBufRealLen;
                pPicBuf = Marshal.AllocHGlobal((int)dwPicBufMaxLen);
                pdwPicBufRealLen = 0;
                pdwPicBufType = 0;
                retVal = IVXDIOSDKProtocol.DIOSnapPicture(dwStrmId, pPicBuf, dwPicBufMaxLen, out pdwPicBufRealLen, out pdwPicBufType);

            }

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            System.Drawing.Image img = ModelParser.GetImage(pPicBuf, (int)pdwPicBufRealLen);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDIOSDKProtocol DIOSnapPicture ret:" + retVal);
            if (pPicBuf != IntPtr.Zero)
                Marshal.FreeHGlobal(pPicBuf);
            return img;



        }
        #endregion
    }
}
