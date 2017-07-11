namespace IVX.Live.MainForm.View
{
    partial class FormCrowdReatime
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
			this.ucCrowdRealTime1 = new IVX.Live.MainForm.View.ucCrowdRealtime();
			this.SuspendLayout();
			// 
			// ucCrowdRealTime1
			// 
			this.ucCrowdRealTime1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucCrowdRealTime1.Location = new System.Drawing.Point(1, 44);
			this.ucCrowdRealTime1.Name = "ucCrowdRealTime1";
			this.ucCrowdRealTime1.Size = new System.Drawing.Size(982, 503);
			this.ucCrowdRealTime1.TabIndex = 6;
			// 
			// FormCrowdReatime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 574);
			this.Controls.Add(this.ucCrowdRealTime1);
			this.DoubleBuffered = true;
			this.Name = "FormCrowdReatime";
			this.ShowStatusBar = true;
			this.Text = "实时大客流";
			this.Activated += new System.EventHandler(this.FormCrowdReatime_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCrowdReatime_FormClosed);
			this.Controls.SetChildIndex(this.ucCrowdRealTime1, 0);
			this.ResumeLayout(false);

        }

        private ucCrowdRealtime ucCrowdRealTime1;
        #endregion
    }
}