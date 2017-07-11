using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IVX.DataModel;
// using BOCOM.RealtimeProtocol.Model;
using DataModel;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace IVX.Live.ConfigServices.Interop
{
    #region 基本结构体
    	    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GBDevInfo
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string  DevId;
		public int LoginId;
	};

	//通道信息
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CHLSINFO
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string ChlId;	//通道Id（也即相机编号）
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string ChlName;		//通道名（也即相机名）
        public byte Status;							//摄像机使用状态（1-正常;2-停用;3-作废）
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 127)]
        public string Rest;			//保留信息
	};

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
    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    internal unsafe delegate int STATENOTECALLBACK(int iEvent,UInt64 ubiStrm,int wParam,int lParam, IntPtr pParam);

    #endregion

    internal partial class IVXStreamIOSDKProtocol
    {


        //BOOL b_s_l, TRUE表示为远程sip_server； FALSE表示为本地sip_server
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmInit();//没有返回值

        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmUninit();//没有返回值

        //版本信息包含dio、gbpcsdk及大华SDK的版本，字符串长度推荐为256
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetver(IntPtr total_ver);

        /** 
         * 功能：获取错误码描述信息
         * 参数：
         * dwErrCode: 错误码
         * szErrInfo：错误描述信息（输出参数），调用时传递字符数组char ErrInfo[256]
         * 返回值：无
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern void StrmGetErrInfo(uint dwErrCode, IntPtr ErrInfo);

        // 	登录大华等设备或平台，注意loginid
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmLogin(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE eConnType,
            string DevIp,
            ushort DevPort,
            string UserName,
            string Passwd,
            out uint LoginId);//多次登录


        //功能：客户端连接sip服务端
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32	StrmConnect(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE eConnType,
		IntPtr ServerIp,ushort ServerPort,IntPtr RtpRecIp,ushort RtpPort);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetDevNum(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE eConnType, out uint DevNum);
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetDevInfo(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE eConnType, uint DevNum, /* OUT struct GBDevInfo **/ IntPtr DevInfo);
        // 	依据loginid创建通道信息查找各通道
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetChlNum(uint LoginId, out uint ChlNum);
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetChlInfo(uint LoginId, uint ChlNum, /* OUT struct CHLSINFO **/ IntPtr ChlInfo);
        //返回值：0：打开码流失败；非0: 码流ID
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmRealStartPlay(uint LoginId, IntPtr hWnd, string devID, STATENOTECALLBACK fstatecb, IntPtr pUserContext, out UInt64 StrmId);
        /** 
         * 功能：	依据loginid,ChannelId和起始时间QueryCondition查找该设备下的录像数量
         * 参数：
         * LoginId：         唯一指定设备
         * pChannelId：	     通道号
         * ptQueryCondition：查询条件结构体，即查询的起始时间
         * VideoNum：        输出，该设备下所有的录像的数量
         * 返回值：	DIO_OK成功；其他值失败，参见DIO_SUBCLASS_DEF.h中的错误码介绍
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetVideoNum(uint LoginId,
		string pChannelId,
		ref TDIO_QueryFileCondition ptQueryCondition,
		out uint VideoNum);

        /** 
         * 功能：	依据loginid,ChannelId和起始时间QueryCondition查找该设备下的录像信息（即TDIO_QueryFileCondition）
         * 参数：
         * LoginId：         唯一指定设备
         * pChannelId：	     通道号
         * ptQueryCondition：查询条件结构体，即查询的起始时间
         * VideoNum:         查询的录像数量（避免StrmGetVideoNum查询到的数量与实际数量不符）
         * vctStrmFilesInfo：输出，该设备下所有的录像信息
         * 返回值：	DIO_OK成功；其他值失败，参见DIO_SUBCLASS_DEF.h中的错误码介绍
         */
	    [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetVideoInfo(uint LoginId,
		string pChannelId,
		ref TDIO_QueryFileCondition ptQueryCondition,
		uint VideoNum,
		/*out  TDIO_StrmFileInfo * */ IntPtr ptStrmFilesInfo);

        //返回值：0：失败；非0: 成功
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmRealSnap(UInt64 streamID, string pchPicFileName, eSNAP_TYPE eType = eSNAP_TYPE.SNAP_BMP);
        //返回值：0：失败；非0: 成功
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmRealStop(UInt64 streamID);
        //[DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        //public static extern void stream_setyuvcb(UInt64 streamID, void* fCallback);
        //[DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        //public static extern void stream_setrgbcb(UInt64 streamID);

        /**
         * 功能：	获取码流分辨率
         * 参数：
         * StrmId： 唯一指定码流，为StrmRealStart的输出结果
         * pData：	输出，图片内容之buf，由调用者管理内存
         * iLen：	数据大小
         * iType：	数据格式（参见SoftDecDef.h文件sFrameInfo中iType类型定义）
         * iRes：
        * 返回值：	DIO_OK成功；其他值失败，参见DIO_SUBCLASS_DEF.h中的错误码介绍
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGrabPictureData(UInt64 StrmId, IntPtr pData, out Int32 iLen, eSNAP_TYPE eType, int iRes = 0);
        /**
         * 功能：	获取码流分辨率
         * 参数：
         * StrmId：	唯一指定码流，为StrmRealStart的输出结果
         * Width：
         * Height：
         * 返回值：	DIO_OK成功；其他值失败，参见DIO_SUBCLASS_DEF.h中的错误码介绍
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetResolution(UInt64 StrmId,
        out UInt32 Width,
        out UInt32 Height);
        /**
         * 功能：	获取码流帧率
         * 参数：
         * StrmId： 唯一指定码流，为StrmRealStart的输出结果
         * fRate：	帧率，输出值
         * 返回值：	DIO_OK成功；其他值失败，参见DIO_SUBCLASS_DEF.h中的错误码介绍
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 StrmGetFrameRate(UInt64 StrmId, out float fRate);
    }


    public partial class IVXRealtimeProtocol
    {

        #region sio

        public uint DIOInit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmInit ");
            UInt32 retVal = IVXStreamIOSDKProtocol.StrmInit();
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmInit ret:" + 0);
            return 0;

        }

        public uint DIOUninit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmUninit ");
            UInt32 retVal = IVXStreamIOSDKProtocol.StrmUninit();
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmUninit ret:" + 0);
            return 0;

        }

        public uint DIOLoginDevice(uint dwConnType, string pIp,
    ushort uPort, string pUser, string pPassword, uint dwTimeout, out uint pdwLoginId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,string.Format( "IVXStreamIOSDKProtocol StrmLogin dwConnType:{0}"
                +",pIp:{1}"
                +",uPort:{2}"
                +",pUser:{3}"
                +",pPassword:{4}"
                +",dwTimeout:{5}"
                , dwConnType
                , pIp
                , uPort
                , pUser
                , pPassword
                , dwTimeout));
            if ((E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)dwConnType == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL)
            {
                IntPtr ServerIp = Marshal.StringToHGlobalAnsi(pIp);
                IntPtr RtpRecIp = Marshal.StringToHGlobalAnsi("192.168.137.121");
                UInt32 retVal = IVXStreamIOSDKProtocol.StrmConnect((E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)dwConnType, ServerIp, uPort, RtpRecIp,6006);
                pdwLoginId = 1;
                if (retVal > 0)
                {
                    pdwLoginId = 0;
                    DIO_GetError(retVal);
                }

                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmConnect ret:" + retVal + ",pdwLoginId:" + pdwLoginId);
                return retVal;
            }
            else
            {
                UInt32 retVal = IVXStreamIOSDKProtocol.StrmLogin((E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)dwConnType, pIp, uPort, pUser, pPassword, out pdwLoginId);

                if (retVal > 0)
                {
                    pdwLoginId = 0;
                    DIO_GetError(retVal);
                }

                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmLogin ret:" + retVal + ",pdwLoginId:" + pdwLoginId);
                return retVal;
            }
        }

        public uint DIOLogoutDevice(uint dwLoginId)
        {
            //MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol DIOLogoutDevice pdwLoginId:" + dwLoginId);
            UInt32 retVal = 0;// IVXStreamIOSDKProtocol.DIOLogoutDevice(dwLoginId);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            //MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol DIOLogoutDevice ret:" + retVal);
            return retVal;

        }

        public List<GBDevInfo> DIOQueryDeviceList(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE type)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetDevInfo type:" + type);
            IntPtr ptr = Marshal.AllocHGlobal(1000);
            uint ChlNum = 0;
            IVXStreamIOSDKProtocol.StrmGetDevNum(type, out ChlNum);
            IntPtr pchlinfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GBDevInfo)) * (int)ChlNum);
            uint retVal = IVXStreamIOSDKProtocol.StrmGetDevInfo(type, ChlNum, pchlinfo);
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            List<GBDevInfo> ret = new List<GBDevInfo>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ChlNum; i++)
            {
                GBDevInfo temp = (GBDevInfo)Marshal.PtrToStructure(pchlinfo + Marshal.SizeOf(typeof(GBDevInfo)) * i, typeof(GBDevInfo));
                ret.Add(temp);
                sb.AppendLine("DevId:" + temp.DevId + ",LoginId:" + temp.LoginId);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetDevInfo ret:" + 0 + ",list:" + sb.ToString());
            return ret;

        }
        public List<TDIO_ChannelInfo> DIOQueryChannelList(uint loginid,string devname="")
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetChlInfo loginid:" + loginid + ",devname:" + devname);
            IntPtr ptr = Marshal.AllocHGlobal(1000);
            uint ChlNum = 0;
            IVXStreamIOSDKProtocol.StrmGetChlNum(loginid, out ChlNum);
            IntPtr pchlinfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CHLSINFO)) * (int)ChlNum);
            uint retVal = IVXStreamIOSDKProtocol.StrmGetChlInfo(loginid, ChlNum, pchlinfo);
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            List<TDIO_ChannelInfo> ret = new List<TDIO_ChannelInfo>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ChlNum; i++)
            {
                 CHLSINFO temp = (CHLSINFO)Marshal.PtrToStructure(pchlinfo + Marshal.SizeOf(typeof(CHLSINFO)) * i, typeof(CHLSINFO));
                 TDIO_ChannelInfo info = new TDIO_ChannelInfo();
                 info.szChannelId = string.IsNullOrEmpty(devname) ? temp.ChlId : devname + " " + temp.ChlId;
                 info.szChannelName = temp.ChlName;
                 //info.szRest = temp.Rest;
                 info.szRest = loginid.ToString();
                 //if (temp.Status == 1)
                     ret.Add(info);
                     sb.AppendLine("szChannelId:" + info.szChannelId + ",szChannelName:" + info.szChannelName + ",szRest:" + info.szRest);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetChlInfo ret:" + 0 + ",list:" + sb.ToString());
            return ret;

        }

        public List<TDIO_StrmFileInfo> DIOQueryFileList(uint loginid, string pChannelId, DateTime st, DateTime et)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetVideoInfo loginid:" + loginid + ",pChannelId:" + pChannelId + ",st:" + st.ToString("yyyyMMddHHmmss") + ",et:" + et.ToString("yyyyMMddHHmmss"));
            IntPtr ptr = Marshal.AllocHGlobal(1000);
            uint ChlNum = 0;
            TDIO_QueryFileCondition query = new TDIO_QueryFileCondition()
            {
                tStart = DataModel.Common.ConvertLinuxTime(st),
                tStop = DataModel.Common.ConvertLinuxTime(et),
                szRest = "",
            };
            IVXStreamIOSDKProtocol.StrmGetVideoNum(loginid,pChannelId,ref query, out ChlNum);
            IntPtr pchlinfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TDIO_StrmFileInfo)) * (int)ChlNum);
            uint retVal = IVXStreamIOSDKProtocol.StrmGetVideoInfo(loginid,pChannelId,ref query, ChlNum, pchlinfo);
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            List<TDIO_StrmFileInfo> ret = new List<TDIO_StrmFileInfo>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ChlNum; i++)
            {
                TDIO_StrmFileInfo temp = (TDIO_StrmFileInfo)Marshal.PtrToStructure(pchlinfo + Marshal.SizeOf(typeof(TDIO_StrmFileInfo)) * i, typeof(TDIO_StrmFileInfo));
                if (temp.qwFileSize == 0)
                    continue;
                ret.Add(temp);
                sb.AppendLine(string.Format("szFileId:{0},tStart:{1},tStop:{2},qwFileSize:{3}", temp.szFileId, temp.tStart, temp.tStop, temp.qwFileSize));
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetVideoInfo ret:" + 0 + ",list:" + sb.ToString());
            return ret;


        }

        public uint DIOStartRealPlayStrm(uint loginid, string pChannelId,IntPtr hWnd, out UInt64 pdwRealStrmId)
        {
            m_STATENOTECALLBACK = OnSTATENOTECALLBACK;
            if (pChannelId.Contains(" "))
                pChannelId = pChannelId.Substring(pChannelId.LastIndexOf(' ') + 1);
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStartPlay loginid:" + loginid + ",pChannelId:" + pChannelId + ",hWnd:" + hWnd.ToInt64());
            UInt64 retVal = IVXStreamIOSDKProtocol.StrmRealStartPlay(loginid, hWnd, pChannelId, m_STATENOTECALLBACK, IntPtr.Zero, out pdwRealStrmId);
            if (retVal > 0)
            {
                DIO_GetError((uint)retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStartPlay ret:" + retVal + ",pdwRealStrmId:" + pdwRealStrmId);
            return (uint)retVal;

        }



        public  uint DIOCloseStrm(UInt64 dwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStop dwStrmId:" + dwStrmId);
            UInt32 retVal = IVXStreamIOSDKProtocol.StrmRealStop( dwStrmId);

            if (retVal > 0)
            {
                DIO_GetError((uint)retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStop ret:" + retVal);
            return retVal;

        }


        public  uint DIOGetVer(out TDIO_Version ver)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetver ");
            IntPtr version = Marshal.AllocHGlobal(256);
            UInt32 retVal = IVXStreamIOSDKProtocol.StrmGetver(version);


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetver ret:" + 0);
            ver = new TDIO_Version();
            ver.szVer = Marshal.PtrToStringAuto(version);
            return 0;

        }
        public  System.Drawing.Image DIOSnapPictureEx(UInt64 dwStrmId)
        {

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGrabPictureData dwStrmId:" + dwStrmId);


            int buflen = Common.MAX_PIC_DATA_LEN;
            IntPtr picbuf = IntPtr.Zero;
            int picdatalen = 0;

            uint retVal = IVXStreamIOSDKProtocol.StrmGrabPictureData(dwStrmId, picbuf, out picdatalen, eSNAP_TYPE.SNAP_BMP);

            if ( picdatalen > buflen && picdatalen > 0)
            {
                if (picbuf != IntPtr.Zero)
                    Marshal.FreeHGlobal(picbuf);

                buflen = picdatalen;
                picbuf = Marshal.AllocHGlobal((int)buflen);
                picdatalen = 0;
                retVal = IVXStreamIOSDKProtocol.StrmGrabPictureData(dwStrmId, picbuf,out picdatalen, eSNAP_TYPE.SNAP_BMP);

            }

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            System.Drawing.Image img = null;//DataModel.Common.GetImage(picbuf, (int)buflen);
            if (picbuf != IntPtr.Zero)
            {
                img = Common.GetImage(picbuf, (int)buflen);
                Marshal.FreeHGlobal(picbuf);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGrabPictureData ret:" + 0);

            return img;



        }


        public System.Drawing.Image DIOSnapPicture(UInt64 dwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealSnap dwStrmId:" + dwStrmId);
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".bmp";
            UInt32 retVal = IVXStreamIOSDKProtocol.StrmRealSnap(dwStrmId, filename);
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            System.Drawing.Image img = null;
            if (System.IO.File.Exists(filename))
            {
                try
                {
                    Image temp = System.Drawing.Image.FromFile(filename);
                    img = new Bitmap(temp);
                    temp.Dispose();
                }
                catch (Exception ex)
                {
                    MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealSnap error:" + ex.ToString());
                }
                try
                {
                    System.IO.File.Delete(filename);
                }
                catch
                { }
            }
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol DIOSnapPicture ret:" + 0);

            return img;



        }


        public bool GetPlayResolution(UInt64 dwStrmId, out UInt32 pdwWidth, out UInt32 pdwHeight)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXStreamIOSDKProtocol StrmGetResolution dwStrmId:{0}"
                , dwStrmId
                ));

            uint retVal = IVXStreamIOSDKProtocol.StrmGetResolution(dwStrmId, out  pdwWidth, out pdwHeight);
            if (retVal>0)
            {
                // 调用失败，抛异常
                DIO_GetError(retVal);
            }


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXStreamIOSDKProtocol StrmGetResolution ret:{0}"
                + ",pdwWidth:{1}"
                + ",pdwHeight:{2}"
                , retVal
                , pdwWidth
                , pdwHeight
                ));
            return retVal>0;

        }
        #endregion
    }
}
