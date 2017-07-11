namespace IVX.Live.MainForm.View
{
    partial class FormAddEditServer
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
            this.ipAddressInputServerIp = new DevComponents.Editors.IpAddressInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.simpleButton1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.integerInputServerPort = new DevComponents.Editors.IntegerInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxServerType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBoxDes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPortRegion = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInputServerIp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputServerPort)).BeginInit();
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
            this.labelX4.Location = new System.Drawing.Point(80, 185);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(306, 23);
            this.labelX4.TabIndex = 7;
            // 
            // ipAddressInputServerIp
            // 
            this.ipAddressInputServerIp.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInputServerIp.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInputServerIp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInputServerIp.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInputServerIp.ButtonFreeText.Visible = true;
            this.ipAddressInputServerIp.Location = new System.Drawing.Point(161, 102);
            this.ipAddressInputServerIp.Name = "ipAddressInputServerIp";
            this.ipAddressInputServerIp.Size = new System.Drawing.Size(152, 21);
            this.ipAddressInputServerIp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInputServerIp.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(254, 214);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(86, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(80, 156);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "用途";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(80, 100);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "地址";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.simpleButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.simpleButton1.Location = new System.Drawing.Point(92, 214);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 23);
            this.simpleButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(80, 127);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "端口";
            // 
            // integerInputServerPort
            // 
            // 
            // 
            // 
            this.integerInputServerPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputServerPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputServerPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputServerPort.Location = new System.Drawing.Point(161, 129);
            this.integerInputServerPort.Name = "integerInputServerPort";
            this.integerInputServerPort.ShowUpDown = true;
            this.integerInputServerPort.Size = new System.Drawing.Size(152, 21);
            this.integerInputServerPort.TabIndex = 2;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(80, 71);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "类型";
            // 
            // comboBoxServerType
            // 
            this.comboBoxServerType.DisplayMember = "Text";
            this.comboBoxServerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServerType.FormattingEnabled = true;
            this.comboBoxServerType.ItemHeight = 15;
            this.comboBoxServerType.Location = new System.Drawing.Point(161, 71);
            this.comboBoxServerType.Name = "comboBoxServerType";
            this.comboBoxServerType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxServerType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxServerType.TabIndex = 0;
            // 
            // textBoxDes
            // 
            // 
            // 
            // 
            this.textBoxDes.Border.Class = "TextBoxBorder";
            this.textBoxDes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDes.Location = new System.Drawing.Point(161, 156);
            this.textBoxDes.Name = "textBoxDes";
            this.textBoxDes.Size = new System.Drawing.Size(152, 21);
            this.textBoxDes.TabIndex = 3;
            // 
            // labelPortRegion
            // 
            // 
            // 
            // 
            this.labelPortRegion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPortRegion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPortRegion.Location = new System.Drawing.Point(319, 129);
            this.labelPortRegion.Name = "labelPortRegion";
            this.labelPortRegion.Size = new System.Drawing.Size(94, 23);
            this.labelPortRegion.TabIndex = 7;
            // 
            // FormAddEditServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 273);
            this.Controls.Add(this.comboBoxServerType);
            this.Controls.Add(this.integerInputServerPort);
            this.Controls.Add(this.labelPortRegion);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.ipAddressInputServerIp);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.textBoxDes);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.simpleButton1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditServer";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "添加服务";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.textBoxDes, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.ipAddressInputServerIp, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.labelPortRegion, 0);
            this.Controls.SetChildIndex(this.integerInputServerPort, 0);
            this.Controls.SetChildIndex(this.comboBoxServerType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInputServerIp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX simpleButton1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IpAddressInput ipAddressInputServerIp;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxServerType;
        private DevComponents.Editors.IntegerInput integerInputServerPort;
        private DevComponents.DotNetBar.LabelX labelPortRegion;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxDes;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;


    }
}
