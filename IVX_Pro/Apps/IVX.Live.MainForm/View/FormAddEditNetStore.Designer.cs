namespace IVX.Live.MainForm.View
{
    partial class FormAddEditNetStore
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
            this.ipAddressInputNetStoreIp = new DevComponents.Editors.IpAddressInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxNetStorePassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.simpleButton1 = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.integerInputNetStorePort = new DevComponents.Editors.IntegerInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxNetStoreType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBoxNetStoreUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.textBoxNetStoreName = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInputNetStoreIp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputNetStorePort)).BeginInit();
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
            this.labelX4.Location = new System.Drawing.Point(60, 231);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(306, 23);
            this.labelX4.TabIndex = 7;
            // 
            // ipAddressInputNetStoreIp
            // 
            this.ipAddressInputNetStoreIp.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInputNetStoreIp.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInputNetStoreIp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInputNetStoreIp.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInputNetStoreIp.ButtonFreeText.Visible = true;
            this.highlighter1.SetHighlightOnFocus(this.ipAddressInputNetStoreIp, true);
            this.ipAddressInputNetStoreIp.Location = new System.Drawing.Point(146, 109);
            this.ipAddressInputNetStoreIp.Name = "ipAddressInputNetStoreIp";
            this.ipAddressInputNetStoreIp.Size = new System.Drawing.Size(152, 21);
            this.ipAddressInputNetStoreIp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInputNetStoreIp.TabIndex = 2;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(239, 260);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(86, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // textBoxNetStorePassword
            // 
            // 
            // 
            // 
            this.textBoxNetStorePassword.Border.Class = "TextBoxBorder";
            this.textBoxNetStorePassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.textBoxNetStorePassword, true);
            this.textBoxNetStorePassword.Location = new System.Drawing.Point(146, 199);
            this.textBoxNetStorePassword.Name = "textBoxNetStorePassword";
            this.textBoxNetStorePassword.Size = new System.Drawing.Size(152, 21);
            this.textBoxNetStorePassword.TabIndex = 5;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(65, 199);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "密码";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(65, 169);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "用户名";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(65, 109);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "地址";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.simpleButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.simpleButton1.Location = new System.Drawing.Point(77, 260);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 23);
            this.simpleButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(65, 139);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "端口";
            // 
            // integerInputNetStorePort
            // 
            // 
            // 
            // 
            this.integerInputNetStorePort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputNetStorePort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputNetStorePort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputNetStorePort.Location = new System.Drawing.Point(146, 139);
            this.integerInputNetStorePort.Name = "integerInputNetStorePort";
            this.integerInputNetStorePort.ShowUpDown = true;
            this.integerInputNetStorePort.Size = new System.Drawing.Size(152, 21);
            this.integerInputNetStorePort.TabIndex = 3;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(65, 79);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "类型";
            // 
            // comboBoxNetStoreType
            // 
            this.comboBoxNetStoreType.DisplayMember = "Text";
            this.comboBoxNetStoreType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxNetStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetStoreType.FormattingEnabled = true;
            this.comboBoxNetStoreType.ItemHeight = 15;
            this.comboBoxNetStoreType.Location = new System.Drawing.Point(146, 79);
            this.comboBoxNetStoreType.Name = "comboBoxNetStoreType";
            this.comboBoxNetStoreType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxNetStoreType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxNetStoreType.TabIndex = 1;
            this.comboBoxNetStoreType.SelectedIndexChanged += new System.EventHandler(this.comboBoxNetStoreType_SelectedIndexChanged);
            // 
            // textBoxNetStoreUsername
            // 
            // 
            // 
            // 
            this.textBoxNetStoreUsername.Border.Class = "TextBoxBorder";
            this.textBoxNetStoreUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxNetStoreUsername.Location = new System.Drawing.Point(146, 169);
            this.textBoxNetStoreUsername.Name = "textBoxNetStoreUsername";
            this.textBoxNetStoreUsername.Size = new System.Drawing.Size(152, 21);
            this.textBoxNetStoreUsername.TabIndex = 4;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(65, 49);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "名称";
            // 
            // textBoxNetStoreName
            // 
            // 
            // 
            // 
            this.textBoxNetStoreName.Border.Class = "TextBoxBorder";
            this.textBoxNetStoreName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxNetStoreName.Location = new System.Drawing.Point(146, 49);
            this.textBoxNetStoreName.Name = "textBoxNetStoreName";
            this.textBoxNetStoreName.Size = new System.Drawing.Size(252, 21);
            this.textBoxNetStoreName.TabIndex = 0;
            // 
            // FormAddEditNetStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 324);
            this.Controls.Add(this.comboBoxNetStoreType);
            this.Controls.Add(this.integerInputNetStorePort);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.ipAddressInputNetStoreIp);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.textBoxNetStoreUsername);
            this.Controls.Add(this.textBoxNetStoreName);
            this.Controls.Add(this.textBoxNetStorePassword);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.simpleButton1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditNetStore";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "添加平台";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.labelX7, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.textBoxNetStorePassword, 0);
            this.Controls.SetChildIndex(this.textBoxNetStoreName, 0);
            this.Controls.SetChildIndex(this.textBoxNetStoreUsername, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.ipAddressInputNetStoreIp, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.integerInputNetStorePort, 0);
            this.Controls.SetChildIndex(this.comboBoxNetStoreType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInputNetStoreIp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputNetStorePort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX simpleButton1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxNetStorePassword;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.Editors.IpAddressInput ipAddressInputNetStoreIp;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxNetStoreType;
        private DevComponents.Editors.IntegerInput integerInputNetStorePort;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxNetStoreUsername;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxNetStoreName;
        private DevComponents.DotNetBar.LabelX labelX7;


    }
}
