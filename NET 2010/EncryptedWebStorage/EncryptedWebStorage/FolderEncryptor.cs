using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnignoraDataTypes.Configurations;
using AnignoraIO;
using EncryptedWebStorage.Config;

namespace EncryptedWebStorage
{
    public class FolderEncryptor
    {
        private readonly ConfiguratorXml<FolderEncryptorConfiguarion> m_configurator = new ConfiguratorXml<FolderEncryptorConfiguarion>(@"EWS.config", "Config");
        private readonly FileSystemWatcher m_watcher = new FileSystemWatcher();

        public FolderEncryptor()
        {
            m_configurator.Load();
            FolderEncryptorConfiguarion conf = m_configurator.Configuration;
            if (!Directory.Exists(conf.FolderMonitored)) Directory.CreateDirectory(conf.FolderMonitored);
            if (!Directory.Exists(conf.FolderEncrypted)) Directory.CreateDirectory(conf.FolderEncrypted);


            initWatcher();
        }

        private void initWatcher()
        {
            FolderEncryptorConfiguarion conf = m_configurator.Configuration;
            m_watcher.Path = conf.FolderMonitored;
            m_watcher.EnableRaisingEvents = true;
            m_watcher.IncludeSubdirectories = true;

            m_watcher.NotifyFilter = NotifyFilters.FileName;
            m_watcher.Filter = "*.*";
            m_watcher.Created += onCreate;
            m_watcher.Deleted += onDeleted;
            m_watcher.Renamed += onRenamed;
        }

        private void onDeleted(object p_sender, FileSystemEventArgs p_e)
        {
            Console.WriteLine("onDeleted File: " + p_e.FullPath + " " + p_e.ChangeType);
        }

        private static void onCreate(object p_source, FileSystemEventArgs p_e)
        {
            Console.WriteLine("onCreate File: " + p_e.FullPath + " " + p_e.ChangeType);
        }

        private static void onRenamed(object p_source, RenamedEventArgs p_e)
        {
            Console.WriteLine("onRenamed File: {0} renamed to {1}", p_e.OldFullPath, p_e.FullPath);
        }
    }
}
