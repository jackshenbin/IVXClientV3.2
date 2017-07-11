namespace IVX.Live.MainForm.View
{
    partial class FormTrafficEventSearch
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
			this.m_ucTrafficEventSearch = new IVX.Live.MainForm.View.ucTrafficEventSearch();
			this.SuspendLayout();
			// 
			// m_ucTrafficEventSearch
			// 
			this.m_ucTrafficEventSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ucTrafficEventSearch.Location = new System.Drawing.Point(1, 44);
			this.m_ucTrafficEventSearch.Name = "m_ucTrafficEventSearch";
			this.m_ucTrafficEventSearch.Size = new System.Drawing.Size(865, 624);
			this.m_ucTrafficEventSearch.TabIndex = 6;
			// 
			// FormTrafficEventSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 695);
			this.Controls.Add(this.m_ucTrafficEventSearch);
			this.DoubleBuffered = true;
			this.Name = "FormTrafficEventSearch";
			this.ShowStatusBar = true;
			this.Text = "历史交通事件";
			this.Controls.SetChildIndex(this.m_ucTrafficEventSearch, 0);
			this.ResumeLayout(false);

        }
        ucTrafficEventSearch m_ucTrafficEventSearch;
        #endregion
    }
}