namespace IVX.Live.Brief.OCX
{
    partial class BriefOCX
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BriefOCX));
            this.axbriefocx1 = new AxbriefocxLib.Axbriefocx();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.axbriefocx1)).BeginInit();
            this.SuspendLayout();
            // 
            // axbriefocx1
            // 
            this.axbriefocx1.Enabled = true;
            this.axbriefocx1.Location = new System.Drawing.Point(0, 0);
            this.axbriefocx1.Name = "axbriefocx1";
            this.axbriefocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axbriefocx1.OcxState")));
            this.axbriefocx1.Size = new System.Drawing.Size(100, 50);
            this.axbriefocx1.TabIndex = 1;
            this.axbriefocx1.Visible = false;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(467, 284);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.DimGray;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.LightGray;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // BriefOCX
            // 
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.axbriefocx1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "BriefOCX";
            this.Size = new System.Drawing.Size(467, 284);
            ((System.ComponentModel.ISupportInitialize)(this.axbriefocx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxbriefocxLib.Axbriefocx axbriefocx1;
        private DevComponents.DotNetBar.PanelEx panelEx1;

    }
}
