﻿namespace IVX.Live.MainForm.View
{
    partial class FormRealtimeTaskManagement
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelCountInfo = new DevComponents.DotNetBar.LabelX();
            this.pageNavigatorEx1 = new WinFormAppUtil.Controls.PageNavigatorEx();
            this.buttonShowMap = new DevComponents.DotNetBar.ButtonX();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelCountInfo);
            this.panelEx1.Controls.Add(this.pageNavigatorEx1);
            this.panelEx1.Controls.Add(this.buttonShowMap);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(1, 491);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(892, 36);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelCountInfo
            // 
            this.labelCountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelCountInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCountInfo.Location = new System.Drawing.Point(499, 6);
            this.labelCountInfo.Name = "labelCountInfo";
            this.labelCountInfo.Size = new System.Drawing.Size(193, 23);
            this.labelCountInfo.TabIndex = 9;
            this.labelCountInfo.Text = "总记录数 0 条，共 0 页";
            // 
            // pageNavigatorEx1
            // 
            this.pageNavigatorEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageNavigatorEx1.Index = 0;
            this.pageNavigatorEx1.Location = new System.Drawing.Point(698, 5);
            this.pageNavigatorEx1.MaxCount = 0;
            this.pageNavigatorEx1.MinimumSize = new System.Drawing.Size(0, 25);
            this.pageNavigatorEx1.Name = "pageNavigatorEx1";
            this.pageNavigatorEx1.Size = new System.Drawing.Size(191, 25);
            this.pageNavigatorEx1.TabIndex = 5;
            this.pageNavigatorEx1.FirstClick += new System.EventHandler(this.pageNavigatorEx1_FirstClick);
            this.pageNavigatorEx1.PrivClick += new System.EventHandler(this.pageNavigatorEx1_PrivClick);
            this.pageNavigatorEx1.NextClick += new System.EventHandler(this.pageNavigatorEx1_NextClick);
            this.pageNavigatorEx1.LastClick += new System.EventHandler(this.pageNavigatorEx1_LastClick);
            // 
            // buttonShowMap
            // 
            this.buttonShowMap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonShowMap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonShowMap.Location = new System.Drawing.Point(12, 6);
            this.buttonShowMap.Name = "buttonShowMap";
            this.buttonShowMap.Size = new System.Drawing.Size(139, 23);
            this.buttonShowMap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonShowMap.TabIndex = 2;
            this.buttonShowMap.Text = "添加联网点位视频...";
            this.buttonShowMap.Click += new System.EventHandler(this.buttonShowMap_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(892, 421);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.SizeChanged += new System.EventHandler(this.flowLayoutPanel1_SizeChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1, 44);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(892, 26);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // FormRealtimeTaskManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.DoubleBuffered = true;
            this.Name = "FormRealtimeTaskManagement";
            this.ShowStatusBar = true;
            this.Text = "任务管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTaskManagement_FormClosing);
            this.Load += new System.EventHandler(this.FormRealtimeTaskManagement_Load);
            this.MdiChildActivate += new System.EventHandler(this.FormTaskManagement_MdiChildActivate);
            this.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonShowMap;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private WinFormAppUtil.Controls.PageNavigatorEx pageNavigatorEx1;
        private DevComponents.DotNetBar.LabelX labelCountInfo;

    }
}