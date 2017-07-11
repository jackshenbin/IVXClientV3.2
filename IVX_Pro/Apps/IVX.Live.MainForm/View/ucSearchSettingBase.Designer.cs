namespace IVX.Live.MainForm.View
{
    partial class ucSearchSettingBase
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
			this.m_treeList = new IVX.Live.MainForm.View.ucTaskTreeBase();
			this.buttonOk = new DevComponents.DotNetBar.ButtonX();
			this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
			this.buttonReset = new DevComponents.DotNetBar.ButtonX();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
			this.expandablePanel5 = new DevComponents.DotNetBar.ExpandablePanel();
			this.checkBoxET = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.checkBoxST = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelEx1.SuspendLayout();
			this.panelEx2.SuspendLayout();
			this.expandablePanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
			this.expandablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_treeList
			// 
			this.m_treeList.AlarmImageIndex = 1;
			this.m_treeList.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;
			this.m_treeList.CameraImageIndex = 0;
			this.m_treeList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_treeList.HasCheck = false;
			this.m_treeList.HasHistoryTask = false;
			this.m_treeList.HasRootNode = false;
			this.m_treeList.Location = new System.Drawing.Point(0, 30);
			this.m_treeList.MuliteCheck = false;
			this.m_treeList.Name = "m_treeList";
			this.m_treeList.NormalImageIndex = -1;
			this.m_treeList.Size = new System.Drawing.Size(290, 385);
			this.m_treeList.TabIndex = 20;
			this.m_treeList.TreeTitle = "监控点";
			// 
			// buttonOk
			// 
			this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonOk.Location = new System.Drawing.Point(194, 6);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "检索";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonCancel.Location = new System.Drawing.Point(93, 6);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.Visible = false;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonReset.Location = new System.Drawing.Point(12, 6);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 23);
			this.buttonReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonReset.TabIndex = 1;
			this.buttonReset.Text = "复位";
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.buttonReset);
			this.panelEx1.Controls.Add(this.buttonCancel);
			this.panelEx1.Controls.Add(this.buttonOk);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelEx1.Location = new System.Drawing.Point(0, 528);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(290, 35);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 2;
			// 
			// panelEx2
			// 
			this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx2.Controls.Add(this.m_treeList);
			this.panelEx2.Controls.Add(this.expandablePanel5);
			this.panelEx2.Controls.Add(this.expandablePanel1);
			this.panelEx2.Controls.Add(this.label1);
			this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEx2.Location = new System.Drawing.Point(0, 0);
			this.panelEx2.Name = "panelEx2";
			this.panelEx2.Size = new System.Drawing.Size(290, 528);
			this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx2.Style.GradientAngle = 90;
			this.panelEx2.TabIndex = 19;
			// 
			// expandablePanel5
			// 
			this.expandablePanel5.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel5.Controls.Add(this.checkBoxET);
			this.expandablePanel5.Controls.Add(this.checkBoxST);
			this.expandablePanel5.Controls.Add(this.labelX3);
			this.expandablePanel5.Controls.Add(this.labelX1);
			this.expandablePanel5.Controls.Add(this.dateTimeEnd);
			this.expandablePanel5.Controls.Add(this.dateTimeStart);
			this.expandablePanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel5.Location = new System.Drawing.Point(0, 415);
			this.expandablePanel5.Name = "expandablePanel5";
			this.expandablePanel5.Size = new System.Drawing.Size(290, 87);
			this.expandablePanel5.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel5.Style.GradientAngle = 90;
			this.expandablePanel5.TabIndex = 6;
			this.expandablePanel5.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel5.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel5.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel5.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel5.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel5.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel5.TitleStyle.GradientAngle = 90;
			this.expandablePanel5.TitleText = "时间设置";
			// 
			// checkBoxET
			// 
			this.checkBoxET.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkBoxET.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkBoxET.Location = new System.Drawing.Point(267, 58);
			this.checkBoxET.Name = "checkBoxET";
			this.checkBoxET.Size = new System.Drawing.Size(22, 23);
			this.checkBoxET.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.checkBoxET.TabIndex = 4;
			this.checkBoxET.CheckedChanged += new System.EventHandler(this.checkBoxET_CheckedChanged);
			// 
			// checkBoxST
			// 
			this.checkBoxST.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkBoxST.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkBoxST.Location = new System.Drawing.Point(267, 29);
			this.checkBoxST.Name = "checkBoxST";
			this.checkBoxST.Size = new System.Drawing.Size(22, 23);
			this.checkBoxST.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.checkBoxST.TabIndex = 4;
			this.checkBoxST.CheckedChanged += new System.EventHandler(this.checkBoxST_CheckedChanged);
			// 
			// labelX3
			// 
			this.labelX3.AutoSize = true;
			this.labelX3.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX3.Location = new System.Drawing.Point(3, 61);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(56, 18);
			this.labelX3.TabIndex = 3;
			this.labelX3.Text = "结束时间";
			// 
			// labelX1
			// 
			this.labelX1.AutoSize = true;
			this.labelX1.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX1.Location = new System.Drawing.Point(3, 33);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(56, 18);
			this.labelX1.TabIndex = 3;
			this.labelX1.Text = "开始时间";
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
			this.dateTimeEnd.Enabled = false;
			this.dateTimeEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dateTimeEnd.IsPopupCalendarOpen = false;
			this.dateTimeEnd.Location = new System.Drawing.Point(59, 61);
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
			this.dateTimeEnd.MonthCalendar.DisplayMonth = new System.DateTime(2016, 5, 1, 0, 0, 0, 0);
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
			this.dateTimeEnd.Size = new System.Drawing.Size(206, 21);
			this.dateTimeEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dateTimeEnd.TabIndex = 2;
			this.dateTimeEnd.Value = new System.DateTime(2016, 5, 25, 15, 59, 24, 0);
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
			this.dateTimeStart.Enabled = false;
			this.dateTimeStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dateTimeStart.IsPopupCalendarOpen = false;
			this.dateTimeStart.Location = new System.Drawing.Point(59, 31);
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
			this.dateTimeStart.MonthCalendar.DisplayMonth = new System.DateTime(2016, 5, 1, 0, 0, 0, 0);
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
			this.dateTimeStart.Size = new System.Drawing.Size(206, 21);
			this.dateTimeStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dateTimeStart.TabIndex = 1;
			this.dateTimeStart.Value = new System.DateTime(2016, 5, 25, 15, 59, 28, 0);
			// 
			// expandablePanel1
			// 
			this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel1.Controls.Add(this.pictureBox1);
			this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel1.Expanded = false;
			this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(0, 336, 290, 166);
			this.expandablePanel1.Location = new System.Drawing.Point(0, 502);
			this.expandablePanel1.Name = "expandablePanel1";
			this.expandablePanel1.Size = new System.Drawing.Size(290, 26);
			this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel1.Style.GradientAngle = 90;
			this.expandablePanel1.TabIndex = 4;
			this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel1.TitleStyle.GradientAngle = 90;
			this.expandablePanel1.TitleText = "比对设置";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::IVX.Live.MainForm.Properties.Resources.bkpng;
			this.pictureBox1.Location = new System.Drawing.Point(0, 26);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(290, 0);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Firebrick;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(290, 30);
			this.label1.TabIndex = 7;
			this.label1.Text = "搜全部";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ucSearchSettingBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.panelEx2);
			this.Controls.Add(this.panelEx1);
			this.MinimumSize = new System.Drawing.Size(290, 0);
			this.Name = "ucSearchSettingBase";
			this.Size = new System.Drawing.Size(290, 563);
			this.Load += new System.EventHandler(this.ucMoveObjSearchSetting_Load);
			this.panelEx1.ResumeLayout(false);
			this.panelEx2.ResumeLayout(false);
			this.expandablePanel5.ResumeLayout(false);
			this.expandablePanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
			this.expandablePanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
		private ucTaskTreeBase m_treeList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX buttonOk;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.ButtonX buttonReset;
		private DevComponents.DotNetBar.PanelEx panelEx1;
		private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel5;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxET;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxST;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        protected internal DevComponents.DotNetBar.PanelEx panelEx2;
    }
}
