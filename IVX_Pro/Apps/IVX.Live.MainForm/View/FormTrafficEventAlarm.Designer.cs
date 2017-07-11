namespace IVX.Live.MainForm.View
{
    partial class FormTrafficEventAlarm
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
			this.ucTrafficEventAlarm1 = new IVX.Live.MainForm.View.ucTrafficEventAlarm();
			this.SuspendLayout();
			// 
			// ucTrafficEventAlarm1
			// 
			this.ucTrafficEventAlarm1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTrafficEventAlarm1.Location = new System.Drawing.Point(1, 44);
			this.ucTrafficEventAlarm1.Name = "ucTrafficEventAlarm1";
			this.ucTrafficEventAlarm1.Size = new System.Drawing.Size(982, 503);
			this.ucTrafficEventAlarm1.TabIndex = 6;
			// 
			// FormTrafficEventAlarm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 574);
			this.Controls.Add(this.ucTrafficEventAlarm1);
			this.DoubleBuffered = true;
			this.Name = "FormTrafficEventAlarm";
			this.ShowStatusBar = true;
			this.Text = "交通事件";
			this.Load += new System.EventHandler(this.FormGisMap_Load);
			this.Shown += new System.EventHandler(this.FormGisMap_Shown);
			this.Controls.SetChildIndex(this.ucTrafficEventAlarm1, 0);
			this.ResumeLayout(false);

        }

        #endregion

        private ucTrafficEventAlarm ucTrafficEventAlarm1;



    }
}