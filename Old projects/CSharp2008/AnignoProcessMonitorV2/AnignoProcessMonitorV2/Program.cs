using System;
using System.Windows.Forms;
using AnignoLibrary.Helpers;
using AnignoProcessMonitorV2.UI;
using LoggingProvider;
using System.Threading;

namespace AnignoProcessMonitorV2
{
    static class Program
    {
        public const string VERSION_STRING="2.14";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Logger.Deactivate();
            if(ProcessHelper.GetInstances(Application.ExecutablePath)>1)return;
            Logger.LogInfo("****** AnignoProcessMonitorV2 started ******");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
