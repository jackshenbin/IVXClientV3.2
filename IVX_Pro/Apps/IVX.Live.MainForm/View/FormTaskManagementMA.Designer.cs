﻿namespace IVX.Live.MainForm.View
{
    partial class FormTaskManagementMA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskManagementMA));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelCountInfo = new DevComponents.DotNetBar.LabelX();
            this.buttonShowMap = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddFtpTask = new DevComponents.DotNetBar.ButtonX();
            this.axfileupload1 = new IVX.Live.MainForm.View.ucUploadWnd();
            this.buttonAddLocalTask = new DevComponents.DotNetBar.ButtonX();
            this.advTree1 = new WinFormAppUtil.Controls.TreeListEx();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader7 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.progressBarItem1 = new DevComponents.DotNetBar.ProgressBarItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.textBoxSearch);
            this.panelEx1.Controls.Add(this.labelCountInfo);
            this.panelEx1.Controls.Add(this.buttonShowMap);
            this.panelEx1.Controls.Add(this.buttonAddFtpTask);
            this.panelEx1.Controls.Add(this.axfileupload1);
            this.panelEx1.Controls.Add(this.buttonAddLocalTask);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(1, 44);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1125, 36);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            // 
            // 
            // 
            this.textBoxSearch.Border.Class = "TextBoxBorder";
            this.textBoxSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxSearch.ButtonCustom.Image = global::IVX.Live.MainForm.Properties.Resources.ZoomHS;
            this.textBoxSearch.ButtonCustom.Visible = true;
            this.textBoxSearch.Location = new System.Drawing.Point(3, 8);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(182, 22);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.WatermarkColor = System.Drawing.SystemColors.ButtonShadow;
            this.textBoxSearch.WatermarkText = "过滤任务";
            this.textBoxSearch.ButtonCustomClick += new System.EventHandler(this.textBoxSearch_ButtonCustomClick);
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelCountInfo
            // 
            this.labelCountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelCountInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCountInfo.Location = new System.Drawing.Point(998, 6);
            this.labelCountInfo.Name = "labelCountInfo";
            this.labelCountInfo.Size = new System.Drawing.Size(116, 23);
            this.labelCountInfo.TabIndex = 8;
            this.labelCountInfo.Text = "总记录数 0 条";
            // 
            // buttonShowMap
            // 
            this.buttonShowMap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonShowMap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonShowMap.Location = new System.Drawing.Point(469, 7);
            this.buttonShowMap.Name = "buttonShowMap";
            this.buttonShowMap.Size = new System.Drawing.Size(169, 23);
            this.buttonShowMap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonShowMap.Symbol = "";
            this.buttonShowMap.TabIndex = 2;
            this.buttonShowMap.Text = "添加联网点位视频...";
            this.buttonShowMap.TextColor = System.Drawing.Color.DarkSlateGray;
            this.buttonShowMap.Click += new System.EventHandler(this.buttonShowMap_Click);
            // 
            // buttonAddFtpTask
            // 
            this.buttonAddFtpTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddFtpTask.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddFtpTask.Location = new System.Drawing.Point(335, 7);
            this.buttonAddFtpTask.Name = "buttonAddFtpTask";
            this.buttonAddFtpTask.Size = new System.Drawing.Size(128, 23);
            this.buttonAddFtpTask.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddFtpTask.Symbol = "";
            this.buttonAddFtpTask.TabIndex = 2;
            this.buttonAddFtpTask.Text = "添加FTP视频...";
            this.buttonAddFtpTask.TextColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddFtpTask.Click += new System.EventHandler(this.buttonAddFtpTask_Click);
            // 
            // axfileupload1
            // 
            this.axfileupload1.Location = new System.Drawing.Point(511, 14);
            this.axfileupload1.Name = "axfileupload1";
            this.axfileupload1.Size = new System.Drawing.Size(38, 16);
            this.axfileupload1.TabIndex = 1;
            this.axfileupload1.Visible = false;
            // 
            // buttonAddLocalTask
            // 
            this.buttonAddLocalTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddLocalTask.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddLocalTask.Location = new System.Drawing.Point(191, 7);
            this.buttonAddLocalTask.Name = "buttonAddLocalTask";
            this.buttonAddLocalTask.Size = new System.Drawing.Size(138, 23);
            this.buttonAddLocalTask.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddLocalTask.Symbol = "";
            this.buttonAddLocalTask.TabIndex = 0;
            this.buttonAddLocalTask.Text = "添加本地视频...";
            this.buttonAddLocalTask.TextColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddLocalTask.Click += new System.EventHandler(this.buttonAddLocalTask_Click);
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader6);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.Columns.Add(this.columnHeader4);
            this.advTree1.Columns.Add(this.columnHeader5);
            this.advTree1.Columns.Add(this.columnHeader7);
            this.advTree1.Columns.Add(this.columnHeader8);
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.DragDropEnabled = false;
            this.advTree1.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.advTree1.ExpandWidth = 14;
            this.advTree1.ImageList = this.imageList1;
            this.advTree1.Location = new System.Drawing.Point(1, 80);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(1125, 464);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTree1_MarkupLinkClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width.Absolute = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "任务名称";
            this.columnHeader2.Width.Absolute = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "开始时间";
            this.columnHeader6.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "任务进度";
            this.columnHeader3.Width.Absolute = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "任务状态";
            this.columnHeader4.Width.Absolute = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "算法";
            this.columnHeader5.Width.Absolute = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Name = "columnHeader7";
            this.columnHeader7.Text = "操作";
            this.columnHeader7.Width.Absolute = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.Text = "删除";
            this.columnHeader8.Width.Absolute = 50;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bk.png");
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // progressBarItem1
            // 
            // 
            // 
            // 
            this.progressBarItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarItem1.ChunkGradientAngle = 0F;
            this.progressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.progressBarItem1.Name = "progressBarItem1";
            this.progressBarItem1.RecentlyUsed = false;
            this.progressBarItem1.Text = "progressBarItem1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "buttonItem3";
            // 
            // FormTaskManagementMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 571);
            this.Controls.Add(this.advTree1);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "FormTaskManagementMA";
            this.ShowStatusBar = true;
            this.Text = "任务管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTaskManagement_FormClosing);
            this.Load += new System.EventHandler(this.FormTaskManagement_Load);
            this.MdiChildActivate += new System.EventHandler(this.FormTaskManagement_MdiChildActivate);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.advTree1, 0);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonAddLocalTask;
        private ucUploadWnd axfileupload1;
        private DevComponents.DotNetBar.ButtonX buttonAddFtpTask;
        private DevComponents.DotNetBar.ButtonX buttonShowMap;
        private DevComponents.DotNetBar.LabelX labelCountInfo;
        private WinFormAppUtil.Controls.TreeListEx advTree1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ProgressBarItem progressBarItem1;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxSearch;

    }
}