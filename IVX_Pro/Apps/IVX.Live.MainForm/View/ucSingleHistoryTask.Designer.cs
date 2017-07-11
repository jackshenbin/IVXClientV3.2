namespace IVX.Live.MainForm.View
{
    partial class ucSingleHistoryTask
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
            this.components = new System.ComponentModel.Container();
            this.labelStartTime = new DevComponents.DotNetBar.LabelX();
            this.labelAnalyseType = new DevComponents.DotNetBar.LabelX();
            this.labelStatus = new DevComponents.DotNetBar.LabelX();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.progressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reflectionImage4 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.reflectionImage3 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.labelTaskId = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonTaskInfo = new DevComponents.DotNetBar.ButtonX();
            this.buttonPlay = new DevComponents.DotNetBar.ButtonX();
            this.buttonBrief = new DevComponents.DotNetBar.ButtonX();
            this.buttonReImport = new DevComponents.DotNetBar.ButtonX();
            this.buttonReAnalyse = new DevComponents.DotNetBar.ButtonX();
            this.buttonVehicle = new DevComponents.DotNetBar.ButtonX();
            this.buttonMoveObj = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDynmicVehicle = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStartTime
            // 
            this.labelStartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStartTime.Location = new System.Drawing.Point(626, 13);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(134, 23);
            this.labelStartTime.TabIndex = 9;
            this.labelStartTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // labelAnalyseType
            // 
            this.labelAnalyseType.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelAnalyseType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelAnalyseType.Location = new System.Drawing.Point(521, 13);
            this.labelAnalyseType.Name = "labelAnalyseType";
            this.labelAnalyseType.Size = new System.Drawing.Size(94, 23);
            this.labelAnalyseType.TabIndex = 10;
            this.labelAnalyseType.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStatus.Location = new System.Drawing.Point(421, 13);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(93, 23);
            this.labelStatus.TabIndex = 11;
            this.labelStatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelName.Location = new System.Drawing.Point(103, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(162, 23);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "加载中...";
            this.labelName.Click += new System.EventHandler(this.reflectionImage3_Click);
            this.labelName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.progressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBar.Location = new System.Drawing.Point(271, 13);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(144, 23);
            this.progressBar.TabIndex = 12;
            this.progressBar.TextVisible = true;
            this.progressBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelStatus, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAnalyseType, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelStartTime, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.reflectionImage4, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.reflectionImage3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTaskId, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 50);
            this.tableLayoutPanel1.TabIndex = 13;
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.tableLayoutPanel1_MouseLeave);
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // reflectionImage4
            // 
            this.reflectionImage4.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.reflectionImage4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reflectionImage4.Image = global::IVX.Live.MainForm.Properties.Resources._305_Close_24x24_72;
            this.reflectionImage4.Location = new System.Drawing.Point(779, 13);
            this.reflectionImage4.Name = "reflectionImage4";
            this.reflectionImage4.Size = new System.Drawing.Size(27, 23);
            this.reflectionImage4.TabIndex = 8;
            this.toolTip1.SetToolTip(this.reflectionImage4, "删除任务");
            this.reflectionImage4.Click += new System.EventHandler(this.reflectionImage4_Click);
            this.reflectionImage4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // reflectionImage3
            // 
            this.reflectionImage3.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.reflectionImage3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reflectionImage3.Image = global::IVX.Live.MainForm.Properties.Resources.bkpng;
            this.reflectionImage3.Location = new System.Drawing.Point(45, 6);
            this.reflectionImage3.Name = "reflectionImage3";
            this.reflectionImage3.Size = new System.Drawing.Size(50, 37);
            this.reflectionImage3.TabIndex = 6;
            this.toolTip1.SetToolTip(this.reflectionImage3, "点击查看");
            this.reflectionImage3.Click += new System.EventHandler(this.reflectionImage3_Click);
            this.reflectionImage3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // labelTaskId
            // 
            this.labelTaskId.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelTaskId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTaskId.Location = new System.Drawing.Point(3, 13);
            this.labelTaskId.Name = "labelTaskId";
            this.labelTaskId.Size = new System.Drawing.Size(34, 23);
            this.labelTaskId.TabIndex = 13;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.tableLayoutPanel1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(818, 50);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderWidth = 0;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.buttonTaskInfo);
            this.flowLayoutPanel1.Controls.Add(this.buttonPlay);
            this.flowLayoutPanel1.Controls.Add(this.buttonBrief);
            this.flowLayoutPanel1.Controls.Add(this.buttonReImport);
            this.flowLayoutPanel1.Controls.Add(this.buttonReAnalyse);
            this.flowLayoutPanel1.Controls.Add(this.buttonVehicle);
            this.flowLayoutPanel1.Controls.Add(this.buttonMoveObj);
            this.flowLayoutPanel1.Controls.Add(this.buttonDynmicVehicle);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(100, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(458, 45);
            this.flowLayoutPanel1.TabIndex = 15;
            this.flowLayoutPanel1.Visible = false;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // buttonTaskInfo
            // 
            this.buttonTaskInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTaskInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTaskInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTaskInfo.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.查看详情5;
            this.buttonTaskInfo.HoverImage = global::IVX.Live.MainForm.Properties.Resources.查看详情4;
            this.buttonTaskInfo.Image = global::IVX.Live.MainForm.Properties.Resources.查看详情1;
            this.buttonTaskInfo.Location = new System.Drawing.Point(3, 3);
            this.buttonTaskInfo.Name = "buttonTaskInfo";
            this.buttonTaskInfo.Size = new System.Drawing.Size(38, 38);
            this.buttonTaskInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonTaskInfo.TabIndex = 11;
            this.buttonTaskInfo.Tooltip = "信息";
            this.buttonTaskInfo.Visible = false;
            this.buttonTaskInfo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPlay.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.播放5;
            this.buttonPlay.HoverImage = global::IVX.Live.MainForm.Properties.Resources.播放4;
            this.buttonPlay.Image = global::IVX.Live.MainForm.Properties.Resources.播放1;
            this.buttonPlay.Location = new System.Drawing.Point(47, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(38, 38);
            this.buttonPlay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPlay.TabIndex = 5;
            this.buttonPlay.Tooltip = "播放";
            this.buttonPlay.Visible = false;
            this.buttonPlay.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonBrief
            // 
            this.buttonBrief.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrief.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBrief.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrief.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.浓缩播放5;
            this.buttonBrief.HoverImage = global::IVX.Live.MainForm.Properties.Resources.浓缩播放4;
            this.buttonBrief.Image = global::IVX.Live.MainForm.Properties.Resources.浓缩播放1;
            this.buttonBrief.Location = new System.Drawing.Point(91, 3);
            this.buttonBrief.Name = "buttonBrief";
            this.buttonBrief.Size = new System.Drawing.Size(38, 38);
            this.buttonBrief.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonBrief.TabIndex = 6;
            this.buttonBrief.Tooltip = "摘要";
            this.buttonBrief.Visible = false;
            this.buttonBrief.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonReImport
            // 
            this.buttonReImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReImport.Location = new System.Drawing.Point(135, 3);
            this.buttonReImport.Name = "buttonReImport";
            this.buttonReImport.Size = new System.Drawing.Size(38, 38);
            this.buttonReImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonReImport.TabIndex = 7;
            this.buttonReImport.Text = "重新导入";
            this.buttonReImport.Tooltip = "重新导入";
            this.buttonReImport.Visible = false;
            this.buttonReImport.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonReAnalyse
            // 
            this.buttonReAnalyse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReAnalyse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReAnalyse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReAnalyse.Location = new System.Drawing.Point(179, 3);
            this.buttonReAnalyse.Name = "buttonReAnalyse";
            this.buttonReAnalyse.Size = new System.Drawing.Size(38, 38);
            this.buttonReAnalyse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonReAnalyse.TabIndex = 8;
            this.buttonReAnalyse.Text = "重新分析";
            this.buttonReAnalyse.Tooltip = "重新分析";
            this.buttonReAnalyse.Visible = false;
            this.buttonReAnalyse.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonVehicle
            // 
            this.buttonVehicle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonVehicle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVehicle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonVehicle.Location = new System.Drawing.Point(223, 3);
            this.buttonVehicle.Name = "buttonVehicle";
            this.buttonVehicle.Size = new System.Drawing.Size(38, 38);
            this.buttonVehicle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonVehicle.TabIndex = 9;
            this.buttonVehicle.Text = "车牌检索";
            this.buttonVehicle.Tooltip = "车牌检索";
            this.buttonVehicle.Visible = false;
            this.buttonVehicle.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonMoveObj
            // 
            this.buttonMoveObj.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonMoveObj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMoveObj.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonMoveObj.Location = new System.Drawing.Point(267, 3);
            this.buttonMoveObj.Name = "buttonMoveObj";
            this.buttonMoveObj.Size = new System.Drawing.Size(38, 38);
            this.buttonMoveObj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonMoveObj.TabIndex = 10;
            this.buttonMoveObj.Text = "行人检索";
            this.buttonMoveObj.Tooltip = "运动物检索";
            this.buttonMoveObj.Visible = false;
            this.buttonMoveObj.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonDynmicVehicle
            // 
            this.buttonDynmicVehicle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDynmicVehicle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDynmicVehicle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDynmicVehicle.Location = new System.Drawing.Point(311, 3);
            this.buttonDynmicVehicle.Name = "buttonDynmicVehicle";
            this.buttonDynmicVehicle.Size = new System.Drawing.Size(38, 38);
            this.buttonDynmicVehicle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonDynmicVehicle.TabIndex = 12;
            this.buttonDynmicVehicle.Text = "动态车牌";
            this.buttonDynmicVehicle.Tooltip = "车牌检索";
            this.buttonDynmicVehicle.Visible = false;
            this.buttonDynmicVehicle.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ucSingleHistoryTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(0, 50);
            this.Name = "ucSingleHistoryTask";
            this.Size = new System.Drawing.Size(818, 50);
            this.Load += new System.EventHandler(this.ucSingleHistoryTask_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelStartTime;
        private DevComponents.DotNetBar.LabelX labelAnalyseType;
        private DevComponents.DotNetBar.LabelX labelStatus;
        private DevComponents.DotNetBar.LabelX labelName;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage3;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage4;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelTaskId;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ButtonX buttonPlay;
        private DevComponents.DotNetBar.ButtonX buttonBrief;
        private DevComponents.DotNetBar.ButtonX buttonReImport;
        private DevComponents.DotNetBar.ButtonX buttonReAnalyse;
        private DevComponents.DotNetBar.ButtonX buttonVehicle;
        private DevComponents.DotNetBar.ButtonX buttonMoveObj;
        private DevComponents.DotNetBar.ButtonX buttonTaskInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.ButtonX buttonDynmicVehicle;

    }
}
