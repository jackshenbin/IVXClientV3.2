using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdateApp
{
    public partial class FormMessage : Form
    {
        public FormMessage()
        {
            InitializeComponent();
        }

        public string Title
        {
            set { this.Text = value; }
        }
        const int RightPageSize = 50;
        const int PageWidth = 400;
        public string Content
        {
            set 
            { 
                this.label1.Text = value;
                int w = label1.Width + label1.Location.X + RightPageSize;
                this.Width = Math.Max(w, PageWidth);
            }
        }

        public bool IsShow
        {
            get { return checkBox1.Checked; }
        }
        public void SetButton(MessageBoxButtons button)
        {
            switch(button)
            {
                case MessageBoxButtons.OK:
                    break;
                case MessageBoxButtons.YesNo:
                    break;
            }
        }
        public void SetIcon(MessageBoxIcon icon)
        { 
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    break;
                case MessageBoxIcon.Information:
                    break;
                case MessageBoxIcon.Question:
                    break;
                case MessageBoxIcon.Warning:
                    break;
            }
        }
        public bool CanHide
        {
            set { checkBox1.Visible = value; }
        }
        public  DialogResult Show(string content, string title)
        {
            this.Title = title;
            this.Content = content;
            return this.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
