﻿namespace IVX.Live.MainForm.View
{
    partial class FormPlayBriefNew
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
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucPlayHistory1 = new IVX.Live.MainForm.View.ucPlayHistory();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ucPlayBrief1 = new IVX.Live.MainForm.View.ucPlayBrief();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandableSplitter2.ExpandableControl = this.panel4;
            this.expandableSplitter2.Expanded = false;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter2.Location = new System.Drawing.Point(1104, 0);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(6, 672);
            this.expandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla;
            this.expandableSplitter2.TabIndex = 1;
            this.expandableSplitter2.TabStop = false;
            this.expandableSplitter2.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandableSplitter2_ExpandedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ucPlayHistory1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(352, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 600);
            this.panel4.TabIndex = 1;
            this.panel4.Visible = false;
            // 
            // ucPlayHistory1
            // 
            this.ucPlayHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucPlayHistory1.Name = "ucPlayHistory1";
            this.ucPlayHistory1.OCX_MssHostIp = null;
            this.ucPlayHistory1.OCX_MssHostPort = ((uint)(0u));
            this.ucPlayHistory1.OCX_TaskName = null;
            this.ucPlayHistory1.OCX_VideoPath = null;
            this.ucPlayHistory1.Size = new System.Drawing.Size(224, 600);
            this.ucPlayHistory1.TabIndex = 0;
            this.ucPlayHistory1.ShowGotoCompare = true;
            this.ucPlayHistory1.CloseThis += new System.EventHandler(this.ucPlayHistory1_CloseThis);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 672);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.expandableSplitter2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 672);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ucPlayBrief1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1104, 672);
            this.panel3.TabIndex = 0;
            // 
            // ucPlayBrief1
            // 
            this.ucPlayBrief1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayBrief1.Location = new System.Drawing.Point(0, 0);
            this.ucPlayBrief1.Name = "ucPlayBrief1";
            this.ucPlayBrief1.OCX_AdjustTime = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.ucPlayBrief1.OCX_BriefDataPath = null;
            this.ucPlayBrief1.OCX_BriefIndexPath = null;
            this.ucPlayBrief1.OCX_MssHostIp = null;
            this.ucPlayBrief1.OCX_MssHostPort = ((uint)(0u));
            this.ucPlayBrief1.OCX_TaskName = null;
            this.ucPlayBrief1.Size = new System.Drawing.Size(1104, 672);
            this.ucPlayBrief1.TabIndex = 0;
            // 
            // FormPlayBriefNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FormPlayBriefNew";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "摘要";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlayBriefNew_FormClosing);
            this.Load += new System.EventHandler(this.FormPlayHistory_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ucPlayHistory ucPlayHistory1;
        private ucPlayBrief ucPlayBrief1;
    }
}