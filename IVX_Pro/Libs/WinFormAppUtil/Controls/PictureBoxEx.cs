using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppUtil.Controls
{
    public partial class PictureBoxEx : System.Windows.Forms.Label
    {
        public PictureBoxEx()
        {
            InitializeComponent();
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

        }
        public System.Drawing.Image Image { get { return this.BackgroundImage; } set { this.BackgroundImage = value; } }
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
    }
}
