using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnignoraDataTypes.Configurations;

namespace EncryptedWebStorage.Config
{
    public class FolderEncryptorConfiguarion:IConfiguration
    {
        public string FolderMonitored { get; set; }
        public string FolderEncrypted { get; set; }
        public string[] ExtensionsIncluded{ get; set; }
        public string[] ExtensionsExcluded{ get; set; }
        public string[] FoldersExcluded{ get; set; }
        
        public void SetDefaults()
        {
            FolderMonitored = @"c:\temp\FolderMonitored";
            FolderEncrypted = @"c:\temp\FolderEncrypted";
        }
    }
}
