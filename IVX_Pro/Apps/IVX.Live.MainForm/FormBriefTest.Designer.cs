namespace IVX.Live.MainForm
{
    partial class FormBriefTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBriefTest));
            this.axbriefocx1 = new AxbriefocxLib.Axbriefocx();
            this.axVdaPlayer1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sideBar1 = new DevComponents.DotNetBar.SideBar();
            ((System.ComponentModel.ISupportInitialize)(this.axbriefocx1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axbriefocx1
            // 
            this.axbriefocx1.BackColor = System.Drawing.Color.White;
            this.axbriefocx1.Enabled = true;
            this.axbriefocx1.ForeColor = System.Drawing.Color.Black;
            this.axbriefocx1.Location = new System.Drawing.Point(280, 285);
            this.axbriefocx1.Name = "axbriefocx1";
            this.axbriefocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axbriefocx1.OcxState")));
            this.axbriefocx1.Size = new System.Drawing.Size(100, 50);
            this.axbriefocx1.TabIndex = 8;
            this.axbriefocx1.Visible = false;
            // 
            // axVdaPlayer1
            // 
            this.axVdaPlayer1.BackColor = System.Drawing.Color.White;
            this.axVdaPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axVdaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVdaPlayer1.ForeColor = System.Drawing.Color.Black;
            this.axVdaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axVdaPlayer1.Name = "axVdaPlayer1";
            this.axVdaPlayer1.Size = new System.Drawing.Size(929, 466);
            this.axVdaPlayer1.TabIndex = 9;
            this.axVdaPlayer1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxIndex);
            this.panel1.Controls.Add(this.textBoxData);
            this.panel1.Controls.Add(this.textBoxPort);
            this.panel1.Controls.Add(this.textBoxIP);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 113);
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(648, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIndex.BackColor = System.Drawing.Color.White;
            this.textBoxIndex.ForeColor = System.Drawing.Color.Black;
            this.textBoxIndex.Location = new System.Drawing.Point(71, 81);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.Size = new System.Drawing.Size(845, 21);
            this.textBoxIndex.TabIndex = 1;
            this.textBoxIndex.Text = "F:\\\\AnalyzeResult\\\\20160816\\\\virtualcamera_63\\\\Brief\\\\0001\\\\BA991964-4078-42EF-BF" +
    "2D-7EAFA78F5B29.index";
            // 
            // textBoxData
            // 
            this.textBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxData.BackColor = System.Drawing.Color.White;
            this.textBoxData.ForeColor = System.Drawing.Color.Black;
            this.textBoxData.Location = new System.Drawing.Point(71, 58);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(845, 21);
            this.textBoxData.TabIndex = 1;
            this.textBoxData.Text = "F:\\\\AnalyzeResult\\\\20160816\\\\virtualcamera_63\\\\Brief\\\\0001\\\\BA991964-4078-42EF-BF" +
    "2D-7EAFA78F5B29.data";
            // 
            // textBoxPort
            // 
            this.textBoxPort.BackColor = System.Drawing.Color.White;
            this.textBoxPort.ForeColor = System.Drawing.Color.Black;
            this.textBoxPort.Location = new System.Drawing.Point(177, 31);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "9301";
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.White;
            this.textBoxIP.ForeColor = System.Drawing.Color.Black;
            this.textBoxIP.Location = new System.Drawing.Point(71, 31);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "192.168.88.197";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(526, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(445, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(177, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "SetCommonFilter";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(96, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(15, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "AddDispatch";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sideBar1
            // 
            this.sideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.sideBar1.Appearance = DevComponents.DotNetBar.eSideBarAppearance.Flat;
            this.sideBar1.BackColor = System.Drawing.Color.White;
            this.sideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None;
            this.sideBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar1.ExpandedPanel = null;
            this.sideBar1.ForeColor = System.Drawing.Color.Black;
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(192, 466);
            this.sideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sideBar1.TabIndex = 11;
            this.sideBar1.Text = "sideBar1";
            // 
            // FormBriefTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IVX.Live.MainForm.Properties.Resources.bocom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(929, 579);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.axVdaPlayer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axbriefocx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBriefTest";
            this.Text = "FormBriefTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FormBriefTest_Load);
            this.Shown += new System.EventHandler(this.FormBriefTest_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axbriefocx1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxbriefocxLib.Axbriefocx axbriefocx1;
        private System.Windows.Forms.Label axVdaPlayer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIndex;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private DevComponents.DotNetBar.SideBar sideBar1;
        private System.Windows.Forms.Label label4;

    }
}