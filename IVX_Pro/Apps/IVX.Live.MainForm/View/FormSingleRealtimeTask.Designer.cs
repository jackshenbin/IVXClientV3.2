namespace IVX.Live.MainForm.View
{
    partial class FormSingleRealtimeTask
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
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFilePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxTaskStatus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxTaskName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxTaskId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxTaskType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxAnlyse = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxPriority = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTransEvent = new DevComponents.DotNetBar.ButtonX();
            this.buttonReAnalyse = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxCameraID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(373, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.Location = new System.Drawing.Point(454, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "关闭";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxFilePath, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTaskStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTaskName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTaskId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTaskType, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAnlyse, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelX7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPriority, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX14, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelX12, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelX5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelX6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCameraID, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 335);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // textBoxFilePath
            // 
            // 
            // 
            // 
            this.textBoxFilePath.Border.Class = "TextBoxBorder";
            this.textBoxFilePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxFilePath, 3);
            this.textBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFilePath.Location = new System.Drawing.Point(83, 153);
            this.textBoxFilePath.Multiline = true;
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(532, 139);
            this.textBoxFilePath.TabIndex = 20;
            // 
            // textBoxTaskStatus
            // 
            // 
            // 
            // 
            this.textBoxTaskStatus.Border.Class = "TextBoxBorder";
            this.textBoxTaskStatus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxTaskStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTaskStatus.Location = new System.Drawing.Point(83, 123);
            this.textBoxTaskStatus.Name = "textBoxTaskStatus";
            this.textBoxTaskStatus.ReadOnly = true;
            this.textBoxTaskStatus.Size = new System.Drawing.Size(223, 21);
            this.textBoxTaskStatus.TabIndex = 19;
            // 
            // textBoxTaskName
            // 
            // 
            // 
            // 
            this.textBoxTaskName.Border.Class = "TextBoxBorder";
            this.textBoxTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxTaskName, 3);
            this.textBoxTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTaskName.Location = new System.Drawing.Point(83, 33);
            this.textBoxTaskName.Name = "textBoxTaskName";
            this.textBoxTaskName.Size = new System.Drawing.Size(532, 21);
            this.textBoxTaskName.TabIndex = 18;
            this.textBoxTaskName.TextChanged += new System.EventHandler(this.textBoxTaskName_TextChanged);
            // 
            // textBoxTaskId
            // 
            // 
            // 
            // 
            this.textBoxTaskId.Border.Class = "TextBoxBorder";
            this.textBoxTaskId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxTaskId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTaskId.Location = new System.Drawing.Point(83, 3);
            this.textBoxTaskId.Name = "textBoxTaskId";
            this.textBoxTaskId.ReadOnly = true;
            this.textBoxTaskId.Size = new System.Drawing.Size(223, 21);
            this.textBoxTaskId.TabIndex = 17;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(3, 33);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(74, 14);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "任务名称";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "任务编号";
            // 
            // textBoxTaskType
            // 
            // 
            // 
            // 
            this.textBoxTaskType.Border.Class = "TextBoxBorder";
            this.textBoxTaskType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxTaskType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTaskType.Location = new System.Drawing.Point(392, 63);
            this.textBoxTaskType.Name = "textBoxTaskType";
            this.textBoxTaskType.ReadOnly = true;
            this.textBoxTaskType.Size = new System.Drawing.Size(223, 21);
            this.textBoxTaskType.TabIndex = 1;
            // 
            // textBoxAnlyse
            // 
            // 
            // 
            // 
            this.textBoxAnlyse.Border.Class = "TextBoxBorder";
            this.textBoxAnlyse.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxAnlyse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAnlyse.Location = new System.Drawing.Point(392, 123);
            this.textBoxAnlyse.Name = "textBoxAnlyse";
            this.textBoxAnlyse.ReadOnly = true;
            this.textBoxAnlyse.Size = new System.Drawing.Size(223, 21);
            this.textBoxAnlyse.TabIndex = 25;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(3, 63);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(74, 14);
            this.labelX7.TabIndex = 4;
            this.labelX7.Text = "优先级";
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.DisplayMember = "Text";
            this.comboBoxPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPriority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.ItemHeight = 15;
            this.comboBoxPriority.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10});
            this.comboBoxPriority.Location = new System.Drawing.Point(83, 63);
            this.comboBoxPriority.MaxDropDownItems = 10;
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(223, 21);
            this.comboBoxPriority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxPriority.TabIndex = 28;
            this.comboBoxPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriority_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1 最高";
            this.comboItem1.Value = "1";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2";
            this.comboItem2.Value = "2";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "3";
            this.comboItem3.Value = "3";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "4";
            this.comboItem4.Value = "4";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "5";
            this.comboItem5.Value = "5";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "6";
            this.comboItem6.Value = "6";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "7";
            this.comboItem7.Value = "7";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "8";
            this.comboItem8.Value = "8";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "9";
            this.comboItem9.Value = "9";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "10 最低";
            this.comboItem10.Value = "10";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(3, 153);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(74, 14);
            this.labelX14.TabIndex = 14;
            this.labelX14.Text = "原始地址";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.buttonTransEvent);
            this.panel1.Controls.Add(this.buttonReAnalyse);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(83, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 34);
            this.panel1.TabIndex = 30;
            // 
            // buttonTransEvent
            // 
            this.buttonTransEvent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTransEvent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTransEvent.Location = new System.Drawing.Point(104, 8);
            this.buttonTransEvent.Name = "buttonTransEvent";
            this.buttonTransEvent.Size = new System.Drawing.Size(107, 23);
            this.buttonTransEvent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonTransEvent.TabIndex = 8;
            this.buttonTransEvent.Text = "查看转发参数...";
            this.buttonTransEvent.Click += new System.EventHandler(this.buttonTransEvent_Click);
            // 
            // buttonReAnalyse
            // 
            this.buttonReAnalyse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReAnalyse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReAnalyse.Location = new System.Drawing.Point(9, 8);
            this.buttonReAnalyse.Name = "buttonReAnalyse";
            this.buttonReAnalyse.Size = new System.Drawing.Size(89, 23);
            this.buttonReAnalyse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonReAnalyse.TabIndex = 6;
            this.buttonReAnalyse.Text = "重新分析";
            this.buttonReAnalyse.Click += new System.EventHandler(this.buttonReAnalyse_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(217, 8);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "重新导入";
            this.buttonX1.Visible = false;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(312, 63);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(74, 14);
            this.labelX12.TabIndex = 12;
            this.labelX12.Text = "任务类型";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(312, 123);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 14);
            this.labelX3.TabIndex = 21;
            this.labelX3.Text = "算法";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 123);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(74, 14);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "任务状态";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(3, 93);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(74, 14);
            this.labelX6.TabIndex = 3;
            this.labelX6.Text = "关联相机";
            // 
            // textBoxCameraID
            // 
            // 
            // 
            // 
            this.textBoxCameraID.Border.Class = "TextBoxBorder";
            this.textBoxCameraID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxCameraID, 3);
            this.textBoxCameraID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCameraID.Location = new System.Drawing.Point(83, 93);
            this.textBoxCameraID.Name = "textBoxCameraID";
            this.textBoxCameraID.ReadOnly = true;
            this.textBoxCameraID.Size = new System.Drawing.Size(532, 21);
            this.textBoxCameraID.TabIndex = 31;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // FormSingleRealtimeTask
            // 
            this.ClientSize = new System.Drawing.Size(620, 406);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "FormSingleRealtimeTask";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "任务查看";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSingleTask_FormClosing);
            this.Load += new System.EventHandler(this.FormSingleTask_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxFilePath;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxTaskStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxTaskName;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxTaskId;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxTaskType;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxAnlyse;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxPriority;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonReAnalyse;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxCameraID;
        private DevComponents.DotNetBar.ButtonX buttonTransEvent;
    }
}