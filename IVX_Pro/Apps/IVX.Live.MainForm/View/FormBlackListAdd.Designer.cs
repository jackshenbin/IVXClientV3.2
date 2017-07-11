namespace IVX.Live.MainForm.View {
	partial class FormBlackListAdd {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.code = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.otherInfo = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.AddBtn = new DevComponents.DotNetBar.ButtonX();
			this.calcelBtn = new DevComponents.DotNetBar.ButtonX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.name = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.errorLabel = new DevComponents.DotNetBar.LabelX();
			this.SuspendLayout();
			// 
			// labelX2
			// 
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.Location = new System.Drawing.Point(135, 100);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(38, 21);
			this.labelX2.TabIndex = 13;
			this.labelX2.Text = "名称:";
			// 
			// code
			// 
			// 
			// 
			// 
			this.code.Border.Class = "TextBoxBorder";
			this.code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.code.Location = new System.Drawing.Point(197, 154);
			this.code.Name = "code";
			this.code.Size = new System.Drawing.Size(149, 21);
			this.code.TabIndex = 12;
			this.code.Text = "黑名单1";
			// 
			// labelX3
			// 
			// 
			// 
			// 
			this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX3.Location = new System.Drawing.Point(135, 210);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(38, 21);
			this.labelX3.TabIndex = 13;
			this.labelX3.Text = "备注:";
			this.labelX3.Click += new System.EventHandler(this.labelX3_Click);
			// 
			// otherInfo
			// 
			// 
			// 
			// 
			this.otherInfo.Border.Class = "TextBoxBorder";
			this.otherInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.otherInfo.Location = new System.Drawing.Point(197, 210);
			this.otherInfo.Multiline = true;
			this.otherInfo.Name = "otherInfo";
			this.otherInfo.Size = new System.Drawing.Size(149, 42);
			this.otherInfo.TabIndex = 12;
			this.otherInfo.Text = "黑名单1";
			// 
			// AddBtn
			// 
			this.AddBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.AddBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.AddBtn.Location = new System.Drawing.Point(135, 312);
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(75, 23);
			this.AddBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.AddBtn.TabIndex = 14;
			this.AddBtn.Text = "确定";
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// calcelBtn
			// 
			this.calcelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.calcelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.calcelBtn.Location = new System.Drawing.Point(308, 312);
			this.calcelBtn.Name = "calcelBtn";
			this.calcelBtn.Size = new System.Drawing.Size(75, 23);
			this.calcelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.calcelBtn.TabIndex = 14;
			this.calcelBtn.Text = "取消";
			this.calcelBtn.Click += new System.EventHandler(this.calcelBtn_Click);
			// 
			// labelX4
			// 
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.Location = new System.Drawing.Point(135, 154);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(38, 21);
			this.labelX4.TabIndex = 13;
			this.labelX4.Text = "编号:";
			this.labelX4.Click += new System.EventHandler(this.labelX3_Click);
			// 
			// name
			// 
			// 
			// 
			// 
			this.name.Border.Class = "TextBoxBorder";
			this.name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.name.Location = new System.Drawing.Point(197, 100);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(149, 21);
			this.name.TabIndex = 12;
			this.name.Text = "黑名单1";
			// 
			// errorLabel
			// 
			// 
			// 
			// 
			this.errorLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.errorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(135, 272);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(276, 23);
			this.errorLabel.TabIndex = 15;
			// 
			// FormBlackListAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 427);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.calcelBtn);
			this.Controls.Add(this.AddBtn);
			this.Controls.Add(this.labelX4);
			this.Controls.Add(this.labelX3);
			this.Controls.Add(this.otherInfo);
			this.Controls.Add(this.labelX2);
			this.Controls.Add(this.name);
			this.Controls.Add(this.code);
			this.DoubleBuffered = true;
			this.Name = "FormBlackListAdd";
			this.ShowStatusBar = true;
			this.Text = "添加黑名单";
			this.Load += new System.EventHandler(this.FormBlackListAdd_Load);
			this.Controls.SetChildIndex(this.code, 0);
			this.Controls.SetChildIndex(this.name, 0);
			this.Controls.SetChildIndex(this.labelX2, 0);
			this.Controls.SetChildIndex(this.otherInfo, 0);
			this.Controls.SetChildIndex(this.labelX3, 0);
			this.Controls.SetChildIndex(this.labelX4, 0);
			this.Controls.SetChildIndex(this.AddBtn, 0);
			this.Controls.SetChildIndex(this.calcelBtn, 0);
			this.Controls.SetChildIndex(this.errorLabel, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.Controls.TextBoxX code;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.Controls.TextBoxX otherInfo;
		private DevComponents.DotNetBar.ButtonX AddBtn;
		private DevComponents.DotNetBar.ButtonX calcelBtn;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.Controls.TextBoxX name;
		private DevComponents.DotNetBar.LabelX errorLabel;
	}
}