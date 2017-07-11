namespace IVX.Live.MainForm.View
{
    partial class ucPlayHistory
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
            this.panelWin = new System.Windows.Forms.Panel();
            this.panelEx5 = new System.Windows.Forms.Panel();
            this.ucSinglePlayWnd1 = new IVX.Live.MainForm.View.ucSinglePlayWnd();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelEx4 = new System.Windows.Forms.Panel();
            this.LabelTime = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.LabelStatus = new DevComponents.DotNetBar.LabelItem();
            this.buttonPlay = new DevComponents.DotNetBar.ButtonX();
            this.buttonStop = new DevComponents.DotNetBar.ButtonX();
            this.buttonGrab = new DevComponents.DotNetBar.ButtonX();
            this.buttonSpeedUp = new DevComponents.DotNetBar.ButtonX();
            this.buttonSpeedDown = new DevComponents.DotNetBar.ButtonX();
            this.buttonExport = new DevComponents.DotNetBar.ButtonX();
            this.buttonGotoCompare = new DevComponents.DotNetBar.ButtonX();
            this.buttonBackword = new DevComponents.DotNetBar.ButtonX();
            this.panelWin.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWin
            // 
            this.panelWin.BackColor = System.Drawing.Color.Transparent;
            this.panelWin.Controls.Add(this.panelEx5);
            this.panelWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWin.Location = new System.Drawing.Point(0, 0);
            this.panelWin.Name = "panelWin";
            this.panelWin.Size = new System.Drawing.Size(1048, 583);
            this.panelWin.TabIndex = 2;
            // 
            // panelEx5
            // 
            this.panelEx5.Controls.Add(this.ucSinglePlayWnd1);
            this.panelEx5.Controls.Add(this.tableLayoutPanel1);
            this.panelEx5.Controls.Add(this.bar1);
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(1048, 583);
            this.panelEx5.TabIndex = 2;
            // 
            // ucSinglePlayWnd1
            // 
            this.ucSinglePlayWnd1.AllowDrop = true;
            this.ucSinglePlayWnd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSinglePlayWnd1.Location = new System.Drawing.Point(0, 24);
            this.ucSinglePlayWnd1.MSS_IP = null;
            this.ucSinglePlayWnd1.MSS_Path = null;
            this.ucSinglePlayWnd1.MSS_Port = ((uint)(0u));
            this.ucSinglePlayWnd1.Name = "ucSinglePlayWnd1";
            this.ucSinglePlayWnd1.PlayEndTime = 0;
            this.ucSinglePlayWnd1.PlayStartTime = 0;
            this.ucSinglePlayWnd1.Selected = false;
            this.ucSinglePlayWnd1.Size = new System.Drawing.Size(1048, 509);
            this.ucSinglePlayWnd1.TabIndex = 0;
            this.ucSinglePlayWnd1.VideoName = "No Video";
            this.ucSinglePlayWnd1.MouseClickEx += new System.Windows.Forms.MouseEventHandler(this.ucSinglePlayWnd_MouseClickEx);
            this.ucSinglePlayWnd1.MouseDoubleClickEx += new System.Windows.Forms.MouseEventHandler(this.ucSinglePlayWnd_MouseDoubleClickEx);
            this.ucSinglePlayWnd1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.ucSinglePlayWnd_PropertyChanged);
            this.ucSinglePlayWnd1.DragDrop += new System.Windows.Forms.DragEventHandler(this.wnd_DragDrop);
            this.ucSinglePlayWnd1.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelX2_DragEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonPlay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGrab, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSpeedUp, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSpeedDown, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx4, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelTime, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonExport, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGotoCompare, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackword, 8, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 533);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1048, 50);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelEx4
            // 
            this.panelEx4.Location = new System.Drawing.Point(393, 3);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(4, 44);
            this.panelEx4.TabIndex = 1;
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
            this.LabelTime.Location = new System.Drawing.Point(915, 13);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(130, 23);
            this.LabelTime.TabIndex = 8;
            this.LabelTime.Text = "00:00:00/00:00:00";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.CanMove = false;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.LabelStatus});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1048, 24);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelStatus.ForeColor = System.Drawing.Color.Red;
            this.LabelStatus.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Text = "4X";
            // 
            // buttonPlay
            // 
            this.buttonPlay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPlay.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.播放5;
            this.buttonPlay.HoverImage = global::IVX.Live.MainForm.Properties.Resources.播放4;
            this.buttonPlay.Image = global::IVX.Live.MainForm.Properties.Resources.播放1;
            this.buttonPlay.Location = new System.Drawing.Point(23, 7);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(34, 36);
            this.buttonPlay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPlay.TabIndex = 2;
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
            this.buttonStop.Location = new System.Drawing.Point(63, 7);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(34, 36);
            this.buttonStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Tooltip = "停止";
            this.buttonStop.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonGrab
            // 
            this.buttonGrab.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGrab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGrab.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGrab.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.截图5;
            this.buttonGrab.HoverImage = global::IVX.Live.MainForm.Properties.Resources.截图4;
            this.buttonGrab.Image = global::IVX.Live.MainForm.Properties.Resources.截图1;
            this.buttonGrab.Location = new System.Drawing.Point(103, 7);
            this.buttonGrab.Name = "buttonGrab";
            this.buttonGrab.Size = new System.Drawing.Size(34, 36);
            this.buttonGrab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGrab.TabIndex = 4;
            this.buttonGrab.Tooltip = "抓图";
            this.buttonGrab.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonSpeedUp
            // 
            this.buttonSpeedUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSpeedUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpeedUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSpeedUp.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.快进5;
            this.buttonSpeedUp.HoverImage = global::IVX.Live.MainForm.Properties.Resources.快进4;
            this.buttonSpeedUp.Image = global::IVX.Live.MainForm.Properties.Resources.快进1;
            this.buttonSpeedUp.Location = new System.Drawing.Point(143, 7);
            this.buttonSpeedUp.Name = "buttonSpeedUp";
            this.buttonSpeedUp.Size = new System.Drawing.Size(34, 36);
            this.buttonSpeedUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSpeedUp.TabIndex = 5;
            this.buttonSpeedUp.Text = "加速";
            this.buttonSpeedUp.Tooltip = "加速";
            this.buttonSpeedUp.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonSpeedDown
            // 
            this.buttonSpeedDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSpeedDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpeedDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSpeedDown.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.快退5;
            this.buttonSpeedDown.HoverImage = global::IVX.Live.MainForm.Properties.Resources.快退4;
            this.buttonSpeedDown.Image = global::IVX.Live.MainForm.Properties.Resources.快退1;
            this.buttonSpeedDown.Location = new System.Drawing.Point(183, 7);
            this.buttonSpeedDown.Name = "buttonSpeedDown";
            this.buttonSpeedDown.Size = new System.Drawing.Size(34, 36);
            this.buttonSpeedDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSpeedDown.TabIndex = 6;
            this.buttonSpeedDown.Text = "减速";
            this.buttonSpeedDown.Tooltip = "减速";
            this.buttonSpeedDown.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonExport.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.导出5;
            this.buttonExport.HoverImage = global::IVX.Live.MainForm.Properties.Resources.导出4;
            this.buttonExport.Image = global::IVX.Live.MainForm.Properties.Resources.导出1;
            this.buttonExport.Location = new System.Drawing.Point(223, 7);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(34, 36);
            this.buttonExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "视频导出";
            this.buttonExport.Tooltip = "视频导出";
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonGotoCompare
            // 
            this.buttonGotoCompare.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGotoCompare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGotoCompare.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGotoCompare.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.转到以图搜图5;
            this.buttonGotoCompare.HoverImage = global::IVX.Live.MainForm.Properties.Resources.转到以图搜图4;
            this.buttonGotoCompare.Image = global::IVX.Live.MainForm.Properties.Resources.转到以图搜图1;
            this.buttonGotoCompare.Location = new System.Drawing.Point(263, 7);
            this.buttonGotoCompare.Name = "buttonGotoCompare";
            this.buttonGotoCompare.Size = new System.Drawing.Size(34, 36);
            this.buttonGotoCompare.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGotoCompare.TabIndex = 10;
            this.buttonGotoCompare.Text = "视频导出";
            this.buttonGotoCompare.Tooltip = "转到以图搜图";
            this.buttonGotoCompare.Click += new System.EventHandler(this.buttonGotoCompare_Click);
            // 
            // buttonBackword
            // 
            this.buttonBackword.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBackword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBackword.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBackword.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.前一帧5;
            this.buttonBackword.HoverImage = global::IVX.Live.MainForm.Properties.Resources.前一帧4;
            this.buttonBackword.Image = global::IVX.Live.MainForm.Properties.Resources.前一帧1;
            this.buttonBackword.Location = new System.Drawing.Point(303, 7);
            this.buttonBackword.Name = "buttonBackword";
            this.buttonBackword.Size = new System.Drawing.Size(34, 36);
            this.buttonBackword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonBackword.TabIndex = 11;
            this.buttonBackword.Text = "倒放";
            this.buttonBackword.Tooltip = "倒放";
            this.buttonBackword.Click += new System.EventHandler(this.buttonBackword_Click);
            // 
            // ucPlayHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWin);
            this.DoubleBuffered = true;
            this.Name = "ucPlayHistory";
            this.Size = new System.Drawing.Size(1048, 583);
            this.Load += new System.EventHandler(this.FormPlayHistory_Load);
            this.panelWin.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWin;
        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelEx4;
        private System.Windows.Forms.Panel panelEx5;
        private DevComponents.DotNetBar.ButtonX buttonPlay;
        private DevComponents.DotNetBar.ButtonX buttonStop;
        private DevComponents.DotNetBar.ButtonX buttonGrab;
        private DevComponents.DotNetBar.ButtonX buttonSpeedUp;
        private DevComponents.DotNetBar.ButtonX buttonSpeedDown;
        private DevComponents.DotNetBar.LabelX LabelTime;
        private DevComponents.DotNetBar.LabelItem LabelStatus;
        private ucSinglePlayWnd ucSinglePlayWnd1;
        private DevComponents.DotNetBar.ButtonX buttonExport;
        private DevComponents.DotNetBar.ButtonX buttonGotoCompare;
        private DevComponents.DotNetBar.ButtonX buttonBackword;
    }
}