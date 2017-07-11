namespace IVX.Live.MainForm.View
{
    partial class FormFaceAlarmControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonFaceControl = new DevComponents.DotNetBar.ButtonX();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader7 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonFaceControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 35);
            this.panel1.TabIndex = 41;
            // 
            // buttonFaceControl
            // 
            this.buttonFaceControl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonFaceControl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonFaceControl.Location = new System.Drawing.Point(11, 6);
            this.buttonFaceControl.Name = "buttonFaceControl";
            this.buttonFaceControl.Size = new System.Drawing.Size(75, 23);
            this.buttonFaceControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonFaceControl.TabIndex = 7;
            this.buttonFaceControl.Text = "添加...";
            this.buttonFaceControl.Click += new System.EventHandler(this.buttonFaceControl_Click);
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
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader4);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.Columns.Add(this.columnHeader6);
            this.advTree1.Columns.Add(this.columnHeader7);
            this.advTree1.Columns.Add(this.columnHeader8);
            this.advTree1.Columns.Add(this.columnHeader5);
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.DragDropEnabled = false;
            this.advTree1.DragDropNodeCopyEnabled = false;
            this.advTree1.ExpandWidth = 0;
            this.advTree1.Location = new System.Drawing.Point(1, 79);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(1004, 565);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 3;
            this.advTree1.Text = "advTree1";
            this.advTree1.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTree1_MarkupLinkClick);
            this.advTree1.DataSourceChanged += new System.EventHandler(this.advTree1_DataSourceChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "ID";
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "编号";
            this.columnHeader1.Width.Absolute = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "CameraID";
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "监控点";
            this.columnHeader2.Width.Absolute = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "ControlThreshold";
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "阈值";
            this.columnHeader3.Width.Absolute = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DataFieldName = "BlackListHandle";
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "黑名单";
            this.columnHeader4.Width.Absolute = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "删除";
            this.columnHeader5.Width.Absolute = 70;
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
            // columnHeader6
            // 
            this.columnHeader6.DataFieldName = "ControlNation";
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "布控民族";
            this.columnHeader6.Width.Absolute = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DataFieldName = "ControlSex";
            this.columnHeader7.Name = "columnHeader7";
            this.columnHeader7.Text = "布控性别";
            this.columnHeader7.Width.Absolute = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DataFieldName = "ControlAge";
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.Text = "布控年龄";
            this.columnHeader8.Width.Absolute = 100;
            // 
            // FormFaceAlarmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 671);
            this.Controls.Add(this.advTree1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FormFaceAlarmControl";
            this.ShowStatusBar = true;
            this.Text = "人脸布控报警管理";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.advTree1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonX buttonFaceControl;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;


    }
}
