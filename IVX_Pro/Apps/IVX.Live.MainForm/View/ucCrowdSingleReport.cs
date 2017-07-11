using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace IVX.Live.MainForm.View
{
    public partial class ucCrowdSingleReport : UserControl
    {
        public ucCrowdSingleReport()
        {
            InitializeComponent();
            chart1.Series[0].ChartType = SeriesChartType.Line;
        }

        public void RefreshInfo(List<CrowdStatistic> crowdInfoList,CrowdTimeType type)
        {
            chart1.Series[0].Points.Clear();
            if (crowdInfoList.Count > 0)
            {
                IdLabel.Text = crowdInfoList[0].CameraID;
            }
            string curTimeTag = null;
            string[] dayStr = null;
            string[] str    = null;
            for (int i = 0; i < crowdInfoList.Count; i++)
            {
                switch (type)
                {
                    case CrowdTimeType.MONTH:
                        dayStr = crowdInfoList[i].TimeTag.Split('-');
                        curTimeTag = dayStr[1];
                        break;
                    case CrowdTimeType.DAY:
                        dayStr = crowdInfoList[i].TimeTag.Split('-');
                        curTimeTag =dayStr[2];
                        break;
                    case CrowdTimeType.HOUR:
                        str = crowdInfoList[i].TimeTag.Split(' ');
                        dayStr = str[0].Split('-');
                        curTimeTag = str[1];
                        break;
                    default:
                        break;
                }
                chart1.Series[0].Points.AddXY(curTimeTag, crowdInfoList[i].PeopleCountArg);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
