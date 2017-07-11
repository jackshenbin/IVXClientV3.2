using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using DevComponents.Editors;

namespace IVX.Live.MainForm.View
{
    public partial class ucTrafficEventAnalyseSetting : UserControl, IAnalyseSetting
    {
        #region AccidentAlarm
        public AccidentAlarmSubType AccidentAlarmSubType
        {
            get
            {
                AccidentAlarmSubType type = DataModel.AccidentAlarmSubType.None;
                if (btnCheckJam.Checked) type |= AccidentAlarmSubType.CheckJam;
                if (btnFlux.Checked) type |= AccidentAlarmSubType.Flux;
                return type;
            }
            set
            {
                btnFlux.Checked = ((value & AccidentAlarmSubType.Flux) > 0);
                btnCheckJam.Checked = ((value & AccidentAlarmSubType.CheckJam) > 0);
            }
        }
        private Point[] m_worldSC = null;

        public Point[] WorldSC
        {
            get
            {
                if (m_worldSC == null)
                {
                    ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

                    if (c == null || c.DrawImage == null)
                        return null;
                    if (c.ImageSC.Count != 6)
                        return null;
                    m_worldSC = new Point[6];

                    for (int i = 0; i < 6; i++)
                    {
                        m_worldSC[i] = new Point(c.ImageSC[i].X - c.ImageSC[0].X, c.ImageSC[i].Y - c.ImageSC[0].Y);
                    }
                }

                doubleInputX1.Value = m_worldSC[0].X;
                doubleInputX2.Value = m_worldSC[1].X;
                doubleInputX3.Value = m_worldSC[2].X;
                doubleInputX4.Value = m_worldSC[3].X;
                doubleInputX5.Value = m_worldSC[4].X;
                doubleInputX6.Value = m_worldSC[5].X;
                doubleInputY1.Value = m_worldSC[0].Y;
                doubleInputY2.Value = m_worldSC[1].Y;
                doubleInputY3.Value = m_worldSC[2].Y;
                doubleInputY4.Value = m_worldSC[3].Y;
                doubleInputY5.Value = m_worldSC[4].Y;
                doubleInputY6.Value = m_worldSC[5].Y;

                return m_worldSC;
            }
            set
            {
                m_worldSC = value;
                doubleInputX1.Value = m_worldSC[0].X;
                doubleInputX2.Value = m_worldSC[1].X;
                doubleInputX3.Value = m_worldSC[2].X;
                doubleInputX4.Value = m_worldSC[3].X;
                doubleInputX5.Value = m_worldSC[4].X;
                doubleInputX6.Value = m_worldSC[5].X;
                doubleInputY1.Value = m_worldSC[0].Y;
                doubleInputY2.Value = m_worldSC[1].Y;
                doubleInputY3.Value = m_worldSC[2].Y;
                doubleInputY4.Value = m_worldSC[3].Y;
                doubleInputY5.Value = m_worldSC[4].Y;
                doubleInputY6.Value = m_worldSC[5].Y;
            }
        }
        public bool VehicleNoplatInclude
        {
            get { return checkEditNoplatInclude.Checked; }
            set
            {
                checkEditNoplatInclude.Checked = value;
            }
        }


        public uint FluxTimelyReportTimeInterval
        {
            get { return (uint)spinEditFlux.Value; }
            set
            {
                spinEditFlux.Value = (int)value;
            }
        }
        public uint JamTimelyReportTimeInterval
        {
            get { return (uint)spinEditJam.Value; }
            set
            {
                spinEditJam.Value = (int)value;
            }
        }

        public bool P_StructualFeature
        {
            get { return checkBoxP_StructualFeature.Checked; }
            set { checkBoxP_StructualFeature.Checked = value; }
        }
        public bool P_GlobalFeature
        {
            get { return checkBoxP_GlobalFeature.Checked; }
            set { checkBoxP_GlobalFeature.Checked = value; }
        }
        public bool P_PartFeature
        {
            get { return checkBoxP_PartFeature.Checked; }
            set { checkBoxP_PartFeature.Checked = value; }
        }
        public bool P_Track
        {
            get { return checkBoxP_Track.Checked; }
            set { checkBoxP_Track.Checked = value; }
        }
        public bool P_SnapImage
        {
            get { return checkBoxP_SnapImage.Checked; }
            set { checkBoxP_SnapImage.Checked = value; }
        }


        public bool NV_StructualFeature
        {
            get { return checkBoxNV_StructualFeature.Checked; }
            set { checkBoxNV_StructualFeature.Checked = value; }
        }
        public bool NV_GlobalFeature
        {
            get { return checkBoxNV_GlobalFeature.Checked; }
            set { checkBoxNV_GlobalFeature.Checked = value; }
        }
        public bool NV_PartFeature
        {
            get { return checkBoxNV_PartFeature.Checked; }
            set { checkBoxNV_PartFeature.Checked = value; }
        }
        public bool NV_Track
        {
            get { return checkBoxNV_Track.Checked; }
            set { checkBoxNV_Track.Checked = value; }
        }
        public bool NV_SnapImage
        {
            get { return checkBoxNV_SnapImage.Checked; }
            set { checkBoxNV_SnapImage.Checked = value; }
        }



        public bool V_StructualFeature
        {
            get { return checkBoxV_StructualFeature.Checked; }
            set { checkBoxV_StructualFeature.Checked = value; }
        }
        public bool V_GlobalFeature
        {
            get { return checkBoxV_GlobalFeature.Checked; }
            set { checkBoxV_GlobalFeature.Checked = value; }
        }
        public bool V_PartFeature
        {
            get { return checkBoxV_PartFeature.Checked; }
            set { checkBoxV_PartFeature.Checked = value; }
        }
        public bool V_Track
        {
            get { return checkBoxV_Track.Checked; }
            set { checkBoxV_Track.Checked = value; }
        }
        public bool V_SnapImage
        {
            get { return checkBoxV_SnapImage.Checked; }
            set { checkBoxV_SnapImage.Checked = value; }
        }


