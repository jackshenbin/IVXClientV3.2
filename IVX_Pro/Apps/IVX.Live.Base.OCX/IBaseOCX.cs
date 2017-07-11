using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace IVX.Live.Base.OCX
{
    [Guid("41D54035-BEDE-4773-A35F-F1A6FB460793"),
    InterfaceType(ComInterfaceType.InterfaceIsDual),
    ComVisible(true)]
    public interface IBaseOCX
    {
        #region 基础操作

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        string Init();
        
        /// <summary>
        /// 退出清理
        /// </summary>
        /// <returns></returns>
        string  Clear();

        /// <summary>
        /// 启动导出视频
        /// </summary>
        /// <param name="hostIP">服务器ip</param>
        /// <param name="hostPort">服务器端口</param>
        /// <param name="videoPath">视频路径</param>
        /// <param name="startSecond">开始秒数，默认0</param>
        /// <param name="endSecond">结束秒数,默认0</param>
        /// <param name="savefilepath">需要保存的视频路径</param>
        /// <returns></returns>
        string StartVideoSave(string hostIP, uint hostPort, string videoPath, int startSecond, int endSecond, string savefilepath);

        /// <summary>
        /// 停止导出视频
        /// </summary>
        /// <param name="handel">导出唯一句柄</param>
        /// <returns></returns>
        string StopVideoSave(int handel);

        /// <summary>
        /// 设置保存截图及下载视频的默认位置
        /// </summary>
        /// <param name="path">需要保存的本地磁盘位置</param>
        /// <returns></returns>
        string VdaSetSavePictureAndVideoDefaultPath(string path);

        /// <summary>
        /// 获取ocx版本号
        /// </summary>
        /// <returns>版本号，如：3.1.0.1</returns>
        string GetVersion();


        #endregion

    }



    [ComVisible(true)]
    [Guid("6497FC48-6275-49E5-8C64-5BA21BE31910")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IBaseOCXEvents
    {

        /// <summary>
        /// 视频保存完成通知
        /// </summary>
        /// <param name="handel">下载唯一句柄</param>
        /// <param name="fileSavePath">文件存储路径</param>
        /// <param name="progress">下载进度 千分比</param>
        [DispId(104)]
        void OnVideoSaveProgress(int handel, string fileSavePath, int progress);

        /// <summary>
        /// 视频保存完成通知
        /// </summary>
        /// <param name="handel">下载唯一句柄</param>
        /// <param name="fileSavePath">文件存储路径</param>
        /// <param name="finishType">0成功，非0失败错误码</param>
        [DispId(105)]
        void OnVideoSaveFinished(int handel, string fileSavePath, int finishType);

    }


    /// <summary>
    /// IObjectSafety接口.net定义
    /// </summary>
    [ComImport, GuidAttribute("CB5BDC81-93C1-11CF-8F20-00805F2CD064")]//uuid
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]//继承了IUnknown
    public interface IObjectSafety
    {
        [PreserveSig]
        int GetInterfaceSafetyOptions(
            ref Guid riid,
            [MarshalAs(UnmanagedType.U4)] ref int pdwSupportedOptions,
            [MarshalAs(UnmanagedType.U4)] ref int pdwEnabledOptions);

        [PreserveSig()]
        int SetInterfaceSafetyOptions(
            ref Guid riid,
            [MarshalAs(UnmanagedType.U4)] int dwOptionSetMask,
            [MarshalAs(UnmanagedType.U4)] int dwEnabledOptions);
    }

}
