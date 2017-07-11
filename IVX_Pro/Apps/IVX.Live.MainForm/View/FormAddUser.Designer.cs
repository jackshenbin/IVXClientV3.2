namespace IVX.Live.MainForm.View {
	partial class FormAddUser {
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
            this.Txt_userName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.Txt_pwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Txt_pwdCfm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Txt_userOther = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.yesBtn = new DevComponents.DotNetBar.ButtonX();
            this.cancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.errorLabel = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.userRoleCom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(79, 45);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "用 户 名 :";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Txt_userName
            // 
            // 
            // 
            // 
            this.Txt_userName.Border.Class = "TextBoxBorder";
            this.Txt_userName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Txt_userName.Location = new System.Drawing.Point(162, 49);
            this.Txt_userName.Name = "Txt_userName";
            this.Txt_userName.Size = new System.Drawing.Size(101, 21);
            this.Txt_userName.TabIndex = 0;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(79, 74);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "密    码 :";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelX3.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(92, 130);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(66, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "用户角色 :";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(62, 156);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(96, 23);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "信息备注 :";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelX5.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(79, 101);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(79, 23);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "密码确认 :";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Txt_pwd
            // 
            // 
            // 
            // 
            this.Txt_pwd.Border.Class = "TextBoxBorder";
            this.Txt_pwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Txt_pwd.Location = new System.Drawing.Point(161, 74);
            this.Txt_pwd.Name = "Txt_pwd";
            this.Txt_pwd.PasswordChar = '*';
            this.Txt_pwd.Size = new System.Drawing.Size(102, 21);
            this.Txt_pwd.TabIndex = 1;
            // 
            // Txt_pwdCfm
            // 
            // 
            // 
            // 
            this.Txt_pwdCfm.Border.Class = "TextBoxBorder";
            this.Txt_pwdCfm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Txt_pwdCfm.Location = new System.Drawing.Point(162, 101);
            this.Txt_pwdCfm.Name = "Txt_pwdCfm";
            this.Txt_pwdCfm.PasswordChar = '*';
            this.Txt_pwdCfm.Size = new System.Drawing.Size(101, 21);
            this.Txt_pwdCfm.TabIndex = 2;
            // 
            // Txt_userOther
            // 
            // 
            // 
            // 
            this.Txt_userOther.Border.Class = "TextBoxBorder";
            this.Txt_userOther.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Txt_userOther.Location = new System.Drawing.Point(161, 158);
            this.Txt_userOther.Name = "Txt_userOther";
            this.Txt_userOther.Size = new System.Drawing.Size(190, 21);
            this.Txt_userOther.TabIndex = 4;
            // 
            // yesBtn
            // 
            this.yesBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.yesBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.yesBtn.Location = new System.Drawing.Point(92, 217);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(78, 24);
            this.yesBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.yesBtn.TabIndex = 5;
            this.yesBtn.TabStop = false;
            this.yesBtn.Text = "确定";
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelBtn.Location = new System.Drawing.Point(235, 217);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(76, 24);
            this.cancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelBtn.TabIndex = 6;
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
            this.errorLabel.Location = new System.Drawing.Point(92, 185);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(276, 23);
            this.errorLabel.TabIndex = 10;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(282, 50);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(101, 20);
            this.labelX7.TabIndex = 11;
            this.labelX7.Text = "数字、字母组成";
            // 
            // userRoleCom
            // 
            this.userRoleCom.DisplayMember = "Text";
            this.userRoleCom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.userRoleCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userRoleCom.FormattingEnabled = true;
            this.userRoleCom.ItemHeight = 15;
            this.userRoleCom.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.userRoleCom.Location = new System.Drawing.Point(162, 132);
            this.userRoleCom.Name = "userRoleCom";
            this.userRoleCom.Size = new System.Drawing.Size(101, 21);
            this.userRoleCom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.userRoleCom.TabIndex = 3;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "管理员";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "普通用户";
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 273);
            this.Controls.Add(this.userRoleCom);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.yesBtn);
            this.Controls.Add(this.Txt_userOther);
            this.Controls.Add(this.Txt_pwdCfm);
            this.Controls.Add(this.Txt_pwd);
            this.Controls.Add(this.Txt_userName);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddUser";
            this.ShowStatusBar = true;
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.FormAddUser_Load);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.Txt_userName, 0);
            this.Controls.SetChildIndex(this.Txt_pwd, 0);
            this.Controls.SetChildIndex(this.Txt_pwdCfm, 0);
            this.Controls.SetChildIndex(this.Txt_userOther, 0);
            this.Controls.SetChildIndex(this.yesBtn, 0);
            this.Controls.SetChildIndex(this.cancelBtn, 0);
            this.Controls.SetChildIndex(this.errorLabel, 0);
            this.Controls.SetChildIndex(this.labelX7, 0);
            this.Controls.SetChildIndex(this.userRoleCom, 0);
            this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.Controls.TextBoxX Txt_userName;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.LabelX labelX5;
		private DevComponents.DotNetBar.LabelX labelX6;
		private DevComponents.DotNetBar.Controls.TextBoxX Txt_pwd;
		private DevComponents.DotNetBar.Controls.TextBoxX Txt_pwdCfm;
		private DevComponents.DotNetBar.Controls.TextBoxX Txt_userOther;
		private DevComponents.DotNetBar.ButtonX yesBtn;
		private DevComponents.DotNetBar.ButtonX cancelBtn;
		private DevComponents.DotNetBar.LabelX errorLabel;
		private DevComponents.DotNetBar.LabelX labelX7;
		private DevComponents.DotNetBar.Controls.ComboBoxEx userRoleCom;
		private DevComponents.Editors.ComboItem comboItem1;
		private DevComponents.Editors.ComboItem comboItem2;
	}
}