﻿namespace IVX.Live.MainForm.View
{
    partial class FormSingleBehaviourEvnetDetail
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
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.advPropertyGrid1 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pageNavigatorEx1 = new WinFormAppUtil.Controls.PageNavigatorEx();
            this.buttonGrabpic = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox5 = new WinFormAppUtil.Controls.PictureZoomBox();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "del";
            // 
            // advPropertyGrid1
            // 
            this.advPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Left;
            this.advPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid1.Location = new System.Drawing.Point(1, 44);
            this.advPropertyGrid1.Name = "advPropertyGrid1";
            this.advPropertyGrid1.SearchBoxVisible = false;
            this.advPropertyGrid1.Size = new System.Drawing.Size(253, 670);
            this.advPropertyGrid1.SubPropertiesDefaultSort = DevComponents.DotNetBar.ePropertySort.NoSort;
            this.advPropertyGrid1.TabIndex = 6;
            this.advPropertyGrid1.Text = "advPropertyGrid1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pageNavigatorEx1);
            this.panel1.Controls.Add(this.buttonGrabpic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(254, 681);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 33);
            this.panel1.TabIndex = 7;
            // 
            // pageNavigatorEx1
            // 
            this.pageNavigatorEx1.Index = 0;
            this.pageNavigatorEx1.Location = new System.Drawing.Point(6, 5);
            this.pageNavigatorEx1.MaxCount = 0;
            this.pageNavigatorEx1.MinimumSize = new System.Drawing.Size(0, 25);
            this.pageNavigatorEx1.Name = "pageNavigatorEx1";
            this.pageNavigatorEx1.Size = new System.Drawing.Size(192, 25);
            this.pageNavigatorEx1.TabIndex = 3;
            this.pageNavigatorEx1.FirstClick += new System.EventHandler(this.pageNavigatorEx1_FirstClick);
            this.pageNavigatorEx1.PrivClick += new System.EventHandler(this.pageNavigatorEx1_PrivClick);
            this.pageNavigatorEx1.NextClick += new System.EventHandler(this.pageNavigatorEx1_NextClick);
            this.pageNavigatorEx1.LastClick += new System.EventHandler(this.pageNavigatorEx1_LastClick);
            // 
            // buttonGrabpic
            // 
            this.buttonGrabpic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGrabpic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGrabpic.Location = new System.Drawing.Point(305, 5);
            this.buttonGrabpic.Name = "buttonGrabpic";
            this.buttonGrabpic.Size = new System.Drawing.Size(75, 23);
            this.buttonGrabpic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGrabpic.TabIndex = 1;
            this.buttonGrabpic.Text = "存图";
            this.buttonGrabpic.Click += new System.EventHandler(this.buttonGrabpic_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = global::IVX.Live.MainForm.Properties.Resources.bocom;
            this.pictureBox5.Location = new System.Drawing.Point(254, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(855, 637);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // FormSingleBehaviourEvnetDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.advPropertyGrid1);
            this.DoubleBuffered = true;
            this.Name = "FormSingleBehaviourEvnetDetail";
            this.ShowStatusBar = true;
            this.Text = "行为事件查看";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportList_FormClosing);
            this.Load += new System.EventHandler(this.FormExportList_Load);
            this.Controls.SetChildIndex(this.advPropertyGrid1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.AdvPropertyGrid advPropertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private WinFormAppUtil.Controls.PictureZoomBox pictureBox5;
        private DevComponents.DotNetBar.ButtonX buttonGrabpic;
        private WinFormAppUtil.Controls.PageNavigatorEx pageNavigatorEx1;
    }
}