using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ViewModel.WSDataReceiveViewModel ws;
        private void button1_Click(object sender, EventArgs e)
        {
            ws = new ViewModel.WSDataReceiveViewModel( 9001);
            
        }
    }
}
