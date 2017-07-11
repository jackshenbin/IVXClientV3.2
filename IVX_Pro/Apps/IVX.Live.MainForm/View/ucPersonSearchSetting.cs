using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucPersonSearchSetting : ucSearchSettingBase
    {
        public ucPersonSearchSetting()
        {
            InitializeComponent();
			this.panelEx2.Controls.SetChildIndex(this.expandablePanel2, 1);
        }
        private void ucMoveObjSearchSetting_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            colorComboBoxUpBody.InitColor(DataModel.Constant.MoveObjectColorInfos.Select(item => new object[] { item.Type.Col, item.Name, item.Type.ID }).ToList());
            colorComboBoxUpBody.SelectedIndex = 0;
            colorComboBoxDownBody.InitColor(DataModel.Constant.MoveObjectColorInfos.Select(item => new object[] { item.Type.Col, item.Name, item.Type.ID }).ToList());
            colorComboBoxDownBody.SelectedIndex = 0;
            comboBoxBag.ValueMember = "Type";
            comboBoxBag.DisplayMember = "Name";
            comboBoxBag.DataSource = DataModel.Constant.BagTypeInfos;//.OrderBy(item=>item.Name).ToArray();
            comboBoxBag.SelectedIndex = 0;
            m_viewModel.ObjFilterType = DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_PASSAGER | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_TWOWHEEL;
        }

        public override void ClearSetting()
        {
            colorComboBoxUpBody.SelectedIndex = 0;
            colorComboBoxDownBody.SelectedIndex = 0;
            base.ClearSetting();
        }
        

        private void colorComboBoxUpBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.UpBodyColors = Convert.ToUInt32( colorComboBoxUpBody.SelectedColorValue);
        }

        private void colorComboBoxDownBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.DownBodyColors = Convert.ToUInt32(colorComboBoxDownBody.SelectedColorValue);

        }

        private void ucPersonSearchSetting_Reset(object sender, EventArgs e)
        {
            ClearSetting();
        }
        private void comboBoxBag_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.PeopleBagType = (DataModel.E_MOVE_OBJ_PEOPLE_BAG_TYPE)comboBoxBag.SelectedValue;

        }
    }
}
