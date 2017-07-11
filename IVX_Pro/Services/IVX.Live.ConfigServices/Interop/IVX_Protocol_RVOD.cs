using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IVX.DataModel;

using DataModel;
using System.Collections.Generic;
using System.Text;

namespace IVX.Live.ConfigServices.Interop
{
    #region 基本结构体

    //服务器信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TRVODSDK_SERVER_INFO
    {
        public UInt16 wDevPort;				       //端口
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.SDK_MAX_IPADDR_LEN)]
        public string szDevIp; //设备IP地址
    };

    //视频资源详细信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TRVODSDK_VIDEO_INFO
    {
        public UInt32 dwVideoSize;					 //文件大小,暂不使用，预留
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.SDK_FILE_PATH_LEN)]
        public string szVideoPath;//文件路径	
    };

    //点播信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TRVODSDK_PLAYBACK_VOD_INFO
    {
        public UInt32 hPlayWnd;				         //播放窗口的句柄
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.SDK_FILE_PATH_LEN)]
        public string szVideoPath;//文件路径		
        public TRVODSDK_SERVER_INFO tServerInfo;    //服务器信息
    };

    //视频码流信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TRVODSDK_STREAM_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.SDK_FILE_PATH_LEN)]
        public string szVideoPath;//文件详细路径		
        public TRVODSDK_SERVER_INFO tVideoSerInfo;  //文件所在服务器信息(szVideoPath所在的服务器)
    };

    //通用帧信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TGeneralFrameInfo
    {
        public UInt32 dwPayLoad;		//载荷，或者数据类型
        public UInt32 dwFrameId;		//帧序号
        public UInt32 dwFrameRate;	//帧率
        public UInt64 qwTimeStamp;	//时间戳
        public bool bKeyFrame;		//是否关键帧
        public UInt32 dwWidth;		//图像宽
        public UInt32 dwHeight;		//图像高
    };


    //点播帧结构(用于点播传输，播放控制等）
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVodFrame
    {
        public TGeneralFrameInfo tFrameInfo;
        public IntPtr /* char* */ pFrame;      //帧数据，纯码流
        public UInt32 dwFrameLen;   //码流大小
    };

    //点播帧结构(用于点播传输，播放控制等）
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVodFileInfo
    {
        public UInt32 dwTotalFrameNum;	//总帧数
        public UInt64 qwTotalTimeMs;		//总时长（毫秒）
        public UInt32 dwDevType;		//视频文件类型
        public UInt32 dwSubDecType;   //视频子类型

        //以下字段用于适应新的分帧库和解码库
        public UInt32 dwFormat;     //enum eStrmFormat eFormat;
        public UInt32 dwWidth;      //uint32_t	uWidth;
        public UInt32 dwHeight;    //uint32_t	uHeight;
        public UInt32 dwFrameRate;		//帧率  float		fFrameRate;
        public UInt32 dwProfile_idc;   //uint32_t	profile_idc;
        public UInt32 dwLevel_idc;            //uint32_t	level_idc;
        public UInt32 dwUInterlaced;      //uint32_t	uInterlaced;
        public UInt32 dwLog2_max_frame_num;    //uint32_t	log2_max_frame_num;
        public UInt32 dwFrame_mbs_only_flag;     //uint32_t	frame_mbs_only_flag;
        public UInt32 dwFrameLibType;			//int32_t		iRes;	 保留字段,  分帧库的类型（2--ffmpeg 1--bocom 可能还有其他值）如果是ffmpeg或者bocom，需要在inputdata之前调用SetInputStrmInfo
        public bool bValidate;         //bool		bValidate;
    };

    //点播流信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TVodStrmInfo
    {
        public TVodFileInfo tFileInfo;       //文件信息
        public IntPtr /* UINT8*  */ pFileHeaderBuf;   //文件头
        public UInt32 dwHeaderLen;		//文件头长度
    };

    #endregion

    #region 回调定义
    /*===========================================================
功  能：视频码流帧回调
参  数：dwStreamHandle - 码流句柄
		tVodFrame - 视频帧信息
		tFileInfo - 视频文件信息
		dwUserData - 用户数据
===========================================================*/
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void TfuncVideoFrameDataCB(uint dwStreamHandle, TVodFrame tVodFrame, TVodFileInfo tFileInfo, uint dwUserData);
    /*===========================================================
    功  能：视频码流状态回调
    参  数：dwStreamHandle - 码流句柄
            tVodFrame - 视频帧信息
            tFileInfo - 视频文件信息
            dwUserData - 用户数据
    ===========================================================*/
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void TfuncVideoFrameStatusCB(uint dwDispatchId, ERVODSDK_STREAM_STATUS eStatus, uint dwUserData);
    /*===========================================================
    功  能：播放进度回调函数
    参  数：lVodHandle - 播放标示
            dwPlayState - 播放状态，见E_VDA_PLAY_STATUS
            dwPlayProgress - 播放进度，（千分比整数值，801表示80.1%）
            dwCurPlayTime - 当前播放时间（绝对时间）
            dwUserData - 用户数据
    返回值：-1表示失败，其他值表示返回的点播标示值。
    ===========================================================*/
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal unsafe delegate void TfuncPlayPosCB(uint lVodHandle, uint dwPlayState, uint dwPlayProgress, uint dwCurPlayTime, uint dwUserData);

    #endregion

    internal partial class IVXRVODSDKProtocol
    {

        //初始化
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_Init();
        //退出
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_UnInit();
        //获取SDK的版本信息
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern string RvodSdk_GetSdkVersion();
        //获取错误码
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 RvodSdk_GetLastError();
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern string RvodSdk_GetErrorMsg(UInt32 dwErrCode);

        /*===========================================================
        获取服务器视频列表相关接口
        ===========================================================*/
        /*===========================================================
        功  能：获取指定盘符下视频文件个数
        参  数：	ptSearch - 视频查询条件
                pdwQueryHandle - 检索句柄
        返回值：成功返回文件个数，失败返回-1
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 RvodSdk_GetVideoResourceTotalNum(ref TRVODSDK_SERVER_INFO ptServer, out UInt32 pdwQueryHandle);

        /*===========================================================
        功  能：查询下一个视频资源信息（遍历接口）
        参  数：lQueryHandle - 查询标示值
                ptVideoInfo - 视频文件信息
        返回值：成功返回TRUE，失败返回FALSE。
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_QueryNextVideoResource(UInt32 lQueryHandle, out TRVODSDK_VIDEO_INFO ptVideoInfo);

        /*===========================================================
        功  能：关闭视频资源查询查询
        参  数：lQueryHandle 查询标示值
        返回值：成功返回TRUE，失败返回FALSE。
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_CloseVideoResourceQuery(UInt32 lQueryHandle);


        /*===========================================================
        视频点播相关接口
        ===========================================================*/
        /*===========================================================
        功  能：点播视频
        参  数：ptVodInfo - 点播信息
                pfuncPlayPos - 进度回调函数，传Null标示不需要回调进度
                dwUserData - 用户数据
        返回值：-1表示失败，其他值表示返回的点播标示值。
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 RvodSdk_PlayBackVideo(ref TRVODSDK_PLAYBACK_VOD_INFO ptVodInfo, TfuncPlayPosCB pfuncPlayPos, UInt32 dwUserData);
        /*===========================================================
        功  能：播放控制
        参  数：lVodHandle - 点播标示句柄
                dwControlCode - 播放控制类型，见E_VDA_PLAYCTRL_TYPE定义
                dwInValue - 播放控制输入参数
                pdwOutValue - 播放控制输出参数，如获取的进度等
        返回值：成功返回TRUE，失败返回FALSE
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_PlayBackControl(UInt32 lVodHandle, UInt32 dwControlCode, UInt32 dwInValue, out UInt32 pdwOutValue);
        /*===========================================================
        功  能：抓图并获取数据
        参  数：lVodHandle - 点播标示句柄
                dwPicType - 抓取图片的类型，见E_VDA_GRAB_PIC_TYPE
                pPicBuf - 图片缓存区（只有在输入缓存区大小足够前提下，才会输出图片数据）
                dwBufLen - 输入图片缓存区大小
                dwPicDataLen - 实际图片数据大小
        返回值：成功返回TRUE，失败返回FALSE
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_GrabPictureData(UInt32 lVodHandle, UInt32 dwPicType, IntPtr /* IN OUT char **/ pPicBuf, UInt32 dwBufLen, out UInt32 dwPicDataLen);
        /*===========================================================
        功  能：获取视频分辨率
        参  数：lVodHandle - 点播标示句柄
		        pdwWidth - 视频宽
		        pdwHeight - 视频高
        返回值：成功返回TRUE，失败返回FALSE
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_GetPlayResolution(UInt32 lVodHandle, out UInt32 pdwWidth, out UInt32 pdwHeight);
        //停止播放
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_StopPlayBack(UInt32 lVodHandle);


        /*===========================================================
        获取视频文件流相关接口
        ===========================================================*/
        /*===========================================================
        功  能：获取视频码流
        参  数：ptStreamInfo - 码流信息
                pfuncFrameDataCB - 回调函数
                dwUserData - 用户数据
        返回值：-1表示失败，其他值表示返回的示值。
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 RvodSdk_GetVideoStream(TRVODSDK_STREAM_INFO ptStreamInfo, TfuncVideoFrameDataCB pfuncFrameDataCB,
                                                            TfuncVideoFrameStatusCB pfuncFrameStatusCB, UInt32 dwUserData);
        /*===========================================================
        功  能：停止获取码流
        参  数：lStreamHandle - 码流句柄
        返回值：-1表示失败，其他值表示返回的示值。
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RvodSdk_StopVideoStream(UInt32 lStreamHandle);

    }


    partial class IVXRealtimeProtocol
    {
        #region Rvod

        //初始化
        public bool RvodSdk_Init()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_Init ");
            bool retVal = IVXRVODSDKProtocol.RvodSdk_Init();
            if (!retVal)
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_Init ret:" + retVal);
            return retVal;

            
        }

        //退出
        public  bool RvodSdk_UnInit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_UnInit ");
            bool retVal = IVXRVODSDKProtocol.RvodSdk_UnInit();
            if (!retVal)
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_UnInit ret:" + retVal);
            return retVal;


        }


        //获取SDK的版本信息
        public  string RvodSdk_GetSdkVersion()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_Init ");
            string retVal = IVXRVODSDKProtocol.RvodSdk_GetSdkVersion();

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_Init ret:" + retVal);
            return retVal;


        }


        //获取错误码
        public UInt32 RvodSdk_GetLastError()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GetRvodtError ");
            UInt32 retVal = IVXRVODSDKProtocol.RvodSdk_GetLastError();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GetRvodtError ret:" + retVal);
            return retVal;


        }


        public string RvodSdk_GetErrorMsg(UInt32 dwErrCode)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GetErrorMsg dwErrCode:" + dwErrCode);
            string retVal = IVXRVODSDKProtocol.RvodSdk_GetErrorMsg(dwErrCode);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GetErrorMsg ret:" + retVal);
            return retVal;


        }


        /*===========================================================
        获取服务器视频列表相关接口
        ===========================================================*/
        /*===========================================================
        功  能：获取指定盘符下视频文件个数
        参  数：	ptSearch - 视频查询条件
                pdwQueryHandle - 检索句柄
        返回值：成功返回文件个数，失败返回-1
        ===========================================================*/
        public UInt32 RvodSdk_GetVideoResourceTotalNum(string ip,uint port, out UInt32 pdwQueryHandle)
        {
            TRVODSDK_SERVER_INFO ptServer = new TRVODSDK_SERVER_INFO()
            {
                szDevIp = ip,
                wDevPort = (ushort)port,
            };
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GetVideoResourceTotalNum ip:"+ip+",port:"+port);
            UInt32 retVal = IVXRVODSDKProtocol.RvodSdk_GetVideoResourceTotalNum(ref ptServer, out pdwQueryHandle); ;
            if (pdwQueryHandle <= 0 || pdwQueryHandle == 0xffffffff)
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GetVideoResourceTotalNum ret count:" + retVal+",handel:"+pdwQueryHandle);
            return retVal;

        }

        /*===========================================================
        功  能：查询下一个视频资源信息（遍历接口）
        参  数：lQueryHandle - 查询标示值
                ptVideoInfo - 视频文件信息
        返回值：成功返回TRUE，失败返回FALSE。
        ===========================================================*/

        public RVODFileInfo RvodSdk_QueryNextVideoResource(UInt32 lQueryHandle)
        {
            TRVODSDK_VIDEO_INFO ptVideoInfo = new TRVODSDK_VIDEO_INFO()
            { dwVideoSize =0, szVideoPath="",};
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_QueryNextVideoResource lQueryHandle:" + lQueryHandle);
            bool retVal = IVXRVODSDKProtocol.RvodSdk_QueryNextVideoResource(lQueryHandle, out ptVideoInfo) ;

            if (string.IsNullOrEmpty(ptVideoInfo.szVideoPath))
                return null;
            //if (retVal < 0)
            //{
            //    RVOD_GetError();
            //}

            string path = ptVideoInfo.szVideoPath.Replace('\\','/');
            RVODFileInfo info = new RVODFileInfo()
            {
                VodFileName = path,
                VodFileSize = ptVideoInfo.dwVideoSize,

            };

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_QueryNextVideoResource ret:" + retVal + ",szVideoPath:" + ptVideoInfo.szVideoPath + ",dwVideoSize:" + ptVideoInfo.dwVideoSize);
            return info;

        }

        /*===========================================================
        功  能：关闭视频资源查询查询
        参  数：lQueryHandle 查询标示值
        返回值：成功返回TRUE，失败返回FALSE。
        ===========================================================*/
        public bool RvodSdk_CloseVideoResourceQuery(UInt32 lQueryHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_CloseVideoResourceQuery lQueryHandle:" + lQueryHandle );
            bool retVal = IVXRVODSDKProtocol.RvodSdk_CloseVideoResourceQuery( lQueryHandle); ;
            if (!retVal)
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_CloseVideoResourceQuery ret :" + retVal );
            return retVal;

        }


        /*===========================================================
        视频点播相关接口
        ===========================================================*/
        /*===========================================================
        功  能：点播视频
        参  数：ptVodInfo - 点播信息
                pfuncPlayPos - 进度回调函数，传Null标示不需要回调进度
                dwUserData - 用户数据
        返回值：-1表示失败，其他值表示返回的点播标示值。
        ===========================================================*/
        public UInt32 RvodSdk_PlayBackVideo(IntPtr hWnd,RVODFileInfo info)
        {
            TRVODSDK_PLAYBACK_VOD_INFO ptVodInfo = new TRVODSDK_PLAYBACK_VOD_INFO()
            {
                hPlayWnd = (uint)hWnd.ToInt32(),
                szVideoPath = info.VodFileName,
                tServerInfo = new TRVODSDK_SERVER_INFO() {  szDevIp = info.ServerIP, wDevPort = (ushort)info.ServerPort,},
            };
            pfuncPlayPos = OnTfuncPlayPosCB;
            UInt32 dwUserData = 0;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_PlayBackVideo hWnd:" + hWnd.ToInt32() + ",VodFileName:" + info.VodFileName + ",VodFileSize:" + info.VodFileSize + ",ServerIP:" + info.ServerIP + ",ServerPort:" + info.ServerPort);
            uint retVal = IVXRVODSDKProtocol.RvodSdk_PlayBackVideo(ref ptVodInfo,pfuncPlayPos,dwUserData); 
            if (retVal<=0 || retVal == 0xffffffff)
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_PlayBackVideo ret :" + retVal);
            return retVal;

        }
        /*===========================================================
        功  能：播放控制
        参  数：lVodHandle - 点播标示句柄
                dwControlCode - 播放控制类型，见E_VDA_PLAYCTRL_TYPE定义
                dwInValue - 播放控制输入参数
                pdwOutValue - 播放控制输出参数，如获取的进度等
        返回值：成功返回TRUE，失败返回FALSE
        ===========================================================*/
        public bool RvodSdk_PlayBackControl(UInt32 lVodHandle, UInt32 dwControlCode, UInt32 dwInValue, out UInt32 pdwOutValue)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_PlayBackControl lVodHandle:" + lVodHandle + ",dwControlCode:" + dwControlCode + ",dwInValue:" + dwInValue);
            bool retVal = IVXRVODSDKProtocol.RvodSdk_PlayBackControl(lVodHandle, dwControlCode, dwInValue, out pdwOutValue);
            if (!retVal )
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_PlayBackControl ret :" + retVal + ",pdwOutValue:" + pdwOutValue);
            return retVal;

        }
        /*===========================================================
        功  能：抓图并获取数据
        参  数：lVodHandle - 点播标示句柄
                dwPicType - 抓取图片的类型，见E_VDA_GRAB_PIC_TYPE
                pPicBuf - 图片缓存区（只有在输入缓存区大小足够前提下，才会输出图片数据）
                dwBufLen - 输入图片缓存区大小
                dwPicDataLen - 实际图片数据大小
        返回值：成功返回TRUE，失败返回FALSE
        ===========================================================*/
        public System.Drawing.Image RvodSdk_GrabPictureData(UInt32 lVodHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GrabPictureData lVodHandle:" + lVodHandle);


            uint buflen = DataModel.Common.MAX_PIC_DATA_LEN;
            IntPtr picbuf = Marshal.AllocHGlobal((int)buflen);
            uint picdatalen = 0;

            bool retVal = IVXRVODSDKProtocol.RvodSdk_GrabPictureData(lVodHandle, (uint)E_VDA_GRAB_PIC_TYPE.E_GRAB_PIC_BMP, picbuf,buflen, out picdatalen);

            if (!retVal && picdatalen > buflen && picdatalen > 0)
            {
                if (picbuf != IntPtr.Zero)
                    Marshal.FreeHGlobal(picbuf);

                buflen = picdatalen;
                picbuf = Marshal.AllocHGlobal((int)buflen);
                picdatalen = 0;
                retVal = IVXRVODSDKProtocol.RvodSdk_GrabPictureData(lVodHandle, (uint)E_VDA_GRAB_PIC_TYPE.E_GRAB_PIC_BMP, picbuf, buflen, out picdatalen);

            }

            if (!retVal )
            {
                RVOD_GetError();
            }
            System.Drawing.Image img = DataModel.Common.GetImage(picbuf, (int)buflen);
            if (picbuf != IntPtr.Zero)
                Marshal.FreeHGlobal(picbuf);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_GrabPictureData ret:" + retVal);

            return img;

        }

        public bool GetRVodPlayResolution(UInt32 dwStrmId, out UInt32 pdwWidth, out UInt32 pdwHeight)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXRVODSDKProtocol RvodSdk_GetPlayResolution dwStrmId:{0}"
                , dwStrmId
                ));

            bool retVal = IVXRVODSDKProtocol.RvodSdk_GetPlayResolution(dwStrmId, out  pdwWidth, out pdwHeight);
            if (!retVal)
            {
                // 调用失败，抛异常
                RVOD_GetError();
            }


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, string.Format("IVXRVODSDKProtocol RvodSdk_GetPlayResolution ret:{0}"
                + ",pdwWidth:{1}"
                + ",pdwHeight:{2}"
                , retVal
                , pdwWidth
                , pdwHeight
                ));
            return retVal;

        }

        //停止播放
        public bool RvodSdk_StopPlayBack(UInt32 lVodHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_StopPlayBack lVodHandle:" + lVodHandle);
            bool retVal = IVXRVODSDKProtocol.RvodSdk_StopPlayBack(lVodHandle);
            if (!retVal)
            {
                RVOD_GetError();
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXRVODSDKProtocol RvodSdk_StopPlayBack ret :" + retVal );
            return retVal;

        }


        ///*===========================================================
        //获取视频文件流相关接口
        //===========================================================*/
        ///*===========================================================
        //功  能：获取视频码流
        //参  数：ptStreamInfo - 码流信息
        //        pfuncFrameDataCB - 回调函数
        //        dwUserData - 用户数据
        //返回值：-1表示失败，其他值表示返回的示值。
        //===========================================================*/
        //[DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        //public static extern UInt32 RvodSdk_GetVideoStream(TRVODSDK_STREAM_INFO ptStreamInfo, TfuncVideoFrameDataCB pfuncFrameDataCB,
        //                                                    TfuncVideoFrameStatusCB pfuncFrameStatusCB, UInt32 dwUserData);
        ///*===========================================================
        //功  能：停止获取码流
        //参  数：lStreamHandle - 码流句柄
        //返回值：-1表示失败，其他值表示返回的示值。
        //===========================================================*/
        //[DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        //public static extern bool RvodSdk_StopVideoStream(UInt32 lStreamHandle);

        #endregion
    }
}
