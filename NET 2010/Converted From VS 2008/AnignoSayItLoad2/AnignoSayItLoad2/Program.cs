using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AnignoSayItLoad2
{
    static class Program
    {
        public static string Version = " V1.2";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
