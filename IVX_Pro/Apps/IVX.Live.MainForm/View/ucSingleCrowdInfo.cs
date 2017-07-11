using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSingleCrowdInfo : UserControl
    {
        public ucSingleCrowdInfo()
        {
            InitializeComponent();
        }

        public void Init()
        {
            peoCountLabel.Text = "0人/100m²";
            cameraIdLabel.Text = "";
            pictureOrig.Image = null;
            pictureHot.Image = null;
            pictureDirection.Image = null;
        }

        public void RefreshInfo(CrowdInfo crowdInfo)
        {
            if (crowdInfo == null)
            {
                return;
            }
            string peopleCount = crowdInfo.PeopleCount.ToString() + "人";
            string area = crowdInfo.RegionArea.ToString() + "m²";
            peoCountLabel.Text = peopleCount + "/" + area; ;
            cameraIdLabel.Text = crowdInfo.CameraID;
            pictureOrig.Image = Common.GetImage(crowdInfo.OriginaloImageURL);
            pictureHot.Image = Common.GetImage(crowdInfo.HotImageURL);
            pictureDirection.Image = Common.GetImage(crowdInfo.DirectionImageURL);
            DrawRegion(crowdInfo.RegionPoints);
        }

        private void DrawRegion(List<System.Drawing.Point> regionPoints)
        {
            Graphics g = Graphics.FromImage(pictureOrig.Image);
            Pen mypen = new Pen(Color.Red, 5);
            int count = regionPoints.Count;
            Point[] p = new Point[count];
            for (int i = 0; i < count; i++)
            {
                p[i] = new Point(pictureOrig.Location.X + regionPoints[i].X, pictureOrig.Location.Y + regionPoints[i].Y);
            }
            g.DrawPolygon(mypen, p);
        }

        private void cameraIdLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void ucSingleCrowdInfo_Load(object sender, EventArgs e)
        {

        }

        private void pictureOrig_Click(object sender, EventArgs e)
        {

        }
    }
}
