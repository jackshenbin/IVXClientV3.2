using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm
{
    public partial class ucAnalysePicker : UserControl
    {
        public ucAnalysePicker()
        {
            InitializeComponent();
            
        }

        public DataModel.E_VIDEO_ANALYZE_TYPE Value
        {
            get;
            set;
        }

        protected virtual void OnValueChanged(EventArgs eventargs)
        { 
        }
    }
}
