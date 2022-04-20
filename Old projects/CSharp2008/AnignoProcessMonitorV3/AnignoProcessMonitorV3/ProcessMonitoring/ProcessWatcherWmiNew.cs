using System;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AnignoProcessMonitorV3.ProcessMonitoring
{
    public class ProcessWatcherWmiNew
    {

		#region Enums (1) 

        public enum ProcessActivityEnum
        {
            Created,
            Deleted
        }

		#endregion Enums 

		#region Fields (5) 


        private readonly List<uint> _currentRunningProcessesList = new List<uint>();

        private readonly Dictionary<uint, ProcessData> _removedProcessedDictionary = new Dictionary<uint, ProcessData>();
        private readonly Dictionary<uint, ProcessData> _knownRunningProcessesDictionay = new Dictionary<uint, ProcessData>();
        private readonly ManagementObjectSearcher _managementObjectSearcherProcesses = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Process");
        private readonly Timer _periodicTimer = new Timer();

		#endregion Fields 

		#region Constructors (1) 

        public ProcessWatcherWmiNew(int intervalMs)
        {
            _periodicTimer.Interval = intervalMs;
            _periodicTimer.Tick += _periodicTimer_Tick;
        }

		#endregion Constructors 

		#region Events (1) 

        public event ProcessWatcherWmiNewActivityEventHandler OnProcessActivity;

		#endregion Events 

		#region Delegates (1) 

        public delegate void ProcessWatcherWmiNewActivityEventHandler(ProcessData processData, ProcessActivityEnum activity);

		#endregion Delegates 

		#region Event Handlers (1) 

        void _periodicTimer_Tick(object sender, EventArgs e)
        {
            CheckRunningProcessesData();
        }

		#endregion Event Handlers 

		#region Public Methods (4) 

        public void CheckRunningProcessesData()
        {
            lock (_knownRunningProcessesDictionay)
            {
                //Check for new processes
                _currentRunningProcessesList.Clear();
                _removedProcessedDictionary.Clear();
                foreach (ManagementObject queryObj in _managementObjectSearcherProcesses.Get())
                {
                    uint pid = (uint) queryObj["ProcessId"];
                    _currentRunningProcessesList.Add(pid);
                    if (!_knownRunningProcessesDictionay.ContainsKey(pid))
                    {
                        //process created
                        ProcessData pd = new ProcessData();
                        pd.ProcessId = (uint) queryObj["ProcessId"];
                        pd.Caption = (string) queryObj["Caption"];
                        pd.Name = (string) queryObj["Name"];
                        pd.Description = "";
                        pd.ExecutablePath = (string)queryObj["ExecutablePath"];
                        pd.ParentProcessId = (uint)queryObj["ParentProcessId"];
                        //Set commandline, possible null for idle and system processes
                        string commandLine=(string) queryObj["CommandLine"];
                        if(commandLine==null)commandLine=pd.Name;
                        pd.CommandLine = commandLine.ToLower();
                        //Set creation date, possible null for idle and system processes
                        string sDateTime = (string) queryObj["CreationDate"];
                        pd.CreationDateString = sDateTime == null ? "" :GetDateFromWmiDateString( sDateTime.Split('+')[0]);
                        _knownRunningProcessesDictionay.Add(pd.ProcessId, pd);
                        if (OnProcessActivity != null) OnProcessActivity(pd, ProcessActivityEnum.Created);
                    }
                }
                //Check for deleted processes
                foreach (KeyValuePair<uint, ProcessData> processData in _knownRunningProcessesDictionay)
                {
                    if (!_currentRunningProcessesList.Contains(processData.Key))
                    {
                        //process deleted
                        _removedProcessedDictionary.Add(processData.Key, processData.Value);
                    }
                }
                //Actually remove deleted processes
                foreach (KeyValuePair<uint, ProcessData> processData in _removedProcessedDictionary)
                {
                    ProcessData pd = processData.Value; //Nothing holds handled ProcessData after removal
                    _knownRunningProcessesDictionay.Remove(processData.Key);
                    if (OnProcessActivity != null) OnProcessActivity(pd, ProcessActivityEnum.Deleted);
                }
            }
        }

        private string GetDateFromWmiDateString(string sDate)
        {
            return string.Format(@"{0}/{1}/{2} {3}:{4}:{5}",
                sDate.Substring(0,4),
                sDate.Substring(4,2),
                sDate.Substring(6,2),
                sDate.Substring(8,2),
                sDate.Substring(10,2),
                sDate.Substring(12,2)
                );
        }

        public void DeleteProcess(uint pid)
        {
            lock (_knownRunningProcessesDictionay)
            {
                _knownRunningProcessesDictionay.Remove(pid);
            }
        }

        public void Start()
        {
            _periodicTimer.Start();
        }

        public void Stop()
        {
            _periodicTimer.Stop();
        }

		#endregion Public Methods 

    }
}