using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.IO
{
    #region Enums
    public enum BackupTypeEnum
    {
        /// <summary>Copy source to destination</summary>
        Copy,
        /// <summary>Syncronization occurs on user request</summary>
        OfflineSync,
        /// <summary>Syncronization occurs online</summary>
        OnlineSync
    }

    public enum CopyTypeEnum
    {
        /// <summary>Overwrites existing old files</summary>
        Overwrite,
        /// <summary>Copy existing old files to history folder before overwriting</summary>
        Differential
    }
    #endregion Enums

    public class BackupEngine
    {
        private BackupTypeEnum _backupType;

        public string SourceDirectory { get; set; }
        public string DestinationDirectory { get; set; }

        public BackupTypeEnum BackupType
        {
            get { return _backupType; }
            set
            {
                _backupType = value;
                if (_backupType == BackupTypeEnum.OnlineSync)
                {
                    StartOnLine();
                }
                else
                {
                    StopOnline();
                }
            }
        }

        private void StopOnline()
        {
        }

        private void StartOnLine()
        {
        }

        public void Run()
        {

        }
    }
}
