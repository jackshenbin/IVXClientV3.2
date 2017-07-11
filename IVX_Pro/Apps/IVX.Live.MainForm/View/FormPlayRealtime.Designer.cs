namespace IVX.Live.MainForm.View
{
    partial class FormPlayRealtime
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
            this.ucPlayHistory1 = new IVX.Live.MainForm.View.ucPlayRealtime();
            this.SuspendLayout();
            // 
            // ucPlayHistory1
            // 
            this.ucPlayHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayHistory1.Location = new System.Drawing.Point(0, 43);
            this.ucPlayHistory1.Name = "ucPlayHistory1";
            this.ucPlayHistory1.OCX_Channel = null;
            this.ucPlayHistory1.OCX_IP = null;
            this.ucPlayHistory1.OCX_Pass = null;
            this.ucPlayHistory1.OCX_Port = ((uint)(0u));
            this.ucPlayHistory1.OCX_Protocol = IVX.DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL;
            this.ucPlayHistory1.OCX_TaskName = null;
            this.ucPlayHistory1.OCX_User = null;
            this.ucPlayHistory1.Size = new System.Drawing.Size(1110, 672);
            this.ucPlayHistory1.TabIndex = 5;
            this.ucPlayHistory1.CloseThis += ucPlayHistory1_CloseThis;
            // 
            // FormPlayRealtime
            // 
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.ucPlayHistory1);
            this.DoubleBuffered = true;
            this.Name = "FormPlayRealtime";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "视频直播";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSingleTask_FormClosing);
            this.Load += new System.EventHandler(this.FormSingleTask_Load);
            this.Controls.SetChildIndex(this.ucPlayHistory1, 0);
            this.ResumeLayout(false);

        }


        #endregion

        private ucPlayRealtime ucPlayHistory1;
    }
}