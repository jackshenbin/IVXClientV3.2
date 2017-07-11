namespace IVX.Live.VOD.OCX
{
    partial class VODOCX
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
            System.Diagnostics.Trace.WriteLine("vodocx Dispose 1");
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            System.Diagnostics.Trace.WriteLine("vodocx Dispose 2");
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VODOCX));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.axvodocx1 = new AxvodocxLib.Axvodocx();
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).BeginInit();
            this.SuspendLayout();
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
            // axvodocx1
            // 
            this.axvodocx1.Enabled = true;
            this.axvodocx1.Location = new System.Drawing.Point(177, 223);
            this.axvodocx1.Name = "axvodocx1";
            this.axvodocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axvodocx1.OcxState")));
            this.axvodocx1.Size = new System.Drawing.Size(100, 50);
            this.axvodocx1.TabIndex = 0;
            this.axvodocx1.Visible = false;
            // 
            // VODOCX
            // 
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.axvodocx1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "VODOCX";
            this.Size = new System.Drawing.Size(467, 284);
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private AxvodocxLib.Axvodocx axvodocx1;

    }
}
