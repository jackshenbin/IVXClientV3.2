using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormChannelTrafficEventSetting : IVX.Live.MainForm.UILogics.FormBase
    {
        public TrafficeEventChannelParamInfo ChannelParam{ get; set; }

        public FormChannelTrafficEventSetting()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Text = "车道["+ChannelParam.ChannelID+"]事件监测";
           
            btnCheckNoReverse.DataBindings.Add("Checked",ChannelParam,"CheckNoReverseEnable");
            btnCheckCarCross.DataBindings.Add("Checked",ChannelParam,"CheckCarCrossEnable");
            btnCheckCarFast.DataBindings.Add("Checked",ChannelParam,"CheckCarFastEnable");
            btnCheckCarLow.DataBindings.Add("Checked",ChannelParam,"CheckCarLowEnable");
            btnCheckCarStop.DataBindings.Add("Checked",ChannelParam,"CheckCarStopEnable");
            //btnCheckJam.DataBindings.Add("Checked",ChannelParam,"CheckJamEnable");
            btnCheckPassagerCross.DataBindings.Add("Checked",ChannelParam,"CheckPassagerCrossEnable");
            //btnFlux.DataBindings.Add("Checked",ChannelParam,"CheckFluxEnable");
            btnNoLeft.DataBindings.Add("Checked",ChannelParam,"CheckNoLeftEnable");
            btnNoPassing.DataBindings.Add("Checked",ChannelParam,"CheckNoPassingEnable");
            btnNoRight.DataBindings.Add("Checked",ChannelParam,"CheckNoRightEnable");
            btnNoTurnAround.DataBindings.Add("Checked",ChannelParam,"CheckNoTurnAroundEnable");
            btnNoStraight.DataBindings.Add("Checked",ChannelParam,"CheckNoStraightEnable");
            btnOnBusWay.DataBindings.Add("Checked",ChannelParam,"CheckOnBusWayEnable");
            btnOnMotorWay.DataBindings.Add("Checked",ChannelParam,"CheckOnMotorWayEnable");
            btnPressLine.DataBindings.Add("Checked",ChannelParam,"CheckPressLineEnable");

            checkEditCheckCarCrossGetPlate.DataBindings.Add("Checked",ChannelParam,"CheckCarCrossGetCarPlate");
            checkEditCheckCarFastGetPlate.DataBindings.Add("Checked",ChannelParam,"CheckCarFastGetCarPlate");
            checkEditCheckCarLowGetPlate.DataBindings.Add("Checked",ChannelParam,"CheckCarLowGetCarPlate");
            checkEditCheckCarStopGetPlate.DataBindings.Add("Checked",ChannelParam,"CheckCarStopGetCarPlate");
            checkEditCheckNoReverseGetPlate.DataBindings.Add("Checked",ChannelParam,"CheckNoReverseGetCarPlate");
            checkNoLeft.DataBindings.Add("Checked",ChannelParam,"CheckNoLeftGetCarPlate");
            checkNoPassing.DataBindings.Add("Checked",ChannelParam,"CheckNoPassingGetCarPlate");
            checkNoRight.DataBindings.Add("Checked",ChannelParam,"CheckNoRightGetCarPlate");
            checkNoStraight.DataBindings.Add("Checked",ChannelParam,"CheckNoStraightGetCarPlate");
            checkNoTurnAround.DataBindings.Add("Checked",ChannelParam,"CheckNoTurnAroundGetCarPlate");
            checkOnBusWay.DataBindings.Add("Checked",ChannelParam,"CheckOnBusWayGetCarPlate");
            checkOnMotorWay.DataBindings.Add("Checked",ChannelParam,"CheckOnMotorWayGetCarPlate");
            checkPressLine.DataBindings.Add("Checked",ChannelParam,"CheckPressLineGetCarPlate");

            spinEditCheckCarFast.DataBindings.Add("Value",ChannelParam,"CheckCarFastLimen");
            spinEditCheckCarLow.DataBindings.Add("Value",ChannelParam,"CheckCarLowLimen");
            spinEditCheckCarStop.DataBindings.Add("Value",ChannelParam,"CheckCarStopLimen");
            //spinEditFlux.DataBindings.Add("Value",ChannelParam,"CheckFluxTimeInterval");
            //spinEditJam.DataBindings.Add("Value",ChannelParam,"CheckJamTimeInterval");
            spinEditPressLine.DataBindings.Add("Value",ChannelParam,"CheckPressLineLimen");
        }
    }
}