using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using log4net.Appender;

namespace MyLog4Net
{
    public  class Container
    {
        private static Container s_Instance = null;
        private ILog m_Log = null;

        public static Container Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new Container();
                }
                return s_Instance;
            }
        }
        public ILog Log
        {
            get
            {
                if (m_Log == null)
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    string logpath = Directory.GetParent(asm.Location).FullName;
                    if (logpath.Contains("Temporary ASP.NET Files"))
                        logpath = Path.GetTempPath();
                    
                    string configFile = Path.Combine(logpath, "MyLog4Net.config");
                    FileInfo fi = new FileInfo(configFile);
                    if (!File.Exists(configFile))
                    {
                        File.WriteAllText(configFile, Properties.Resources.MyLog4Net, Encoding.UTF8);
                    }

                    log4net.Config.XmlConfigurator.Configure(fi);
                    m_Log = LogManager.GetLogger("DebuggingLog");

                    var repository = LogManager.GetRepository();
                    var appendes = repository.GetAppenders();
                    var targetapder = appendes.First(p => p.Name == "DebuggingRollingFileAppender") as RollingFileAppender;
                    targetapder.File = Path.Combine(logpath, "IVXdebug_"+Process.GetCurrentProcess().Id+".log");
                    targetapder.ActivateOptions();
                }
                return m_Log;
            }
        }

    }

    public static class ILogExtension
    {
        public static void DebugWithDebugView(this ILog log, object Message)
        {
            System.Diagnostics.Trace.WriteLine(Message);
            log.Debug(Message);
        }
        public static void ErrorWithDebugView(this ILog log, object Message)
        {
            System.Diagnostics.Trace.WriteLine(Message);
            log.Error(Message);
        }
    }


}
