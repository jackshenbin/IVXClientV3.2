namespace IVX.Live.MainForm.View {
	partial class ucFaceSearchResultPanel {
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
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
			this.labelRecordCountInfo = new DevComponents.DotNetBar.LabelX();
			this.pageNavigatorEx1 = new WinFormAppUtil.Controls.PageNavigatorEx();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ucSingleSearchResult1 = new IVX.Live.MainForm.View.ucSingleSearchResult();
			this.waitProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
			this.panelEx1.SuspendLayout();
			this.panelEx3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.waitProgress);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEx1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.panelEx1.Location = new System.Drawing.Point(0, 0);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(933, 615);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.Red;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 4;
			this.panelEx1.Visible = false;
			// 
			// panelEx3
			// 
			this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx3.Controls.Add(this.labelRecordCountInfo);
			this.panelEx3.Controls.Add(this.pageNavigatorEx1);
			this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelEx3.Location = new System.Drawing.Point(0, 615);
			this.panelEx3.Name = "panelEx3";
			this.panelEx3.Size = new System.Drawing.Size(933, 35);
			this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx3.Style.GradientAngle = 90;
			this.panelEx3.TabIndex = 5;
			// 
			// labelRecordCountInfo
			// 
			// 
			// 
			// 
			this.labelRecordCountInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelRecordCountInfo.Location = new System.Drawing.Point(198, 7);
			this.labelRecordCountInfo.Name = "labelRecordCountInfo";
			this.labelRecordCountInfo.Size = new System.Drawing.Size(193, 23);
			this.labelRecordCountInfo.TabIndex = 7;
			this.labelRecordCountInfo.Text = "总记录数 0 条，共 0 页";
			// 
			// pageNavigatorEx1
			// 
			this.pageNavigatorEx1.Index = 0;
			this.pageNavigatorEx1.Location = new System.Drawing.Point(3, 5);
			this.pageNavigatorEx1.MaxCount = 0;
			this.pageNavigatorEx1.MinimumSize = new System.Drawing.Size(0, 25);
			this.pageNavigatorEx1.Name = "pageNavigatorEx1";
			this.pageNavigatorEx1.Size = new System.Drawing.Size(189, 25);
			this.pageNavigatorEx1.TabIndex = 6;
			this.pageNavigatorEx1.FirstClick += new System.EventHandler(this.pageNavigatorEx1_FirstClick);
			this.pageNavigatorEx1.PrivClick += new System.EventHandler(this.pageNavigatorEx1_PrivClick);
			this.pageNavigatorEx1.NextClick += new System.EventHandler(this.pageNavigatorEx1_NextClick);
			this.pageNavigatorEx1.LastClick += new System.EventHandler(this.pageNavigatorEx1_LastClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
			this.tableLayoutPanel1.Controls.Add(this.ucSingleSearchResult1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 615);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// ucSingleSearchResult1
			// 
			this.ucSingleSearchResult1.BackColor = System.Drawing.Color.Transparent;
			this.ucSingleSearchResult1.Checked = true;
			this.ucSingleSearchResult1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSingleSearchResult1.Group = -1;
			this.ucSingleSearchResult1.Location = new System.Drawing.Point(3, 3);
			this.ucSingleSearchResult1.Name = "ucSingleSearchResult1";
			this.ucSingleSearchResult1.Record = null;
			this.ucSingleSearchResult1.Size = new System.Drawing.Size(180, 117);
			this.ucSingleSearchResult1.TabIndex = 3;
			// 
			// waitProgress
			// 
			this.waitProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
			// 
			// 
			// 
			this.waitProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.waitProgress.Location = new System.Drawing.Point(279, 204);
			this.waitProgress.Name = "waitProgress";
			this.waitProgress.Size = new System.Drawing.Size(375, 243);
			this.waitProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
			this.waitProgress.TabIndex = 6;
			// 
			// ucFaceSearchResultPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelEx1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panelEx3);
			this.Name = "ucFaceSearchResultPanel";
			this.Size = new System.Drawing.Size(933, 650);
			this.panelEx1.ResumeLayout(false);
			this.panelEx3.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.PanelEx panelEx1;
		private DevComponents.DotNetBar.PanelEx panelEx3;
		private DevComponents.DotNetBar.LabelX labelRecordCountInfo;
		private WinFormAppUtil.Controls.PageNavigatorEx pageNavigatorEx1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ucSingleSearchResult ucSingleSearchResult1;
		private DevComponents.DotNetBar.Controls.CircularProgress waitProgress;
	}
}
