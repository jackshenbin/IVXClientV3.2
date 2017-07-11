using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using System.Reflection;
using System.IO;

namespace IVX.Live.MainForm.View
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class FormGisMap : IVX.Live.MainForm.UILogics.FormBase
    {

        private ViewModel.GisMapViewModel m_viewModel;
        public FormGisMap()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }


        public override void UpdateUI()
        {
            webBrowser1.Refresh();
        }

        public override void Clear()
        {
            webBrowser1.Url = null;
        }



        public void WebInited()
        {
            foreach (var item in m_viewModel.CameraList)
	        {
                AddCamera(item.CameraName+"["+item.CameraID+"]",item.ID,item.PosCoordX,item.PosCoordY); 
	        } 
        }

        public void CameraClick(string id)
        {
            uint camid = Convert.ToUInt32(id);
            var cam = m_viewModel.CameraList.Single(item => item.ID == camid);
            if (cam != null)
            {
                if ((Program.PRODUCT_TYPE & Framework.Environment.E_PRODUCT_TYPE.PuDong_PRODUCT) > 0)
                {                FormAddRealTaskNoDIO f = new FormAddRealTaskNoDIO();
                    //FormAddRealTask f = new FormAddRealTask();
                    f.CameraID = cam.CameraID;
                    f.VideoName = cam.CameraName+"["+cam.CameraID+"]";
                    f.IP = cam.VideoSupplier.IP;
                    f.Port = cam.VideoSupplier.Port;
                    f.Protocol = cam.VideoSupplier.ProtocolType;
                    f.Channel = cam.VideoSupplierChannelID;
                    f.User = cam.VideoSupplier.UserName;
                    f.Pass = cam.VideoSupplier.Password;
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();

                }
                else
                {
                    //FormAddRealTaskNoDIO f = new FormAddRealTaskNoDIO();
                    FormAddRealTask f = new FormAddRealTask();
                    f.CameraID = cam.CameraID;
                    f.VideoName = cam.CameraName + "[" + cam.CameraID + "]";
                    f.IP = cam.VideoSupplier.IP;
                    f.Port = cam.VideoSupplier.Port;
                    f.Protocol = cam.VideoSupplier.ProtocolType;
                    f.Channel = cam.VideoSupplierChannelID;
                    f.User = cam.VideoSupplier.UserName;
                    f.Pass = cam.VideoSupplier.Password;
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
        }

        public void AddCamera(string name,uint id,float x,float y)
        {
            //webBrowser1.Document.InvokeScript("mark_pos", new object[] {"IPCamera34", "192.168.88.252_8000_1024_34_admin_12345", "31.127055", "121.278995" });
            webBrowser1.Document.InvokeScript("mark_pos", new object[] { name, id.ToString(), y.ToString("0.000000"), x.ToString("0.000000") });
        }

        private void FormGisMap_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            m_viewModel = new ViewModel.GisMapViewModel();
        }
        private void thOpenWeb()
        {
            //System.Threading.Thread.Sleep(500);
            DoOpenWeb();
        }
        private void DoOpenWeb()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(DoOpenWeb));
            }
            else
            {
                webBrowser1.Url = new Uri(Framework.Environment.GisMapPath);
                webBrowser1.ObjectForScripting = this;
            }
        }

        private void FormGisMap_Shown(object sender, EventArgs e)
        {
            new System.Threading.Thread(thOpenWeb).Start();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            textBoxItem1.Text = null;
        }

        private void buttonItemFlash_Click(object sender, EventArgs e)
        {
            m_viewModel = new ViewModel.GisMapViewModel();

            new System.Threading.Thread(thOpenWeb).Start();

        }
    }
}
