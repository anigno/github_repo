using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnignoBackUp.Data
{
    public class TaskFileSystemWatcher
    {
        private string _path = "";
        FileSystemWatcher fsw = new FileSystemWatcher();

        #region CTOR
        public TaskFileSystemWatcher()
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
        #endregion

        #region Events
        void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        void fsw_Created(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
