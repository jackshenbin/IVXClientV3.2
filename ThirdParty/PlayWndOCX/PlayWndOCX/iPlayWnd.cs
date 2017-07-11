using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BOCOM.IVX.COMLibrary
{
    [Guid("0CDEFC00-C0CC-4834-B6C8-BDACEAEC0479"),
    InterfaceType(ComInterfaceType.InterfaceIsDual),
    ComVisible(true)]
    public interface iPlayWnd
    {
        [DispId(0)]
        string GetHwnd();
    }


    /// <summary>
    /// IObjectSafety接口.net定义
    /// </summary>
    [Guid("0229148E-7BF6-4F1E-8A21-51881D0331EF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectSafety
    {
        /// <summary>
        /// 获取接口安全性
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="supportedOptions"></param>
        /// <param name="enabledOptions"></param>
        void GetInterfaceSafetyOptions(int riid, out int supportedOptions, out int enabledOptions);

        /// <summary>
        /// 设置接口安全性
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="optionsSetMask"></param>
        /// <param name="enabledOptions"></param>
        void SetInterfaceSafetyOptions(int riid, int optionsSetMask, int enabledOptions);
    }

}

