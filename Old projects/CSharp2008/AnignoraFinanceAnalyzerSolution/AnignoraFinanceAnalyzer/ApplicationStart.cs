using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer.Data;
using AnignoraFinanceAnalyzer.UI.Forms;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer
{
    static class ApplicationStart
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.LogInfo("Application Started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataManager.Instance.LoadApplicationData();

            Logger.LogError("Security has been removed for developement");
            DataManager.Instance.LoadSymbolsData();
            Application.Run(new FormMain());


            //FormLogin f = new FormLogin();
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    DataManager.Instance.LoadSymbolsData();
            //    Application.Run(new FormMain());
            //}
        }
    }
}
