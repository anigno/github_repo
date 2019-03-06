using System;
using System.Windows.Forms;
using FinanceAnalizer3.UI;
using LoggingProvider;
using FinanceAnalizer3.Data;
using System.Threading;

namespace FinanceAnalizer3
{
    static class MainApplication
    {
		#region (------------------  Static Methods  ------------------)
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.LogInfo("Aplication Started {0}", Application.ProductVersion);

            //if (DateTime.Now >= new DateTime(2011, 2, 21))
            //{
            //    while (true)
            //    {
            //        Logger.LogError("Date is not in a valid format!");
            //        Thread.Sleep(3000);
            //    }
            //}


            //Start UI thread
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            Thread.Sleep(2000);
        }
		#endregion (------------------  Static Methods  ------------------)
    }
}
