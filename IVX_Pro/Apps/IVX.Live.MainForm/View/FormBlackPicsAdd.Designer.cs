namespace IVX.Live.MainForm.View {
	partial class FormBlackPicsAdd {
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
			this.label2 = new System.Windows.Forms.Label();
			this.libName = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.zipFileBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.proLab = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(141, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 21);
			this.label2.TabIndex = 9;
			this.label2.Text = "名称:";
			// 
			// libName
			// 
			this.libName.AutoSize = true;
			this.libName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.libName.Location = new System.Drawing.Point(193, 76);
			this.libName.Name = "libName";
			this.libName.Size = new System.Drawing.Size(67, 21);
			this.libName.TabIndex = 8;
			this.libName.Text = "黑名单1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(46, 141);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 21);
			this.label3.TabIndex = 9;
			this.label3.Text = "文件路径:";
			// 
			// zipFileBox
			// 
			this.zipFileBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.zipFileBox.Location = new System.Drawing.Point(130, 141);
			this.zipFileBox.Name = "zipFileBox";
			this.zipFileBox.Size = new System.Drawing.Size(294, 23);
			this.zipFileBox.TabIndex = 10;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(435, 141);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(47, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "浏览";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(317, 302);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 11;
			this.button3.Text = "确定";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(433, 302);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 23);
			this.button4.TabIndex = 11;
			this.button4.Text = "取消";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(46, 213);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 21);
			this.label5.TabIndex = 9;
			this.label5.Text = "导入进度:";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(130, 213);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(294, 22);
			this.progressBar1.TabIndex = 12;
			// 
			// proLab
			// 
			this.proLab.AutoSize = true;
			this.proLab.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.proLab.Location = new System.Drawing.Point(440, 213);
			this.proLab.Name = "proLab";
			this.proLab.Size = new System.Drawing.Size(33, 21);
			this.proLab.TabIndex = 9;
			this.proLab.Text = "0%";
			// 
			// FormBlackPicsAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(530, 397);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.zipFileBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.proLab);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.libName);
			this.DoubleBuffered = true;
			this.Name = "FormBlackPicsAdd";
			this.ShowStatusBar = true;
			this.Text = "批量导入";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBlackPicsAdd_FormClosed);
			this.Load += new System.EventHandler(this.FormBlackPicsAdd_Load);
			this.Controls.SetChildIndex(this.libName, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.proLab, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.zipFileBox, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.button3, 0);
			this.Controls.SetChildIndex(this.button4, 0);
			this.Controls.SetChildIndex(this.progressBar1, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label libName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox zipFileBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label proLab;
	}
}