        public TrafficeEventChannelParamInfo[] TrafficeEventParam
        {
            get
            {
                TrafficeEventChannelParamInfo[] t = new TrafficeEventChannelParamInfo[6];
                t[0] = buttonEventParamX1.Tag as TrafficeEventChannelParamInfo;
                t[1] = buttonEventParamX2.Tag as TrafficeEventChannelParamInfo;
                t[2] = buttonEventParamX3.Tag as TrafficeEventChannelParamInfo;
                t[3] = buttonEventParamX4.Tag as TrafficeEventChannelParamInfo;
                t[4] = buttonEventParamX5.Tag as TrafficeEventChannelParamInfo;
                t[5] = buttonEventParamX6.Tag as TrafficeEventChannelParamInfo;
                return t;
            }
            set
            {
                buttonEventParamX1.Tag = value[0];
                buttonEventParamX2.Tag = value[1];
                buttonEventParamX3.Tag = value[2];
                buttonEventParamX4.Tag = value[3];
                buttonEventParamX5.Tag = value[4];
                buttonEventParamX6.Tag = value[5];
            }
        }
        #endregion

        public ucTrafficEventAnalyseSetting()
        {
            InitializeComponent();

            checkBoxWay1.Tag = DrawGraphType.DriveWay1;
            checkBoxWay2.Tag = DrawGraphType.DriveWay2;
            checkBoxWay3.Tag = DrawGraphType.DriveWay3;
            checkBoxWay4.Tag = DrawGraphType.DriveWay4;
            checkBoxWay5.Tag = DrawGraphType.DriveWay5;
            checkBoxWay6.Tag = DrawGraphType.DriveWay6;

            checkButtonFluxline1.Tag = DrawGraphType.VehicleFluxLine1;
            checkButtonFluxline2.Tag = DrawGraphType.VehicleFluxLine2;
            checkButtonFluxline3.Tag = DrawGraphType.VehicleFluxLine3;
            checkButtonFluxline4.Tag = DrawGraphType.VehicleFluxLine4;
            checkButtonFluxline5.Tag = DrawGraphType.VehicleFluxLine5;
            checkButtonFluxline6.Tag = DrawGraphType.VehicleFluxLine6;

            doubleInputX1.Tag = "1X";
            doubleInputX2.Tag = "2X";
            doubleInputX3.Tag = "3X";
            doubleInputX4.Tag = "4X";
            doubleInputX5.Tag = "5X";
            doubleInputX6.Tag = "6X";
            doubleInputY1.Tag = "1Y";
            doubleInputY2.Tag = "2Y";
            doubleInputY3.Tag = "3Y";
            doubleInputY4.Tag = "4Y";
            doubleInputY5.Tag = "5Y";
            doubleInputY6.Tag = "6Y";

            buttonEventParamX1.Tag = new TrafficeEventChannelParamInfo(1);
            buttonEventParamX2.Tag = new TrafficeEventChannelParamInfo(2);
            buttonEventParamX3.Tag = new TrafficeEventChannelParamInfo(3);
            buttonEventParamX4.Tag = new TrafficeEventChannelParamInfo(4);
            buttonEventParamX5.Tag = new TrafficeEventChannelParamInfo(5);
            buttonEventParamX6.Tag = new TrafficeEventChannelParamInfo(6);

        }

        public string AnalyseParam
        {
            set
            {
                ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
                buttonEventParamX1.Tag = GetEventParamFromXML(value, 1);
                buttonEventParamX2.Tag = GetEventParamFromXML(value, 2);
                buttonEventParamX3.Tag = GetEventParamFromXML(value, 3);
                buttonEventParamX4.Tag = GetEventParamFromXML(value, 4);
                buttonEventParamX5.Tag = GetEventParamFromXML(value, 5);
                buttonEventParamX6.Tag = GetEventParamFromXML(value, 6);

                 uint fluxTimelyReportTimeInterval = 0; uint jamTimelyReportTimeInterval = 0;
                GetCarFastFromXML(value, out fluxTimelyReportTimeInterval, out jamTimelyReportTimeInterval);

                FluxTimelyReportTimeInterval = fluxTimelyReportTimeInterval;
                JamTimelyReportTimeInterval = jamTimelyReportTimeInterval;

                bool p_StructualFeature = false;
                bool p_GlobalFeature = false;
                bool p_PartFeature = false;
                bool p_Track = false;
                bool p_SnapImage = false;
                bool nv_StructualFeature = false;
                bool nv_GlobalFeature = false;
                bool nv_PartFeature = false;
                bool nv_Track = false;
                bool nv_SnapImage = false;
                bool v_StructualFeature = false;
                bool v_GlobalFeature = false;
                bool v_PartFeature = false;
                bool v_Track = false;
                bool v_SnapImage = false;


                GetCheckObjectFromXML(value
                    , out p_StructualFeature
                    , out  p_GlobalFeature
                    , out  p_PartFeature
                    , out  p_Track
                    , out  p_SnapImage
                    , out nv_StructualFeature
                    , out  nv_GlobalFeature
                    , out  nv_PartFeature
                    , out  nv_Track
                    , out  nv_SnapImage
                    , out  v_StructualFeature
                    , out  v_GlobalFeature
                    , out  v_PartFeature
                    , out  v_Track
                    , out  v_SnapImage
                    );

                P_StructualFeature = p_StructualFeature;
                P_GlobalFeature = p_GlobalFeature;
                P_PartFeature = p_PartFeature;
                P_Track = p_Track;
                P_SnapImage = p_SnapImage;
                NV_StructualFeature = nv_StructualFeature;
                NV_GlobalFeature = nv_GlobalFeature;
                NV_PartFeature = nv_PartFeature;
                NV_Track = nv_Track;
                NV_SnapImage = nv_SnapImage;
                V_StructualFeature = v_StructualFeature;
                V_GlobalFeature = v_GlobalFeature;
                V_PartFeature = v_PartFeature;
                V_Track = v_Track;
                V_SnapImage = v_SnapImage; 
                
                
                AccidentAlarmSubType = GetAccidentAlarmSubTypeFromXML(value);
                List<DriveWayRegion> dwbreaks = GetDriveWayRegionFromXML(value);
                c.DriveWays = new bool[6];
                c.DriveWayRegionParam = dwbreaks;
                foreach (DriveWayRegion dw in dwbreaks)
                {
                    c.DriveWays[dw.ChannelID - 1] = true;
                    (expandablePanel4.Controls["checkBoxWay"+dw.ChannelID] as CheckBoxX).Checked = true;
                }
                c.ChangeChannelLineParam = GetChangeChannelLineFromXML(value);
                c.PressChannelLineParam = GetPressChannelLineFromXML(value);
                c.StopLineParam = GetStopLineFromXML(value);
                c.SecondLineParam = GetSecondLineFromXML(value);
                c.NoStraightLineParam = GetNoStraightLineFromXML(value);
                c.NoLeftLineParam = GetNoLeftLineFromXML(value);
                c.NoRightLineParam = GetNoRightLineFromXML(value);
                c.NoTurnAroundLineParam = GetNoTurnAroundLineFromXML(value);
                List<Point> vehiclemark = GetSceneMarkFromXML("ImageSC", value);
                c.ImageSC = vehiclemark;
                WorldSC = GetSceneMarkFromXML("WorldSC", value).ToArray();


                List<Point> vehicleregion = GetRoadRegionFromXML(value);
                if (vehicleregion.Count > 0)

                    c.AnalyseAreaExParam = vehicleregion;
                //List<Rectangle> carplate = GetCarPlateAreaFromXML(szAnalysisParam);
                //if(carplate.Count>0)
                //    SetPicDrawData(DrawGraphType.VehicleRegion, carplate[0]);

                VehicleNoplatInclude = GetAnalyseVehicleNoplatIncludeFromXML(value);
            }
            get
            {
                return BuildAnalyseParamByAccidentAlarm();
            }
        }

