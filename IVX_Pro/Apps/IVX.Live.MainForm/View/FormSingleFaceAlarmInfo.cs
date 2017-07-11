using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormSingleFaceAlarmInfo : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormSingleFaceAlarmInfo()
        {
            InitializeComponent();
        }

        public void Init(FaceAlarmInfoV3_1 obj)
        {
            System.Drawing.Rectangle rect = obj.FacePosition;
            System.Drawing.Image img = new System.Drawing.Bitmap(obj.FacePosition.Width, obj.FacePosition.Height);
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(DataModel.Common.GetImage(obj.OriFacePicPath), new Rectangle(0, 0, obj.FacePosition.Width, obj.FacePosition.Height), rect, GraphicsUnit.Pixel);
            g.Dispose();
            pictureBox28.Image = img;

            if(obj.BlackListPicInfo.Count>0)
            { 
            pictureBox5.Image = DataModel.Common.GetImage(obj.BlackListPicInfo.ElementAt(0).Key.PictureUrl);
            labelX4.Text = obj.BlackListPicInfo.ElementAt(0).Value+"%";
            }
            if(obj.BlackListPicInfo.Count>1)
            { 
            pictureBox6.Image = DataModel.Common.GetImage(obj.BlackListPicInfo.ElementAt(1).Key.PictureUrl);
            labelX5.Text = obj.BlackListPicInfo.ElementAt(1).Value+"%";
            }
            if(obj.BlackListPicInfo.Count>2)
            { 
            pictureBox7.Image = DataModel.Common.GetImage(obj.BlackListPicInfo.ElementAt(2).Key.PictureUrl);
            labelX6.Text = obj.BlackListPicInfo.ElementAt(2).Value+"%";
            }
            dateTimeInput1.Value = obj.BeginTime;
            dateTimeInput2.Value = obj.EndTime;
            textBoxCameraName.Text = obj.CameraID;
            textBoxCameraID.Text = obj.BlackListHandle.ToString();
            pictureZoomBox1.Image = DataModel.Common.Overlay(DataModel.Common.GetImage(obj.OriFacePicPath), obj.FacePosition);
        }

        private void FormSingleTask_Load(object sender, EventArgs e)
        {
        }

        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureZoomBox1.Image = null;
        }






        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }



    }
}
