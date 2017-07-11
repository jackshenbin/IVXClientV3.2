using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BOCOM.IVX.COMLibrary;

namespace PlayWndOCX
{
    [Guid("7373F6A0-DD52-4DA6-851A-DFAF27B832AE"),
    ProgId("PlayWndOCX"),
    ClassInterface(ClassInterfaceType.None),
    ComDefaultInterface(typeof(iPlayWnd)),
    ComVisible(true)]
    public partial class ucPlayWnd : UserControl, iPlayWnd, IObjectSafety
    {
        public ucPlayWnd()
        {
            InitializeComponent();
        }

        public string GetHwnd()
        {
            return this.Handle.ToString();
        }

        #region IObjectSafety implementations

        void IObjectSafety.GetInterfaceSafetyOptions(int riid, out int supportedOptions, out int enabledOptions)
        {
            supportedOptions = 1;
            enabledOptions = 2;
        }

        void IObjectSafety.SetInterfaceSafetyOptions(int riid, int optionsSetMask, int enabledOptions)
        {
            //throw new NotImplementedException();
        }

        #endregion

    }
}
