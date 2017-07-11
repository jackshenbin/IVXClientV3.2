namespace IVX.Live.MainForm.View
{
    partial class FormTrafficFluxStatisticSearch
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
			this.ucTrafficFluxStatisticSearch1 = new IVX.Live.MainForm.View.ucTrafficFluxStatisticSearch();
			this.SuspendLayout();
			// 
			// ucTrafficFluxStatisticSearch1
			// 
			this.ucTrafficFluxStatisticSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTrafficFluxStatisticSearch1.Location = new System.Drawing.Point(1, 44);
			this.ucTrafficFluxStatisticSearch1.Name = "ucTrafficFluxStatisticSearch1";
			this.ucTrafficFluxStatisticSearch1.Size = new System.Drawing.Size(735, 494);
			this.ucTrafficFluxStatisticSearch1.TabIndex = 6;
			// 
			// FormTrafficFluxStatisticSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(737, 565);
			this.Controls.Add(this.ucTrafficFluxStatisticSearch1);
			this.DoubleBuffered = true;
			this.Name = "FormTrafficFluxStatisticSearch";
			this.ShowStatusBar = true;
			this.Text = "交通流量统计";
			this.Controls.SetChildIndex(this.ucTrafficFluxStatisticSearch1, 0);
			this.ResumeLayout(false);

        }

        #endregion

        private ucTrafficFluxStatisticSearch ucTrafficFluxStatisticSearch1;
    }
}