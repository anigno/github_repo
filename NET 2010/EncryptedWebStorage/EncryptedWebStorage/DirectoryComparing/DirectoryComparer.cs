using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedWebStorage.DirectoryComparing
{
    public enum FileStatusEnum
    {

    }

    public class DirectoryComparer
    {
        public static void CompareDirectories(string p_sourceDir, string p_destDir)
        {
            string[] sourceFolders = Directory.GetDirectories(p_sourceDir);
        }
    }
}
