using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Synchronization.Files;

namespace EncryptedWebStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSyncProvider fsp = new FileSyncProvider(@"C:\temp\FolderMonitored");
            fsp.Initialize();
            new FolderEncryptor();
            Console.ReadKey();
        }
    }
}