        public Control DrawHandle
        {
            get;
            set;
        }

        private string BuildAnalyseParamByAccidentAlarm()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            sb.AppendLine("<AlgorithmInitParam>");
            sb.AppendLine("<AlgorithmType>Crossroad</AlgorithmType>");
            if (c.AnalyseAreaExParam.Count > 0)
            {
                sb.AppendLine("<RoadRegion>");
                sb.AppendLine("<RoadNum>1</RoadNum>");
                sb.AppendLine("<RoadInfo>");
                sb.AppendLine("<PointNum>" + c.AnalyseAreaExParam.Count + "</PointNum>");
                sb.AppendLine("<PointSet>");
                foreach (var item in c.AnalyseAreaExParam)
                {
                    sb.AppendLine("<Point>");
                    sb.AppendLine("<X>" + item.X + "</X>");
                    sb.AppendLine("<Y>" + item.Y + "</Y>");
                    sb.AppendLine("</Point>");

                }
                sb.AppendLine("</PointSet>");
                sb.AppendLine("</RoadInfo>");
                sb.AppendLine("</RoadRegion>");
            }

            sb.AppendLine("<ChannelRegion>");
            sb.AppendLine("<ChannelNum>" + c.DriveWayRegionParam.Count + "</ChannelNum>");
            c.DriveWayRegionParam.ForEach(item => { sb.AppendLine(item.ToXMLString()); });
            sb.AppendLine("</ChannelRegion>");



            sb.AppendLine(BuildAnalyseParamBySceneMark());

            sb.AppendLine(BuildAnalyseParamByCarPlate(c.CarPlateAreaParam[0]));

            sb.AppendLine(BuildAnalyseParamByObjectCheck());



            sb.AppendLine("<Accident>");
            sb.AppendLine(BuildAnalyseParamByCheckNoReverse());
            sb.AppendLine(BuildAnalyseParamByCheckJam());
            sb.AppendLine(BuildAnalyseParamByCheckPassagerCross());
            sb.AppendLine(BuildAnalyseParamByCheckCarCross());
            sb.AppendLine(BuildAnalyseParamByCheckCarFast());
            sb.AppendLine(BuildAnalyseParamByCheckCarLow());
            sb.AppendLine(BuildAnalyseParamByCheckCarStop());
            sb.AppendLine(BuildAnalyseParamByCheckOnMotorWay());
            sb.AppendLine(BuildAnalyseParamByCheckNoPassing());
            sb.AppendLine(BuildAnalyseParamByCheckNoTurnAround());
            sb.AppendLine(BuildAnalyseParamByCheckNoLeft());
            sb.AppendLine(BuildAnalyseParamByCheckNoRight());
            sb.AppendLine(BuildAnalyseParamByCheckNoStraight());
            sb.AppendLine(BuildAnalyseParamByCheckPressLine());
            sb.AppendLine(BuildAnalyseParamByCheckOnBusWay());
            sb.AppendLine("</Accident>");

            sb.AppendLine(BuildAnalyseParamByFlux());

