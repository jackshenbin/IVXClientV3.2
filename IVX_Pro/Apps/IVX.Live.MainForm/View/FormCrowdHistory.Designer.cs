namespace IVX.Live.MainForm.View
{
    partial class FormCrowdHistory
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
			this.ucCrowdHistory1 = new IVX.Live.MainForm.View.ucCrowdHistory();
			this.SuspendLayout();
			// 
			// ucCrowdHistory1
			// 
			this.ucCrowdHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucCrowdHistory1.Location = new System.Drawing.Point(1, 44);
			this.ucCrowdHistory1.Name = "ucCrowdHistory1";
			this.ucCrowdHistory1.Size = new System.Drawing.Size(982, 503);
			this.ucCrowdHistory1.TabIndex = 6;
			// 
			// FormCrowdHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 574);
			this.Controls.Add(this.ucCrowdHistory1);
			this.DoubleBuffered = true;
			this.Name = "FormCrowdHistory";
			this.ShowStatusBar = true;
			this.Text = "历史大客流";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCrowdHistory_FormClosed);
			this.Controls.SetChildIndex(this.ucCrowdHistory1, 0);
			this.ResumeLayout(false);

        }
        private ucCrowdHistory ucCrowdHistory1;
        #endregion
    }
}