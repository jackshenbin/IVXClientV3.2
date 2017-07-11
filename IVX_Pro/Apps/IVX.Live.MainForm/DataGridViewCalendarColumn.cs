using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm
{
    public partial class DataGridViewCalendarColumn : DataGridViewColumn
    {

        public DataGridViewCalendarColumn()
            : base(new DataGridViewCalendarCell())
        {
            
        }



        //获取或设置用于创建新单元格的模板。

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                //确保单元格式一个DataGridViewCalendarCell]

                //一个 DataGridViewCell，列中的所有其他单元格都以它为模型。默认值为新的 DataGridViewLinkCell 实例。
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCalendarCell)))
                {
                    throw new InvalidCastException("必须是一个日历单元格");
                }
                base.CellTemplate = value;
            }
        }





    }

    public class DataGridViewCalendarCell :DataGridViewImageCell // DataGridViewTextBoxCell
    {
        public DataGridViewCalendarCell()
            : base()
        {
            //this.Style.Format = "";
            KeyEntersEditMode(new KeyEventArgs(Keys.LButton));
        }

        //附加并初始化寄宿的编辑控件。

        //rowIndex 
        //类型：System..::.Int32

        //该单元格父行的索引。

        //initialFormattedValue 
        //类型：System..::.Object

        //要在控件中显示的初始值。

        //dataGridViewCellStyle 
        //类型：System.Windows.Forms..::.DataGridViewCellStyle

        //一个 DataGridViewCellStyle，确定寄宿控件的外观。

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        }



        //获取或设置单元格中值的数据类型。

        public override Type ValueType
        {
            get
            {
                return typeof(System.Drawing.Image);
            }
        }


        
        //获取单元格的寄宿编辑控件的类型。

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewCalendarEditingControl);
            }
        }



        //获取新记录所在行中单元格的默认值

        public override object DefaultNewRowValue
        {
            get
            {
                return Properties.Resources._305_Close_24x24_72;
            }
        }



    }
    // IDataGridViewEditingControl 接口
//定义承载在 DataGridView 的单元格内的控件的常见功能。 
    class DataGridViewCalendarEditingControl : ucAnalysePicker, IDataGridViewEditingControl
    {

        int rowIndex;//定义行索引
        DataGridView dataGridView;//定义datagridview
        private bool valueChanged = false;//定义单元格值是否变化

        public DataGridViewCalendarEditingControl()
        {

            
            
            //当前类继承DateTimePicker,具有DateTimePicker的功能，在构造函数中设置初始化日期格式
            //this.Format = DateTimePickerFormat.Short;
        }



        //实现 the IDataGridViewEditingControl.EditingControlFormattedValue属性

        //获取或设置编辑器正在修改的单元格的格式化值。 

        //格式化值以值在控件的用户界面上的显示形式表示该值。格式化值的绝对值甚至数据类型都可能与控件中包含的实际值不同。
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value;
            }
            set
            {
                string newValue = value as string;
                if (newValue != null)
                {
                    this.Value = ( DataModel.E_VIDEO_ANALYZE_TYPE) Convert.ToInt32(newValue);
                }
            }
        }

        #region IDataGridViewEditingControl 成员
        // 实现 the IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        // method,用于设置单元格样式
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }


        // Implements the IDataGridViewEditingControl.EditingControlDataGridView
        // property.//用于设置当前的datagridview

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }


        // 实现 the IDataGridViewEditingControl.EditingControlRowIndex
        // property.//设置处于编辑状态的datatridview控件的行索引

        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }


        // Implements the IDataGridViewEditingControl.EditingControlValueChanged
        // property.获取或设置控件值是否发生变化
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }


        // 实现 the IDataGridViewEditingControl.EditingControlWantsInputKey
        // method. 确定指定的键是应由编辑控件处理的常规输入键，还是应由 DataGridView 处理的特殊键。

        //DataGridView 控件调用此方法确定是要处理某个输入键还是让编辑控件处理它。

        //如果 keyData 包括 Up 或 Down 值，或者如果显示了下拉列表并且 keyData 包括 Escape 或 Enter 值，则此方法返回 true。

        //如果 //dataGridViewWantsInputKey 为 false，此方法也会返回 true。否则，此方法返回 false。

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return false;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingPanelCursor
        // property



        //编辑面板是在 DataGridView 控件处于编辑模式时用来承载编辑控件的 Panel。实际的编辑控件可能不会覆盖编辑面板的整个区域。

        //在////这种情况下，EditingPanelCursor 实现应返回当鼠标指针位于面板上方但不位于控件上方时使用的光标。通常，

        //您会希望返回与控件使用的光标相同的光标。如果希望更改当指针位于控件上方时显示的光标，必须设置 Cursor 属性。可以在

        //IDataGridViewEditingControl 实现的构造函数中设置此属性，也可以在 PrepareEditingControlForEdit 实现中设置。 
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        // 实现 the IDataGridViewEditingControl.GetEditingControlFormattedValue
        // method.//检索单元格的格式化值。

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }



        //准备当前选中的单元格以进行编辑。

        //

        //selectAll 
        //类型：System..::.Boolean

        //为 true，则选择单元格的全部内容；否则为 false。

        //

        //此方法的用途是准备控件及其内容以进行编辑。例如，您可能想要将插入点放在内容的末尾，或者更改内容的对齐方式。

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            //throw new NotImplementedException();
        }





        //实现 the IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        // property.

        //取得值，指出每當值變更時是否需要重新定位儲存格內容。

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }



        //当datatimepicker值变化时，通知datagridview

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView when the cell's contents was changed.

            valueChanged = true;

            //通知DATAGRIDVIEW有未提交的更改，

            // 如果要指示该单元格有未提交的更改，为 true；否则为 false。


            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }

        #endregion
    }
}
