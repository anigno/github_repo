using System;
using System.Windows.Forms;
using AnignoFileSync.Data;
using LoggingProvider;
using AnignoLibrary.DataTypes.DataManager;

namespace AnignoFileSync
{
    static class Program
    {
        public const string APPLICATION_VERSION = "1.10";
        public static string[] ChangeSet ={
                                      @"1.6 Added current file display",
                                      @"1.7 Fixed problem when path too long",
                                      @"1.8 Fixed short path (E.G. c: c:\)",
                                      @"1.9 Fixed bug in GetRelativePath()",
                                      @"1.10 Fixed bugs"
                                  };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.LogInfo("Application started " + APPLICATION_VERSION);
            DataManager<ApplicationData>.DataFilePath = Environment.CurrentDirectory;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
