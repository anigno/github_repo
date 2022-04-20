using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnignoLibrary.DataTypes.DataManager;
using FinanceAnalizer.Data;
using LoggingProvider;

namespace FinanceAnalizer
{
    static class Program
    {
		#region (------------------  Const Fields  ------------------)
        public const string VERSION = "2.3";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Static Fields  ------------------)
        public static DateTime VerifiedDate;
		#endregion (------------------  Static Fields  ------------------)


		#region (------------------  Event Handlers  ------------------)
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Logger.LogError(ex, "FATAL !!!, Unhandled Exception");
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Static Methods  ------------------)
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Logger.LogInfo("Application started");
            DataManagerContractBased<ApplicationData>.DataFilePath = Environment.CurrentDirectory;
            DataManagerContractBased<ApplicationData>.DataFileName = "FinanceAnalizerData.xml";
            VerifiedDate = new DateTime(2010,7, 20);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
		#endregion (------------------  Static Methods  ------------------)
    }
}
