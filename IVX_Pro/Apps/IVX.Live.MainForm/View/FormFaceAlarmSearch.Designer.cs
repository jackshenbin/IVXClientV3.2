namespace IVX.Live.MainForm.View {
	partial class FormFaceAlarmSearch {
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
			this.m_formAlarmSearch = new IVX.Live.MainForm.View.ucFaceAlarmSearch();
			this.SuspendLayout();
			// 
			// m_formAlarmSearch
			// 
			this.m_formAlarmSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_formAlarmSearch.Location = new System.Drawing.Point(0, 0);
			this.m_formAlarmSearch.Name = "m_formAlarmSearch";
			this.m_formAlarmSearch.Size = new System.Drawing.Size(914, 652);
			this.m_formAlarmSearch.TabIndex = 7;
			// 
			// FormFaceAlarmSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(914, 652);
			this.Controls.Add(this.m_formAlarmSearch);
			this.DoubleBuffered = true;
			this.Name = "FormFaceAlarmSearch";
			this.ShowStatusBar = true;
			this.Text = "FormFaceAlarmSearchcs";
			this.Controls.SetChildIndex(this.m_formAlarmSearch, 0);
			this.ResumeLayout(false);

		}

		ucFaceAlarmSearch m_formAlarmSearch;
		#endregion
	}
}