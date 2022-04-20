using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnignoLibrary.IO
{
    public class IOSearcher
    {
        public DirectoryItem BuildDirectoryTree(bool directoriesOnly)
        {
            return null;
        }

        private void BuildTreeRecurse(DirectoryItem directory)
        {
            foreach (string file in Directory.GetFiles(directory.FullPath))
            {
                
            }
        }
    }
}
