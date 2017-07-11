namespace IVX.Live.MainForm.View
{
    partial class FormCrowdReport
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
			this.ucCrowdReport1 = new IVX.Live.MainForm.View.ucCrowdReport();
			this.SuspendLayout();
			// 
			// ucCrowdReport1
			// 
			this.ucCrowdReport1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucCrowdReport1.Location = new System.Drawing.Point(1, 44);
			this.ucCrowdReport1.Name = "ucCrowdReport1";
			this.ucCrowdReport1.Size = new System.Drawing.Size(998, 629);
			this.ucCrowdReport1.TabIndex = 6;
			// 
			// FormCrowdReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 700);
			this.Controls.Add(this.ucCrowdReport1);
			this.DoubleBuffered = true;
			this.Name = "FormCrowdReport";
			this.ShowStatusBar = true;
			this.Text = "统计大客流";
			this.Controls.SetChildIndex(this.ucCrowdReport1, 0);
			this.ResumeLayout(false);

        }
        private ucCrowdReport ucCrowdReport1;
        #endregion
    }
}