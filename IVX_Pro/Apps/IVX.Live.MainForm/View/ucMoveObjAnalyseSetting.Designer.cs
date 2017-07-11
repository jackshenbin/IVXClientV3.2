namespace IVX.Live.MainForm.View
{
    partial class ucMoveObjAnalyseSetting
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
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.spinEditNumJam = new DevComponents.Editors.IntegerInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.spinEditTimeJam = new DevComponents.Editors.IntegerInput();
            this.btnCheckJam = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxV_SnapImage = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxV_Track = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxV_PartFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxV_GlobalFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxV_StructualFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxNV_SnapImage = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxNV_Track = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxNV_PartFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxNV_GlobalFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxNV_StructualFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.expandablePanel3 = new DevComponents.DotNetBar.ExpandablePanel();
            this.panelEx1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumJam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTimeJam)).BeginInit();
            this.expandablePanel2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.expandablePanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(30, 36);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(101, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "绘制检测区域";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.expandablePanel1);
            this.panelEx1.Controls.Add(this.expandablePanel2);
            this.panelEx1.Controls.Add(this.expandablePanel3);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(344, 604);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 5;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.spinEditNumJam);
            this.expandablePanel1.Controls.Add(this.labelX1);
            this.expandablePanel1.Controls.Add(this.labelX13);
            this.expandablePanel1.Controls.Add(this.labelX2);
            this.expandablePanel1.Controls.Add(this.labelX12);
            this.expandablePanel1.Controls.Add(this.spinEditTimeJam);
            this.expandablePanel1.Controls.Add(this.btnCheckJam);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 293);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(344, 142);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 4;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "交通拥堵";
            // 
            // spinEditNumJam
            // 
            // 
            // 
            // 
            this.spinEditNumJam.BackgroundStyle.Class = "DateTimeInputBackground";
            this.spinEditNumJam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.spinEditNumJam.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.spinEditNumJam.Location = new System.Drawing.Point(154, 72);
            this.spinEditNumJam.Name = "spinEditNumJam";
            this.spinEditNumJam.ShowUpDown = true;
            this.spinEditNumJam.Size = new System.Drawing.Size(59, 21);
            this.spinEditNumJam.TabIndex = 2;
            this.spinEditNumJam.Value = 10;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(219, 75);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "辆车，";
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(205, 109);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(68, 18);
            this.labelX13.TabIndex = 2;
            this.labelX13.Text = "秒时报警。";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(30, 109);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(93, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "且持续时间超过";
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(30, 75);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(118, 18);
            this.labelX12.TabIndex = 2;
            this.labelX12.Text = "当前检测区域中超过";
            // 
            // spinEditTimeJam
            // 
            // 
            // 
            // 
            this.spinEditTimeJam.BackgroundStyle.Class = "DateTimeInputBackground";
            this.spinEditTimeJam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.spinEditTimeJam.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.spinEditTimeJam.Location = new System.Drawing.Point(129, 106);
            this.spinEditTimeJam.Name = "spinEditTimeJam";
            this.spinEditTimeJam.ShowUpDown = true;
            this.spinEditTimeJam.Size = new System.Drawing.Size(69, 21);
            this.spinEditTimeJam.TabIndex = 2;
            this.spinEditTimeJam.Value = 20;
            // 
            // btnCheckJam
            // 
            this.btnCheckJam.AutoSize = true;
            this.btnCheckJam.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.btnCheckJam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnCheckJam.Location = new System.Drawing.Point(30, 42);
            this.btnCheckJam.Name = "btnCheckJam";
            this.btnCheckJam.Size = new System.Drawing.Size(125, 18);
            this.btnCheckJam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCheckJam.TabIndex = 1;
            this.btnCheckJam.Text = "启用交通拥堵检测";
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel2.Controls.Add(this.groupPanel2);
            this.expandablePanel2.Controls.Add(this.groupPanel1);
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel2.HideControlsWhenCollapsed = true;
            this.expandablePanel2.Location = new System.Drawing.Point(0, 77);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(344, 216);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 3;
            this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = "检测类型";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.checkBoxV_SnapImage);
            this.groupPanel2.Controls.Add(this.checkBoxV_Track);
            this.groupPanel2.Controls.Add(this.checkBoxV_PartFeature);
            this.groupPanel2.Controls.Add(this.checkBoxV_GlobalFeature);
            this.groupPanel2.Controls.Add(this.checkBoxV_StructualFeature);
            this.groupPanel2.Location = new System.Drawing.Point(173, 36);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(153, 168);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "机动车";
            // 
            // checkBoxV_SnapImage
            // 
            this.checkBoxV_SnapImage.AutoSize = true;
            this.checkBoxV_SnapImage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxV_SnapImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxV_SnapImage.Checked = true;
            this.checkBoxV_SnapImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxV_SnapImage.CheckValue = "Y";
            this.checkBoxV_SnapImage.Location = new System.Drawing.Point(13, 119);
            this.checkBoxV_SnapImage.Name = "checkBoxV_SnapImage";
            this.checkBoxV_SnapImage.Size = new System.Drawing.Size(64, 18);
            this.checkBoxV_SnapImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxV_SnapImage.TabIndex = 1;
            this.checkBoxV_SnapImage.Text = "缩略图";
            // 
            // checkBoxV_Track
            // 
            this.checkBoxV_Track.AutoSize = true;
            this.checkBoxV_Track.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxV_Track.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxV_Track.Checked = true;
            this.checkBoxV_Track.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxV_Track.CheckValue = "Y";
            this.checkBoxV_Track.Location = new System.Drawing.Point(13, 90);
            this.checkBoxV_Track.Name = "checkBoxV_Track";
            this.checkBoxV_Track.Size = new System.Drawing.Size(51, 18);
            this.checkBoxV_Track.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxV_Track.TabIndex = 1;
            this.checkBoxV_Track.Text = "轨迹";
            // 
            // checkBoxV_PartFeature
            // 
            this.checkBoxV_PartFeature.AutoSize = true;
            this.checkBoxV_PartFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxV_PartFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxV_PartFeature.Checked = true;
            this.checkBoxV_PartFeature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxV_PartFeature.CheckValue = "Y";
            this.checkBoxV_PartFeature.Location = new System.Drawing.Point(13, 61);
            this.checkBoxV_PartFeature.Name = "checkBoxV_PartFeature";
            this.checkBoxV_PartFeature.Size = new System.Drawing.Size(125, 18);
            this.checkBoxV_PartFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxV_PartFeature.TabIndex = 1;
            this.checkBoxV_PartFeature.Text = "非结构化局部特征";
            // 
            // checkBoxV_GlobalFeature
            // 
            this.checkBoxV_GlobalFeature.AutoSize = true;
            this.checkBoxV_GlobalFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxV_GlobalFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxV_GlobalFeature.Checked = true;
            this.checkBoxV_GlobalFeature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxV_GlobalFeature.CheckValue = "Y";
            this.checkBoxV_GlobalFeature.Location = new System.Drawing.Point(13, 32);
            this.checkBoxV_GlobalFeature.Name = "checkBoxV_GlobalFeature";
            this.checkBoxV_GlobalFeature.Size = new System.Drawing.Size(125, 18);
            this.checkBoxV_GlobalFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxV_GlobalFeature.TabIndex = 1;
            this.checkBoxV_GlobalFeature.Text = "非结构化全局特征";
            // 
            // checkBoxV_StructualFeature
            // 
            this.checkBoxV_StructualFeature.AutoSize = true;
            this.checkBoxV_StructualFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxV_StructualFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxV_StructualFeature.Checked = true;
            this.checkBoxV_StructualFeature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxV_StructualFeature.CheckValue = "Y";
            this.checkBoxV_StructualFeature.Location = new System.Drawing.Point(13, 3);
            this.checkBoxV_StructualFeature.Name = "checkBoxV_StructualFeature";
            this.checkBoxV_StructualFeature.Size = new System.Drawing.Size(88, 18);
            this.checkBoxV_StructualFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxV_StructualFeature.TabIndex = 1;
            this.checkBoxV_StructualFeature.Text = "结构化特征";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.checkBoxNV_SnapImage);
            this.groupPanel1.Controls.Add(this.checkBoxNV_Track);
            this.groupPanel1.Controls.Add(this.checkBoxNV_PartFeature);
            this.groupPanel1.Controls.Add(this.checkBoxNV_GlobalFeature);
            this.groupPanel1.Controls.Add(this.checkBoxNV_StructualFeature);
            this.groupPanel1.Location = new System.Drawing.Point(14, 36);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(153, 168);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "非机动车";
            // 
            // checkBoxNV_SnapImage
            // 
            this.checkBoxNV_SnapImage.AutoSize = true;
            this.checkBoxNV_SnapImage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxNV_SnapImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxNV_SnapImage.Checked = true;
            this.checkBoxNV_SnapImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNV_SnapImage.CheckValue = "Y";
            this.checkBoxNV_SnapImage.Location = new System.Drawing.Point(13, 119);
            this.checkBoxNV_SnapImage.Name = "checkBoxNV_SnapImage";
            this.checkBoxNV_SnapImage.Size = new System.Drawing.Size(64, 18);
            this.checkBoxNV_SnapImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxNV_SnapImage.TabIndex = 1;
            this.checkBoxNV_SnapImage.Text = "缩略图";
            // 
            // checkBoxNV_Track
            // 
            this.checkBoxNV_Track.AutoSize = true;
            this.checkBoxNV_Track.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxNV_Track.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxNV_Track.Checked = true;
            this.checkBoxNV_Track.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNV_Track.CheckValue = "Y";
            this.checkBoxNV_Track.Location = new System.Drawing.Point(13, 90);
            this.checkBoxNV_Track.Name = "checkBoxNV_Track";
            this.checkBoxNV_Track.Size = new System.Drawing.Size(51, 18);
            this.checkBoxNV_Track.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxNV_Track.TabIndex = 1;
            this.checkBoxNV_Track.Text = "轨迹";
            // 
            // checkBoxNV_PartFeature
            // 
            this.checkBoxNV_PartFeature.AutoSize = true;
            this.checkBoxNV_PartFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxNV_PartFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxNV_PartFeature.Checked = true;
            this.checkBoxNV_PartFeature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNV_PartFeature.CheckValue = "Y";
            this.checkBoxNV_PartFeature.Location = new System.Drawing.Point(13, 61);
            this.checkBoxNV_PartFeature.Name = "checkBoxNV_PartFeature";
            this.checkBoxNV_PartFeature.Size = new System.Drawing.Size(125, 18);
            this.checkBoxNV_PartFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxNV_PartFeature.TabIndex = 1;
            this.checkBoxNV_PartFeature.Text = "非结构化局部特征";
            // 
            // checkBoxNV_GlobalFeature
            // 
            this.checkBoxNV_GlobalFeature.AutoSize = true;
            this.checkBoxNV_GlobalFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxNV_GlobalFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxNV_GlobalFeature.Checked = true;
            this.checkBoxNV_GlobalFeature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNV_GlobalFeature.CheckValue = "Y";
            this.checkBoxNV_GlobalFeature.Location = new System.Drawing.Point(13, 32);
            this.checkBoxNV_GlobalFeature.Name = "checkBoxNV_GlobalFeature";
            this.checkBoxNV_GlobalFeature.Size = new System.Drawing.Size(125, 18);
            this.checkBoxNV_GlobalFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxNV_GlobalFeature.TabIndex = 1;
            this.checkBoxNV_GlobalFeature.Text = "非结构化全局特征";
            // 
            // checkBoxNV_StructualFeature
            // 
            this.checkBoxNV_StructualFeature.AutoSize = true;
            this.checkBoxNV_StructualFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxNV_StructualFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxNV_StructualFeature.Checked = true;
            this.checkBoxNV_StructualFeature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNV_StructualFeature.CheckValue = "Y";
            this.checkBoxNV_StructualFeature.Location = new System.Drawing.Point(13, 3);
            this.checkBoxNV_StructualFeature.Name = "checkBoxNV_StructualFeature";
            this.checkBoxNV_StructualFeature.Size = new System.Drawing.Size(88, 18);
            this.checkBoxNV_StructualFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxNV_StructualFeature.TabIndex = 1;
            this.checkBoxNV_StructualFeature.Text = "结构化特征";
            // 
            // expandablePanel3
            // 
            this.expandablePanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel3.Controls.Add(this.buttonX1);
            this.expandablePanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel3.HideControlsWhenCollapsed = true;
            this.expandablePanel3.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel3.Name = "expandablePanel3";
            this.expandablePanel3.Size = new System.Drawing.Size(344, 77);
            this.expandablePanel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel3.Style.GradientAngle = 90;
            this.expandablePanel3.TabIndex = 0;
            this.expandablePanel3.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel3.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel3.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel3.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel3.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel3.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel3.TitleStyle.GradientAngle = 90;
            this.expandablePanel3.TitleText = "基础设置*";
            // 
            // ucMoveObjAnalyseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "ucMoveObjAnalyseSetting";
            this.Size = new System.Drawing.Size(344, 604);
            this.panelEx1.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumJam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTimeJam)).EndInit();
            this.expandablePanel2.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.expandablePanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel3;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxNV_StructualFeature;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.Editors.IntegerInput spinEditNumJam;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.Editors.IntegerInput spinEditTimeJam;
        private DevComponents.DotNetBar.Controls.CheckBoxX btnCheckJam;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxV_SnapImage;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxV_Track;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxV_PartFeature;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxV_GlobalFeature;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxV_StructualFeature;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxNV_SnapImage;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxNV_Track;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxNV_PartFeature;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxNV_GlobalFeature;
    }
}
