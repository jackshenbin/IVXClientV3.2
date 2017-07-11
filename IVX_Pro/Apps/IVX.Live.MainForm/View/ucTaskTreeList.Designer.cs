namespace IVX.Live.MainForm.View
{
    partial class ucTaskTreelist
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaskTreelist));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.advTreeUnSel = new DevComponents.AdvTree.AdvTree();
			this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
			this.node2 = new DevComponents.AdvTree.Node();
			this.node3 = new DevComponents.AdvTree.Node();
			this.node4 = new DevComponents.AdvTree.Node();
			this.node8 = new DevComponents.AdvTree.Node();
			this.node9 = new DevComponents.AdvTree.Node();
			this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
			this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
			this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
			((System.ComponentModel.ISupportInitialize)(this.advTreeUnSel)).BeginInit();
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
			this.imageList1.Images.SetKeyName(4, "Alerts.png");
			this.imageList1.Images.SetKeyName(5, "VideoSrcTree_15.png");
			// 
			// advTreeUnSel
			// 
			this.advTreeUnSel.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
			this.advTreeUnSel.AllowDrop = true;
			this.advTreeUnSel.BackColor = System.Drawing.SystemColors.Window;
			// 
			// 
			// 
			this.advTreeUnSel.BackgroundStyle.Class = "TreeBorderKey";
			this.advTreeUnSel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.advTreeUnSel.Columns.Add(this.columnHeader1);
			this.advTreeUnSel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.advTreeUnSel.DragDropNodeCopyEnabled = false;
			this.advTreeUnSel.DropAsChildOffset = 240000;
			this.advTreeUnSel.ImageList = this.imageList1;
			this.advTreeUnSel.Location = new System.Drawing.Point(0, 0);
			this.advTreeUnSel.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode;
			this.advTreeUnSel.Name = "advTreeUnSel";
			this.advTreeUnSel.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2,
            this.node3,
            this.node4,
            this.node8,
            this.node9});
			this.advTreeUnSel.NodesConnector = this.nodeConnector2;
			this.advTreeUnSel.NodeStyle = this.elementStyle1;
			this.advTreeUnSel.NodeStyleSelected = this.elementStyle2;
			this.advTreeUnSel.PathSeparator = ";";
			this.advTreeUnSel.Size = new System.Drawing.Size(241, 435);
			this.advTreeUnSel.Styles.Add(this.elementStyle1);
			this.advTreeUnSel.Styles.Add(this.elementStyle2);
			this.advTreeUnSel.TabIndex = 8;
			this.advTreeUnSel.Text = "advTree2";
			this.advTreeUnSel.AfterCheck += new DevComponents.AdvTree.AdvTreeCellEventHandler(this.advTree1_AfterCheck);
			this.advTreeUnSel.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTreeUnSel_NodeDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.MinimumWidth = 200;
			this.columnHeader1.Name = "columnHeader1";
			this.columnHeader1.Text = "待选列表";
			this.columnHeader1.Width.Absolute = 150;
			this.columnHeader1.Width.AutoSize = true;
			this.columnHeader1.Width.AutoSizeMinHeader = true;
			// 
			// node2
			// 
			this.node2.Expanded = true;
			this.node2.Name = "node2";
			this.node2.Text = "node2";
			this.node2.Visible = false;
			// 
			// node3
			// 
			this.node3.Expanded = true;
			this.node3.Name = "node3";
			this.node3.Text = "node3";
			// 
			// node4
			// 
			this.node4.Expanded = true;
			this.node4.Name = "node4";
			this.node4.Text = "node4";
			// 
			// node8
			// 
			this.node8.Expanded = true;
			this.node8.Name = "node8";
			this.node8.Text = "node8";
			// 
			// node9
			// 
			this.node9.Expanded = true;
			this.node9.Name = "node9";
			this.node9.Text = "node9";
			// 
			// nodeConnector2
			// 
			this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
			// 
			// elementStyle1
			// 
			this.elementStyle1.BackColorGradientAngle = 90;
			this.elementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle1.CornerDiameter = 4;
			this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.elementStyle1.Description = "Blue";
			this.elementStyle1.Name = "elementStyle1";
			this.elementStyle1.TextColor = System.Drawing.Color.Black;
			// 
			// elementStyle2
			// 
			this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
			this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
			this.elementStyle2.BackColorGradientAngle = 90;
			this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
			this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.elementStyle2.CornerDiameter = 4;
			this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.elementStyle2.Description = "Yellow";
			this.elementStyle2.Name = "elementStyle2";
			this.elementStyle2.TextColor = System.Drawing.Color.Black;
			// 
			// ucTaskTreelist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.advTreeUnSel);
			this.Name = "ucTaskTreelist";
			this.Size = new System.Drawing.Size(241, 435);
			((System.ComponentModel.ISupportInitialize)(this.advTreeUnSel)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.AdvTree.AdvTree advTreeUnSel;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
    }
}
