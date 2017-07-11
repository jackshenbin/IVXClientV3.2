using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.Live.MainForm.View
{
    public class FilterableTreeList : DevComponents.AdvTree.AdvTree
    {
        private string m_FilterText;


        private bool m_isMatchInContainMode = true;


        private int m_level2Filter = -1;

        public int Level2Filter
        {
            get { return m_level2Filter; }
            set { m_level2Filter = value; }
        }
        public bool IsMatchInContainMode
        {
            get { return m_isMatchInContainMode; }
            set { m_isMatchInContainMode = value; }
        }

        public string FilterText
        {
            get
            {
                return m_FilterText;
            }
            set
            {
                if (string.Compare(m_FilterText, value, true) != 0)
                {
                    m_FilterText = value;
                }
            }
        }
        DevComponents.DotNetBar.Controls.TextBoxX buttonEdit1;
        public FilterableTreeList()
            : base()
        {
            InitButton();
            this.VScrollBarVisible = true;
            
            KeyUp += FilterableTreeList_KeyUp;
        }



        void FilterableTreeList_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == System.Windows.Forms.Keys.Enter)
                DoFilter();

        }

        private void InitButton()
        {
            buttonEdit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            // buttonEdit1
            // 
            //this.buttonEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEdit1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.buttonEdit1.Location = this.Location;
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.AutoSize = false;
            this.buttonEdit1.WatermarkText = "过滤点位";
            this.buttonEdit1.Size = new System.Drawing.Size(this.Width-18, 22);
            this.buttonEdit1.TabIndex = 3;
            this.buttonEdit1.TextChanged += buttonEdit1_TextChanged;
            this.Controls.Add(buttonEdit1);
            buttonEdit1.BringToFront();
            buttonEdit1.Visible = false;
        }

        void buttonEdit1_TextChanged(object sender, EventArgs e)
        {
            DoFilter();
        }

        #region Private helper functions

        private bool IsMatch(DevComponents.AdvTree.Node node)
        {
            bool matched = true;
            if (Columns.Count <= 0)
                return true ;
            if (m_level2Filter >=0 && node.Level != m_level2Filter)
                return true ;
            if (!string.IsNullOrEmpty(m_FilterText))
            {
                string nodeVal = node.Cells[0].Text;
                if (m_isMatchInContainMode)
                {
                    matched = nodeVal.Contains(this.m_FilterText);
                }
                else
                {
                    matched = nodeVal.StartsWith(this.m_FilterText);
                }
            }

            return matched;
        }


        #endregion

        void FilterNodes(DevComponents.AdvTree.Node node)
        {
            foreach (DevComponents.AdvTree.Node item in node.Nodes)
            {
                if (item.HasChildNodes)
                {
                    FilterNodes(item);
                }
                else
                {
                    bool matched = IsMatch(item);

                    item.Visible = true;
            
                    if (matched)
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
            }

        }


        private void DoFilter()
        {
            string text = buttonEdit1.Text.Trim();
            if (this.IsMatchInContainMode != true
                || string.Compare(this.FilterText, text, false) != 0)
            {
                this.IsMatchInContainMode = true;
                this.FilterText = text;

                foreach (DevComponents.AdvTree.Node item in base.Nodes)
                {
                    this.FilterNodes(item);
                }
            }
        }

    }
}
