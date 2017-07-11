namespace IVX.Live.MainForm.View
{
    partial class ucTrafficFluxStatisticSearch
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			this.panel1 = new System.Windows.Forms.Panel();
			this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.mouthItem = new DevComponents.Editors.ComboItem();
			this.DayItem = new DevComponents.Editors.ComboItem();
			this.hourItem = new DevComponents.Editors.ComboItem();
			this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.labelinterVel = new DevComponents.DotNetBar.LabelX();
			this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.ucTrafficCameraTree1 = new IVX.Live.MainForm.View.ucTaskTreeBase();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.reSet = new DevComponents.DotNetBar.ButtonX();
			this.searchBtn = new DevComponents.DotNetBar.ButtonX();
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			this.panel1.SuspendLayout();
			this.expandablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
			this.panelEx1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.expandablePanel1);
			this.panel1.Controls.Add(this.ucTrafficCameraTree1);
			this.panel1.Controls.Add(this.panelEx1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(274, 611);
			this.panel1.TabIndex = 0;
			// 
			// expandablePanel1
			// 
			this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel1.Controls.Add(this.buttonX1);
			this.expandablePanel1.Controls.Add(this.buttonX2);
			this.expandablePanel1.Controls.Add(this.labelX2);
			this.expandablePanel1.Controls.Add(this.comboBoxEx1);
			this.expandablePanel1.Controls.Add(this.dateTimeStart);
			this.expandablePanel1.Controls.Add(this.labelX3);
			this.expandablePanel1.Controls.Add(this.labelinterVel);
			this.expandablePanel1.Controls.Add(this.dateTimeEnd);
			this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel1.HideControlsWhenCollapsed = true;
			this.expandablePanel1.Location = new System.Drawing.Point(0, 428);
			this.expandablePanel1.Name = "expandablePanel1";
			this.expandablePanel1.Size = new System.Drawing.Size(274, 150);
			this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel1.Style.GradientAngle = 90;
			this.expandablePanel1.TabIndex = 16;
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
			this.labelX2.Location = new System.Drawing.Point(3, 30);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(58, 23);
			this.labelX2.TabIndex = 11;
			this.labelX2.Text = "开始时间";
			// 
			// comboBoxEx1
			// 
			this.comboBoxEx1.DisplayMember = "Text";
			this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBoxEx1.FormattingEnabled = true;
			this.comboBoxEx1.ItemHeight = 15;
			this.comboBoxEx1.Items.AddRange(new object[] {
            this.mouthItem,
            this.DayItem,
            this.hourItem});
			this.comboBoxEx1.Location = new System.Drawing.Point(115, 92);
			this.comboBoxEx1.Name = "comboBoxEx1";
			this.comboBoxEx1.Size = new System.Drawing.Size(142, 21);
			this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.comboBoxEx1.TabIndex = 14;
			this.comboBoxEx1.Text = "月";
			// 
			// mouthItem
			// 
			this.mouthItem.Text = "月";
			this.mouthItem.Value = "1";
			// 
			// DayItem
			// 
			this.DayItem.Text = "天";
			this.DayItem.Value = "2";
			// 
			// hourItem
			// 
			this.hourItem.Text = "小时";
			this.hourItem.Value = "3";
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
			this.dateTimeStart.Location = new System.Drawing.Point(63, 32);
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
			this.dateTimeStart.Size = new System.Drawing.Size(209, 21);
			this.dateTimeStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dateTimeStart.TabIndex = 10;
			this.dateTimeStart.Value = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
			// 
			// labelX3
			// 
			this.labelX3.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX3.Location = new System.Drawing.Point(3, 59);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(58, 23);
			this.labelX3.TabIndex = 13;
			this.labelX3.Text = "结束时间";
			// 
			// labelinterVel
			// 
			this.labelinterVel.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelinterVel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelinterVel.Location = new System.Drawing.Point(3, 92);
			this.labelinterVel.Name = "labelinterVel";
			this.labelinterVel.Size = new System.Drawing.Size(58, 23);
			this.labelinterVel.TabIndex = 13;
			this.labelinterVel.Text = "时间间隔";
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
			this.dateTimeEnd.Location = new System.Drawing.Point(62, 59);
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
			this.dateTimeEnd.Size = new System.Drawing.Size(210, 21);
			this.dateTimeEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dateTimeEnd.TabIndex = 12;
			this.dateTimeEnd.Value = new System.DateTime(2016, 7, 18, 1, 0, 0, 0);
			// 
			// ucTrafficCameraTree1
			// 
			this.ucTrafficCameraTree1.AlarmImageIndex = 1;
			this.ucTrafficCameraTree1.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
			this.ucTrafficCameraTree1.CameraImageIndex = 0;
			this.ucTrafficCameraTree1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTrafficCameraTree1.HasCheck = false;
			this.ucTrafficCameraTree1.HasHistoryTask = false;
			this.ucTrafficCameraTree1.HasRootNode = false;
			this.ucTrafficCameraTree1.Location = new System.Drawing.Point(0, 0);
			this.ucTrafficCameraTree1.MuliteCheck = false;
			this.ucTrafficCameraTree1.Name = "ucTrafficCameraTree1";
			this.ucTrafficCameraTree1.NormalImageIndex = -1;
			this.ucTrafficCameraTree1.Size = new System.Drawing.Size(274, 578);
			this.ucTrafficCameraTree1.TabIndex = 0;
			this.ucTrafficCameraTree1.TreeTitle = "监控点";
			// 
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.reSet);
			this.panelEx1.Controls.Add(this.searchBtn);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelEx1.Location = new System.Drawing.Point(0, 578);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(274, 33);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 17;
			// 
			// reSet
			// 
			this.reSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.reSet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.reSet.Location = new System.Drawing.Point(16, 7);
			this.reSet.Name = "reSet";
			this.reSet.Size = new System.Drawing.Size(73, 23);
			this.reSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.reSet.TabIndex = 9;
			this.reSet.Text = "复位";
			this.reSet.Click += new System.EventHandler(this.reSet_Click);
			// 
			// searchBtn
			// 
			this.searchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.searchBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.searchBtn.Location = new System.Drawing.Point(170, 7);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(74, 23);
			this.searchBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.searchBtn.TabIndex = 9;
			this.searchBtn.Text = "查询";
			this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// expandableSplitter1
			// 
			this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandableSplitter1.ExpandableControl = this.panel1;
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
			this.expandableSplitter1.Location = new System.Drawing.Point(274, 0);
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size(10, 611);
			this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.expandableSplitter1.TabIndex = 20;
			this.expandableSplitter1.TabStop = false;
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart1.BackSecondaryColor = System.Drawing.Color.White;
			this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
			this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderlineWidth = 2;
			this.chart1.BorderSkin.BackColor = System.Drawing.Color.SteelBlue;
			this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea6.Area3DStyle.Inclination = 15;
			chartArea6.Area3DStyle.IsClustered = true;
			chartArea6.Area3DStyle.IsRightAngleAxes = false;
			chartArea6.Area3DStyle.Perspective = 10;
			chartArea6.Area3DStyle.Rotation = 10;
			chartArea6.Area3DStyle.WallWidth = 0;
			chartArea6.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
			chartArea6.AxisX.Interval = 1D;
			chartArea6.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)
						| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
			chartArea6.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea6.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			chartArea6.AxisX.ScaleBreakStyle.Enabled = true;
			chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			chartArea6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
			chartArea6.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			chartArea6.BackSecondaryColor = System.Drawing.Color.White;
			chartArea6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			chartArea6.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea6.Name = "ChartArea1";
			chartArea6.Position.Auto = false;
			chartArea6.Position.Height = 86.67578F;
			chartArea6.Position.Width = 89.09162F;
			chartArea6.Position.X = 4.963351F;
			chartArea6.Position.Y = 5.929688F;
			chartArea6.ShadowColor = System.Drawing.Color.Transparent;
			this.chart1.ChartAreas.Add(chartArea6);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend6.Alignment = System.Drawing.StringAlignment.Far;
			legend6.BackColor = System.Drawing.Color.Transparent;
			legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
			legend6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			legend6.InterlacedRows = true;
			legend6.IsDockedInsideChartArea = false;
			legend6.IsTextAutoFit = false;
			legend6.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
			legend6.Name = "Legend";
			legend6.Position.Auto = false;
			legend6.Position.Height = 8.102767F;
			legend6.Position.Width = 16.07143F;
			legend6.Position.X = 79.25446F;
			legend6.Position.Y = 0.4822135F;
			this.chart1.Legends.Add(legend6);
			this.chart1.Location = new System.Drawing.Point(284, 0);
			this.chart1.Name = "chart1";
			this.chart1.Size = new System.Drawing.Size(766, 611);
			this.chart1.TabIndex = 21;
			// 
			// buttonX2
			// 
			this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX2.Location = new System.Drawing.Point(15, 121);
			this.buttonX2.Name = "buttonX2";
			this.buttonX2.Size = new System.Drawing.Size(74, 24);
			this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX2.TabIndex = 15;
			this.buttonX2.Text = "最近一年";
			this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX1.Location = new System.Drawing.Point(170, 121);
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size(74, 24);
			this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX1.TabIndex = 15;
			this.buttonX1.Text = "最近一月";
			this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
			// 
			// ucTrafficFluxStatisticSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.expandableSplitter1);
			this.Controls.Add(this.panel1);
			this.Name = "ucTrafficFluxStatisticSearch";
			this.Size = new System.Drawing.Size(1050, 611);
			this.Load += new System.EventHandler(this.ucTrafficFluxStatisticSearch_Load);
			this.panel1.ResumeLayout(false);
			this.expandablePanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
			this.panelEx1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ucTaskTreeBase ucTrafficCameraTree1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.Editors.ComboItem mouthItem;
        private DevComponents.Editors.ComboItem DayItem;
        private DevComponents.Editors.ComboItem hourItem;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelinterVel;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX searchBtn;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private DevComponents.DotNetBar.ButtonX reSet;
		private DevComponents.DotNetBar.ButtonX buttonX1;
		private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}
