using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnignoSimpleDuplicateFilesFinder
{
    public class FileItem
    {
        private string mFileName;
        private int mFileSize;
        private List<string> mFoundPaths=new List<string>();


        public string FileName
        {
            get { return mFileName; }
            set { mFileName = value; }
        }

        public int FileSize
        {
            get { return mFileSize; }
            set { mFileSize = value; }
        }

        public List<string> FoundPaths
        {
            get { return mFoundPaths; }
            set { mFoundPaths = value; }
        }
    }
}
