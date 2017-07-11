namespace IVX.Live.MainForm
{
    partial class FormPlayTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayTest));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.ucSinglePlayWnd1 = new IVX.Live.MainForm.View.ucSinglePlayWnd();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.textBoxIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.axvodocx1 = new AxvodocxLib.Axvodocx();
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(52, 503);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(47, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "start";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(105, 503);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 5;
            this.buttonX2.Text = "pause";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(185, 503);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "stop";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(266, 503);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 5;
            this.buttonX4.Text = ">>";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Location = new System.Drawing.Point(346, 503);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(75, 23);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 5;
            this.buttonX5.Text = "<<";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Location = new System.Drawing.Point(426, 503);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(75, 23);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 5;
            this.buttonX6.Text = "snap";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX7.Location = new System.Drawing.Point(1, 503);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(47, 23);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.TabIndex = 5;
            this.buttonX7.Text = "init";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // ucSinglePlayWnd1
            // 
            this.ucSinglePlayWnd1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSinglePlayWnd1.Location = new System.Drawing.Point(12, 54);
            this.ucSinglePlayWnd1.MSS_IP = null;
            this.ucSinglePlayWnd1.MSS_Path = null;
            this.ucSinglePlayWnd1.MSS_Port = ((uint)(0u));
            this.ucSinglePlayWnd1.Name = "ucSinglePlayWnd1";
            this.ucSinglePlayWnd1.Selected = false;
            this.ucSinglePlayWnd1.Size = new System.Drawing.Size(637, 425);
            this.ucSinglePlayWnd1.TabIndex = 6;
            this.ucSinglePlayWnd1.VideoName = "";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(507, 485);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(146, 21);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "labelX2";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(507, 506);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(146, 21);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "labelX3";
            // 
            // textBoxIP
            // 
            // 
            // 
            // 
            this.textBoxIP.Border.Class = "TextBoxBorder";
            this.textBoxIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxIP.Location = new System.Drawing.Point(2, 480);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(107, 21);
            this.textBoxIP.TabIndex = 12;
            this.textBoxIP.Text = "192.168.42.56";
            // 
            // textBoxPath
            // 
            // 
            // 
            // 
            this.textBoxPath.Border.Class = "TextBoxBorder";
            this.textBoxPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxPath.Location = new System.Drawing.Point(162, 480);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(339, 21);
            this.textBoxPath.TabIndex = 13;
            this.textBoxPath.Text = "D:\\OriginalFile\\20160325\\Video\\0001\\0BB07151-45C8-4CA1-8E89-21D851B1B0FC.avi";
            // 
            // textBoxPort
            // 
            // 
            // 
            // 
            this.textBoxPort.Border.Class = "TextBoxBorder";
            this.textBoxPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxPort.Location = new System.Drawing.Point(114, 480);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(43, 21);
            this.textBoxPort.TabIndex = 14;
            this.textBoxPort.Text = "9002";
            // 
            // axvodocx1
            // 
            this.axvodocx1.Enabled = true;
            this.axvodocx1.Location = new System.Drawing.Point(616, 488);
            this.axvodocx1.Name = "axvodocx1";
            this.axvodocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axvodocx1.OcxState")));
            this.axvodocx1.Size = new System.Drawing.Size(45, 29);
            this.axvodocx1.TabIndex = 18;
            this.axvodocx1.Visible = false;
            // 
            // FormPlayTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 529);
            this.Controls.Add(this.axvodocx1);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.ucSinglePlayWnd1);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX7);
            this.Controls.Add(this.buttonX1);
            this.DoubleBuffered = true;
            this.Name = "FormPlayTest";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.buttonX7, 0);
            this.Controls.SetChildIndex(this.buttonX2, 0);
            this.Controls.SetChildIndex(this.buttonX3, 0);
            this.Controls.SetChildIndex(this.buttonX6, 0);
            this.Controls.SetChildIndex(this.buttonX4, 0);
            this.Controls.SetChildIndex(this.buttonX5, 0);
            this.Controls.SetChildIndex(this.ucSinglePlayWnd1, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.textBoxIP, 0);
            this.Controls.SetChildIndex(this.textBoxPath, 0);
            this.Controls.SetChildIndex(this.textBoxPort, 0);
            this.Controls.SetChildIndex(this.axvodocx1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private View.ucSinglePlayWnd ucSinglePlayWnd1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxIP;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxPath;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxPort;
        private AxvodocxLib.Axvodocx axvodocx1;
    }
}