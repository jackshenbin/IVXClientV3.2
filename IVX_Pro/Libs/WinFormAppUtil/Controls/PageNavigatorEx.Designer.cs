namespace WinFormAppUtil.Controls
{
    partial class PageNavigatorEx
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
            this.buttonFirst = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonNext = new DevComponents.DotNetBar.ButtonX();
            this.buttonLast = new DevComponents.DotNetBar.ButtonX();
            this.buttonPriv = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFirst
            // 
            this.buttonFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonFirst.Image = global::WinFormAppUtil.Properties.Resources.DataContainer_MoveFirstHS;
            this.buttonFirst.Location = new System.Drawing.Point(14, 0);
            this.buttonFirst.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(25, 23);
            this.buttonFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonFirst.TabIndex = 0;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(64, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "1/5";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonNext
            // 
            this.buttonNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonNext.Image = global::WinFormAppUtil.Properties.Resources.DataContainer_MoveNextHS;
            this.buttonNext.Location = new System.Drawing.Point(144, 0);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(25, 23);
            this.buttonNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLast.Image = global::WinFormAppUtil.Properties.Resources.DataContainer_MoveLastHS;
            this.buttonLast.Location = new System.Drawing.Point(169, 0);
            this.buttonLast.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(25, 23);
            this.buttonLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonLast.TabIndex = 2;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonPriv
            // 
            this.buttonPriv.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPriv.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPriv.Image = global::WinFormAppUtil.Properties.Resources.DataContainer_MovePreviousHS;
            this.buttonPriv.Location = new System.Drawing.Point(39, 0);
            this.buttonPriv.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPriv.Name = "buttonPriv";
            this.buttonPriv.Size = new System.Drawing.Size(25, 23);
            this.buttonPriv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPriv.TabIndex = 1;
            this.buttonPriv.Click += new System.EventHandler(this.buttonPriv_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonFirst, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonLast, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonNext, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPriv, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(209, 25);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // PageNavigatorEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(0, 25);
            this.Name = "PageNavigatorEx";
            this.Size = new System.Drawing.Size(209, 25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonFirst;
        private DevComponents.DotNetBar.ButtonX buttonPriv;
        private DevComponents.DotNetBar.ButtonX buttonLast;
        private DevComponents.DotNetBar.ButtonX buttonNext;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
