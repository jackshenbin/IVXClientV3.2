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
    public partial class ucAllMoveObjSearchSetting : ucSearchSettingBase
    {
        public ucAllMoveObjSearchSetting()
        {
            InitializeComponent();
        }
        private void ucMoveObjSearchSetting_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel.ObjFilterType = DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_PASSAGER
                | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_VEHICLE
                | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_OTHER
                | DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_TWOWHEEL;
        }

        public override void ClearSetting()
        {
            base.ClearSetting();
        }

        private void ucAllMoveObjSearchSetting_Reset(object sender, EventArgs e)
        {
            ClearSetting();
        }

		private void buttonSelectSearchItem_Click(object sender, EventArgs e) {

		}

		private void buttonOk_Click(object sender, EventArgs e) {

		}
        

        
    }
}
