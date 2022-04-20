using System;
using System.ComponentModel;
using System.Diagnostics;
using AnignoLibrary.Processes.ProcessMonitoring.WmiProcessMonitoring;
using LoggingProvider;

namespace AnignoLibrary.Processes.ProcessMonitoring
{
    #region Delegates
    public delegate void OnProcessWatcherExtActionDelegate(string processFullPath);
    #endregion

    /// <summary>
    /// Uses ProcessWatcher to monitor processes creation and deletion,
    /// and, in addition, on start, raises OnProcessFoundRunning for each running process.
    /// </summary>
    public class ProcessWatcherExt_old
    {
        #region Events decleration
        public event OnProcessWatcherExtActionDelegate OnProcessCreated;
        public event OnProcessWatcherExtActionDelegate OnProcessDeleted;
        public event OnProcessWatcherExtActionDelegate OnProcessFoundRunning;
        #endregion

        #region Fields
        private readonly object _syncRoot = new object();
        private readonly ProcessWatcher_old _watcher = new ProcessWatcher_old();
        private bool _isRunning = false;
        #endregion

        #region Properties
        public bool IsRunning
        {
            get { return _isRunning; }
        }
        #endregion

        #region Public
        public void Start()
        {
            lock (_syncRoot)
            {
                if (IsRunning)
                {
                    throw new Exception("ProcessWatcherExt is already running");
                }
                _watcher.ProcessCreated += _watcher_ProcessCreated;
                _watcher.ProcessDeleted += _watcher_ProcessDeleted;
                _watcher.Start();
                IterateRunningProcesses();
                _isRunning = true;
            }
        }

        public void Stop()
        {
            lock (_syncRoot)
            {
                if (!IsRunning)
                {
                    throw new Exception("ProcessWatcherExt is not running");
                }
                _watcher.ProcessCreated -= _watcher_ProcessCreated;
                _watcher.ProcessDeleted -= _watcher_ProcessDeleted;
                _watcher.Stop();
                _isRunning = false;
            }
        }

        public void IterateRunningProcesses()
        {
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    if (p.ProcessName.ToLower() == "system") continue;
                    if (p.ProcessName.ToLower() == "idle") continue;
                    //Check for system process, exception will be thrown here if it is
                    if (p.MainModule == null) continue;
                    RaiseOnProcessFoundRunning(p.MainModule.FileName);
                }
                catch (Win32Exception)
                {
                    //System process has no MainModule
                }
            }
        }
        #endregion

        #region Private ebents handlers
        private void _watcher_ProcessDeleted(Win32_Process proc)
        {
            if (OnProcessDeleted != null) OnProcessDeleted(proc.ExecutablePath);
        }

        private void _watcher_ProcessCreated(Win32_Process proc)
        {
            if (OnProcessCreated != null) OnProcessCreated(proc.ExecutablePath);
        }
        #endregion

        #region Private
        private void RaiseOnProcessFoundRunning(string ProcessFullPath)
        {
            if (OnProcessFoundRunning != null) OnProcessFoundRunning(ProcessFullPath);
        }
        #endregion

    }
}