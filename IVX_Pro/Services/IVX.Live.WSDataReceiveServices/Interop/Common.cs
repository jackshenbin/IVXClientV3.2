using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IVX.Live.WSDataReceiveServices.Interop
{

    internal partial class IVXWSSDKProtocol
    {
        #region 常量定义


#if DEBUG
        const string DLLPATH = @"lib\websrvcommuserver.dll";
#else
        const string DLLPATH = @"lib\websrvcommuserver.dll";
#endif

        #endregion
    }
}
