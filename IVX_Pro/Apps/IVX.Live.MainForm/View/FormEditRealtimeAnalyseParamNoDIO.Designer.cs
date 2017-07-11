namespace IVX.Live.MainForm.View
{
    partial class FormEditRealtimeAnalyseParamNoDIO
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
            this.ucEditTaskAnalyseParam1 = new IVX.Live.MainForm.View.ucEditTaskAnalyseParam();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // ucEditTaskAnalyseParam1
            // 
            this.ucEditTaskAnalyseParam1.AnalyseParam = "";
            this.ucEditTaskAnalyseParam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEditTaskAnalyseParam1.DrawImage = null;
            this.ucEditTaskAnalyseParam1.Location = new System.Drawing.Point(1, 44);
            this.ucEditTaskAnalyseParam1.Name = "ucEditTaskAnalyseParam1";
            this.ucEditTaskAnalyseParam1.Size = new System.Drawing.Size(1108, 670);
            this.ucEditTaskAnalyseParam1.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(12, 685);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(31, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 9;
            this.buttonX1.Text = "抓图";
            this.buttonX1.Click += new System.EventHandler(this.buttonGrab_Click);
            // 
            // FormEditRealtimeAnalyseParamNoDIO
            // 
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.ucEditTaskAnalyseParam1);
            this.DoubleBuffered = true;
            this.Name = "FormEditRealtimeAnalyseParamNoDIO";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "修改算法参数";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSingleTask_FormClosing);
            this.Load += new System.EventHandler(this.FormSingleTask_Load);
            this.Controls.SetChildIndex(this.ucEditTaskAnalyseParam1, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ucEditTaskAnalyseParam ucEditTaskAnalyseParam1;
        private DevComponents.DotNetBar.ButtonX buttonX1;

    }
}