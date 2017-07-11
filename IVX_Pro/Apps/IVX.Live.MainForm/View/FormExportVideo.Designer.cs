namespace IVX.Live.MainForm.View
{
    partial class FormExportVideo
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
            this.ucExportVideo1 = new IVX.Live.MainForm.View.ucExportVideo();
            this.SuspendLayout();
            // 
            // ucExportVideo1
            // 
            this.ucExportVideo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExportVideo1.Location = new System.Drawing.Point(0, 43);
            this.ucExportVideo1.Name = "ucExportVideo1";
            this.ucExportVideo1.Size = new System.Drawing.Size(1110, 654);
            this.ucExportVideo1.TabIndex = 6;
            // 
            // FormExportVideo
            // 
            this.ClientSize = new System.Drawing.Size(1110, 723);
            this.Controls.Add(this.ucExportVideo1);
            this.DoubleBuffered = true;
            this.Name = "FormExportVideo";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "视频导出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportVideo_FormClosing);
            this.Load += new System.EventHandler(this.FormExportVideo_Load);
            this.Controls.SetChildIndex(this.ucExportVideo1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ucExportVideo ucExportVideo1;

    }
}