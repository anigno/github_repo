using System;

namespace AnignoraIO.AsyncFileAndFolderCopy
{
    public class CopyDirectoryEventArgs : EventArgs
    {
        public string SourcePath { get; private set; }
        public string DestPath { get; private set; }

        public CopyDirectoryEventArgs(string p_sourcePath, string p_destPath)
        {
            SourcePath = p_sourcePath;
            DestPath = p_destPath;
        }
    }
}