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

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_VERSION_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_VERSION_LEN)]
        public string szVersion;
    };

    //登陆信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_LOGIN_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_IPADDR_LEN)]
        public string szIp; //服务端IP地址
        public UInt16 wPort;						//服务端端口
    };
    //合成模板参数
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_TEMPLATE_PARAM
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_DESCRIPTION_LEN)]
        public string szTemplateDescription; //合成模板描述
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_TEMPLATE_LEN)]
        public string szTemplateContent;     // 合成模板数据内容
    };

    // 合成模板信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_TEMPLATE_INFO
    {
        public UInt32 dwTemplateHandle;				//合成模板编号
        public TADPSSDK_TEMPLATE_PARAM tTemplateParam; //合成模板参数
    };

    //处理事件参数
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_PROCESS_EVENT_PARAM
    {
        public UInt32 dwTaskUnitID;					//任务单元ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_NAME_LEN)]
        public string szCameraID;	//相机ID
        public UInt32 dwAnalyseType;					//算法类型 
        public UInt32 dwTaskType;						//任务类型
        public UInt32 dwMergeStyle;					//合图方式
        public UInt32 dwStoreStyle;					//存储方式 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_IPADDR_LEN)]
        public string szReceiveIp;//事件接收IP
        public UInt16 wReceivePort;					//事件接收端口
        public UInt32 dwProtocolType;					//转发协议
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_IPADDR_LEN)]
        public string szServerIp;	//事件处理IP(网络字节序)
        public UInt16 wServerPort;						//事件处理端口
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_DESCRIPTION_LEN)]
        public string szDescription; //描述
    };

    //处理事件信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_PROCESS_EVENT_INFO
    {
        public UInt32 dwEventID;							//事件ID
        public TADPSSDK_PROCESS_EVENT_PARAM tEventParam;	//事件参数
        public UInt32 eStatusType;							//服务状态
    };

    //处理节点信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_PROCESS_UNIT_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_IPADDR_LEN)]
        public string szArsIp;	//分析执行节点IP
        public UInt16 wArsPort;						//分析执行节点端口
    };

    //服务单元参数
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_SERVER_UNIT_PARAM
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_IPADDR_LEN)]
        public string szArsIp;	//分析执行节点IP
        public UInt16 wArsPort;						//分析执行节点端口
        public E_ADPSSDK_SERVER_UNIT_TYPE wServerType;						//服务单元类型
        public UInt16 wIsUsed;							//是否启用
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.ADPSSDK_MAX_DESCRIPTION_LEN)]
        public string szDescription; //服务器描述
    };

    //服务单元信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TADPSSDK_SERVER_UNIT_INFO
    {
        public UInt32 dwServerUnitID;							//服务单元ID
        public TADPSSDK_SERVER_UNIT_PARAM tServerUnitParam;	//服务单元参数
    };
    #endregion


    #region 回调定义
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void TAdpsSdk_DisConnectNtfCB(UInt32 dwLoginID, UInt64 qwContext);

    #endregion

    internal partial class IVXAdpsSDKProtocol
    {
        #region 实时分析计划接口


        /************************************************************************
         ** 初始化和连接接口
         ***********************************************************************/
        //初始化
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_Init();
        //反初始化
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_UnInit();

        //获取SDK的版本信息
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetSdkVersion(out TADPSSDK_VERSION_INFO cServerVersion);
        //获取错误码描述
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern string AdpsSdk_GetErrorMsg(UInt32 dwErrCode);

        /*===========================================================
        功  能：注册状态回调函数
        参  数：
		        pFuncDisConnectNtf - 断开连接通知回调函数
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_RegisterCallBack(TAdpsSdk_DisConnectNtfCB pFuncDisConnectNtf, UInt64 qwContext);

        /*===========================================================
        功  能：登陆请求
        参  数：tLogInfo - 服务端登录信息
                dwTimeoutS - 超时时间（秒）
                qwContext - 回调上下文
                pdwLoginID - 返回登录ID
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_Login(TADPSSDK_LOGIN_INFO tLogInfo, UInt32 dwTimeoutS,
                                      UInt64 qwContext, out UInt32 pdwLoginID);

        /*===========================================================
        功  能：注销登陆
        参  数：dwLoginID - 登陆ID，AdpsSdk_Login的返回值
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_Logout(UInt32 dwLoginID);

        /*===========================================================
        功  能：获取服务器的版本
        参  数：dwLoginID - 登陆ID
                cServerVersion - 版本字符串
        返回值：版本字符串，失败返回NULL
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetServerVersion(UInt32 dwLoginID,out TADPSSDK_VERSION_INFO cServerVersion);

        /*===========================================================
        功  能：获取数据处理节点
        参  数：dwLoginID - 登陆ID
                ptProcessUnitInfo - 服务器能力
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetProcessUnitInfo(UInt32 dwLoginID, out  TADPSSDK_PROCESS_UNIT_INFO ptProcessUnitInfo);

        /*=========================================================================================
        事件相关
        =========================================================================================*/
        /*===========================================================
        功  能：添加事件信息
        参  数：dwLoginID - 登录ID
                tEventParam - 事件参数
                pdwEventHandle - 返回事件句柄
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_AddProcessEvent(UInt32 dwLoginID, TADPSSDK_PROCESS_EVENT_PARAM tProcessEventParam, out UInt32 pdwProcessEventHandle);


        /*===========================================================
        功  能：修改事件信息
        参  数：dwLoginID - 登录ID
		        dwProcessEventHandle - 事件句柄
		        tProcessEventParam - 事件参数
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_UpdateProcessEvent(UInt32 dwLoginID, UInt32 dwProcessEventHandle, TADPSSDK_PROCESS_EVENT_PARAM tProcessEventParam);
        /*===========================================================
        功  能：获取事件信息ByID
        参  数：dwLoginID - 登录ID
                dwEventHandle - 事件句柄
                ptEventInfo - 返回事件信息
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetProcessEventInfoByID(UInt32 dwLoginID, UInt32 dwProcessEventHandle, out TADPSSDK_PROCESS_EVENT_INFO ptProcessEventInfo);

        /*===========================================================
        功  能：获取事件信息数量
        参  数：dwLoginID - 登录ID
                pdwProcessEventNum - 事件信息数量
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetProcessEventNum(UInt32 dwLoginID, out UInt32 pdwProcessEventNum);

        /*===========================================================
        功  能：获取事件信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwProcessEventNum - 返回实际得到的事件信息数量
                ptProcessEventInfo - 返回事件信息指针
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetProcessEventList(UInt32 dwLoginID, UInt32 dwMaxNum, out UInt32 pdwProcessEventNum, /*OUT TADPSSDK_PROCESS_EVENT_INFO * */IntPtr ptProcessEventInfo);

        /*===========================================================
        功  能：获取事件信息状态
        参  数：dwLoginID - 登陆ID
                dwProcessEventHandle - 事件ID
                pdwStatus - 事件状态
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetProcessEventStatus(UInt32 dwLoginID, UInt32 dwProcessEventHandle, out UInt32 pdwStatus);

        //删除事件信息
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_DelProcessEvent(UInt32 dwLoginID, UInt32 dwProcessEventHandle);

        /*=========================================================================================
        服务单元相关
        =========================================================================================*/
        /*===========================================================
        功  能：增加服务单元（执行节点）
        参  数：dwLoginID - 登陆ID，AdpsSdk_Login的返回值
                tServerUnitParam - 服务单元参数
                pdwServerUnitID - 输出服务单元ID
        返回值：版本字符串，失败返回0
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_AddServerUnit(UInt32 dwLoginID, TADPSSDK_SERVER_UNIT_PARAM tServerUnitParam, out UInt32 pdwServerUnitID);

        /*===========================================================
        功  能：删除服务单元（执行节点）
        参  数：dwLoginID - 登陆ID，AdpsSdk_Login的返回值
                dwServerUnitID - 服务单元ID
        返回值：版本字符串，失败返回0
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_DelServerUnit(UInt32 dwLoginID, UInt32 dwServerUnitID);

        /*===========================================================
        功  能：获取服务单元ByID
        参  数：dwLoginID - 登录ID
                dwServerUnitID - 服务单元ID
                tServerUnitInfo - 返回服务单元信息
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetServerUnitByID(UInt32 dwLoginID, UInt32 dwServerUnitID, out TADPSSDK_SERVER_UNIT_INFO ptServerUnitInfo);

        /*===========================================================
        功  能：获取服务单元数量
        参  数：dwLoginID - 登录ID
                pdwServerUnitNum - 服务单元数量
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetServerUnitNum(UInt32 dwLoginID, out UInt32 pdwServerUnitNum);

        /*===========================================================
        功  能：获取服务单元信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwServerUnitNum - 返回实际得到的数量
                tServerUnitInfo - 返回服务单元信息指针
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetServerUnitList(UInt32 dwLoginID, UInt32 dwMaxNum, out UInt32 pdwServerUnitNum, /*OUT TADPSSDK_SERVER_UNIT_INFO * */IntPtr ptServerUnitInfo);




        /*=========================================================================================
        合成模板相关
        =========================================================================================*/
        /*===========================================================
        功  能：添加模板信息
        参  数：dwLoginID - 登录ID
                tTemplateParam - 模板参数
                pdwTemplateHandle - 返回模板句柄
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_AddTemplate(UInt32 dwLoginID, TADPSSDK_TEMPLATE_PARAM tTemplateParam, out UInt32 pdwTemplateHandle);

        /*===========================================================
        功  能：修改模板信息
        参  数：dwLoginID - 登录ID
                dwTemplateHandle - 模板句柄
                tTemplateParam - 模板参数
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_UpdateTemplate(UInt32 dwLoginID, UInt32 dwTemplateHandle, TADPSSDK_TEMPLATE_PARAM tTemplateParam);

        /*===========================================================
        功  能：获取模板信息ByID
        参  数：dwLoginID - 登录ID
                dwTemplateHandle - 模板句柄
                ptTemplateInfo - 返回模板信息
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetTemplateInfoByID(UInt32 dwLoginID, UInt32 dwTemplateHandle, out TADPSSDK_TEMPLATE_INFO ptTemplateInfo);

        /*===========================================================
        功  能：获取模板信息数量
        参  数：dwLoginID - 登录ID
                pdwTemplateNum - 模板信息数量
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetTemplateNum(UInt32 dwLoginID, out UInt32 pdwTemplateNum);

        /*===========================================================
        功  能：获取模板信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwTemplateNum - 返回实际得到的模板信息数量
                ptTemplateInfo - 返回模板信息指针
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_GetTemplateList(UInt32 dwLoginID, UInt32 dwMaxNum, out UInt32 pdwTemplateNum, /*OUT TADPSSDK_TEMPLATE_INFO * */IntPtr ptTemplateInfo);

        //删除模板信息
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 AdpsSdk_DelTemplate(UInt32 dwLoginID, UInt32 dwTemplateHandle);
        #endregion

    }

    public partial class IVXRealtimeProtocol
    {
        #region 实时分析计划接口



        //初始化
        public bool AdpsSdk_Init()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_Init ");
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_Init();

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_Init ret:" + retVal);
            return retVal == 0;
        }
        //反初始化
        public bool AdpsSdk_UnInit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_UnInit ");
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_UnInit();

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_UnInit ret:" + retVal);
            return retVal == 0;
        }

        //获取SDK的版本信息
        public string AdpsSdk_GetSdkVersion()
        {
            TADPSSDK_VERSION_INFO cServerVersion = new TADPSSDK_VERSION_INFO() {  szVersion = "0.0.0.0"};
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetSdkVersion ");
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetSdkVersion(out cServerVersion);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetSdkVersion ret:" + retVal + ",cServerVersion:" + cServerVersion);
            return cServerVersion.szVersion;
        }

        //获取错误码描述
        public string AdpsSdk_GetErrorMsg(UInt32 dwErrCode)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetErrorMsg dwErrCode: " + dwErrCode);
            string retVal = IVXAdpsSDKProtocol.AdpsSdk_GetErrorMsg(dwErrCode);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetErrorMsg ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：注册状态回调函数
        参  数：
		        pFuncDisConnectNtf - 断开连接通知回调函数
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_RegisterCallBack()
        {

            m_TAdpsSdk_DisConnectNtfCB = OnTAdpsSdk_DisConnectNtfCB;

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_RegisterCallBack ");
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_RegisterCallBack(m_TAdpsSdk_DisConnectNtfCB,0);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_RegisterCallBack ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：登陆请求
        参  数：tLogInfo - 服务端登录信息
                dwTimeoutS - 超时时间（秒）
                qwContext - 回调上下文
                pdwLoginID - 返回登录ID
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_Login(string IP, ushort Port, out UInt32 pdwLoginID)
        {
            TADPSSDK_LOGIN_INFO tLogInfo = new TADPSSDK_LOGIN_INFO() { szIp = IP, wPort = Port };
            UInt32 dwTimeoutS = 30*1000;
            UInt32 qwContext = 0;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_Login szIp:" + IP + ",port:" + Port);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_Login(tLogInfo, dwTimeoutS, qwContext, out pdwLoginID);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_Login ret:" + retVal + ",pdwLoginID:" + pdwLoginID);
            return retVal;
        }

        /*===========================================================
        功  能：注销登陆
        参  数：dwLoginID - 登陆ID，AdpsSdk_Login的返回值
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_Logout(UInt32 dwLoginID)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_Logout dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_Logout(dwLoginID);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_Logout ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：获取服务器的版本
        参  数：dwLoginID - 登陆ID
                cServerVersion - 版本字符串
        返回值：版本字符串，失败返回NULL
        ===========================================================*/
        public string AdpsSdk_GetServerVersion(UInt32 dwLoginID)
        {
            TADPSSDK_VERSION_INFO cServerVersion = new TADPSSDK_VERSION_INFO() { szVersion = "0.0.0.0" };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerVersion dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetServerVersion(dwLoginID, out cServerVersion);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerVersion ret:" + retVal + ",cServerVersion:" + cServerVersion);
            return cServerVersion.szVersion;
        }

        /*===========================================================
        功  能：获取数据处理节点
        参  数：dwLoginID - 登陆ID
                ptProcessUnitInfo - 服务器能力
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public AdpsServerUnitInfo AdpsSdk_GetProcessUnitInfo(UInt32 dwLoginID)
        {
            TADPSSDK_PROCESS_UNIT_INFO ptProcessUnitInfo = new TADPSSDK_PROCESS_UNIT_INFO();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetProcessUnitInfo dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetProcessUnitInfo(dwLoginID, out ptProcessUnitInfo);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            AdpsServerUnitInfo info = new AdpsServerUnitInfo()
            {
                dwServerID = 0,
                szDescription = "",
                szServerIp = ptProcessUnitInfo.szArsIp,
                wIsUsed = 0,
                wServerPort = ptProcessUnitInfo.wArsPort,
                wServerType = 0,
            };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetProcessUnitInfo ret:" + retVal + ",ptProcessUnitInfo.szArsIp:" + ptProcessUnitInfo.szArsIp + ",ptProcessUnitInfo.wArsPort:" + ptProcessUnitInfo.wArsPort);
            return info;

        }

        /*=========================================================================================
        事件相关
        =========================================================================================*/
        /*===========================================================
        功  能：添加事件信息
        参  数：dwLoginID - 登录ID
                tEventParam - 事件参数
                pdwEventHandle - 返回事件句柄
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_AddEvent(UInt32 dwLoginID, AdpsParam param, out UInt32 pdwEventHandle)
        {
            TADPSSDK_PROCESS_EVENT_PARAM tEventParam = new TADPSSDK_PROCESS_EVENT_PARAM()
            {
                dwAnalyseType = param.dwAnalyseType,
                dwMergeStyle = param.dwMergeStyle,
                dwProtocolType = param.dwProtocolType,
                dwStoreStyle = param.dwStoreStyle,
                dwTaskType = param.dwTaskType,
                dwTaskUnitID = param.dwTaskUnitID,
                szCameraID = param.szCameraID,
                szReceiveIp = param.szReceiveIp,
                szServerIp = param.szServerIp,
                wReceivePort = param.wReceivePort,
                wServerPort = param.wServerPort,
            };
            string str = string.Format("dwAnalyseType:{0}"
                + ",dwMergeStyle:{1}"
                + ",dwProtocolType:{2}"
                + ",dwStoreStyle:{3}"
                + ",dwTaskType:{4}"
                + ",dwTaskUnitID:{5}"
                + ",szCameraID:{6}"
                + ",szReceiveIp:{7}"
                + ",wReceivePort:{8}"
                + ",wServerPort:{9}"
                , tEventParam.dwAnalyseType
                , tEventParam.dwMergeStyle
                , tEventParam.dwProtocolType
                , tEventParam.dwStoreStyle
                , tEventParam.dwTaskType
                , tEventParam.dwTaskUnitID
                , tEventParam.szCameraID
                , tEventParam.szReceiveIp
                , tEventParam.wReceivePort
                , tEventParam.wServerPort

                );

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_AddEvent dwLoginID:" + dwLoginID + Environment.NewLine + str);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_AddProcessEvent(dwLoginID, tEventParam, out pdwEventHandle);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_AddEvent ret:" + retVal);
            return retVal;
        }

        public UInt32 AdpsSdk_UpdateEvent(UInt32 dwLoginID, AdpsParam param, UInt32 pdwEventHandle)
        {
            TADPSSDK_PROCESS_EVENT_PARAM tEventParam = new TADPSSDK_PROCESS_EVENT_PARAM()
            {
                dwAnalyseType = param.dwAnalyseType,
                dwMergeStyle = param.dwMergeStyle,
                dwProtocolType = param.dwProtocolType,
                dwStoreStyle = param.dwStoreStyle,
                dwTaskType = param.dwTaskType,
                dwTaskUnitID = param.dwTaskUnitID,
                szCameraID = param.szCameraID,
                szReceiveIp = param.szReceiveIp,
                szServerIp = param.szServerIp,
                wReceivePort = param.wReceivePort,
                wServerPort = param.wServerPort,
            };
            string str = string.Format("dwAnalyseType:{0}"
                + ",dwMergeStyle:{1}"
                + ",dwProtocolType:{2}"
                + ",dwStoreStyle:{3}"
                + ",dwTaskType:{4}"
                + ",dwTaskUnitID:{5}"
                + ",szCameraID:{6}"
                + ",szReceiveIp:{7}"
                + ",wReceivePort:{8}"
                + ",wServerPort:{9}"
                , tEventParam.dwAnalyseType
                , tEventParam.dwMergeStyle
                , tEventParam.dwProtocolType
                , tEventParam.dwStoreStyle
                , tEventParam.dwTaskType
                , tEventParam.dwTaskUnitID
                , tEventParam.szCameraID
                , tEventParam.szReceiveIp
                , tEventParam.wReceivePort
                , tEventParam.wServerPort

                );
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_UpdateEvent dwLoginID:" + dwLoginID + Environment.NewLine + str);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_UpdateProcessEvent(dwLoginID, pdwEventHandle, tEventParam);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_UpdateEvent ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：获取事件信息ByID
        参  数：dwLoginID - 登录ID
                dwEventHandle - 事件句柄
                ptEventInfo - 返回事件信息
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public AdpsInfo AdpsSdk_GetEventInfoByID(UInt32 dwLoginID, UInt32 dwEventHandle)
        {
            TADPSSDK_PROCESS_EVENT_INFO ptEventInfo = new TADPSSDK_PROCESS_EVENT_INFO();

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventInfoByID dwLoginID:" + dwLoginID + ",dwEventHandle:" + dwEventHandle);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetProcessEventInfoByID(dwLoginID, dwEventHandle, out ptEventInfo);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            AdpsInfo info = new AdpsInfo()
            {
                dwEventID = ptEventInfo.dwEventID,
                eStatusType = ptEventInfo.eStatusType,
                tEventParam = new AdpsParam()
                {
                    dwAnalyseType = ptEventInfo.tEventParam.dwAnalyseType,
                    dwMergeStyle = ptEventInfo.tEventParam.dwMergeStyle,
                    dwProtocolType = ptEventInfo.tEventParam.dwProtocolType,
                    dwStoreStyle = ptEventInfo.tEventParam.dwStoreStyle,
                    dwTaskType = ptEventInfo.tEventParam.dwTaskType,
                    dwTaskUnitID = ptEventInfo.tEventParam.dwTaskUnitID,
                    szCameraID = ptEventInfo.tEventParam.szCameraID,
                    szReceiveIp = ptEventInfo.tEventParam.szReceiveIp,
                    szServerIp = ptEventInfo.tEventParam.szServerIp,
                    wReceivePort = ptEventInfo.tEventParam.wReceivePort,
                    wServerPort = ptEventInfo.tEventParam.wServerPort,
                },
            };

            string str = string.Format("dwEventID:{0}"
                + ",eStatusType:{1}"
                + ",dwAnalyseType:{2}"
                + ",dwMergeStyle:{3}"
                + ",dwProtocolType:{4}"
                + ",dwStoreStyle:{5}"
                + ",dwTaskType:{6}"
                + ",dwTaskUnitID:{7}"
                + ",szCameraID:{8}"
                + ",szReceiveIp:{9}"
                + ",wReceivePort:{10}"
                + ",wServerPort:{11}"
                , ptEventInfo.dwEventID
                , ptEventInfo.eStatusType
                , ptEventInfo.tEventParam.dwAnalyseType
                , ptEventInfo.tEventParam.dwMergeStyle
                , ptEventInfo.tEventParam.dwProtocolType
                , ptEventInfo.tEventParam.dwStoreStyle
                , ptEventInfo.tEventParam.dwTaskType
                , ptEventInfo.tEventParam.dwTaskUnitID
                , ptEventInfo.tEventParam.szCameraID
                , ptEventInfo.tEventParam.szReceiveIp
                , ptEventInfo.tEventParam.wReceivePort
                , ptEventInfo.tEventParam.wServerPort

                );

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventInfoByID ret:" + retVal + Environment.NewLine + str);
            return info;
        }

        /*===========================================================
        功  能：获取事件信息数量
        参  数：dwLoginID - 登录ID
                pdwEventNum - 事件信息数量
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_GetEventNum(UInt32 dwLoginID, out UInt32 pdwEventNum)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventNum dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetProcessEventNum(dwLoginID, out pdwEventNum);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventNum ret:" + retVal + ",pdwEventNum:" + pdwEventNum);
            return retVal;
        }

        /*===========================================================
        功  能：获取事件信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwEventNum - 返回实际得到的事件信息数量
                ptEventInfo - 返回事件信息指针
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public List<AdpsInfo> AdpsSdk_GetEventList(UInt32 dwLoginID, UInt32 dwMaxNum)
        {
            UInt32 pdwEventNum = 0;
            /*TADPSSDK_PROCESS_EVENT_INFO * */
            IntPtr ptEventInfo = Marshal.AllocHGlobal((int)(Marshal.SizeOf(typeof(TADPSSDK_PROCESS_EVENT_INFO)) * dwMaxNum));
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventList dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetProcessEventList(dwLoginID, dwMaxNum, out pdwEventNum, ptEventInfo);
            List<AdpsInfo> list = new List<AdpsInfo>();

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            for (int i = 0; i < pdwEventNum; i++)
            {
                TADPSSDK_PROCESS_EVENT_INFO temp = (TADPSSDK_PROCESS_EVENT_INFO)Marshal.PtrToStructure(ptEventInfo + Marshal.SizeOf(typeof(TADPSSDK_PROCESS_EVENT_INFO)) * i, typeof(TADPSSDK_PROCESS_EVENT_INFO));
                AdpsInfo info = new AdpsInfo()
                {
                    dwEventID = temp.dwEventID,
                    eStatusType = temp.eStatusType,
                    tEventParam = new AdpsParam()
                    {
                        dwAnalyseType = temp.tEventParam.dwAnalyseType,
                        dwMergeStyle = temp.tEventParam.dwMergeStyle,
                        dwProtocolType = temp.tEventParam.dwProtocolType,
                        dwStoreStyle = temp.tEventParam.dwStoreStyle,
                        dwTaskType = temp.tEventParam.dwTaskType,
                        dwTaskUnitID = temp.tEventParam.dwTaskUnitID,
                        szCameraID = temp.tEventParam.szCameraID,
                        szReceiveIp = temp.tEventParam.szReceiveIp,
                        szServerIp = temp.tEventParam.szServerIp,
                        wReceivePort = temp.tEventParam.wReceivePort,
                        wServerPort = temp.tEventParam.wServerPort,
                    },
                };

                list.Add(info);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventList ret:" + retVal + ",pdwEventNum:" + pdwEventNum);
            return list;

        }

        /*===========================================================
        功  能：获取事件信息状态
        参  数：dwLoginID - 登陆ID
                dwEventHandle - 事件ID
                pdwStatus - 事件状态
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/

        public UInt32 AdpsSdk_GetEventStatus(UInt32 dwLoginID, UInt32 dwEventHandle, out UInt32 pdwStatus)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventStatus dwLoginID:" + dwLoginID + ",dwEventHandle:" + dwEventHandle);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetProcessEventStatus(dwLoginID, dwEventHandle, out pdwStatus);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetEventStatus ret:" + retVal + ",pdwStatus:" + pdwStatus);
            return retVal;
        }

        //删除事件信息

        public bool AdpsSdk_DelEvent(UInt32 dwLoginID, UInt32 dwEventHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_DelEvent dwLoginID:" + dwLoginID + ",dwEventHandle:" + dwEventHandle);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_DelProcessEvent(dwLoginID, dwEventHandle);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_DelEvent ret:" + retVal);
            return retVal == 0;

        }

        /*=========================================================================================
        服务单元相关
        =========================================================================================*/
        /*===========================================================
        功  能：增加服务单元（执行节点）
        参  数：dwLoginID - 登陆ID，AdpsSdk_Login的返回值
                tServerUnitParam - 服务单元参数
                pdwServerUnitID - 输出服务单元ID
        返回值：版本字符串，失败返回0
        ===========================================================*/

        public UInt32 AdpsSdk_AddServerUnit(UInt32 dwLoginID, AdpsServerUnitInfo info, out UInt32 pdwServerUnitID)
        {
            TADPSSDK_SERVER_UNIT_PARAM tServerUnitParam = new TADPSSDK_SERVER_UNIT_PARAM()
                {
                    szArsIp = info.szServerIp,
                    szDescription = info.szDescription,
                    wArsPort = info.wServerPort,
                    wIsUsed = info.wIsUsed,
                    wServerType = info.wServerType,
                };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_AddServerUnit dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_AddServerUnit(dwLoginID, tServerUnitParam, out pdwServerUnitID);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_AddServerUnit ret:" + retVal + ",pdwServerUnitID:" + pdwServerUnitID);
            return retVal;
        }

        /*===========================================================
        功  能：删除服务单元（执行节点）
        参  数：dwLoginID - 登陆ID，AdpsSdk_Login的返回值
                dwServerUnitID - 服务单元ID
        返回值：版本字符串，失败返回0
        ===========================================================*/

        public UInt32 AdpsSdk_DelServerUnit(UInt32 dwLoginID, UInt32 dwServerUnitID)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_DelServerUnit dwLoginID:" + dwLoginID + ",dwServerUnitID:" + dwServerUnitID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_DelServerUnit(dwLoginID, dwServerUnitID);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_DelServerUnit ret:" + retVal);
            return retVal;
        }

        /*===========================================================
        功  能：获取服务单元ByID
        参  数：dwLoginID - 登录ID
                dwServerUnitID - 服务单元ID
                tServerUnitInfo - 返回服务单元信息
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public AdpsServerUnitInfo AdpsSdk_GetServerUnitByID(UInt32 dwLoginID, UInt32 dwServerUnitID)
        {
            TADPSSDK_SERVER_UNIT_INFO ptServerUnitInfo = new TADPSSDK_SERVER_UNIT_INFO();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerUnitByID dwLoginID:" + dwLoginID + ",dwServerUnitID:" + dwServerUnitID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetServerUnitByID(dwLoginID, dwServerUnitID, out ptServerUnitInfo);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            AdpsServerUnitInfo info = new AdpsServerUnitInfo()
            {
                dwServerID = ptServerUnitInfo.dwServerUnitID,
                szDescription = ptServerUnitInfo.tServerUnitParam.szDescription,
                wServerType = ptServerUnitInfo.tServerUnitParam.wServerType,
                wIsUsed = ptServerUnitInfo.tServerUnitParam.wIsUsed,
                wServerPort = ptServerUnitInfo.tServerUnitParam.wArsPort,
                szServerIp = ptServerUnitInfo.tServerUnitParam.szArsIp,
            };

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerUnitByID ret:" + retVal);
            return info;

        }

        /*===========================================================
        功  能：获取服务单元数量
        参  数：dwLoginID - 登录ID
                pdwServerUnitNum - 服务单元数量
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_GetServerUnitNum(UInt32 dwLoginID, out UInt32 pdwServerUnitNum)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerUnitNum dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetServerUnitNum(dwLoginID, out pdwServerUnitNum);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerUnitNum ret:" + retVal + ",pdwServerUnitNum:" + pdwServerUnitNum);
            return retVal;
        }

        /*===========================================================
        功  能：获取服务单元信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwServerUnitNum - 返回实际得到的数量
                tServerUnitInfo - 返回服务单元信息指针
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public List<AdpsServerUnitInfo> AdpsSdk_GetServerUnitList(UInt32 dwLoginID, UInt32 dwMaxNum)
        {
            UInt32 pdwServerUnitNum = 0;
            /*OUT TADPSSDK_SERVER_UNIT_INFO * */
            IntPtr ptServerUnitInfo = Marshal.AllocHGlobal((int)(Marshal.SizeOf(typeof(TADPSSDK_SERVER_UNIT_INFO)) * dwMaxNum));
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerUnitList dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetServerUnitList(dwLoginID, dwMaxNum, out pdwServerUnitNum, ptServerUnitInfo);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            List<AdpsServerUnitInfo> list = new List<AdpsServerUnitInfo>();
            for (int i = 0; i < pdwServerUnitNum; i++)
            {
                TADPSSDK_SERVER_UNIT_INFO temp = (TADPSSDK_SERVER_UNIT_INFO)Marshal.PtrToStructure(ptServerUnitInfo + Marshal.SizeOf(typeof(TADPSSDK_SERVER_UNIT_INFO)) * i, typeof(TADPSSDK_SERVER_UNIT_INFO));
                AdpsServerUnitInfo info = new AdpsServerUnitInfo()
                {
                    dwServerID = temp.dwServerUnitID,
                    szDescription = temp.tServerUnitParam.szDescription,
                    wServerType = temp.tServerUnitParam.wServerType,
                    wIsUsed = temp.tServerUnitParam.wIsUsed,
                    wServerPort = temp.tServerUnitParam.wArsPort,
                    szServerIp = temp.tServerUnitParam.szArsIp,
                };
                list.Add(info);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetServerUnitList ret:" + retVal + ",pdwServerUnitNum:" + pdwServerUnitNum);
            return list;

        }





        /*=========================================================================================
        合成模板相关
        =========================================================================================*/
        /*===========================================================
        功  能：添加模板信息
        参  数：dwLoginID - 登录ID
                tTemplateParam - 模板参数
                pdwTemplateHandle - 返回模板句柄
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_AddTemplate(UInt32 dwLoginID, string name, string content, out UInt32 pdwTemplateHandle)
        {
            TADPSSDK_TEMPLATE_PARAM tTemplateParam = new TADPSSDK_TEMPLATE_PARAM()
                {
                    szTemplateContent = content,
                    szTemplateDescription = name,
                };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_AddTemplate dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_AddTemplate(dwLoginID, tTemplateParam, out pdwTemplateHandle);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_AddTemplate ret:" + retVal + ",pdwTemplateHandle:" + pdwTemplateHandle);
            return retVal;

        }

        /*===========================================================
        功  能：修改模板信息
        参  数：dwLoginID - 登录ID
                dwTemplateHandle - 模板句柄
                tTemplateParam - 模板参数
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_UpdateTemplate(UInt32 dwLoginID, UInt32 dwTemplateHandle, string name, string content)
        {
                TADPSSDK_TEMPLATE_PARAM tTemplateParam = new TADPSSDK_TEMPLATE_PARAM()
                {
                    szTemplateContent = content,
                    szTemplateDescription = name,
                };
             MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_UpdateTemplate dwLoginID:" + dwLoginID);
             UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_UpdateTemplate(dwLoginID, dwTemplateHandle, tTemplateParam);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_UpdateTemplate ret:" + retVal );
            return retVal;
        }

        /*===========================================================
        功  能：获取模板信息ByID
        参  数：dwLoginID - 登录ID
                dwTemplateHandle - 模板句柄
                ptTemplateInfo - 返回模板信息
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public MergeTemplateInfo AdpsSdk_GetTemplateInfoByID(UInt32 dwLoginID, UInt32 dwTemplateHandle )
        {
            TADPSSDK_TEMPLATE_INFO ptTemplateInfo = new TADPSSDK_TEMPLATE_INFO();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetTemplateInfoByID dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetTemplateInfoByID(dwLoginID, dwTemplateHandle, out ptTemplateInfo);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MergeTemplateInfo info = new MergeTemplateInfo()
            {
                TemplateID = dwTemplateHandle,
                TemplateContent = ptTemplateInfo.tTemplateParam.szTemplateContent,
                TemplateName = ptTemplateInfo.tTemplateParam.szTemplateDescription,
            };

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetTemplateInfoByID ret:" + retVal );
            return info;
        }

        /*===========================================================
        功  能：获取模板信息数量
        参  数：dwLoginID - 登录ID
                pdwTemplateNum - 模板信息数量
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public UInt32 AdpsSdk_GetTemplateNum(UInt32 dwLoginID, out UInt32 pdwTemplateNum)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetTemplateNum dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetTemplateNum(dwLoginID, out pdwTemplateNum);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetTemplateNum ret:" + retVal + ",pdwTemplateNum:" + pdwTemplateNum);
            return retVal;
        }

        /*===========================================================
        功  能：获取模板信息ByNum
        参  数：dwLoginID - 登录ID
                dwMaxNum - 传入需要获取的数量
                pdwTemplateNum - 返回实际得到的模板信息数量
                ptTemplateInfo - 返回模板信息指针
        返回值：成功返回ADPSSDK_OK，失败返回错误码
        ===========================================================*/
        public List<MergeTemplateInfo> AdpsSdk_GetTemplateList(UInt32 dwLoginID, UInt32 dwMaxNum )
        { 
            UInt32 pdwTemplateNum;
            IntPtr ptTemplateInfo = Marshal.AllocHGlobal((int)(Marshal.SizeOf(typeof(TADPSSDK_TEMPLATE_INFO)) * dwMaxNum));
            //TADPSSDK_TEMPLATE_INFO ptTemplateInfo = new TADPSSDK_TEMPLATE_INFO();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetTemplateList dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_GetTemplateList(dwLoginID, dwMaxNum,out pdwTemplateNum, ptTemplateInfo);
            List<MergeTemplateInfo> list = new List<MergeTemplateInfo>();
            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            for (int i = 0; i < pdwTemplateNum; i++)
            {
                TADPSSDK_TEMPLATE_INFO temp = (TADPSSDK_TEMPLATE_INFO)Marshal.PtrToStructure(ptTemplateInfo + Marshal.SizeOf(typeof(TADPSSDK_TEMPLATE_INFO)) * i, typeof(TADPSSDK_TEMPLATE_INFO));
                MergeTemplateInfo info = new MergeTemplateInfo()
                {
                     TemplateID = temp.dwTemplateHandle,
                      TemplateContent = temp.tTemplateParam.szTemplateContent,
                       TemplateName = temp.tTemplateParam.szTemplateDescription,
                };

                list.Add(info);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_GetTemplateList ret:" + retVal);
            return list;
        }

        //删除模板信息
        public UInt32 AdpsSdk_DelTemplate(UInt32 dwLoginID, UInt32 dwTemplateHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_DelTemplate dwLoginID:" + dwLoginID);
            UInt32 retVal = IVXAdpsSDKProtocol.AdpsSdk_DelTemplate(dwLoginID, dwTemplateHandle);

            if (retVal > 0)
            {
                Adps_GetError(retVal);
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXAdpsSDKProtocol AdpsSdk_DelTemplate ret:" + retVal );
            return retVal;
        }


        #endregion
    }
}
