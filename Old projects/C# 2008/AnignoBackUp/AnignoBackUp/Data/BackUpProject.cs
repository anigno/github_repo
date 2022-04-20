using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnignoBackUp.Data
{
    public class BackUpProject
    {
        #region Fields
        private DateTime _lastUpdate = DateTime.Now;
        private TimeSpan _scheduleinterval = new TimeSpan(long.MaxValue);
        private List<BackupTask> _taskList = new List<BackupTask>();
        private object _activitySynch = new object();
        private bool _monitored = false;
        private bool _scheduled = false;
        FileSystemWatcher fsw = new FileSystemWatcher();
        #endregion

        #region CTOR
        public BackUpProject()
        {
        }
        #endregion

        #region Properties
        public DateTime LastUpdated
        {
            get { return _lastUpdate; }
        }

        public int ScheduleIntervalMinutes
        {
            get
            {
                lock (_activitySynch)
                {

                    return _scheduleinterval.Minutes;
                }
            }
            set
            {
                lock (_activitySynch)
                {

                    _scheduleinterval = new TimeSpan(0, value, 0);
                }
            }
        }

        public BackupTask[] JobList
        {
            get
            {
                lock (_activitySynch)
                {

                    return _taskList.ToArray();
                }
            }
        }

        /// <summary>
        /// Gets or sets if project is monitored by FileSystemWatcher for changes
        /// </summary>
        public bool Monitored
        {
            get
            {
                lock (_activitySynch)
                {
                    return _monitored;
                }
            }
            set
            {
                lock (_activitySynch)
                {
                    _monitored = value;
                    fsw.EnableRaisingEvents = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets if project's schedule every interval is active
        /// </summary>
        public bool Scheduled
        {
            get
            {
                lock (_activitySynch)
                {
                    return _scheduled;
                }
            }
            set
            {
                lock (_activitySynch)
                {
                    _scheduled = value;
                }
            }
        }

        #endregion

        #region Public
        public void AddPath(string path)
        {
            lock (_activitySynch)
            {

            }
            //if (!_jobList.Contains(path))
            //{
            //    _jobList.Add(path);
            //}
        }

        public void RemovePath(string path)
        {
            //if (_jobList.Contains(path))
            //{
            //    _jobList.Remove(path);
            //}
            //else
            //{
            //    string exceptionMessage = string.Format("RemovePath, Source path: {0} wasn't found in source path list", path);
            //    throw new Exception(exceptionMessage);
            //}
        }

        public void ClearSourcePathList()
        {
            //_sourcePathList.Clear();
        }
        #endregion


        #region Private
        private bool IsFile(string fileOrDirectoryPath)
        {
            return !Directory.Exists(fileOrDirectoryPath);
        }

        private void GetJob()
        {

        }
        #endregion

    }
}