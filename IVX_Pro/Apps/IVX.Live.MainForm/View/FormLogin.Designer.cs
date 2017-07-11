namespace IVX.Live.MainForm.View
{
    partial class FormLogin
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
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ipAddressInput1 = new DevComponents.Editors.IpAddressInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.pwd_textBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.UserName_DropDown = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.simpleButton1 = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.labelVersion = new DevComponents.DotNetBar.LabelX();
            this.checkBoxSaveUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.ForeColor = System.Drawing.Color.Red;
            this.labelX4.Location = new System.Drawing.Point(79, 162);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(306, 23);
            this.labelX4.TabIndex = 7;
            // 
            // ipAddressInput1
            // 
            this.ipAddressInput1.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput1.ButtonFreeText.Visible = true;
            this.highlighter1.SetHighlightOnFocus(this.ipAddressInput1, true);
            this.ipAddressInput1.Location = new System.Drawing.Point(163, 64);
            this.ipAddressInput1.Name = "ipAddressInput1";
            this.ipAddressInput1.Size = new System.Drawing.Size(152, 21);
            this.ipAddressInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput1.TabIndex = 0;
            this.ipAddressInput1.Value = "192.168.42.197";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(241, 191);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(86, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "退出";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // pwd_textBox
            // 
            // 
            // 
            // 
            this.pwd_textBox.Border.Class = "TextBoxBorder";
            this.pwd_textBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.pwd_textBox, true);
            this.pwd_textBox.Location = new System.Drawing.Point(163, 127);
            this.pwd_textBox.Name = "pwd_textBox";
            this.pwd_textBox.PasswordChar = '*';
            this.pwd_textBox.ShortcutsEnabled = false;
            this.pwd_textBox.Size = new System.Drawing.Size(152, 21);
            this.pwd_textBox.TabIndex = 2;
            this.pwd_textBox.UseSystemPasswordChar = true;
            // 
            // UserName_DropDown
            // 
            // 
            // 
            // 
            this.UserName_DropDown.BackgroundStyle.Class = "TextBoxBorder";
            this.UserName_DropDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.UserName_DropDown, true);
            this.UserName_DropDown.Location = new System.Drawing.Point(163, 96);
            this.UserName_DropDown.Name = "UserName_DropDown";
            this.UserName_DropDown.Size = new System.Drawing.Size(152, 20);
            this.UserName_DropDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.UserName_DropDown.TabIndex = 1;
            this.UserName_DropDown.Text = "";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(82, 127);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "密    码";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(82, 93);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "用 户 名";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(82, 62);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "登陆地址";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.simpleButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.simpleButton1.Location = new System.Drawing.Point(79, 191);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 23);
            this.simpleButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "登录";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            // 
            // 
            // 
            this.labelVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelVersion.Location = new System.Drawing.Point(1, 209);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 0);
            this.labelVersion.TabIndex = 8;
            // 
            // checkBoxSaveUser
            // 
            this.checkBoxSaveUser.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxSaveUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxSaveUser.Checked = true;
            this.checkBoxSaveUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveUser.CheckValue = "Y";
            this.checkBoxSaveUser.Location = new System.Drawing.Point(332, 125);
            this.checkBoxSaveUser.Name = "checkBoxSaveUser";
            this.checkBoxSaveUser.Size = new System.Drawing.Size(87, 23);
            this.checkBoxSaveUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxSaveUser.TabIndex = 3;
            this.checkBoxSaveUser.Text = "记住密码";
            this.checkBoxSaveUser.CheckedChanged += new System.EventHandler(this.checkBoxSaveUser_CheckedChanged);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 236);
            this.Controls.Add(this.checkBoxSaveUser);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.ipAddressInput1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.pwd_textBox);
            this.Controls.Add(this.UserName_DropDown);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.simpleButton1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.UserName_DropDown, 0);
            this.Controls.SetChildIndex(this.pwd_textBox, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.ipAddressInput1, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.Controls.SetChildIndex(this.checkBoxSaveUser, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX simpleButton1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown UserName_DropDown;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX pwd_textBox;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.Editors.IpAddressInput ipAddressInput1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelVersion;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxSaveUser;


    }
}
