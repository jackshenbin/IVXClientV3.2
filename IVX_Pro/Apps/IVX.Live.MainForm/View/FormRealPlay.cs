using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormRealPlay : IVX.Live.MainForm.UILogics.FormBase
    {
        RealPlayViewModel m_viewModel;
        public DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Channel { get; set; }
        public string VideoName { get { return Text; } set { Text = value; } }


        public FormRealPlay()
        {
            InitializeComponent();
            UseMdiDefaultWindow(false);
            SetWindowSizeable(false);
            labelX2.HandleCreated += new EventHandler(labelX2_HandleCreated);
        }

        void labelX2_HandleCreated(object sender, EventArgs e)
        {
            new System.Threading.Thread(thPlay).Start();
        }

        private void thPlay()
        { DoPlay(); }

        private void DoPlay()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(DoPlay));
            }
            else
            {
                m_viewModel.PlayRealTime(Protocol, IP, (ushort)Port, User, Pass, labelX2.Handle, Channel);
            }
        }

        private void FormRealPlay_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new RealPlayViewModel();
        }
    }
}
