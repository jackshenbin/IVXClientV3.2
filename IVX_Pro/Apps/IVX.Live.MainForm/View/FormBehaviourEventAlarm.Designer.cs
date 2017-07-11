namespace IVX.Live.MainForm.View
{
    partial class FormBehaviourEventAlarm
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
			this.ucBehaviourEventAlarm1 = new IVX.Live.MainForm.View.ucBehaviourEventAlarm();
			this.SuspendLayout();
			// 
			// ucBehaviourEventAlarm1
			// 
			this.ucBehaviourEventAlarm1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBehaviourEventAlarm1.Location = new System.Drawing.Point(1, 44);
			this.ucBehaviourEventAlarm1.Name = "ucBehaviourEventAlarm1";
			this.ucBehaviourEventAlarm1.Size = new System.Drawing.Size(982, 503);
			this.ucBehaviourEventAlarm1.TabIndex = 6;
			// 
			// FormBehaviourEventAlarm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 574);
			this.Controls.Add(this.ucBehaviourEventAlarm1);
			this.DoubleBuffered = true;
			this.Name = "FormBehaviourEventAlarm";
			this.ShowStatusBar = true;
			this.Text = "行为事件";
			this.Load += new System.EventHandler(this.FormGisMap_Load);
			this.Shown += new System.EventHandler(this.FormGisMap_Shown);
			this.Controls.SetChildIndex(this.ucBehaviourEventAlarm1, 0);
			this.ResumeLayout(false);

        }

        #endregion

        private ucBehaviourEventAlarm ucBehaviourEventAlarm1;



    }
}