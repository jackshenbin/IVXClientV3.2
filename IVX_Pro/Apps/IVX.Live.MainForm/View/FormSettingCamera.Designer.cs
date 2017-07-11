namespace IVX.Live.MainForm.View
{
    partial class FormSettingCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingCamera));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonAddNetStore = new DevComponents.DotNetBar.ButtonX();
            this.advTreeVideoSupplier = new DevComponents.AdvTree.AdvTree();
            this.columnHeader9 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader16 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader10 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader11 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader12 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader13 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader14 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader23 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector4 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.buttonMutiAdd = new DevComponents.DotNetBar.ButtonX();
            this.advTreeCamera = new DevComponents.AdvTree.AdvTree();
            this.columnHeader17 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader19 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader18 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader20 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader21 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader22 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader15 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector3 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.buttonAddCamera = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeVideoSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeCamera)).BeginInit();
            this.SuspendLayout();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 44);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddNetStore);
            this.splitContainer1.Panel1.Controls.Add(this.advTreeVideoSupplier);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonMutiAdd);
            this.splitContainer1.Panel2.Controls.Add(this.advTreeCamera);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddCamera);
            this.splitContainer1.Size = new System.Drawing.Size(988, 552);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 6;
            // 
            // buttonAddNetStore
            // 
            this.buttonAddNetStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddNetStore.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddNetStore.Location = new System.Drawing.Point(3, 5);
            this.buttonAddNetStore.Name = "buttonAddNetStore";
            this.buttonAddNetStore.Size = new System.Drawing.Size(90, 23);
            this.buttonAddNetStore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddNetStore.Symbol = "";
            this.buttonAddNetStore.TabIndex = 5;
            this.buttonAddNetStore.Text = "添加...";
            this.buttonAddNetStore.Click += new System.EventHandler(this.buttonAddNetStore_Click);
            // 
            // advTreeVideoSupplier
            // 
            this.advTreeVideoSupplier.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeVideoSupplier.AllowDrop = true;
            this.advTreeVideoSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advTreeVideoSupplier.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeVideoSupplier.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeVideoSupplier.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader9);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader16);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader10);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader11);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader12);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader13);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader14);
            this.advTreeVideoSupplier.Columns.Add(this.columnHeader23);
            this.advTreeVideoSupplier.DragDropEnabled = false;
            this.advTreeVideoSupplier.ExpandWidth = 0;
            this.advTreeVideoSupplier.ImageList = this.imageList1;
            this.advTreeVideoSupplier.Location = new System.Drawing.Point(3, 32);
            this.advTreeVideoSupplier.Name = "advTreeVideoSupplier";
            this.advTreeVideoSupplier.NodesConnector = this.nodeConnector4;
            this.advTreeVideoSupplier.NodeStyle = this.elementStyle4;
            this.advTreeVideoSupplier.PathSeparator = ";";
            this.advTreeVideoSupplier.Size = new System.Drawing.Size(979, 163);
            this.advTreeVideoSupplier.Styles.Add(this.elementStyle4);
            this.advTreeVideoSupplier.TabIndex = 3;
            this.advTreeVideoSupplier.Text = "advTree4";
            this.advTreeVideoSupplier.BeforeNodeSelect += new DevComponents.AdvTree.AdvTreeNodeCancelEventHandler(this.advTree4_BeforeNodeSelect);
            this.advTreeVideoSupplier.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTree4_MarkupLinkClick);
            this.advTreeVideoSupplier.DataSourceChanged += new System.EventHandler(this.advTree4_DataSourceChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.DataFieldName = "id";
            this.columnHeader9.Name = "columnHeader9";
            this.columnHeader9.Text = "平台ID";
            this.columnHeader9.Width.Absolute = 50;
            // 
            // columnHeader16
            // 
            this.columnHeader16.DataFieldName = "DeviceName";
            this.columnHeader16.Name = "columnHeader16";
            this.columnHeader16.Text = "设备名称";
            this.columnHeader16.Width.Absolute = 300;
            // 
            // columnHeader10
            // 
            this.columnHeader10.DataFieldName = "ProtocolType";
            this.columnHeader10.Name = "columnHeader10";
            this.columnHeader10.Text = "平台类型";
            this.columnHeader10.Width.Absolute = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DataFieldName = "IP";
            this.columnHeader11.Name = "columnHeader11";
            this.columnHeader11.Text = "设备IP";
            this.columnHeader11.Width.Absolute = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.DataFieldName = "Port";
            this.columnHeader12.Name = "columnHeader12";
            this.columnHeader12.Text = "设备端口";
            this.columnHeader12.Width.Absolute = 60;
            // 
            // columnHeader13
            // 
            this.columnHeader13.DataFieldName = "UserName";
            this.columnHeader13.EditorType = DevComponents.AdvTree.eCellEditorType.DateTime;
            this.columnHeader13.Name = "columnHeader13";
            this.columnHeader13.Text = "用户名";
            this.columnHeader13.Width.Absolute = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.DataFieldName = "Password";
            this.columnHeader14.Name = "columnHeader14";
            this.columnHeader14.Text = "密码";
            this.columnHeader14.Width.Absolute = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Name = "columnHeader23";
            this.columnHeader23.Text = "删除";
            this.columnHeader23.Width.Absolute = 50;
            // 
            // nodeConnector4
            // 
            this.nodeConnector4.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle4
            // 
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // buttonMutiAdd
            // 
            this.buttonMutiAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonMutiAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonMutiAdd.Location = new System.Drawing.Point(3, 4);
            this.buttonMutiAdd.Name = "buttonMutiAdd";
            this.buttonMutiAdd.Size = new System.Drawing.Size(150, 23);
            this.buttonMutiAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonMutiAdd.Symbol = "";
            this.buttonMutiAdd.TabIndex = 4;
            this.buttonMutiAdd.Text = "从平台批量获取...";
            this.buttonMutiAdd.Click += new System.EventHandler(this.buttonMutiAdd_Click);
            // 
            // advTreeCamera
            // 
            this.advTreeCamera.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeCamera.AllowDrop = true;
            this.advTreeCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advTreeCamera.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeCamera.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeCamera.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeCamera.Columns.Add(this.columnHeader17);
            this.advTreeCamera.Columns.Add(this.columnHeader19);
            this.advTreeCamera.Columns.Add(this.columnHeader18);
            this.advTreeCamera.Columns.Add(this.columnHeader20);
            this.advTreeCamera.Columns.Add(this.columnHeader21);
            this.advTreeCamera.Columns.Add(this.columnHeader22);
            this.advTreeCamera.Columns.Add(this.columnHeader15);
            this.advTreeCamera.DragDropEnabled = false;
            this.advTreeCamera.ExpandWidth = 0;
            this.advTreeCamera.Location = new System.Drawing.Point(3, 33);
            this.advTreeCamera.Name = "advTreeCamera";
            this.advTreeCamera.NodesConnector = this.nodeConnector3;
            this.advTreeCamera.NodeStyle = this.elementStyle3;
            this.advTreeCamera.PathSeparator = ";";
            this.advTreeCamera.Size = new System.Drawing.Size(979, 311);
            this.advTreeCamera.Styles.Add(this.elementStyle3);
            this.advTreeCamera.TabIndex = 2;
            this.advTreeCamera.Text = "advTree3";
            this.advTreeCamera.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTreeCamera_MarkupLinkClick);
            this.advTreeCamera.DataSourceChanged += new System.EventHandler(this.advTreeCamera_DataSourceChanged);
            // 
            // columnHeader17
            // 
            this.columnHeader17.DataFieldName = "ID";
            this.columnHeader17.Name = "columnHeader17";
            this.columnHeader17.Text = "相机ID";
            this.columnHeader17.Width.Absolute = 50;
            // 
            // columnHeader19
            // 
            this.columnHeader19.DataFieldName = "CameraID";
            this.columnHeader19.Name = "columnHeader19";
            this.columnHeader19.Text = "相机编号";
            this.columnHeader19.Width.Absolute = 250;
            // 
            // columnHeader18
            // 
            this.columnHeader18.DataFieldName = "CameraName";
            this.columnHeader18.Name = "columnHeader18";
            this.columnHeader18.Text = "相机名称";
            this.columnHeader18.Width.Absolute = 220;
            // 
            // columnHeader20
            // 
            this.columnHeader20.DataFieldName = "PosCoordX";
            this.columnHeader20.Name = "columnHeader20";
            this.columnHeader20.Text = "经度";
            this.columnHeader20.Width.Absolute = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.DataFieldName = "PosCoordY";
            this.columnHeader21.Name = "columnHeader21";
            this.columnHeader21.Text = "纬度";
            this.columnHeader21.Width.Absolute = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.DataFieldName = "VideoSupplierChannelID";
            this.columnHeader22.Name = "columnHeader22";
            this.columnHeader22.Text = "在对应平台上的编号";
            this.columnHeader22.Width.Absolute = 150;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Name = "columnHeader15";
            this.columnHeader15.Text = "删除";
            this.columnHeader15.Width.Absolute = 50;
            // 
            // nodeConnector3
            // 
            this.nodeConnector3.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle3
            // 
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // buttonAddCamera
            // 
            this.buttonAddCamera.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddCamera.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddCamera.Location = new System.Drawing.Point(159, 4);
            this.buttonAddCamera.Name = "buttonAddCamera";
            this.buttonAddCamera.Size = new System.Drawing.Size(106, 23);
            this.buttonAddCamera.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddCamera.Symbol = "";
            this.buttonAddCamera.TabIndex = 4;
            this.buttonAddCamera.Text = "手动添加...";
            this.buttonAddCamera.Click += new System.EventHandler(this.buttonAddCamera_Click);
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
            // FormSettingCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 623);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "FormSettingCamera";
            this.ShowStatusBar = true;
            this.Text = "平台及相机设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSetting_FormClosed);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeVideoSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTreeCamera;
        private DevComponents.AdvTree.NodeConnector nodeConnector3;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private DevComponents.DotNetBar.ButtonX buttonAddNetStore;
        private DevComponents.DotNetBar.ButtonX buttonAddCamera;
        private DevComponents.DotNetBar.ButtonX buttonMutiAdd;
        private DevComponents.AdvTree.AdvTree advTreeVideoSupplier;
        private DevComponents.AdvTree.ColumnHeader columnHeader9;
        private DevComponents.AdvTree.ColumnHeader columnHeader10;
        private DevComponents.AdvTree.ColumnHeader columnHeader11;
        private DevComponents.AdvTree.ColumnHeader columnHeader12;
        private DevComponents.AdvTree.ColumnHeader columnHeader13;
        private DevComponents.AdvTree.ColumnHeader columnHeader14;
        private DevComponents.AdvTree.ColumnHeader columnHeader16;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.AdvTree.NodeConnector nodeConnector4;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.AdvTree.ColumnHeader columnHeader17;
        private DevComponents.AdvTree.ColumnHeader columnHeader18;
        private DevComponents.AdvTree.ColumnHeader columnHeader19;
        private DevComponents.AdvTree.ColumnHeader columnHeader20;
        private DevComponents.AdvTree.ColumnHeader columnHeader21;
        private DevComponents.AdvTree.ColumnHeader columnHeader22;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.AdvTree.ColumnHeader columnHeader23;
        private DevComponents.AdvTree.ColumnHeader columnHeader15;
    }
}