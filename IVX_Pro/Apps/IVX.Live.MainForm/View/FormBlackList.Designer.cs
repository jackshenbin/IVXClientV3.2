﻿namespace IVX.Live.MainForm.View
{
    partial class FormBlackList
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
			this.m_blackList = new IVX.Live.MainForm.View.ucBlackList();
			this.SuspendLayout();
			// 
			// m_blackList
			// 
			this.m_blackList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_blackList.Location = new System.Drawing.Point(0, 0);
			this.m_blackList.Name = "m_blackList";
			this.m_blackList.Size = new System.Drawing.Size(867, 695);
			this.m_blackList.TabIndex = 7;
			// 
			// FormBlackList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 695);
			this.Controls.Add(this.m_blackList);
			this.DoubleBuffered = true;
			this.Name = "FormBlackList";
			this.ShowStatusBar = true;
			this.Text = "FormBlackList";
			this.Controls.SetChildIndex(this.m_blackList, 0);
			this.ResumeLayout(false);

        }

		ucBlackList m_blackList;
        #endregion
    }
}