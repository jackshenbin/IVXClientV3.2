using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppUtil.Controls
{
    public partial class ProgressForm : Form, IProgressForm
    {

        public string StatusText
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        public int Maximum
        {
            get
            {
                return this.progressBar1.Maximum;
            }
            set
            {
                this.progressBar1.Maximum = value;
            }
        }

        public int Progress
        {
            get
            {
                return this.progressBar1.Value;
            }
            set
            {
                this.progressBar1.Value = value;
            }
        }

        public ProgressForm()
        {
            InitializeComponent();
        }

    }
}