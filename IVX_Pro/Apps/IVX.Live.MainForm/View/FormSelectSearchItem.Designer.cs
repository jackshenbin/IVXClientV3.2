namespace IVX.Live.MainForm.View
{
    partial class FormSelectSearchItem
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
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.advTreeSel = new DevComponents.AdvTree.AdvTree();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node7 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.advTreeUnSel = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node8 = new DevComponents.AdvTree.Node();
            this.node9 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.buttonAdd = new DevComponents.DotNetBar.ButtonX();
            this.buttonRemove = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonClear = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.labelSelectedCount = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeUnSel)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "del";
            // 
            // advTreeSel
            // 
            this.advTreeSel.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeSel.AllowDrop = true;
            this.advTreeSel.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeSel.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeSel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeSel.Columns.Add(this.columnHeader2);
            this.advTreeSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeSel.DragDropNodeCopyEnabled = false;
            this.advTreeSel.DropAsChildOffset = 240000;
            this.advTreeSel.Location = new System.Drawing.Point(578, 3);
            this.advTreeSel.MultiSelect = true;
            this.advTreeSel.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode;
            this.advTreeSel.Name = "advTreeSel";
            this.advTreeSel.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node5,
            this.node6,
            this.node7});
            this.advTreeSel.NodesConnector = this.nodeConnector1;
            this.advTreeSel.NodeStyle = this.elementStyle1;
            this.advTreeSel.PathSeparator = ";";
            this.advTreeSel.Size = new System.Drawing.Size(529, 626);
            this.advTreeSel.Styles.Add(this.elementStyle1);
            this.advTreeSel.TabIndex = 6;
            this.advTreeSel.Text = "advTree1";
            this.advTreeSel.AfterNodeDrop += new DevComponents.AdvTree.TreeDragDropEventHandler(this.advTreeSel_AfterNodeDrop);
            this.advTreeSel.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTreeSel_NodeDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.MinimumWidth = 200;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "已选列表";
            this.columnHeader2.Width.Absolute = 150;
            this.columnHeader2.Width.AutoSize = true;
            this.columnHeader2.Width.AutoSizeMinHeader = true;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            this.node1.Visible = false;
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Text = "node5";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Name = "node6";
            this.node6.Text = "node6";
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Name = "node7";
            this.node7.Text = "node7";
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
            this.advTreeUnSel.Location = new System.Drawing.Point(3, 3);
            this.advTreeUnSel.MultiSelect = true;
            this.advTreeUnSel.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode;
            this.advTreeUnSel.Name = "advTreeUnSel";
            this.advTreeUnSel.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2,
            this.node3,
            this.node4,
            this.node8,
            this.node9});
            this.advTreeUnSel.NodesConnector = this.nodeConnector2;
            this.advTreeUnSel.NodeStyle = this.elementStyle2;
            this.advTreeUnSel.PathSeparator = ";";
            this.advTreeUnSel.Size = new System.Drawing.Size(529, 626);
            this.advTreeUnSel.Styles.Add(this.elementStyle2);
            this.advTreeUnSel.TabIndex = 7;
            this.advTreeUnSel.Text = "advTree2";
            this.advTreeUnSel.AfterNodeDrop += new DevComponents.AdvTree.TreeDragDropEventHandler(this.advTreeUnSel_AfterNodeDrop);
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
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // buttonAdd
            // 
            this.buttonAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAdd.Location = new System.Drawing.Point(5, 49);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(24, 23);
            this.buttonAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = ">>";
            this.buttonAdd.Tooltip = "添加选择";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRemove.Location = new System.Drawing.Point(5, 90);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(24, 23);
            this.buttonRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "<<";
            this.buttonRemove.Tooltip = "取消选择";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.buttonClear);
            this.panel3.Controls.Add(this.buttonRemove);
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(538, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(34, 626);
            this.panel3.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClear.Location = new System.Drawing.Point(5, 133);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(24, 23);
            this.buttonClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "C";
            this.buttonClear.Tooltip = "清空选择";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.advTreeSel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.advTreeUnSel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 672);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSelectedCount);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(578, 635);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 34);
            this.panel1.TabIndex = 8;
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.Location = new System.Drawing.Point(444, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(363, 6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelSelectedCount
            // 
            this.labelSelectedCount.AutoSize = true;
            // 
            // 
            // 
            this.labelSelectedCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSelectedCount.Location = new System.Drawing.Point(3, 9);
            this.labelSelectedCount.Name = "labelSelectedCount";
            this.labelSelectedCount.Size = new System.Drawing.Size(50, 16);
            this.labelSelectedCount.TabIndex = 1;
            // 
            // FormSelectSearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "FormSelectSearchItem";
            this.ShowStatusBar = true;
            this.Text = "选择检索范围";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportList_FormClosing);
            this.Load += new System.EventHandler(this.FormExportList_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeUnSel)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.AdvTree.AdvTree advTreeSel;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.AdvTree advTreeUnSel;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ButtonX buttonAdd;
        private DevComponents.DotNetBar.ButtonX buttonRemove;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.DotNetBar.ButtonX buttonClear;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.LabelX labelSelectedCount;
    }
}