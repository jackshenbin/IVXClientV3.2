namespace IVX.Live.MainForm.View
{
    partial class ucBehaviourEventAlarm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.advTreeBehaviourEvent = new DevComponents.AdvTree.AdvTree();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader14 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.flowLayoutPanelEvent = new System.Windows.Forms.FlowLayoutPanel();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.checkBoxItemEvent = new DevComponents.DotNetBar.CheckBoxItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.LabelItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.ucTaskFileSystem1 = new IVX.Live.MainForm.View.ucTaskTreeBase();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeBehaviourEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bar2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(247, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1307, 583);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advTreeBehaviourEvent);
            this.panel2.Controls.Add(this.flowLayoutPanelEvent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 552);
            this.panel2.TabIndex = 1;
            // 
            // advTreeBehaviourEvent
            // 
            this.advTreeBehaviourEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeBehaviourEvent.AllowDrop = true;
            this.advTreeBehaviourEvent.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeBehaviourEvent.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeBehaviourEvent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeBehaviourEvent.Columns.Add(this.columnHeader2);
            this.advTreeBehaviourEvent.Columns.Add(this.columnHeader3);
            this.advTreeBehaviourEvent.Columns.Add(this.columnHeader4);
            this.advTreeBehaviourEvent.Columns.Add(this.columnHeader14);
            this.advTreeBehaviourEvent.Columns.Add(this.columnHeader5);
            this.advTreeBehaviourEvent.Columns.Add(this.columnHeader1);
            this.advTreeBehaviourEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeBehaviourEvent.ExpandWidth = 0;
            this.advTreeBehaviourEvent.Location = new System.Drawing.Point(0, 0);
            this.advTreeBehaviourEvent.Name = "advTreeBehaviourEvent";
            this.advTreeBehaviourEvent.NodesConnector = this.nodeConnector1;
            this.advTreeBehaviourEvent.NodeStyle = this.elementStyle1;
            this.advTreeBehaviourEvent.PathSeparator = ";";
            this.advTreeBehaviourEvent.Size = new System.Drawing.Size(1307, 552);
            this.advTreeBehaviourEvent.Styles.Add(this.elementStyle1);
            this.advTreeBehaviourEvent.TabIndex = 11;
            this.advTreeBehaviourEvent.Text = "advTree1";
            this.advTreeBehaviourEvent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.advTreeTrafficEvent_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "EventType";
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "事件类型";
            this.columnHeader2.Width.Absolute = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "StartTime";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "开始时间";
            this.columnHeader3.Width.Absolute = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DataFieldName = "EndTime";
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "结束时间";
            this.columnHeader4.Width.Absolute = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.DataFieldName = "ObjId";
            this.columnHeader14.Name = "columnHeader14";
            this.columnHeader14.Text = "目标编号";
            this.columnHeader14.Width.Absolute = 130;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "CameraCode";
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "相机编号";
            this.columnHeader1.Width.Absolute = 130;
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
            // flowLayoutPanelEvent
            // 
            this.flowLayoutPanelEvent.AutoSize = true;
            this.flowLayoutPanelEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelEvent.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelEvent.Name = "flowLayoutPanelEvent";
            this.flowLayoutPanelEvent.Size = new System.Drawing.Size(1307, 0);
            this.flowLayoutPanelEvent.TabIndex = 7;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.checkBoxItemEvent,
            this.buttonItem2,
            this.buttonItem1});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1307, 31);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 12;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // checkBoxItemEvent
            // 
            this.checkBoxItemEvent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxItemEvent.Checked = true;
            this.checkBoxItemEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxItemEvent.Name = "checkBoxItemEvent";
            this.checkBoxItemEvent.Text = "行为事件报警";
            this.checkBoxItemEvent.Click += new System.EventHandler(this.checkBoxItemEvent_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.BeginGroup = true;
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Symbol = "";
            this.buttonItem2.Text = "清除数据";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.BeginGroup = true;
            this.buttonItem1.ForeColor = System.Drawing.Color.Blue;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "报警数据源：";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.ucTaskFileSystem1;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(241, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 583);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 13;
            this.expandableSplitter1.TabStop = false;
            // 
            // ucTaskFileSystem1
            // 
            this.ucTaskFileSystem1.AnalyseFilter = IVX.DataModel.E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM;
            this.ucTaskFileSystem1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucTaskFileSystem1.Location = new System.Drawing.Point(0, 0);
            this.ucTaskFileSystem1.Name = "ucTaskFileSystem1";
            this.ucTaskFileSystem1.Size = new System.Drawing.Size(241, 583);
            this.ucTaskFileSystem1.TabIndex = 15;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "目标类型";
            this.columnHeader5.Width.Absolute = 150;
            // 
            // ucBehaviourEventAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.ucTaskFileSystem1);
            this.DoubleBuffered = true;
            this.Name = "ucBehaviourEventAlarm";
            this.Size = new System.Drawing.Size(1554, 583);
            this.Load += new System.EventHandler(this.FormPlayHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeBehaviourEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem buttonItem1;
        private DevComponents.AdvTree.AdvTree advTreeBehaviourEvent;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader14;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private ucTaskTreeBase ucTaskFileSystem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEvent;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItemEvent;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
    }
}