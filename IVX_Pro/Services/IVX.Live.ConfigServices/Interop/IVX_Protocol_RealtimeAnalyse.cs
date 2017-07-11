using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using IVX.DataModel;
using DataModel;

namespace IVX.Live.ConfigServices.Interop
{
    #region 基本结构体

    //登陆信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TIASSDK_LOGIN_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_IPADDR_LEN)]
        public string szIp; //服务端IP地址
        public UInt16 wPort;					  //服务端端口
    };

    //实时网络存储设备基本信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct T_IASSDK_REAL_NET_STROE_DEV_INFO
    {
        public UInt32 dwDeviceType;		//平台类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_IPADDR_LEN)]
        public string szDeviceIP;	//连接IP地址
        public UInt16 dwDevicePort;		//连接端口号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_NAME_LEN)]
        public string szLoginUser;	//登录用户
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_PWD_LEN)]
        public string szLoginPwd;	//登录密码	
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_NET_STORE_DEV_NAME)]
        public string szChannelID;   //平台通道ID
    };

    //实时分析任务参数
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TIASSDK_REAL_ANALYSIS_PARAM
    {
        public UInt32 dwAnalysisPlanID;					//分析计划ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_NAME_LEN)]
        public string szCameraID;		//存储相机ID
        public UInt32 eAlgthmType;    //算法类型
        public T_IASSDK_REAL_NET_STROE_DEV_INFO cNetStoreDevInfo; //接入模块参数
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_IPADDR_LEN)]
        public string szArsIp;			//分析结果存储服务器IP(网络字节序)
        public UInt16 wArsPort;		//分析结果存储服务器端口
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_ANALYSIS_PRARM_LENGTH)]
        public string szAnalysisParam;	//分析参数
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_DESCRIPTION_LEN)]
        public string szOther;			//备用字段
    };

    //实时分析信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TIASSDK_REAL_ANALYSIS_INFO
    {
        public UInt32 dwAnalysisID;      //分析ID  //UUID
        public TIASSDK_REAL_ANALYSIS_PARAM tAnalysisParam;		 //实时分析任务参数
        public UInt32 dwServerID;		//分析服务ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_IPADDR_LEN)]
        public string szServerIp;//分析服务IP
        public UInt16 wServerPort;		//分析服务端口
        public UInt32 dwConSerialNum;	//分析服务并发ID
        public UInt32 eStatusType;   //分析状态
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TIASSDK_VERSION_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.IASSDK_MAX_VERSION_LEN)]
        public string szVersion;
    };
    #endregion


    #region 回调定义
    // 网络连接断开回调函数
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void TIasSdk_DisConnectNtfCB(UInt32 dwLoginID, UInt64 qwContext);
    // 实时分析状态回调函数
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void TIasSdk_RTAnalysisStatusNtfCB(UInt32 dwLoginID, UInt32 dwAnalysisID, E_IASSDK_REAL_ANALYZE_STATUS_TYPE eStatusType, UInt64 qwContext);

    #endregion

    internal partial class IVXRealtimeSDKProtocol
    {
        #region 实时分析计划接口



        /************************************************************************
         ** 初始化和连接接口
         ***********************************************************************/
        //初始化
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_Init();
        //退出
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_UnInit();

        //获取SDK的版本信息
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetSdkVersion(out TIASSDK_VERSION_INFO cServerVersion);
        //获取错误码描述
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern string IasSdk_GetErrorMsg(UInt32 dwErrCode);

        /*===========================================================
        功  能：注册状态回调函数
        参  数：
		        pFuncDisConnectNtf - 断开连接通知回调函数
		        pFuncRTAnalysisStatusNtf - 实时分析状态回调函数
		        pFuncNoRTAnalysisStatusNtf - 非实时分析状态回调函数
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_RegisterCallBack(TIasSdk_DisConnectNtfCB pFuncDisConnectNtf, TIasSdk_RTAnalysisStatusNtfCB pFuncRTAnalysisStatusNtf,
                                                    IntPtr/*TIasSdk_NoRTAnalysisStatusNtfCB*/ pFuncNoRTAnalysisStatusNtf);

        /*===========================================================
        功  能：登陆请求
        参  数：tLogInfo - 服务端登录信息
                dwTimeoutS - 超时时间（秒）
                qwContext - 回调上下文
                pdwLoginID - 返回登录ID
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_Login(TIASSDK_LOGIN_INFO tLogInfo, UInt32 dwTimeoutS,
                                      UInt64 qwContext, out UInt32 pdwLoginID);

        /*===========================================================
        功  能：注销登陆
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_Logout(UInt32 dwLoginID);

        /*===========================================================
        功  能：获取服务器的版本
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
                cServerVersion - 版本字符串
        返回值：版本字符串，失败返回NULL
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetServerVersion(UInt32 dwLoginID, out TIASSDK_VERSION_INFO cServerVersion);

        /*===========================================================
        功  能：获取服务的能力级
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
                pdwServiceCapacity - 服务器能力
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetServiceCapacity(UInt32 dwLoginID, out UInt32 pdwServiceCapacity);

        /*===========================================================
        功  能：添加实时分析
        参  数：dwLoginID - 登录ID
                tAnalysisInfo - 分析信息
                pdwAnalysisID - 返回分析ID
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_AddRTAnalysis(UInt32 dwLoginID, TIASSDK_REAL_ANALYSIS_PARAM tAnalysisParam, out UInt32 pdwAnalysisID);

        /*===========================================================
        功  能：获取实时分析信息ByID
        参  数：dwLoginID - 登录ID
                pdwAnalysisID - 分析ID
                tAnalysisInfo - 返回分析信息
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetRTAnalysisInfoByID(UInt32 dwLoginID, UInt32 dwAnalysisID, out TIASSDK_REAL_ANALYSIS_INFO ptAnalysisInfo);

        /*===========================================================
        功  能：获取实时分析数量
        参  数：dwLoginID - 登录ID
                pdwAnalysisNum - 实时分析数量
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetRTAnalysisNum(UInt32 dwLoginID, out UInt32 pdwAnalysisNum);

        /*===========================================================
        功  能：获取实时分析信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwAnalysisNum - 返回实际得到的分析数量
                ptAnalysisInfo - 返回分析信息指针
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetRTAnalysisList(UInt32 dwLoginID, UInt32 dwMaxNum, out UInt32 pdwAnalysisNum, /*OUT TIASSDK_REAL_ANALYSIS_INFO * */IntPtr ptAnalysisInfo);

        /*===========================================================
        功  能：获取实时分析状态
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
                dwAnalysisID - 分析ID
                pdwStatus - 分析状态
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_GetRTAnalysisStatus(UInt32 dwLoginID, UInt32 dwAnalysisID, out E_IASSDK_REAL_ANALYZE_STATUS_TYPE pdwStatus);

        //删除分析
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 IasSdk_DelAnalysis(UInt32 dwLoginID, UInt32 dwAnalysisID);

        ///*===========================================================
        //功  能：增加服务单元（执行节点）
        //参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
        //        tServerUnitParam - 服务单元参数
        //        pdwServerUnitID - 输出服务单元ID
        //返回值：版本字符串，失败返回0
        //===========================================================*/
        //IAS_SDK_API UINT32 STDCALL IasSdk_AddServerUnit(UINT32 dwLoginID, TIASSDK_SERVER_UNIT_PARAM tServerUnitParam, OUT UINT32 *pdwServerUnitID);

        ///*===========================================================
        //功  能：删除服务单元（执行节点）
        //参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
        //        dwServerUnitID - 服务单元ID
        //返回值：版本字符串，失败返回0
        //===========================================================*/
        //IAS_SDK_API UINT32 STDCALL IasSdk_DelServerUnit(UINT32 dwLoginID, UINT32 dwServerUnitID);

        ///*===========================================================
        //功  能：获取服务单元ByID
        //参  数：dwLoginID - 登录ID
        //        dwServerUnitID - 服务单元ID
        //        tServerUnitInfo - 返回服务单元信息
        //返回值：成功返回IASSDK_OK，失败返回错误码
        //===========================================================*/
        //IAS_SDK_API UINT32 STDCALL IasSdk_GetServerUnitByID( UINT32 dwLoginID, UINT32 dwServerUnitID, OUT TIASSDK_SERVER_UNIT_INFO *ptServerUnitInfo);

        ///*===========================================================
        //功  能：获取服务单元数量
        //参  数：dwLoginID - 登录ID
        //        pdwServerUnitNum - 服务单元数量
        //返回值：成功返回IASSDK_OK，失败返回错误码
        //===========================================================*/
        //IAS_SDK_API UINT32 STDCALL IasSdk_GetServerUnitNum( UINT32 dwLoginID, OUT UINT32 *pdwServerUnitNum);

        ///*===========================================================
        //功  能：获取服务单元信息ByNum
        //参  数：dwLoginID - 登录ID
        //        dwMaxNum - 传入需要获取的数量
        //        pdwServerUnitNum - 返回实际得到的数量
        //        tServerUnitInfo - 返回服务单元信息指针
        //返回值：成功返回IASSDK_OK，失败返回错误码
        //===========================================================*/
        //IAS_SDK_API UINT32 STDCALL IasSdk_GetServerUnitList( UINT32 dwLoginID, UINT32 dwMaxNum, OUT UINT32 *pdwServerUnitNum, OUT TIASSDK_SERVER_UNIT_INFO *ptServerUnitInfo);


        #endregion

    }

    public partial class IVXRealtimeProtocol
    {
        #region 实时分析计划接口



        //初始化
        public bool IasSdk_Init()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_Init " );
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_Init();

            if (retVal>0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_Init ret:" + retVal);
            return retVal==0;
        }
        //退出
        public bool IasSdk_UnInit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_UnInit ");
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_UnInit();

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_UnInit ret:" + retVal);
            return retVal==0;
        }

        //获取SDK的版本信息
        public static string IasSdk_GetSdkVersion()
        {
            TIASSDK_VERSION_INFO cServerVersion ;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetSdkVersion ");
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetSdkVersion(out cServerVersion);

            if (retVal > 0)
            {
                return "0.0.0.0";
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetSdkVersion ret:" + retVal + ",cServerVersion:" + cServerVersion.szVersion);
            return cServerVersion.szVersion;
        }
        //获取错误码描述

        private  string IasSdk_GetErrorMsg(UInt32 dwErrCode)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetErrorMsg dwErrCode:" + dwErrCode);
            string retVal = IVXRealtimeSDKProtocol.IasSdk_GetErrorMsg(dwErrCode);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetErrorMsg ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：注册状态回调函数
        参  数：
		        pFuncDisConnectNtf - 断开连接通知回调函数
		        pFuncRTAnalysisStatusNtf - 实时分析状态回调函数
		        pFuncNoRTAnalysisStatusNtf - 非实时分析状态回调函数
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/

        public UInt32 IasSdk_RegisterCallBack()
        {
            m_pFuncDisConnectNtf = OnTIasSdk_DisConnectNtfCB;
            m_pFuncRTAnalysisStatusNtf = OnTIasSdk_RTAnalysisStatusNtfCB;
            IntPtr pFuncNoRTAnalysisStatusNtf = IntPtr.Zero;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_RegisterCallBack ");
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_RegisterCallBack(m_pFuncDisConnectNtf, m_pFuncRTAnalysisStatusNtf, pFuncNoRTAnalysisStatusNtf);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_RegisterCallBack ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：登陆请求
        参  数：tLogInfo - 服务端登录信息
                dwTimeoutS - 超时时间（秒）
                qwContext - 回调上下文
                pdwLoginID - 返回登录ID
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 IasSdk_Login(string IP,ushort Port,  out UInt32 pdwLoginID)
        {
            UInt32 dwTimeoutS = 30 * 1000;
            UInt64 qwContext=0;
            TIASSDK_LOGIN_INFO tLogInfo = new TIASSDK_LOGIN_INFO()
            {
                szIp = IP,
                wPort = Port,
            };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_Login IP:"+IP+",port:"+Port);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_Login(tLogInfo,dwTimeoutS,qwContext,out pdwLoginID);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_Login ret:" + retVal + ",pdwLoginID:" + pdwLoginID);
            return retVal;
        }

        /*===========================================================
        功  能：注销登陆
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/

        public UInt32 IasSdk_Logout(UInt32 dwLoginID)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_Logout loginId:"+dwLoginID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_Logout(dwLoginID);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_Logout ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：获取服务器的版本
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
                cServerVersion - 版本字符串
        返回值：版本字符串，失败返回NULL
        ===========================================================*/
        public string IasSdk_GetServerVersion(UInt32 dwLoginID)
        {
            TIASSDK_VERSION_INFO cServerVersion ;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetServerVersion dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetServerVersion(dwLoginID,out cServerVersion);

            if (retVal > 0)
            {
                return "0.0.0.0";
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetServerVersion ret:" + retVal + ",cServerVersion:" + cServerVersion.szVersion);

            return cServerVersion.szVersion;
        }

        /*===========================================================
        功  能：获取服务的能力级
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
                pdwServiceCapacity - 服务器能力
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 IasSdk_GetServiceCapacity(UInt32 dwLoginID, out UInt32 pdwServiceCapacity)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetServiceCapacity dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetServiceCapacity(dwLoginID,out pdwServiceCapacity);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetServiceCapacity ret:" + retVal + ",pdwServiceCapacity:" + pdwServiceCapacity);

            return retVal;
        }

        /*===========================================================
        功  能：添加实时分析
        参  数：dwLoginID - 登录ID
                tAnalysisInfo - 分析信息
                pdwAnalysisID - 返回分析ID
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 IasSdk_AddRTAnalysis(UInt32 dwLoginID, RealAnalyseParam param, out UInt32 pdwAnalysisID)
        {
            TIASSDK_REAL_ANALYSIS_PARAM tAnalysisParam = new TIASSDK_REAL_ANALYSIS_PARAM()
            {
                dwAnalysisPlanID = param.dwAnalysisPlanID,
                szAnalysisParam = param.szAnalysisParam.Replace(Environment.NewLine,""),
                szArsIp = param.szArsIp,
                szCameraID = param.realCameraInfo.szCameraID,
                wArsPort = param.wArsPort,
                cNetStoreDevInfo = new T_IASSDK_REAL_NET_STROE_DEV_INFO
                {
                    dwDevicePort = param.realCameraInfo.dwDevicePort,
                    dwDeviceType = param.realCameraInfo.dwDeviceType,
                    szChannelID = param.realCameraInfo.szChannelID,
                    szDeviceIP = param.realCameraInfo.szDeviceIP,
                    szLoginPwd = param.realCameraInfo.szLoginPwd,
                    szLoginUser = param.realCameraInfo.szLoginUser,
                },
                eAlgthmType = (uint)param.eAlgthmType,
            };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXRealtimeSDKProtocol IasSdk_AddRTAnalysis dwLoginID:{0}"
                +",dwAnalysisPlanID:{1}"
                + ",szAnalysisParam:{2}"
                + ",szArsIp:{3}"
                + ",szCameraID:{4}"
                + ",wArsPort:{5}"
                + ",eAlgthmType:{6}"
                + ",dwDevicePort:{7}"
                + ",dwDeviceType:{8}"
                + ",szChannelID:{9}"
                + ",szDeviceIP:{10}"
                + ",szLoginPwd:{11}"
                + ",szLoginUser:{12}"
                ,dwLoginID
                ,tAnalysisParam.dwAnalysisPlanID
                , tAnalysisParam.szAnalysisParam
                , tAnalysisParam.szArsIp
                , tAnalysisParam.szCameraID
                , tAnalysisParam.wArsPort
                , tAnalysisParam.eAlgthmType
                , tAnalysisParam.cNetStoreDevInfo.dwDevicePort
                , tAnalysisParam.cNetStoreDevInfo.dwDeviceType
                , tAnalysisParam.cNetStoreDevInfo.szChannelID
                , tAnalysisParam.cNetStoreDevInfo.szDeviceIP
                , tAnalysisParam.cNetStoreDevInfo.szLoginPwd
                , tAnalysisParam.cNetStoreDevInfo.szLoginUser
                ));
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_AddRTAnalysis(dwLoginID,tAnalysisParam,out pdwAnalysisID);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_AddRTAnalysis ret:" + retVal + ",pdwAnalysisID:" + pdwAnalysisID);

            return retVal;
        }

        /*===========================================================
        功  能：获取实时分析信息ByID
        参  数：dwLoginID - 登录ID
                pdwAnalysisID - 分析ID
                tAnalysisInfo - 返回分析信息
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public RealAnalyseInfo IasSdk_GetRTAnalysisInfoByID(UInt32 dwLoginID, UInt32 dwAnalysisID)
        {  
            TIASSDK_REAL_ANALYSIS_INFO ptAnalysisInfo = new TIASSDK_REAL_ANALYSIS_INFO();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisInfoByID dwLoginID:" + dwLoginID + ",dwAnalysisID:" + dwAnalysisID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetRTAnalysisInfoByID(dwLoginID,dwAnalysisID,out ptAnalysisInfo);
            RealAnalyseInfo info = null;
            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            info = new RealAnalyseInfo()
            {
                dwAnalysisID = ptAnalysisInfo.dwAnalysisID,
                realAnalyseServerInfo = new RealAnalyseServerUnitInfo()
                {
                    dwServerID = ptAnalysisInfo.dwServerID,
                    szServerIp = ptAnalysisInfo.szServerIp,
                    wServerPort = ptAnalysisInfo.wServerPort,
                    serverType = E_IASSDK_SERVER_UNIT_TYPE.E_IASSDK_ANALYSIS_UNIT_UNKNOW,
                },
                realAnalyseParam = new RealAnalyseParam()
                {
                    dwAnalysisPlanID = ptAnalysisInfo.tAnalysisParam.dwAnalysisPlanID,
                    eAlgthmType = (E_VIDEO_ANALYZE_TYPE)ptAnalysisInfo.tAnalysisParam.eAlgthmType,
                    szAnalysisParam = ptAnalysisInfo.tAnalysisParam.szAnalysisParam,
                    szArsIp = ptAnalysisInfo.tAnalysisParam.szArsIp,
                    wArsPort = ptAnalysisInfo.tAnalysisParam.wArsPort,
                    realCameraInfo = new RealCameraInfo()
                    {
                        dwDevicePort = ptAnalysisInfo.tAnalysisParam.cNetStoreDevInfo.dwDevicePort,
                        dwDeviceType = ptAnalysisInfo.tAnalysisParam.cNetStoreDevInfo.dwDeviceType,
                        szCameraID = ptAnalysisInfo.tAnalysisParam.szCameraID,
                        szChannelID = ptAnalysisInfo.tAnalysisParam.cNetStoreDevInfo.szChannelID,
                        szDeviceIP = ptAnalysisInfo.tAnalysisParam.cNetStoreDevInfo.szDeviceIP,
                        szLoginPwd = ptAnalysisInfo.tAnalysisParam.cNetStoreDevInfo.szLoginPwd,
                        szLoginUser = ptAnalysisInfo.tAnalysisParam.cNetStoreDevInfo.szLoginUser,
                    },
                },
                dwConSerialNum = ptAnalysisInfo.dwConSerialNum,
                eStatusType = (E_IASSDK_REAL_ANALYZE_STATUS_TYPE) ptAnalysisInfo.eStatusType,

            };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisInfoByID ret:{0}"
                +",dwAnalysisID:{1}"
                + ",dwServerID:{2}"
                + ",szServerIp:{3}"
                + ",wServerPort:{4}"
                + ",serverType:{5}"
                + ",dwAnalysisPlanID:{6}"
                + ",eAlgthmType:{7}"
                + ",szAnalysisParam:{8}"
                + ",szArsIp:{9}"
                + ",wArsPort:{10}"
                + ",dwDevicePort:{11}"
                + ",dwDeviceType:{12}"
                + ",szCameraID:{13}"
                + ",szChannelID:{14}"
                + ",szDeviceIP:{15}"
                + ",szLoginPwd:{16}"
                + ",szLoginUser:{17}"
                + ",dwConSerialNum:{18}"
                + ",eStatusType:{19}"
                , retVal
                , info.dwAnalysisID
                , info.realAnalyseServerInfo.dwServerID
                , info.realAnalyseServerInfo.szServerIp
                , info.realAnalyseServerInfo.wServerPort
                , info.realAnalyseServerInfo.serverType
                , info.realAnalyseParam.dwAnalysisPlanID
                , info.realAnalyseParam.eAlgthmType
                , info.realAnalyseParam.szAnalysisParam
                , info.realAnalyseParam.szArsIp
                , info.realAnalyseParam.wArsPort
                , info.realAnalyseParam.realCameraInfo.dwDevicePort
                , info.realAnalyseParam.realCameraInfo.dwDeviceType
                , info.realAnalyseParam.realCameraInfo.szCameraID
                , info.realAnalyseParam.realCameraInfo.szChannelID
                , info.realAnalyseParam.realCameraInfo.szDeviceIP
                , info.realAnalyseParam.realCameraInfo.szLoginPwd
                , info.realAnalyseParam.realCameraInfo.szLoginUser
                , info.dwConSerialNum
                , info.eStatusType
                ));

            return info;
        }

        /*===========================================================
        功  能：获取实时分析数量
        参  数：dwLoginID - 登录ID
                pdwAnalysisNum - 实时分析数量
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 IasSdk_GetRTAnalysisNum(UInt32 dwLoginID, out UInt32 pdwAnalysisNum)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisNum dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetRTAnalysisNum(dwLoginID,out pdwAnalysisNum);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisNum ret:" + retVal + ",pdwAnalysisNum:" + pdwAnalysisNum);
            return retVal;
        }

        /*===========================================================
        功  能：获取实时分析信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwAnalysisNum - 返回实际得到的分析数量
                ptAnalysisInfo - 返回分析信息指针
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public List<RealAnalyseInfo> IasSdk_GetRTAnalysisList(UInt32 dwLoginID, UInt32 dwMaxNum)
        {
            UInt32 pdwAnalysisNum=0;
            IntPtr ptAnalysisInfo = Marshal.AllocHGlobal((int)(Marshal.SizeOf(typeof(TIASSDK_REAL_ANALYSIS_INFO)) * dwMaxNum)); /*OUT TIASSDK_REAL_ANALYSIS_INFO * */

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisList dwLoginID:" + dwLoginID + ",dwMaxNum:" + dwMaxNum);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetRTAnalysisList(dwLoginID,  dwMaxNum, out  pdwAnalysisNum,  ptAnalysisInfo);
            List<RealAnalyseInfo> infolist = new List<RealAnalyseInfo>();
            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }
            for (int i = 0; i < pdwAnalysisNum; i++)
            {
                TIASSDK_REAL_ANALYSIS_INFO temp = (TIASSDK_REAL_ANALYSIS_INFO)Marshal.PtrToStructure(ptAnalysisInfo + i * Marshal.SizeOf(typeof(TIASSDK_REAL_ANALYSIS_INFO)), typeof(TIASSDK_REAL_ANALYSIS_INFO));
                RealAnalyseInfo info = new RealAnalyseInfo()
                {
                    dwAnalysisID = temp.dwAnalysisID,
                    realAnalyseServerInfo = new RealAnalyseServerUnitInfo()
                    {
                        dwServerID = temp.dwServerID,
                        szServerIp = temp.szServerIp,
                        wServerPort = temp.wServerPort,
                        serverType = E_IASSDK_SERVER_UNIT_TYPE.E_IASSDK_ANALYSIS_UNIT_UNKNOW,
                    },
                    realAnalyseParam = new RealAnalyseParam()
                    {
                        dwAnalysisPlanID = temp.tAnalysisParam.dwAnalysisPlanID,
                        eAlgthmType = (E_VIDEO_ANALYZE_TYPE)temp.tAnalysisParam.eAlgthmType,
                        szAnalysisParam = temp.tAnalysisParam.szAnalysisParam,
                        szArsIp = temp.tAnalysisParam.szArsIp,
                        wArsPort = temp.tAnalysisParam.wArsPort,
                        realCameraInfo = new RealCameraInfo()
                        {
                            dwDevicePort = temp.tAnalysisParam.cNetStoreDevInfo.dwDevicePort,
                            dwDeviceType = temp.tAnalysisParam.cNetStoreDevInfo.dwDeviceType,
                            szCameraID = temp.tAnalysisParam.szCameraID,
                            szChannelID = temp.tAnalysisParam.cNetStoreDevInfo.szChannelID,
                            szDeviceIP = temp.tAnalysisParam.cNetStoreDevInfo.szDeviceIP,
                            szLoginPwd = temp.tAnalysisParam.cNetStoreDevInfo.szLoginPwd,
                            szLoginUser = temp.tAnalysisParam.cNetStoreDevInfo.szLoginUser,
                        },
                    },
                    dwConSerialNum = temp.dwConSerialNum,
                    eStatusType = (E_IASSDK_REAL_ANALYZE_STATUS_TYPE)temp.eStatusType,

                };
                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisList [{0}]"
    + ",dwAnalysisID:{1}"
    + ",dwServerID:{2}"
    + ",szServerIp:{3}"
    + ",wServerPort:{4}"
    + ",serverType:{5}"
    + ",dwAnalysisPlanID:{6}"
    + ",eAlgthmType:{7}"
    + ",szAnalysisParam:{8}"
    + ",szArsIp:{9}"
    + ",wArsPort:{10}"
    + ",dwDevicePort:{11}"
    + ",dwDeviceType:{12}"
    + ",szCameraID:{13}"
    + ",szChannelID:{14}"
    + ",szDeviceIP:{15}"
    + ",szLoginPwd:{16}"
    + ",szLoginUser:{17}"
    + ",dwConSerialNum:{18}"
    + ",eStatusType:{19}"
    , i
    , info.dwAnalysisID
    , info.realAnalyseServerInfo.dwServerID
    , info.realAnalyseServerInfo.szServerIp
    , info.realAnalyseServerInfo.wServerPort
    , info.realAnalyseServerInfo.serverType
    , info.realAnalyseParam.dwAnalysisPlanID
    , info.realAnalyseParam.eAlgthmType
    , info.realAnalyseParam.szAnalysisParam
    , info.realAnalyseParam.szArsIp
    , info.realAnalyseParam.wArsPort
    , info.realAnalyseParam.realCameraInfo.dwDevicePort
    , info.realAnalyseParam.realCameraInfo.dwDeviceType
    , info.realAnalyseParam.realCameraInfo.szCameraID
    , info.realAnalyseParam.realCameraInfo.szChannelID
    , info.realAnalyseParam.realCameraInfo.szDeviceIP
    , info.realAnalyseParam.realCameraInfo.szLoginPwd
    , info.realAnalyseParam.realCameraInfo.szLoginUser
    , info.dwConSerialNum
    , info.eStatusType
    ));

                infolist.Add(info);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisList ret:" + retVal);
            return infolist;
        }

        /*===========================================================
        功  能：获取实时分析状态
        参  数：dwLoginID - 登陆ID，IasSdk_Login的返回值
                dwAnalysisID - 分析ID
                pdwStatus - 分析状态
        返回值：成功返回IASSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 IasSdk_GetRTAnalysisStatus(UInt32 dwLoginID, UInt32 dwAnalysisID, out E_IASSDK_REAL_ANALYZE_STATUS_TYPE pdwStatus)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisStatus dwLoginID:" + dwLoginID + ",dwAnalysisID:" + dwAnalysisID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_GetRTAnalysisStatus(dwLoginID,  dwAnalysisID, out  pdwStatus);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_GetRTAnalysisStatus ret:" + retVal + ",pdwStatus:" + pdwStatus);
            return retVal;
        }

        //删除分析
        public bool IasSdk_DelAnalysis(UInt32 dwLoginID, UInt32 dwAnalysisID)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_DelAnalysis dwLoginID:" + dwLoginID + ",dwAnalysisID:" + dwAnalysisID);
            UInt32 retVal = IVXRealtimeSDKProtocol.IasSdk_DelAnalysis(dwLoginID,  dwAnalysisID);

            if (retVal > 0)
            {
                IAS_CheckError(retVal);
            }
            System.Threading.Thread.Sleep(1000);
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRealtimeSDKProtocol IasSdk_DelAnalysis ret:" + retVal);
            return retVal==0;
        }


        #endregion
    }
}
