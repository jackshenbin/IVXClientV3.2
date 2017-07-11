using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View
{
    public partial class ucUploadWnd : UserControl
    {
        public ucUploadWnd()
        {
            InitializeComponent();

        }

        public bool Init()
        {
            int retVal = ocx_SetMaxAbility((int)Framework.Environment.UploadAbility);
            return retVal == 0;
        }
        public bool AddTask(uint uTaskID, string pchFilePath, string pchServerUrl)
        {
            uint retVal = ocx_AddTask(uTaskID,pchFilePath,pchServerUrl);
            return retVal == 0;
        }
        public bool DeleteTask(uint uTaskID)
        {
            uint retVal = ocx_DeleteTask(uTaskID);
            return retVal == 0;
        }

        #region ocxInterface
        private uint ocx_AddTask(uint uTaskID, string pchFilePath, string pchServerUrl)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("fileuploadLib AddTask uTaskID:{0},pchFilePath:{1},pchServerUrl:{2}", uTaskID, pchFilePath, pchServerUrl);

            uint retVal = axfileupload1.AddTask(uTaskID, pchFilePath, pchServerUrl);
            MyLog4Net.Container.Instance.Log.DebugFormat("fileuploadLib AddTask  retVal:" + retVal);
            return retVal;
        }
        private uint ocx_DeleteTask(uint uTaskID)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("fileuploadLib DeleteTask uTaskID:" + uTaskID);

            uint retVal = axfileupload1.DeleteTask(uTaskID);
            MyLog4Net.Container.Instance.Log.DebugFormat("fileuploadLib DeleteTask retVal:" + retVal);
            return retVal;
        }
        private int ocx_SetMaxAbility(int wMaxAbility)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("fileuploadLib SetMaxAbility wMaxAbility:" + wMaxAbility);

            int retVal = axfileupload1.SetMaxAbility(wMaxAbility);
            MyLog4Net.Container.Instance.Log.DebugFormat("fileuploadLib SetMaxAbility retVal:" + retVal);
            return retVal;
        }

        #endregion
    }
}
