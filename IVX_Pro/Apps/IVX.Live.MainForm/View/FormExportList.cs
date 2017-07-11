using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using IVX.DataModel;
using IVX.Live.MainForm.Service;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormExportList : UILogics.FormBase
    {
        public FormExportList()
        {
            InitializeComponent();
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {
            BuildExportListTree();
        }


        private void BuildExportListTree()
        {
            advTree1.Nodes.Clear();
            advTree1.SuspendLayout();
            foreach (var info in VideoExportService.Instence.DownloadList)
            {
                Node node = new Node();
                node.Text = info.SessionId.ToString();
                //node.Image = Properties.Resources.bkpng;
                string stat = DataModel.Constant.DownloadStatusInfos.Single(item => item.DownloadStatus == info.Status).Name;
                string file = System.IO.Path.GetFileName(info.LocalSaveFilePath);
                node.Cells.Add(new Cell(file));
                node.Cells.Add(new Cell((info.ComposeProgress/10f).ToString("0.0")+"%"));
                node.Cells.Add(new Cell(stat));
                Cell c = new Cell();
                DevComponents.DotNetBar.ButtonItem buttonItem1 = new DevComponents.DotNetBar.ButtonItem(); 
                buttonItem1.Text = info.Status== VideoDownloadStatus.Download_Finish?"查看文件":"取消任务";
                buttonItem1.Tag = (DownloadInfo)info.Clone();
                buttonItem1.Click+=buttonItem1_Click;
                c.HostedItem = buttonItem1;
                node.Cells.Add(c);
                advTree1.Nodes.Add(node);
            }
            advTree1.ResumeLayout();
        }

        void buttonItem1_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem buttonItem1 = sender as DevComponents.DotNetBar.ButtonItem;
            if (buttonItem1 != null && buttonItem1.Tag is DownloadInfo)
            {
                var info = buttonItem1.Tag as DownloadInfo;
                if (info.Status == VideoDownloadStatus.Download_Finish)
                {
                    string fileName = info.LocalSaveFilePath;
                    if (File.Exists(fileName))
                    {
                        Process.Start("Explorer.exe", string.Format("/select,{0}", fileName));
                    }
                    else
                    {
                        string path = Path.GetDirectoryName(fileName);
                        Process.Start("Explorer.exe", path);
                    }

                }
                else
                {
                    WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<DelVideoDownloadEvent>().Publish(info);
                }
            }
        }

        private void FormExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BuildExportListTree();
        }

    }
}
