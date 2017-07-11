namespace IVX.Live.MainForm.View {
	partial class ucLogSearch {
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
			this.logTypeComb = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.comboItem8 = new DevComponents.Editors.ComboItem();
			this.comboItem5 = new DevComponents.Editors.ComboItem();
			this.comboItem6 = new DevComponents.Editors.ComboItem();
			this.comboItem7 = new DevComponents.Editors.ComboItem();
			this.opeName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.logLevelcomb = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.comboItem4 = new DevComponents.Editors.ComboItem();
			this.comboItem1 = new DevComponents.Editors.ComboItem();
			this.comboItem2 = new DevComponents.Editors.ComboItem();
			this.comboItem3 = new DevComponents.Editors.ComboItem();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.logType = new DevComponents.DotNetBar.LabelX();
			this.searchBtn = new DevComponents.DotNetBar.ButtonX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
			this.noDataLabel = new DevComponents.DotNetBar.LabelX();
			this.logDataList = new WinFormAppUtil.Controls.DataGridViewEx();
			this.OptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LogLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LogKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
			this.panelEx2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logDataList)).BeginInit();
			this.SuspendLayout();
			// 
			// logTypeComb
			// 
			this.logTypeComb.DisplayMember = "Text";
			this.logTypeComb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.logTypeComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.logTypeComb.FormattingEnabled = true;
			this.logTypeComb.ItemHeight = 15;
			this.logTypeComb.Items.AddRange(new object[] {
            this.comboItem8,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7});
			this.logTypeComb.Location = new System.Drawing.Point(385, 15);
			this.logTypeComb.Name = "logTypeComb";
			this.logTypeComb.Size = new System.Drawing.Size(156, 21);
			this.logTypeComb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.logTypeComb.TabIndex = 5;
			// 
			// comboItem8
			// 
			this.comboItem8.Text = "所有";
			// 
			// comboItem5
			// 
			this.comboItem5.Text = "系统日志";
			// 
			// comboItem6
			// 
			this.comboItem6.Text = "操作日志";
			// 
			// comboItem7
			// 
			this.comboItem7.Text = "管理日志";
			// 
			// opeName
			// 
			// 
			// 
			// 
			this.opeName.Border.Class = "TextBoxBorder";
			this.opeName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.opeName.Location = new System.Drawing.Point(636, 15);
			this.opeName.Name = "opeName";
			this.opeName.Size = new System.Drawing.Size(146, 21);
			this.opeName.TabIndex = 4;
			// 
			// logLevelcomb
			// 
			this.logLevelcomb.DisplayMember = "Text";
			this.logLevelcomb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.logLevelcomb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.logLevelcomb.FormattingEnabled = true;
			this.logLevelcomb.ItemHeight = 15;
			this.logLevelcomb.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
			this.logLevelcomb.Location = new System.Drawing.Point(385, 41);
			this.logLevelcomb.Name = "logLevelcomb";
			this.logLevelcomb.Size = new System.Drawing.Size(156, 21);
			this.logLevelcomb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.logLevelcomb.TabIndex = 3;
			// 
			// comboItem4
			// 
			this.comboItem4.Text = "所有";
			// 
			// comboItem1
			// 
			this.comboItem1.Text = "普通";
			// 
			// comboItem2
			// 
			this.comboItem2.Text = "警告";
			// 
			// comboItem3
			// 
			this.comboItem3.Text = "错误";
			// 
			// labelX1
			// 
			// 
			// 
			// 
			this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX1.Location = new System.Drawing.Point(559, 15);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(83, 23);
			this.labelX1.TabIndex = 2;
			this.labelX1.Text = "操作者名称:";
			// 
			// labelX4
			// 
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.Location = new System.Drawing.Point(310, 15);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(69, 23);
			this.labelX4.TabIndex = 2;
			this.labelX4.Text = "日志类型:";
			// 
			// logType
			// 
			// 
			// 
			// 
			this.logType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.logType.Location = new System.Drawing.Point(310, 42);
			this.logType.Name = "logType";
			this.logType.Size = new System.Drawing.Size(69, 23);
			this.logType.TabIndex = 2;
			this.logType.Text = "日志级别:";
			// 
			// searchBtn
			// 
			this.searchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.searchBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.searchBtn.Location = new System.Drawing.Point(803, 15);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(135, 47);
			this.searchBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.searchBtn.TabIndex = 1;
			this.searchBtn.Text = "查询";
			this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// labelX2
			// 
			this.labelX2.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.Location = new System.Drawing.Point(26, 15);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(61, 23);
			this.labelX2.TabIndex = 6;
			this.labelX2.Text = "开始时间:";
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
			this.dateTimeEnd.Location = new System.Drawing.Point(93, 41);
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
			this.labelX3.Location = new System.Drawing.Point(26, 42);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(61, 23);
			this.labelX3.TabIndex = 8;
			this.labelX3.Text = "结束时间:";
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
			this.dateTimeStart.Location = new System.Drawing.Point(93, 15);
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
			// panelEx2
			// 
			this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx2.Controls.Add(this.dateTimeEnd);
			this.panelEx2.Controls.Add(this.logLevelcomb);
			this.panelEx2.Controls.Add(this.searchBtn);
			this.panelEx2.Controls.Add(this.logType);
			this.panelEx2.Controls.Add(this.logTypeComb);
			this.panelEx2.Controls.Add(this.labelX2);
			this.panelEx2.Controls.Add(this.opeName);
			this.panelEx2.Controls.Add(this.labelX4);
			this.panelEx2.Controls.Add(this.labelX3);
			this.panelEx2.Controls.Add(this.dateTimeStart);
			this.panelEx2.Controls.Add(this.labelX1);
			this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelEx2.Location = new System.Drawing.Point(0, 0);
			this.panelEx2.Name = "panelEx2";
			this.panelEx2.Size = new System.Drawing.Size(962, 73);
			this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx2.Style.GradientAngle = 90;
			this.panelEx2.TabIndex = 23;
			// 
			// noDataLabel
			// 
			// 
			// 
			// 
			this.noDataLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.noDataLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.noDataLabel.Location = new System.Drawing.Point(310, 264);
			this.noDataLabel.Name = "noDataLabel";
			this.noDataLabel.Size = new System.Drawing.Size(291, 43);
			this.noDataLabel.TabIndex = 23;
			this.noDataLabel.Text = "没有符合条件的日志信息";
			this.noDataLabel.TextAlignment = System.Drawing.StringAlignment.Center;
			this.noDataLabel.Visible = false;
			// 
			// logDataList
			// 
			this.logDataList.AllowDrop = true;
			this.logDataList.AllowUserToAddRows = false;
			this.logDataList.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
			this.logDataList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.logDataList.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.logDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.logDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.logDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OptName,
            this.Time,
            this.LogLevel,
            this.LogKind,
            this.Description});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.logDataList.DefaultCellStyle = dataGridViewCellStyle3;
			this.logDataList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logDataList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.logDataList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this.logDataList.Location = new System.Drawing.Point(0, 73);
			this.logDataList.Margin = new System.Windows.Forms.Padding(0);
			this.logDataList.Name = "logDataList";
			this.logDataList.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.logDataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.logDataList.RowTemplate.Height = 23;
			this.logDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.logDataList.Size = new System.Drawing.Size(962, 544);
			this.logDataList.TabIndex = 22;
			this.logDataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logDataList_CellContentClick);
			this.logDataList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.logDataList_Scroll);
			this.logDataList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.logDataList_SortCompare);
			// 
			// OptName
			// 
			this.OptName.HeaderText = "操作者";
			this.OptName.Name = "OptName";
			this.OptName.ReadOnly = true;
			// 
			// Time
			// 
			this.Time.HeaderText = "日志时间";
			this.Time.Name = "Time";
			this.Time.ReadOnly = true;
			this.Time.Width = 140;
			// 
			// LogLevel
			// 
			this.LogLevel.HeaderText = "日志级别";
			this.LogLevel.Name = "LogLevel";
			this.LogLevel.ReadOnly = true;
			this.LogLevel.Width = 80;
			// 
			// LogKind
			// 
			this.LogKind.HeaderText = "日志类型";
			this.LogKind.Name = "LogKind";
			this.LogKind.ReadOnly = true;
			this.LogKind.Width = 80;
			// 
			// Description
			// 
			this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Description.HeaderText = "日志描述";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			// 
			// ucLogSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.noDataLabel);
			this.Controls.Add(this.logDataList);
			this.Controls.Add(this.panelEx2);
			this.Name = "ucLogSearch";
			this.Size = new System.Drawing.Size(962, 617);
			this.Load += new System.EventHandler(this.ucLogSearch_Load);
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
			this.panelEx2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.logDataList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
		private DevComponents.DotNetBar.ButtonX searchBtn;
		private DevComponents.DotNetBar.LabelX logType;
		private DevComponents.DotNetBar.Controls.ComboBoxEx logLevelcomb;
		private DevComponents.Editors.ComboItem comboItem1;
		private DevComponents.Editors.ComboItem comboItem2;
		private DevComponents.Editors.ComboItem comboItem3;
		private DevComponents.Editors.ComboItem comboItem4;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.Controls.TextBoxX opeName;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.Controls.ComboBoxEx logTypeComb;
		private DevComponents.Editors.ComboItem comboItem5;
		private DevComponents.Editors.ComboItem comboItem6;
		private DevComponents.Editors.ComboItem comboItem7;
		private DevComponents.Editors.ComboItem comboItem8;
		private DevComponents.DotNetBar.PanelEx panelEx2;
		private DevComponents.DotNetBar.LabelX noDataLabel;
		private WinFormAppUtil.Controls.DataGridViewEx logDataList;
		private System.Windows.Forms.DataGridViewTextBoxColumn OptName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Time;
		private System.Windows.Forms.DataGridViewTextBoxColumn LogLevel;
		private System.Windows.Forms.DataGridViewTextBoxColumn LogKind;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
	}
}
