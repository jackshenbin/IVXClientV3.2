namespace IVX.Live.MainForm
{
    partial class FormMainNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainNew));
            this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem15 = new DevComponents.DotNetBar.ButtonItem();
            this.AppCommandTheme = new DevComponents.DotNetBar.Command(this.components);
            this.buttonItem16 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem17 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelItemTime = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labelItemStat = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.labelExportStat = new DevComponents.DotNetBar.LabelItem();
            this.tabStrip1 = new DevComponents.DotNetBar.TabStrip();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.sideBar1 = new DevComponents.DotNetBar.SideBar();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.axvodocx1 = new AxvodocxLib.Axvodocx();
            this.axbriefocx1 = new AxbriefocxLib.Axbriefocx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUser = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logOutBtn = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonFormBack = new DevComponents.DotNetBar.ButtonX();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axbriefocx1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonItem14
            // 
            this.buttonItem14.AutoExpandOnClick = true;
            this.buttonItem14.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem15,
            this.buttonItem16,
            this.buttonItem17,
            this.buttonItem1});
            this.buttonItem14.Text = "界面风格";
            // 
            // buttonItem15
            // 
            this.buttonItem15.Command = this.AppCommandTheme;
            this.buttonItem15.CommandParameter = "Metro";
            this.buttonItem15.Name = "buttonItem15";
            this.buttonItem15.OptionGroup = "style";
            this.buttonItem15.Text = "纯粹白";
            // 
            // AppCommandTheme
            // 
            this.AppCommandTheme.Name = "AppCommandTheme";
            this.AppCommandTheme.Executed += new System.EventHandler(this.AppCommandTheme_Executed);
            // 
            // buttonItem16
            // 
            this.buttonItem16.Command = this.AppCommandTheme;
            this.buttonItem16.CommandParameter = "Office2010Blue";
            this.buttonItem16.Name = "buttonItem16";
            this.buttonItem16.OptionGroup = "style";
            this.buttonItem16.Text = "经典蓝";
            // 
            // buttonItem17
            // 
            this.buttonItem17.Checked = true;
            this.buttonItem17.Command = this.AppCommandTheme;
            this.buttonItem17.CommandParameter = "Office2010Black";
            this.buttonItem17.Name = "buttonItem17";
            this.buttonItem17.OptionGroup = "style";
            this.buttonItem17.Text = "科技灰";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Command = this.AppCommandTheme;
            this.buttonItem1.CommandParameter = "Office2007Black";
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.OptionGroup = "style";
            this.buttonItem1.Text = "高级黑";
            this.buttonItem1.Visible = false;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItemTime,
            this.labelItem1,
            this.labelItemStat,
            this.labelItem2,
            this.labelExportStat,
            this.buttonItem14});
            this.bar1.Location = new System.Drawing.Point(1, 686);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1108, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // labelItemTime
            // 
            this.labelItemTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelItemTime.Name = "labelItemTime";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Stretch = true;
            this.labelItem1.Text = "|";
            // 
            // labelItemStat
            // 
            this.labelItemStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelItemStat.Name = "labelItemStat";
            this.labelItemStat.Text = "正在连接服务器...";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Stretch = true;
            this.labelItem2.Text = "|";
            // 
            // labelExportStat
            // 
            this.labelExportStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelExportStat.Name = "labelExportStat";
            this.labelExportStat.Click += new System.EventHandler(this.labelExportStat_Click);
            // 
            // tabStrip1
            // 
            this.tabStrip1.AutoSelectAttachedControl = true;
            this.tabStrip1.CanReorderTabs = true;
            this.tabStrip1.CloseButtonVisible = false;
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip1.ForeColor = System.Drawing.Color.Black;
            this.tabStrip1.Location = new System.Drawing.Point(1, 88);
            this.tabStrip1.MdiForm = this;
            this.tabStrip1.MdiTabbedDocuments = true;
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.SelectedTab = this.tabItem1;
            this.tabStrip1.Size = new System.Drawing.Size(1108, 0);
            this.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.tabStrip1.TabIndex = 10;
            this.tabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabStrip1.Tabs.Add(this.tabItem1);
            this.tabStrip1.Text = "tabStrip1";
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "tabItem1";
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.sideBar1);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx4.Location = new System.Drawing.Point(1, 88);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(143, 598);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 14;
            this.panelEx4.Text = "panelEx4";
            // 
            // sideBar1
            // 
            this.sideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.sideBar1.BackColor = System.Drawing.Color.LightGray;
            this.sideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None;
            this.sideBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar1.ExpandedPanel = null;
            this.sideBar1.ForeColor = System.Drawing.Color.Black;
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(143, 598);
            this.sideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sideBar1.TabIndex = 1;
            this.sideBar1.Text = "sideBar1";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.ExpandableControl = this.panelEx4;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(144, 88);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 598);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla;
            this.expandableSplitter1.TabIndex = 15;
            this.expandableSplitter1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // axvodocx1
            // 
            this.axvodocx1.Enabled = true;
            this.axvodocx1.Location = new System.Drawing.Point(436, 442);
            this.axvodocx1.Name = "axvodocx1";
            this.axvodocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axvodocx1.OcxState")));
            this.axvodocx1.Size = new System.Drawing.Size(45, 29);
            this.axvodocx1.TabIndex = 17;
            this.axvodocx1.Visible = false;
            // 
            // axbriefocx1
            // 
            this.axbriefocx1.Enabled = true;
            this.axbriefocx1.Location = new System.Drawing.Point(561, 431);
            this.axbriefocx1.Name = "axbriefocx1";
            this.axbriefocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axbriefocx1.OcxState")));
            this.axbriefocx1.Size = new System.Drawing.Size(100, 50);
            this.axbriefocx1.TabIndex = 17;
            this.axbriefocx1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.buttonFormBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 44);
            this.panel1.TabIndex = 19;
            // 
            // labelUser
            // 
            // 
            // 
            // 
            this.labelUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUser.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelUser.Location = new System.Drawing.Point(839, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(184, 44);
            this.labelUser.Symbol = "";
            this.labelUser.SymbolColor = System.Drawing.Color.DarkSlateGray;
            this.labelUser.TabIndex = 10;
            this.labelUser.Text = "欢迎您，请登录";
            this.labelUser.Click += new System.EventHandler(this.labelUser_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logOutBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1023, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 44);
            this.panel2.TabIndex = 12;
            // 
            // logOutBtn
            // 
            this.logOutBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.logOutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logOutBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.logOutBtn.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logOutBtn.Location = new System.Drawing.Point(8, 5);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(71, 35);
            this.logOutBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.logOutBtn.TabIndex = 11;
            this.logOutBtn.Text = "退出登录";
            this.logOutBtn.Visible = false;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelX2.Location = new System.Drawing.Point(76, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(325, 21);
            this.labelX2.TabIndex = 8;
            // 
            // buttonFormBack
            // 
            this.buttonFormBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonFormBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFormBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonFormBack.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFormBack.Location = new System.Drawing.Point(12, 5);
            this.buttonFormBack.Name = "buttonFormBack";
            this.buttonFormBack.Size = new System.Drawing.Size(58, 35);
            this.buttonFormBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonFormBack.TabIndex = 6;
            this.buttonFormBack.Text = "上一步";
            this.buttonFormBack.Click += new System.EventHandler(this.buttonFormBack_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "查看下载";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // FormMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.axbriefocx1);
            this.Controls.Add(this.axvodocx1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panelEx4);
            this.Controls.Add(this.tabStrip1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormMainNew";
            this.ShowStatusBar = true;
            this.Text = "博康视频图像侦查系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainNew_FormClosing);
            this.Load += new System.EventHandler(this.FormMainNew_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.tabStrip1, 0);
            this.Controls.SetChildIndex(this.panelEx4, 0);
            this.Controls.SetChildIndex(this.expandableSplitter1, 0);
            this.Controls.SetChildIndex(this.axvodocx1, 0);
            this.Controls.SetChildIndex(this.axbriefocx1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axbriefocx1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem14;
        private DevComponents.DotNetBar.ButtonItem buttonItem15;
        private DevComponents.DotNetBar.ButtonItem buttonItem16;
        private DevComponents.DotNetBar.ButtonItem buttonItem17;
        private DevComponents.DotNetBar.Command AppCommandTheme;
        private DevComponents.DotNetBar.TabStrip tabStrip1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.SideBar sideBar1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.LabelItem labelItemStat;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItemTime;
        private System.Windows.Forms.Timer timer1;
        private AxvodocxLib.Axvodocx axvodocx1;
        private AxbriefocxLib.Axbriefocx axbriefocx1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonFormBack;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem labelExportStat;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DevComponents.DotNetBar.LabelX labelUser;
		private DevComponents.DotNetBar.ButtonItem buttonItem1;
		private DevComponents.DotNetBar.ButtonX logOutBtn;
		private System.Windows.Forms.Panel panel2;

    }
}