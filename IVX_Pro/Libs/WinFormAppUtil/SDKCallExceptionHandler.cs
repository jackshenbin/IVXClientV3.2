using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using log4net;
using IVX.DataModel;

namespace WinFormAppUtil
{
    public class SDKCallExceptionHandler
    {
        /// <summary>
        /// 处理SDKCallException, 记录日志， 弹提示框
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="operationName"></param>
        /// <param name="showMessageBox"></param>
        public static void Handle(Exception ex, string operationName, string captionName, ILog log, IInteractionService interactionService, bool showMessageBox = true)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                return;
            }
            uint errorCode = 0;
            SDKCallException sdkException = ex as SDKCallException;
            if (sdkException != null)
            {
                errorCode = sdkException.ErrorCode;
            }
            string msg = string.Format("{0}出错: {1}, 错误码: {2}", operationName, ex.Message, errorCode);
            log.Error(msg, ex);
            Trace.WriteLine(msg + ex.ToString());

            msg = string.Format("{0}出错: {1}", operationName, ex.Message);
            if (showMessageBox)
            {
                interactionService.ShowMessageBox(msg, captionName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Debug.Assert(false, msg);
            }
        }

    }
}
