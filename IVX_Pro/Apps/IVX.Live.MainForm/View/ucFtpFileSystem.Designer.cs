namespace IVX.Live.MainForm.View
{
    partial class ucFtpFileSystem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFtpFileSystem));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxIP = new DevComponents.Editors.IpAddressInput();
            this.textBoxPort = new DevComponents.Editors.IntegerInput();
            this.buttonGetFtpFile = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.checkBoxAnonymous = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPort)).BeginInit();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListFile
            // 
            // 
            // 
            // 
            this.treeListFile.BackgroundStyle.Class = "TreeBorderKey";
            this.treeListFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeListFile.Location = new System.Drawing.Point(0, 124);
            this.treeListFile.Size = new System.Drawing.Size(289, 314);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "File.png");
            this.imageList1.Images.SetKeyName(1, "Folder_Closed.png");
            this.imageList1.Images.SetKeyName(2, "Folder_Opened.png");
            this.imageList1.Images.SetKeyName(3, "Local_Disk.png");
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 36);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "FTP地址";
            // 
            // textBoxIP
            // 
            this.textBoxIP.AutoOverwrite = true;
            // 
            // 
            // 
            this.textBoxIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBoxIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBoxIP.ButtonFreeText.Visible = true;
            this.textBoxIP.Location = new System.Drawing.Point(66, 36);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(146, 21);
            this.textBoxIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Value = "127.0.0.1";
            // 
            // textBoxPort
            // 
            // 
            // 
            // 
            this.textBoxPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBoxPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBoxPort.Location = new System.Drawing.Point(218, 36);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ShowUpDown = true;
            this.textBoxPort.Size = new System.Drawing.Size(60, 21);
            this.textBoxPort.TabIndex = 2;
            this.textBoxPort.Value = 21;
            // 
            // buttonGetFtpFile
            // 
            this.buttonGetFtpFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGetFtpFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGetFtpFile.Location = new System.Drawing.Point(203, 92);
            this.buttonGetFtpFile.Name = "buttonGetFtpFile";
            this.buttonGetFtpFile.Size = new System.Drawing.Size(75, 23);
            this.buttonGetFtpFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGetFtpFile.TabIndex = 3;
            this.buttonGetFtpFile.Text = "获取文件";
            this.buttonGetFtpFile.Click += new System.EventHandler(this.buttonGetFtpFile_Click);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(10, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(44, 18);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "用户名";
            // 
            // textBoxUser
            // 
            // 
            // 
            // 
            this.textBoxUser.Border.Class = "TextBoxBorder";
            this.textBoxUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxUser.Enabled = false;
            this.textBoxUser.Location = new System.Drawing.Point(66, 63);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 21);
            this.textBoxUser.TabIndex = 5;
            this.textBoxUser.Text = "anonymous";
            // 
            // textBoxPass
            // 
            // 
            // 
            // 
            this.textBoxPass.Border.Class = "TextBoxBorder";
            this.textBoxPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxPass.Enabled = false;
            this.textBoxPass.Location = new System.Drawing.Point(66, 90);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 21);
            this.textBoxPass.TabIndex = 6;
            this.textBoxPass.Text = "anonymous";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(10, 90);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(31, 18);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "密码";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.checkBoxAnonymous);
            this.expandablePanel1.Controls.Add(this.labelX1);
            this.expandablePanel1.Controls.Add(this.textBoxIP);
            this.expandablePanel1.Controls.Add(this.textBoxPort);
            this.expandablePanel1.Controls.Add(this.labelX3);
            this.expandablePanel1.Controls.Add(this.buttonGetFtpFile);
            this.expandablePanel1.Controls.Add(this.textBoxPass);
            this.expandablePanel1.Controls.Add(this.labelX2);
            this.expandablePanel1.Controls.Add(this.textBoxUser);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(289, 124);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 10;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "FTP地址设置";
            // 
            // checkBoxAnonymous
            // 
            this.checkBoxAnonymous.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxAnonymous.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxAnonymous.Checked = true;
            this.checkBoxAnonymous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAnonymous.CheckValue = "Y";
            this.checkBoxAnonymous.Location = new System.Drawing.Point(172, 63);
            this.checkBoxAnonymous.Name = "checkBoxAnonymous";
            this.checkBoxAnonymous.Size = new System.Drawing.Size(87, 23);
            this.checkBoxAnonymous.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxAnonymous.TabIndex = 10;
            this.checkBoxAnonymous.Text = "匿名登录";
            this.checkBoxAnonymous.CheckedChanged += new System.EventHandler(this.checkBoxAnonymous_CheckedChanged);
            // 
            // ucFtpFileSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expandablePanel1);
            this.Name = "ucFtpFileSystem";
            this.Size = new System.Drawing.Size(289, 438);
            this.Load += new System.EventHandler(this.ucFtpFileSystem_Load);
            this.Controls.SetChildIndex(this.expandablePanel1, 0);
            this.Controls.SetChildIndex(this.treeListFile, 0);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPort)).EndInit();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IpAddressInput textBoxIP;
        private DevComponents.Editors.IntegerInput textBoxPort;
        private DevComponents.DotNetBar.ButtonX buttonGetFtpFile;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxUser;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxPass;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxAnonymous;
    }
}
