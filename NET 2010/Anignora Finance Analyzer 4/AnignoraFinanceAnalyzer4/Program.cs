using System;
using System.Threading;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer4.UI.Forms;
using LoggingProvider;


namespace AnignoraFinanceAnalyzer4
{
    static class Program
    {
		#region (------  Static Methods  ------)

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.Name = "ApplicationRunnerThread";
            Logger.LogInfo("Application Started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

		#endregion (------  Static Methods  ------)
    }
}
