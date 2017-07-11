namespace IVX.Live.MainForm.View
{
    partial class ucSingleDrawImageWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSingleDrawImageWnd));
            this.axChannelDrawing1 = new AxChannelDrawingLib.AxChannelDrawing();
            this.buttonClearAllGraphs = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.axChannelDrawing1)).BeginInit();
            this.SuspendLayout();
            // 
            // axChannelDrawing1
            // 
            this.axChannelDrawing1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axChannelDrawing1.Enabled = true;
            this.axChannelDrawing1.Location = new System.Drawing.Point(0, 0);
            this.axChannelDrawing1.Name = "axChannelDrawing1";
            this.axChannelDrawing1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axChannelDrawing1.OcxState")));
            this.axChannelDrawing1.Size = new System.Drawing.Size(502, 357);
            this.axChannelDrawing1.TabIndex = 13;
            // 
            // buttonClearAllGraphs
            // 
            this.buttonClearAllGraphs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClearAllGraphs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearAllGraphs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClearAllGraphs.Location = new System.Drawing.Point(469, 3);
            this.buttonClearAllGraphs.Name = "buttonClearAllGraphs";
            this.buttonClearAllGraphs.Size = new System.Drawing.Size(30, 23);
            this.buttonClearAllGraphs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonClearAllGraphs.TabIndex = 14;
            this.buttonClearAllGraphs.Text = "删除";
            this.buttonClearAllGraphs.Click += new System.EventHandler(this.buttonClearAllGraphs_Click);
            // 
            // ucSingleDrawImageWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonClearAllGraphs);
            this.Controls.Add(this.axChannelDrawing1);
            this.Name = "ucSingleDrawImageWnd";
            this.Size = new System.Drawing.Size(502, 357);
            this.Load += new System.EventHandler(this.ucSinglePlayWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axChannelDrawing1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxChannelDrawingLib.AxChannelDrawing axChannelDrawing1;
        private DevComponents.DotNetBar.ButtonX buttonClearAllGraphs;

    }
}
