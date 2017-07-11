namespace IVX.Live.MainForm.View
{
    partial class FormSettingServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingServer));
            this.advTreeServer = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader24 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader7 = new DevComponents.AdvTree.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reBootBtn = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddServer = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeServer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advTreeServer
            // 
            this.advTreeServer.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeServer.AllowDrop = true;
            this.advTreeServer.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeServer.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeServer.Columns.Add(this.columnHeader1);
            this.advTreeServer.Columns.Add(this.columnHeader2);
            this.advTreeServer.Columns.Add(this.columnHeader3);
            this.advTreeServer.Columns.Add(this.columnHeader4);
            this.advTreeServer.Columns.Add(this.columnHeader5);
            this.advTreeServer.Columns.Add(this.columnHeader8);
            this.advTreeServer.Columns.Add(this.columnHeader24);
            this.advTreeServer.Columns.Add(this.columnHeader6);
            this.advTreeServer.Columns.Add(this.columnHeader7);
            this.advTreeServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeServer.DragDropEnabled = false;
            this.advTreeServer.ExpandWidth = 0;
            this.advTreeServer.HScrollBarVisible = false;
            this.advTreeServer.ImageList = this.imageList1;
            this.advTreeServer.Location = new System.Drawing.Point(1, 75);
            this.advTreeServer.Name = "advTreeServer";
            this.advTreeServer.NodesConnector = this.nodeConnector1;
            this.advTreeServer.NodeStyle = this.elementStyle1;
            this.advTreeServer.PathSeparator = ";";
            this.advTreeServer.Size = new System.Drawing.Size(988, 521);
            this.advTreeServer.Styles.Add(this.elementStyle1);
            this.advTreeServer.TabIndex = 0;
            this.advTreeServer.Text = "advTree1";
            this.advTreeServer.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTree1_MarkupLinkClick);
            this.advTreeServer.DataSourceChanged += new System.EventHandler(this.advTree1_DataSourceChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "ServerId";
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "服务器ID";
            this.columnHeader1.Width.Absolute = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "ServerIP";
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "服务器IP地址";
            this.columnHeader2.Width.Absolute = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "ServerPort";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "服务器端口";
            this.columnHeader3.Width.Absolute = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DataFieldName = "ServerType";
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "服务器类型";
            this.columnHeader4.Width.Absolute = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DataFieldName = "Status";
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "服务器状态";
            this.columnHeader5.Width.Absolute = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DataFieldName = "Description";
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.Text = "描述";
            this.columnHeader8.Width.Absolute = 150;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Name = "columnHeader24";
            this.columnHeader24.Text = "删除";
            this.columnHeader24.Width.Absolute = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.EditorType = DevComponents.AdvTree.eCellEditorType.DateTime;
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "update time";
            this.columnHeader6.Visible = false;
            this.columnHeader6.Width.Absolute = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Name = "columnHeader7";
            this.columnHeader7.Text = "使用率";
            this.columnHeader7.Visible = false;
            this.columnHeader7.Width.Absolute = 60;
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
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reBootBtn);
            this.panel1.Controls.Add(this.buttonAddServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 31);
            this.panel1.TabIndex = 1;
            // 
            // reBootBtn
            // 
            this.reBootBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.reBootBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.reBootBtn.Location = new System.Drawing.Point(88, 3);
            this.reBootBtn.Name = "reBootBtn";
            this.reBootBtn.Size = new System.Drawing.Size(75, 23);
            this.reBootBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.reBootBtn.TabIndex = 6;
            this.reBootBtn.Text = "重启...";
            this.reBootBtn.Click += new System.EventHandler(this.reBootBtn_Click);
            // 
            // buttonAddServer
            // 
            this.buttonAddServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddServer.Location = new System.Drawing.Point(7, 3);
            this.buttonAddServer.Name = "buttonAddServer";
            this.buttonAddServer.Size = new System.Drawing.Size(75, 23);
            this.buttonAddServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddServer.TabIndex = 6;
            this.buttonAddServer.Text = "添加...";
            this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "修改";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "删除";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "修改";
            // 
            // buttonItem4
            // 
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "删除";
            // 
            // checkBoxItem1
            // 
            this.checkBoxItem1.Name = "checkBoxItem1";
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 623);
            this.Controls.Add(this.advTreeServer);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FormSetting";
            this.ShowStatusBar = true;
            this.Text = "服务器设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSetting_FormClosed);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.advTreeServer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeServer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTreeServer;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private DevComponents.AdvTree.ColumnHeader columnHeader24;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonAddServer;
		private DevComponents.DotNetBar.ButtonX reBootBtn;
    }
}