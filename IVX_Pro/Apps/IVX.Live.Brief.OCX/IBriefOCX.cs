using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace IVX.Live.Brief.OCX
{
    [Guid("2AE1A363-4B90-4871-8011-3BE83E94C0E3"),
    InterfaceType(ComInterfaceType.InterfaceIsDual),
    ComVisible(true)]
    public interface IBriefOCX
    {
        #region 基础操作

        /// <summary>
        /// 创建摘要
        /// </summary>
        /// <param name="hostIP">服务器ip</param>
        /// <param name="hostPort">服务器端口</param>
        /// <param name="briefIndexPath">摘要索引路径</param>
        /// <param name="briefDatePath">摘要数据路径</param>
        /// <param name="videoLenth">视频文件持续秒数</param>
        /// <param name="adjusttime">视频校准时间</param>
        /// <returns></returns>
        string CreateBrief(string hostIP, uint hostPort, string briefIndexPath, string briefDatePath, int videoLenth, int adjusttime);
        
        /// <summary>
        /// 退出清理
        /// </summary>
        /// <returns></returns>
        string  Clear();

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

        /// <summary>
        /// 改变样式
        /// </summary>
        /// <param name="param">样式参数</param>
        /// <returns></returns>
        string ChangeTheme(string param);

        #endregion

    }



    [ComVisible(true)]
    [Guid("6B2A6313-02DD-4D55-AE2E-B7A0BC8F711E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IBriefOCXEvents
    {
        /// <summary>
        /// 摘要回溯播放通知
        /// </summary>
        /// <param name="MoveObjID">目标编号</param>
        /// <param name="MoveObjType">目标类型，见E_VDA_MOVEOBJ_TYPE</param>
        /// <param name="MoveObjColor">目标颜色，见？</param>
        /// <param name="BeginTimeS">目标出现的时间，相对于视频开始的秒数</param>
        /// <param name="EndTimeS">目标消失的时间，相对于视频开始的秒数</param>
        [DispId(101)]
        void OnBriefObjectPlayBackNote(uint MoveObjID, int MoveObjType, int MoveObjColor, int BeginTimeS, int EndTimeS);


        /// <summary>
        /// 图片保存通知
        /// </summary>
        /// <param name="fileSavePath">文件存储路径</param>
        /// <param name="formType">图片来源 见E_PICTURE_FORM_TYPE  </param>
        [DispId(102)]
        void OnPictureSaved(string fileSavePath, int formType);

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
