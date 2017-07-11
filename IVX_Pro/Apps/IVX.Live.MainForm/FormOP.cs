using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm
{
    public partial class FormOP : Form
    {
        public FormOP()
        {
            InitializeComponent();

            this.SizeChanged += FormOP_SizeChanged;
        }

        void FormOP_SizeChanged(object sender, EventArgs e)
        {
    //        foreach (Form item in this.MdiChildren)
    //{
    //    item.Size = this.ClientSize;
    //} 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //View.FormPeopleSearch f = new View.FormPeopleSearch();
            //f.ControlBox = false;
            //f.Text = "";
            //f.MdiParent = this;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //f.ShowIcon = false;
            //f.Dock = DockStyle.Fill;
            //f.Show();
            ucOPMain1.AddMoveObjSearch();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            View.FormLogin f = new View.FormLogin();
            f.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //View.FormVehicleSearch f = new View.FormVehicleSearch();
            //f.ControlBox = false;
            //f.Text = "";
            //f.MdiParent = this;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //f.ShowIcon = false;
            //f.Dock = DockStyle.Fill;
            //f.Show();
            ucOPMain1.AddVehicleSearch();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            ucOPMain1.AddRealtimeTask();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ucOPMain1.AddHistoryTask();

        }
    }
}
