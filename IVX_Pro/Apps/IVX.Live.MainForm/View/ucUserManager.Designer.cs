namespace IVX.Live.MainForm {
	partial class ucUserManager {
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.userDataList = new WinFormAppUtil.Controls.DataGridViewEx();
			this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Other = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bar1 = new DevComponents.DotNetBar.Bar();
			this.addBtn = new DevComponents.DotNetBar.ButtonItem();
			this.modBtn = new DevComponents.DotNetBar.ButtonItem();
			this.delBtn = new DevComponents.DotNetBar.ButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.userDataList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
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
            this.UserName,
            this.UserRole,
            this.Other});
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
			this.userDataList.Location = new System.Drawing.Point(0, 27);
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
			this.userDataList.RowTemplate.Height = 23;
			this.userDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.userDataList.Size = new System.Drawing.Size(897, 588);
			this.userDataList.TabIndex = 23;
			this.userDataList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataList_CellDoubleClick);
			// 
			// UserName
			// 
			this.UserName.HeaderText = "用户名";
			this.UserName.Name = "UserName";
			this.UserName.ReadOnly = true;
			this.UserName.Width = 200;
			// 
			// UserRole
			// 
			this.UserRole.HeaderText = "用户角色";
			this.UserRole.Name = "UserRole";
			this.UserRole.ReadOnly = true;
			this.UserRole.Width = 300;
			// 
			// Other
			// 
			this.Other.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Other.HeaderText = "用户信息备注";
			this.Other.Name = "Other";
			this.Other.ReadOnly = true;
			// 
			// bar1
			// 
			this.bar1.AntiAlias = true;
			this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.addBtn,
            this.modBtn,
            this.delBtn});
			this.bar1.Location = new System.Drawing.Point(0, 0);
			this.bar1.Name = "bar1";
			this.bar1.Size = new System.Drawing.Size(897, 27);
			this.bar1.Stretch = true;
			this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.bar1.TabIndex = 24;
			this.bar1.TabStop = false;
			this.bar1.Text = "bar1";
			// 
			// addBtn
			// 
			this.addBtn.Name = "addBtn";
			this.addBtn.Text = "   添加    ";
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// modBtn
			// 
			this.modBtn.Name = "modBtn";
			this.modBtn.Text = "  修改";
			this.modBtn.Click += new System.EventHandler(this.modBtn_Click);
			// 
			// delBtn
			// 
			this.delBtn.Name = "delBtn";
			this.delBtn.Text = "   删除  ";
			this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
			// 
			// ucUserManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.userDataList);
			this.Controls.Add(this.bar1);
			this.Name = "ucUserManager";
			this.Size = new System.Drawing.Size(897, 615);
			this.Load += new System.EventHandler(this.ucUserManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.userDataList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private WinFormAppUtil.Controls.DataGridViewEx userDataList;
		private DevComponents.DotNetBar.Bar bar1;
		private DevComponents.DotNetBar.ButtonItem delBtn;
		private DevComponents.DotNetBar.ButtonItem modBtn;
		private DevComponents.DotNetBar.ButtonItem addBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserRole;
		private System.Windows.Forms.DataGridViewTextBoxColumn Other;
	}
}
