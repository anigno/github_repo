using System;

namespace AnignoraIO.DirectoryWalking
{
    public class DirectoryWalkerActivityEventArgs : EventArgs
    {
        public string Path { get; set; }

        public DirectoryWalkerActivityEventArgs(string p_path)
        {
            Path = p_path;
        }
    }
}