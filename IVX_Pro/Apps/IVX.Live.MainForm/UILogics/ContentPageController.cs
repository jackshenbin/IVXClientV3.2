using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IVX.DataModel;
using System.Windows.Forms;
using System.Reflection;
using MyLog4Net;
using System.Drawing;
using System.Xml;


namespace IVX.Live.MainForm.UILogics
{
    public class ContentPageController 
    {
        #region Fields
        Dictionary<string, IVX.Live.MainForm.UILogics.FormBase> m_DTFunction2TabPage;

        #endregion
        
        #region Constructors

        public ContentPageController()
        {
            m_DTFunction2TabPage = new Dictionary<string, IVX.Live.MainForm.UILogics.FormBase>();
        }

        #endregion

        #region Private helper functions

        private  IVX.Live.MainForm.UILogics.FormBase CreateContentPage(string itemInfo)
        {
            try
            {
                IVX.Live.MainForm.UILogics.FormBase ctrl
                    = Assembly.GetExecutingAssembly().CreateInstance("IVX.Live.MainForm.View." + itemInfo) as IVX.Live.MainForm.UILogics.FormBase;
                //ctrl.FormClosed += ctrl_FormClosed;
                ctrl.Name = itemInfo;
                return ctrl;

            }
            catch (Exception ex)
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("CreateContentPage iteminfo:"+itemInfo+" error:"+ex.ToString());
                return null;
            }
                    
        }

        void ctrl_FormClosed(object sender, FormClosedEventArgs e)
        {
            IVX.Live.MainForm.UILogics.FormBase tabPage = sender as IVX.Live.MainForm.UILogics.FormBase;
            tabPage.Controls.Remove(tabPage);
            m_DTFunction2TabPage.Remove(tabPage.Name);
            tabPage.Clear();
            //tabPage.Dispose();
        }


        #endregion

        #region Public
        public Image GetPageICON(string itemInfo)
        {            
            XmlDocument xDoc = new XmlDocument();
            Assembly asm = Assembly.GetExecutingAssembly();
            string fileName = System.IO.Path.GetDirectoryName(asm.Location) + "\\img\\"+itemInfo+".jpg";
            if (System.IO.File.Exists(fileName))
            {
                Image temp = Image.FromFile(fileName);
                Image img = new Bitmap(temp);
                temp.Dispose();

                return img;
            }
            else
                return global::IVX.Live.MainForm.Properties.Resources.播放1;
        }

        public Image GetPageImage(string itemInfo)
        {
            XmlDocument xDoc = new XmlDocument();
            Assembly asm = Assembly.GetExecutingAssembly();
            string fileName = System.IO.Path.GetDirectoryName(asm.Location) + "\\img\\" + itemInfo + ".png";
            if (System.IO.File.Exists(fileName))
            {
                Image temp = Image.FromFile(fileName);
                Image img = new Bitmap(temp);
                temp.Dispose();

                return img;
            }
            else

                return global::IVX.Live.MainForm.Properties.Resources.案件管理; 
        }

        public IVX.Live.MainForm.UILogics.FormBase GetContentPage(string itemInfo)
        {
            IVX.Live.MainForm.UILogics.FormBase tabPage = null;

            if (m_DTFunction2TabPage.ContainsKey(itemInfo))
            {
                tabPage = m_DTFunction2TabPage[itemInfo];
            }
            else
            {
                tabPage = CreateContentPage(itemInfo);
                if (tabPage != null)
                {
                    tabPage.WindowState = FormWindowState.Maximized;
                    tabPage.EnableCustomStyle = true;
                    m_DTFunction2TabPage.Add(itemInfo, tabPage);

                }
            }

            return tabPage;
        }

        void RemovePage(string itemInfo, IVX.Live.MainForm.UILogics.FormBase tabPage)
        {
            tabPage.Clear();
        }

        public void Cleanup()
        {
            foreach (var item in m_DTFunction2TabPage)
            {
                RemovePage(item.Key, item.Value);
                
            }
            m_DTFunction2TabPage.Clear();
        }

        #endregion

        
        #region Event handlers



        #endregion

    }
}
