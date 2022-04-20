using System.ComponentModel;
using System.Diagnostics;
using AnignoLibrary.Processes.ProcessWatching.PeriodicProcessWatching;
using AnignoProcessMonitorV2.Data;
using AnignoLibrary.DataTypes.DataManager;
using LoggingProvider;
using System.Timers;
using System.IO;

namespace AnignoProcessMonitorV2
{
    public delegate void OnProcessesListActivityDelegate(ProcessDataEntity processData);
    public delegate void OnProcessInstancesChangedDelegate(ProcessDataEntity processData, uint instances, uint oldInstances);
    public delegate void OnProcessBlockedDelegate(string descriptor, uint pid);

    public class ProcessMonitor
    {

        #region Fields (3)


        private readonly object _syncRoot = new object();
        private readonly PeriodicProcessWatcherFast _watcher = new PeriodicProcessWatcherFast();
        private Timer _PeriodicSaveTimer;

        #endregion Fields

        #region Constructors (1)

        public ProcessMonitor()
        {
            Logger.LogInfo("ProcessMonitor CTOR");
            lock (_syncRoot)
            {
                DataManager<ProcessMonitorData>.ForceDataItemRead();
                DataManager<ProcessMonitorData>.DataItem.SortProcessesData();
                if (!DataManager<ProcessMonitorData>.DataItem.IsApplicationClosedCurrectly)
                {
                    BlockingActive = false;
                }
                IsApplicationClosedCorrectly = false;
                DataManager<ProcessMonitorData>.UpdateSavedData();
                _watcher.Interval = 500;
                _PeriodicSaveTimer = new Timer(_watcher.Interval * 1000);
            }
        }

        #endregion Constructors

        #region Properties (3)


        public bool BlockingActive
        {
            get
            {
                lock (_syncRoot)
                {
                    return DataManager<ProcessMonitorData>.DataItem.BlockingActive;
                }
            }

            set
            {
                lock (_syncRoot)
                {
                    DataManager<ProcessMonitorData>.DataItem.BlockingActive = value;
                    if (value)
                    {
                        CheckKillAllProcesses();
                    }
                }
            }
        }

        public bool AnnounceActive
        {
            get
            {
                lock (_syncRoot)
                {
                    return DataManager<ProcessMonitorData>.DataItem.AnnounceActive;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    DataManager<ProcessMonitorData>.DataItem.AnnounceActive = value;
                }
            }
        }

        public bool IsApplicationClosedCorrectly
        {
            get
            {
                lock (_syncRoot)
                {
                    return DataManager<ProcessMonitorData>.DataItem.IsApplicationClosedCurrectly;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    DataManager<ProcessMonitorData>.DataItem.IsApplicationClosedCurrectly = value;
                }
            }
        }


        #endregion Properties

        #region Events (3)

        public event OnProcessesListActivityDelegate OnProcessAddedToProcessList;

        public event OnProcessBlockedDelegate OnProcessBlocked;

        public event OnProcessInstancesChangedDelegate OnProcessInstancesChanged;

        #endregion Events

        #region Event Handlers (3)

        void _PeriodicSaveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Logger.Log();
            DataManager<ProcessMonitorData>.UpdateSavedData();
        }

