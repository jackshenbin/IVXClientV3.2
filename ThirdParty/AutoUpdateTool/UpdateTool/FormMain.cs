using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;

namespace UpdateTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            LoadVersion();
        }
        bool isUpdate = false;
        public struct Version
        {
            public string ver;
            public int type;
            public string date;
            public string discription;
            public List<string> paths;
            public bool enable;
        }
        private void AddNewVersion()
        {
            FormAdd f = new FormAdd();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (DevComponents.AdvTree.Node n in advTreeVersion.Nodes)
                {
                    if (n.Text == f.Version)
                    {
                        MessageBox.Show("当前添加的版本 V"+f.Version+" 已经存在。", "版本添加");
                        return;
                    }
                }
                Version v = new Version();
                v.ver = f.Version;
                v.date = f.Date.ToString("yyyy-MM-dd HH:mm:ss");
                v.discription = f.Discription;
                v.type = f.Type;
                v.paths = new List<string>();
                v.enable = false;
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                node.Text = v.ver;
                node.ImageIndex = v.type;
                node.Tag = v;
                node.NodeClick += new EventHandler(TreeNodeClick);
                advTreeVersion.Nodes.Add(node);
                if(!System.IO.Directory.Exists(Application.StartupPath + @"\" + v.ver))
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\" + v.ver);
                SaveVersionFileList(v);
            }
            
        }
        private void LoadVersion()
        {
            advTreeVersion.Nodes.Clear();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Application.StartupPath + @"\ver.xml");
            XmlElement xmlelement = xmldoc.DocumentElement;
            foreach (XmlNode node in xmlelement.ChildNodes)
            {

                DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                
                Version v = LoadVersion(node.InnerText);
                n.Text = v.ver;
                if(node.Attributes["en"].Value.ToString() != "1") n.Style= DevComponents.AdvTree.NodeStyles.Red;
                n.ImageIndex =int.Parse( node.Attributes["type"].InnerText);
                n.NodeClick += new EventHandler(TreeNodeClick);
                v.enable = (node.Attributes["en"].Value.ToString() == "1");
                v.type = int.Parse(node.Attributes["type"].InnerText);
                n.Tag = v;
                advTreeVersion.Nodes.Add(n);
            }
            
        }
        private Version LoadVersion(string ver)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + @"\" + ver  + @"\ver.list.xml");
            XmlElement element = doc.DocumentElement;


            Version v = new Version();
            v.ver = element.Attributes["ver"].InnerText;
            v.date = element.Attributes["date"].InnerText;
            v.discription = element.Attributes["discription"].InnerText;
            v.paths = new List<string>();
            foreach (XmlNode file in element.ChildNodes)
            {
                v.paths.Add(file.InnerText);
            }
            return v;
        }

        private void ShowVersion(Version v)
        { 
            toolStripButtonSendoutVersion.Text = (v.enable ? "取消发布" : "发布");
            string[] vers= v.ver.Split(new string []{"."},StringSplitOptions.None);
            integerInput1.Value = int.Parse(vers[0]);
            integerInput2.Value = int.Parse(vers[1]);
            integerInput3.Value = int.Parse(vers[2]);
            integerInput4.Value = int.Parse(vers[3]);
            dateTimePicker1.Value = DateTime.Parse(v.date);
            textBoxDiscription.Text = v.discription;
            if (v.type == 0) radioButtonType1.Checked = true;
            else if (v.type == 1) radioButtonType2.Checked = true;
            else if (v.type == 2) radioButtonType3.Checked = true;
            listViewVersionFileList.Items.Clear();
            ImageList images = new ImageList();
            listViewVersionFileList.SmallImageList = images;
            foreach (string file in v.paths)
            {
                ListViewItem item = new ListViewItem();
                System.IO.FileInfo f = new System.IO.FileInfo(Application.StartupPath + @"\" + v.ver + @"\" + file);
                images.Images.Add(file,Icon.ExtractAssociatedIcon(f.FullName));
                item.ImageKey = file;
                item.Text = file;
                item.SubItems.Add(f.Length.ToString());
                item.SubItems.Add(f.Extension);
                MD5 md5 = MD5.Create();
                md5.Initialize();
                byte[] md5buf = md5.ComputeHash(f.OpenRead());
                string md5str = "";
                foreach (byte b in md5buf)
                {
                    md5str += b.ToString("X2");
                }
                item.SubItems.Add(md5str);
                listViewVersionFileList.Items.Add(item);
                //listViewEx1.Items.Add(item);
            }
            isUpdate = false;
            buttonSaveVersionFileList.Enabled = false;
        }
        void TreeNodeClick(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = (DevComponents.AdvTree.Node)sender;
            Version v = (Version)n.Tag;
            isUpdate = false;
            ShowVersion(v);
        }

        private void ButtonNewVersion_Click(object sender, EventArgs e)
        {
            AddNewVersion();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
            Version v = (Version)n.Tag;
            v.enable = !v.enable;
            toolStripButtonSendoutVersion.Text = (v.enable ? "取消发布" : "发布");
            if (!v.enable) 
                n.Style = DevComponents.AdvTree.NodeStyles.Red;
            else
                n.Style = null;
            n.Tag = v;
            SaveVersion();
        }

        private void ButtonLoadVersion_Click(object sender, EventArgs e)
        {
            LoadVersion();
        }

        private void ButtonSaveVersion_Click(object sender, EventArgs e)
        {
            SaveVersion();
        }
        private bool SaveVersionFileList(Version v)
        {

            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Indent = true;
            settings.IndentChars = ("\t");
            settings.Encoding = Encoding.GetEncoding("utf-8");
            settings.OmitXmlDeclaration = false;

            System.IO.FileInfo f = new System.IO.FileInfo(Application.StartupPath + @"\" + v.ver + @"\ver.list.xml");
            System.IO.Stream s = null;
            int i=0;
            while(i<100)
            {
                
                try
                {
                     s = f.Open(System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    break;
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                    i++;
                }
            }
            if (s == null)
            {
                MessageBox.Show("文件写入失败，未保存", "版本保存");
                return false;
            }



            XmlWriter xw = XmlWriter.Create(s, settings);

            XmlDocument doc = new XmlDocument();
            XmlElement newElem = doc.CreateElement("application");
            newElem.SetAttribute("ver", v.ver);
            newElem.SetAttribute("date", v.date);
            newElem.SetAttribute("discription", v.discription);
            foreach (string  file in v.paths)
            {
                XmlElement newElemfile = doc.CreateElement("file");
                newElemfile.InnerText = file;
                newElem.AppendChild(newElemfile);
            }

            doc.AppendChild(newElem);

            // Save the document to a file. White space is
            // preserved (no white space).
            doc.PreserveWhitespace = true;
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + @"\" + v.ver + @"\ver.list.xml"))
                    System.IO.File.SetAttributes(Application.StartupPath + @"\" + v.ver + @"\ver.list.xml", System.IO.FileAttributes.Normal);

                doc.WriteTo(xw);
                xw.Flush();

            }
            catch
            {
            }

            return true;
        }

        private bool SaveVersion()
        {

            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Indent = true;
            settings.IndentChars = ("\t");
            settings.Encoding = Encoding.GetEncoding("utf-8");
            settings.OmitXmlDeclaration = false;

            System.IO.FileInfo f = new System.IO.FileInfo(Application.StartupPath + @"\ver.xml");
            System.IO.Stream s = null;
            int i = 0;
            while (i < 10)
            {

                try
                {
                    s = f.Open(System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    break;
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                    i++;
                }
            }
            if (s == null) return false;



            XmlWriter xw = XmlWriter.Create(s, settings);

            XmlDocument doc = new XmlDocument();
            XmlElement newElem = doc.CreateElement("application");

            foreach (DevComponents.AdvTree.Node n in advTreeVersion.Nodes)
            {
                Version v = (Version)n.Tag;
                XmlElement newElemver = doc.CreateElement("ver");
                newElemver.SetAttribute("en",v.enable?"1":"0");
                newElemver.SetAttribute("type",v.type.ToString());
                newElemver.InnerText = v.ver;
                newElem.AppendChild(newElemver);
            }

            doc.AppendChild(newElem);

            // Save the document to a file. White space is
            // preserved (no white space).
            doc.PreserveWhitespace = true;
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + @"\ver.xml"))
                    System.IO.File.SetAttributes(Application.StartupPath + @"\ver.xml", System.IO.FileAttributes.Normal);

                doc.WriteTo(xw);
                xw.Flush();
                s.Close();
            }
            catch
            {
            }

            return true;
        }

        private void ButtonSaveVersionFileList_Click(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
            Version v = (Version)n.Tag;
            v.discription = textBoxDiscription.Text;
            v.date = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (radioButtonType1.Checked) v.type = 0;
            else if (radioButtonType2.Checked) v.type = 1;
            else if (radioButtonType3.Checked) v.type = 2;
            else v.type = 0;

            SaveVersionFileList(v);
                isUpdate = false;
                buttonSaveVersionFileList.Enabled = false;
        }

        private void ButtonAddVersionFile_Click(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
            Version v = (Version)n.Tag;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in openfile.FileNames)
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(file);
                    info.CopyTo(Application.StartupPath + @"\" + v.ver + @"\"+info.Name,true);
                    v.paths.Add(info.Name);

                }
            }
            n.Tag = v;
            ShowVersion(v);
            isUpdate = true;
            buttonSaveVersionFileList.Enabled = true;

        }

        private void ButtonDelVersionFile_Click(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
            Version v = (Version)n.Tag;

            foreach (ListViewItem item in listViewVersionFileList.SelectedItems)
            {
                v.paths.Remove(item.Text);
            }
            n.Tag = v;
            ShowVersion(v);
            isUpdate = true;
            buttonSaveVersionFileList.Enabled = true;

        }

        private void advTree1_BeforeNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {
            if (isUpdate)
            {
                    DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
                    Version v = (Version)n.Tag;
                if (MessageBox.Show("版本已经修改，是否要保存", "版本更新", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    v.discription = textBoxDiscription.Text;
                    v.date = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    if (radioButtonType1.Checked) v.type = 0;
                    else if (radioButtonType2.Checked) v.type = 1;
                    else if (radioButtonType3.Checked) v.type = 2;
                    else v.type = 0;

                    n.Tag = v;

                    SaveVersionFileList(v);

                }
                else
                {
                    Version temp =  LoadVersion(v.ver);
                    v.ver = temp.ver;
                    v.date = temp.date;
                    v.discription = temp.discription;
                    v.paths = temp.paths;
                    n.Tag = v;

                }
                isUpdate = false ;
                buttonSaveVersionFileList.Enabled = false;

                ShowVersion((Version)e.Node.Tag);
            }
        }

        private void VersionContent_Changed(object sender, EventArgs e)
        {
                isUpdate = true  ;
                buttonSaveVersionFileList.Enabled = true;


        }

        private void ButtonRemoveVersion_Click(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
            Version v = (Version)n.Tag;
            if (MessageBox.Show("版本删除之后不能恢复，是否确认要删除？", "版本删除", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                System.IO.Directory.Delete(Application.StartupPath + @"\" + v.ver, true);
                advTreeVersion.Nodes.Remove(n);
                SaveVersion();
            }
        }

        private void toolStripButtonEditPath_Click(object sender, EventArgs e)
        {
            DevComponents.AdvTree.Node n = advTreeVersion.SelectedNode;
            Version v = (Version)n.Tag;
            FormPathEdit fe = new FormPathEdit();
            if (fe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string newpath = fe.Path;
                foreach (ListViewItem item in listViewVersionFileList.SelectedItems)
                {
                    int index = v.paths.IndexOf(item.Text);
                    if (index > 0)
                    {
                        int pathindex = v.paths[index].LastIndexOf('\\')+1;
                        string filename = v.paths[index].Substring(pathindex, v.paths[index].Length - pathindex);
                        string oldpath = v.paths[index].Substring(0,pathindex);
                        if (oldpath == newpath)
                            continue;
                        try
                        {
                            if (!System.IO.Directory.Exists(Application.StartupPath + @"\" + v.ver + @"\" + newpath))
                            {
                                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\" + v.ver + @"\" + newpath);
                            }
                            if (System.IO.File.Exists(Application.StartupPath + @"\" + v.ver + @"\" + newpath + filename))
                            {
                                System.IO.File.Delete(Application.StartupPath + @"\" + v.ver + @"\" + newpath + filename);
                            }
                            System.IO.File.Copy(Application.StartupPath + @"\" + v.ver + @"\" + v.paths[index], Application.StartupPath + @"\" + v.ver + @"\" + newpath + filename);
                            v.paths[index] = newpath + filename;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            continue;
                        }
                    }
                }
                n.Tag = v;
                ShowVersion(v);
                isUpdate = true;
                buttonSaveVersionFileList.Enabled = true;
            }
        }



    }
}