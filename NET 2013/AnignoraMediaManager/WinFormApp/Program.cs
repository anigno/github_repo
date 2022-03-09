using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnignoraDataTypes.CommonTypes;
using AnignoraMediaManager;

namespace WinFormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MediaManager mediaManager=new MediaManager();

            //mediaManager.AddVolumeChange(DayOfWeek.Sunday, new Time(1, 2, 3, 0), 20);
            //mediaManager.AddVolumeChange(DayOfWeek.Monday, new Time(2, 2, 3, 0), 20);
            //mediaManager.AddVolumeChange(DayOfWeek.Thursday, new Time(3, 2, 3, 0), 20);
            //mediaManager.AddVolumeChange(DayOfWeek.Thursday, new Time(4, 2, 3, 0), 20);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
