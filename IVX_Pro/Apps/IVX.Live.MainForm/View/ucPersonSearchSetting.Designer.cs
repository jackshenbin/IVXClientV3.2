namespace IVX.Live.MainForm.View
{
    partial class ucPersonSearchSetting
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
			this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
			this.comboBoxBag = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.colorComboBoxDownBody = new WinFormAppUtil.Controls.ColorComboBox();
			this.colorComboBoxUpBody = new WinFormAppUtil.Controls.ColorComboBox();
			this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.checkBoxX4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.panelEx2.SuspendLayout();
			this.expandablePanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelEx2
			// 
			this.panelEx2.Controls.Add(this.expandablePanel2);
			this.panelEx2.Size = new System.Drawing.Size(290, 599);
			this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx2.Style.GradientAngle = 90;
			this.panelEx2.Controls.SetChildIndex(this.expandablePanel2, 1);
			// 
			// expandablePanel2
			// 
			this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.expandablePanel2.Controls.Add(this.comboBoxBag);
			this.expandablePanel2.Controls.Add(this.colorComboBoxDownBody);
			this.expandablePanel2.Controls.Add(this.colorComboBoxUpBody);
			this.expandablePanel2.Controls.Add(this.checkBoxX3);
			this.expandablePanel2.Controls.Add(this.labelX5);
			this.expandablePanel2.Controls.Add(this.checkBoxX4);
			this.expandablePanel2.Controls.Add(this.labelX2);
			this.expandablePanel2.Controls.Add(this.labelX4);
			this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.expandablePanel2.Expanded = false;
			this.expandablePanel2.ExpandedBounds = new System.Drawing.Rectangle(0, 363, 290, 123);
			this.expandablePanel2.Location = new System.Drawing.Point(0, 460);
			this.expandablePanel2.Name = "expandablePanel2";
			this.expandablePanel2.Size = new System.Drawing.Size(290, 26);
			this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel2.Style.GradientAngle = 90;
			this.expandablePanel2.TabIndex = 8;
			this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel2.TitleStyle.GradientAngle = 90;
			this.expandablePanel2.TitleText = "搜人选项";
			// 
			// comboBoxBag
			// 
			this.comboBoxBag.DisplayMember = "Text";
			this.comboBoxBag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBoxBag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxBag.FormattingEnabled = true;
			this.comboBoxBag.ItemHeight = 15;
			this.comboBoxBag.Location = new System.Drawing.Point(87, 86);
			this.comboBoxBag.Name = "comboBoxBag";
			this.comboBoxBag.Size = new System.Drawing.Size(121, 21);
			this.comboBoxBag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.comboBoxBag.TabIndex = 20;
			this.comboBoxBag.SelectedIndexChanged += new System.EventHandler(this.comboBoxBag_SelectedIndexChanged);
			// 
			// colorComboBoxDownBody
			// 
			this.colorComboBoxDownBody.DisplayMember = "Text";
			this.colorComboBoxDownBody.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.colorComboBoxDownBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.colorComboBoxDownBody.FormattingEnabled = true;
			this.colorComboBoxDownBody.ItemHeight = 15;
			this.colorComboBoxDownBody.Location = new System.Drawing.Point(87, 59);
			this.colorComboBoxDownBody.Name = "colorComboBoxDownBody";
			this.colorComboBoxDownBody.Size = new System.Drawing.Size(121, 21);
			this.colorComboBoxDownBody.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.colorComboBoxDownBody.TabIndex = 5;
			this.colorComboBoxDownBody.SelectedIndexChanged += new System.EventHandler(this.colorComboBoxDownBody_SelectedIndexChanged);
			// 
			// colorComboBoxUpBody
			// 
			this.colorComboBoxUpBody.DisplayMember = "Text";
			this.colorComboBoxUpBody.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.colorComboBoxUpBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.colorComboBoxUpBody.FormattingEnabled = true;
			this.colorComboBoxUpBody.ItemHeight = 15;
			this.colorComboBoxUpBody.Location = new System.Drawing.Point(87, 37);
			this.colorComboBoxUpBody.Name = "colorComboBoxUpBody";
			this.colorComboBoxUpBody.Size = new System.Drawing.Size(121, 21);
			this.colorComboBoxUpBody.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.colorComboBoxUpBody.TabIndex = 5;
			this.colorComboBoxUpBody.SelectedIndexChanged += new System.EventHandler(this.colorComboBoxUpBody_SelectedIndexChanged);
			// 
			// checkBoxX3
			// 
			this.checkBoxX3.AutoSize = true;
			this.checkBoxX3.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkBoxX3.Location = new System.Drawing.Point(267, 58);
			this.checkBoxX3.Name = "checkBoxX3";
			this.checkBoxX3.Size = new System.Drawing.Size(0, 0);
			this.checkBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.checkBoxX3.TabIndex = 4;
			// 
			// labelX5
			// 
			this.labelX5.AutoSize = true;
			this.labelX5.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX5.Location = new System.Drawing.Point(23, 86);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(56, 18);
			this.labelX5.TabIndex = 3;
			this.labelX5.Text = "背包特征";
			// 
			// checkBoxX4
			// 
			this.checkBoxX4.AutoSize = true;
			this.checkBoxX4.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkBoxX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkBoxX4.Location = new System.Drawing.Point(267, 29);
			this.checkBoxX4.Name = "checkBoxX4";
			this.checkBoxX4.Size = new System.Drawing.Size(0, 0);
			this.checkBoxX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.checkBoxX4.TabIndex = 4;
			// 
			// labelX2
			// 
			this.labelX2.AutoSize = true;
			this.labelX2.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.Location = new System.Drawing.Point(23, 59);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(56, 18);
			this.labelX2.TabIndex = 3;
			this.labelX2.Text = "下身颜色";
			// 
			// labelX4
			// 
			this.labelX4.AutoSize = true;
			this.labelX4.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.Location = new System.Drawing.Point(23, 37);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(56, 18);
			this.labelX4.TabIndex = 3;
			this.labelX4.Text = "上身颜色";
			// 
			// ucPersonSearchSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.MinimumSize = new System.Drawing.Size(290, 2);
			this.Name = "ucPersonSearchSetting";
			this.Size = new System.Drawing.Size(290, 634);
			this.Title = "搜人";
			this.Reset += new System.EventHandler(this.ucPersonSearchSetting_Reset);
			this.Load += new System.EventHandler(this.ucMoveObjSearchSetting_Load);
			this.panelEx2.ResumeLayout(false);
			this.expandablePanel2.ResumeLayout(false);
			this.expandablePanel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private WinFormAppUtil.Controls.ColorComboBox colorComboBoxDownBody;
        private WinFormAppUtil.Controls.ColorComboBox colorComboBoxUpBody;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxBag;

    }
}
