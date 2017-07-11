using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAppUtil.Common;
using System.IO;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucPlatFileSystem : UserControl
    {
        const string NullValue = "无数据...";
        public event EventHandler FilesDoubleClicked;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        #region Constructors

        public ucPlatFileSystem()
        {
            InitializeComponent();
        }


        #endregion

        #region Private helper functions

        public void InitPlatRoot()
        {

            //list.Add( new DataModel.VideoSupplierDeviceInfo()
            //{
            //    //DeviceName = "192.168.88.241`37777`1025`admin`admin",
            //    DeviceName = "haikang://admin:12345@192.168.88.252:8000",
            //    Id = 0,
            //    IP = "192.168.88.252",
            //    LoginSessionId = 0,                

            //    Password = "12345",
            //    Port = 8000,
            //    ProtocolType =  DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_DEV,
            //    UserName = "admin",

            //});

            List<DataModel.VideoSupplierDeviceInfo> list = Framework.Container.Instance.CommService.GET_NET_STORE_LIST();
            foreach (DataModel.VideoSupplierDeviceInfo item in list)
            {
                if (item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_BCSYS_PLAT
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_BCVIS_PLAT_V1
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DH_DEV
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_H3C_PLAT
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_DEV
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_PLAT
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HT_PLAT
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NETPOSA_PLAT
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL
                   && item.ProtocolType != E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_SANYO_IPC_DEV)
                    continue;

                DevComponents.AdvTree.Node snode = new DevComponents.AdvTree.Node();
                snode.Expanded = false;
                snode.ImageIndex = 3;
                snode.Text = item.DeviceName;
                snode.Cells.Add(new DevComponents.AdvTree.Cell(item.DeviceName));
                snode.Cells.Add(new DevComponents.AdvTree.Cell("0"));
                snode.Cells.Add(new DevComponents.AdvTree.Cell("Plat"));
                snode.Nodes.Add(new DevComponents.AdvTree.Node(NullValue));
                snode.NodeDoubleClick += new EventHandler(snode_NodeDoubleClick);
                snode.Tag = item;
                treeListFtpFile.Nodes.Add(snode);
                //InitCameraList(snode);
            }

        }

        private void InitCameraList(DevComponents.AdvTree.Node pNode)
        {
            if (pNode.Cells[3].Text != "Plat")
                return;

            if (pNode.Tag is ConfigServices.DIOService)
                return;

            DataModel.VideoSupplierDeviceInfo info = pNode.Tag as DataModel.VideoSupplierDeviceInfo;
            if (info == null)
                return;

            ConfigServices.DIOService server = new ConfigServices.DIOService(Framework.Container.Instance.IVXProtocol);
            server.Login(info.ProtocolType, info.IP, (ushort)info.Port, info.UserName, info.Password);

            //ConfigServices.DIOService server = pNode.Tag as ConfigServices.DIOService;
            pNode.Tag = server;
            treeListFtpFile.SuspendLayout();

            try
            {
                var list = server.GetChannelList();
                pNode.Nodes.Clear();

                foreach (IVX.Live.ConfigServices.Interop.TDIO_ChannelInfo item in list)
                {
                    DevComponents.AdvTree.Node snode = new DevComponents.AdvTree.Node();
                    snode.Expanded = false;
                    snode.Name = "Camera";
                    snode.ImageIndex = 1;
                    snode.Text = item.szChannelName;
                    snode.Cells.Add(new DevComponents.AdvTree.Cell(item.szChannelId));
                    snode.Cells.Add(new DevComponents.AdvTree.Cell("0"));
                    snode.Cells.Add(new DevComponents.AdvTree.Cell("Camera"));
                    snode.Nodes.Add(new DevComponents.AdvTree.Node(NullValue));
                    snode.NodeDoubleClick += new EventHandler(snode_NodeDoubleClick);
                    
                    snode.Tag = item;
                    pNode.Nodes.Add(snode);
                }


            }
            catch (Exception)
            {
                //Framework.Container.Instance.InteractionService.ShowMessageBox("无法连接FTP服务器，或获取HTTP文件列表失败。", Framework.Environment.PROGRAM_NAME);
                return;
            }
            treeListFtpFile.ResumeLayout();
        }

        private void InitFileList(DateTime st, DateTime et)
        {
            foreach (DevComponents.AdvTree.Node node in treeListFtpFile.SelectedNodes)
            {
                if (node.Cells[3].Text == "Camera")
                {
                    node.Nodes.Clear();
                    //node.Expand();
                    ConfigServices.DIOService server = node.Parent.Tag as ConfigServices.DIOService;
                    ConfigServices.Interop.TDIO_ChannelInfo channel = (ConfigServices.Interop.TDIO_ChannelInfo)node.Tag;
                    foreach (ConfigServices.Interop.TDIO_StrmFileInfo item in server.GetFileListByTime(channel,st, et))
                    {
                        DevComponents.AdvTree.Node snode = new DevComponents.AdvTree.Node();
                        snode.Expanded = false;
                        snode.ImageIndex = 0;
                        snode.Text = string.Format("{0}-{1}", DataModel.Common.ConvertLinuxTime(item.tStart).ToString("yyyyMMddHHmmss"), DataModel.Common.ConvertLinuxTime(item.tStop).ToString("yyyyMMddHHmmss"));
                        snode.Cells.Add(new DevComponents.AdvTree.Cell(item.szFileId));
                        snode.Cells.Add(new DevComponents.AdvTree.Cell(item.qwFileSize.ToString()));
                        snode.Cells.Add(new DevComponents.AdvTree.Cell("File"));
                        snode.NodeDoubleClick += new EventHandler(snode_NodeDoubleClick);
                        snode.Tag = item;
                        node.Nodes.Add(snode);
                    }
                    
                     
                }
            }
        }

        #endregion



        void snode_NodeDoubleClick(object sender, EventArgs e)
        {


            List<object> m_SelectedFiles = new List<object>();

            DevComponents.AdvTree.Node snode = sender as DevComponents.AdvTree.Node;
            //DevExpress.XtraTreeList.TreeListHitInfo info = treeListFtpFile.CalcHitInfo(e.Location);
            if (snode != null)
            {
                if (snode.Cells[3].Text == "File")
                {
                    foreach (DevComponents.AdvTree.Node node in treeListFtpFile.SelectedNodes)
                    {
                        if (node.Cells[3].Text == "File")
                        {
                            ConfigServices.Interop.TDIO_StrmFileInfo file = (ConfigServices.Interop.TDIO_StrmFileInfo)node.Tag;
                            ConfigServices.Interop.TDIO_ChannelInfo channel = (ConfigServices.Interop.TDIO_ChannelInfo)node.Parent.Tag;
                            ConfigServices.DIOService server = (ConfigServices.DIOService)node.Parent.Parent.Tag;

                            string filefullname = string.Format("{0}`{1}`{2}`{3}`{4}`{5}",server.m_currIP,server.m_currPort,(int)server.m_connType,server.m_currUser,server.m_currPass,channel.szChannelId);
                            string filename = node.Cells[0].Text;
                            string filesize = node.Cells[2].Text;
                            string st = file.tStart.ToString();
                            string et = file.tStop.ToString();
                            m_SelectedFiles.Add(new object[] { filefullname, filename, filesize,st,et });
                        }
                    }

                    if (m_SelectedFiles.Count > 0 && FilesDoubleClicked != null)
                    {
                        FilesDoubleClicked(m_SelectedFiles, EventArgs.Empty);
                    }
                }
                //else if (snode.Cells[3].Text == "Plat")
                //{
                //    InitCameraList(snode); 
                //}
                //else
                //{
                //    InitFileList(dateTimeInput1.Value, dateTimeInput2.Value);
                //}
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            InitFileList(dateTimeInput1.Value, dateTimeInput2.Value);
        }

        private void ucPlatFileSystem_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            dateTimeInput1.Value = DateTime.Now.AddHours(-1);
            dateTimeInput2.Value = DateTime.Now;
        }

        private void treeListFtpFile_BeforeExpand(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {

            if (e.Node != null)
            {
                if (e.Node.Cells[3].Text == "Plat")
                {
                    InitCameraList(e.Node);
                }
                else if(e.Node.Cells[3].Text == "Camera")
                {
                    InitFileList(dateTimeInput1.Value, dateTimeInput2.Value);
                }
            }

        }

    }
}
