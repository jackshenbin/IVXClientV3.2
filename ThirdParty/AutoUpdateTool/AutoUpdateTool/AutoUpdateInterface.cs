using System;
using System.Xml;
using System.Diagnostics;

namespace AutoUpdate
{
    public  class AutoUpdateInterface
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

        static public void Initialize()
        {
            UpdateType = 0;
            UpdateURL = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\ProgramSetting.xml");
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
                }
            }



        }

        static public System.Windows.Forms.DialogResult ShowSetting()
        {
            FormAutoUpdate f = new FormAutoUpdate();
            f.UpdateType = UpdateType;
            f.UpdateURL = UpdateURL;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateURL = f.UpdateURL;
                UpdateType = f.UpdateType;
                SaveSetting();
                return System.Windows.Forms.DialogResult.OK;
            }
            return System.Windows.Forms.DialogResult.Cancel;
        }
        static public void SaveSetting()
        { 
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\ProgramSetting.xml");
            XmlElement xmlelement = xmldoc.DocumentElement;
            foreach (XmlNode node in xmlelement.ChildNodes)
            {
                switch (node.Name)
                {
                    case "UpdateURL":
                        node.InnerText = UpdateURL;
                        break;
                    case "UpdateType":
                        node.InnerText = UpdateType.ToString();
                        break;
                }
            }
            xmldoc.Save(AppDomain.CurrentDomain.BaseDirectory + @"\ProgramSetting.xml");
        }

        static public void Update()
        {
            //AutoUpdate();
            Process.Start("AutoUpdateApp.exe","1");
             
        }

        static public void Check()
        {
            //GetVersion();
            //CompareVersion();
            Process.Start("AutoUpdateApp.exe","4");
        }



    }
}
