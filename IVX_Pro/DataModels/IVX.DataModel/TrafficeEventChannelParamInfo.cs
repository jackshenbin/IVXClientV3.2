using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    [Serializable]
    public class TrafficeEventChannelParamInfo:ICloneable
    {
        public readonly int ChannelID = 0;
        public bool CheckNoReverseEnable{get;set;}
        public bool CheckNoReverseGetCarPlate{get;set;}
        //public bool CheckJamEnable{get;set;}
        //public int CheckJamTimeInterval{get;set;}
        //public bool CheckFluxEnable { get; set; }
        //public int CheckFluxTimeInterval { get; set; }
        public bool CheckPassagerCrossEnable{get;set;}
        public bool CheckCarCrossEnable{get;set;}
        public bool CheckCarCrossGetCarPlate{get;set;}
        public bool CheckCarFastEnable{get;set;}
        public int CheckCarFastLimen{get;set;}
        public bool CheckCarFastGetCarPlate{get;set;}
        public bool CheckCarLowEnable{get;set;}
        public int CheckCarLowLimen{get;set;}
        public bool CheckCarLowGetCarPlate{get;set;}
        public bool CheckCarStopEnable{get;set;}
        public int CheckCarStopLimen{get;set;}
        public bool CheckCarStopGetCarPlate{get;set;}
        public bool CheckOnMotorWayEnable{get;set;}
        public bool CheckOnMotorWayGetCarPlate{get;set;}
        public bool CheckNoPassingEnable{get;set;}
        public bool CheckNoPassingGetCarPlate{get;set;}
        public bool CheckNoTurnAroundEnable{get;set;}
        public bool CheckNoTurnAroundGetCarPlate{get;set;}
        public bool CheckNoLeftEnable{get;set;}
        public bool CheckNoLeftGetCarPlate{get;set;}
        public bool CheckNoRightEnable{get;set;}
        public bool CheckNoRightGetCarPlate{get;set;}
        public bool CheckNoStraightEnable{get;set;}
        public bool CheckNoStraightGetCarPlate{get;set;}
        public bool CheckPressLineEnable{get;set;}
        public int CheckPressLineLimen{get;set;}
        public bool CheckPressLineGetCarPlate{get;set;}
        public bool CheckOnBusWayEnable{get;set;}
        public bool CheckOnBusWayGetCarPlate{get;set;}

        public TrafficeEventChannelParamInfo(int channelId)
        {
            ChannelID = channelId;
            CheckNoReverseEnable = false;
            CheckNoReverseGetCarPlate = true;
            CheckPassagerCrossEnable = false;
            CheckCarCrossEnable = false;
            CheckCarCrossGetCarPlate = true;
            CheckCarFastEnable = false;
            CheckCarFastLimen = 60;
            CheckCarFastGetCarPlate = true;
            CheckCarLowEnable = false;
            CheckCarLowLimen = 60;
            CheckCarLowGetCarPlate = true;
            CheckCarStopEnable = false;
            CheckCarStopLimen = 60;
            CheckCarStopGetCarPlate = true;
            CheckOnMotorWayEnable = false;
            CheckOnMotorWayGetCarPlate = true;
            CheckNoPassingEnable = false;
            CheckNoPassingGetCarPlate = true;
            CheckNoTurnAroundEnable = false;
            CheckNoTurnAroundGetCarPlate = true;
            CheckNoLeftEnable = false;
            CheckNoLeftGetCarPlate = true;
            CheckNoRightEnable = false;
            CheckNoRightGetCarPlate = true;
            CheckNoStraightEnable = false;
            CheckNoStraightGetCarPlate = true;
            CheckPressLineEnable = false;
            CheckPressLineLimen = 1;
            CheckPressLineGetCarPlate = true;
            CheckOnBusWayEnable = false;
            CheckOnBusWayGetCarPlate = true;

        }


        public object Clone()
        {
            return new TrafficeEventChannelParamInfo(this.ChannelID)
            {
                CheckCarCrossEnable = this.CheckCarCrossEnable,
                CheckCarCrossGetCarPlate = this.CheckCarCrossGetCarPlate,
                CheckOnBusWayGetCarPlate = this.CheckOnBusWayGetCarPlate,
                CheckOnBusWayEnable = this.CheckOnBusWayEnable,
                CheckPressLineGetCarPlate = this.CheckPressLineGetCarPlate,
                CheckPressLineLimen = this.CheckPressLineLimen,
                CheckPressLineEnable = this.CheckPressLineEnable,
                CheckCarFastEnable = this.CheckCarFastEnable,
                CheckCarFastGetCarPlate = this.CheckCarFastGetCarPlate,
                CheckCarFastLimen = this.CheckCarFastLimen,
                CheckNoTurnAroundEnable = this.CheckNoTurnAroundEnable,
                CheckCarLowEnable = this.CheckCarLowEnable,
                CheckCarLowGetCarPlate = this.CheckCarLowGetCarPlate,
                CheckCarLowLimen = this.CheckCarLowLimen,
                CheckCarStopEnable = this.CheckCarStopEnable,

                CheckCarStopGetCarPlate = this.CheckCarStopGetCarPlate,
                CheckCarStopLimen = this.CheckCarStopLimen,
                CheckNoLeftEnable = this.CheckNoLeftEnable,
                CheckNoLeftGetCarPlate = this.CheckNoLeftGetCarPlate,
                CheckNoPassingEnable = this.CheckNoPassingEnable,
                CheckNoPassingGetCarPlate = this.CheckNoPassingGetCarPlate,
                CheckNoReverseEnable = this.CheckNoReverseEnable,
                CheckNoReverseGetCarPlate = this.CheckNoReverseGetCarPlate,
                CheckNoRightEnable = this.CheckNoRightEnable,
                CheckNoRightGetCarPlate = this.CheckNoRightGetCarPlate,
                CheckNoTurnAroundGetCarPlate = this.CheckNoTurnAroundGetCarPlate,
                CheckNoStraightEnable = this.CheckNoStraightEnable,
                CheckNoStraightGetCarPlate = this.CheckNoStraightGetCarPlate,
                CheckOnMotorWayEnable = this.CheckOnMotorWayEnable,
                CheckOnMotorWayGetCarPlate = this.CheckOnMotorWayGetCarPlate,
                CheckPassagerCrossEnable = this.CheckPassagerCrossEnable,
            };
        }
    };
}
