namespace IVX.Live.MainForm.View {
	partial class FormUserInfoSingle {
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
			this.Txt_userName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.userRoleCom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.comboItem1 = new DevComponents.Editors.ComboItem();
			this.comboItem2 = new DevComponents.Editors.ComboItem();
			this.Txt_userOther = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.Txt_pwd = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.cancelBtn = new DevComponents.DotNetBar.ButtonX();
			this.yesBtn = new DevComponents.DotNetBar.ButtonX();
			this.errorLabel = new DevComponents.DotNetBar.LabelX();
			this.mdfPwd = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// Txt_userName
			// 
			// 
			// 
			// 
			this.Txt_userName.Border.Class = "TextBoxBorder";
			this.Txt_userName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.Txt_userName.Location = new System.Drawing.Point(166, 50);
			this.Txt_userName.Name = "Txt_userName";
			this.Txt_userName.ReadOnly = true;
			this.Txt_userName.Size = new System.Drawing.Size(101, 21);
			this.Txt_userName.TabIndex = 7;
			// 
			// labelX2
			// 
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.Location = new System.Drawing.Point(83, 46);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(79, 23);
			this.labelX2.TabIndex = 8;
			this.labelX2.Text = "用 户 名 :";
			this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// userRoleCom
			// 
			this.userRoleCom.DisplayMember = "Text";
			this.userRoleCom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.userRoleCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.userRoleCom.Enabled = false;
			this.userRoleCom.FormattingEnabled = true;
			this.userRoleCom.ItemHeight = 15;
			this.userRoleCom.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
			this.userRoleCom.Location = new System.Drawing.Point(166, 122);
			this.userRoleCom.Name = "userRoleCom";
			this.userRoleCom.Size = new System.Drawing.Size(101, 21);
			this.userRoleCom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.userRoleCom.TabIndex = 10;
			// 
			// comboItem1
			// 
			this.comboItem1.Text = "管理员";
			// 
			// comboItem2
			// 
			this.comboItem2.Text = "普通用户";
			// 
			// Txt_userOther
			// 
			// 
			// 
			// 
			this.Txt_userOther.Border.Class = "TextBoxBorder";
			this.Txt_userOther.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.Txt_userOther.Location = new System.Drawing.Point(166, 160);
			this.Txt_userOther.Name = "Txt_userOther";
			this.Txt_userOther.Size = new System.Drawing.Size(190, 21);
			this.Txt_userOther.TabIndex = 11;
			this.Txt_userOther.TextChanged += new System.EventHandler(this.Txt_userOther_TextChanged);
			// 
			// Txt_pwd
			// 
			// 
			// 
			// 
			this.Txt_pwd.Border.Class = "TextBoxBorder";
			this.Txt_pwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.Txt_pwd.Location = new System.Drawing.Point(166, 84);
			this.Txt_pwd.Name = "Txt_pwd";
			this.Txt_pwd.PasswordChar = '*';
			this.Txt_pwd.ReadOnly = true;
			this.Txt_pwd.Size = new System.Drawing.Size(102, 21);
			this.Txt_pwd.TabIndex = 9;
			this.Txt_pwd.TextChanged += new System.EventHandler(this.Txt_userOther_TextChanged);
			// 
			// labelX5
			// 
			// 
			// 
			// 
			this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX5.Location = new System.Drawing.Point(66, 158);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(96, 23);
			this.labelX5.TabIndex = 14;
			this.labelX5.Text = "信息备注 :";
			this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
			this.labelX5.TextLineAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX4
			// 
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.Location = new System.Drawing.Point(96, 120);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(66, 23);
			this.labelX4.TabIndex = 13;
			this.labelX4.Text = "用户角色 :";
			// 
			// labelX3
			// 
			// 
			// 
			// 
			this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX3.Location = new System.Drawing.Point(83, 82);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(79, 23);
			this.labelX3.TabIndex = 12;
			this.labelX3.Text = "密    码 :";
			this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
			this.labelX3.TextLineAlignment = System.Drawing.StringAlignment.Far;
			// 
			// cancelBtn
			// 
			this.cancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.cancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.cancelBtn.Location = new System.Drawing.Point(240, 216);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(76, 24);
			this.cancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.cancelBtn.TabIndex = 16;
			this.cancelBtn.TabStop = false;
			this.cancelBtn.Text = "取消";
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// yesBtn
			// 
			this.yesBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.yesBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.yesBtn.Location = new System.Drawing.Point(94, 216);
			this.yesBtn.Name = "yesBtn";
			this.yesBtn.Size = new System.Drawing.Size(78, 24);
			this.yesBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.yesBtn.TabIndex = 15;
			this.yesBtn.TabStop = false;
			this.yesBtn.Text = "确定";
			this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
			// 
			// errorLabel
			// 
			// 
			// 
			// 
			this.errorLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.errorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(94, 187);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(276, 23);
			this.errorLabel.TabIndex = 17;
			// 
			// mdfPwd
			// 
			this.mdfPwd.AutoSize = true;
			this.mdfPwd.Location = new System.Drawing.Point(286, 86);
			this.mdfPwd.Name = "mdfPwd";
			this.mdfPwd.Size = new System.Drawing.Size(53, 12);
			this.mdfPwd.TabIndex = 18;
			this.mdfPwd.TabStop = true;
			this.mdfPwd.Text = "修改密码";
			this.mdfPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mdfPwd_LinkClicked);
			// 
			// FormUserInfoSingle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 273);
			this.Controls.Add(this.mdfPwd);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.yesBtn);
			this.Controls.Add(this.userRoleCom);
			this.Controls.Add(this.Txt_userOther);
			this.Controls.Add(this.Txt_pwd);
			this.Controls.Add(this.labelX5);
			this.Controls.Add(this.labelX4);
			this.Controls.Add(this.labelX3);
			this.Controls.Add(this.Txt_userName);
			this.Controls.Add(this.labelX2);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormUserInfoSingle";
			this.ShowStatusBar = true;
			this.Text = "个人信息";
			this.Load += new System.EventHandler(this.FormUserInfoSingle_Load);
			this.Controls.SetChildIndex(this.labelX2, 0);
			this.Controls.SetChildIndex(this.Txt_userName, 0);
			this.Controls.SetChildIndex(this.labelX3, 0);
			this.Controls.SetChildIndex(this.labelX4, 0);
			this.Controls.SetChildIndex(this.labelX5, 0);
			this.Controls.SetChildIndex(this.Txt_pwd, 0);
			this.Controls.SetChildIndex(this.Txt_userOther, 0);
			this.Controls.SetChildIndex(this.userRoleCom, 0);
			this.Controls.SetChildIndex(this.yesBtn, 0);
			this.Controls.SetChildIndex(this.cancelBtn, 0);
			this.Controls.SetChildIndex(this.errorLabel, 0);
			this.Controls.SetChildIndex(this.mdfPwd, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevComponents.DotNetBar.Controls.TextBoxX Txt_userName;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.Controls.ComboBoxEx userRoleCom;
		private DevComponents.Editors.ComboItem comboItem1;
		private DevComponents.Editors.ComboItem comboItem2;
		private DevComponents.DotNetBar.Controls.TextBoxX Txt_userOther;
		private DevComponents.DotNetBar.Controls.TextBoxX Txt_pwd;
		private DevComponents.DotNetBar.LabelX labelX5;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.ButtonX cancelBtn;
		private DevComponents.DotNetBar.ButtonX yesBtn;
		private DevComponents.DotNetBar.LabelX errorLabel;
		private System.Windows.Forms.LinkLabel mdfPwd;
	}
}