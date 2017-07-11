namespace IVX.Live.MainForm.View {
	partial class ucRebootSer {
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
			this.advTreeServer = new DevComponents.AdvTree.AdvTree();
			this.d1 = new DevComponents.AdvTree.ColumnHeader();
			this.d2 = new DevComponents.AdvTree.ColumnHeader();
			this.reBoot = new DevComponents.AdvTree.ColumnHeader();
			this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
			this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			((System.ComponentModel.ISupportInitialize)(this.advTreeServer)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// advTreeServer
			// 
			this.advTreeServer.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
			this.advTreeServer.AllowDrop = true;
			this.advTreeServer.BackColor = System.Drawing.SystemColors.Window;
			// 
			// 
			// 
			this.advTreeServer.BackgroundStyle.Class = "TreeBorderKey";
			this.advTreeServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.advTreeServer.Columns.Add(this.d1);
			this.advTreeServer.Columns.Add(this.d2);
			this.advTreeServer.Columns.Add(this.reBoot);
			this.advTreeServer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.advTreeServer.DragDropEnabled = false;
			this.advTreeServer.ExpandWidth = 0;
			this.advTreeServer.HScrollBarVisible = false;
			this.advTreeServer.Location = new System.Drawing.Point(0, 23);
			this.advTreeServer.Name = "advTreeServer";
			this.advTreeServer.NodesConnector = this.nodeConnector1;
			this.advTreeServer.NodeStyle = this.elementStyle1;
			this.advTreeServer.PathSeparator = ";";
			this.advTreeServer.Size = new System.Drawing.Size(726, 427);
			this.advTreeServer.Styles.Add(this.elementStyle1);
			this.advTreeServer.TabIndex = 1;
			this.advTreeServer.Text = " ";
			this.advTreeServer.MarkupLinkClick += new DevComponents.AdvTree.MarkupLinkClickEventHandler(this.advTreeServer_MarkupLinkClick);
			this.advTreeServer.Click += new System.EventHandler(this.advTreeServer_Click);
			// 
			// d1
			// 
			this.d1.DataFieldName = "ServerIP";
			this.d1.Name = "d1";
			this.d1.Text = "服务器IP地址";
			this.d1.Width.Absolute = 300;
			// 
			// d2
			// 
			this.d2.DataFieldName = "Status";
			this.d2.Name = "d2";
			this.d2.Text = "状态";
			this.d2.Width.Absolute = 150;
			// 
			// reBoot
			// 
			this.reBoot.Name = "reBoot";
			this.reBoot.Text = "重启";
			this.reBoot.Width.Absolute = 150;
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
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonX1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(726, 23);
			this.panel1.TabIndex = 0;
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX1.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonX1.Location = new System.Drawing.Point(0, 0);
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size(99, 23);
			this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX1.TabIndex = 0;
			this.buttonX1.Text = "重启全部";
			this.buttonX1.Click += new System.EventHandler(this.buttonItem1_Click);
			// 
			// ucRebootSer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.advTreeServer);
			this.Controls.Add(this.panel1);
			this.Name = "ucRebootSer";
			this.Size = new System.Drawing.Size(726, 450);
			this.Load += new System.EventHandler(this.ucRebootSer_Load);
			((System.ComponentModel.ISupportInitialize)(this.advTreeServer)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.AdvTree.AdvTree advTreeServer;
		private DevComponents.AdvTree.NodeConnector nodeConnector1;
		private DevComponents.DotNetBar.ElementStyle elementStyle1;
		private DevComponents.AdvTree.ColumnHeader d1;
		private DevComponents.AdvTree.ColumnHeader d2;
		private DevComponents.AdvTree.ColumnHeader reBoot;
		private System.Windows.Forms.Panel panel1;
		private DevComponents.DotNetBar.ButtonX buttonX1;
	}
}
