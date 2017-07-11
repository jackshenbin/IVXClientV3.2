namespace IVX.Live.MainForm.View
{
    partial class ucSingleCrowdInfo
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
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.pictureOrig = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureHot = new System.Windows.Forms.PictureBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureDirection = new System.Windows.Forms.PictureBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cameraIdLabel = new DevComponents.DotNetBar.LabelX();
            this.peoCountLabel = new DevComponents.DotNetBar.LabelX();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOrig)).BeginInit();
            this.pictureOrig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHot)).BeginInit();
            this.pictureHot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDirection)).BeginInit();
            this.pictureDirection.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Desktop;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.splitContainer1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 25);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(766, 465);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 2;
            this.panelEx2.Text = "panelEx2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureOrig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(766, 465);
            this.splitContainer1.SplitterDistance = 527;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.Control;
            this.labelX3.Location = new System.Drawing.Point(3, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(118, 50);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "原始图";
            // 
            // pictureOrig
            // 
            this.pictureOrig.Controls.Add(this.labelX3);
            this.pictureOrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureOrig.Location = new System.Drawing.Point(0, 0);
            this.pictureOrig.Name = "pictureOrig";
            this.pictureOrig.Size = new System.Drawing.Size(527, 465);
            this.pictureOrig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureOrig.TabIndex = 0;
            this.pictureOrig.TabStop = false;
            this.pictureOrig.Click += new System.EventHandler(this.pictureOrig_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureHot);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureDirection);
            this.splitContainer2.Size = new System.Drawing.Size(235, 465);
            this.splitContainer2.SplitterDistance = 230;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureHot
            // 
            this.pictureHot.Controls.Add(this.labelX1);
            this.pictureHot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureHot.Location = new System.Drawing.Point(0, 0);
            this.pictureHot.Name = "pictureHot";
            this.pictureHot.Size = new System.Drawing.Size(235, 230);
            this.pictureHot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHot.TabIndex = 0;
            this.pictureHot.TabStop = false;
            this.pictureHot.Tag = "";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(102, 33);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "热力图";
            // 
            // pictureDirection
            // 
            this.pictureDirection.Controls.Add(this.labelX2);
            this.pictureDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureDirection.Location = new System.Drawing.Point(0, 0);
            this.pictureDirection.Name = "pictureDirection";
            this.pictureDirection.Size = new System.Drawing.Size(235, 231);
            this.pictureDirection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDirection.TabIndex = 0;
            this.pictureDirection.TabStop = false;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.Control;
            this.labelX2.Location = new System.Drawing.Point(3, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(102, 33);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "方向图";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tableLayoutPanel2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(766, 25);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Text = "panelEx1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel2.Controls.Add(this.cameraIdLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.peoCountLabel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(766, 25);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cameraIdLabel
            // 
            // 
            // 
            // 
            this.cameraIdLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cameraIdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraIdLabel.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cameraIdLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cameraIdLabel.Location = new System.Drawing.Point(195, 3);
            this.cameraIdLabel.Name = "cameraIdLabel";
            this.cameraIdLabel.SingleLineColor = System.Drawing.SystemColors.Control;
            this.cameraIdLabel.Size = new System.Drawing.Size(342, 19);
            this.cameraIdLabel.TabIndex = 1;
            this.cameraIdLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.cameraIdLabel.Click += new System.EventHandler(this.cameraIdLabel_Click_1);
            // 
            // peoCountLabel
            // 
            // 
            // 
            // 
            this.peoCountLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.peoCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peoCountLabel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.peoCountLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.peoCountLabel.Location = new System.Drawing.Point(543, 3);
            this.peoCountLabel.Name = "peoCountLabel";
            this.peoCountLabel.SingleLineColor = System.Drawing.SystemColors.Control;
            this.peoCountLabel.Size = new System.Drawing.Size(220, 19);
            this.peoCountLabel.TabIndex = 0;
            this.peoCountLabel.Text = "0人/100m²";
            this.peoCountLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ucSingleCrowdInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "ucSingleCrowdInfo";
            this.Size = new System.Drawing.Size(766, 490);
            this.Load += new System.EventHandler(this.ucSingleCrowdInfo_Load);
            this.panelEx2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureOrig)).EndInit();
            this.pictureOrig.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHot)).EndInit();
            this.pictureHot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDirection)).EndInit();
            this.pictureDirection.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureOrig;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureHot;
        private System.Windows.Forms.PictureBox pictureDirection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.LabelX peoCountLabel;
        private DevComponents.DotNetBar.LabelX cameraIdLabel;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}
