namespace IVX.Live.MainForm.View
{
    partial class ucCrowdHistory
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
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.searchBtn = new DevComponents.DotNetBar.ButtonX();
			this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.m_crowdCamerTree = new IVX.Live.MainForm.View.ucTaskTreeBase();
			this.m_crowdSingleHistory = new IVX.Live.MainForm.View.ucCrowdSingleHistory();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
			this.panel2.SuspendLayout();
			this.panelEx1.SuspendLayout();
			this.expandablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
			this.SuspendLayout();
			// 
			// expandableSplitter1
			// 
			this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandableSplitter1.ExpandableControl = this.panel2;
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
			this.expandableSplitter1.Location = new System.Drawing.Point(272, 0);
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size(7, 599);
			this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.expandableSplitter1.TabIndex = 18;
			this.expandableSplitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.expandablePanel1);
			this.panel2.Controls.Add(this.m_crowdCamerTree);
			this.panel2.Controls.Add(this.panelEx1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(272, 599);
			this.panel2.TabIndex = 17;
			// 
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.buttonX1);
			this.panelEx1.Controls.Add(this.buttonX2);
			this.panelEx1.Controls.Add(this.searchBtn);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelEx1.Location = new System.Drawing.Point(0, 563);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(272, 36);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 10;
			// 
			// searchBtn
			// 
			this.searchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.searchBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.searchBtn.Location = new System.Drawing.Point(177, 6);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(79, 25);
			this.searchBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.searchBtn.TabIndex = 1;
			this.searchBtn.Text = "查询";
			this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// expandablePanel1
			// 
			this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel1.Controls.Add(this.labelX2);
			this.expandablePanel1.Controls.Add(this.dateTimeEnd);
			this.expandablePanel1.Controls.Add(this.labelX3);
			this.expandablePanel1.Controls.Add(this.dateTimeStart);
			this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel1.HideControlsWhenCollapsed = true;
			this.expandablePanel1.Location = new System.Drawing.Point(0, 463);
			this.expandablePanel1.Name = "expandablePanel1";
			this.expandablePanel1.Size = new System.Drawing.Size(272, 100);
			this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel1.Style.GradientAngle = 90;
			this.expandablePanel1.TabIndex = 9;
			this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel1.TitleStyle.GradientAngle = 90;
			this.expandablePanel1.TitleText = "时间设置";
			// 
			// labelX2
			// 
			this.labelX2.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.Location = new System.Drawing.Point(0, 35);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(58, 23);
			this.labelX2.TabIndex = 6;
			this.labelX2.Text = "开始时间";
			// 
			// dateTimeEnd
			// 
			// 
			// 
			// 
			this.dateTimeEnd.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dateTimeEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dateTimeEnd.ButtonDropDown.Visible = true;
			this.dateTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dateTimeEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dateTimeEnd.IsPopupCalendarOpen = false;
			this.dateTimeEnd.Location = new System.Drawing.Point(54, 64);
			// 
			// 
			// 
			this.dateTimeEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dateTimeEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			this.dateTimeEnd.MonthCalendar.ClearButtonVisible = true;
			// 
			// 
			// 
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeEnd.MonthCalendar.DisplayMonth = new System.DateTime(2016, 3, 1, 0, 0, 0, 0);
			this.dateTimeEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dateTimeEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeEnd.MonthCalendar.TodayButtonVisible = true;
			this.dateTimeEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dateTimeEnd.Name = "dateTimeEnd";
			this.dateTimeEnd.ShowUpDown = true;
			this.dateTimeEnd.Size = new System.Drawing.Size(211, 21);
			this.dateTimeEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dateTimeEnd.TabIndex = 7;
			this.dateTimeEnd.Value = new System.DateTime(2016, 7, 26, 1, 0, 0, 0);
			// 
			// labelX3
			// 
			this.labelX3.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX3.Location = new System.Drawing.Point(0, 64);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(58, 23);
			this.labelX3.TabIndex = 8;
			this.labelX3.Text = "结束时间";
			// 
			// dateTimeStart
			// 
			// 
			// 
			// 
			this.dateTimeStart.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dateTimeStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dateTimeStart.ButtonDropDown.Visible = true;
			this.dateTimeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dateTimeStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dateTimeStart.IsPopupCalendarOpen = false;
			this.dateTimeStart.Location = new System.Drawing.Point(54, 35);
			// 
			// 
			// 
			this.dateTimeStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dateTimeStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeStart.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			this.dateTimeStart.MonthCalendar.ClearButtonVisible = true;
			// 
			// 
			// 
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeStart.MonthCalendar.DisplayMonth = new System.DateTime(2016, 3, 1, 0, 0, 0, 0);
			this.dateTimeStart.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dateTimeStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateTimeStart.MonthCalendar.TodayButtonVisible = true;
			this.dateTimeStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dateTimeStart.Name = "dateTimeStart";
			this.dateTimeStart.ShowUpDown = true;
			this.dateTimeStart.Size = new System.Drawing.Size(211, 21);
			this.dateTimeStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dateTimeStart.TabIndex = 5;
			this.dateTimeStart.Value = new System.DateTime(2016, 7, 26, 0, 0, 0, 0);
			// 
			// m_crowdCamerTree
			// 
			this.m_crowdCamerTree.AlarmImageIndex = 1;
			this.m_crowdCamerTree.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
			this.m_crowdCamerTree.CameraImageIndex = 0;
			this.m_crowdCamerTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_crowdCamerTree.HasCheck = false;
			this.m_crowdCamerTree.HasHistoryTask = false;
			this.m_crowdCamerTree.HasRootNode = false;
			this.m_crowdCamerTree.Location = new System.Drawing.Point(0, 0);
			this.m_crowdCamerTree.MuliteCheck = false;
			this.m_crowdCamerTree.Name = "m_crowdCamerTree";
			this.m_crowdCamerTree.NormalImageIndex = -1;
			this.m_crowdCamerTree.Size = new System.Drawing.Size(272, 563);
			this.m_crowdCamerTree.TabIndex = 0;
			this.m_crowdCamerTree.TreeTitle = "监控点";
			// 
			// m_crowdSingleHistory
			// 
			this.m_crowdSingleHistory.BackColor = System.Drawing.SystemColors.Control;
			this.m_crowdSingleHistory.Count = 0;
			this.m_crowdSingleHistory.CurIndex = 0;
			this.m_crowdSingleHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_crowdSingleHistory.Location = new System.Drawing.Point(279, 0);
			this.m_crowdSingleHistory.Name = "m_crowdSingleHistory";
			this.m_crowdSingleHistory.Size = new System.Drawing.Size(776, 599);
			this.m_crowdSingleHistory.TabIndex = 0;
			this.m_crowdSingleHistory.ThreadTime = ((uint)(10u));
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX1.Location = new System.Drawing.Point(22, 6);
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size(79, 25);
			this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX1.TabIndex = 1;
			this.buttonX1.Text = "复位";
			this.buttonX1.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// buttonX2
			// 
			this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX2.Location = new System.Drawing.Point(175, 6);
			this.buttonX2.Name = "buttonX2";
			this.buttonX2.Size = new System.Drawing.Size(79, 25);
			this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX2.TabIndex = 1;
			this.buttonX2.Text = "查询";
			this.buttonX2.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// ucCrowdHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_crowdSingleHistory);
			this.Controls.Add(this.expandableSplitter1);
			this.Controls.Add(this.panel2);
			this.Name = "ucCrowdHistory";
			this.Size = new System.Drawing.Size(1055, 599);
			this.Load += new System.EventHandler(this.ucCrowdHistory_Load);
			this.panel2.ResumeLayout(false);
			this.panelEx1.ResumeLayout(false);
			this.expandablePanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
			this.ResumeLayout(false);

        }
        
        #endregion
        ucCrowdSingleHistory m_crowdSingleHistory;
        ucTaskTreeBase m_crowdCamerTree;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.ButtonX searchBtn;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
		private DevComponents.DotNetBar.ButtonX buttonX1;
		private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}
