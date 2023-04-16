using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["metric_down_count"] = 1;
            // properties have data already but we add additional for test properties filtering
            log4net.GlobalContext.Properties["animal"] = "Zebra";

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "log4net.config")));
            ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _log.Error("Error Message", new Exception("This is Exception"));
            Console.WriteLine("Press ENTER key");
            Console.ReadKey();
        }
    }
}
