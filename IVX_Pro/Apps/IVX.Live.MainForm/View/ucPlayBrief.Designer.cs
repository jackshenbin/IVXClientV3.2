namespace IVX.Live.MainForm.View
{
    partial class ucPlayBrief
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sliderSize = new DevComponents.DotNetBar.SliderItem();
            this.sliderSpeed = new DevComponents.DotNetBar.SliderItem();
            this.panelEx5 = new System.Windows.Forms.Panel();
            this.ucSingleBriefPlayWnd1 = new IVX.Live.MainForm.View.ucSingleBriefPlayWnd();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelTime = new DevComponents.DotNetBar.LabelX();
            this.buttonPlay = new DevComponents.DotNetBar.ButtonX();
            this.buttonStop = new DevComponents.DotNetBar.ButtonX();
            this.buttonObjectRect = new DevComponents.DotNetBar.ButtonX();
            this.sliderDensity = new DevComponents.DotNetBar.Controls.Slider();
            this.ratingStar1 = new DevComponents.DotNetBar.Controls.RatingStar();
            this.buttonSpeedUp = new DevComponents.DotNetBar.ButtonX();
            this.buttonSpeedDown = new DevComponents.DotNetBar.ButtonX();
            this.buttonFilterRect = new DevComponents.DotNetBar.ButtonX();
            this.buttonGrab = new DevComponents.DotNetBar.ButtonX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.switchButtonFilter = new DevComponents.DotNetBar.SwitchButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.btnSetColor = new DevComponents.DotNetBar.ColorPickerDropDown();
            this.btnSetSize = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetSpeed = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetDirection = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetSheild = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetInterest = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetCompare = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemUnSet = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemSet = new DevComponents.DotNetBar.ButtonItem();
            this.LabelStatus = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.panelWin = new System.Windows.Forms.Panel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelWin.SuspendLayout();
            this.SuspendLayout();
            // 
            // sliderSize
            // 
            this.sliderSize.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.sliderSize.LabelVisible = false;
            this.sliderSize.LabelWidth = 20;
            this.sliderSize.Maximum = 2;
            this.sliderSize.Name = "sliderSize";
            this.sliderSize.SliderOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.sliderSize.Text = "1";
            this.sliderSize.Value = 1;
            this.sliderSize.Width = 80;
            this.sliderSize.ValueChanging += new DevComponents.DotNetBar.CancelIntValueEventHandler(this.sliderSize_ValueChanging);
            // 
            // sliderSpeed
            // 
            this.sliderSpeed.LabelVisible = false;
            this.sliderSpeed.LabelWidth = 20;
            this.sliderSpeed.Maximum = 10;
            this.sliderSpeed.Name = "sliderSpeed";
            this.sliderSpeed.SliderOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.sliderSpeed.Text = "5";
            this.sliderSpeed.Value = 5;
            // 
            // panelEx5
            // 
            this.panelEx5.Controls.Add(this.ucSingleBriefPlayWnd1);
            this.panelEx5.Controls.Add(this.tableLayoutPanel1);
            this.panelEx5.Controls.Add(this.bar1);
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(807, 500);
            this.panelEx5.TabIndex = 0;
            // 
            // ucSingleBriefPlayWnd1
            // 
            this.ucSingleBriefPlayWnd1.AllowDrop = true;
            this.ucSingleBriefPlayWnd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleBriefPlayWnd1.Location = new System.Drawing.Point(0, 27);
            this.ucSingleBriefPlayWnd1.MSS_Data_Path = null;
            this.ucSingleBriefPlayWnd1.MSS_Index_Path = null;
            this.ucSingleBriefPlayWnd1.MSS_IP = null;
            this.ucSingleBriefPlayWnd1.MSS_Port = ((uint)(0u));
            this.ucSingleBriefPlayWnd1.Name = "ucSingleBriefPlayWnd1";
            this.ucSingleBriefPlayWnd1.Size = new System.Drawing.Size(807, 423);
            this.ucSingleBriefPlayWnd1.TabIndex = 4;
            this.ucSingleBriefPlayWnd1.VideoName = "No Brief Video";
            this.ucSingleBriefPlayWnd1.MouseClickEx += new System.Windows.Forms.MouseEventHandler(this.ucSinglePlayWnd_MouseClickEx);
            this.ucSingleBriefPlayWnd1.MouseDoubleClickEx += new System.Windows.Forms.MouseEventHandler(this.ucSinglePlayWnd_MouseDoubleClickEx);
            this.ucSingleBriefPlayWnd1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.ucSinglePlayWnd_PropertyChanged);
            this.ucSingleBriefPlayWnd1.MoveObjectClick += new System.Action<IVX.Live.MainForm.View.ucSingleBriefPlayWnd, IVX.DataModel.BriefMoveobjInfo>(this.ucSingleBriefPlayWnd1_MoveObjectClick);
            this.ucSingleBriefPlayWnd1.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelX2_DragDrop);
            this.ucSingleBriefPlayWnd1.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelX2_DragEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LabelTime, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPlay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonObjectRect, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.sliderDensity, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.ratingStar1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSpeedUp, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSpeedDown, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonFilterRect, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGrab, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 450);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(807, 50);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // LabelTime
            // 
            this.LabelTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.LabelTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelTime.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelTime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LabelTime.Location = new System.Drawing.Point(612, 13);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(192, 23);
            this.LabelTime.TabIndex = 9;
            this.LabelTime.Text = "00:00:00/00:00:00(100.0%)";
            this.LabelTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // buttonPlay
            // 
            this.buttonPlay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPlay.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.播放5;
            this.buttonPlay.HoverImage = global::IVX.Live.MainForm.Properties.Resources.播放4;
            this.buttonPlay.Image = global::IVX.Live.MainForm.Properties.Resources.播放1;
            this.buttonPlay.Location = new System.Drawing.Point(103, 7);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(34, 36);
            this.buttonPlay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPlay.TabIndex = 5;
            this.buttonPlay.Tooltip = "播放";
            this.buttonPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonStop.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.停止5;
            this.buttonStop.HoverImage = global::IVX.Live.MainForm.Properties.Resources.停止4;
            this.buttonStop.Image = global::IVX.Live.MainForm.Properties.Resources.停止1;
            this.buttonStop.Location = new System.Drawing.Point(143, 7);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(34, 36);
            this.buttonStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Tooltip = "停止";
            this.buttonStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // buttonObjectRect
            // 
            this.buttonObjectRect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonObjectRect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonObjectRect.AutoCheckOnClick = true;
            this.buttonObjectRect.Checked = true;
            this.buttonObjectRect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonObjectRect.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.时间框叠加5;
            this.buttonObjectRect.HoverImage = global::IVX.Live.MainForm.Properties.Resources.时间框叠加4;
            this.buttonObjectRect.Image = global::IVX.Live.MainForm.Properties.Resources.时间框叠加1;
            this.buttonObjectRect.Location = new System.Drawing.Point(303, 7);
            this.buttonObjectRect.Name = "buttonObjectRect";
            this.buttonObjectRect.Size = new System.Drawing.Size(34, 36);
            this.buttonObjectRect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonObjectRect.TabIndex = 13;
            this.buttonObjectRect.Text = "目标框";
            this.buttonObjectRect.Tooltip = "显示目标时间";
            this.buttonObjectRect.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // sliderDensity
            // 
            this.sliderDensity.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.sliderDensity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderDensity.FocusCuesEnabled = false;
            this.sliderDensity.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.sliderDensity.Location = new System.Drawing.Point(383, 5);
            this.sliderDensity.Maximum = 10;
            this.sliderDensity.Name = "sliderDensity";
            this.sliderDensity.Size = new System.Drawing.Size(1, 40);
            this.sliderDensity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderDensity.TabIndex = 8;
            this.sliderDensity.Text = "密度";
            this.sliderDensity.TrackMarker = false;
            this.sliderDensity.Value = 2;
            this.sliderDensity.Visible = false;
            this.sliderDensity.ValueChanged += new System.EventHandler(this.sliderDensity_ValueChanged);
            // 
            // ratingStar1
            // 
            // 
            // 
            // 
            this.ratingStar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ratingStar1.CustomImages.Rated = global::IVX.Live.MainForm.Properties.Resources.Density;
            this.ratingStar1.CustomImages.RatedMouseOver = global::IVX.Live.MainForm.Properties.Resources.Density;
            this.ratingStar1.CustomImages.Unrated = global::IVX.Live.MainForm.Properties.Resources.UnDensity;
            this.ratingStar1.CustomImages.UnratedMouseOver = global::IVX.Live.MainForm.Properties.Resources.UnDensity;
            this.ratingStar1.Location = new System.Drawing.Point(3, 3);
            this.ratingStar1.Name = "ratingStar1";
            this.ratingStar1.Rating = 2;
            this.ratingStar1.Size = new System.Drawing.Size(94, 40);
            this.ratingStar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ratingStar1.TabIndex = 14;
            this.ratingStar1.Text = "密度";
            this.ratingStar1.TextColor = System.Drawing.Color.Empty;
            this.ratingStar1.RatingChanged += new System.EventHandler(this.ratingStar1_RatingChanged);
            // 
            // buttonSpeedUp
            // 
            this.buttonSpeedUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSpeedUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpeedUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSpeedUp.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.快进5;
            this.buttonSpeedUp.HoverImage = global::IVX.Live.MainForm.Properties.Resources.快进4;
            this.buttonSpeedUp.Image = global::IVX.Live.MainForm.Properties.Resources.快进1;
            this.buttonSpeedUp.Location = new System.Drawing.Point(183, 7);
            this.buttonSpeedUp.Name = "buttonSpeedUp";
            this.buttonSpeedUp.Size = new System.Drawing.Size(34, 36);
            this.buttonSpeedUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSpeedUp.TabIndex = 10;
            this.buttonSpeedUp.Text = "加速";
            this.buttonSpeedUp.Tooltip = "加速";
            this.buttonSpeedUp.Click += new System.EventHandler(this.buttonSpeedUp_Click);
            // 
            // buttonSpeedDown
            // 
            this.buttonSpeedDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSpeedDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpeedDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSpeedDown.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.快退5;
            this.buttonSpeedDown.HoverImage = global::IVX.Live.MainForm.Properties.Resources.快退4;
            this.buttonSpeedDown.Image = global::IVX.Live.MainForm.Properties.Resources.快退1;
            this.buttonSpeedDown.Location = new System.Drawing.Point(223, 7);
            this.buttonSpeedDown.Name = "buttonSpeedDown";
            this.buttonSpeedDown.Size = new System.Drawing.Size(34, 36);
            this.buttonSpeedDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSpeedDown.TabIndex = 11;
            this.buttonSpeedDown.Text = "减速";
            this.buttonSpeedDown.Tooltip = "减速";
            this.buttonSpeedDown.Click += new System.EventHandler(this.buttonSpeedDown_Click);
            // 
            // buttonFilterRect
            // 
            this.buttonFilterRect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonFilterRect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonFilterRect.AutoCheckOnClick = true;
            this.buttonFilterRect.Checked = true;
            this.buttonFilterRect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonFilterRect.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.区域叠加5;
            this.buttonFilterRect.HoverImage = global::IVX.Live.MainForm.Properties.Resources.区域叠加4;
            this.buttonFilterRect.Image = global::IVX.Live.MainForm.Properties.Resources.区域叠加1;
            this.buttonFilterRect.Location = new System.Drawing.Point(343, 7);
            this.buttonFilterRect.Name = "buttonFilterRect";
            this.buttonFilterRect.Size = new System.Drawing.Size(34, 36);
            this.buttonFilterRect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonFilterRect.TabIndex = 12;
            this.buttonFilterRect.Text = "过滤参数框";
            this.buttonFilterRect.Tooltip = "显示目标框";
            this.buttonFilterRect.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonGrab
            // 
            this.buttonGrab.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGrab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGrab.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGrab.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.截图5;
            this.buttonGrab.HoverImage = global::IVX.Live.MainForm.Properties.Resources.截图4;
            this.buttonGrab.Image = global::IVX.Live.MainForm.Properties.Resources.截图1;
            this.buttonGrab.Location = new System.Drawing.Point(263, 7);
            this.buttonGrab.Name = "buttonGrab";
            this.buttonGrab.Size = new System.Drawing.Size(34, 36);
            this.buttonGrab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGrab.TabIndex = 7;
            this.buttonGrab.Tooltip = "抓目标图";
            this.buttonGrab.Visible = false;
            this.buttonGrab.Click += new System.EventHandler(this.buttonGrab_Click);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.CanMove = false;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.switchButtonFilter,
            this.labelItem2,
            this.btnSetColor,
            this.btnSetSize,
            this.btnSetSpeed,
            this.btnSetDirection,
            this.btnSetSheild,
            this.btnSetInterest,
            this.btnSetCompare,
            this.buttonItemUnSet,
            this.buttonItemSet,
            this.LabelStatus,
            this.labelItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(807, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // switchButtonFilter
            // 
            this.switchButtonFilter.ButtonWidth = 80;
            this.switchButtonFilter.Name = "switchButtonFilter";
            this.switchButtonFilter.OffText = "全目标";
            this.switchButtonFilter.OnText = "过滤";
            this.switchButtonFilter.Visible = false;
            this.switchButtonFilter.ValueChanged += new System.EventHandler(this.switchButtonItem1_ValueChanged);
            // 
            // labelItem2
            // 
            this.labelItem2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "设置过滤条件：";
            // 
            // btnSetColor
            // 
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Text = "颜色";
            this.btnSetColor.Visible = false;
            // 
            // btnSetSize
            // 
            this.btnSetSize.AutoExpandOnClick = true;
            this.btnSetSize.Name = "btnSetSize";
            this.btnSetSize.PopupOffset = new System.Drawing.Point(10, 0);
            this.btnSetSize.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sliderSize});
            this.btnSetSize.Text = "大小";
            this.btnSetSize.Visible = false;
            this.btnSetSize.Click += new System.EventHandler(this.btnSetSize_Click);
            // 
            // btnSetSpeed
            // 
            this.btnSetSpeed.AutoExpandOnClick = true;
            this.btnSetSpeed.Name = "btnSetSpeed";
            this.btnSetSpeed.PopupOffset = new System.Drawing.Point(10, 0);
            this.btnSetSpeed.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sliderSpeed});
            this.btnSetSpeed.Text = "速度";
            this.btnSetSpeed.Visible = false;
            // 
            // btnSetDirection
            // 
            this.btnSetDirection.Name = "btnSetDirection";
            this.btnSetDirection.Text = "方向";
            this.btnSetDirection.Visible = false;
            this.btnSetDirection.Click += new System.EventHandler(this.btnSetDirection_Click);
            // 
            // btnSetSheild
            // 
            this.btnSetSheild.Name = "btnSetSheild";
            this.btnSetSheild.Text = "屏蔽区";
            this.btnSetSheild.Visible = false;
            this.btnSetSheild.Click += new System.EventHandler(this.btnSetSheild_Click);
            // 
            // btnSetInterest
            // 
            this.btnSetInterest.Name = "btnSetInterest";
            this.btnSetInterest.Text = "关注区";
            this.btnSetInterest.Visible = false;
            this.btnSetInterest.Click += new System.EventHandler(this.btnSetInterest_Click);
            // 
            // btnSetCompare
            // 
            this.btnSetCompare.Name = "btnSetCompare";
            this.btnSetCompare.Text = "相似目标";
            this.btnSetCompare.Visible = false;
            // 
            // buttonItemUnSet
            // 
            this.buttonItemUnSet.Name = "buttonItemUnSet";
            this.buttonItemUnSet.Text = "重置";
            this.buttonItemUnSet.Click += new System.EventHandler(this.buttonItemUnSet_Click);
            // 
            // buttonItemSet
            // 
            this.buttonItemSet.FontBold = true;
            this.buttonItemSet.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonItemSet.Name = "buttonItemSet";
            this.buttonItemSet.Text = "确认修改";
            this.buttonItemSet.Visible = false;
            this.buttonItemSet.Click += new System.EventHandler(this.buttonItemSet_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelStatus.ForeColor = System.Drawing.Color.Red;
            this.LabelStatus.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Text = "4X";
            this.LabelStatus.TextAlignment = System.Drawing.StringAlignment.Far;
            this.LabelStatus.Width = 80;
            // 
            // labelItem1
            // 
            this.labelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "总目标数：1024";
            this.labelItem1.Visible = false;
            // 
            // panelWin
            // 
            this.panelWin.BackColor = System.Drawing.Color.Transparent;
            this.panelWin.Controls.Add(this.panelEx5);
            this.panelWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWin.Location = new System.Drawing.Point(0, 0);
            this.panelWin.Name = "panelWin";
            this.panelWin.Size = new System.Drawing.Size(807, 500);
            this.panelWin.TabIndex = 5;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.停止5;
            this.buttonX2.HoverImage = global::IVX.Live.MainForm.Properties.Resources.停止4;
            this.buttonX2.Image = global::IVX.Live.MainForm.Properties.Resources.停止1;
            this.buttonX2.Location = new System.Drawing.Point(207, 7);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(36, 36);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 10;
            // 
            // ucPlayBrief
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWin);
            this.DoubleBuffered = true;
            this.Name = "ucPlayBrief";
            this.Size = new System.Drawing.Size(807, 500);
            this.Load += new System.EventHandler(this.FormPlayHistory_Load);
            this.panelEx5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelWin.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private DevComponents.DotNetBar.SliderItem sliderSize;
        private DevComponents.DotNetBar.SliderItem sliderSpeed;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Panel panelEx5;
        private ucSingleBriefPlayWnd ucSingleBriefPlayWnd1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX buttonStop;
        private DevComponents.DotNetBar.ButtonX buttonPlay;
        private DevComponents.DotNetBar.ButtonX buttonGrab;
        private DevComponents.DotNetBar.Controls.Slider sliderDensity;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonFilter;
        private DevComponents.DotNetBar.ColorPickerDropDown btnSetColor;
        private DevComponents.DotNetBar.ButtonItem btnSetSize;
        private DevComponents.DotNetBar.ButtonItem btnSetSpeed;
        private DevComponents.DotNetBar.ButtonItem btnSetDirection;
        private DevComponents.DotNetBar.ButtonItem btnSetSheild;
        private DevComponents.DotNetBar.ButtonItem btnSetInterest;
        private DevComponents.DotNetBar.ButtonItem btnSetCompare;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelX LabelTime;
        private DevComponents.DotNetBar.ButtonX buttonSpeedUp;
        private DevComponents.DotNetBar.ButtonX buttonSpeedDown;
        private DevComponents.DotNetBar.LabelItem LabelStatus;
        private System.Windows.Forms.Panel panelWin;
        private DevComponents.DotNetBar.ButtonX buttonFilterRect;
        private DevComponents.DotNetBar.ButtonX buttonObjectRect;
        private DevComponents.DotNetBar.ButtonItem buttonItemSet;
        private DevComponents.DotNetBar.Controls.RatingStar ratingStar1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItemUnSet;
    }
}