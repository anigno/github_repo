using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using AnignoLibrary.Processes.ProcessMonitoring.WmiProcessMonitoring;

namespace AnignoLibrary.Processes.ProcessMonitoring.WmiProcessMonitoring
{
    public delegate void ProcessEventHandler(Win32_Process proc);

    public class ProcessBaseWatcher : ManagementEventWatcher
    {
        public ProcessBaseWatcher()
        {
            Query.QueryLanguage = "WQL";
        }
    }
}