            sb.AppendLine("</AlgorithmInitParam>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }

        private string BuildAnalyseParamByChangeChannelLine()
        {/*			<ChangeChannelLine>
				<LineNum>1</LineNum>
				<LineSet>
					<Line>
						<StartPoint>
							<X>841</X>
							<Y>1240</Y>
						</StartPoint>
						<EndPoint>
							<X>177</X>
							<Y>2006</Y>
						</EndPoint>
					</Line>
				</LineSet>
			</ChangeChannelLine>
*/
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ChangeChannelLine>");
            sb.AppendLine("<LineNum>" + c.ChangeChannelLineParam.Count + "</LineNum>");
            sb.AppendLine("<LineSet>");
            foreach (Tuple<Point, Point> item in c.ChangeChannelLineParam)
            {
                sb.AppendLine("<Line>");
                sb.AppendLine("<StartPoint>");
                sb.AppendLine("<X>" + item.Item1.X + "</X>");
                sb.AppendLine("<Y>" + item.Item1.Y + "</Y>");
                sb.AppendLine("</StartPoint>");
                sb.AppendLine("<EndPoint>");
                sb.AppendLine("<X>" + item.Item2.X + "</X>");
                sb.AppendLine("<Y>" + item.Item2.Y + "</Y>");
                sb.AppendLine("</EndPoint>");
                sb.AppendLine("</Line>");

            }
            sb.AppendLine("</LineSet>");
            sb.AppendLine("</ChangeChannelLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByPressChannelLine()
        {/*				<PressChannelLine>
				<LineNum>1</LineNum>
				<LineSet>
					<Line>
						<StartPoint>
							<X>841</X>
							<Y>1240</Y>
						</StartPoint>
						<EndPoint>
							<X>177</X>
							<Y>2006</Y>
						</EndPoint>
					</Line>
				</LineSet>
			</PressChannelLine>
*/
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<PressChannelLine>");
            sb.AppendLine("<LineNum>" + c.PressChannelLineParam.Count + "</LineNum>");
            sb.AppendLine("<LineSet>");
            foreach (Tuple<Point, Point> item in c.PressChannelLineParam)
            {
                sb.AppendLine("<Line>");
                sb.AppendLine("<StartPoint>");
                sb.AppendLine("<X>" + item.Item1.X + "</X>");
                sb.AppendLine("<Y>" + item.Item1.Y + "</Y>");
                sb.AppendLine("</StartPoint>");
                sb.AppendLine("<EndPoint>");
                sb.AppendLine("<X>" + item.Item2.X + "</X>");
                sb.AppendLine("<Y>" + item.Item2.Y + "</Y>");
                sb.AppendLine("</EndPoint>");
                sb.AppendLine("</Line>");

            }
            sb.AppendLine("</LineSet>");
            sb.AppendLine("</PressChannelLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByStopLine()
        {/*		<StopLine>
				<StartPoint>
					<X>841</X>
					<Y>1240</Y>
				</StartPoint>
				<EndPoint>
					<X>3298</X>
					<Y>1235</Y>
				</EndPoint>
			</StopLine>
*/
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<StopLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + c.StopLineParam.Item1.X + "</X>");
            sb.AppendLine("<Y>" + c.StopLineParam.Item1.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + c.StopLineParam.Item2.X + "</X>");
            sb.AppendLine("<Y>" + c.StopLineParam.Item2.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</StopLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamBySecondLine()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<SecondLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + c.SecondLineParam.Item1.X + "</X>");
            sb.AppendLine("<Y>" + c.SecondLineParam.Item1.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + c.SecondLineParam.Item2.X + "</X>");
            sb.AppendLine("<Y>" + c.SecondLineParam.Item2.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</SecondLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByNoStraightLine()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<NoStraightLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + c.NoStraightLineParam.Item1.X + "</X>");
            sb.AppendLine("<Y>" + c.NoStraightLineParam.Item1.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + c.NoStraightLineParam.Item2.X + "</X>");
            sb.AppendLine("<Y>" + c.NoStraightLineParam.Item2.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</NoStraightLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByNoLeftLine()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<NoLeftLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + c.NoLeftLineParam.Item1.X + "</X>");
            sb.AppendLine("<Y>" + c.NoLeftLineParam.Item1.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + c.NoLeftLineParam.Item2.X + "</X>");
            sb.AppendLine("<Y>" + c.NoLeftLineParam.Item2.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</NoLeftLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByNoRightLine()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<NoRightLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + c.NoRightLineParam.Item1.X + "</X>");
            sb.AppendLine("<Y>" + c.NoRightLineParam.Item1.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + c.NoRightLineParam.Item2.X + "</X>");
            sb.AppendLine("<Y>" + c.NoRightLineParam.Item2.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</NoRightLine>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByNoTurnAroundLine()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<NoTurnAroundLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + c.NoTurnAroundLineParam.Item1.X + "</X>");
            sb.AppendLine("<Y>" + c.NoTurnAroundLineParam.Item1.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + c.NoTurnAroundLineParam.Item2.X + "</X>");
            sb.AppendLine("<Y>" + c.NoTurnAroundLineParam.Item2.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</NoTurnAroundLine>");

            return sb.ToString();
        }

        private string BuildAnalyseParamByCheckNoReverse()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoReverse>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckNoReverseEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckNoReverseGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckNoReverse>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckJam()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckJam>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                if (c.DriveWays[i] && ((AccidentAlarmSubType.CheckJam & AccidentAlarmSubType) > 0))
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("<TimelyReportTimeInterval>" + JamTimelyReportTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("</CheckJam>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckPassagerCross()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckPassagerCross>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckPassagerCrossEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckPassagerCross>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarCross()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarCross>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckCarCrossEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckCarCrossGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckCarCross>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarFast()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarFast>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckCarFastEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<Limen>" + tempinfo.CheckCarFastLimen + "</Limen>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckCarFastGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }

            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckCarFast>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarLow()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarLow>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckCarLowEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<Limen>" + tempinfo.CheckCarLowLimen + "</Limen>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckCarLowGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckCarLow>");

            return sb.ToString();
        }
        private string BuildAnalyseParamByCheckCarStop()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckCarStop>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckCarStopEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<Limen>" + tempinfo.CheckCarStopLimen + "</Limen>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckCarStopGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckCarStop>");

            return sb.ToString();
        }

        private string BuildAnalyseParamByCheckOnMotorWay()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckOnMotorWay>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckOnMotorWayEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckOnBusWayGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckOnMotorWay>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckNoPassing()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoPassing>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckNoPassingEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckNoPassingGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckNoPassing>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckNoTurnAround()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoTurnAround>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckNoTurnAroundEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckNoTurnAroundGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckNoTurnAround>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckNoLeft()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoLeft>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckNoLeftEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckNoLeftGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckNoLeft>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckNoRight()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoRight>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckNoRightEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckNoRightGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckNoRight>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckNoStraight()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckNoStraight>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckNoStraightEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckNoStraightGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckNoStraight>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckPressLine()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckPressLine>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckPressLineEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<Limen>" + tempinfo.CheckPressLineLimen.ToString().ToUpper() + "</Limen>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckPressLineGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckPressLine>");

            return sb.ToString();

        }
        private string BuildAnalyseParamByCheckOnBusWay()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CheckOnBusWay>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                TrafficeEventChannelParamInfo tempinfo
                    = expandablePanel4.Controls["buttonEventParamX" + (i + 1)].Tag as TrafficeEventChannelParamInfo;
                if (c.DriveWays[i] && tempinfo != null && tempinfo.CheckOnBusWayEnable)
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("<GetCarPlate>" + tempinfo.CheckOnBusWayGetCarPlate.ToString().ToUpper() + "</GetCarPlate>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");
            sb.AppendLine("</CheckOnBusWay>");

            return sb.ToString();

        }


        private string BuildAnalyseParamByFlux()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Flux>");
            int count = 0;
            for (int i = 0; i < c.DriveWays.Length; i++)
            {
                if (c.DriveWays[i] && ((AccidentAlarmSubType.Flux & AccidentAlarmSubType) > 0))
                {
                    count++;
                    sb.AppendLine("<ChannelInfo>");
                    sb.AppendLine("<ChannelID>" + (i + 1) + "</ChannelID>");
                    sb.AppendLine("</ChannelInfo>");
                }
            }
            sb.AppendLine("<ChannelNum>" + count + "</ChannelNum>");

            sb.AppendLine("<TimelyReportTimeInterval>" + FluxTimelyReportTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("</Flux>");

            return sb.ToString();
        }

        private string BuildAnalyseParamByObjectCheck()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ObjectCheck>");

            sb.AppendLine("<CheckPeople>");
            sb.AppendLine("<Enable>TRUE</Enable>");
            sb.AppendLine("<StructualFeature>");
            sb.AppendLine("<Enable>" + P_StructualFeature.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</StructualFeature>");
            sb.AppendLine("<NonStructualFeature>");
            sb.AppendLine("<GlobalFeature>" + P_GlobalFeature.ToString().ToUpper() + "</GlobalFeature>");
            sb.AppendLine("<PartFeature>" + P_PartFeature.ToString().ToUpper() + "</PartFeature>");
            sb.AppendLine("</NonStructualFeature>");
            sb.AppendLine("<Track>");
            sb.AppendLine("<Enable>" + P_Track.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</Track>");
            sb.AppendLine("<SnapImage>");
            sb.AppendLine("<Enable>" + P_SnapImage.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</SnapImage>");
            sb.AppendLine("</CheckPeople>");

            sb.AppendLine("<CheckTwoWheel>");
            sb.AppendLine("<Enable>TRUE</Enable>");
            sb.AppendLine("<StructualFeature>");
            sb.AppendLine("<Enable>" + NV_StructualFeature.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</StructualFeature>");
            sb.AppendLine("<NonStructualFeature>");
            sb.AppendLine("<GlobalFeature>" + NV_GlobalFeature.ToString().ToUpper() + "</GlobalFeature>");
            sb.AppendLine("<PartFeature>" + NV_PartFeature.ToString().ToUpper() + "</PartFeature>");
            sb.AppendLine("</NonStructualFeature>");
            sb.AppendLine("<Track>");
            sb.AppendLine("<Enable>" + NV_Track.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</Track>");
            sb.AppendLine("<SnapImage>");
            sb.AppendLine("<Enable>" + NV_SnapImage.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</SnapImage>");
            sb.AppendLine("</CheckTwoWheel>");

            sb.AppendLine("<CheckVehicle>");
            sb.AppendLine("<Enable>TRUE</Enable>");
            sb.AppendLine("<StructualFeature>");
            sb.AppendLine("<Enable>" + V_StructualFeature.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</StructualFeature>");
            sb.AppendLine("<NonStructualFeature>");
            sb.AppendLine("<GlobalFeature>" + V_GlobalFeature.ToString().ToUpper() + "</GlobalFeature>");
            sb.AppendLine("<PartFeature>" + V_PartFeature.ToString().ToUpper() + "</PartFeature>");
            sb.AppendLine("</NonStructualFeature>");
            sb.AppendLine("<Track>");
            sb.AppendLine("<Enable>" + V_Track.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</Track>");
            sb.AppendLine("<SnapImage>");
            sb.AppendLine("<Enable>" + V_SnapImage.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</SnapImage>");
            sb.AppendLine("</CheckVehicle>");

            sb.AppendLine("</ObjectCheck>");

            return sb.ToString();

        }

        private string BuildAnalyseParamByCarPlate(Rectangle rect)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CarPlate>");
            //sb.AppendLine("<CarPlateCheckRegion>");
            //sb.AppendLine("<LTPoint>");
            //sb.AppendLine("<X>" + rect.X + "</X>");
            //sb.AppendLine("<Y>" + rect.Y + "</Y>");
            //sb.AppendLine("</LTPoint>");
            //sb.AppendLine("<Width>" + rect.Width + "</Width>");
            //sb.AppendLine("<Height>" + rect.Height + "</Height>");
            //sb.AppendLine("</CarPlateCheckRegion>");
            sb.AppendLine("<CheckNoCarPlate>" + VehicleNoplatInclude.ToString().ToUpper() + "</CheckNoCarPlate>");
            sb.AppendLine("</CarPlate>");

            return sb.ToString();
        }

        private string BuildAnalyseParamBySceneMark()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<SceneMark>");
            sb.AppendLine(BuildAnalyseParamByChangeChannelLine());
            sb.AppendLine(BuildAnalyseParamByPressChannelLine());
            sb.AppendLine(BuildAnalyseParamByStopLine());
            sb.AppendLine(BuildAnalyseParamBySecondLine());
            sb.AppendLine(BuildAnalyseParamByNoStraightLine());
            sb.AppendLine(BuildAnalyseParamByNoLeftLine());
            sb.AppendLine(BuildAnalyseParamByNoRightLine());
            sb.AppendLine(BuildAnalyseParamByNoTurnAroundLine());
            sb.AppendLine("<ImageSC>");
            sb.AppendLine("<PointNum>" + c.ImageSC.Count + "</PointNum>");
            sb.AppendLine("<PointSet>");
            System.Drawing.Point item = c.ImageSC[0];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[2];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[3];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[5];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[1];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[4];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");


            sb.AppendLine("</PointSet>");
            sb.AppendLine("</ImageSC>");


            sb.AppendLine("<WorldSC>");
            sb.AppendLine("<PointNum>" + WorldSC.Length + "</PointNum>");
            sb.AppendLine("<PointSet>");
            item = WorldSC[0];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[2];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[3];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[5];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[1];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[4];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");

            sb.AppendLine("</PointSet>");
            sb.AppendLine("</WorldSC>");
            sb.AppendLine("</SceneMark>");
            return sb.ToString();

        }

        private TrafficeEventChannelParamInfo GetEventParamFromXML(string xml,int channel)
        {
            TrafficeEventChannelParamInfo info = new TrafficeEventChannelParamInfo(channel);
            if (string.IsNullOrEmpty(xml))
            {
                return info;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckNoReverse/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckNoReverseEnable = true;
                    info.CheckNoReverseGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckPassagerCross/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                if(c== channel)
                {
                    info.CheckPassagerCrossEnable = true;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckCarCross/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckCarCrossEnable = true;
                    info.CheckCarCrossGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckCarFast/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                int l = Convert.ToInt32(node.SelectSingleNode("Limen").InnerXml);
                if(c== channel)
                {
                    info.CheckCarFastEnable = true;
                    info.CheckCarFastGetCarPlate = p;
                    info.CheckCarFastLimen = l;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckCarLow/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                int l = Convert.ToInt32(node.SelectSingleNode("Limen").InnerXml);
                if(c== channel)
                {
                    info.CheckCarLowEnable = true;
                    info.CheckCarLowGetCarPlate = p;
                    info.CheckCarLowLimen = l;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckCarStop/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                int l = Convert.ToInt32(node.SelectSingleNode("Limen").InnerXml);
                if(c== channel)
                {
                    info.CheckCarStopEnable = true;
                    info.CheckCarStopGetCarPlate = p;
                    info.CheckCarStopLimen = l;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckOnMotorWay/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckOnMotorWayEnable = true;
                    info.CheckOnMotorWayGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckNoPassing/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckNoPassingEnable = true;
                    info.CheckNoPassingGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckNoTurnAround/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckNoTurnAroundEnable = true;
                    info.CheckNoTurnAroundGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckNoLeft/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckNoLeftEnable = true;
                    info.CheckNoLeftGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckNoRight/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckNoRightEnable = true;
                    info.CheckNoRightGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckNoStraight/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckNoStraightEnable = true;
                    info.CheckNoStraightGetCarPlate = p;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckPressLine/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                int l = Convert.ToInt32(node.SelectSingleNode("Limen").InnerXml);
                if(c== channel)
                {
                    info.CheckPressLineEnable = true;
                    info.CheckPressLineGetCarPlate = p;
                    info.CheckPressLineLimen = l;
                }
            }
            foreach (System.Xml.XmlNode node in xmldoc.SelectNodes("root/AlgorithmInitParam/Accident/CheckOnBusWay/ChannelInfo"))
            {
                int c = Convert.ToInt32(node.SelectSingleNode("ChannelID").InnerXml);
                bool p = Convert.ToBoolean(node.SelectSingleNode("GetCarPlate").InnerXml);
                if(c== channel)
                {
                    info.CheckOnBusWayEnable = true;
                    info.CheckOnBusWayGetCarPlate = p;
                }
            }
            return info;
        }
        private void GetCarFastFromXML(string xml, out uint Flux, out uint Jam)
        {
            if (string.IsNullOrEmpty(xml))
            {
                Flux = 120;
                Jam = 120;
                return;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode CheckCarFlux = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Flux/TimelyReportTimeInterval");
            Flux = Convert.ToUInt32(CheckCarFlux.InnerText);

            System.Xml.XmlNode CheckCarJam = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckJam/TimelyReportTimeInterval");
            Jam = Convert.ToUInt32(CheckCarJam.InnerText);

        }

        private void GetCheckObjectFromXML(string xml
    , out bool p_StructualFeature
    , out bool p_GlobalFeature
    , out bool p_PartFeature
    , out bool p_Track
    , out bool p_SnapImage
    , out bool nv_StructualFeature
    , out bool nv_GlobalFeature
    , out bool nv_PartFeature
    , out bool nv_Track
    , out bool nv_SnapImage
    , out bool v_StructualFeature
    , out bool v_GlobalFeature
    , out bool v_PartFeature
    , out bool v_Track
    , out bool v_SnapImage)
        {
            if (string.IsNullOrEmpty(xml))
            {
                p_StructualFeature= true;
                p_GlobalFeature= true;
                p_PartFeature= true;
                p_Track = true;
                p_SnapImage = true;

                nv_StructualFeature = true;
                nv_GlobalFeature = true;
                nv_PartFeature = true;
                nv_Track = true;
                nv_SnapImage = true;

                v_StructualFeature = true;
                v_GlobalFeature = true;
                v_PartFeature = true;
                v_Track = true;
                v_SnapImage = true;
                return;
            }

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNode p_StructualFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/StructualFeature/Enable");
            p_StructualFeature = Convert.ToBoolean(p_StructualFeatureNode.InnerText);

            System.Xml.XmlNode p_GlobalFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/NonStructualFeature/GlobalFeature");
            p_GlobalFeature = Convert.ToBoolean(p_GlobalFeatureNode.InnerText);

            System.Xml.XmlNode p_PartFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/NonStructualFeature/PartFeature");
            p_PartFeature = Convert.ToBoolean(p_PartFeatureNode.InnerText);

            System.Xml.XmlNode p_TrackNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/Track/Enable");
            p_Track = Convert.ToBoolean(p_TrackNode.InnerText);

            System.Xml.XmlNode p_SnapImageNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/SnapImage/Enable");
            p_SnapImage = Convert.ToBoolean(p_SnapImageNode.InnerText);


            System.Xml.XmlNode nv_StructualFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/StructualFeature/Enable");
            nv_StructualFeature = Convert.ToBoolean(nv_StructualFeatureNode.InnerText);

            System.Xml.XmlNode nv_GlobalFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/NonStructualFeature/GlobalFeature");
            nv_GlobalFeature = Convert.ToBoolean(nv_GlobalFeatureNode.InnerText);

            System.Xml.XmlNode nv_PartFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/NonStructualFeature/PartFeature");
            nv_PartFeature = Convert.ToBoolean(nv_PartFeatureNode.InnerText);

            System.Xml.XmlNode nv_TrackNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/Track/Enable");
            nv_Track = Convert.ToBoolean(nv_TrackNode.InnerText);

            System.Xml.XmlNode nv_SnapImageNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/SnapImage/Enable");
            nv_SnapImage = Convert.ToBoolean(nv_SnapImageNode.InnerText);



            System.Xml.XmlNode v_StructualFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/StructualFeature/Enable");
            v_StructualFeature = Convert.ToBoolean(v_StructualFeatureNode.InnerText);

            System.Xml.XmlNode v_GlobalFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/NonStructualFeature/GlobalFeature");
            v_GlobalFeature = Convert.ToBoolean(v_GlobalFeatureNode.InnerText);

            System.Xml.XmlNode v_PartFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/NonStructualFeature/PartFeature");
            v_PartFeature = Convert.ToBoolean(v_PartFeatureNode.InnerText);

            System.Xml.XmlNode v_TrackNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/Track/Enable");
            v_Track = Convert.ToBoolean(v_TrackNode.InnerText);

            System.Xml.XmlNode v_SnapImageNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/SnapImage/Enable");
            v_SnapImage = Convert.ToBoolean(v_SnapImageNode.InnerText);


        }

        private List<DriveWayRegion> GetDriveWayRegionFromXML(string xml)
        {
            List<DriveWayRegion> ret = new List<DriveWayRegion>();
            if (string.IsNullOrEmpty(xml))
                return ret;

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            foreach (System.Xml.XmlNode item in xmldoc.SelectNodes("root/AlgorithmInitParam/ChannelRegion/ChannelInfo"))
            {
                ret.Add(DriveWayRegion.LoadFromXml(item));
            };
            return ret;
        }
        private AccidentAlarmSubType GetAccidentAlarmSubTypeFromXML(string xml)
        {
            AccidentAlarmSubType ret = AccidentAlarmSubType.None;
            if (string.IsNullOrEmpty(xml))
                return ret;

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode CheckJam = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckJam/ChannelNum");
            if (Convert.ToUInt32(CheckJam.InnerText)>0)
                ret |= AccidentAlarmSubType.CheckJam;

            System.Xml.XmlNode Flux = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Flux/ChannelNum");
            if (Convert.ToUInt32(Flux.InnerText)>0)
                ret |= AccidentAlarmSubType.Flux;

            return ret;

        }
        private List<Point> GetSceneMarkFromXML(string type, string xml)
        {
            List<Point> ret = new List<Point>();
            if (string.IsNullOrEmpty(xml))
            {
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/" + type);
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("PointSet/Point"))
            {
                RegionPointList.Add(new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("X").InnerText), Convert.ToInt32(it.SelectSingleNode("Y").InnerText)));
            }
            RegionPointList.Insert(1, RegionPointList[4]);
            RegionPointList.Insert(4, RegionPointList[6]);

            ret = RegionPointList.Take(6).ToList();

            return ret;
        }
        private List<Tuple<Point, Point>> GetChangeChannelLineFromXML(string xml)
        {
            List<Tuple<Point, Point>> ret = new List<Tuple<Point, Point>>();
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/ChangeChannelLine");
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("LineSet/Line"))
            {
                Point p1 = new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(it.SelectSingleNode("StartPoint/Y").InnerText));
                Point p2 = new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(it.SelectSingleNode("EndPoint/Y").InnerText));
                ret.Add(new Tuple<Point, Point>(p1, p2));
            }

            return ret;
        }
        private List<Tuple<Point, Point>> GetPressChannelLineFromXML(string xml)
        {
            List<Tuple<Point, Point>> ret = new List<Tuple<Point, Point>>();
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/PressChannelLine");
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("LineSet/Line"))
            {
                Point p1 = new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(it.SelectSingleNode("StartPoint/Y").InnerText));
                Point p2 = new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(it.SelectSingleNode("EndPoint/Y").InnerText));
                ret.Add(new Tuple<Point, Point>(p1, p2));
            }

            return ret;
        }
        private Tuple<Point, Point> GetStopLineFromXML(string xml)
        {
            Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/StopLine");
            Point p1 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("StartPoint/Y").InnerText));
            Point p2 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("EndPoint/Y").InnerText));
            ret = new Tuple<Point, Point>(p1, p2);

            return ret;
        }
        private Tuple<Point, Point> GetSecondLineFromXML(string xml)
        {
            Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/SecondLine");
            Point p1 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("StartPoint/Y").InnerText));
            Point p2 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("EndPoint/Y").InnerText));
            ret = new Tuple<Point, Point>(p1, p2);

