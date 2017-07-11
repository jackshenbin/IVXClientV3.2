using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AutoUpdate;

namespace UpdateTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AutoUpdate.AutoUpdateInterface.ShowSetting() == System.Windows.Forms.DialogResult.OK)
            {
            textBox1.Text = AutoUpdate.AutoUpdateInterface.UpdateURL;
            switch (AutoUpdate.AutoUpdateInterface.UpdateType)
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

        private void button2_Click(object sender, EventArgs e)
        {
            AutoUpdate.AutoUpdateInterface.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AutoUpdate.AutoUpdateInterface.Check();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdate.AutoUpdateInterface.Initialize();
            textBox1.Text = AutoUpdate.AutoUpdateInterface.UpdateURL;
            switch (AutoUpdate.AutoUpdateInterface.UpdateType)
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

        private void button4_Click(object sender, EventArgs e)
        {
            AutoUpdate.AutoUpdateInterface.UpdateURL = textBox1.Text;
            AutoUpdate.AutoUpdateInterface.SaveSetting();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                AutoUpdate.AutoUpdateInterface.UpdateType = 1;
            else if(radioButton2.Checked == true)
                AutoUpdate.AutoUpdateInterface.UpdateType = 2;
            else if(radioButton3.Checked == true)
                AutoUpdate.AutoUpdateInterface.UpdateType = 3;
            else
                AutoUpdate.AutoUpdateInterface.UpdateType = 2;
            AutoUpdate.AutoUpdateInterface.SaveSetting();

        }

    }
}
