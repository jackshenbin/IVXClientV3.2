namespace IVX.Live.MainForm.View {
	partial class FormLogSearch {
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
			this.m_logSearch = new IVX.Live.MainForm.View.ucLogSearch();
			this.SuspendLayout();
			// 
			// m_logSearch
			// 
			this.m_logSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_logSearch.Location = new System.Drawing.Point(0, 0);
			this.m_logSearch.Name = "m_logSearch";
			this.m_logSearch.Size = new System.Drawing.Size(867, 695);
			this.m_logSearch.TabIndex = 6;
			// 
			// FormLogSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 695);
			this.Controls.Add(this.m_logSearch);
			this.DoubleBuffered = true;
			this.Name = "FormLogSearch";
			this.ShowStatusBar = true;
			this.Text = "FormLogSearch";
			this.Controls.SetChildIndex(this.m_logSearch, 0);
			this.ResumeLayout(false);

		}
		private ucLogSearch m_logSearch;
		#endregion
	}
}