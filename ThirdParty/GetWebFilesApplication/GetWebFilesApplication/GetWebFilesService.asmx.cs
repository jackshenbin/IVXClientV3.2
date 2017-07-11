using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace GetWebFilesApplication
{
    /// <summary>
    /// GetWebFilesService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class GetWebFilesService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public string GetFolders(string parant)
        {
            string rootpath = Server.MapPath(@"/files/");
            string[] folders = System.IO.Directory.GetDirectories(rootpath+parant);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine( "<Folders>");
            foreach (string f in folders)
            {
                sb.AppendLine( "<item>" + f.Replace(rootpath,"").Replace('\\','/') + "</item>");
            }
            sb.AppendLine("</Folders>");
            return sb.ToString();
        }

        [WebMethod]
        public string GetFiles(string parant)
        {
            string rootpath = Server.MapPath(@"/files/");
            string[] files = System.IO.Directory.GetFiles(rootpath + parant);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine( "<Files>");
            foreach (string f in files)
            {
                string size = "size = 0";
                if(System.IO.File.Exists(f))
                {
                System.IO.FileInfo fi = new System.IO.FileInfo(f);
                size = " size = \"" + fi.Length+"\"";
                }
                sb.AppendLine("<item " + size + ">" + f.Replace(rootpath, "").Replace('\\', '/') + "</item>");
            }
            sb.AppendLine( "</Files>");
            return sb.ToString();
        }



    }
}
