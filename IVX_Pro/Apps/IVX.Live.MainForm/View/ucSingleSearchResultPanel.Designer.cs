namespace IVX.Live.MainForm.View
{
    partial class ucSingleSearchResultPanel
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
            Clear();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucSingleSearchResult1 = new IVX.Live.MainForm.View.ucSingleSearchResult();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonLayout4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonLayout5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonLayout6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonClearSearch = new DevComponents.DotNetBar.ButtonItem();
            this.labelItemTime = new DevComponents.DotNetBar.LabelItem();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.labelRecordCountInfo = new DevComponents.DotNetBar.LabelX();
            this.pageNavigatorEx1 = new WinFormAppUtil.Controls.PageNavigatorEx();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonSnap = new DevComponents.DotNetBar.ButtonX();
            this.buttonStop = new DevComponents.DotNetBar.ButtonX();
            this.buttonPlay = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Controls.Add(this.ucSingleSearchResult1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(979, 588);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ucSingleSearchResult1
            // 
            this.ucSingleSearchResult1.BackColor = System.Drawing.Color.Transparent;
            this.ucSingleSearchResult1.Checked = true;
            this.ucSingleSearchResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleSearchResult1.Group = -1;
            this.ucSingleSearchResult1.Location = new System.Drawing.Point(3, 3);
            this.ucSingleSearchResult1.Name = "ucSingleSearchResult1";
            this.ucSingleSearchResult1.Record = null;
            this.ucSingleSearchResult1.Size = new System.Drawing.Size(189, 111);
            this.ucSingleSearchResult1.TabIndex = 3;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonLayout4,
            this.buttonLayout5,
            this.buttonLayout6,
            this.buttonClearSearch,
            this.labelItemTime});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(979, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonLayout4
            // 
            this.buttonLayout4.Name = "buttonLayout4";
            this.buttonLayout4.Text = "4×4";
            this.buttonLayout4.Click += new System.EventHandler(this.buttonLayout4_Click);
            // 
            // buttonLayout5
            // 
            this.buttonLayout5.Name = "buttonLayout5";
            this.buttonLayout5.Text = "5×5";
            this.buttonLayout5.Click += new System.EventHandler(this.buttonLayout5_Click);
            // 
            // buttonLayout6
            // 
            this.buttonLayout6.Name = "buttonLayout6";
            this.buttonLayout6.Text = "6×6";
            this.buttonLayout6.Click += new System.EventHandler(this.buttonLayout6_Click);
            // 
            // buttonClearSearch
            // 
            this.buttonClearSearch.Name = "buttonClearSearch";
            this.buttonClearSearch.Text = "关闭检索";
            this.buttonClearSearch.Click += new System.EventHandler(this.buttonClearSearch_Click);
            // 
            // labelItemTime
            // 
            this.labelItemTime.ForeColor = System.Drawing.Color.Black;
            this.labelItemTime.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItemTime.Name = "labelItemTime";
            this.labelItemTime.Text = "耗时：0ms";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.labelRecordCountInfo);
            this.panelEx3.Controls.Add(this.pageNavigatorEx1);
            this.panelEx3.Controls.Add(this.buttonOK);
            this.panelEx3.Controls.Add(this.buttonCancel);
            this.panelEx3.Controls.Add(this.buttonSnap);
            this.panelEx3.Controls.Add(this.buttonStop);
            this.panelEx3.Controls.Add(this.buttonPlay);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(0, 615);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(979, 35);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 4;
            // 
            // labelRecordCountInfo
            // 
            // 
            // 
            // 
            this.labelRecordCountInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRecordCountInfo.Location = new System.Drawing.Point(198, 7);
            this.labelRecordCountInfo.Name = "labelRecordCountInfo";
            this.labelRecordCountInfo.Size = new System.Drawing.Size(193, 23);
            this.labelRecordCountInfo.TabIndex = 7;
            this.labelRecordCountInfo.Text = "总记录数 0 条，共 0 页";
            // 
            // pageNavigatorEx1
            // 
            this.pageNavigatorEx1.Index = 0;
            this.pageNavigatorEx1.Location = new System.Drawing.Point(3, 5);
            this.pageNavigatorEx1.MaxCount = 0;
            this.pageNavigatorEx1.MinimumSize = new System.Drawing.Size(0, 25);
            this.pageNavigatorEx1.Name = "pageNavigatorEx1";
            this.pageNavigatorEx1.Size = new System.Drawing.Size(189, 25);
            this.pageNavigatorEx1.TabIndex = 6;
            this.pageNavigatorEx1.FirstClick += new System.EventHandler(this.pageNavigatorEx1_FirstClick);
            this.pageNavigatorEx1.PrivClick += new System.EventHandler(this.pageNavigatorEx1_PrivClick);
            this.pageNavigatorEx1.NextClick += new System.EventHandler(this.pageNavigatorEx1_NextClick);
            this.pageNavigatorEx1.LastClick += new System.EventHandler(this.pageNavigatorEx1_LastClick);
            this.pageNavigatorEx1.ItemClick += new System.Action<int>(this.pageNavigatorEx1_ItemClick);
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(820, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "确定";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.Location = new System.Drawing.Point(901, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            // 
            // buttonSnap
            // 
            this.buttonSnap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSnap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSnap.Location = new System.Drawing.Point(633, 5);
            this.buttonSnap.Name = "buttonSnap";
            this.buttonSnap.Size = new System.Drawing.Size(75, 23);
            this.buttonSnap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSnap.TabIndex = 2;
            this.buttonSnap.Text = "pic";
            this.buttonSnap.Visible = false;
            // 
            // buttonStop
            // 
            this.buttonStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonStop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonStop.Location = new System.Drawing.Point(467, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "info";
            this.buttonStop.Visible = false;
            // 
            // buttonPlay
            // 
            this.buttonPlay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPlay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPlay.Location = new System.Drawing.Point(548, 5);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "play";
            this.buttonPlay.Visible = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.circularProgress1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Location = new System.Drawing.Point(0, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(979, 588);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.Red;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            this.panelEx1.Visible = false;
            // 
            // circularProgress1
            // 
            this.circularProgress1.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(303, 163);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.Size = new System.Drawing.Size(375, 243);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 0;
            // 
            // ucSingleSearchResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.bar1);
            this.Name = "ucSingleSearchResultPanel";
            this.Size = new System.Drawing.Size(979, 650);
            this.Load += new System.EventHandler(this.ucSearchResultPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonLayout4;
        private DevComponents.DotNetBar.ButtonItem buttonLayout5;
        private DevComponents.DotNetBar.ButtonItem buttonLayout6;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.ButtonX buttonSnap;
        private DevComponents.DotNetBar.ButtonX buttonStop;
        private DevComponents.DotNetBar.ButtonX buttonPlay;
        private DevComponents.DotNetBar.ButtonItem buttonClearSearch;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private ucSingleSearchResult ucSingleSearchResult1;
        private DevComponents.DotNetBar.LabelX labelRecordCountInfo;
        private WinFormAppUtil.Controls.PageNavigatorEx pageNavigatorEx1;
        private DevComponents.DotNetBar.LabelItem labelItemTime;
    }
}
