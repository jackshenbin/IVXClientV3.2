using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormEditRealtimeAnalyseParamNoDIO : IVX.Live.MainForm.UILogics.FormBase
    {
        public uint TaskId { get; set; }
        public E_VIDEO_ANALYZE_TYPE AlgthmType { get; set; }
        public string AnalyseParam { get; set; }
        public FormEditRealtimeAnalyseParamNoDIO(uint taskid, E_VIDEO_ANALYZE_TYPE algthmType, string analyseParam)
        {
            InitializeComponent();
            TaskId = taskid;
            AlgthmType = algthmType;
            AnalyseParam = analyseParam;
        }

        void ucEditTaskAnalyseParam1_OnCancel(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        void ucEditTaskAnalyseParam1_OnOk(object sender, EventArgs e)
        {
            AnalyseParam = ucEditTaskAnalyseParam1.AnalyseParam;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        private void FormSingleTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            ucEditTaskAnalyseParam1.SetAnalyseType( AlgthmType);
            ucEditTaskAnalyseParam1.AnalyseParam = AnalyseParam;
            ucEditTaskAnalyseParam1.OnOk += ucEditTaskAnalyseParam1_OnOk;
            ucEditTaskAnalyseParam1.OnCancel += ucEditTaskAnalyseParam1_OnCancel;

        }

        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private void buttonGrab_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
            ofd.InitialDirectory = Framework.Environment.PictureSavePath;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = ofd.FileName;
                Image temp = Image.FromFile(fileName);
                Image img = new Bitmap(temp);
                temp.Dispose();
                if (img != null)
                    ucEditTaskAnalyseParam1.DrawImage = img;
            }
        }

    }
}
