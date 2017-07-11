using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm
{
    public partial class ucOPMain : UserControl
    {
        public ucOPMain()
        {
            InitializeComponent();
        }


        public void AddMoveObjSearch()
        {
            View.FormAllMoveObjSearch f = new View.FormAllMoveObjSearch();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            superTabControlPanel1.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();
        }
        public void AddVehicleSearch()
        {
            View.FormVehicleSearch f = new View.FormVehicleSearch();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            superTabControlPanel2.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        public void AddCameraManager()
        { 
        }

        public void AddRealtimeTask()
        {
            View.FormRealtimeTaskManagementMA f = new View.FormRealtimeTaskManagementMA();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            superTabControlPanel6.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();

        }
        public void AddHistoryTask()
        {
            View.FormTaskManagementMA f = new View.FormTaskManagementMA();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            superTabControlPanel7.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();

        }
    
    }
}
