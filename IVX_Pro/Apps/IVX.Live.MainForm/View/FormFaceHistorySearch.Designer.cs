namespace IVX.Live.MainForm.View {
	partial class FormFaceHistorySearch {
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
			this.m_FaceHistorySearch = new IVX.Live.MainForm.View.ucFaceHistorySearch();
			this.SuspendLayout();
			// 
			// m_FaceHistorySearch
			// 
			this.m_FaceHistorySearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_FaceHistorySearch.Location = new System.Drawing.Point(1, 44);
			this.m_FaceHistorySearch.Name = "m_FaceHistorySearch";
			this.m_FaceHistorySearch.Size = new System.Drawing.Size(859, 526);
			this.m_FaceHistorySearch.TabIndex = 7;
			this.m_FaceHistorySearch.Load += new System.EventHandler(this.m_FaceHistorySearch_Load);
			// 
			// FormFaceHistorySearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 597);
			this.Controls.Add(this.m_FaceHistorySearch);
			this.DoubleBuffered = true;
			this.Name = "FormFaceHistorySearch";
			this.ShowStatusBar = true;
			this.Text = "FormFaceHistorySearch";
			this.Controls.SetChildIndex(this.m_FaceHistorySearch, 0);
			this.ResumeLayout(false);

		}
		ucFaceHistorySearch m_FaceHistorySearch;
		#endregion
	}
}