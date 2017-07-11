namespace IVX.Live.MainForm.View {
	partial class FormUserManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.m_ucUserManager = new IVX.Live.MainForm.ucUserManager();
			this.SuspendLayout();
			// 
			// m_ucUserManager
			// 
			this.m_ucUserManager.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ucUserManager.Location = new System.Drawing.Point(1, 44);
			this.m_ucUserManager.Name = "m_ucUserManager";
			this.m_ucUserManager.Size = new System.Drawing.Size(865, 624);
			this.m_ucUserManager.TabIndex = 6;
			this.m_ucUserManager.Load += new System.EventHandler(this.m_ucUserManager_Load);
			// 
			// FormUserManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 695);
			this.Controls.Add(this.m_ucUserManager);
			this.DoubleBuffered = true;
			this.Name = "FormUserManager";
			this.ShowStatusBar = true;
			this.Text = "FormUserManager";
			this.Load += new System.EventHandler(this.FormUserManager_Load);
			this.Controls.SetChildIndex(this.m_ucUserManager, 0);
			this.ResumeLayout(false);

		}
		ucUserManager m_ucUserManager;
		#endregion
	}
}