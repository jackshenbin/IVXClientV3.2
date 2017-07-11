namespace IVX.Live.MainForm.View
{
    partial class ucPlayRealtime
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
            this.components = new System.ComponentModel.Container();
            this.panelWin = new System.Windows.Forms.Panel();
            this.panelEx5 = new System.Windows.Forms.Panel();
            this.ucSinglePlayWnd1 = new IVX.Live.MainForm.View.ucSingleRealtimePlayWnd();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPlay = new DevComponents.DotNetBar.ButtonX();
            this.buttonStop = new DevComponents.DotNetBar.ButtonX();
            this.buttonGrab = new DevComponents.DotNetBar.ButtonX();
            this.panelEx4 = new System.Windows.Forms.Panel();
            this.LabelTime = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.LabelStatus = new DevComponents.DotNetBar.LabelItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonGotoCompare = new DevComponents.DotNetBar.ButtonX();
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
            this.ucSinglePlayWnd1.Channel = null;
            this.ucSinglePlayWnd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSinglePlayWnd1.IP = null;
            this.ucSinglePlayWnd1.Location = new System.Drawing.Point(0, 24);
            this.ucSinglePlayWnd1.Name = "ucSinglePlayWnd1";
            this.ucSinglePlayWnd1.Pass = null;
            this.ucSinglePlayWnd1.Port = ((uint)(0u));
            this.ucSinglePlayWnd1.Protocol = IVX.DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL;
            this.ucSinglePlayWnd1.Size = new System.Drawing.Size(1048, 509);
            this.ucSinglePlayWnd1.TabIndex = 0;
            this.ucSinglePlayWnd1.User = null;
            this.ucSinglePlayWnd1.VideoName = "No Video";
            this.ucSinglePlayWnd1.MouseClickEx += new System.Windows.Forms.MouseEventHandler(this.ucSinglePlayWnd_MouseClickEx);
            this.ucSinglePlayWnd1.MouseDoubleClickEx += new System.Windows.Forms.MouseEventHandler(this.ucSinglePlayWnd_MouseDoubleClickEx);
            this.ucSinglePlayWnd1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.ucSinglePlayWnd_PropertyChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonPlay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGrab, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx4, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelTime, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGotoCompare, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 533);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1048, 50);
            this.tableLayoutPanel1.TabIndex = 1;
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
            // panelEx4
            // 
            this.panelEx4.Location = new System.Drawing.Point(283, 3);
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
            this.LabelTime.Location = new System.Drawing.Point(898, 13);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(147, 23);
            this.LabelTime.TabIndex = 8;
            this.LabelTime.Text = "0000-00-00 00:00:00";
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonGotoCompare
            // 
            this.buttonGotoCompare.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGotoCompare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGotoCompare.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGotoCompare.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.转到以图搜图5;
            this.buttonGotoCompare.HoverImage = global::IVX.Live.MainForm.Properties.Resources.转到以图搜图4;
            this.buttonGotoCompare.Image = global::IVX.Live.MainForm.Properties.Resources.转到以图搜图1;
            this.buttonGotoCompare.Location = new System.Drawing.Point(143, 7);
            this.buttonGotoCompare.Name = "buttonGotoCompare";
            this.buttonGotoCompare.Size = new System.Drawing.Size(34, 36);
            this.buttonGotoCompare.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGotoCompare.TabIndex = 11;
            this.buttonGotoCompare.Text = "视频导出";
            this.buttonGotoCompare.Tooltip = "转到以图搜图";
            this.buttonGotoCompare.Click += new System.EventHandler(this.buttonGotoCompare_Click);
            // 
            // ucPlayRealtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWin);
            this.DoubleBuffered = true;
            this.Name = "ucPlayRealtime";
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
        private DevComponents.DotNetBar.LabelX LabelTime;
        private DevComponents.DotNetBar.LabelItem LabelStatus;
        private ucSingleRealtimePlayWnd ucSinglePlayWnd1;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ButtonX buttonGotoCompare;
    }
}