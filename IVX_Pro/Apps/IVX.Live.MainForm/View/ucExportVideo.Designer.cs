namespace IVX.Live.MainForm.View
{
    partial class ucExportVideo
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
            this.buttonPlay = new DevComponents.DotNetBar.ButtonX();
            this.buttonStop = new DevComponents.DotNetBar.ButtonX();
            this.panelEx4 = new System.Windows.Forms.Panel();
            this.labelEnd = new DevComponents.DotNetBar.LabelX();
            this.labelStart = new DevComponents.DotNetBar.LabelX();
            this.buttonEnd = new DevComponents.DotNetBar.ButtonX();
            this.buttonStart = new DevComponents.DotNetBar.ButtonX();
            this.LabelTime = new DevComponents.DotNetBar.LabelX();
            this.buttonExport = new DevComponents.DotNetBar.ButtonX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.LabelStatus = new DevComponents.DotNetBar.LabelItem();
            this.panelWin.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelEx4.SuspendLayout();
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonPlay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx4, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelTime, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonExport, 3, 0);
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
            this.buttonPlay.Click += new System.EventHandler(this.buttonX1_Click);
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
            // panelEx4
            // 
            this.panelEx4.Controls.Add(this.labelEnd);
            this.panelEx4.Controls.Add(this.labelStart);
            this.panelEx4.Controls.Add(this.buttonEnd);
            this.panelEx4.Controls.Add(this.buttonStart);
            this.panelEx4.Location = new System.Drawing.Point(143, 3);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(393, 44);
            this.panelEx4.TabIndex = 1;
            // 
            // labelEnd
            // 
            // 
            // 
            // 
            this.labelEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEnd.ForeColor = System.Drawing.Color.Blue;
            this.labelEnd.Location = new System.Drawing.Point(194, 10);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(75, 23);
            this.labelEnd.TabIndex = 4;
            this.labelEnd.Text = "00:00:00";
            // 
            // labelStart
            // 
            // 
            // 
            // 
            this.labelStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStart.ForeColor = System.Drawing.Color.Blue;
            this.labelStart.Location = new System.Drawing.Point(3, 10);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(75, 23);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "00:00:00";
            // 
            // buttonEnd
            // 
            this.buttonEnd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEnd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEnd.Location = new System.Drawing.Point(275, 10);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonEnd.TabIndex = 3;
            this.buttonEnd.Text = "设为结束";
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonStart.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonStart.Location = new System.Drawing.Point(85, 10);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "设为开始";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
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
            // buttonExport
            // 
            this.buttonExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonExport.DisabledImage = global::IVX.Live.MainForm.Properties.Resources.储存5;
            this.buttonExport.HoverImage = global::IVX.Live.MainForm.Properties.Resources.储存4;
            this.buttonExport.Image = global::IVX.Live.MainForm.Properties.Resources.储存1;
            this.buttonExport.Location = new System.Drawing.Point(103, 7);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(34, 36);
            this.buttonExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "视频导出";
            this.buttonExport.Tooltip = "保存视频片段";
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
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
            // ucExportVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWin);
            this.DoubleBuffered = true;
            this.Name = "ucExportVideo";
            this.Size = new System.Drawing.Size(1048, 583);
            this.Load += new System.EventHandler(this.FormPlayHistory_Load);
            this.panelWin.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
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
        private DevComponents.DotNetBar.LabelX LabelTime;
        private DevComponents.DotNetBar.LabelItem LabelStatus;
        private ucSinglePlayWnd ucSinglePlayWnd1;
        private DevComponents.DotNetBar.ButtonX buttonExport;
        private DevComponents.DotNetBar.ButtonX buttonEnd;
        private DevComponents.DotNetBar.ButtonX buttonStart;
        private DevComponents.DotNetBar.LabelX labelEnd;
        private DevComponents.DotNetBar.LabelX labelStart;
    }
}