using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UpdateTool
{
    public partial class FormPathEdit : Form
    {
        public FormPathEdit(string path="")
        {
            InitializeComponent();
            textBox1.Text = path;
        }

        public string Path
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimEnd(new char[]{'\\'}) + "\\";
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
