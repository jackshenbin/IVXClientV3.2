namespace IVX.Live.MainForm.View
{
    partial class FormTrafficFluxSearch
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
			this.ucTrafficFluxSearch1 = new IVX.Live.MainForm.View.ucTrafficFluxSearch();
			this.SuspendLayout();
			// 
			// ucTrafficFluxSearch1
			// 
			this.ucTrafficFluxSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTrafficFluxSearch1.Location = new System.Drawing.Point(1, 44);
			this.ucTrafficFluxSearch1.Name = "ucTrafficFluxSearch1";
			this.ucTrafficFluxSearch1.Size = new System.Drawing.Size(865, 624);
			this.ucTrafficFluxSearch1.TabIndex = 6;
			// 
			// FormTrafficFluxSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 695);
			this.Controls.Add(this.ucTrafficFluxSearch1);
			this.DoubleBuffered = true;
			this.Name = "FormTrafficFluxSearch";
			this.ShowStatusBar = true;
			this.Text = "历史交通流量";
			this.Controls.SetChildIndex(this.ucTrafficFluxSearch1, 0);
			this.ResumeLayout(false);

        }

        #endregion

        private ucTrafficFluxSearch ucTrafficFluxSearch1;
    }
}