        void _watcher_OnProcessInstanceCreated(string descriptor, uint pid)
        {
            Logger.LogDebug("_watcher_OnProcessInstanceCreated process: {0} with pid: {1}", descriptor, pid);
            lock (_syncRoot)
            {
                ProcessDataEntity processData = DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor);
                if (processData == null)//Process doesn't exists in known processes list
                {
                    processData = new ProcessDataEntity();
                    processData.ProcessDescriptor = descriptor;
                    DataManager<ProcessMonitorData>.DataItem.ProcessesList.Add(processData);
                    if (OnProcessAddedToProcessList != null) OnProcessAddedToProcessList(processData);
                }
                uint instances = GetProcessInstances(processData.ProcessDescriptor);
                if (OnProcessInstancesChanged != null) OnProcessInstancesChanged(processData, instances, instances - 1);
                CheckKillProcess(processData, pid);
            }
        }

        void _watcher_OnProcessInstanceDeleted(string descriptor, uint pid)
        {
            Logger.Log();
            lock (_syncRoot)
            {
                Logger.LogDebug("_watcher_OnProcessInstanceDeleted: {0} {1}", descriptor, pid);
                ProcessDataEntity testedProcess = DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor);
                uint instances = GetProcessInstances(testedProcess.ProcessDescriptor);
                if (OnProcessInstancesChanged != null) OnProcessInstancesChanged(testedProcess, instances, instances + 1);
            }
        }

        #endregion Event Handlers

        #region Private Methods (2)

        private void CheckKillAllProcesses()
        {
            Logger.Log();
            lock (_syncRoot)
            {
                Process[] processes = Process.GetProcesses(".");
                foreach (Process p in processes)
                {
                    try
                    {
                        if (p.Id < 10) continue;
                        string descriptor = p.MainModule.FileName.ToLower();
                        ProcessDataEntity processData = GetProcessData(descriptor);
                        if (processData == null) continue;
                        CheckKillProcess(processData, (uint)p.Id);
                    }
                    catch (Win32Exception)
                    {
                        //System process
                    }
                }
            }
        }

        private void CheckKillProcess(ProcessDataEntity processData, uint pid)
        {
            Logger.LogDebug("CheckKillProcess for process: {0} with pid: {1}", processData.ProcessDescriptor, pid);
            lock (_syncRoot)
            {
                if (!DataManager<ProcessMonitorData>.DataItem.BlockingActive) return;
                if (!processData.ProcessAllowed)
                {
                    Process.GetProcessById((int)pid).Kill();
                    Logger.LogDebug("_watcher_OnProcessInstanceDeleted: Process killed: {0}", processData.ProcessDescriptor);
                    if (OnProcessBlocked != null) OnProcessBlocked(processData.ProcessDescriptor, pid);
                }
            }
        }

        #endregion Private Methods

        #region Public Methods (10)

        /// <summary>
        /// Gets stored known processes
        /// </summary>
        public ProcessDataEntity[] GetKnownProcesses()
        {
            Logger.Log();
            lock (_syncRoot)
            {
                return DataManager<ProcessMonitorData>.DataItem.ProcessesList.ToArray();
            }
        }

        public ProcessDataEntity GetProcessData(string descriptor)
        {
            Logger.LogDebug("GetProcessData: descriptor={0}", descriptor);
            lock (_syncRoot)
            {
                return DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor);
            }
        }

        public uint GetProcessInstances(string descriptor)
        {
            Logger.LogDebug("GetProcessInstances: {0}", descriptor);
            lock (_syncRoot)
            {
                return _watcher.GetProcessInstances(descriptor);
            }
        }

        public void KillAllInstances(string descriptor)
        {
            Logger.LogDebug("KillAllInstances for process: {0}", descriptor);
            lock (_syncRoot)
            {
                if(!BlockingActive)return;
                Process[] processes = Process.GetProcesses(".");
                foreach (Process p in processes)
                {
                    try
                    {
                        if (p.Id < 10) continue;
                        if (descriptor == p.MainModule.FileName.ToLower())
                        {
                            int id = p.Id;
                            p.Kill();
                            Logger.LogDebug("_watcher_OnProcessInstanceDeleted: Process killed: {0}", descriptor);
                            if (OnProcessBlocked != null) OnProcessBlocked(descriptor, (uint)id);
                        }
                    }
                    catch (Win32Exception)
                    {
                        //System process
                    }
                }
            }
        }

        public void RemoveKnownProcess(string descriptor)
        {
            Logger.Log();
            ProcessDataEntity processDataToRemove = DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor);
            DataManager<ProcessMonitorData>.DataItem.ProcessesList.Remove(processDataToRemove);
            _watcher.RemoveProcessData(descriptor);
        }

        public void Start()
        {
            Logger.Log();
            lock (_syncRoot)
            {
                _watcher.OnProcessInstanceCreated += _watcher_OnProcessInstanceCreated;
                _watcher.OnProcessInstanceDeleted += _watcher_OnProcessInstanceDeleted;
                _PeriodicSaveTimer.Elapsed += _PeriodicSaveTimer_Elapsed;
                _watcher.Start();
                _PeriodicSaveTimer.Start();
            }
        }

        public void Stop()
        {
            Logger.Log();
            lock (_syncRoot)
            {
                _watcher.Stop();
                _PeriodicSaveTimer.Stop();
                _watcher.OnProcessInstanceCreated -= _watcher_OnProcessInstanceCreated;
                _watcher.OnProcessInstanceDeleted -= _watcher_OnProcessInstanceDeleted;
                _PeriodicSaveTimer.Elapsed -= _PeriodicSaveTimer_Elapsed;
            }
        }

        public void UpdateAllow(string descriptor, bool isAallow)
        {
            Logger.LogDebug("UpdateAllow for process: {0} isAllow={1}", descriptor, isAallow);
            lock (_syncRoot)
            {
                ProcessDataEntity processData = DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor);
                processData.ProcessAllowed = isAallow;
                if (processData.ProcessAllowed) return;

                KillAllInstances(descriptor);
            }
        }

        public void UpdateAnnounce(string descriptor, bool announce)
        {
            Logger.Log();
            lock (_syncRoot)
            {
                DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor).ProcessAnnounceAllow = announce;
            }
        }

        public void UpdateDescription(string descriptor, string description)
        {
            Logger.Log();
            lock (_syncRoot)
            {
                DataManager<ProcessMonitorData>.DataItem.GetProcessData(descriptor).ProcessDescription = description;
            }
        }

        #endregion Public Methods

        /// <summary>
        /// Add '_' to the end of a file, preventing future running
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public bool RenameProcess(string descriptor)
        {
            Logger.Log();
            try
            {
                File.Move(descriptor, descriptor + "_");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}