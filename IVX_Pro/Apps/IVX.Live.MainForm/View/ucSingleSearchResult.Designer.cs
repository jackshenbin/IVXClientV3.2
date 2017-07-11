namespace IVX.Live.MainForm.View
{
    partial class ucSingleSearchResult
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new WinFormAppUtil.Controls.PictureBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.line3 = new DevComponents.DotNetBar.Controls.Line();
            this.line4 = new DevComponents.DotNetBar.Controls.Line();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::IVX.Live.MainForm.Properties.Resources.bkpng;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 68);
            //this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseDoubleClick);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.CheckedPicture_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseMove);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelX1.Location = new System.Drawing.Point(2, 70);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(133, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "沪A88888";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseClick);
            this.labelX1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseDoubleClick);
            this.labelX1.MouseLeave += new System.EventHandler(this.CheckedPicture_MouseLeave);
            this.labelX1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseMove);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelX2.Location = new System.Drawing.Point(2, 93);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(133, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "2016-06-01 13:45:32";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseClick);
            this.labelX2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseDoubleClick);
            this.labelX2.MouseLeave += new System.EventHandler(this.CheckedPicture_MouseLeave);
            this.labelX2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckedPicture_MouseMove);
            // 
            // line1
            // 
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.ForeColor = System.Drawing.Color.Transparent;
            this.line1.Location = new System.Drawing.Point(2, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(133, 2);
            this.line1.TabIndex = 6;
            this.line1.Text = "line1";
            this.line1.Thickness = 2;
            // 
            // line2
            // 
            this.line2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line2.ForeColor = System.Drawing.Color.Transparent;
            this.line2.Location = new System.Drawing.Point(2, 116);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(133, 2);
            this.line2.TabIndex = 7;
            this.line2.Text = "line2";
            this.line2.Thickness = 2;
            // 
            // line3
            // 
            this.line3.Dock = System.Windows.Forms.DockStyle.Left;
            this.line3.ForeColor = System.Drawing.Color.Transparent;
            this.line3.Location = new System.Drawing.Point(0, 0);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(2, 118);
            this.line3.TabIndex = 8;
            this.line3.Text = "line3";
            this.line3.Thickness = 2;
            this.line3.VerticalLine = true;
            // 
            // line4
            // 
            this.line4.Dock = System.Windows.Forms.DockStyle.Right;
            this.line4.ForeColor = System.Drawing.Color.Transparent;
            this.line4.Location = new System.Drawing.Point(135, 0);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(2, 118);
            this.line4.TabIndex = 9;
            this.line4.Text = "line4";
            this.line4.Thickness = 2;
            this.line4.VerticalLine = true;
            // 
            // ucSingleSearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line3);
            this.Controls.Add(this.line4);
            this.Name = "ucSingleSearchResult";
            this.Size = new System.Drawing.Size(137, 118);
            this.Load += new System.EventHandler(this.ucSearchResultPanel_Load);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormAppUtil.Controls.PictureBoxEx pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.Line line2;
        private DevComponents.DotNetBar.Controls.Line line3;
        private DevComponents.DotNetBar.Controls.Line line4;

    }
}
