﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

namespace WinFormAppUtil.Common
{
    public class FtpWeb
    {
        #region Fields
        
        public readonly string m_ftpServerIP;
        public string m_ftpRemotePath;
        public readonly string m_ftpUserID;
        public readonly string m_ftpPassword;
        public string m_ftpURI;
        public readonly Encoding m_serverEncoding;
        private readonly static char[] SLASHES = new char[]{'/', '\\'};

        #endregion

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="ip">FTP连接地址</param>
        /// <param name="path">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
         FtpWeb(string ip, string path, string userName, string password,Encoding enc )
        {
            m_ftpServerIP = ip;
            m_ftpRemotePath = path;
            m_ftpUserID = userName;
            m_ftpPassword = password;
            m_ftpURI = "ftp://" + m_ftpServerIP + "/" + m_ftpRemotePath;
            m_serverEncoding = enc;
        }
         FtpWeb(string ip, string path, string userName, string password ):this(ip,path,userName,password,Encoding.UTF8)
        {
        }

        /// <summary>
        /// 本来想用正则表达式来获取数据的，结果不会用了，先用字符串截取的方式实现
        /// //ftp://public:public123$@192.168.42.6/素材库/3.0测试视频
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool GetFtpUrlInfo(string url, out string ip, out string port, out string username, out string password, out string path)
        {
            ip = ""; port = ""; username = ""; password = ""; path = "";

            if (url.ToLower().StartsWith(@"ftp://"))
            {
                string u_p_i_p_p = url.Substring(6);
                int indexu_p_i_p_p = u_p_i_p_p.IndexOf('@');
                string u_p = "";
                string i_p_p = "";
                string i_p = "";
                int indexu_p = -1;
                int indexi_p_p = -1;
                int indexi_p = -1;

                if(indexu_p_i_p_p>=0)
                {
                    u_p = u_p_i_p_p.Substring(0, indexu_p_i_p_p);
                    indexu_p = u_p.IndexOf(':');

                    i_p_p = u_p_i_p_p.Substring(indexu_p_i_p_p+1);
                    indexi_p_p = i_p_p.IndexOf("/");
                }
                else
                {
                    u_p = "";
                    indexu_p = -1;
                    i_p_p = u_p_i_p_p;
                    indexi_p_p = i_p_p.IndexOf("/");
                    
                }

                if (indexu_p >= 0)
                {
                    username = u_p.Substring(0, indexu_p);
                    password = u_p.Substring(indexu_p + 1);
                }
                else
                {
                    username = u_p;
                    password = "";
                }

                if (indexi_p_p >= 0)
                {
                    i_p = i_p_p.Substring(0, indexi_p_p);

                    indexi_p = i_p.IndexOf(':');
                    path = i_p_p.Substring(indexi_p_p + 1);
                }
                else
                {

                    i_p = i_p_p;
                    indexi_p = i_p.IndexOf(':');
                    path = "";
                }

                if (indexi_p >= 0)
                {
                    ip = i_p.Substring(0, indexi_p);
                    port = i_p.Substring(indexi_p + 1);
                }
                else
                {
                    ip = i_p;
                    port = "21";
                }
                
                return true;
            }
            else
                return false;
        }

        private static string Combine(string url, string folder)
        {
            string sRet = url;
            if (!string.IsNullOrEmpty(folder))
            {
                sRet = url.Trim(SLASHES);
                string folderTmp = folder.Trim(SLASHES);
                if (folderTmp.Length == 0)
                {
                    sRet = string.Format("{0}/", sRet);
                }
                else
                {
                    sRet = string.Format("{0}/{1}/", sRet, folderTmp);
                }
            }
            return sRet;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="filename"></param>
        public void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = m_ftpURI + fileInf.Name;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new  FtpException("FtpWeb Upload Error --> " + ex.Message);
            }
        }
        
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public void Download(string filePath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(m_ftpURI + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new  FtpException("FtpWeb Download Error --> " + ex.Message);
            }
        }

