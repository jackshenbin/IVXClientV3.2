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
    //音视频流回调函数（dwDataType参见EDIO_STRMDATA_TYPE）
    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
internal unsafe delegate Int32 LPSTRMCALLBACK(UInt32 dwStrmId,UInt32 dwDataType,IntPtr pData,Int32 nDataLen,IntPtr pUserContext);

//异常回调函数（dwExceptionType参见EDIO_EXCEPTION_TYPE, dwId由异常的类型确定，如LoginId，StrmId等）
[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
internal unsafe delegate void LPEXCEPTIONCALLBACK(UInt32 dwId, UInt32 dwExceptionType, IntPtr pUserContext);

    #endregion

    internal partial class IVXDIOSDKProtocol
    {
        

        //BOOL b_s_l, TRUE表示为远程sip_server； FALSE表示为本地sip_server
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOInit();//没有返回值

        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOUninit();//没有返回值

        //版本信息包含dio、gbpcsdk及大华SDK的版本，字符串长度推荐为256
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOGetVer(string total_ver);

        /** 
         * 功能：获取错误码描述信息
         * 参数：
         * dwErrCode: 错误码
         * szErrInfo：错误描述信息（输出参数），调用时传递字符数组char ErrInfo[256]
         * 返回值：无
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DIOGetErrInfo(uint dwErrCode, IntPtr ErrInfo);

        // 	登录大华等设备或平台，注意loginid
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOLoginDevice(uint eConnType,
            string DevIp,
            ushort DevPort,
            string UserName,
            string Passwd,
            uint dwTimeout,
            out uint LoginId);//多次登录

        /**
         * 功能：登出第三方设备/平台
         * 参数：
         * dwLoginId：登录ID
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOLogoutDevice(UInt32 dwLoginId);


        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOCreateQueryChannelList(UInt32 dwQueryChnLstHandle, out UInt32 pdwQueryChnLstHandle);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOGetNextChannelInfo(UInt32 dwQueryChnLstHandle, out TDIO_ChannelInfo ptChannelInfo, out UInt32 pdwQueryOverFlag);

        //关闭设备通道查询
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOCloseQueryChannelList(UInt32 loginHandle);


        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOCreateQueryStrmFilesList(UInt32 loginHandle, string pChannelId, ref TDIO_QueryFileCondition tFileCondition, out UInt32 pdwQueryStrmFilesHandle);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOGetNextFileInfo(UInt32 dwQueryStrmFilesHandle, out TDIO_StrmFileInfo ptFileInfo, out UInt32 pdwQueryOverFlag);

        //关闭设备通道查询
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOCloseQueryStrmFilesList(UInt32 dwQueryStrmFilesHandle);

        //实时视频播放 
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIORealPlay(UInt32 lLoginHandle, string pChannelId,UInt32 dwStrmType, UInt32 hWnd, LPSTRMCALLBACK fCallback,IntPtr pUserContext,out UInt32 pdwRealStrmId);

        //关闭平台视频点播(含实时视频点播) 
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOCloseRealStrm(UInt32 pdwRealStrmId); 

        //关闭平台视频点播(含实时视频点播) 
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIORealGrabPicture( UInt32 dwRealStrmId,string pPicSaveFile, UInt32 dwPicFileType );

        /************************************************************************/
        /* 跟异常回调有关的接口函数                                             */
        /************************************************************************/
        /**
         * 功能：设置异常回调函数（当有底层有异常时能及时通知上层）
         * 参数：
         * dwLoginId：登录ID
         * fCallback：异常回调函数
         * pUserContext：用户上下文
         * 返回值：DIO_OK成功，非DIO_OK失败
         */
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 DIOSetExceptionCallbackFun(LPEXCEPTIONCALLBACK fCallback, IntPtr pUserContext);


    }


    public partial class IVXRealtimeProtocol
    {

        #region sio

        public uint DIOInit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmInit ");
            UInt32 retVal = IVXDIOSDKProtocol.DIOInit();
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
            UInt32 retVal = IVXDIOSDKProtocol.DIOUninit();
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
            UInt32 retVal = IVXDIOSDKProtocol.DIOLoginDevice(dwConnType, pIp, uPort, pUser, pPassword,5000, out pdwLoginId);

                if (retVal > 0)
                {
                    pdwLoginId = 0;
                    DIO_GetError(retVal);
                }

                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmLogin ret:" + retVal + ",pdwLoginId:" + pdwLoginId);
                return retVal;
        }

        public uint DIOLogoutDevice(uint dwLoginId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol DIOLogoutDevice pdwLoginId:" + dwLoginId);
            UInt32 retVal = IVXDIOSDKProtocol.DIOLogoutDevice(dwLoginId);

            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol DIOLogoutDevice ret:" + retVal);
            return retVal;

        }

        public List<TDIO_ChannelInfo> DIOQueryChannelList(uint loginid,string devname="")
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetChlInfo loginid:" + loginid + ",devname:" + devname);
            uint pdwQueryChnLstHandle;
            IVXDIOSDKProtocol.DIOCreateQueryChannelList(loginid, out pdwQueryChnLstHandle);
            List<TDIO_ChannelInfo> ret = new List<TDIO_ChannelInfo>();
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                TDIO_ChannelInfo info = new TDIO_ChannelInfo();
                uint pdwQueryOverFlag;
                IVXDIOSDKProtocol.DIOGetNextChannelInfo(pdwQueryChnLstHandle, out info, out pdwQueryOverFlag);

                if (pdwQueryOverFlag == 0)
                    break;
                else
                {
                    info.szRest = loginid.ToString();
                    ret.Add(info);
                    sb.AppendLine("szChannelId:" + info.szChannelId + ",szChannelName:" + info.szChannelName + ",szRest:" + info.szRest);
                }
            }
            IVXDIOSDKProtocol.DIOCloseQueryChannelList(pdwQueryChnLstHandle);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetChlInfo ret:" + 0 + ",list:" + sb.ToString());
            return ret;

        }

        public List<TDIO_StrmFileInfo> DIOQueryFileList(uint loginid, string pChannelId, DateTime st, DateTime et)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetVideoInfo loginid:" + loginid + ",pChannelId:" + pChannelId + ",st:" + st.ToString("yyyyMMddHHmmss") + ",et:" + et.ToString("yyyyMMddHHmmss"));
            uint pdwQueryStrmFilesHandle;
            TDIO_QueryFileCondition query = new TDIO_QueryFileCondition()
            {
                tStart = DataModel.Common.ConvertLinuxTime(st),
                tStop = DataModel.Common.ConvertLinuxTime(et),
                szRest = "",
            };
            UInt32 retVal = IVXDIOSDKProtocol.DIOCreateQueryStrmFilesList(loginid, pChannelId, ref query, out pdwQueryStrmFilesHandle);
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }
            List<TDIO_StrmFileInfo> ret = new List<TDIO_StrmFileInfo>();
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                TDIO_StrmFileInfo info = new TDIO_StrmFileInfo();
                uint pdwQueryOverFlag;
                IVXDIOSDKProtocol.DIOGetNextFileInfo(pdwQueryStrmFilesHandle, out info, out pdwQueryOverFlag);

                if (pdwQueryOverFlag == 0)
                    break;
                else
                {
                    ret.Add(info);
                    sb.AppendLine("qwFileSize:" + info.qwFileSize + ",tStart:" + info.tStart + ",tStop:" + info.tStop + ",szRest:" + info.szRest);
                }
            }
            IVXDIOSDKProtocol.DIOCloseQueryStrmFilesList(pdwQueryStrmFilesHandle);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGetVideoInfo ret:" + 0 + ",list:" + sb.ToString());
            return ret;


        }

        public uint DIOStartRealPlayStrm(uint loginid, string pChannelId,IntPtr hWnd, out UInt32 pdwRealStrmId)
        {
            m_LPSTRMCALLBACK = OnLPSTRMCALLBACK;
            if (pChannelId.Contains(" "))
                pChannelId = pChannelId.Substring(pChannelId.LastIndexOf(' ') + 1);
            IntPtr userContext = Marshal.AllocHGlobal(4);
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStartPlay loginid:" + loginid + ",pChannelId:" + pChannelId + ",hWnd:" + hWnd.ToInt64());
            UInt32 retVal = IVXDIOSDKProtocol.DIORealPlay(loginid, pChannelId,0, (uint)hWnd.ToInt32(), m_LPSTRMCALLBACK, userContext, out pdwRealStrmId);
            if (retVal > 0)
            {
                DIO_GetError((uint)retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStartPlay ret:" + retVal + ",pdwRealStrmId:" + pdwRealStrmId);
            return (uint)retVal;

        }



        public  uint DIOCloseStrm(UInt32 dwStrmId)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStop dwStrmId:" + dwStrmId);
            UInt32 retVal = IVXDIOSDKProtocol.DIOCloseRealStrm(dwStrmId);

            if (retVal > 0)
            {
                DIO_GetError((uint)retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmRealStop ret:" + retVal);
            return retVal;

        }



        public  System.Drawing.Image DIOSnapPictureEx(UInt32 dwStrmId)
        {

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGrabPictureData dwStrmId:" + dwStrmId);

            string tempfile = System.IO.Path.GetTempFileName();
            uint retVal = IVXDIOSDKProtocol.DIORealGrabPicture(dwStrmId, tempfile, 0);
            if (retVal > 0)
            {
                DIO_GetError(retVal);
            }


            System.Drawing.Image img = Image.FromFile(tempfile);
            if (img != null)
            {
                System.IO.File.Delete(tempfile);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXStreamIOSDKProtocol StrmGrabPictureData ret:" + 0);

            return img;



        }
        public string GetErrInfo(uint errCode)
        {
            IntPtr str = Marshal.AllocHGlobal(256);
            IVXDIOSDKProtocol.DIOGetErrInfo(errCode, str);
            string ret = Marshal.PtrToStringAnsi(str);

            return ret;
        }

        public bool GetPlayResolution(UInt64 dwStrmId, out UInt32 pdwWidth, out UInt32 pdwHeight)
        {
            //MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXStreamIOSDKProtocol StrmGetResolution dwStrmId:{0}"
            //    , dwStrmId
            //    ));
            pdwWidth = 1920;
            pdwHeight = 1080;
            //uint retVal = IVXStreamIOSDKProtocol.StrmGetResolution(dwStrmId, out  pdwWidth, out pdwHeight);
            //if (retVal>0)
            //{
            //    // 调用失败，抛异常
            //    DIO_GetError(retVal);
            //}


            //MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXStreamIOSDKProtocol StrmGetResolution ret:{0}"
            //    + ",pdwWidth:{1}"
            //    + ",pdwHeight:{2}"
            //    , retVal
            //    , pdwWidth
            //    , pdwHeight
            //    ));
            //return retVal>0;
            return true;
        }
        #endregion
    }
}
