using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormFaceAlarm : IVX.Live.MainForm.UILogics.FormBase
    {
        uint ReceivedCount { get; set; }
        WSDataReceiveViewModel m_viewModel;
        public FormFaceAlarm()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            ShowStatusBar = false;
        }


        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            
        }
        public override void DoAction(object action)
        {
            if (action is DataModel.CameraInfoV3_1)
            {


            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            m_viewModel = new WSDataReceiveViewModel(Framework.Environment.AlarmReceivePort);
            WSDataReceiveViewModel.FaceAlarmReceived += WSDataReceiveViewModel_FaceAlarmReceived;
        }

        void WSDataReceiveViewModel_FaceAlarmReceived(FaceAlarmInfoV3_1 obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<FaceAlarmInfoV3_1>(WSDataReceiveViewModel_FaceAlarmReceived), obj);
            }
            else
            {
                WinFormAppUtil.Controls.PictureBoxEx p = new WinFormAppUtil.Controls.PictureBoxEx();
                p.Size = new System.Drawing.Size(100,100);
                
                System.Drawing.Rectangle rect = obj.FacePosition;
                System.Drawing.Image img = new System.Drawing.Bitmap(obj.FacePosition.Width, obj.FacePosition.Height);
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(DataModel.Common.GetImage(obj.OriFacePicPath), new Rectangle(0, 0, obj.FacePosition.Width, obj.FacePosition.Height), rect, GraphicsUnit.Pixel);
                g.Dispose();
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Image = img;
                p.Tag = obj;
                p.Margin = new System.Windows.Forms.Padding(3);
                p.MouseDoubleClick += p_MouseDoubleClick;
                flowLayoutPanel1.Controls.Add(p);
                ReceivedCount++;
                labelCountInfo.Text = "收到报警记录数 "+ReceivedCount+" 条";
            }
        }

        void p_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormAppUtil.Controls.PictureBoxEx pic = sender as WinFormAppUtil.Controls.PictureBoxEx;
            if (pic != null && pic.Tag is FaceAlarmInfoV3_1)
            {
                FormSingleFaceAlarmInfo f = new FormSingleFaceAlarmInfo();
                f.Init(pic.Tag as FaceAlarmInfoV3_1);
                f.ShowDialog();
            }
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            FormAddEditFaceSubscribe f = new FormAddEditFaceSubscribe();
            f.ShowDialog();
        }



        private void node1_NodeClick(object sender, EventArgs e)
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormFaceAlarmSearch", Title = "人脸报警", Discription = "人脸报警" }, null));

        }



    }
}