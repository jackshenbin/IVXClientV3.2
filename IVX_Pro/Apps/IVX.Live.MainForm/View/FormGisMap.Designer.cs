namespace IVX.Live.MainForm.View
{
    partial class FormGisMap
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemFlash = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 76);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(984, 472);
            this.webBrowser1.TabIndex = 2;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItemFlash,
            this.labelItem1,
            this.textBoxItem1,
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(0, 43);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(984, 33);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "查找";
            this.labelItem1.Visible = false;
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.TextBoxWidth = 200;
            this.textBoxItem1.Visible = false;
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = global::IVX.Live.MainForm.Properties.Resources._305_Close_24x24_72;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            this.buttonItem1.Visible = false;
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItemFlash
            // 
            this.buttonItemFlash.Name = "buttonItemFlash";
            this.buttonItemFlash.Text = "刷新";
            this.buttonItemFlash.Click += new System.EventHandler(this.buttonItemFlash_Click);
            // 
            // FormGisMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 574);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FormGisMap";
            this.ShowStatusBar = true;
            this.Text = "地图";
            this.Load += new System.EventHandler(this.FormGisMap_Load);
            this.Shown += new System.EventHandler(this.FormGisMap_Shown);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.webBrowser1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItemFlash;

    }
}