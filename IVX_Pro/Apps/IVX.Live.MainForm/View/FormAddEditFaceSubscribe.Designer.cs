namespace IVX.Live.MainForm.View
{
    partial class FormAddEditFaceSubscribe
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.advTree1 = new WinFormAppUtil.Controls.TreeListEx();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.node3 = new DevComponents.AdvTree.Node();
            this.cell9 = new DevComponents.AdvTree.Cell();
            this.cell10 = new DevComponents.AdvTree.Cell();
            this.cell11 = new DevComponents.AdvTree.Cell();
            this.cell12 = new DevComponents.AdvTree.Cell();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.advTree1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
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
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.CellEdit = true;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.Columns.Add(this.columnHeader4);
            this.advTree1.Columns.Add(this.columnHeader5);
            this.advTree1.Columns.Add(this.columnHeader6);
            this.advTree1.Controls.Add(this.groupPanel2);
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.DragDropEnabled = false;
            this.advTree1.EndCellEditingOnLostFocus = false;
            this.advTree1.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.advTree1.ExpandWidth = 0;
            this.advTree1.Location = new System.Drawing.Point(1, 44);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node3});
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(831, 384);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 7;
            this.advTree1.Text = "advTree1";
            this.advTree1.BeforeCellEdit += new DevComponents.AdvTree.CellEditEventHandler(this.advTree1_BeforeCellEdit);
            this.advTree1.AfterCellEditComplete += new DevComponents.AdvTree.CellEditEventHandler(this.advTree1_AfterCellEditComplete);
            this.advTree1.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTree1_MarkupLinkClick);
            this.advTree1.DataSourceChanged += new System.EventHandler(this.advTree1_DataSourceChanged);
            this.advTree1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.advTree1_MouseClick);
            this.advTree1.MouseCaptureChanged += new System.EventHandler(this.advTree1_MouseCaptureChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "ID";
            this.columnHeader1.Editable = false;
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width.Absolute = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "CameraID";
            this.columnHeader2.Editable = false;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "关联相机";
            this.columnHeader2.Width.Absolute = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "BlackListLibs";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "订阅黑名单详情";
            this.columnHeader3.Width.Absolute = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Editable = false;
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "操作";
            this.columnHeader4.Width.Absolute = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Editable = false;
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "取消订阅";
            this.columnHeader5.Width.Absolute = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DataFieldName = "SubscribeInfos";
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "Column";
            this.columnHeader6.Visible = false;
            this.columnHeader6.Width.Absolute = 150;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flowLayoutPanel1);
            this.groupPanel2.Controls.Add(this.buttonX1);
            this.groupPanel2.Location = new System.Drawing.Point(209, 141);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(415, 225);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Visible = false;
            this.groupPanel2.VisibleChanged += new System.EventHandler(this.groupPanel2_VisibleChanged);
            this.groupPanel2.Leave += new System.EventHandler(this.groupPanel2_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 201);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(371, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(35, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "确认";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click_1);
            // 
            // node3
            // 
            this.node3.Cells.Add(this.cell9);
            this.node3.Cells.Add(this.cell10);
            this.node3.Cells.Add(this.cell11);
            this.node3.Cells.Add(this.cell12);
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Text = "node3";
            // 
            // cell9
            // 
            this.cell9.Name = "cell9";
            this.cell9.StyleMouseOver = null;
            // 
            // cell10
            // 
            this.cell10.Name = "cell10";
            this.cell10.StyleMouseOver = null;
            this.cell10.Tag = "BlackListLibs";
            this.cell10.TagString = "BlackListLibs";
            this.cell10.Text = "ttttt";
            // 
            // cell11
            // 
            this.cell11.Name = "cell11";
            this.cell11.StyleMouseOver = null;
            // 
            // cell12
            // 
            this.cell12.Name = "cell12";
            this.cell12.StyleMouseOver = null;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // FormAddEditFaceSubscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 455);
            this.Controls.Add(this.advTree1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditFaceSubscribe";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "人脸报警订阅管理";
            this.TitleText = "人脸报警订阅管理";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.advTree1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.advTree1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private WinFormAppUtil.Controls.TreeListEx advTree1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Cell cell9;
        private DevComponents.AdvTree.Cell cell10;
        private DevComponents.AdvTree.Cell cell11;
        private DevComponents.AdvTree.Cell cell12;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;


    }
}
