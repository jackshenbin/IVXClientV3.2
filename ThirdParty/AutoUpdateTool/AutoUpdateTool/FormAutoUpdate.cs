using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutoUpdate
{
    public  partial class FormAutoUpdate : Form
    {
        public FormAutoUpdate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("AutoUpdateApp.exe", "2");

        }
        public string UpdateURL
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public int UpdateType
        {
            get 
            {
                int type = 0;
                if (radioButton1.Checked == true)
                    type = 1;
                else if (radioButton2.Checked == true)
                    type = 2;
                else if (radioButton3.Checked == true)
                    type = 3;
                else
                    type = 2;
                return type;
            }
            set 
            {
                switch (value)
                {
                    case 1:
                        radioButton1.Checked = true;
                        break;
                    case 2:
                        radioButton2.Checked = true;
                        break;
                    case 3:
                        radioButton3.Checked = true;
                        break;
                    default:
                        radioButton2.Checked = true;
                        break;
                }

            }
        }
    }
}
