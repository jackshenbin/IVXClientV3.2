namespace IVX.Live.MainForm.View
{
    partial class ucUploadWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUploadWnd));
            this.axfileupload1 = new AxfileuploadLib.Axfileupload();
            ((System.ComponentModel.ISupportInitialize)(this.axfileupload1)).BeginInit();
            this.SuspendLayout();
            // 
            // axfileupload1
            // 
            this.axfileupload1.Enabled = true;
            this.axfileupload1.Location = new System.Drawing.Point(3, 3);
            this.axfileupload1.Name = "axfileupload1";
            this.axfileupload1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfileupload1.OcxState")));
            this.axfileupload1.Size = new System.Drawing.Size(38, 16);
            this.axfileupload1.TabIndex = 2;
            this.axfileupload1.Visible = false;
            // 
            // ucUploadWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axfileupload1);
            this.Name = "ucUploadWnd";
            this.Size = new System.Drawing.Size(50, 24);
            ((System.ComponentModel.ISupportInitialize)(this.axfileupload1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxfileuploadLib.Axfileupload axfileupload1;
    }
}
