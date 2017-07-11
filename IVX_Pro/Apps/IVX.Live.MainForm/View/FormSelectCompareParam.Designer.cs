namespace IVX.Live.MainForm.View
{
    partial class FormSelectCompareParam
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
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxBreakRect = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxPassline = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxParticalRect = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxObjRect = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonSelectPic = new DevComponents.DotNetBar.ButtonX();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonReset = new DevComponents.DotNetBar.ButtonX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.ucSingleDrawImageWnd1 = new IVX.Live.MainForm.View.ucSingleDrawImageWnd();
            this.groupPanelObjectType = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxPerson = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxVehicle = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel3.SuspendLayout();
            this.groupPanelObjectType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "del";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.groupPanelObjectType);
            this.panel3.Controls.Add(this.checkBoxBreakRect);
            this.panel3.Controls.Add(this.checkBoxPassline);
            this.panel3.Controls.Add(this.checkBoxParticalRect);
            this.panel3.Controls.Add(this.checkBoxObjRect);
            this.panel3.Controls.Add(this.buttonSelectPic);
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Controls.Add(this.buttonReset);
            this.panel3.Controls.Add(this.buttonOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(789, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 650);
            this.panel3.TabIndex = 7;
            // 
            // checkBoxBreakRect
            // 
            // 
            // 
            // 
            this.checkBoxBreakRect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxBreakRect.Location = new System.Drawing.Point(7, 148);
            this.checkBoxBreakRect.Name = "checkBoxBreakRect";
            this.checkBoxBreakRect.Size = new System.Drawing.Size(87, 23);
            this.checkBoxBreakRect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxBreakRect.TabIndex = 6;
            this.checkBoxBreakRect.Text = "闯入闯出";
            this.checkBoxBreakRect.CheckedChanged += new System.EventHandler(this.checkBoxBreakRect_CheckedChanged);
            // 
            // checkBoxPassline
            // 
            // 
            // 
            // 
            this.checkBoxPassline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxPassline.Location = new System.Drawing.Point(7, 119);
            this.checkBoxPassline.Name = "checkBoxPassline";
            this.checkBoxPassline.Size = new System.Drawing.Size(87, 23);
            this.checkBoxPassline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxPassline.TabIndex = 6;
            this.checkBoxPassline.Text = "越界线";
            this.checkBoxPassline.CheckedChanged += new System.EventHandler(this.checkBoxPassline_CheckedChanged);
            // 
            // checkBoxParticalRect
            // 
            // 
            // 
            // 
            this.checkBoxParticalRect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxParticalRect.Location = new System.Drawing.Point(7, 90);
            this.checkBoxParticalRect.Name = "checkBoxParticalRect";
            this.checkBoxParticalRect.Size = new System.Drawing.Size(87, 23);
            this.checkBoxParticalRect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxParticalRect.TabIndex = 6;
            this.checkBoxParticalRect.Text = "局部检索框";
            this.checkBoxParticalRect.CheckedChanged += new System.EventHandler(this.checkBoxParticalRect_CheckedChanged);
            // 
            // checkBoxObjRect
            // 
            // 
            // 
            // 
            this.checkBoxObjRect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxObjRect.Location = new System.Drawing.Point(7, 61);
            this.checkBoxObjRect.Name = "checkBoxObjRect";
            this.checkBoxObjRect.Size = new System.Drawing.Size(87, 23);
            this.checkBoxObjRect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxObjRect.TabIndex = 6;
            this.checkBoxObjRect.Text = "目标框";
            this.checkBoxObjRect.CheckedChanged += new System.EventHandler(this.checkBoxObjRect_CheckedChanged);
            // 
            // buttonSelectPic
            // 
            this.buttonSelectPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSelectPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSelectPic.Location = new System.Drawing.Point(12, 10);
            this.buttonSelectPic.Name = "buttonSelectPic";
            this.buttonSelectPic.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSelectPic.TabIndex = 5;
            this.buttonSelectPic.Text = "选择图片";
            this.buttonSelectPic.Click += new System.EventHandler(this.buttonSelectPic_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.Location = new System.Drawing.Point(10, 609);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReset.Location = new System.Drawing.Point(12, 528);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "重置";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(10, 580);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ucSingleDrawImageWnd1
            // 
            this.ucSingleDrawImageWnd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleDrawImageWnd1.DrawImage = null;
            this.ucSingleDrawImageWnd1.Location = new System.Drawing.Point(0, 43);
            this.ucSingleDrawImageWnd1.Name = "ucSingleDrawImageWnd1";
            this.ucSingleDrawImageWnd1.Size = new System.Drawing.Size(789, 650);
            this.ucSingleDrawImageWnd1.TabIndex = 10;
            // 
            // groupPanelObjectType
            // 
            this.groupPanelObjectType.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelObjectType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelObjectType.Controls.Add(this.checkBoxVehicle);
            this.groupPanelObjectType.Controls.Add(this.checkBoxPerson);
            this.groupPanelObjectType.Location = new System.Drawing.Point(7, 223);
            this.groupPanelObjectType.Name = "groupPanelObjectType";
            this.groupPanelObjectType.Size = new System.Drawing.Size(87, 100);
            // 
            // 
            // 
            this.groupPanelObjectType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelObjectType.Style.BackColorGradientAngle = 90;
            this.groupPanelObjectType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelObjectType.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelObjectType.Style.BorderBottomWidth = 1;
            this.groupPanelObjectType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelObjectType.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelObjectType.Style.BorderLeftWidth = 1;
            this.groupPanelObjectType.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelObjectType.Style.BorderRightWidth = 1;
            this.groupPanelObjectType.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelObjectType.Style.BorderTopWidth = 1;
            this.groupPanelObjectType.Style.CornerDiameter = 4;
            this.groupPanelObjectType.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelObjectType.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelObjectType.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelObjectType.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelObjectType.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelObjectType.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelObjectType.TabIndex = 7;
            this.groupPanelObjectType.Text = "目标类型";
            // 
            // checkBoxPerson
            // 
            // 
            // 
            // 
            this.checkBoxPerson.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxPerson.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxPerson.Checked = true;
            this.checkBoxPerson.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPerson.CheckValue = "Y";
            this.checkBoxPerson.Location = new System.Drawing.Point(3, 12);
            this.checkBoxPerson.Name = "checkBoxPerson";
            this.checkBoxPerson.Size = new System.Drawing.Size(74, 23);
            this.checkBoxPerson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxPerson.TabIndex = 0;
            this.checkBoxPerson.Text = "行人";
            this.checkBoxPerson.CheckedChanged += new System.EventHandler(this.checkBoxPerson_CheckedChanged);
            // 
            // checkBoxVehicle
            // 
            // 
            // 
            // 
            this.checkBoxVehicle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxVehicle.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxVehicle.Location = new System.Drawing.Point(2, 41);
            this.checkBoxVehicle.Name = "checkBoxVehicle";
            this.checkBoxVehicle.Size = new System.Drawing.Size(74, 23);
            this.checkBoxVehicle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxVehicle.TabIndex = 0;
            this.checkBoxVehicle.Text = "机动车";
            this.checkBoxVehicle.CheckedChanged += new System.EventHandler(this.checkBoxVehicle_CheckedChanged);
            // 
            // FormSelectCompareParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 719);
            this.Controls.Add(this.ucSingleDrawImageWnd1);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Name = "FormSelectCompareParam";
            this.ShowStatusBar = true;
            this.Text = "比对设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExportList_FormClosing);
            this.Load += new System.EventHandler(this.FormExportList_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.ucSingleDrawImageWnd1, 0);
            this.panel3.ResumeLayout(false);
            this.groupPanelObjectType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.ButtonX buttonSelectPic;
        private DevComponents.DotNetBar.ButtonX buttonReset;
        private ucSingleDrawImageWnd ucSingleDrawImageWnd1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxBreakRect;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxPassline;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxParticalRect;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxObjRect;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelObjectType;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxVehicle;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxPerson;
    }
}