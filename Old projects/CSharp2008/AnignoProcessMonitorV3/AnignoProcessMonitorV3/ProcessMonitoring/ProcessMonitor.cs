using System.Collections.Generic;
using AnignoLibrary.DataTypes.DataManager;
using LoggingProvider;
using System.Diagnostics;
using System;

namespace AnignoProcessMonitorV3.ProcessMonitoring
{
    public class ProcessMonitor
    {

		#region Const Fields (1) 

        private const int PERIODIC_INTERVAL_MS = 1000;

		#endregion Const Fields 

		#region Fields (4) 


        private bool _blockingEngaged;

        private readonly MainData _data;
        private readonly object _syncRoot = new object();
        private readonly ProcessWatcherWmiNew _processWatcher = new ProcessWatcherWmiNew(PERIODIC_INTERVAL_MS);

		#endregion Fields 

		#region Constructors (1) 

        public ProcessMonitor()
        {
            Logger.LogDebug("ProcessMonitor started");
            DataManagerContractBased<MainData>.OnAfterFirstLoad += ProcessMonitor_OnAfterFirstLoad;
            _data = DataManagerContractBased<MainData>.DataItem;
            _processWatcher.OnProcessActivity += _processWatcher_OnProcessActivity;
            _processWatcher.Start();
        }

        void ProcessMonitor_OnAfterFirstLoad(Type type, MainData dataItem)
        {
            foreach (ProcessData pd in dataItem.ProcessesData.Values)
            {
                pd.Instances = 0;
            }
        }

       

		#endregion Constructors 

		#region Properties (1) 


		#endregion Properties 

		#region Events (3) 

        public event ProcessMonitorActivityEventHandler OnProcessAdded;

        public event ProcessMonitorActivityEventHandler OnProcessCreated;

        public event ProcessMonitorActivityEventHandler OnProcessDeleted;

        public event ProcessMonitorActivityEventHandler OnProcessBlocked;

        public event ProcessMonitorActivityEventHandler OnProcessBlockedError;

		#endregion Events 

		#region Delegates (1) 

        public delegate void ProcessMonitorActivityEventHandler(ProcessData processData);

		#endregion Delegates 

		#region Event Handlers (1) 

        public void _processWatcher_OnProcessActivity(ProcessData processData, ProcessWatcherWmiNew.ProcessActivityEnum activity)
        {
            lock (_syncRoot)
            {
                _processWatcher.Stop();
                if (activity == ProcessWatcherWmiNew.ProcessActivityEnum.Created)
                {
                    //Process created
                    //System and Idle processes doesn't have a command line
                    if (processData.CommandLine == null) processData.CommandLine = processData.Name.ToLower();
                    if (_data.ProcessesData.ContainsKey(processData.CommandLine))
                    {
                        //Process is known
                        ProcessData pd = _data.ProcessesData[processData.CommandLine];
                        pd.ProcessId = processData.ProcessId;
                        pd.Instances++;
                        Logger.LogDebug("Process: {0} was created", pd.CommandLine);
                        if (OnProcessCreated != null) OnProcessCreated(pd);
                        CheckKillProcess(pd, false);
                    }
                    else
                    {
                        //Process isn't known
                        processData.Allowed = false;
                        processData.Instances++;
                        _data.ProcessesData.Add(processData.CommandLine.ToLower(), processData);
                        Logger.LogDebug("Process: {0} was added", processData.CommandLine);
                        if (OnProcessAdded != null) OnProcessAdded(processData);
                        Logger.LogDebug("Process: {0} was created", processData.CommandLine);
                        if (OnProcessCreated != null) OnProcessCreated(processData);
                        CheckKillProcess(processData, false);
                    }
                }
                else
                {
                    //Process deleted
                    ProcessData pd = _data.ProcessesData[processData.CommandLine];
                    pd.Instances--;
                    Logger.LogDebug("Process: {0} was deleted", processData.CommandLine);
                    if (OnProcessDeleted != null) OnProcessDeleted(pd);
                }
                _processWatcher.Start();
            }
        }

		#endregion Event Handlers 

		#region Public Methods (2) 

        public void CheckKillProcess(ProcessData pd, bool forceKill)
        {
            bool kill = false;
            if (!pd.Allowed && _data.BlockingEngage) kill = true;
            if (forceKill) kill = true;
            if (!kill) return;
            try
            {
                Process processToKill = Process.GetProcessById((int)pd.ProcessId);
                //processToKill.Kill();
                if (OnProcessBlocked != null) OnProcessBlocked(pd);
                Logger.LogDebug("Process: {0} was killed", pd.CommandLine);
            }
            catch (Exception ex)
            {
                if (OnProcessBlockedError != null) OnProcessBlockedError(pd);
                Logger.LogError("Process: {0} wasn't killed. {1}", pd.CommandLine, ex.Message);
            }
        }

        public void RemoveProcessFromKnownProcesses(ProcessData processData)
        {
            lock (_syncRoot)
            {
                _data.ProcessesData.Remove(processData.CommandLine);
                _processWatcher.DeleteProcess(processData.ProcessId);
            }
        }

		#endregion Public Methods 

    }
}