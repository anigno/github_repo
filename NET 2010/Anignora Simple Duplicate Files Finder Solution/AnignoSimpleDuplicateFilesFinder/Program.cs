using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LoggingProvider;

namespace AnignoSimpleDuplicateFilesFinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.LogInfo("Application started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
