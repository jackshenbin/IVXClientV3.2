namespace IVX.Live.MainForm.View
{
    partial class FormPlayHistoryNew
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
            this.ucPlayHistory1 = new IVX.Live.MainForm.View.ucPlayHistory();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeTrackControl1 = new TimeTrackControl.TimeTrackControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelMsg = new DevComponents.DotNetBar.LabelX();
            this.labelTwowheel = new DevComponents.DotNetBar.LabelX();
            this.labelVehclie = new DevComponents.DotNetBar.LabelX();
            this.labelPerson = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPlayHistory1
            // 
            this.ucPlayHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayHistory1.Location = new System.Drawing.Point(1, 44);
            this.ucPlayHistory1.Name = "ucPlayHistory1";
            this.ucPlayHistory1.OCX_MssHostIp = null;
            this.ucPlayHistory1.OCX_MssHostPort = ((uint)(0u));
            this.ucPlayHistory1.OCX_TaskName = null;
            this.ucPlayHistory1.OCX_VideoPath = null;
            this.ucPlayHistory1.ShowGotoCompare = true;
            this.ucPlayHistory1.Size = new System.Drawing.Size(1108, 600);
            this.ucPlayHistory1.TabIndex = 5;
            this.ucPlayHistory1.CloseThis += new System.EventHandler(this.ucPlayHistory1_CloseThis);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timeTrackControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 644);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 70);
            this.panel1.TabIndex = 8;
            // 
            // timeTrackControl1
            // 
            this.timeTrackControl1.CurrentTime = new System.DateTime(((long)(0)));
            this.timeTrackControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeTrackControl1.EditMode = 0;
            this.timeTrackControl1.EndTime = new System.DateTime(((long)(0)));
            this.timeTrackControl1.Location = new System.Drawing.Point(0, 23);
            this.timeTrackControl1.Name = "timeTrackControl1";
            this.timeTrackControl1.Size = new System.Drawing.Size(1108, 47);
            this.timeTrackControl1.StartTime = new System.DateTime(((long)(0)));
            this.timeTrackControl1.TabIndex = 7;
            this.timeTrackControl1.TimeTrackModel = TimeTrackControl.TimeTrackModel.Minutes;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelMsg);
            this.panel2.Controls.Add(this.labelTwowheel);
            this.panel2.Controls.Add(this.labelVehclie);
            this.panel2.Controls.Add(this.labelPerson);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 23);
            this.panel2.TabIndex = 9;
            // 
            // labelMsg
            // 
            // 
            // 
            // 
            this.labelMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelMsg.ForeColor = System.Drawing.Color.Red;
            this.labelMsg.Location = new System.Drawing.Point(561, 0);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelMsg.Size = new System.Drawing.Size(541, 23);
            this.labelMsg.TabIndex = 8;
            // 
            // labelTwowheel
            // 
            // 
            // 
            // 
            this.labelTwowheel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTwowheel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTwowheel.ForeColor = System.Drawing.Color.Indigo;
            this.labelTwowheel.Location = new System.Drawing.Point(300, 0);
            this.labelTwowheel.Name = "labelTwowheel";
            this.labelTwowheel.Size = new System.Drawing.Size(108, 23);
            this.labelTwowheel.TabIndex = 8;
            this.labelTwowheel.Text = "两轮车 ： 0次";
            // 
            // labelVehclie
            // 
            // 
            // 
            // 
            this.labelVehclie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelVehclie.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVehclie.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelVehclie.Location = new System.Drawing.Point(1, 0);
            this.labelVehclie.Name = "labelVehclie";
            this.labelVehclie.Size = new System.Drawing.Size(108, 23);
            this.labelVehclie.TabIndex = 8;
            this.labelVehclie.Text = "机动车 ： 0次";
            // 
            // labelPerson
            // 
            // 
            // 
            // 
            this.labelPerson.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPerson.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPerson.ForeColor = System.Drawing.Color.Teal;
            this.labelPerson.Location = new System.Drawing.Point(150, 0);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(108, 23);
            this.labelPerson.TabIndex = 8;
            this.labelPerson.Text = "行人 ： 0次";
            // 
            // FormPlayHistoryNew
            // 
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.ucPlayHistory1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FormPlayHistoryNew";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "视频点播";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSingleTask_FormClosing);
            this.Load += new System.EventHandler(this.FormSingleTask_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.ucPlayHistory1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPlayHistory ucPlayHistory1;
        private TimeTrackControl.TimeTrackControl timeTrackControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelTwowheel;
        private DevComponents.DotNetBar.LabelX labelVehclie;
        private DevComponents.DotNetBar.LabelX labelPerson;
        private DevComponents.DotNetBar.LabelX labelMsg;
    }
}