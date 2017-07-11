namespace IVX.Live.MainForm.View
{
    partial class FormAddEditCamera
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
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.simpleButton1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxCameraName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.doubleInputX = new DevComponents.Editors.DoubleInput();
            this.doubleInputY = new DevComponents.Editors.DoubleInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.textBoxChannel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelNmae = new DevComponents.DotNetBar.LabelX();
            this.textBoxCameraID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputY)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.ForeColor = System.Drawing.Color.Red;
            this.labelX4.Location = new System.Drawing.Point(45, 235);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(390, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(258, 265);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(86, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(74, 120);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "相机名称";
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
            // simpleButton1
            // 
            this.simpleButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.simpleButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.simpleButton1.Location = new System.Drawing.Point(96, 265);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 23);
            this.simpleButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(37, 91);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(93, 18);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "相机编号(唯一)";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(99, 149);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(31, 18);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "经度";
            // 
            // textBoxCameraName
            // 
            // 
            // 
            // 
            this.textBoxCameraName.Border.Class = "TextBoxBorder";
            this.textBoxCameraName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxCameraName.Location = new System.Drawing.Point(139, 117);
            this.textBoxCameraName.Name = "textBoxCameraName";
            this.textBoxCameraName.Size = new System.Drawing.Size(226, 21);
            this.textBoxCameraName.TabIndex = 2;
            this.textBoxCameraName.Text = "相机1";
            // 
            // doubleInputX
            // 
            // 
            // 
            // 
            this.doubleInputX.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputX.ButtonFreeText.Checked = true;
            this.doubleInputX.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInputX.DisplayFormat = "0.000000";
            this.doubleInputX.FreeTextEntryMode = true;
            this.doubleInputX.Increment = 1D;
            this.doubleInputX.Location = new System.Drawing.Point(139, 146);
            this.doubleInputX.MaxValue = 365D;
            this.doubleInputX.MinValue = 0D;
            this.doubleInputX.Name = "doubleInputX";
            this.doubleInputX.ShowUpDown = true;
            this.doubleInputX.Size = new System.Drawing.Size(152, 21);
            this.doubleInputX.TabIndex = 3;
            this.doubleInputX.Value = 121.316456D;
            this.doubleInputX.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right;
            this.doubleInputX.WatermarkText = "121.316456";
            // 
            // doubleInputY
            // 
            // 
            // 
            // 
            this.doubleInputY.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputY.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputY.ButtonFreeText.Checked = true;
            this.doubleInputY.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInputY.DisplayFormat = "0.000000";
            this.doubleInputY.FreeTextEntryMode = true;
            this.doubleInputY.Increment = 1D;
            this.doubleInputY.Location = new System.Drawing.Point(139, 175);
            this.doubleInputY.MaxValue = 365D;
            this.doubleInputY.MinValue = 0D;
            this.doubleInputY.Name = "doubleInputY";
            this.doubleInputY.ShowUpDown = true;
            this.doubleInputY.Size = new System.Drawing.Size(152, 21);
            this.doubleInputY.TabIndex = 4;
            this.doubleInputY.Value = 31.150456D;
            this.doubleInputY.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right;
            this.doubleInputY.WatermarkText = "31.150456";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(74, 62);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "所属平台";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(99, 178);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(31, 18);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "纬度";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(12, 207);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(118, 18);
            this.labelX8.TabIndex = 2;
            this.labelX8.Text = "在所属平台上的编号";
            // 
            // textBoxChannel
            // 
            // 
            // 
            // 
            this.textBoxChannel.Border.Class = "TextBoxBorder";
            this.textBoxChannel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxChannel.Location = new System.Drawing.Point(139, 204);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(226, 21);
            this.textBoxChannel.TabIndex = 5;
            // 
            // labelNmae
            // 
            // 
            // 
            // 
            this.labelNmae.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelNmae.BackgroundStyle.BorderBottomWidth = 1;
            this.labelNmae.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelNmae.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelNmae.BackgroundStyle.BorderLeftWidth = 1;
            this.labelNmae.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelNmae.BackgroundStyle.BorderRightWidth = 1;
            this.labelNmae.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelNmae.BackgroundStyle.BorderTopWidth = 1;
            this.labelNmae.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNmae.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNmae.Location = new System.Drawing.Point(139, 57);
            this.labelNmae.Name = "labelNmae";
            this.labelNmae.Size = new System.Drawing.Size(280, 23);
            this.labelNmae.TabIndex = 0;
            // 
            // textBoxCameraID
            // 
            // 
            // 
            // 
            this.textBoxCameraID.Border.Class = "TextBoxBorder";
            this.textBoxCameraID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxCameraID.Location = new System.Drawing.Point(139, 88);
            this.textBoxCameraID.Name = "textBoxCameraID";
            this.textBoxCameraID.Size = new System.Drawing.Size(226, 21);
            this.textBoxCameraID.TabIndex = 1;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(372, 86);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(18, 23);
            this.labelX9.TabIndex = 8;
            this.labelX9.Text = "*";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(372, 204);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(18, 23);
            this.labelX10.TabIndex = 8;
            this.labelX10.Text = "*";
            // 
            // FormAddEditCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 332);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelNmae);
            this.Controls.Add(this.doubleInputY);
            this.Controls.Add(this.doubleInputX);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.textBoxChannel);
            this.Controls.Add(this.textBoxCameraID);
            this.Controls.Add(this.textBoxCameraName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.simpleButton1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditCamera";
            this.ShowInTaskbar = false;
            this.ShowStatusBar = true;
            this.Text = "添加相机";
            this.TitleText = "添加相机";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.labelX7, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.labelX8, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.textBoxCameraName, 0);
            this.Controls.SetChildIndex(this.textBoxCameraID, 0);
            this.Controls.SetChildIndex(this.textBoxChannel, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.doubleInputX, 0);
            this.Controls.SetChildIndex(this.doubleInputY, 0);
            this.Controls.SetChildIndex(this.labelNmae, 0);
            this.Controls.SetChildIndex(this.labelX9, 0);
            this.Controls.SetChildIndex(this.labelX10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX simpleButton1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxCameraName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DoubleInput doubleInputX;
        private DevComponents.Editors.DoubleInput doubleInputY;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxChannel;
        private DevComponents.DotNetBar.LabelX labelNmae;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxCameraID;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;


    }
}
