using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm
{
    public partial class FormPlayTest : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormPlayTest()
        {
            InitializeComponent();
            /*
             ocx_BriefVoddcInit
             */
            ucSinglePlayWnd1.MouseClickEx += ucSinglePlayWnd1_MouseClickEx;
            ucSinglePlayWnd1.MouseDoubleClickEx += ucSinglePlayWnd1_MouseDoubleClickEx;
            ucSinglePlayWnd1.PropertyChanged += ucSinglePlayWnd1_PropertyChanged;
        }
        View.ucSinglePlayWnd currWnd;
        void ucSinglePlayWnd1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            View.ucSinglePlayWnd wnd = sender as View.ucSinglePlayWnd;
            if(e.PropertyName == "VideoTime")
            { UpdataTime(wnd); }
            if (e.PropertyName == "VideoStatus")
            { UpdataStatus(wnd); }
        }

        private void UpdataTime(View.ucSinglePlayWnd wnd)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<View.ucSinglePlayWnd>(UpdataTime),wnd);
            }
            else
            {
                labelX2.Text = wnd.VideoTime;
            }
        }

        private void UpdataStatus(View.ucSinglePlayWnd wnd)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<View.ucSinglePlayWnd>(UpdataStatus), wnd);
            }
            else
            {
                switch (wnd.VideoStatus)
                {
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                        wnd.StopPlayBack();
                        break;
                    default:
                        break;
                }
                labelX3.Text = wnd.VideoStatusString;
            }
        }

        void ucSinglePlayWnd1_MouseDoubleClickEx(object sender, MouseEventArgs e)
        {
            MessageBox.Show("ucSinglePlayWnd1_MouseDoubleClickEx");
        }

        void ucSinglePlayWnd1_MouseClickEx(object sender, MouseEventArgs e)
        {
            View.ucSinglePlayWnd wnd = sender as View.ucSinglePlayWnd;

            wnd.PlayOrPauseOrResume();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            currWnd.StartPlayBack(textBoxIP.Text, Convert.ToUInt32(textBoxPort.Text), textBoxPath.Text,0,0);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            currWnd.PlayOrPauseOrResume();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            currWnd.StopPlayBack();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            currWnd.SpeedUp();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            currWnd.SpeedDown();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            Image img = currWnd.GrabPictureData();
            img.Save(@"c:\a.jpg");
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            Framework.Environment.VODPlayControler = axvodocx1;
            if (ucSinglePlayWnd1.Init())
            {
                currWnd = ucSinglePlayWnd1;
                currWnd.VideoName = System.IO.Path.GetFileName( textBoxPath.Text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSinglePlayWnd1.UnInit();
        }
    }
}
