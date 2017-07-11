namespace IVX.Live.Base.OCX
{
    partial class BaseOCX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseOCX));
            this.axvodocx1 = new AxvodocxLib.Axvodocx();
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).BeginInit();
            this.SuspendLayout();
            // 
            // axvodocx1
            // 
            this.axvodocx1.Enabled = true;
            this.axvodocx1.Location = new System.Drawing.Point(3, 3);
            this.axvodocx1.Name = "axvodocx1";
            this.axvodocx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axvodocx1.OcxState")));
            this.axvodocx1.Size = new System.Drawing.Size(100, 50);
            this.axvodocx1.TabIndex = 0;
            this.axvodocx1.Visible = false;
            // 
            // BaseOCX
            // 
            this.Controls.Add(this.axvodocx1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "BaseOCX";
            this.Size = new System.Drawing.Size(114, 63);
            ((System.ComponentModel.ISupportInitialize)(this.axvodocx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxvodocxLib.Axvodocx axvodocx1;

    }
}
