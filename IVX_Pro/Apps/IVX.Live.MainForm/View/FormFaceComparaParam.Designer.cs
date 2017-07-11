namespace IVX.Live.MainForm.View {
	partial class FormFaceComparaParam {
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
			this.ucSingleDrawImageWnd1 = new IVX.Live.MainForm.View.ucSingleDrawImageWnd();
			this.buttonSelectPic = new DevComponents.DotNetBar.ButtonX();
			this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
			this.buttonReset = new DevComponents.DotNetBar.ButtonX();
			this.buttonOK = new DevComponents.DotNetBar.ButtonX();
			this.checkBoxObjRect = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.SuspendLayout();
			// 
			// ucSingleDrawImageWnd1
			// 
			this.ucSingleDrawImageWnd1.Dock = System.Windows.Forms.DockStyle.Left;
			this.ucSingleDrawImageWnd1.DrawImage = null;
			this.ucSingleDrawImageWnd1.Location = new System.Drawing.Point(1, 44);
			this.ucSingleDrawImageWnd1.Name = "ucSingleDrawImageWnd1";
			this.ucSingleDrawImageWnd1.Size = new System.Drawing.Size(711, 475);
			this.ucSingleDrawImageWnd1.TabIndex = 7;
			// 
			// buttonSelectPic
			// 
			this.buttonSelectPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonSelectPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonSelectPic.Location = new System.Drawing.Point(733, 63);
			this.buttonSelectPic.Name = "buttonSelectPic";
			this.buttonSelectPic.Size = new System.Drawing.Size(83, 23);
			this.buttonSelectPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonSelectPic.TabIndex = 8;
			this.buttonSelectPic.Text = "选择图片";
			this.buttonSelectPic.Click += new System.EventHandler(this.buttonSelectPic_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonCancel.Location = new System.Drawing.Point(733, 477);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(83, 23);
			this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "取消";
			// 
			// buttonReset
			// 
			this.buttonReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonReset.Location = new System.Drawing.Point(733, 396);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(83, 23);
			this.buttonReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonReset.TabIndex = 11;
			this.buttonReset.Text = "重置";
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonOK.Location = new System.Drawing.Point(733, 448);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(83, 23);
			this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonOK.TabIndex = 9;
			this.buttonOK.Text = "确定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// checkBoxObjRect
			// 
			// 
			// 
			// 
			this.checkBoxObjRect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkBoxObjRect.Location = new System.Drawing.Point(734, 126);
			this.checkBoxObjRect.Name = "checkBoxObjRect";
			this.checkBoxObjRect.Size = new System.Drawing.Size(82, 23);
			this.checkBoxObjRect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.checkBoxObjRect.TabIndex = 13;
			this.checkBoxObjRect.Text = "目标框";
			this.checkBoxObjRect.CheckedChanged += new System.EventHandler(this.checkBoxObjRect_CheckedChanged);
			// 
			// FormFaceComparaParam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 546);
			this.Controls.Add(this.checkBoxObjRect);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonSelectPic);
			this.Controls.Add(this.ucSingleDrawImageWnd1);
			this.DoubleBuffered = true;
			this.Name = "FormFaceComparaParam";
			this.ShowStatusBar = true;
			this.Text = "人脸比对设置";
			this.Controls.SetChildIndex(this.ucSingleDrawImageWnd1, 0);
			this.Controls.SetChildIndex(this.buttonSelectPic, 0);
			this.Controls.SetChildIndex(this.buttonOK, 0);
			this.Controls.SetChildIndex(this.buttonReset, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.checkBoxObjRect, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private ucSingleDrawImageWnd ucSingleDrawImageWnd1;
		private DevComponents.DotNetBar.ButtonX buttonSelectPic;
		private DevComponents.DotNetBar.ButtonX buttonCancel;
		private DevComponents.DotNetBar.ButtonX buttonReset;
		private DevComponents.DotNetBar.ButtonX buttonOK;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxObjRect;
	}
}