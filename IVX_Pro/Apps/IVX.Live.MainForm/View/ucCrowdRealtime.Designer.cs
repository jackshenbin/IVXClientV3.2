namespace IVX.Live.MainForm.View
{
    partial class ucCrowdRealtime
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCrowdRealtime));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.playBtn = new DevComponents.DotNetBar.ButtonX();
			this.panel1 = new System.Windows.Forms.Panel();
			this.LabelTime = new DevComponents.DotNetBar.LabelX();
			this.panel2 = new System.Windows.Forms.Panel();
			this.Savebutton = new DevComponents.DotNetBar.ButtonX();
			this.m_SingleCrowdInfo = new IVX.Live.MainForm.View.ucSingleCrowdInfo();
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.ucCrowdRealCameraTree1 = new IVX.Live.MainForm.View.ucTaskTreeBase();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.playBtn, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.Savebutton, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(163, 533);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 50);
			this.tableLayoutPanel1.TabIndex = 15;
			this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
			// 
			// playBtn
			// 
			this.playBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.playBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.playBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.playBtn.Enabled = false;
			this.playBtn.Image = global::IVX.Live.MainForm.Properties.Resources.暂停1;
			this.playBtn.Location = new System.Drawing.Point(23, 7);
			this.playBtn.Name = "playBtn";
			this.playBtn.Size = new System.Drawing.Size(34, 36);
			this.playBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.playBtn.TabIndex = 11;
			this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.LabelTime);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(503, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(291, 44);
			this.panel1.TabIndex = 13;
			// 
			// LabelTime
			// 
			// 
			// 
			// 
			this.LabelTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.LabelTime.Dock = System.Windows.Forms.DockStyle.Right;
			this.LabelTime.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabelTime.ForeColor = System.Drawing.Color.RoyalBlue;
			this.LabelTime.Location = new System.Drawing.Point(143, 0);
			this.LabelTime.Name = "LabelTime";
			this.LabelTime.Size = new System.Drawing.Size(148, 44);
			this.LabelTime.TabIndex = 9;
			this.LabelTime.Text = "0000-00-00 00:00:00";
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(103, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(354, 44);
			this.panel2.TabIndex = 14;
			// 
			// Savebutton
			// 
			this.Savebutton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.Savebutton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Savebutton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.Savebutton.Enabled = false;
			this.Savebutton.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
			this.Savebutton.Image = ((System.Drawing.Image)(resources.GetObject("Savebutton.Image")));
			this.Savebutton.Location = new System.Drawing.Point(63, 7);
			this.Savebutton.Name = "Savebutton";
			this.Savebutton.Size = new System.Drawing.Size(34, 36);
			this.Savebutton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.Savebutton.TabIndex = 12;
			this.Savebutton.TextColor = System.Drawing.Color.RoyalBlue;
			this.Savebutton.Click += new System.EventHandler(this.buttonX1_Click);
			// 
			// m_SingleCrowdInfo
			// 
			this.m_SingleCrowdInfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.m_SingleCrowdInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_SingleCrowdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SingleCrowdInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_SingleCrowdInfo.Location = new System.Drawing.Point(163, 0);
			this.m_SingleCrowdInfo.Name = "m_SingleCrowdInfo";
			this.m_SingleCrowdInfo.Size = new System.Drawing.Size(794, 533);
			this.m_SingleCrowdInfo.TabIndex = 0;
			// 
			// expandableSplitter1
			// 
			this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandableSplitter1.ExpandableControl = this.ucCrowdRealCameraTree1;
			this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
			this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
			this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
			this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
			this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.expandableSplitter1.Location = new System.Drawing.Point(153, 0);
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size(10, 583);
			this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.expandableSplitter1.TabIndex = 14;
			this.expandableSplitter1.TabStop = false;
			// 
			// ucCrowdRealCameraTree1
			// 
			this.ucCrowdRealCameraTree1.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD;
			this.ucCrowdRealCameraTree1.Dock = System.Windows.Forms.DockStyle.Left;
			this.ucCrowdRealCameraTree1.Location = new System.Drawing.Point(0, 0);
			this.ucCrowdRealCameraTree1.Name = "ucCrowdRealCameraTree1";
			this.ucCrowdRealCameraTree1.Size = new System.Drawing.Size(153, 583);
			this.ucCrowdRealCameraTree1.TabIndex = 6;
			this.ucCrowdRealCameraTree1.TreeTitle = "大客流列表";
			// 
			// ucCrowdRealtime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_SingleCrowdInfo);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.expandableSplitter1);
			this.Controls.Add(this.ucCrowdRealCameraTree1);
			this.Name = "ucCrowdRealtime";
			this.Size = new System.Drawing.Size(957, 583);
			this.Load += new System.EventHandler(this.ucCrowdRealtime_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        #endregion
        private ucTaskTreeBase ucCrowdRealCameraTree1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private ucSingleCrowdInfo m_SingleCrowdInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX Savebutton;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX LabelTime;
        private DevComponents.DotNetBar.ButtonX playBtn;
        private System.Windows.Forms.Panel panel2;



    }
}
