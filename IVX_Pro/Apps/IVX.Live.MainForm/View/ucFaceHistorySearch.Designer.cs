namespace IVX.Live.MainForm.View {
	partial class ucFaceHistorySearch {
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.ucTaskTreeBase1 = new IVX.Live.MainForm.View.ucTaskTreeBase();
			this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
			this.sexBox = new System.Windows.Forms.ComboBox();
			this.endAge = new System.Windows.Forms.NumericUpDown();
			this.startAge = new System.Windows.Forms.NumericUpDown();
			this.labelX7 = new DevComponents.DotNetBar.LabelX();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timePanel = new DevComponents.DotNetBar.ExpandablePanel();
			this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
			this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			this.searchBtn = new DevComponents.DotNetBar.ButtonX();
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.m_ucFaceHistorySearchResultPanel = new IVX.Live.MainForm.View.ucFaceHistorySearchResultPanel();
			this.panel1.SuspendLayout();
			this.expandablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.endAge)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startAge)).BeginInit();
			this.expandablePanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.timePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
			this.panelEx1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ucTaskTreeBase1);
			this.panel1.Controls.Add(this.expandablePanel1);
			this.panel1.Controls.Add(this.expandablePanel2);
			this.panel1.Controls.Add(this.timePanel);
			this.panel1.Controls.Add(this.panelEx1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(270, 566);
			this.panel1.TabIndex = 1;
			// 
			// ucTaskTreeBase1
			// 
			this.ucTaskTreeBase1.AlarmImageIndex = 1;
			this.ucTaskTreeBase1.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
			this.ucTaskTreeBase1.CameraImageIndex = 0;
			this.ucTaskTreeBase1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTaskTreeBase1.HasCheck = false;
			this.ucTaskTreeBase1.HasHistoryTask = false;
			this.ucTaskTreeBase1.HasRootNode = false;
			this.ucTaskTreeBase1.Location = new System.Drawing.Point(0, 0);
			this.ucTaskTreeBase1.MuliteCheck = false;
			this.ucTaskTreeBase1.Name = "ucTaskTreeBase1";
			this.ucTaskTreeBase1.NormalImageIndex = -1;
			this.ucTaskTreeBase1.Size = new System.Drawing.Size(270, 155);
			this.ucTaskTreeBase1.TabIndex = 0;
			this.ucTaskTreeBase1.TreeTitle = "监控点";
			this.ucTaskTreeBase1.Load += new System.EventHandler(this.ucTaskTreeBase1_Load);
			// 
			// expandablePanel1
			// 
			this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel1.Controls.Add(this.sexBox);
			this.expandablePanel1.Controls.Add(this.endAge);
			this.expandablePanel1.Controls.Add(this.startAge);
			this.expandablePanel1.Controls.Add(this.labelX7);
			this.expandablePanel1.Controls.Add(this.labelX6);
			this.expandablePanel1.Controls.Add(this.labelX5);
			this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel1.HideControlsWhenCollapsed = true;
			this.expandablePanel1.Location = new System.Drawing.Point(0, 155);
			this.expandablePanel1.Name = "expandablePanel1";
			this.expandablePanel1.Size = new System.Drawing.Size(270, 122);
			this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel1.Style.GradientAngle = 90;
			this.expandablePanel1.TabIndex = 31;
			this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel1.TitleStyle.GradientAngle = 90;
			this.expandablePanel1.TitleText = "信息设置";
			// 
			// sexBox
			// 
			this.sexBox.FormattingEnabled = true;
			this.sexBox.Items.AddRange(new object[] {
            "未知",
            "男",
            "女"});
			this.sexBox.Location = new System.Drawing.Point(130, 35);
			this.sexBox.Name = "sexBox";
			this.sexBox.Size = new System.Drawing.Size(74, 20);
			this.sexBox.TabIndex = 10;
			// 
			// endAge
			// 
			this.endAge.Location = new System.Drawing.Point(130, 97);
			this.endAge.Name = "endAge";
			this.endAge.Size = new System.Drawing.Size(38, 21);
			this.endAge.TabIndex = 8;
			this.endAge.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// startAge
			// 
			this.startAge.Location = new System.Drawing.Point(130, 66);
			this.startAge.Name = "startAge";
			this.startAge.Size = new System.Drawing.Size(38, 21);
			this.startAge.TabIndex = 8;
			this.startAge.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// labelX7
			// 
			this.labelX7.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX7.Location = new System.Drawing.Point(54, 95);
			this.labelX7.Name = "labelX7";
			this.labelX7.Size = new System.Drawing.Size(58, 23);
			this.labelX7.TabIndex = 7;
			this.labelX7.Text = "结束年龄";
			// 
			// labelX6
			// 
			this.labelX6.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX6.Location = new System.Drawing.Point(54, 66);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(58, 23);
			this.labelX6.TabIndex = 7;
			this.labelX6.Text = "开始年龄";
			// 
			// labelX5
			// 
			this.labelX5.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX5.Location = new System.Drawing.Point(54, 35);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(58, 23);
			this.labelX5.TabIndex = 7;
			this.labelX5.Text = "性别";
			// 
			// expandablePanel2
			// 
			this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel2.Controls.Add(this.pictureBox1);
			this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel2.HideControlsWhenCollapsed = true;
			this.expandablePanel2.Location = new System.Drawing.Point(0, 277);
			this.expandablePanel2.Name = "expandablePanel2";
			this.expandablePanel2.Size = new System.Drawing.Size(270, 132);
			this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel2.Style.GradientAngle = 90;
			this.expandablePanel2.TabIndex = 32;
			this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel2.TitleStyle.GradientAngle = 90;
			this.expandablePanel2.TitleText = "图片设置";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::IVX.Live.MainForm.Properties.Resources.bkpng;
			this.pictureBox1.Location = new System.Drawing.Point(0, 26);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(270, 106);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_Click);
			// 
			// timePanel
			// 
			this.timePanel.CanvasColor = System.Drawing.SystemColors.Control;
			this.timePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.timePanel.Controls.Add(this.buttonX3);
			this.timePanel.Controls.Add(this.buttonX2);
			this.timePanel.Controls.Add(this.labelX2);
			this.timePanel.Controls.Add(this.dateTimeEnd);
			this.timePanel.Controls.Add(this.labelX3);
			this.timePanel.Controls.Add(this.dateTimeStart);
			this.timePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.timePanel.HideControlsWhenCollapsed = true;
			this.timePanel.Location = new System.Drawing.Point(0, 409);
			this.timePanel.Name = "timePanel";
			this.timePanel.Size = new System.Drawing.Size(270, 120);
			this.timePanel.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.timePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.timePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.timePanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.timePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.timePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.timePanel.Style.GradientAngle = 90;
			this.timePanel.TabIndex = 29;
			this.timePanel.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.timePanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.timePanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.timePanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.timePanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.timePanel.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.timePanel.TitleStyle.GradientAngle = 90;
			this.timePanel.TitleText = "时间设置";
			// 
			// buttonX3
			// 
			this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX3.Location = new System.Drawing.Point(178, 91);
			this.buttonX3.Name = "buttonX3";
			this.buttonX3.Size = new System.Drawing.Size(76, 24);
			this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX3.TabIndex = 1;
			this.buttonX3.Text = "最近12小时";
			this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
			// 
			// buttonX2
			// 
			this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX2.Location = new System.Drawing.Point(19, 91);
			this.buttonX2.Name = "buttonX2";
			this.buttonX2.Size = new System.Drawing.Size(76, 24);
			this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX2.TabIndex = 1;
			this.buttonX2.Text = "最近一天";
			this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
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
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.buttonX1);
			this.panelEx1.Controls.Add(this.searchBtn);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelEx1.Location = new System.Drawing.Point(0, 529);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(270, 37);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 30;
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX1.Location = new System.Drawing.Point(19, 6);
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size(76, 24);
			this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX1.TabIndex = 1;
			this.buttonX1.Text = "复位";
			// 
			// searchBtn
			// 
			this.searchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.searchBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.searchBtn.Location = new System.Drawing.Point(178, 6);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(76, 24);
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
			this.expandableSplitter1.Location = new System.Drawing.Point(270, 0);
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size(7, 566);
			this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.expandableSplitter1.TabIndex = 20;
			this.expandableSplitter1.TabStop = false;
			// 
			// m_ucFaceHistorySearchResultPanel
			// 
			this.m_ucFaceHistorySearchResultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ucFaceHistorySearchResultPanel.Location = new System.Drawing.Point(270, 0);
			this.m_ucFaceHistorySearchResultPanel.Name = "m_ucFaceHistorySearchResultPanel";
			this.m_ucFaceHistorySearchResultPanel.Size = new System.Drawing.Size(745, 566);
			this.m_ucFaceHistorySearchResultPanel.TabIndex = 21;
			// 
			// ucFaceHistorySearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.expandableSplitter1);
			this.Controls.Add(this.m_ucFaceHistorySearchResultPanel);
			this.Controls.Add(this.panel1);
			this.Name = "ucFaceHistorySearch";
			this.Size = new System.Drawing.Size(1015, 566);
			this.Load += new System.EventHandler(this.ucFaceHistorySearch_Load);
			this.panel1.ResumeLayout(false);
			this.expandablePanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.endAge)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startAge)).EndInit();
			this.expandablePanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.timePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
			this.panelEx1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ucTaskTreeBase ucTaskTreeBase1;
		private System.Windows.Forms.Panel panel1;
		private DevComponents.DotNetBar.ExpandablePanel timePanel;
		private DevComponents.DotNetBar.ButtonX buttonX3;
		private DevComponents.DotNetBar.ButtonX buttonX2;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
		private DevComponents.DotNetBar.PanelEx panelEx1;
		private DevComponents.DotNetBar.ButtonX buttonX1;
		private DevComponents.DotNetBar.ButtonX searchBtn;
		private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
		private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
		private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
		private DevComponents.DotNetBar.LabelX labelX2;
		private ucFaceHistorySearchResultPanel m_ucFaceHistorySearchResultPanel;
		private DevComponents.DotNetBar.LabelX labelX5;
		private DevComponents.DotNetBar.LabelX labelX6;
		private DevComponents.DotNetBar.LabelX labelX7;
		private System.Windows.Forms.ComboBox sexBox;
		private System.Windows.Forms.NumericUpDown endAge;
		private System.Windows.Forms.NumericUpDown startAge;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
