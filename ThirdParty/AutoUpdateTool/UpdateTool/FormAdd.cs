using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UpdateTool
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
            integerInput1.Text = "0"; 
            integerInput2.Text = "0"; 
            integerInput3.Text = "0"; 
            integerInput4.Text = "0"; 
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public string Version
        {
            get 
            {
                return integerInput1.Value + "." + integerInput2.Value + "." + integerInput3.Value + "." + integerInput4.Value;
            }
            
        }
        public DateTime Date
        {
            get
            {
                return dateTimePicker1.Value;
            }
        }
        public string Discription
        {
            get
            {
                return textBox2.Text;
            }
        }
        public int Type
        {
            get
            {
                if (radioButton1.Checked) return 0;
                else if (radioButton2.Checked) return 1;
                else if (radioButton3.Checked) return 2;
                else return 0;
            }
        }
    }
}
