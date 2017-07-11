namespace IVX.Live.MainForm.View
{
    partial class ucAllMoveObjSearchSetting
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
			this.SuspendLayout();
			// 
			// panelEx2
			// 
			this.panelEx2.Size = new System.Drawing.Size(290, 599);
			this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx2.Style.GradientAngle = 90;
			// 
			// ucAllMoveObjSearchSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.MinimumSize = new System.Drawing.Size(290, 2);
			this.Name = "ucAllMoveObjSearchSetting";
			this.SearchType = IVX.DataModel.SearchType.AllMoveObj;
			this.ShowCompareSearch = false;
			this.Size = new System.Drawing.Size(290, 634);
			this.Reset += new System.EventHandler(this.ucAllMoveObjSearchSetting_Reset);
			this.Load += new System.EventHandler(this.ucMoveObjSearchSetting_Load);
			this.ResumeLayout(false);

        }

        #endregion


    }
}
