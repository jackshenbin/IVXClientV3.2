using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.MainForm.View;

namespace IVX.Live.MainForm
{
    interface IAnalyseSetting
    {
        string AnalyseParam { get; set; }

        Control DrawHandle { get; set; }
    }
}
