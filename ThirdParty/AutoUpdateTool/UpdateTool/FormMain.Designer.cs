namespace UpdateTool
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.advTreeVersion = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewVersionFileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.integerInput4 = new DevComponents.Editors.IntegerInput();
            this.integerInput3 = new DevComponents.Editors.IntegerInput();
            this.integerInput2 = new DevComponents.Editors.IntegerInput();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonType1 = new System.Windows.Forms.RadioButton();
            this.radioButtonType3 = new System.Windows.Forms.RadioButton();
            this.radioButtonType2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDiscription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveVersionFileList = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLoadVersion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveVersion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddVersion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveVersion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendoutVersion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddVersionFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelVersionFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditPath = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeVersion)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTreeVersion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel2.Controls.Add(this.integerInput4);
            this.splitContainer1.Panel2.Controls.Add(this.integerInput3);
            this.splitContainer1.Panel2.Controls.Add(this.integerInput2);
            this.splitContainer1.Panel2.Controls.Add(this.integerInput1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxDiscription);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSaveVersionFileList);
            this.splitContainer1.Size = new System.Drawing.Size(803, 506);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 0;
            // 
            // advTreeVersion
            // 
            this.advTreeVersion.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeVersion.AllowDrop = true;
            this.advTreeVersion.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeVersion.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeVersion.ImageList = this.imageList1;
            this.advTreeVersion.Location = new System.Drawing.Point(0, 0);
            this.advTreeVersion.Name = "advTreeVersion";
            this.advTreeVersion.NodesConnector = this.nodeConnector1;
            this.advTreeVersion.NodeStyle = this.elementStyle1;
            this.advTreeVersion.PathSeparator = ";";
            this.advTreeVersion.Size = new System.Drawing.Size(217, 506);
            this.advTreeVersion.Styles.Add(this.elementStyle1);
            this.advTreeVersion.SuspendPaint = false;
            this.advTreeVersion.TabIndex = 0;
            this.advTreeVersion.Text = "advTree1";
            this.advTreeVersion.BeforeNodeSelect += new DevComponents.AdvTree.AdvTreeNodeCancelEventHandler(this.advTree1_BeforeNodeSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "5159.png");
            this.imageList1.Images.SetKeyName(1, "26792.png");
            this.imageList1.Images.SetKeyName(2, "27568.png");
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewVersionFileList);
            this.groupBox2.Location = new System.Drawing.Point(26, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 262);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件列表";
            // 
            // listViewVersionFileList
            // 
            this.listViewVersionFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.listViewVersionFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewVersionFileList.FullRowSelect = true;
            this.listViewVersionFileList.HideSelection = false;
            this.listViewVersionFileList.Location = new System.Drawing.Point(3, 17);
            this.listViewVersionFileList.Name = "listViewVersionFileList";
            this.listViewVersionFileList.Size = new System.Drawing.Size(538, 242);
            this.listViewVersionFileList.TabIndex = 4;
            this.listViewVersionFileList.UseCompatibleStateImageBehavior = false;
            this.listViewVersionFileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "类型";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MD5";
            this.columnHeader2.Width = 227;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.VersionContent_Changed);
            // 
            // integerInput4
            // 
            // 
            // 
            // 
            this.integerInput4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput4.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInput4.Enabled = false;
            this.integerInput4.Location = new System.Drawing.Point(200, 16);
            this.integerInput4.MaxValue = 999;
            this.integerInput4.MinValue = 0;
            this.integerInput4.Name = "integerInput4";
            this.integerInput4.Size = new System.Drawing.Size(29, 21);
            this.integerInput4.TabIndex = 21;
            // 
            // integerInput3
            // 
            // 
            // 
            // 
            this.integerInput3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput3.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInput3.Enabled = false;
            this.integerInput3.Location = new System.Drawing.Point(165, 16);
            this.integerInput3.MaxValue = 999;
            this.integerInput3.MinValue = 0;
            this.integerInput3.Name = "integerInput3";
            this.integerInput3.Size = new System.Drawing.Size(29, 21);
            this.integerInput3.TabIndex = 22;
            // 
            // integerInput2
            // 
            // 
            // 
            // 
            this.integerInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput2.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInput2.Enabled = false;
            this.integerInput2.Location = new System.Drawing.Point(130, 16);
            this.integerInput2.MaxValue = 999;
            this.integerInput2.MinValue = 0;
            this.integerInput2.Name = "integerInput2";
            this.integerInput2.Size = new System.Drawing.Size(29, 21);
            this.integerInput2.TabIndex = 19;
            // 
            // integerInput1
            // 
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInput1.Enabled = false;
            this.integerInput1.Location = new System.Drawing.Point(95, 16);
            this.integerInput1.MaxValue = 999;
            this.integerInput1.MinValue = 0;
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.Size = new System.Drawing.Size(29, 21);
            this.integerInput1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonType1);
            this.groupBox1.Controls.Add(this.radioButtonType3);
            this.groupBox1.Controls.Add(this.radioButtonType2);
            this.groupBox1.Location = new System.Drawing.Point(256, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型";
            // 
            // radioButtonType1
            // 
            this.radioButtonType1.AutoSize = true;
            this.radioButtonType1.Location = new System.Drawing.Point(6, 20);
            this.radioButtonType1.Name = "radioButtonType1";
            this.radioButtonType1.Size = new System.Drawing.Size(59, 16);
            this.radioButtonType1.TabIndex = 5;
            this.radioButtonType1.TabStop = true;
            this.radioButtonType1.Text = "安装版";
            this.radioButtonType1.UseVisualStyleBackColor = true;
            this.radioButtonType1.CheckedChanged += new System.EventHandler(this.VersionContent_Changed);
            // 
            // radioButtonType3
            // 
            this.radioButtonType3.AutoSize = true;
            this.radioButtonType3.Location = new System.Drawing.Point(136, 20);
            this.radioButtonType3.Name = "radioButtonType3";
            this.radioButtonType3.Size = new System.Drawing.Size(59, 16);
            this.radioButtonType3.TabIndex = 5;
            this.radioButtonType3.TabStop = true;
            this.radioButtonType3.Text = "更新包";
            this.radioButtonType3.UseVisualStyleBackColor = true;
            this.radioButtonType3.CheckedChanged += new System.EventHandler(this.VersionContent_Changed);
            // 
            // radioButtonType2
            // 
            this.radioButtonType2.AutoSize = true;
            this.radioButtonType2.Location = new System.Drawing.Point(71, 20);
            this.radioButtonType2.Name = "radioButtonType2";
            this.radioButtonType2.Size = new System.Drawing.Size(59, 16);
            this.radioButtonType2.TabIndex = 5;
            this.radioButtonType2.TabStop = true;
            this.radioButtonType2.Text = "完整包";
            this.radioButtonType2.UseVisualStyleBackColor = true;
            this.radioButtonType2.CheckedChanged += new System.EventHandler(this.VersionContent_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "发布时间";
            // 
            // textBoxDiscription
            // 
            this.textBoxDiscription.Location = new System.Drawing.Point(95, 76);
            this.textBoxDiscription.Multiline = true;
            this.textBoxDiscription.Name = "textBoxDiscription";
            this.textBoxDiscription.Size = new System.Drawing.Size(361, 94);
            this.textBoxDiscription.TabIndex = 2;
            this.textBoxDiscription.TextChanged += new System.EventHandler(this.VersionContent_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "描述";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "版本";
            // 
            // buttonSaveVersionFileList
            // 
            this.buttonSaveVersionFileList.Enabled = false;
            this.buttonSaveVersionFileList.Location = new System.Drawing.Point(448, 444);
            this.buttonSaveVersionFileList.Name = "buttonSaveVersionFileList";
            this.buttonSaveVersionFileList.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveVersionFileList.TabIndex = 0;
            this.buttonSaveVersionFileList.Text = "保存";
            this.buttonSaveVersionFileList.UseVisualStyleBackColor = true;
            this.buttonSaveVersionFileList.Click += new System.EventHandler(this.ButtonSaveVersionFileList_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadVersion,
            this.toolStripButtonSaveVersion,
            this.toolStripSeparator1,
            this.toolStripButtonAddVersion,
            this.toolStripButtonRemoveVersion,
            this.toolStripButtonSendoutVersion,
            this.toolStripSeparator2,
            this.toolStripButtonAddVersionFile,
            this.toolStripButtonDelVersionFile,
            this.toolStripButtonEditPath});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(803, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLoadVersion
            // 
            this.toolStripButtonLoadVersion.Image = global::UpdateTool.Properties.Resources._1941;
            this.toolStripButtonLoadVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadVersion.Name = "toolStripButtonLoadVersion";
            this.toolStripButtonLoadVersion.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonLoadVersion.Text = "重新加载";
            this.toolStripButtonLoadVersion.Click += new System.EventHandler(this.ButtonLoadVersion_Click);
            // 
            // toolStripButtonSaveVersion
            // 
            this.toolStripButtonSaveVersion.Image = global::UpdateTool.Properties.Resources._26792;
            this.toolStripButtonSaveVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveVersion.Name = "toolStripButtonSaveVersion";
            this.toolStripButtonSaveVersion.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSaveVersion.Text = "全部保存";
            this.toolStripButtonSaveVersion.Click += new System.EventHandler(this.ButtonSaveVersion_Click);
            // 
            // toolStripButtonAddVersion
            // 
            this.toolStripButtonAddVersion.Image = global::UpdateTool.Properties.Resources._26921;
            this.toolStripButtonAddVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddVersion.Name = "toolStripButtonAddVersion";
            this.toolStripButtonAddVersion.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonAddVersion.Text = "添加版本";
            this.toolStripButtonAddVersion.Click += new System.EventHandler(this.ButtonNewVersion_Click);
            // 
            // toolStripButtonRemoveVersion
            // 
            this.toolStripButtonRemoveVersion.Image = global::UpdateTool.Properties.Resources._27164;
            this.toolStripButtonRemoveVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveVersion.Name = "toolStripButtonRemoveVersion";
            this.toolStripButtonRemoveVersion.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonRemoveVersion.Text = "删除版本";
            this.toolStripButtonRemoveVersion.Click += new System.EventHandler(this.ButtonRemoveVersion_Click);
            // 
            // toolStripButtonSendoutVersion
            // 
            this.toolStripButtonSendoutVersion.Image = global::UpdateTool.Properties.Resources._27568;
            this.toolStripButtonSendoutVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendoutVersion.Name = "toolStripButtonSendoutVersion";
            this.toolStripButtonSendoutVersion.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSendoutVersion.Text = "发布版本";
            this.toolStripButtonSendoutVersion.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButtonAddVersionFile
            // 
            this.toolStripButtonAddVersionFile.Image = global::UpdateTool.Properties.Resources._4726;
            this.toolStripButtonAddVersionFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddVersionFile.Name = "toolStripButtonAddVersionFile";
            this.toolStripButtonAddVersionFile.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonAddVersionFile.Text = "添加文件";
            this.toolStripButtonAddVersionFile.Click += new System.EventHandler(this.ButtonAddVersionFile_Click);
            // 
            // toolStripButtonDelVersionFile
            // 
            this.toolStripButtonDelVersionFile.Image = global::UpdateTool.Properties.Resources._4824;
            this.toolStripButtonDelVersionFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelVersionFile.Name = "toolStripButtonDelVersionFile";
            this.toolStripButtonDelVersionFile.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonDelVersionFile.Text = "删除文件";
            this.toolStripButtonDelVersionFile.Click += new System.EventHandler(this.ButtonDelVersionFile_Click);
            // 
            // toolStripButtonEditPath
            // 
            this.toolStripButtonEditPath.Image = global::UpdateTool.Properties.Resources._5159;
            this.toolStripButtonEditPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditPath.Name = "toolStripButtonEditPath";
            this.toolStripButtonEditPath.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonEditPath.Text = "修改路径";
            this.toolStripButtonEditPath.Click += new System.EventHandler(this.toolStripButtonEditPath_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 531);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.Text = "版本发布工具";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeVersion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.integerInput4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.AdvTree.AdvTree advTreeVersion;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.RadioButton radioButtonType3;
        private System.Windows.Forms.RadioButton radioButtonType2;
        private System.Windows.Forms.RadioButton radioButtonType1;
        private System.Windows.Forms.ListView listViewVersionFileList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDiscription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveVersionFileList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddVersion;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveVersion;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendoutVersion;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.Editors.IntegerInput integerInput4;
        private DevComponents.Editors.IntegerInput integerInput3;
        private DevComponents.Editors.IntegerInput integerInput2;
        private DevComponents.Editors.IntegerInput integerInput1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadVersion;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddVersionFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelVersionFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditPath;
    }
}