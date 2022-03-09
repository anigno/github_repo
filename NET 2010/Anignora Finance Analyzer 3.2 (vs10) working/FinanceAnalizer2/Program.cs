using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinanceAnalizer2.UI;
using LoggingProvider;

namespace FinanceAnalizer2
{
    static class Program
    {
        public static string APPLICATION_VERSION = "2.0";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Logger.LogInfo("Aplication Started V{0}", APPLICATION_VERSION);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
