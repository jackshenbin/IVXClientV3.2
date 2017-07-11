namespace IVX.Live.MainForm.View
{
    partial class FormSingleTrafficEventDetail
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
            this.checkBoxX4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonPlayEvent = new DevComponents.DotNetBar.ButtonX();
            this.pageNavigatorEx1 = new WinFormAppUtil.Controls.PageNavigatorEx();
            this.buttonGrabpic = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox5 = new WinFormAppUtil.Controls.PictureZoomBox();
            this.ucPlayHistory1 = new DevComponents.DotNetBar.ButtonX();
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
            this.advPropertyGrid1.Location = new System.Drawing.Point(0, 43);
            this.advPropertyGrid1.Name = "advPropertyGrid1";
            this.advPropertyGrid1.SearchBoxVisible = false;
            this.advPropertyGrid1.Size = new System.Drawing.Size(253, 672);
            this.advPropertyGrid1.SubPropertiesDefaultSort = DevComponents.DotNetBar.ePropertySort.NoSort;
            this.advPropertyGrid1.TabIndex = 6;
            this.advPropertyGrid1.Text = "advPropertyGrid1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxX4);
            this.panel1.Controls.Add(this.checkBoxX3);
            this.panel1.Controls.Add(this.checkBoxX2);
            this.panel1.Controls.Add(this.checkBoxX1);
            this.panel1.Controls.Add(this.buttonPlayEvent);
            this.panel1.Controls.Add(this.pageNavigatorEx1);
            this.panel1.Controls.Add(this.buttonGrabpic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(253, 682);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 33);
            this.panel1.TabIndex = 7;
            // 
            // checkBoxX4
            // 
            this.checkBoxX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxX4.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX4.Location = new System.Drawing.Point(781, 9);
            this.checkBoxX4.Name = "checkBoxX4";
            this.checkBoxX4.Size = new System.Drawing.Size(64, 18);
            this.checkBoxX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX4.TabIndex = 8;
            this.checkBoxX4.Text = "合成图";
            this.checkBoxX4.Visible = false;
            // 
            // checkBoxX3
            // 
            this.checkBoxX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxX3.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX3.Location = new System.Drawing.Point(693, 8);
            this.checkBoxX3.Name = "checkBoxX3";
            this.checkBoxX3.Size = new System.Drawing.Size(88, 18);
            this.checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX3.TabIndex = 7;
            this.checkBoxX3.Text = "事件发生后";
            this.checkBoxX3.Visible = false;
            // 
            // checkBoxX2
            // 
            this.checkBoxX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxX2.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX2.Location = new System.Drawing.Point(605, 7);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.Size = new System.Drawing.Size(88, 18);
            this.checkBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX2.TabIndex = 6;
            this.checkBoxX2.Text = "事件发生时";
            this.checkBoxX2.Visible = false;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxX1.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX1.Checked = true;
            this.checkBoxX1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX1.CheckValue = "Y";
            this.checkBoxX1.Location = new System.Drawing.Point(517, 8);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(88, 18);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 5;
            this.checkBoxX1.Text = "事件发生前";
            this.checkBoxX1.Visible = false;
            // 
            // buttonPlayEvent
            // 
            this.buttonPlayEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPlayEvent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPlayEvent.Location = new System.Drawing.Point(224, 5);
            this.buttonPlayEvent.Name = "buttonPlayEvent";
            this.buttonPlayEvent.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayEvent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPlayEvent.TabIndex = 4;
            this.buttonPlayEvent.Text = "回溯";
            this.buttonPlayEvent.Click += new System.EventHandler(this.buttonPlayEvent_Click);
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
            this.pictureBox5.Location = new System.Drawing.Point(253, 43);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(857, 639);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // ucPlayHistory1
            // 
            this.ucPlayHistory1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ucPlayHistory1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ucPlayHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayHistory1.Location = new System.Drawing.Point(253, 43);
            this.ucPlayHistory1.Name = "ucPlayHistory1";
            this.ucPlayHistory1.Size = new System.Drawing.Size(857, 639);
            this.ucPlayHistory1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ucPlayHistory1.TabIndex = 9;
            this.ucPlayHistory1.Text = "buttonX1";
            // 
            // FormSingleTrafficEventDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.ucPlayHistory1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.advPropertyGrid1);
            this.DoubleBuffered = true;
            this.Name = "FormSingleTrafficEventDetail";
            this.ShowStatusBar = true;
            this.Text = "交通事件报警查看";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportList_FormClosing);
            this.Load += new System.EventHandler(this.FormExportList_Load);
            this.Controls.SetChildIndex(this.advPropertyGrid1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.ucPlayHistory1, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.AdvPropertyGrid advPropertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private WinFormAppUtil.Controls.PictureZoomBox pictureBox5;
        private DevComponents.DotNetBar.ButtonX buttonGrabpic;
        private WinFormAppUtil.Controls.PageNavigatorEx pageNavigatorEx1;
        private DevComponents.DotNetBar.ButtonX buttonPlayEvent;
        private DevComponents.DotNetBar.ButtonX ucPlayHistory1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX4;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
    }
}