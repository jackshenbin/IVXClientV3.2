namespace IVX.Live.MainForm.View {
	partial class ucBehaviorEventSearch {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_CameraTree = new IVX.Live.MainForm.View.ucTaskTreeBase();
            this.typePanel = new DevComponents.DotNetBar.ExpandablePanel();
            this.checkBoxX8 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxXALl = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
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
            this.noDataLabel = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new WinFormAppUtil.Controls.DataGridViewEx();
            this.CameraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginTimeSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.typePanel.SuspendLayout();
            this.timePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_CameraTree);
            this.panel1.Controls.Add(this.typePanel);
            this.panel1.Controls.Add(this.timePanel);
            this.panel1.Controls.Add(this.panelEx1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 634);
            this.panel1.TabIndex = 0;
            // 
            // m_CameraTree
            // 
            this.m_CameraTree.AlarmImageIndex = 1;
            this.m_CameraTree.AllowDrop = true;
            this.m_CameraTree.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
            this.m_CameraTree.AutoScroll = true;
            this.m_CameraTree.CameraImageIndex = 0;
            this.m_CameraTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_CameraTree.HasCheck = false;
            this.m_CameraTree.HasHistoryTask = false;
            this.m_CameraTree.HasRootNode = false;
            this.m_CameraTree.Location = new System.Drawing.Point(0, 0);
            this.m_CameraTree.MuliteCheck = false;
            this.m_CameraTree.Name = "m_CameraTree";
            this.m_CameraTree.NormalImageIndex = -1;
            this.m_CameraTree.Size = new System.Drawing.Size(270, 453);
            this.m_CameraTree.TabIndex = 0;
            this.m_CameraTree.TreeTitle = "监控点";
            // 
            // typePanel
            // 
            this.typePanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.typePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.typePanel.Controls.Add(this.checkBoxX8);
            this.typePanel.Controls.Add(this.checkBoxX7);
            this.typePanel.Controls.Add(this.checkBoxX6);
            this.typePanel.Controls.Add(this.checkBoxX5);
            this.typePanel.Controls.Add(this.checkBoxX4);
            this.typePanel.Controls.Add(this.checkBoxX3);
            this.typePanel.Controls.Add(this.checkBoxX2);
            this.typePanel.Controls.Add(this.checkBoxXALl);
            this.typePanel.Controls.Add(this.checkBoxX1);
            this.typePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.typePanel.Expanded = false;
            this.typePanel.ExpandedBounds = new System.Drawing.Rectangle(0, 302, 270, 177);
            this.typePanel.HideControlsWhenCollapsed = true;
            this.typePanel.Location = new System.Drawing.Point(0, 453);
            this.typePanel.Name = "typePanel";
            this.typePanel.Size = new System.Drawing.Size(270, 26);
            this.typePanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.typePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.typePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.typePanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.typePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.typePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.typePanel.Style.GradientAngle = 90;
            this.typePanel.TabIndex = 24;
            this.typePanel.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.typePanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.typePanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.typePanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.typePanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.typePanel.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.typePanel.TitleStyle.GradientAngle = 90;
            this.typePanel.TitleText = "事件类型";
            // 
            // checkBoxX8
            // 
            this.checkBoxX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX8.Checked = true;
            this.checkBoxX8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX8.CheckValue = "Y";
            this.checkBoxX8.Location = new System.Drawing.Point(3, 143);
            this.checkBoxX8.Name = "checkBoxX8";
            this.checkBoxX8.Size = new System.Drawing.Size(103, 23);
            this.checkBoxX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX8.TabIndex = 9;
            this.checkBoxX8.Text = "目标逆向越界";
            // 
            // checkBoxX7
            // 
            this.checkBoxX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX7.Checked = true;
            this.checkBoxX7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX7.CheckValue = "Y";
            this.checkBoxX7.Location = new System.Drawing.Point(3, 114);
            this.checkBoxX7.Name = "checkBoxX7";
            this.checkBoxX7.Size = new System.Drawing.Size(117, 23);
            this.checkBoxX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX7.TabIndex = 10;
            this.checkBoxX7.Text = "目标正向越界";
            // 
            // checkBoxX6
            // 
            this.checkBoxX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX6.Checked = true;
            this.checkBoxX6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX6.CheckValue = "Y";
            this.checkBoxX6.Location = new System.Drawing.Point(178, 85);
            this.checkBoxX6.Name = "checkBoxX6";
            this.checkBoxX6.Size = new System.Drawing.Size(84, 23);
            this.checkBoxX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX6.TabIndex = 11;
            this.checkBoxX6.Text = "目标闯出";
            // 
            // checkBoxX5
            // 
            this.checkBoxX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX5.Checked = true;
            this.checkBoxX5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX5.CheckValue = "Y";
            this.checkBoxX5.Location = new System.Drawing.Point(82, 85);
            this.checkBoxX5.Name = "checkBoxX5";
            this.checkBoxX5.Size = new System.Drawing.Size(78, 23);
            this.checkBoxX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX5.TabIndex = 12;
            this.checkBoxX5.Text = "目标闯入";
            // 
            // checkBoxX4
            // 
            this.checkBoxX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX4.Checked = true;
            this.checkBoxX4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX4.CheckValue = "Y";
            this.checkBoxX4.Location = new System.Drawing.Point(3, 85);
            this.checkBoxX4.Name = "checkBoxX4";
            this.checkBoxX4.Size = new System.Drawing.Size(76, 23);
            this.checkBoxX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX4.TabIndex = 13;
            this.checkBoxX4.Text = "奔跑";
            // 
            // checkBoxX3
            // 
            this.checkBoxX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX3.Checked = true;
            this.checkBoxX3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX3.CheckValue = "Y";
            this.checkBoxX3.Location = new System.Drawing.Point(178, 56);
            this.checkBoxX3.Name = "checkBoxX3";
            this.checkBoxX3.Size = new System.Drawing.Size(84, 23);
            this.checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX3.TabIndex = 14;
            this.checkBoxX3.Text = "拉横幅";
            // 
            // checkBoxX2
            // 
            this.checkBoxX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX2.Checked = true;
            this.checkBoxX2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX2.CheckValue = "Y";
            this.checkBoxX2.Location = new System.Drawing.Point(82, 56);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.Size = new System.Drawing.Size(78, 23);
            this.checkBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX2.TabIndex = 15;
            this.checkBoxX2.Text = "撒传单";
            // 
            // checkBoxXALl
            // 
            this.checkBoxXALl.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxXALl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxXALl.Checked = true;
            this.checkBoxXALl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxXALl.CheckValue = "Y";
            this.checkBoxXALl.Location = new System.Drawing.Point(3, 27);
            this.checkBoxXALl.Name = "checkBoxXALl";
            this.checkBoxXALl.Size = new System.Drawing.Size(103, 23);
            this.checkBoxXALl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxXALl.TabIndex = 16;
            this.checkBoxXALl.Text = "查询事件类型";
            this.checkBoxXALl.CheckedChanged += new System.EventHandler(this.checkBoxXALl_CheckedChanged);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Checked = true;
            this.checkBoxX1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX1.CheckValue = "Y";
            this.checkBoxX1.Location = new System.Drawing.Point(3, 56);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(73, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 16;
            this.checkBoxX1.Text = "聚集";
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
            this.timePanel.Location = new System.Drawing.Point(0, 479);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(270, 118);
            this.timePanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.timePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.timePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.timePanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.timePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.timePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.timePanel.Style.GradientAngle = 90;
            this.timePanel.TabIndex = 27;
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
            this.buttonX3.Text = "最近一天";
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
            this.buttonX2.Text = "最近七天";
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
            this.panelEx1.Location = new System.Drawing.Point(0, 597);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(270, 37);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 26;
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
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
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
            this.expandableSplitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(270, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 634);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 20;
            this.expandableSplitter1.TabStop = false;
            // 
            // noDataLabel
            // 
            // 
            // 
            // 
            this.noDataLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.noDataLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.noDataLabel.Location = new System.Drawing.Point(466, 256);
            this.noDataLabel.Name = "noDataLabel";
            this.noDataLabel.Size = new System.Drawing.Size(291, 43);
            this.noDataLabel.TabIndex = 24;
            this.noDataLabel.Text = "没有符合条件的信息";
            this.noDataLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.noDataLabel.Visible = false;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowDrop = true;
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
            this.dataGridViewX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CameraID,
            this.BeginTimeSec,
            this.EndTimeSec,
            this.EventType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(280, 0);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(648, 634);
            this.dataGridViewX1.TabIndex = 22;
            this.dataGridViewX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellDoubleClick);
            // 
            // CameraID
            // 
            this.CameraID.HeaderText = "相机名";
            this.CameraID.Name = "CameraID";
            this.CameraID.ReadOnly = true;
            // 
            // BeginTimeSec
            // 
            this.BeginTimeSec.FillWeight = 200F;
            this.BeginTimeSec.HeaderText = "开始时间";
            this.BeginTimeSec.Name = "BeginTimeSec";
            this.BeginTimeSec.ReadOnly = true;
            this.BeginTimeSec.Width = 200;
            // 
            // EndTimeSec
            // 
            this.EndTimeSec.FillWeight = 200F;
            this.EndTimeSec.HeaderText = "结束时间";
            this.EndTimeSec.Name = "EndTimeSec";
            this.EndTimeSec.ReadOnly = true;
            this.EndTimeSec.Width = 200;
            // 
            // EventType
            // 
            this.EventType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EventType.HeaderText = "事件类型";
            this.EventType.Name = "EventType";
            this.EventType.ReadOnly = true;
            // 
            // ucBehaviorEventSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noDataLabel);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ucBehaviorEventSearch";
            this.Size = new System.Drawing.Size(928, 634);
            this.Load += new System.EventHandler(this.ucBehaviorEventSearch_Load);
            this.panel1.ResumeLayout(false);
            this.typePanel.ResumeLayout(false);
            this.timePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
		private WinFormAppUtil.Controls.DataGridViewEx dataGridViewX1;
		private DevComponents.DotNetBar.LabelX noDataLabel;
		private System.Windows.Forms.DataGridViewTextBoxColumn CameraID;
		private System.Windows.Forms.DataGridViewTextBoxColumn BeginTimeSec;
		private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeSec;
		private System.Windows.Forms.DataGridViewTextBoxColumn EventType;
		private DevComponents.DotNetBar.ExpandablePanel typePanel;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX8;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX7;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX6;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX5;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX4;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxXALl;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
		private ucTaskTreeBase m_CameraTree;
		private DevComponents.DotNetBar.PanelEx panelEx1;
		private DevComponents.DotNetBar.ButtonX buttonX1;
		private DevComponents.DotNetBar.ButtonX searchBtn;
		private DevComponents.DotNetBar.ExpandablePanel timePanel;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
		private DevComponents.DotNetBar.ButtonX buttonX2;
		private DevComponents.DotNetBar.ButtonX buttonX3;
	}
}
