﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View
{
    public partial class FormTrafficFluxSearch : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormTrafficFluxSearch()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            this.ucTrafficFluxSearch1.Clear();
        }

    }
}
