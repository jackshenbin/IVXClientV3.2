using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using Microsoft.Win32;
using System.Xml;
using System.Windows.Forms;

namespace AutoUpdateApp
{
    public struct Version
    {
        public string ver;
        public int type;
        public string date;
        public string discription;
        public List<string> paths;
        public bool enable;
    }
    class Program
    {
        static public string UpdateURL
        {
        get;
        set;
        }
        static public int UpdateType
        {
        get;
        set;
        }
        static public string MainProgramPath
        {
        get;
        set;
        }
        static public string MainVersion
        {
        get;
        set;
        }
        static public int IsShowNoNewVersion
        {
        get;
        set;
        }
        static public int IsShowErrorURL
        {
        get;
        set;
        }

        static private List<string> verlist = new List<string>();
        static private Dictionary<string, Version> verlistdescription = new Dictionary<string, Version>();
        static private string VersionPath
        {
            get 
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Update\";
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                return path;
            }
        }

        static private bool LoadSetting()
        {
            UpdateType = 0;
            UpdateURL = "";
            MainProgramPath = "";
            MainVersion = "0.0.0.0";
            IsShowNoNewVersion = 1;
            IsShowErrorURL = 1;
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ProgramSetting.xml"))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(AppDomain.CurrentDomain.BaseDirectory + "ProgramSetting.xml");
                XmlElement xmlelement = xmldoc.DocumentElement;
                foreach (XmlNode node in xmlelement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "UpdateURL":
                            UpdateURL = node.InnerText;
                            break;
                        case "UpdateType":
                            UpdateType = int.Parse(node.InnerText);
                            break;
                        case "MainProgramPath":
                            MainProgramPath = node.InnerText;
                            break;
                        case "MainVersion":
                            MainVersion = node.InnerText;
                            break;
                        case "IsShowNoNewVersion":
                            IsShowNoNewVersion = int.Parse(node.InnerText);
                            break;
                        case "IsShowErrorURL":
                            IsShowErrorURL = int.Parse(node.InnerText);
                            break;
                    }
                }
            }
            else
            {

                MessageBox.Show("系统文件丢失，请重新安装系统。", "系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        static private void Main(string[] args)
        {
            Process[] process = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            foreach (Process p in process)
            {
                if (p.Id == Process.GetCurrentProcess().Id)
                    continue;
                else
                    p.Kill();
            }
           // CreateShortcut();
            if (!LoadSetting())
                return;

            StartProgram();

            if (args.Length > 0)
            {
                UpdateType = int.Parse(args[0]);
            }
            switch (UpdateType)
            {
                case 1://更新
                    AutoUpdate();
                    break;
                case 2://检查
                    if (GetVersion())
                    {
                        CompareVersion();
                        if (verlist.Count > 0)
                        {

                            if (MessageBox.Show("发现新版本 V" + verlist[verlist.Count - 1].ToString() + " 是否要更新？", "版本更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (GetVersionFileList())
                                {
                                    StopProgram();
                                    UpdateVersion();
                                    StartProgram();

                                }
                                else
                                { 
                                    MessageBox.Show("更新失败，请稍候再试。", "版本更新", MessageBoxButtons.OK,MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            //MessageBox.Show("您已经是最新版本。", "版本更新", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    break;
                case 3://不更新
                    break;
                case 4://手动检查
                    if (GetVersion())
                    {
                        CompareVersion();
                        if (verlist.Count > 0)
                        {

                            if (MessageBox.Show("发现新版本 V" + verlist[verlist.Count - 1].ToString() + " 是否要更新？", "版本更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (GetVersionFileList())
                                {
                                    StopProgram();
                                    UpdateVersion();
                                    StartProgram();

                                }
                                else
                                {
                                    MessageBox.Show("更新失败，请稍候再试。", "版本更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            if (IsShowNoNewVersion == 1)
                            {
                                FormMessage f = new FormMessage();
                                f.Show("您已经是最新版本。", "版本更新");
                                IsShowNoNewVersion = f.IsShow?1:0;
                                SaveSetting();
                            }
                            //MessageBox.Show("您已经是最新版本。", "版本更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    break;
                default://检查
                    if (GetVersion())
                    {
                        CompareVersion();
                        if (verlist.Count > 0)
                        {
                            if (MessageBox.Show("发现新版本 V" + verlist[verlist.Count - 1].ToString() + " 是否要更新？", "版本更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (GetVersionFileList())
                                {
                                    StopProgram();
                                    UpdateVersion();
                                    StartProgram();
                                }
                                else
                                {
                                    MessageBox.Show("更新失败，请稍候再试。", "版本更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }
                        else
                        {
                            if (IsShowNoNewVersion == 1)
                            {
                                FormMessage f = new FormMessage();
                                f.Show("您已经是最新版本。", "版本更新");
                                IsShowNoNewVersion = f.IsShow ? 1 : 0;
                                SaveSetting();
                            }

                            //MessageBox.Show("您已经是最新版本。", "版本更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    break;
            }
        }

        static private void AutoUpdate()
        {
            Trace.WriteLine("AutoUpdate");
            if (GetVersion())
            {
                CompareVersion();
                if (verlist.Count > 0)
                {
                    if (GetVersionFileList())
                    {
                        StopProgram();
                        UpdateVersion();
                    }
                }
            }
        }

        static private bool GetVersion()
        {
            Trace.WriteLine("GetVersion");
            WebClient wc = new WebClient();
            try
            {
                wc.DownloadFile(new Uri(UpdateURL.TrimEnd(new char[] { '/' }) + @"/ver.xml"), VersionPath + "ver.xml");
                return true;
            }
            catch (WebException ex)
            {
                if (IsShowErrorURL == 1)
                {
                    FormMessage f = new FormMessage();
                    f.Show("自动更新地址错误", "版本更新");
                    IsShowErrorURL = f.IsShow ? 1 : 0;
                    SaveSetting();
                }

                //MessageBox.Show("自动更新地址错误", "版本更新", MessageBoxButtons.OK,MessageBoxIcon.Warning);

                Trace.WriteLine(ex.ToString());
                return false;
            }
        }

        static private void CompareVersion()
        {
            Trace.WriteLine("CompareVersion");
            XmlDocument doc = new XmlDocument();
            doc.Load(VersionPath+"ver.xml");
            XmlElement element = doc.DocumentElement;
            verlist.Clear();
            foreach (XmlNode node in element.ChildNodes)
            {
                if (CompareVersion(node.InnerText, MainVersion) > 0)
                {
                    if (node.Attributes["en"].InnerText == "1")
                    {
                        verlist.Add(node.InnerText);
                        Version v = new Version();
                        v.date = "";
                        v.discription = "";
                        v.enable = true;
                        v.paths = new List<string>();
                        v.type = int.Parse(node.Attributes["type"].InnerText);
                        v.ver = node.InnerText;
                        verlistdescription.Add(node.InnerText, v);
                    }
                }
            }
            verlist.Sort(CompareVersion);
            for (int i = verlist.Count - 1; i > 0; i--)
            {
                if (verlistdescription[verlist[i]].type == 0 || verlistdescription[verlist[i]].type == 1)
                {
                    verlist.RemoveRange(0, i);
                    break;
                }
            }
        }
        static private int CompareVersion(string x, string y)
        {
            string[] xs = x.Split(new string[] { "." },StringSplitOptions.None);
            string[] ys = y.Split(new string[] { "." },StringSplitOptions.None);
            int x1 = int.Parse(xs[0]);
            int x2 = int.Parse(xs[1]);
            int x3 = int.Parse(xs[2]);
            int x4 = int.Parse(xs[3]);
            int y1 = int.Parse(ys[0]);
            int y2 = int.Parse(ys[1]);
            int y3 = int.Parse(ys[2]);
            int y4 = int.Parse(ys[3]);
            
            if (x1 > y1)
                return 1;
            else if (x1 < y1)
                return -1;
            else 
            {
                if (x2 > y2)
                    return 1;
                else if (x2 < y2)
                    return -1;
                else
                {
                    if (x3 > y3)
                        return 1;
                    else if (x3 < y3)
                        return -1;
                    else
                    {
                        if (x4> y4)
                            return 1;
                        else if (x4 < y4)
                            return -1;
                        else
                        {
                            return 0;
                        }

                    }

                }

            }
            
        }
        static private bool GetVersionFileList()
        {
            FormDownload fd = new FormDownload();
            fd.SetValue(verlist,VersionPath,UpdateURL);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }


        static private void StopProgram()
        {
            Trace.WriteLine("StopProgram");
            System.IO.FileInfo f = new System.IO.FileInfo(MainProgramPath);
            string pName = f.Name.Replace(f.Extension, "");
            Process[] process = Process.GetProcessesByName(pName);
            if (process.Length > 0)
            {


                MessageBox.Show("升级将关闭应用程序，并自动重启。", "版本更新", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (Process p in process)
                    {
                        p.Kill();
                }
            }
            System.Threading.Thread.Sleep(1000);
        }

        static private void UpdateVersion()
        {
            Trace.WriteLine("UpdateVersion");
            //UpdateVersionFileList();
            System.Threading.Thread.Sleep(1000);
            foreach (string ver in verlist)
            {
                string ret = "";
                if (verlistdescription[ver].type == 0)
                {
                    string[] files =System.IO.Directory.GetFiles(VersionPath + ver);
                    foreach (string file in files)
                    {
                        System.IO.FileInfo f = new System.IO.FileInfo(file);
                        if (f.Extension.ToLower() == ".msi")
                        {
                            Trace.WriteLine("msiexec /passive /i " + f.FullName);
                            Process proc =  Process.Start("msiexec","/passive /i \""+f.FullName+"\"");// /quiet
                            if (proc != null)
                            {
                                proc.WaitForExit();
                                continue;
                            }
                        }
                    }
                    ret = "success";
                }
                else
                {
                    System.IO.FileInfo f = new System.IO.FileInfo(MainProgramPath);
                    ret = CopyFolder(VersionPath + ver, f.DirectoryName);
                }
                MainVersion = ver;
                if(ret == "success")
                    SaveSetting();
            }
        }

        static private void SaveSetting()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(AppDomain.CurrentDomain.BaseDirectory + "ProgramSetting.xml");
            XmlElement xmlelement = xmldoc.DocumentElement;
            foreach (XmlNode node in xmlelement.ChildNodes)
            {
                switch (node.Name)
                {
                    case "MainVersion":
                        node.InnerText = MainVersion;
                        break;
                    case "IsShowNoNewVersion":
                        node.InnerText = IsShowNoNewVersion.ToString();
                        break;
                    case "IsShowErrorURL":
                        node.InnerText = IsShowErrorURL.ToString();
                        break;

                }
            }
            xmldoc.Save(AppDomain.CurrentDomain.BaseDirectory + "ProgramSetting.xml");
        }

        /// <summary>
        /// Copy文件夹
        /// </summary>
        /// <param name="sPath">源文件夹路径</param>
        /// <param name="dPath">目的文件夹路径</param>
        /// <returns>完成状态：success-完成；其他-报错</returns>
        static  string CopyFolder(string sPath, string dPath)
        {
            sPath = sPath.TrimEnd(new char[] { '\\' });
            dPath = dPath.TrimEnd(new char[] { '\\' });
            string flag = "success";
            try
            {
                // 创建目的文件夹
                if (!System.IO.Directory.Exists(dPath))
                {
                    System.IO.Directory.CreateDirectory(dPath);
                }

                // 拷贝文件
                System.IO.DirectoryInfo sDir = new System.IO.DirectoryInfo(sPath);
                System.IO.FileInfo[] fileArray = sDir.GetFiles();
                foreach (System.IO.FileInfo file in fileArray)
                {
                    file.CopyTo(dPath + @"\" + file.Name, true);
                }

                // 循环子文件夹
                System.IO.DirectoryInfo dDir = new System.IO.DirectoryInfo(dPath);
                System.IO.DirectoryInfo[] subDirArray = sDir.GetDirectories();
                foreach (System.IO.DirectoryInfo subDir in subDirArray)
                {
                    CopyFolder(subDir.FullName, dPath + @"\" + subDir.Name);
                }
            }
            catch (Exception ex)
            {
                flag = ex.ToString();
            }
            return flag;
        }
        static private void UpdateVersionFileList()
        {
            Trace.WriteLine("UpdateVersionFileList");
            System.Threading.Thread.Sleep(1000);

         }

        static private void StartProgram()
        {
            Trace.WriteLine("StartProgram");
            //System.IO.FileInfo f = new System.IO.FileInfo(MainProgramPath);
            //string pName = f.Name.Replace(f.Extension, "");
            //Process[] process = Process.GetProcessesByName(pName);
            //if (process.Length > 0)
            //{
            //}
            //else
            //    Process.Start(MainProgramPath);

            if(System.IO.File.Exists(MainProgramPath))
                Process.Start(MainProgramPath);

        }



        //static void CreateShortcut()
        //{
        //    System.IO.FileInfo f = new System.IO.FileInfo(MainProgramPath);
        //                string pName = f.Name.Replace(f.Extension, "");

        //    WshShell shell = new WshShell();
        //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(
        //    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
        //    "\\" + pName + " Launcher.lnk"
        //    );
        //    shortcut.TargetPath = f.FullName;
        //    //shortcut.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //    shortcut.WindowStyle = 1;
        //    shortcut.Description = pName + " Launcher";
        //    //shortcut.IconLocation = System.Environment.            SystemDirectory + "\\" + "shell32.dll, 165";
        //    shortcut.Save();
        //}  



    }
}