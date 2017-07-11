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
    public partial class Form3 : UILogics.FormBase
    {
        static int index = 0;
        public Form3()
        {
            InitializeComponent();

            colorComboBox1.InitColor(DataModel.Constant.MoveObjectColorInfos.Select(item => new object[] { item.Type.Col, item.Name, item.Type.ID }).ToList());
        }
        event Action<object,bool, string> threadreturn; 
        private void Form2_Load(object sender, EventArgs e)
        {
            threadreturn += Form3_threadreturn;
        }

        void Form3_threadreturn(object arg1, bool arg2, string arg3)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, bool, string>(Form3_threadreturn), arg1, arg2, arg3);
            }
            else
            {
                richTextBox1.SelectionColor = arg2 ? Color.Blue : Color.Red;
                richTextBox1.AppendText(string.Format("id:{0},ret:{1},msg:{2}" + Environment.NewLine, arg1, arg2, arg3));
                richTextBox1.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = index; i < index+200; i++)
            {
            System.Threading.Thread t = new System.Threading.Thread(doLogin);
            t.Start(i);
               
            }
            index += 200;
        }


        void doLogin(object id)
        {
            ViewModel.LoginViewModel vm = new ViewModel.LoginViewModel();
            string msg = "";
            bool ret = vm.Login("192.168.88.199", "192.168.88.121", "admin", "admin", out msg);
            if (threadreturn != null)
                threadreturn(id, ret, msg);
        }

        private void colorComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.AppendText(colorComboBox1.SelectedColorValue.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorComboBox1.SelectedColorValue = 1;
        }
    }
}
