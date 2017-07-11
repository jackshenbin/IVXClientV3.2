using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucVehicleSearchSetting : ucSearchSettingBase
    {


        public ucVehicleSearchSetting()
        {
            InitializeComponent();
			this.panelEx2.Controls.SetChildIndex(this.expandablePanel2, 1);
            colorComboBoxVehicle.InitColor(DataModel.Constant.VehicleColorInfos.Select(item => new object[] { item.Type.Col, item.Name, item.Type.ID }).ToList());
            colorComboBoxVehicle.SelectedIndex = 0;
            colorComboBoxPlate.InitColor(DataModel.Constant.PlateColorInfos.Select(item => new object[] { item.Type.Col, item.Name, item.Type.ID }).ToList());
            colorComboBoxPlate.SelectedIndex = 0;
            textBoxPlateNo.Text = "";
            m_viewModel.ObjFilterType = DataModel.E_SEARCH_OBJ_FILTER_TYPE.E_SEARCH_OBJ_FILTER_TYPE_VEHICLE ;
            comboBoxPlateRow.ValueMember = "Type";
            comboBoxPlateRow.DisplayMember = "Name";
            comboBoxPlateRow.DataSource = DataModel.Constant.VehiclePlateTypeInfos;
            comboBoxPlateRow.SelectedIndex = 0;
            comboBoxVehicleType.ValueMember = "Type";
            comboBoxVehicleType.DisplayMember = "Name";
            comboBoxVehicleType.DataSource = DataModel.Constant.VehicleTypeInfos;
            comboBoxVehicleType.SelectedIndex = 0;
            comboBoxVehicleTypeDetail.ValueMember = "Type";
            comboBoxVehicleTypeDetail.DisplayMember = "Name";
            comboBoxVehicleTypeDetail.DataSource = DataModel.Constant.VehicleDetailTypeInfos;
            comboBoxVehicleTypeDetail.SelectedIndex = 0;
            comboBoxDriverIsPhoneing.ValueMember = "Type";
            comboBoxDriverIsPhoneing.DisplayMember = "Name";
            comboBoxDriverIsPhoneing.DataSource = DataModel.Constant.VehicleDriverFeatureTypeInfos;
            comboBoxDriverIsPhoneing.SelectedIndex = 0;
            comboBoxDriverIsSafebelt.ValueMember = "Type";
            comboBoxDriverIsSafebelt.DisplayMember = "Name";
            comboBoxDriverIsSafebelt.DataSource = DataModel.Constant.VehicleDriverFeatureTypeInfos;
            comboBoxDriverIsSafebelt.SelectedIndex = 0;
            comboBoxPassengerIsSafebelt.ValueMember = "Type";
            comboBoxPassengerIsSafebelt.DisplayMember = "Name";
            comboBoxPassengerIsSafebelt.DataSource = DataModel.Constant.VehicleDriverFeatureTypeInfos;
            comboBoxPassengerIsSafebelt.SelectedIndex = 0;
            comboBoxDriverIsSunVisor.ValueMember = "Type";
            comboBoxDriverIsSunVisor.DisplayMember = "Name";
            comboBoxDriverIsSunVisor.DataSource = DataModel.Constant.VehicleDriverFeatureTypeInfos;
            comboBoxDriverIsSunVisor.SelectedIndex = 0;
            comboBoxPassengerIsSunVisor.ValueMember = "Type";
            comboBoxPassengerIsSunVisor.DisplayMember = "Name";
            comboBoxPassengerIsSunVisor.DataSource = DataModel.Constant.VehicleDriverFeatureTypeInfos;
            comboBoxPassengerIsSunVisor.SelectedIndex = 0;
            comboBoxVehicleLabel.ValueMember = "Type";
            comboBoxVehicleLabel.DisplayMember = "Name";
            comboBoxVehicleLabel.DataSource = DataModel.Constant.VehicleLabelInfos;//.OrderBy(item=>item.Name).ToArray();
            comboBoxVehicleLabel.SelectedIndex = 0;
            
        }
        private void colorComboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.VehicleColor = Convert.ToUInt32(colorComboBoxVehicle.SelectedColorValue);
        }

        private void colorComboBoxPlate_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.PlateColor = Convert.ToUInt32(colorComboBoxPlate.SelectedColorValue);

        }

        private void textBoxPlateNo_TextChanged(object sender, EventArgs e)
        {
            base.m_viewModel.PlateNo = textBoxPlateNo.Text;
        }

        private void comboBoxPlateRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.PlateNumRow = (E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE)comboBoxPlateRow.SelectedValue;
        }

        private void comboBoxVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.VehicleType = (E_VDA_SEARCH_VEHICLE_TYPE)comboBoxVehicleType.SelectedValue;

        }

        private void comboBoxVehicleTypeDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.VehicleTypeDetail = (E_VDA_SEARCH_VEHICLE_DETAIL_TYPE)comboBoxVehicleTypeDetail.SelectedValue;

        }

        private void comboBoxDriverIsPhoneing_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.DriverIsPhoneing = (E_DRIVER_FEATURE_TYPE)comboBoxDriverIsPhoneing.SelectedValue;

        }

        private void comboBoxDriverIsSafebelt_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.DriverIsSafebelt = (E_DRIVER_FEATURE_TYPE)comboBoxDriverIsSafebelt.SelectedValue;

        }

        private void comboBoxPassengerIsSafebelt_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.PassengerIsSafebelt = (E_DRIVER_FEATURE_TYPE)comboBoxPassengerIsSafebelt.SelectedValue;

        }

        private void comboBoxDriverIsSunVisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.DriverIsSunVisor = (E_DRIVER_FEATURE_TYPE)comboBoxDriverIsSunVisor.SelectedValue;

        }

        private void comboBoxPassengerIsSunVisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.m_viewModel.PassengerIsSunVisor = (E_DRIVER_FEATURE_TYPE)comboBoxPassengerIsSunVisor.SelectedValue;

        }

        private void comboBoxVehicleLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            long parentid = (long)comboBoxVehicleLabel.SelectedValue;
            base.m_viewModel.VehicleLabel = (uint)parentid;
            comboBoxVehicleLabelDetail.ValueMember = "Type";
            comboBoxVehicleLabelDetail.DisplayMember = "Name";
            comboBoxVehicleLabelDetail.DataSource = DataModel.Constant.GetVehicleDetailLabelInfosByParentId(parentid);
            comboBoxVehicleLabelDetail.SelectedIndex = 0;

        }

        private void comboBoxVehicleLabelDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            long childid = (long)comboBoxVehicleLabelDetail.SelectedValue;
            base.m_viewModel.VehicleLabelDetail = (uint)childid;

        }

        private void ucVehicleSearchSetting_Reset(object sender, EventArgs e)
        {
            ClearSetting();
        }

        public override void ClearSetting()
        {
            colorComboBoxVehicle.SelectedIndex = 0;
            colorComboBoxPlate.SelectedIndex = 0;
            textBoxPlateNo.Text = "";
            comboBoxPlateRow.SelectedIndex = 0;
            comboBoxVehicleType.SelectedIndex = 0;
            comboBoxVehicleTypeDetail.SelectedIndex = 0;
            comboBoxDriverIsPhoneing.SelectedIndex = 0;
            comboBoxDriverIsSafebelt.SelectedIndex = 0;
            comboBoxPassengerIsSafebelt.SelectedIndex = 0;
            comboBoxDriverIsSunVisor.SelectedIndex = 0;
            comboBoxPassengerIsSunVisor.SelectedIndex = 0;
            comboBoxVehicleLabel.SelectedIndex = 0;
            comboBoxVehicleLabelDetail.SelectedIndex = 0;

            base.ClearSetting();
        }

    }
}
