namespace IVX.Live.MainForm.View
{
    partial class FormAddEditTransEvent
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.simpleButton1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.integerInputServerPort = new DevComponents.Editors.IntegerInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxProtocolType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxMergeStyle = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxStoreType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxAnalyseType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
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
            this.labelX4.Location = new System.Drawing.Point(67, 237);
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
            this.ipAddressInputServerIp.Location = new System.Drawing.Point(161, 55);
            this.ipAddressInputServerIp.Name = "ipAddressInputServerIp";
            this.ipAddressInputServerIp.Size = new System.Drawing.Size(152, 21);
            this.ipAddressInputServerIp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInputServerIp.TabIndex = 0;
            this.ipAddressInputServerIp.Value = "127.0.0.1";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(241, 266);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(86, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(80, 53);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "转发地址";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.simpleButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.simpleButton1.Location = new System.Drawing.Point(79, 266);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 23);
            this.simpleButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(80, 80);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "转发端口";
            // 
            // integerInputServerPort
            // 
            // 
            // 
            // 
            this.integerInputServerPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputServerPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputServerPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputServerPort.Location = new System.Drawing.Point(161, 82);
            this.integerInputServerPort.Name = "integerInputServerPort";
            this.integerInputServerPort.ShowUpDown = true;
            this.integerInputServerPort.Size = new System.Drawing.Size(152, 21);
            this.integerInputServerPort.TabIndex = 1;
            this.integerInputServerPort.Value = 11301;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(80, 109);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "转发协议";
            // 
            // comboBoxProtocolType
            // 
            this.comboBoxProtocolType.DisplayMember = "Text";
            this.comboBoxProtocolType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxProtocolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocolType.FormattingEnabled = true;
            this.comboBoxProtocolType.ItemHeight = 15;
            this.comboBoxProtocolType.Location = new System.Drawing.Point(161, 109);
            this.comboBoxProtocolType.Name = "comboBoxProtocolType";
            this.comboBoxProtocolType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxProtocolType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxProtocolType.TabIndex = 2;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(80, 189);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "合图模板";
            // 
            // comboBoxMergeStyle
            // 
            this.comboBoxMergeStyle.DisplayMember = "Text";
            this.comboBoxMergeStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxMergeStyle.Enabled = false;
            this.comboBoxMergeStyle.FormattingEnabled = true;
            this.comboBoxMergeStyle.ItemHeight = 15;
            this.comboBoxMergeStyle.Items.AddRange(new object[] {
            this.comboItem1});
            this.comboBoxMergeStyle.Location = new System.Drawing.Point(161, 189);
            this.comboBoxMergeStyle.Name = "comboBoxMergeStyle";
            this.comboBoxMergeStyle.Size = new System.Drawing.Size(152, 21);
            this.comboBoxMergeStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxMergeStyle.TabIndex = 5;
            this.comboBoxMergeStyle.Text = "默认合图";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "默认合图";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(79, 133);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "存储方式";
            // 
            // comboBoxStoreType
            // 
            this.comboBoxStoreType.DisplayMember = "Text";
            this.comboBoxStoreType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoreType.FormattingEnabled = true;
            this.comboBoxStoreType.ItemHeight = 15;
            this.comboBoxStoreType.Location = new System.Drawing.Point(161, 135);
            this.comboBoxStoreType.Name = "comboBoxStoreType";
            this.comboBoxStoreType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxStoreType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxStoreType.TabIndex = 3;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(67, 162);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(88, 23);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "转发算法类型";
            // 
            // comboBoxAnalyseType
            // 
            this.comboBoxAnalyseType.DisplayMember = "Text";
            this.comboBoxAnalyseType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxAnalyseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnalyseType.FormattingEnabled = true;
            this.comboBoxAnalyseType.ItemHeight = 15;
            this.comboBoxAnalyseType.Items.AddRange(new object[] {
            this.comboItem2});
            this.comboBoxAnalyseType.Location = new System.Drawing.Point(161, 162);
            this.comboBoxAnalyseType.Name = "comboBoxAnalyseType";
            this.comboBoxAnalyseType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxAnalyseType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxAnalyseType.TabIndex = 4;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "默认合图";
            // 
            // FormAddEditTransEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 322);
            this.Controls.Add(this.comboBoxStoreType);
            this.Controls.Add(this.comboBoxAnalyseType);
            this.Controls.Add(this.comboBoxMergeStyle);
            this.Controls.Add(this.comboBoxProtocolType);
            this.Controls.Add(this.integerInputServerPort);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.ipAddressInputServerIp);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.simpleButton1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditTransEvent";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "添加转发";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.labelX7, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.ipAddressInputServerIp, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.integerInputServerPort, 0);
            this.Controls.SetChildIndex(this.comboBoxProtocolType, 0);
            this.Controls.SetChildIndex(this.comboBoxMergeStyle, 0);
            this.Controls.SetChildIndex(this.comboBoxAnalyseType, 0);
            this.Controls.SetChildIndex(this.comboBoxStoreType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInputServerIp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX simpleButton1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IpAddressInput ipAddressInputServerIp;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxProtocolType;
        private DevComponents.Editors.IntegerInput integerInputServerPort;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxMergeStyle;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxStoreType;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxAnalyseType;
        private DevComponents.Editors.ComboItem comboItem2;


    }
}
