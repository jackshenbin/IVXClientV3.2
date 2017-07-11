namespace IVX.Live.MainForm.View
{
    partial class FormExportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportList));
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.Columns.Add(this.columnHeader4);
            this.advTree1.Columns.Add(this.columnHeader5);
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.DragDropEnabled = false;
            this.advTree1.ExpandWidth = 0;
            this.advTree1.HScrollBarVisible = false;
            this.advTree1.ImageList = this.imageList1;
            this.advTree1.Location = new System.Drawing.Point(0, 43);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(662, 303);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "VideoTaskUnitID";
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "任务编号";
            this.columnHeader1.Width.Absolute = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "LocalSaveFilePath";
            this.columnHeader2.MinimumWidth = 150;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.StretchToFill = true;
            this.columnHeader2.Text = "文件名";
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "ComposeProgress";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "导出进度";
            this.columnHeader3.Width.Absolute = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DataFieldName = "Status";
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "导出状态";
            this.columnHeader4.Width.Absolute = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "操作";
            this.columnHeader5.Width.Absolute = 60;
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
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "del";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormExportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 372);
            this.Controls.Add(this.advTree1);
            this.DoubleBuffered = true;
            this.Name = "FormExportList";
            this.ShowStatusBar = true;
            this.Text = "导出列表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportList_FormClosing);
            this.Load += new System.EventHandler(this.FormExportList_Load);
            this.Controls.SetChildIndex(this.advTree1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Timer timer1;
    }
}