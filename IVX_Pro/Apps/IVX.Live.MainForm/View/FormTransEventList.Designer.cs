namespace IVX.Live.MainForm.View
{
    partial class FormTransEventList
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
            this.advTreeTransEvent = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader7 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddEvent = new DevComponents.DotNetBar.ButtonX();
            this.columnHeader9 = new DevComponents.AdvTree.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeTransEvent)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advTreeTransEvent
            // 
            this.advTreeTransEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeTransEvent.AllowDrop = true;
            this.advTreeTransEvent.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeTransEvent.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeTransEvent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeTransEvent.Columns.Add(this.columnHeader1);
            this.advTreeTransEvent.Columns.Add(this.columnHeader8);
            this.advTreeTransEvent.Columns.Add(this.columnHeader6);
            this.advTreeTransEvent.Columns.Add(this.columnHeader2);
            this.advTreeTransEvent.Columns.Add(this.columnHeader3);
            this.advTreeTransEvent.Columns.Add(this.columnHeader4);
            this.advTreeTransEvent.Columns.Add(this.columnHeader7);
            this.advTreeTransEvent.Columns.Add(this.columnHeader9);
            this.advTreeTransEvent.Columns.Add(this.columnHeader5);
            this.advTreeTransEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeTransEvent.ExpandWidth = 0;
            this.advTreeTransEvent.HScrollBarVisible = false;
            this.advTreeTransEvent.Location = new System.Drawing.Point(1, 75);
            this.advTreeTransEvent.Name = "advTreeTransEvent";
            this.advTreeTransEvent.NodesConnector = this.nodeConnector1;
            this.advTreeTransEvent.NodeStyle = this.elementStyle1;
            this.advTreeTransEvent.PathSeparator = ";";
            this.advTreeTransEvent.Size = new System.Drawing.Size(744, 347);
            this.advTreeTransEvent.Styles.Add(this.elementStyle1);
            this.advTreeTransEvent.TabIndex = 0;
            this.advTreeTransEvent.Text = "advTree1";
            this.advTreeTransEvent.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTreeTransEvent_MarkupLinkClick);
            this.advTreeTransEvent.DataSourceChanged += new System.EventHandler(this.advTreeTransEvent_DataSourceChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "EventID";
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width.Absolute = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DataFieldName = "TaskID";
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.Text = "Task";
            this.columnHeader8.Visible = false;
            this.columnHeader8.Width.Absolute = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DataFieldName = "MergeStyle";
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "合图模板";
            this.columnHeader6.Visible = false;
            this.columnHeader6.Width.Absolute = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "ReceiveIp";
            this.columnHeader2.MinimumWidth = 150;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "转发地址";
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "ReceivePort";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "转发端口";
            this.columnHeader3.Width.Absolute = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DataFieldName = "ProtocolType";
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "转发协议类型";
            this.columnHeader4.Width.Absolute = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DataFieldName = "StoreStyle";
            this.columnHeader7.Name = "columnHeader7";
            this.columnHeader7.Text = "存储方式";
            this.columnHeader7.Width.Absolute = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "删除";
            this.columnHeader5.Width.Absolute = 50;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddEvent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 31);
            this.panel1.TabIndex = 6;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddEvent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddEvent.Location = new System.Drawing.Point(7, 3);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(75, 23);
            this.buttonAddEvent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddEvent.TabIndex = 6;
            this.buttonAddEvent.Text = "添加";
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // columnHeader9
            // 
            this.columnHeader9.DataFieldName = "AnalyseType";
            this.columnHeader9.Name = "columnHeader9";
            this.columnHeader9.Text = "算法类型";
            this.columnHeader9.Width.Absolute = 150;
            // 
            // FormTransEventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 449);
            this.Controls.Add(this.advTreeTransEvent);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FormTransEventList";
            this.ShowStatusBar = true;
            this.Text = "转发列表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportList_FormClosing);
            this.Load += new System.EventHandler(this.FormExportList_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.advTreeTransEvent, 0);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeTransEvent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTreeTransEvent;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonAddEvent;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private DevComponents.AdvTree.ColumnHeader columnHeader9;
    }
}