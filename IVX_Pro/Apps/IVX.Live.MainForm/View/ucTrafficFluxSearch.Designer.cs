namespace IVX.Live.MainForm.View
{
    partial class ucTrafficFluxSearch
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.timePanel = new DevComponents.DotNetBar.ExpandablePanel();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.ucTrafficCameraTree1 = new IVX.Live.MainForm.View.ucTaskTreeBase();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.reSet = new DevComponents.DotNetBar.ButtonX();
			this.searchBtn = new DevComponents.DotNetBar.ButtonX();
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.dataGridViewX1 = new WinFormAppUtil.Controls.DataGridViewEx();
			this.CameraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatiIctisTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RoadWayNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrafficFluxBig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrafficFluxMiddle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrafficFluxSmall = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrafficFlux = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AvgVehiSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AvgOccupyRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QueueLen = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AvgVehiDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.noDataLabel = new DevComponents.DotNetBar.LabelX();
			this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
			this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			this.panel1.SuspendLayout();
			this.timePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
			this.panelEx1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.timePanel);
			this.panel1.Controls.Add(this.ucTrafficCameraTree1);
			this.panel1.Controls.Add(this.panelEx1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(269, 663);
			this.panel1.TabIndex = 0;
			// 
			// timePanel
			// 
			this.timePanel.CanvasColor = System.Drawing.SystemColors.Control;
			this.timePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.timePanel.Controls.Add(this.buttonX1);
			this.timePanel.Controls.Add(this.buttonX3);
			this.timePanel.Controls.Add(this.buttonX2);
			this.timePanel.Controls.Add(this.labelX2);
			this.timePanel.Controls.Add(this.dateTimeEnd);
			this.timePanel.Controls.Add(this.labelX3);
			this.timePanel.Controls.Add(this.dateTimeStart);
			this.timePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.timePanel.HideControlsWhenCollapsed = true;
			this.timePanel.Location = new System.Drawing.Point(0, 511);
			this.timePanel.Name = "timePanel";
			this.timePanel.Size = new System.Drawing.Size(269, 120);
			this.timePanel.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.timePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.timePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.timePanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.timePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.timePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.timePanel.Style.GradientAngle = 90;
			this.timePanel.TabIndex = 23;
			this.timePanel.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.timePanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.timePanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.timePanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.timePanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.timePanel.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.timePanel.TitleStyle.GradientAngle = 90;
			this.timePanel.TitleText = "时间设置";
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
			this.ucTrafficCameraTree1.Size = new System.Drawing.Size(269, 631);
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
			this.panelEx1.Location = new System.Drawing.Point(0, 631);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(269, 32);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 25;
			// 
			// reSet
			// 
			this.reSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.reSet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.reSet.Location = new System.Drawing.Point(19, 6);
			this.reSet.Name = "reSet";
			this.reSet.Size = new System.Drawing.Size(74, 23);
			this.reSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.reSet.TabIndex = 1;
			this.reSet.Text = "复位";
			this.reSet.Click += new System.EventHandler(this.reSet_Click);
			// 
			// searchBtn
			// 
			this.searchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.searchBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.searchBtn.Location = new System.Drawing.Point(172, 6);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(74, 23);
			this.searchBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.searchBtn.TabIndex = 1;
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
			this.expandableSplitter1.Location = new System.Drawing.Point(269, 0);
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size(10, 663);
			this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.expandableSplitter1.TabIndex = 20;
			this.expandableSplitter1.TabStop = false;
			// 
			// dataGridViewX1
			// 
			this.dataGridViewX1.AllowDrop = true;
			this.dataGridViewX1.AllowUserToAddRows = false;
			this.dataGridViewX1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
			this.dataGridViewX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CameraID,
            this.StatiIctisTime,
            this.RoadWayNum,
            this.TrafficFluxBig,
            this.TrafficFluxMiddle,
            this.TrafficFluxSmall,
            this.TrafficFlux,
            this.AvgVehiSpeed,
            this.AvgOccupyRatio,
            this.QueueLen,
            this.AvgVehiDistance});
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this.dataGridViewX1.Location = new System.Drawing.Point(279, 0);
			this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(0);
			this.dataGridViewX1.Name = "dataGridViewX1";
			this.dataGridViewX1.ReadOnly = true;
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridViewX1.RowTemplate.Height = 23;
			this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewX1.Size = new System.Drawing.Size(622, 663);
			this.dataGridViewX1.TabIndex = 22;
			// 
			// CameraID
			// 
			this.CameraID.HeaderText = "监测点";
			this.CameraID.Name = "CameraID";
			this.CameraID.ReadOnly = true;
			// 
			// StatiIctisTime
			// 
			this.StatiIctisTime.HeaderText = "统计时间";
			this.StatiIctisTime.Name = "StatiIctisTime";
			this.StatiIctisTime.ReadOnly = true;
			// 
			// RoadWayNum
			// 
			this.RoadWayNum.HeaderText = "车道号";
			this.RoadWayNum.Name = "RoadWayNum";
			this.RoadWayNum.ReadOnly = true;
			// 
			// TrafficFluxBig
			// 
			this.TrafficFluxBig.HeaderText = "大车流量";
			this.TrafficFluxBig.Name = "TrafficFluxBig";
			this.TrafficFluxBig.ReadOnly = true;
			// 
			// TrafficFluxMiddle
			// 
			this.TrafficFluxMiddle.HeaderText = "中车流量";
			this.TrafficFluxMiddle.Name = "TrafficFluxMiddle";
			this.TrafficFluxMiddle.ReadOnly = true;
			// 
			// TrafficFluxSmall
			// 
			this.TrafficFluxSmall.HeaderText = "小车流量";
			this.TrafficFluxSmall.Name = "TrafficFluxSmall";
			this.TrafficFluxSmall.ReadOnly = true;
			// 
			// TrafficFlux
			// 
			this.TrafficFlux.HeaderText = "总车流量";
			this.TrafficFlux.Name = "TrafficFlux";
			this.TrafficFlux.ReadOnly = true;
			// 
			// AvgVehiSpeed
			// 
			this.AvgVehiSpeed.HeaderText = "平均车速";
			this.AvgVehiSpeed.Name = "AvgVehiSpeed";
			this.AvgVehiSpeed.ReadOnly = true;
			// 
			// AvgOccupyRatio
			// 
			this.AvgOccupyRatio.HeaderText = "平均车道占用率";
			this.AvgOccupyRatio.Name = "AvgOccupyRatio";
			this.AvgOccupyRatio.ReadOnly = true;
			this.AvgOccupyRatio.Width = 150;
			// 
			// QueueLen
			// 
			this.QueueLen.HeaderText = "队列长度";
			this.QueueLen.Name = "QueueLen";
			this.QueueLen.ReadOnly = true;
			// 
			// AvgVehiDistance
			// 
			this.AvgVehiDistance.HeaderText = "平均车头间距";
			this.AvgVehiDistance.Name = "AvgVehiDistance";
			this.AvgVehiDistance.ReadOnly = true;
			this.AvgVehiDistance.Width = 150;
			// 
			// noDataLabel
			// 
			// 
			// 
			// 
			this.noDataLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.noDataLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.noDataLabel.Location = new System.Drawing.Point(502, 265);
			this.noDataLabel.Name = "noDataLabel";
			this.noDataLabel.Size = new System.Drawing.Size(291, 43);
			this.noDataLabel.TabIndex = 25;
			this.noDataLabel.Text = "没有符合条件的信息";
			this.noDataLabel.TextAlignment = System.Drawing.StringAlignment.Center;
			this.noDataLabel.Visible = false;
			// 
			// buttonX2
			// 
			this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX2.Location = new System.Drawing.Point(19, 93);
			this.buttonX2.Name = "buttonX2";
			this.buttonX2.Size = new System.Drawing.Size(74, 24);
			this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX2.TabIndex = 10;
			this.buttonX2.Text = "最近一天";
			this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
			// 
			// buttonX3
			// 
			this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX3.Location = new System.Drawing.Point(172, 90);
			this.buttonX3.Name = "buttonX3";
			this.buttonX3.Size = new System.Drawing.Size(74, 24);
			this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX3.TabIndex = 11;
			this.buttonX3.Text = "最近12小时";
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX1.Location = new System.Drawing.Point(172, 93);
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size(74, 24);
			this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX1.TabIndex = 11;
			this.buttonX1.Text = "最近12小时";
			this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
			// 
			// ucTrafficFluxSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.noDataLabel);
			this.Controls.Add(this.dataGridViewX1);
			this.Controls.Add(this.expandableSplitter1);
			this.Controls.Add(this.panel1);
			this.Name = "ucTrafficFluxSearch";
			this.Size = new System.Drawing.Size(901, 663);
			this.Load += new System.EventHandler(this.ucTrafficFluxSearch_Load);
			this.panel1.ResumeLayout(false);
			this.timePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
			this.panelEx1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ucTaskTreeBase ucTrafficCameraTree1;
        private DevComponents.DotNetBar.ExpandablePanel timePanel;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX searchBtn;
		private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private WinFormAppUtil.Controls.DataGridViewEx dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CameraID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatiIctisTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoadWayNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrafficFluxBig;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrafficFluxMiddle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrafficFluxSmall;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrafficFlux;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgVehiSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgOccupyRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueueLen;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgVehiDistance;
		private DevComponents.DotNetBar.ButtonX reSet;
		private DevComponents.DotNetBar.LabelX noDataLabel;
		private DevComponents.DotNetBar.ButtonX buttonX2;
		private DevComponents.DotNetBar.ButtonX buttonX3;
		private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
