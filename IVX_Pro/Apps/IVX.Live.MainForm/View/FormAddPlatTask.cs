using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View
{
    public partial class FormAddPlatTask : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormAddPlatTask()
        {
            InitializeComponent();
            this.ucTaskAdd1.OnOk += ucTaskAdd1_OnOk;
            this.ucTaskAdd1.OnCancel += ucTaskAdd1_OnCancel;
            this.ucPlatFileSystem1.FilesDoubleClicked += new EventHandler(ucPlatFileSystem1_FilesDoubleClicked);
            
        }

        void ucTaskAdd1_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        void ucTaskAdd1_OnOk(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        /*<TaskInfo>
  <TaskName>yangli3.avi</TaskName> 
  <TaskType>2</TaskType> 
  <FileType>2</FileType> 
  <FileSize>183052338</FileSize> 
  <DeviceName /> 
  <DeviceType>0</DeviceType> 
  <ProtocolType>0</ProtocolType> 
  <DeviceIP /> 
  <DevicePort>0</DevicePort> 
  <LoginUser /> 
  <LoginPwd /> 
  <ChannelID /> 
  <CameraID /> 
  <OriFilePath>ftp://192.168.42.56:admin@192.168.42.6:21/d:/调试版本库/192.168.42.56/platdemo/20151116-1739/yangli3.avi</OriFilePath> 
  <AlgthmType>1</AlgthmType> 
  <StartTime>123000001</StartTime> 
  <EndTime>120223456</EndTime> 
  <AnalyseParam /> 
  </TaskInfo>
         * 
         * */
        private void expandableSplitter1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {

        }

        private void FormAddEditTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;


            ucPlatFileSystem1.InitPlatRoot();

        }
        void ucPlatFileSystem1_FilesDoubleClicked(object sender, EventArgs e)
        {
            List<object> selectedfiles = sender as List<object>;
            if (selectedfiles == null || selectedfiles.Count == 0)
                return;
            StringBuilder sb = new StringBuilder();
            foreach (var item in selectedfiles)
            {
                object[] vals = item as object[];
                sb.AppendLine(string.Format("filefullname:{0},filename:{1},filesize:{2},st:{3},et:{4}", vals[0], vals[1], vals[2],vals[3],vals[4]));
                ucTaskAdd1.AddFile(vals[0].ToString(), vals[1].ToString(), Convert.ToUInt64(vals[2]), 3, DataModel.Common.ConvertLinuxTime(Convert.ToUInt32(vals[3])), DataModel.Common.ConvertLinuxTime(Convert.ToUInt32(vals[4])));
            }
        }



        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }
    }
}
