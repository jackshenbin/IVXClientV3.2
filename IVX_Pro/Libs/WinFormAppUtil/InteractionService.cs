using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using WinFormAppUtil;
using DevComponents.DotNetBar;

namespace WinFormAppUtil
{
    // [Export(typeof(IInteractionService))]
    public class InteractionService : IInteractionService
    {
        public System.Windows.Forms.DialogResult ShowMessageBox(IWin32Window owner, string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK , MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            return MessageBoxEx.Show(owner, text, caption, buttons, icon);
        }

        public System.Windows.Forms.DialogResult ShowMessageBox(string text, string caption, System.Windows.Forms.MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            return MessageBoxEx.Show(text, caption, buttons, icon);
        }

        public DialogResult ShowMessageBox(string text)
        {
            return MessageBoxEx.Show(text);
        }

        public void ShowAlertBox(string text, string caption ,System.Drawing.Image img = null)
        {
            //DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            //alertControl1.Show(null, caption, text, img);
        }
    }
}