            return ret;
        }
        private Tuple<Point, Point> GetNoStraightLineFromXML(string xml)
        {
            Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/NoStraightLine");
            Point p1 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("StartPoint/Y").InnerText));
            Point p2 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("EndPoint/Y").InnerText));
            ret = new Tuple<Point, Point>(p1, p2);

            return ret;
        }
        private Tuple<Point, Point> GetNoLeftLineFromXML(string xml)
        {
            Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/NoLeftLine");
            Point p1 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("StartPoint/Y").InnerText));
            Point p2 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("EndPoint/Y").InnerText));
            ret = new Tuple<Point, Point>(p1, p2);

            return ret;
        }
        private Tuple<Point, Point> GetNoRightLineFromXML(string xml)
        {
            Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/NoRightLine");
            Point p1 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("StartPoint/Y").InnerText));
            Point p2 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("EndPoint/Y").InnerText));
            ret = new Tuple<Point, Point>(p1, p2);

            return ret;
        }
        private Tuple<Point, Point> GetNoTurnAroundLineFromXML(string xml)
        {
            Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
            if (string.IsNullOrEmpty(xml))
            {
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/NoTurnAroundLine");
            Point p1 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("StartPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("StartPoint/Y").InnerText));
            Point p2 = new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("EndPoint/X").InnerText), Convert.ToInt32(item.SelectSingleNode("EndPoint/Y").InnerText));
            ret = new Tuple<Point, Point>(p1, p2);

            return ret;
        }
        private List<Point> GetRoadRegionFromXML(string xml)
        {
            List<Point> ret = new List<Point>();
            if (string.IsNullOrEmpty(xml))
                return ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/RoadRegion/RoadInfo");
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("PointSet/Point"))
            {
                RegionPointList.Add(new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("X").InnerText), Convert.ToInt32(it.SelectSingleNode("Y").InnerText)));
            }
            ret = RegionPointList;

            return ret;
        }
        private bool GetAnalyseVehicleNoplatIncludeFromXML(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return true;

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            bool area = Convert.ToBoolean(xmldoc.SelectSingleNode("root/AlgorithmInitParam/CarPlate/CheckNoCarPlate").InnerText);

            return area;
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null)
                return;

            CheckBoxX barCheckItem = sender as CheckBoxX;
            if (!barCheckItem.Checked)
            {
                c.DriveWays[Convert.ToInt32(barCheckItem.Tag) - 11] = false;
            }
            else
            {
                c.SetDrawType((DrawGraphType)barCheckItem.Tag);
                c.DriveWays[Convert.ToInt32(barCheckItem.Tag) - 11] = true;
            }
        }
        private void checkButton2_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null)
                return;
            ButtonX barCheckItem = sender as ButtonX;
            c.SetDrawType((DrawGraphType)barCheckItem.Tag);

        }

        private void spinEdit_WorldSC_EditValueChanged(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || m_worldSC == null)
                return;

            DoubleInput edit = sender as DoubleInput;
            switch (edit.Tag.ToString())
            {
                case "1X": m_worldSC[0].X = Convert.ToInt32(edit.Value); break;
                case "1Y": m_worldSC[0].Y = Convert.ToInt32(edit.Value); break;
                case "2X": m_worldSC[1].X = Convert.ToInt32(edit.Value); break;
                case "2Y": m_worldSC[1].Y = Convert.ToInt32(edit.Value); break;
                case "3X": m_worldSC[2].X = Convert.ToInt32(edit.Value); break;
                case "3Y": m_worldSC[2].Y = Convert.ToInt32(edit.Value); break;
                case "4X": m_worldSC[3].X = Convert.ToInt32(edit.Value); break;
                case "4Y": m_worldSC[3].Y = Convert.ToInt32(edit.Value); break;
                case "5X": m_worldSC[4].X = Convert.ToInt32(edit.Value); break;
                case "5Y": m_worldSC[4].Y = Convert.ToInt32(edit.Value); break;
                case "6X": m_worldSC[5].X = Convert.ToInt32(edit.Value); break;
                case "6Y": m_worldSC[5].Y = Convert.ToInt32(edit.Value); break;
                default:
                    break;
            }
        }

        private void btnAnalyseRegion_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.AnalyseAreaEx);

        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.ImageSC);

        }

        private void btnChangeChannel_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.ChangeChannelLine);

        }

        private void btnPressChannel_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.PressChannelLine);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.StopLine);

        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.SecondLine);

        }

        private void btnNoStraight_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.NoStraightLine);

        }

        private void btnNoLeft_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.NoLeftLine);

        }

        private void btnNoRight_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.NoRightLine);

        }

        private void btnNoTurnAround_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.NoTurnAroundLine);

        }

        private void buttonEventParamX1_Click(object sender, EventArgs e)
        {
            ButtonX buttonEventParam = sender as ButtonX;

            FormChannelTrafficEventSetting f = new FormChannelTrafficEventSetting();
            f.ChannelParam = (TrafficeEventChannelParamInfo)(buttonEventParam.Tag as TrafficeEventChannelParamInfo).Clone();
            if (f.ShowDialog() == DialogResult.OK)
            {
                buttonEventParam.Tag = f.ChannelParam;
            }
        }


    }
}
