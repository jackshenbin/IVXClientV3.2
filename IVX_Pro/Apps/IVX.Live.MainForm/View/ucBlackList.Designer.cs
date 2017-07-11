namespace IVX.Live.MainForm.View
{
    partial class ucBlackList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.userDataList = new WinFormAppUtil.Controls.DataGridViewEx();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.picSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.delBtn = new DevComponents.DotNetBar.ButtonX();
			this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			((System.ComponentModel.ISupportInitialize)(this.userDataList)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// userDataList
			// 
			this.userDataList.AllowDrop = true;
			this.userDataList.AllowUserToAddRows = false;
			this.userDataList.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
			this.userDataList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.userDataList.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.userDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.userDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.userDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Name,
            this.picSum,
            this.bz});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.userDataList.DefaultCellStyle = dataGridViewCellStyle3;
			this.userDataList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userDataList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.userDataList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this.userDataList.Location = new System.Drawing.Point(0, 26);
			this.userDataList.Margin = new System.Windows.Forms.Padding(0);
			this.userDataList.Name = "userDataList";
			this.userDataList.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.userDataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.userDataList.RowHeadersVisible = false;
			this.userDataList.RowTemplate.Height = 23;
			this.userDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.userDataList.Size = new System.Drawing.Size(837, 565);
			this.userDataList.TabIndex = 24;
			this.userDataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataList_CellContentClick);
			this.userDataList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataList_CellDoubleClick);
			// 
			// No
			// 
			this.No.HeaderText = "编号";
			this.No.Name = "No";
			this.No.ReadOnly = true;
			// 
			// Name
			// 
			this.Name.HeaderText = "黑名单名称";
			this.Name.Name = "Name";
			this.Name.ReadOnly = true;
			// 
			// picSum
			// 
			this.picSum.HeaderText = "黑名单图片数量";
			this.picSum.Name = "picSum";
			this.picSum.ReadOnly = true;
			this.picSum.Width = 200;
			// 
			// bz
			// 
			this.bz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.bz.HeaderText = "备注";
			this.bz.Name = "bz";
			this.bz.ReadOnly = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.delBtn);
			this.panel1.Controls.Add(this.buttonX2);
			this.panel1.Controls.Add(this.buttonX1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(837, 26);
			this.panel1.TabIndex = 25;
			// 
			// delBtn
			// 
			this.delBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.delBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.delBtn.Dock = System.Windows.Forms.DockStyle.Left;
			this.delBtn.Location = new System.Drawing.Point(176, 0);
			this.delBtn.Name = "delBtn";
			this.delBtn.Size = new System.Drawing.Size(87, 26);
			this.delBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.delBtn.TabIndex = 2;
			this.delBtn.Text = "删除";
			this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
			// 
			// buttonX2
			// 
			this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX2.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonX2.Location = new System.Drawing.Point(89, 0);
			this.buttonX2.Name = "buttonX2";
			this.buttonX2.Size = new System.Drawing.Size(87, 26);
			this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX2.TabIndex = 1;
			this.buttonX2.Text = "管理";
			this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX1.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonX1.Location = new System.Drawing.Point(0, 0);
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size(89, 26);
			this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX1.TabIndex = 0;
			this.buttonX1.Text = "添加";
			this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
			// 
			// ucBlackList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.userDataList);
			this.Controls.Add(this.panel1);
			this.Size = new System.Drawing.Size(837, 591);
			this.Load += new System.EventHandler(this.ucBlackList_Load);
			((System.ComponentModel.ISupportInitialize)(this.userDataList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private WinFormAppUtil.Controls.DataGridViewEx userDataList;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn picSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
		private DevComponents.DotNetBar.ButtonX delBtn;
    }
}
