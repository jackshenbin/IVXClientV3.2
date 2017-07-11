using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppUtil.Controls
{
    public partial class ColorComboBox : DevComponents.DotNetBar.Controls.ComboBoxEx
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedColorValue
        {
            get { return ((DevComponents.Editors.ComboItem)this.SelectedItem).Value; }
            set
            {
                foreach (DevComponents.Editors.ComboItem comboItem in Items)
                {
                    if (comboItem.Value == value)
                    { this.SelectedItem = comboItem; }
                }
            }
        }
        
        public ColorComboBox()
        {
            InitializeComponent();
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void InitColor(List<object[]> list)
        {
            foreach (var pair in list)
            {
                DevComponents.Editors.ComboItem comboItem = new DevComponents.Editors.ComboItem();
                comboItem.BackColor = (Color)pair[0];
                comboItem.ForeColor = Color.FromArgb(0xff - ((Color)pair[0]).R, 0xff - ((Color)pair[0]).G, 0xff - ((Color)pair[0]).B);
                comboItem.Text = pair[1].ToString();
                comboItem.Value = pair[2];
                Items.Add(comboItem);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            // 调用基类 OnPaint
            try
            {
                base.OnPaint(pe);
            }
            catch
            {
                this.Invalidate();
            }
        }

    }
}
