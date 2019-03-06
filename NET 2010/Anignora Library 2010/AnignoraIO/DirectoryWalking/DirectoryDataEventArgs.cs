using System;

namespace AnignoraIO.DirectoryWalking
{
    public class DirectoryDataEventArgs : EventArgs
    {
        public string Path { get; set; }
        public long Size { get; set; }
        public int FilesCount { get; set; }

        public DirectoryDataEventArgs(string p_path, long p_size, int p_filesCount)
        {
            Path = p_path;
            Size = p_size;
            FilesCount = p_filesCount;
        }
    }
}