using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.IO
{
    public class DirectoryItem : ItemBase
    {
        public List<DirectoryItem> Directories = new List<DirectoryItem>();
        public List<FileItem> Files = new List<FileItem>();
    }
}
