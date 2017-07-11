namespace IVX.Live.MainForm.View {
	partial class FormBehaviorEventSearch {
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
			this.m_BehaviorEventSearch = new IVX.Live.MainForm.View.ucBehaviorEventSearch();
			this.SuspendLayout();
			// 
			// m_BehaviorEventSearch
			// 
			this.m_BehaviorEventSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_BehaviorEventSearch.Location = new System.Drawing.Point(1, 44);
			this.m_BehaviorEventSearch.Name = "m_BehaviorEventSearch";
			this.m_BehaviorEventSearch.Size = new System.Drawing.Size(907, 624);
			this.m_BehaviorEventSearch.TabIndex = 7;
			// 
			// FormBehaviorEventSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(909, 695);
			this.Controls.Add(this.m_BehaviorEventSearch);
			this.DoubleBuffered = true;
			this.Name = "FormBehaviorEventSearch";
			this.ShowStatusBar = true;
			this.Text = "行为事件";
			this.Controls.SetChildIndex(this.m_BehaviorEventSearch, 0);
			this.ResumeLayout(false);

		}
		ucBehaviorEventSearch m_BehaviorEventSearch;

		#endregion
	}
}