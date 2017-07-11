using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSearchResultPanel : UserControl
    {
        SearchResultPanelViewModel m_viewModel;
        public ucSearchResultPanel()
        {
            InitializeComponent();
        }

        private void ucSearchResultPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            
        }
        public void InitPanel(DataModel.SearchType searchType)
        { 

            m_viewModel = new SearchResultPanelViewModel(searchType);
            m_viewModel.SearchBegin += m_viewModel_SearchBegin;
        }

        void m_viewModel_SearchBegin(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<object, EventArgs>(m_viewModel_SearchBegin), sender, e);
            }
            else
            {
                for (int i = superTabControl1.Controls.Count - 1; i >= 0; i--)
                {
                    if (superTabControl1.Controls[i] is DevComponents.DotNetBar.SuperTabControlPanel)
                    {
                        if (superTabControl1.Controls[i].Controls.Count > 0 && superTabControl1.Controls[i].Controls[0] is ucSingleSearchResultPanel)
                        {
                            (superTabControl1.Controls[i].Controls[0] as ucSingleSearchResultPanel).Clear();
                            (superTabControl1.Controls[i].Controls[0] as ucSingleSearchResultPanel).Dispose();
                        }
                        superTabControl1.Controls.RemoveAt(i);
                    }
                }
                superTabControl1.Tabs.Clear();
                foreach (var item in m_viewModel.SearchItems)
                {
                    DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
                    DevComponents.DotNetBar.SuperTabItem superTabItem = new DevComponents.DotNetBar.SuperTabItem();
                    ucSingleSearchResultPanel ucSingleSearchResultPanel = new ucSingleSearchResultPanel(item.SearchHandle,item.TaskId);

                    superTabControlPanel.Location = new System.Drawing.Point(0, 26);
                    superTabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    superTabControlPanel.Size = new System.Drawing.Size(979, 624);
                    superTabControlPanel.TabIndex = 1;
                    superTabControlPanel.Name = "superTabControlPanel_" + item.ToString();
                    superTabControlPanel.Text = "superTabControlPanel_" + item.ToString();
                    superTabControlPanel.TabItem = superTabItem;

                    ucSingleSearchResultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    ucSingleSearchResultPanel.Location = new System.Drawing.Point(0, 0);
                    ucSingleSearchResultPanel.Size = new System.Drawing.Size(979, 624);
                    ucSingleSearchResultPanel.TabIndex = 0;
                    ucSingleSearchResultPanel.Name = "ucSingleSearchResultPanel_" + item.ToString();
                    ucSingleSearchResultPanel.Tag = item.ToString();
                    ucSingleSearchResultPanel.SearchBegin();
                    ucSingleSearchResultPanel.ClearSearch += ucSingleSearchResultPanel_ClearSearch;

                    superTabControlPanel.Controls.Add(ucSingleSearchResultPanel);


                    superTabItem.AttachedControl = superTabControlPanel;
                    superTabItem.GlobalItem = false;
                    superTabItem.Name = "superTabItem_" + item.ToString();
                    superTabItem.Text = item.ToString();
                    superTabControl1.Controls.Add(superTabControlPanel);

                    superTabControl1.Tabs.Add(superTabItem);


                }
                superTabControl1.Refresh();
            }
        }
        void ucSingleSearchResultPanel_ClearSearch(object sender, EventArgs e)
        {
            if (sender is ucSingleSearchResultPanel)
            {
                (sender as ucSingleSearchResultPanel).Clear();
                (sender as ucSingleSearchResultPanel).Dispose();
                string name = (sender as ucSingleSearchResultPanel).Tag.ToString();
                superTabControl1.Tabs.Remove("superTabItem_" + name);
                superTabControl1.Controls.RemoveByKey("superTabControlPanel_" + name);
            }

        }


        internal void Clear()
        {
            foreach (Control item in superTabControl1.Controls)
            {
                foreach (Control subitem in item.Controls)
                {
                ucSingleSearchResultPanel ucSingleSearchResultPanel = subitem as ucSingleSearchResultPanel;
                if (ucSingleSearchResultPanel != null)
                    ucSingleSearchResultPanel.Clear();
                }
            }
            superTabControl1.Controls.Clear();

            m_viewModel.Clear();
        }
    }
}
