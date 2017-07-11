namespace IVX.Live.MainForm.View
{
    partial class ucFtpFileSystem1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFtpFileSystem1));
            this.treeListFtpFile = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.cell1 = new DevComponents.AdvTree.Cell();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFtpFile)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListFtpFile
            // 
            this.treeListFtpFile.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeListFtpFile.AllowDrop = true;
            this.treeListFtpFile.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeListFtpFile.BackgroundStyle.Class = "TreeBorderKey";
            this.treeListFtpFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeListFtpFile.Columns.Add(this.columnHeader1);
            this.treeListFtpFile.Columns.Add(this.columnHeader2);
            this.treeListFtpFile.Columns.Add(this.columnHeader3);
            this.treeListFtpFile.Columns.Add(this.columnHeader4);
            this.treeListFtpFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFtpFile.ImageList = this.imageList1;
            this.treeListFtpFile.Location = new System.Drawing.Point(0, 0);
            this.treeListFtpFile.MultiSelect = true;
            this.treeListFtpFile.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode;
            this.treeListFtpFile.Name = "treeListFtpFile";
            this.treeListFtpFile.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.treeListFtpFile.NodesConnector = this.nodeConnector1;
            this.treeListFtpFile.NodeStyle = this.elementStyle1;
            this.treeListFtpFile.PathSeparator = ";";
            this.treeListFtpFile.Size = new System.Drawing.Size(256, 438);
            this.treeListFtpFile.Styles.Add(this.elementStyle1);
            this.treeListFtpFile.TabIndex = 0;
            this.treeListFtpFile.Text = "advTree1";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "Name";
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Ftp文件列表";
            this.columnHeader1.Width.Absolute = 150;
            this.columnHeader1.Width.AutoSize = true;
            this.columnHeader1.Width.AutoSizeMinHeader = true;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "FullName";
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Column";
            this.columnHeader2.Visible = false;
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "Type";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "Column";
            this.columnHeader3.Visible = false;
            this.columnHeader3.Width.Absolute = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DataFieldName = "FileSize";
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "Column";
            this.columnHeader4.Visible = false;
            this.columnHeader4.Width.Absolute = 150;
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
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.ImageIndex = 3;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.node1.Text = "node1";
            // 
            // node2
            // 
            this.node2.Cells.Add(this.cell1);
            this.node2.Expanded = true;
            this.node2.ImageIndex = 1;
            this.node2.Name = "node2";
            this.node2.Text = "node2";
            // 
            // cell1
            // 
            this.cell1.Name = "cell1";
            this.cell1.StyleMouseOver = null;
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
            // ucFtpFileSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListFtpFile);
            this.Name = "ucFtpFileSystem";
            this.Size = new System.Drawing.Size(256, 438);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFtpFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree treeListFtpFile;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Cell cell1;
    }
}
