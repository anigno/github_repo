using System;
using System.Collections.Generic;
using AnignoLibrary.Processes.ProcessWatching;
using System.IO;
using LoggingProvider;

namespace AnignoProcessMonitorV2.Data
{
    [Serializable]
    public class ProcessMonitorData
    {

		#region Fields (6) 


        public List<ProcessDataEntity> ProcessesList = new List<ProcessDataEntity>();

        public bool BlockingActive;
        public bool AnnounceActive = true;
        public bool IsSystemProcess;
        public bool IsApplicationClosedCurrectly;

        private object _syncRoot = new object();

		#endregion Fields 

		#region Public Methods (2) 

        /// <summary>
        /// Gets the ProcessDataEntity for given process descriptor, return ProcessDataEntity if descriptor is found in processes list else return null
        /// </summary>
        public ProcessDataEntity GetProcessData(string descriptor)
        {
            Logger.LogDebug("GetProcessData: processDescriptor={0}", descriptor);
            lock (_syncRoot)
            {
                foreach (ProcessDataEntity processData in ProcessesList)
                {
                    if (descriptor == processData.ProcessDescriptor) return processData;
                }
                return null;
            }
        }

        /// <summary>
        /// Sorts processed by process name
        /// </summary>
        public void SortProcessesData()
        {
            Logger.Log();
            lock (_syncRoot)
            {

                for (int a = 0; a < ProcessesList.Count; a++)
                {
                    for (int b = 0; b < ProcessesList.Count; b++)
                    {
                        string fileA = Path.GetFileNameWithoutExtension(ProcessesList[a].ProcessDescriptor);
                        string fileB = Path.GetFileNameWithoutExtension(ProcessesList[b].ProcessDescriptor);
                        if (fileA.CompareTo(fileB) < 0)
                        {
                            ProcessDataEntity tempProcess = ProcessesList[a];
                            ProcessesList[a] = ProcessesList[b];
                            ProcessesList[b] = tempProcess;
                        }
                    }
                }
            }
        }

		#endregion Public Methods 

    }
}