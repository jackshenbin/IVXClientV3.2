using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Diagnostics;

namespace AutoUpdateApp
{
    public partial class FormDownload : Form
    {
        public FormDownload()
        {
            InitializeComponent();
        }
        List<string> verlist =new List<string>();
        string VersionPath = "";
        string UpdateURL = "";

        public void SetValue(List<string> verlist,string VersionPath,string UpdateURL)
        {
            this.verlist = verlist;
            this.VersionPath = VersionPath;
            this.UpdateURL = UpdateURL;
        }

        public delegate void DownloadMessage(string msg);
        public delegate void DownloadClose(bool exitcode);

        private void CloseMe(bool exitcode)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DownloadClose(CloseMe),new object[]{exitcode});
            }
            else
            {
                if (exitcode) DialogResult = System.Windows.Forms.DialogResult.OK;
                else DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        private void UpdateMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DownloadMessage(UpdateMsg),new object []{msg});
            }
            else
            {
                label1.Text = msg;
            }
        }
        void Download()
        {
            try
            {
                WebClient wc = new WebClient();
                foreach (string ver in verlist)
                {
                    UpdateMsg("版本" + ver + "开始下载。。。");
                    if (!System.IO.Directory.Exists(VersionPath + ver + @"\"))
                        System.IO.Directory.CreateDirectory(VersionPath + ver + @"\");
                    wc.DownloadFile(new Uri(UpdateURL.TrimEnd(new char[] { '/' }) + @"/" + ver + @"/ver.list.xml"), VersionPath + ver + @"\ver.list.xml");
                    UpdateMsg("版本" + ver + "描述文件已下载。");
                    XmlDocument doc = new XmlDocument();
                    doc.Load(VersionPath + ver + @"\ver.list.xml");
                    XmlElement element = doc.DocumentElement;
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        UpdateMsg("文件" + node.InnerText + " 正在下载。。。");
                        System.IO.FileInfo fi = new System.IO.FileInfo(VersionPath + ver + @"\" + node.InnerText);
                        if (!fi.Directory.Exists) 
                            fi.Directory.Create();
                        wc.DownloadFile(new Uri(UpdateURL.TrimEnd(new char[] { '/' }) + @"/" + ver + @"/" + node.InnerText), VersionPath + ver + @"\" + node.InnerText);
                        System.Threading.Thread.Sleep(10);
                        UpdateMsg("文件" + node.InnerText + " 已下载。");

                    }
                    UpdateMsg("版本" + ver + "下载完成。");

                }
            CloseMe(true);
            }
            catch(Exception ex)
            {
                Trace.WriteLine("Download ex"+ ex.ToString());

                CloseMe(false);
            }
        }
        private void FormDownload_Shown(object sender, EventArgs e)
        {
           
             Trace.WriteLine("GetVersionFileList");
             System.Threading.Thread th = new System.Threading.Thread(Download);
             th.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseMe(false);
        }
    }
}
