using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnignoBackUp.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class BackupTask
    {
        private string _path = "";
        private FileSystemWatcher fsw = new FileSystemWatcher();

        public BackupTask()
        {
            fsw.Filter = "*.*";
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.Deleted += new FileSystemEventHandler(fsw_Deleted);
            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
            fsw.IncludeSubdirectories = true;
            fsw.InternalBufferSize = 999;
        }
    }
}
