using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm
{
    public partial class FormProtocolTest : UILogics.FormBase
    {
        event Action<bool, string> threadreturn;
        ProtocolTestViewModel m_viewModel;
        public FormProtocolTest()
        {
            InitializeComponent();
        }

        private bool m_isStop = true;
        private int m_sleepTime = 5000;


        private bool m_have_A200080 = true;
        private bool m_have_A200050 = true;
        private bool m_have_A200030 = true;
        private bool m_have_A200060 = true;
        private void FormProtocolTest_Load(object sender, EventArgs e)
        {
            threadreturn += Form3_threadreturn;

            new System.Threading.Thread(thSendProtocol).Start();

            m_viewModel = new ProtocolTestViewModel();
            m_viewModel.FireMessage += m_viewModel_FireMessage;
        }

        void m_viewModel_FireMessage(string obj)
        {
            if (!obj.Contains("连接成功"))
            Form3_threadreturn(false, obj);
        }

        private void thSendProtocol()
        {
            while (!IsDisposed)
            {
                if (m_isStop)
                {
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    if (threadreturn != null)
                        threadreturn(true, "-----------------start---------------");

                    List<TaskInfoV3_1> list=null;
                    if(m_have_A200080)
                        list = Send_A200080();
                    if (list != null)
                    {
                        if (m_have_A200050)
                            Send_A200050(list);
                        if (m_have_A200030)
                            Send_A200030(list);
                        if (m_have_A200060)
                            Send_A200060();
                    }

                    if (threadreturn != null)
                        threadreturn(true, "---------------finish----------------");

                    for (int i = 0; i < m_sleepTime/10; i++)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                }
                
            }
        }

        private List<TaskInfoV3_1> Send_A200080()
        {
            try
            {
                m_viewModel.CurrentPageIndex = 1;
                m_viewModel.CountPerPage = 10;
                List<TaskInfoV3_1> retVal = m_viewModel.TASK_PAGING();
                if (threadreturn != null)
                    threadreturn(true, "Send_A200080");
                return retVal;
            }
            catch (SDKCallException ex)
            { 
                if (threadreturn != null)
                    threadreturn(false , "Send_A200080 error ["+ex.ErrorCode+"]:"+ex.Message);
                return new List<TaskInfoV3_1>();

            }
        }
        private void Send_A200050(List<TaskInfoV3_1> list)
        {
            try
            {
                m_viewModel.GET_TASK_PROGRESS(list);
                if (threadreturn != null)
                    threadreturn(true, "Send_A200050");
            }
            catch (SDKCallException ex)
            {
                if (threadreturn != null)
                    threadreturn(false, "Send_A200050 error [" + ex.ErrorCode + "]:" + ex.Message);
            }
        }
        private void Send_A200030(List<TaskInfoV3_1> list)
        {
            foreach (var item in list)
            {
            try
            {
                m_viewModel.GetTaskInfo(item.TaskId);
                if (threadreturn != null)
                    threadreturn(true, "Send_A200030 id:" + item.TaskId);
            }
            catch (SDKCallException ex)
            {
                if (threadreturn != null)
                    threadreturn(false, "Send_A200030 id:" + item.TaskId + " error [" + ex.ErrorCode + "]:" + ex.Message);
            }
                
            }
        }
        private void Send_A200060()
        {
            try
            {
                m_viewModel.GET_DOWN_LOAD_LIST();
                if (threadreturn != null)
                    threadreturn(true, "Send_A200060");
            }
            catch (SDKCallException ex)
            {
                if (threadreturn != null)
                    threadreturn(false, "Send_A200060 error [" + ex.ErrorCode + "]:" + ex.Message);
            }
        }


        void Form3_threadreturn( bool arg2, string arg3)
        {
            if (InvokeRequired)
            {
                Invoke(new Action< bool, string>(Form3_threadreturn),  arg2, arg3);
            }
            else
            {
                richTextBox1.SelectionColor = arg2 ? Color.Blue : Color.Red;
                richTextBox1.AppendText(string.Format("time:{0},    ret:{1},    msg:{2}" + Environment.NewLine, DateTime.Now.ToString("HH:mm:ss:fff"), arg2, arg3));
                richTextBox1.ScrollToCaret();
            }
        }

        private void FormProtocolTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_isStop = true;
        }

        private void integerInput1_ValueChanged(object sender, EventArgs e)
        {
            m_sleepTime = integerInput1.Value;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            m_isStop = false ;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            m_isStop = true ;
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            m_have_A200080 = checkBoxX1.Checked;
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            m_have_A200050 = checkBoxX2.Checked;

        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
            m_have_A200030 = checkBoxX3.Checked;

        }

        private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
        {
            m_have_A200060 = checkBoxX4.Checked;

        }

    }
}
