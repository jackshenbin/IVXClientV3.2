namespace WinFormAppUtil
{
    partial class FormLoadImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadImage));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucLocalFileSystem1 = new WinFormAppUtil.ucLocalFileSystem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBaseImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new AxChannelDrawingLib.AxChannelDrawing();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucLocalFileSystem1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(753, 416);
            this.splitContainerControl1.SplitterPosition = 281;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucLocalFileSystem1
            // 
            this.ucLocalFileSystem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLocalFileSystem1.FileFilter = "";
            this.ucLocalFileSystem1.Location = new System.Drawing.Point(0, 0);
            this.ucLocalFileSystem1.Name = "ucLocalFileSystem1";
            this.ucLocalFileSystem1.Size = new System.Drawing.Size(281, 416);
            this.ucLocalFileSystem1.TabIndex = 0;
            this.ucLocalFileSystem1.FilesDoubleClicked += new System.EventHandler(this.ucLocalFileSystem1_FilesDoubleClicked);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBaseImage);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 446);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(753, 36);
            this.panelControl1.TabIndex = 1;
            // 
            // btnBaseImage
            // 
            this.btnBaseImage.Location = new System.Drawing.Point(5, 7);
            this.btnBaseImage.Name = "btnBaseImage";
            this.btnBaseImage.Size = new System.Drawing.Size(75, 23);
            this.btnBaseImage.TabIndex = 0;
            this.btnBaseImage.Text = "恢复原图";
            this.btnBaseImage.Click += new System.EventHandler(this.btnBaseImage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(673, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(592, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnZoomOut);
            this.panelControl2.Controls.Add(this.btnZoomIn);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(753, 30);
            this.panelControl2.TabIndex = 2;
            this.panelControl2.Visible = false;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnZoomOut.Location = new System.Drawing.Point(723, 4);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(20, 20);
            this.btnZoomOut.TabIndex = 2;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnZoomIn.Location = new System.Drawing.Point(701, 4);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(20, 20);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Enabled = true;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pictureBox1.OcxState")));
            this.pictureBox1.Size = new System.Drawing.Size(467, 416);
            this.pictureBox1.TabIndex = 1;
            // 
            // FormLoadImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 482);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormLoadImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoadImage_FormClosing);
            this.Load += new System.EventHandler(this.FormLoadImage_Load);
            this.Shown += new System.EventHandler(this.FormLoadImage_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ucLocalFileSystem ucLocalFileSystem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBaseImage;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private AxChannelDrawingLib.AxChannelDrawing pictureBox1;
    }
}