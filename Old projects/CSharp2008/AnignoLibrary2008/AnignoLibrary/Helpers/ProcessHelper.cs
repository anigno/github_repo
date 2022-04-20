using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace AnignoLibrary.Helpers
{
    public class ProcessHelper
    {
        public static uint GetInstances(string applicationFullPath)
        {
            Process[] processes = Process.GetProcesses();
            uint instancesCount = 0;
            foreach (Process p in processes)
            {
                if (p.Id < 10) continue;
                try
                {
                    if (p.MainModule == null) continue;
                    string path = p.MainModule.FileName;
                    if (path.ToLower() == applicationFullPath.ToLower()) instancesCount++;
                }
                catch(Win32Exception)
                {
                    //System, process
                }
            }
            return instancesCount;
        }

        public static bool IsProcessRunning(string processName)
        {
            bool isMutexCreated;
            new Mutex(false, processName, out isMutexCreated);
            return !isMutexCreated;
        }
    }
}
