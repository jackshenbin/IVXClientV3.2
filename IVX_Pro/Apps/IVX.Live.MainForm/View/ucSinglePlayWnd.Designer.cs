namespace IVX.Live.MainForm.View
{
    partial class ucSinglePlayWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSinglePlayWnd));
            this.trackBarEx1 = new WinFormAppUtil.Controls.TrackBarEx();
            this.axVdaPlayer1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarEx1
            // 
            this.trackBarEx1.BackColor = System.Drawing.Color.Transparent;
            this.trackBarEx1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trackBarEx1.BackgroundImage")));
            this.trackBarEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trackBarEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarEx1.Location = new System.Drawing.Point(0, 350);
            this.trackBarEx1.MaxValue = ((long)(1000));
            this.trackBarEx1.Name = "trackBarEx1";
            this.trackBarEx1.Size = new System.Drawing.Size(502, 7);
            this.trackBarEx1.TabIndex = 2;
            this.trackBarEx1.Value = ((long)(0));
            this.trackBarEx1.ValueChangedByMouse += new System.EventHandler(this.trackBarEx1_ValueChangedByMouse);
            // 
            // axVdaPlayer1
            // 
            this.axVdaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axVdaPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // 
            // 
            this.axVdaPlayer1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.axVdaPlayer1.BackgroundStyle.BorderBottomWidth = 1;
            this.axVdaPlayer1.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.axVdaPlayer1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.axVdaPlayer1.BackgroundStyle.BorderLeftWidth = 1;
            this.axVdaPlayer1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.axVdaPlayer1.BackgroundStyle.BorderRightWidth = 1;
            this.axVdaPlayer1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.axVdaPlayer1.BackgroundStyle.BorderTopWidth = 1;
            this.axVdaPlayer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.axVdaPlayer1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.axVdaPlayer1.ForeColor = System.Drawing.Color.DarkOrange;
            this.axVdaPlayer1.Location = new System.Drawing.Point(1, 30);
            this.axVdaPlayer1.Name = "axVdaPlayer1";
            this.axVdaPlayer1.Size = new System.Drawing.Size(500, 290);
            this.axVdaPlayer1.TabIndex = 3;
            this.axVdaPlayer1.Text = "No Video";
            this.axVdaPlayer1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.axVdaPlayer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelX1_MouseClick);
            this.axVdaPlayer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelX1_MouseDoubleClick);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.axVdaPlayer1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(502, 350);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Black;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.Black;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            this.panelEx1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelX1_MouseClick);
            this.panelEx1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelX1_MouseDoubleClick);
            // 
            // ucSinglePlayWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.trackBarEx1);
            this.Name = "ucSinglePlayWnd";
            this.Size = new System.Drawing.Size(502, 357);
            this.Load += new System.EventHandler(this.ucSinglePlayWnd_Load);
            this.SizeChanged += new System.EventHandler(this.ucSinglePlayWnd_SizeChanged);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormAppUtil.Controls.TrackBarEx trackBarEx1;
        private DevComponents.DotNetBar.LabelX axVdaPlayer1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
    }
}
