using System.Management;
using AnignoLibrary.Processes.ProcessMonitoring.WmiProcessMonitoring;

//To create Win32_Process.cs, run: mgmtclassgen Win32_Process /n root\cimv2 /o WMI.Win32
//E.G. C:\Program Files\Microsoft SDKs\Windows\v6.0A\bin>mgmtclassgen Win32_Process /n root\cimv2 /o WMI.Win32
//Resulting:
//Microsoft (R) .NET Framework Version 3.5.21022.8
//Copyright (C) Microsoft Corporation.  All rights reserved.
//Generating Code for WMI Class Win32_Process ...
//Code Generated Successfully!!!!
//Rename the file Process.cs to Win32_Process.cs

namespace AnignoLibrary.Processes.ProcessMonitoring
{
    //public delegate void ProcessEventHandler(Win32_Process proc);

    public class ProcessWatcher_old : ManagementEventWatcher
    {
        #region Events decleration
        public event ProcessEventHandler ProcessCreated;
        public event ProcessEventHandler ProcessDeleted;
        //public event ProcessEventHandler ProcessModified;
        #endregion

        #region WMI WQL process query strings
        //__InstanceOperationEvent
        //__InstanceCreationEvent
        //__InstanceDeletionEvent
        private const string WMI_OPER_EVENT_QUERY = @"SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'";
        private const string WMI_OPER_EVENT_QUERY_WITH_PROC = WMI_OPER_EVENT_QUERY + " and TargetInstance.Name = '{0}'";
        #endregion

        #region CTORs
        /// <summary>
        /// Watch all processes
        /// </summary>
        public ProcessWatcher_old()
        {
            Init(string.Empty);
        }

        /// <summary>
        /// Watch given process
        /// </summary>
        /// <param name="processName"></param>
        public ProcessWatcher_old(string processName)
        {
            Init(processName);
        }
        #endregion

        #region Private
        private void Init(string processName)
        {
            Query.QueryLanguage = "WQL";
            if (string.IsNullOrEmpty(processName)) 
            {
                Query.QueryString = WMI_OPER_EVENT_QUERY;
            }
            else
            {
                Query.QueryString =string.Format(WMI_OPER_EVENT_QUERY_WITH_PROC, processName);
            }

            EventArrived += watcher_EventArrived;
        }

        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string eventType = e.NewEvent.ClassPath.ClassName;
            Win32_Process proc = new Win32_Process(e.NewEvent["TargetInstance"] as ManagementBaseObject);
            switch (eventType)
            {
                case "__InstanceCreationEvent":
                    if (ProcessCreated != null)
                    {
                        ProcessCreated(proc);
                    }
                    break;
                case "__InstanceDeletionEvent":
                    if (ProcessDeleted != null)
                    {
                        ProcessDeleted(proc);
                    }
                    break;
                //case "__InstanceModificationEvent":
                //    if (ProcessModified != null)
                //    {
                //        ProcessModified(proc);
                //    }
                //    break;
            }
        }


        #endregion

    }
}
 