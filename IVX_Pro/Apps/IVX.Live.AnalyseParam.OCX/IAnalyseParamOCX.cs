using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace IVX.Live.AnalyseParam.OCX
{
    [Guid("510DA525-23CD-4DDC-869B-47DF78F7BCA8"),
    InterfaceType(ComInterfaceType.InterfaceIsDual),
    ComVisible(true)]
    public interface IAnalyseParamOCX
    {
        #region 基础操作


        /// <summary>
        /// 配置分析参数
        /// 配置完成后分析参数和类型通过OnFinish事件返回
        /// </summary>
        /// <param name="analyseType">算法类型</param>
        /// <param name="param">分析参数，新建为空，修改则填写任务中的分析参数值</param>
        /// <returns></returns>
        string ConfigAnalyseParam(int analyseType, string param);

        /// <summary>
        /// 设置需要配置分析参数的场景图片
        /// </summary>
        /// <param name="path">图片路径，支持本地文件，http，windos共享</param>
        /// <returns></returns>
        string SetPicture(string path);

        
        /// <summary>
        /// 退出清理
        /// </summary>
        /// <returns></returns>
        string  Clear();


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
    [Guid("50462B08-9353-452C-9DAB-67ECF0EA35F2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IAnalyseParamOCXEvents
    {
        /// <summary>
        /// 界面操作完成通知
        /// </summary>
        /// <param name="isOk">确定还是取消，1=确定，0=取消</param>
        /// <param name="param">分析参数，isOk=1时有效</param>
        /// <param name="analyseType">分析类型，isOk=1时有效</param>
        [DispId(101)]
        void OnFinish(uint isOk, string param,uint analyseType);

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
