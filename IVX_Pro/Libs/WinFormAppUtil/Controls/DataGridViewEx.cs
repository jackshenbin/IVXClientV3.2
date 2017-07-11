using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppUtil.Controls
{
    public partial class DataGridViewEx : DevComponents.DotNetBar.Controls.DataGridViewX
    {
        bool isShowIndex = true;
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("是否显示列序号")]
        public bool IsShowIndex
        {
            get
            {
                return isShowIndex;
            }
            set
            {
                isShowIndex = value;
            }
        }

        public DataGridViewEx()
        {
            InitializeComponent();

            this.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            //this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.BackgroundColor = System.Drawing.SystemColors.Control;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.Margin = new System.Windows.Forms.Padding(0);
            this.RowPostPaint += new DataGridViewRowPostPaintEventHandler(GridViewEx_RowPostPaint);
            RowHeadersDefaultCellStyle.Font = new Font(SystemFonts.CaptionFont, FontStyle.Bold);
            RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.RoyalBlue;

        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // TODO: 在此处添加自定义绘制代码

            // 调用基类 OnPaint
            try
            {
                base.OnPaint(e);
            }
            catch
            {
                this.Invalidate();
            }
        }
        void GridViewEx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (!IsShowIndex) return;
            DataGridViewEx costomerDataGridView = sender as DataGridViewEx;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                   e.RowBounds.Location.Y,
                                   costomerDataGridView.RowHeadersWidth - 4,
                                   e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                costomerDataGridView.RowHeadersDefaultCellStyle.Font,
                rectangle,
                costomerDataGridView.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
