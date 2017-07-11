using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppUtil.Controls
{
    public partial class PictureZoomBox : UserControl
    {
        private double m_zoom = 1.0f;
        private Point m_startWheelPoint = new Point();

        private bool m_isMove = false;
        private Point m_startMovePoint = new Point();

        public Image Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Location = new Point();
                pictureBox1.Size = this.Size;
                m_zoom = (double)this.Width / (double)value.Width;
            }
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            // 调用基类 OnPaint
            try
            {
                base.OnPaint(pe);
            }
            catch
            {
                this.Invalidate();
            }
        }

        public PictureZoomBox()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            pictureBox1.Location = new Point();
            pictureBox1.Size = this.Size;
        }
        void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                m_zoom *= 1.2f;
                if (m_zoom > 4f)
                    m_zoom = 4f;

            }
            else
            { 
                m_zoom /= 1.2f;
                if (m_zoom < 0.1f)
                    m_zoom = 0.1f;
            }
            m_startWheelPoint =  e.Location;
            ZoomPicture();
        }

        void ZoomPicture()
        {
            if (pictureBox1.Image != null)
            {
                int w1 = pictureBox1.Size.Width;
                pictureBox1.Size = new System.Drawing.Size((int)(pictureBox1.Image.Width * m_zoom), (int)(pictureBox1.Image.Height * m_zoom));
                int w2 = pictureBox1.Size.Width;
                pictureBox1.Location = new Point( m_startWheelPoint.X+pictureBox1.Location.X-(int)(m_startWheelPoint.X*w2/w1),m_startWheelPoint.Y+pictureBox1.Location.Y-(int)(m_startWheelPoint.Y*w2/w1));
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_isMove)
            {
                int x = e.Location.X - m_startMovePoint.X;
                int y = e.Location.Y - m_startMovePoint.Y;
                pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X + x, pictureBox1.Location.Y + y);
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                m_isMove = true;
                m_startMovePoint = e.Location;
                pictureBox1.Cursor = Cursors.SizeAll;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m_isMove = false; m_startMovePoint = new System.Drawing.Point();
            pictureBox1.Cursor = Cursors.Default;

        }

        private void PictureZoomBox_Resize(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Location = new Point();
                pictureBox1.Size = this.Size;
                m_zoom = (double)this.Width / (double)pictureBox1.Image.Width;
            }
        }
    }
}
