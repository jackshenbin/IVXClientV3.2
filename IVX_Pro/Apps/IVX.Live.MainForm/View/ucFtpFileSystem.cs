using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAppUtil.Common;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucFtpFileSystem : ucFileSystemBase
    {
        private string ftproot = "";
        private FtpLib.FtpConnection m_ftpService = null;
        private FtpFileSystemViewModel m_viewModel;

        #region Constructors

        public ucFtpFileSystem()
        {
            InitializeComponent();
            
        }

        private void GetFtpInfo()
        {
            IVX.DataModel.FtpInfo info = Framework.Environment.FtpInfo;
            textBoxIP.Value = info.IP;
            textBoxPort.Text = info.Port.ToString();
            textBoxUser.Text = info.UserName;
            textBoxPass.Text = info.Password;
            checkBoxAnonymous.Checked = info.IsAnonymous;
        }
        private void SaveFtpInfo()
        {
            IVX.DataModel.FtpInfo info = new DataModel.FtpInfo();
            info.IP = textBoxIP.Text;
            info.Port = Convert.ToUInt32( textBoxPort.Text );
            info.UserName=textBoxUser.Text; 
            info.Password=textBoxPass.Text ;
            info.IsAnonymous = checkBoxAnonymous.Checked;
            Framework.Environment.FtpInfo = info;
        }

        #endregion

        #region Private helper functions

        //@"ftp://public:public123$@192.168.42.6/"
        //只能支持单个FTP站点
        public bool InitHttpRoot(DataModel.VideoSupplierDeviceInfo item)
        {
            string strformat = string.IsNullOrEmpty(item.UserName) ? "{0}://{3}:{4}/{5}" : "{0}://{1}:{2}@{3}:{4}/{5}";
            string urlroot = string.Format(strformat
                , (item.ProtocolType == DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_FTP_FILE) ? "ftp" : "http"
                , item.UserName
                , item.Password
                , item.IP
                , item.Port
                , item.Rest);

            ftproot = urlroot.TrimEnd('/') + "/";
            GetDirectoryList = GetFtpDirectoryList;
            GetFileList = GetFtpFileList;
            ClearRoot();
            InitRoot(ftproot, ftproot);

            //string ftproot = @"ftp://public:public123$@192.168.42.6/"; 

            m_ftpService = new FtpLib.FtpConnection(item.IP , (int)item.Port,item.UserName, item.Password);
            m_ftpService.Open();
            try
            {
                m_ftpService.Login();
                //m_ftpService.SetCurrentDirectory(textBoxPath.Text);
                SaveFtpInfo();
                return true;
            }
            catch(Exception ex)
            {                
                DevComponents.DotNetBar.MessageBoxEx.Show("无法连接FTP服务器，请检查地址及用户名密码。 "+ex.Message, Framework.Environment.PROGRAM_NAME);
                return false;
            }
        }

        List<string> GetFtpDirectoryList(string path)
        {
            string cd = path.Replace(ftproot, "").Trim('/');
            if (cd == "") cd = "/";
            else cd = "/" + cd;
            m_ftpService.SetCurrentDirectory(cd);

            var list= m_ftpService.GetDirectories(cd);
            List<string > ret = new List<string>();
            foreach (var item in list)
            {
                ret.Add(item.Name);
            }
            return ret;
        }

        List<FileInfo> GetFtpFileList(string path)
        {
            string cd = path.Replace(ftproot, "").Trim('/');
            if (cd == "") cd = "/";
            else cd = "/" + cd;
            m_ftpService.SetCurrentDirectory(cd);
            var ftplist = m_ftpService.GetFiles();
            List<FileInfo> list = new List<FileInfo>();
            foreach (var item in ftplist)
            {
                long size = m_ftpService.GetFileSize(item.Name);
                list.Add(new FileInfo() { FileSize = (ulong)size, IsDir = false, Name = item.Name });
            }
            return list;
        }

        #endregion

        private void ucFtpFileSystem_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new FtpFileSystemViewModel();
            GetFtpInfo();
        }

        private void buttonGetFtpFile_Click(object sender, EventArgs e)
        {
            string user = checkBoxAnonymous.Checked ? "anonymous" : textBoxUser.Text;
            string pass = checkBoxAnonymous.Checked ? "anonymous" : textBoxPass.Text;
            bool ret = InitHttpRoot(new DataModel.VideoSupplierDeviceInfo
            {
                DeviceName = string.Format("ftp://{0}:{1}", textBoxIP.Text, textBoxPort.Text),
                Id = 0,
                IP = textBoxIP.Text,
                LoginSessionId = 0,
                Password = pass,
                Port = (uint)textBoxPort.Value,
                ProtocolType = DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_FTP_FILE,
                Rest = "",
                UserName = user,
            });
            if(ret)
                expandablePanel1.Expanded = false;
        }

        private void checkBoxAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUser.Enabled = textBoxPass.Enabled = !checkBoxAnonymous.Checked;
        }


    }
}
