using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppUtil.Controls
{
    public partial class PageNavigatorEx : UserControl
    {
        public event EventHandler FirstClick;
        public event EventHandler PrivClick;
        public event EventHandler NextClick;
        public event EventHandler LastClick;

        public event Action<int> ItemClick;

        private int m_maxCount = 0;
        public int MaxCount { get { return m_maxCount; } set { m_maxCount = value; SetCountInfo(); } }

        private int m_index = 0;
        public int Index { get { return m_index; } set { m_index = value; SetCountInfo(); } }

        public PageNavigatorEx()
        {
            m_maxCount = 0; m_index = 0;
            InitializeComponent();
        }

        private void SetCountInfo()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetCountInfo));
            }
            else
            {
                labelX1.Text = string.Format("{0}/{1}", m_index, m_maxCount);
            }
        }
        private void buttonFirst_Click(object sender, EventArgs e)
        {
            if (m_maxCount == 0)
                return;

            Index = 1; 
            if (ItemClick != null)
                ItemClick(1);
            if (FirstClick != null)
                FirstClick(this, e);
        }

        private void buttonPriv_Click(object sender, EventArgs e)
        {
            if (m_maxCount == 0)
                return;

            int id = Math.Max(1, m_index - 1);
            Index = id; 
            if (ItemClick != null)
                ItemClick(id);
            if (PrivClick != null)
                PrivClick(this, e);

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (m_maxCount == 0)
                return;

            int id = Math.Min(m_maxCount, m_index + 1);
            Index = id;
            if (ItemClick != null)
                ItemClick(id);
            if (NextClick != null)
                NextClick(this, e);

        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            if (m_maxCount == 0)
                return;

            Index = m_maxCount;
            if (ItemClick != null)
                ItemClick(MaxCount);
            if (LastClick != null)
                LastClick(this, e);

        }

    }
}
