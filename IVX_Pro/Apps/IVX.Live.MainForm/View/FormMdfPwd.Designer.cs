namespace IVX.Live.MainForm.View {
	partial class FormMdfPwd {
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.oldPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.newPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cfmPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.yesBtn = new DevComponents.DotNetBar.ButtonX();
            this.cancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.errorLabel = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(92, 66);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 23);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "原始密码 :";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(92, 102);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 23);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "新 密 码 :";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(92, 142);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(79, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "确认密码 :";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // oldPwd
            // 
            // 
            // 
            // 
            this.oldPwd.Border.Class = "TextBoxBorder";
            this.oldPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.oldPwd.Location = new System.Drawing.Point(189, 66);
            this.oldPwd.Name = "oldPwd";
            this.oldPwd.PasswordChar = '*';
            this.oldPwd.Size = new System.Drawing.Size(101, 21);
            this.oldPwd.TabIndex = 0;
            // 
            // newPwd
            // 
            // 
            // 
            // 
            this.newPwd.Border.Class = "TextBoxBorder";
            this.newPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.newPwd.Location = new System.Drawing.Point(189, 106);
            this.newPwd.Name = "newPwd";
            this.newPwd.PasswordChar = '*';
            this.newPwd.Size = new System.Drawing.Size(101, 21);
            this.newPwd.TabIndex = 1;
            // 
            // cfmPwd
            // 
            // 
            // 
            // 
            this.cfmPwd.Border.Class = "TextBoxBorder";
            this.cfmPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cfmPwd.Location = new System.Drawing.Point(189, 146);
            this.cfmPwd.Name = "cfmPwd";
            this.cfmPwd.PasswordChar = '*';
            this.cfmPwd.Size = new System.Drawing.Size(101, 21);
            this.cfmPwd.TabIndex = 2;
            // 
            // yesBtn
            // 
            this.yesBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.yesBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.yesBtn.Location = new System.Drawing.Point(104, 216);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(78, 24);
            this.yesBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.yesBtn.TabIndex = 3;
            this.yesBtn.TabStop = false;
            this.yesBtn.Text = "确定";
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelBtn.Location = new System.Drawing.Point(238, 216);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(76, 24);
            this.cancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // errorLabel
            // 
            // 
            // 
            // 
            this.errorLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.errorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(93, 179);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(247, 23);
            this.errorLabel.TabIndex = 12;
            // 
            // FormMdfPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 273);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.yesBtn);
            this.Controls.Add(this.cfmPwd);
            this.Controls.Add(this.newPwd);
            this.Controls.Add(this.oldPwd);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMdfPwd";
            this.ShowStatusBar = true;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.FormMdfPwd_Load);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.oldPwd, 0);
            this.Controls.SetChildIndex(this.newPwd, 0);
            this.Controls.SetChildIndex(this.cfmPwd, 0);
            this.Controls.SetChildIndex(this.yesBtn, 0);
            this.Controls.SetChildIndex(this.cancelBtn, 0);
            this.Controls.SetChildIndex(this.errorLabel, 0);
            this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.Controls.TextBoxX oldPwd;
		private DevComponents.DotNetBar.Controls.TextBoxX newPwd;
		private DevComponents.DotNetBar.Controls.TextBoxX cfmPwd;
		private DevComponents.DotNetBar.ButtonX yesBtn;
		private DevComponents.DotNetBar.ButtonX cancelBtn;
		private DevComponents.DotNetBar.LabelX errorLabel;
	}
}