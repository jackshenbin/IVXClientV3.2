using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucTaskAdd : UserControl
    {
        public event EventHandler OnOk;
        public event EventHandler OnCancel;
        private TaskAddViewModel m_viewModel;
        public ucTaskAdd()
        {
            InitializeComponent();
            dataGridViewX1.AutoGenerateColumns = false;
        }
        private void Init()
        {
            DataTable t = new DataTable();

            t.Columns.Add("Key", typeof(uint));
            t.Columns.Add("Value");
            t.Rows.Add(0, "默认");
            t.Rows.Add(300, "5分钟");
            t.Rows.Add(600, "10分钟");
            t.Rows.Add(1200, "20分钟");
            t.Rows.Add(1800, "30分钟");
            t.Rows.Add(int.MaxValue, "不切分");
            Column3.DataSource = Constant.VideoAnalyzeTypeInfo.Where
                (
                item => item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD 
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT
                ).ToArray();
            Column3.ValueMember = "NStatus";
            Column3.DisplayMember = "Name";

            Column12.DataSource = t;
            Column12.ValueMember = "Key";
            Column12.DisplayMember = "Value";

            BuildContextMenuStrip();
        }


        void BuildContextMenuStrip()
        {
            foreach (var item in (Column3.DataSource as VideoAnalyzeTypeInfo[]))
	        {
                if (item.Type == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    continue;
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = "算法设置为 "+item.Name;
                toolStripMenuItem.Tag = item;
                toolStripMenuItem.Click += toolStripMenuItem_Click;
                this.contextMenuStrip1.Items.Add( toolStripMenuItem);

	        } 
        }

        void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            foreach (DataGridViewRow item in dataGridViewX1.SelectedRows)
            {
                item.Cells["Column3"].Value = (toolStripMenuItem.Tag as VideoAnalyzeTypeInfo).NStatus;
            }
        }
        private void ucTaskAdd_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            Init();
            m_viewModel = new TaskAddViewModel();
            dataGridViewX1.DataSource = m_viewModel.TaskList;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (m_viewModel.Submit())
            {
                if (OnOk != null)
                    OnOk(this, null);
            }
        }
        public void AddFile(string fullname, string name, UInt64 filesize, uint type,DateTime st = new DateTime(), DateTime et = new DateTime(),uint splitTime=0)
        {
            if(st == new DateTime()) st = DateTime.Now;
            if (et == new DateTime()) et = DateTime.Now;

            m_viewModel.AddFile(fullname, name, filesize, type, (uint)E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF, st, et, splitTime);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this, null);

        }

        private void Column9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Column9.Index == e.ColumnIndex)
            {
                m_viewModel.DelFile(dataGridViewX1.Rows[e.RowIndex].DataBoundItem );
            }
        }
        private void labelX2_DragDrop(object sender, DragEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX p = sender as DevComponents.DotNetBar.Controls.DataGridViewX;

            if (e.Data.GetDataPresent(typeof(DevComponents.AdvTree.Node)))
            {
                DevComponents.AdvTree.Node node = (DevComponents.AdvTree.Node)e.Data.GetData(typeof(DevComponents.AdvTree.Node));

                if (!node.HasChildNodes)
                {
                    if (node.Cells[3].Text == "File")
                    {
                        string filefullname = node.Cells[1].Text;
                        string filename = node.Cells[0].Text;
                        ulong filesize = Convert.ToUInt64(node.Cells[2].Text);
                        AddFile(filefullname, filename, filesize, (uint)(filefullname.ToLower().StartsWith("ftp") ? 2 : 1));
                    }
                }

            }
            else if (e.Data.GetDataPresent(typeof(DevComponents.AdvTree.Node[])))
            {
                DevComponents.AdvTree.Node[] nodes = (DevComponents.AdvTree.Node[])e.Data.GetData(typeof(DevComponents.AdvTree.Node[]));
                foreach (DevComponents.AdvTree.Node node in nodes)
                {
                    if (!node.HasChildNodes )
                    {
                        if (node.Cells[3].Text == "File")
                        {
                            string filefullname = node.Cells[1].Text;
                            string filename = node.Cells[0].Text;
                            ulong filesize =Convert.ToUInt64(  node.Cells[2].Text);
                            AddFile(filefullname, filename, filesize, (uint)(filefullname.ToLower().StartsWith("ftp")?2:1));
                        }
                    }
                }

            }

        }

        private void labelX2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DevComponents.AdvTree.Node)))
            {
                e.Effect = DragDropEffects.Copy;

            }
            else if (e.Data.GetDataPresent(typeof(DevComponents.AdvTree.Node[])))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

    }
}
