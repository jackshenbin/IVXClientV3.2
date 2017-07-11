using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using MyLog4Net;

namespace IVX.Live.MainForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            MyLog4Net.Container.Instance.Log.DebugWithDebugView("FormMainNew");

            Application.Run(new FormMainNew());
            //Application.Run(new FormOP());
            //Application.Run(new Form2());
            
            //Application.Run(new IVX.Live.MainForm.View.FormLogin());
            //Application.Run(new IVX.Live.MainForm.FormProtocolTest());
            //Application.Run(new IVX.Live.MainForm.View.FormTrafficEventAlarm());
        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Framework.Environment.CheckMemeryUse();
            if (e.ExceptionObject is Exception)
            {
                MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:", (Exception)e.ExceptionObject);

                MessageBox.Show(
                    string.Format("系统出现未处理异常："
                    + Environment.NewLine + "{0}"
                    + Environment.NewLine + Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", ((Exception)e.ExceptionObject).Message)
                    , "系统未处理异常"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:无描述");

                MessageBox.Show(
                    string.Format("系统出现未处理异常："
                    + Environment.NewLine + "{0}"
                    + Environment.NewLine + Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", "无描述")
                    , "系统未处理异常"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Framework.Environment.CheckMemeryUse();
            MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:", e.Exception);

            MessageBox.Show(
                string.Format("系统出现未处理异常："
                + Environment.NewLine + "{0}"
                + Environment.NewLine + Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", e.Exception.Message)
                , "系统未处理异常"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

        }

        private static int m_productType = -1;
        public static Framework.Environment.E_PRODUCT_TYPE PRODUCT_TYPE
        {
            get
            {
                if (m_productType < 0)
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

                    string path = asm.Location;
                    path = System.IO.Path.GetDirectoryName(path);

                    int ntype = 0;
                    string producttypepath = path + "\\Resource.dll";
                    if (System.IO.File.Exists(producttypepath))
                    {
                        string strtype = System.IO.File.ReadAllText(producttypepath);
                        try
                        {
                            ntype = int.Parse(strtype);
                            if (ntype < 0)
                                ntype = 0;
                        }
                        catch { }
                    }
                    m_productType = ntype;
                }
                return (Framework.Environment.E_PRODUCT_TYPE)m_productType;

            }
        }


    }
}