        public void GetFileStream(string fullName, Stream ms)
        {
            FtpWebRequest reqFTP;
            // Debug.Assert(fullName.StartsWith(m_ftpURI));
            int index = fullName.IndexOf(m_ftpServerIP);
            int index2 = m_ftpURI.IndexOf(m_ftpServerIP);
            string fileName = string.Concat(m_ftpURI.Substring(0, index2), fullName.Substring(index));
            try
            {
                // FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                Uri uri = new Uri(fileName);
                //if (!m_ftpURI.EndsWith("/"))
                //{
                //    uri = new Uri(string.Concat(m_ftpURI, "/", fullName));
                //}
                //else
                //{
                //    uri = new Uri(string.Concat(m_ftpURI, fullName));
                //}
              
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(uri);
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    ms.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                // ms.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb Download Error --> " + ex.Message);
            }
        }
        
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public void Delete(string fileName)
        {
            try
            {
                string uri = m_ftpURI + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb Delete Error --> " + ex.Message + " 文件名:" + fileName);
            }
        }
        
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderName"></param>
        public void RemoveDirectory(string folderName)
        {
            try
            {
                string uri = m_ftpURI + folderName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb Delete Error --> " + ex.Message + " 文件名:" + folderName);
            }
        }
        
        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)
        /// </summary>
        /// <returns></returns>
        public List<FtpFileInfo> GetFilesDetailList(string path)
        {
            List<FtpFileInfo> downloadFiles = new List<FtpFileInfo>();

            // 端口后的 / 可有可无， 但文件夹后的 / 必须要有， // 仅能在ftp后

            try
            {
                FtpWebRequest ftp;
                string strurl = Combine(m_ftpURI, path);
                //strurl = System.Web.HttpUtility.UrlEncode(strurl, m_serverEncoding);
                //strurl = System.Web.HttpUtility.UrlEncode(path, m_serverEncoding);
                //strurl = Combine(m_ftpURI, path);
                //Uri url = new Uri(strurl);
                strurl = Uri.EscapeUriString(strurl);
                ftp = (FtpWebRequest)FtpWebRequest.Create(strurl);
                ftp.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), m_serverEncoding);
                //while (reader.Read() > 0)
                //{
                //}
                string line = reader.ReadLine();
                //line = reader.ReadLine();
                //line = reader.ReadLine();
                FtpFileInfo ftpFileInfo;
                while (line != null)
                {
                    try
                    {
                        ftpFileInfo = GetFtpFileInfo(line);
                        downloadFiles.Add(ftpFileInfo);
                    }
                    catch (Exception ex)
                    {
                        LogService.GetLog("AppUtil").Error(string.Format("获取 ftp 路径 {0} 出错", line), ex);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return downloadFiles;
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb GetFilesDetailList Error --> " + ex.Message);
                return downloadFiles;
            }
        }

        /// <summary>
        /// 获取当前目录下文件列表(仅文件)
        /// </summary>
        /// <returns></returns>
        public List<string> GetFileList(string path,string mask)
        {
            List<string> downloadFiles = new List<string>();

            FtpWebRequest reqFTP;
            string url = Combine(m_ftpURI, path);
            Uri uri = new Uri(url);
                      
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(uri);
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), m_serverEncoding);
                string line = reader.ReadLine();
                string mask_ = mask.Substring(0, mask.IndexOf("*"));

                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            downloadFiles.Add(line);
                        }
                    }
                    else
                    {
                        downloadFiles.Add(line);
                    }
                    line = reader.ReadLine();
                }

                reader.Close();
                response.Close();
                return downloadFiles;
            }
            catch (Exception ex)
            {
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    downloadFiles = null;
                    throw new FtpException("FtpWeb GetFileList Error --> " + ex.Message.ToString());
                }
                return downloadFiles;
            }
        }
        
        private FtpFileInfo GetFtpFileInfo(string str)
        {
            FtpFileInfo info = new FtpFileInfo();
            int dirPos = str.IndexOf("<DIR>");
            string m = string.Empty;

            if (dirPos > 0)//MS-DOS方式文件夹
            {
                
                m += str.Substring(dirPos + 5).Trim() + "\n";
                info.Attribute = "";
                info.FileSize = 0;
                info.IsDir = true;
                info.Name = str.Substring(dirPos + 5).Trim();
                info.Time = new DateTime(0);
                info.User = "";
                info.UserGroup = "";
            }
            else 
            {
                string[] diritems = str.Split(new char[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                if (diritems.Length > 4) //UNIX方式 文件或文件夹
                {
                    info.Attribute = diritems[0];
                    info.FileSize = uint.Parse(diritems[4]);
                    info.IsDir = diritems[0].Trim().Substring(0, 1).ToUpper() == "D";
                    info.Name = diritems[8];
                    info.Time = new DateTime(0);
                    info.User = "";
                    info.UserGroup = "";
                }
                else //MS-DOS方式文件
                {
                    info.Attribute = "";
                    info.FileSize = uint.Parse(diritems[2]);
                    info.IsDir = false;
                    info.Name = diritems[3];
                    info.Time = new DateTime(0);
                    info.User = "";
                    info.UserGroup = "";

                }
            }
            return info;
        }
    
        /// <summary>
        /// 获取当前目录下所有的文件夹列表(仅文件夹)
        /// </summary>
        /// <returns></returns>
        public List<string> GetDirectoryList(string path)
        {
            List<string> dirlist = new List<string>();
            List<FtpFileInfo> drectory = GetFilesDetailList(path);
            string m = string.Empty;
            foreach (FtpFileInfo str in drectory)
            {
                if (str.IsDir)
                {
                    if(str.Name != "." && str.Name!="..")
                        dirlist.Add(str.Name);
                }
            }
            return dirlist;
        }
        
        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        public bool DirectoryExist(string path,string RemoteDirectoryName)
        {
            List<FtpFileInfo> drectory = GetFilesDetailList(path);
            foreach (FtpFileInfo str in drectory)
            {
                if (str.IsDir && str.Name.Trim() == RemoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 判断当前目录下指定的文件是否存在
        /// </summary>
        /// <param name="RemoteFileName">远程文件名</param>
        public bool FileExist(string path,string RemoteFileName)
        {
            List<string> fileList = GetFileList(path,"*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(m_ftpURI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb MakeDir Error --> " + ex.Message);
            }
        }
        
        /// <summary>
        /// 获取指定文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(m_ftpURI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb GetFileSize Error --> " + ex.Message);
            }
            return fileSize;
        }
        
        /// <summary>
        /// 改名
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(m_ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new FtpException("FtpWeb ReName Error --> " + ex.Message);
            }
        }
        
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }
        
        /// <summary>
        /// 切换当前目录
        /// </summary>
        /// <param name="DirectoryName"></param>
        /// <param name="IsRoot">true 绝对路径 false 相对路径</param>
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                m_ftpRemotePath = DirectoryName;
            }
            else
            {
                m_ftpRemotePath += DirectoryName + "/";
            }
            m_ftpURI = "ftp://" + m_ftpServerIP + "/" + m_ftpRemotePath + "/";
        }
    }

    [Serializable]
    public class FtpException : Exception
    {
        public FtpException() { }

        public FtpException(string message) : base(message) { }
        
        public FtpException(string message, Exception inner) : base(message, inner) { }
        
        protected FtpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public class FtpFileInfo
    {
        public string Attribute;

        public string User;

        public string UserGroup;

        public UInt64 FileSize;

        public bool IsDir;

        public DateTime Time;

        public string Name;
    }
}