using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer.Data
{
    public class DataManager
    {
		#region (------------------  Const Fields  ------------------)
        private const string APPLICATION_DATA_FILE_NAME = "ApplicationData.bin";
        private const string SYMBOLS_DATA_FILE_NAME = "SymbolsData.bin";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Static Fields  ------------------)
        private static DataManager instance;
		#endregion (------------------  Static Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private ApplicationData applicationData = new ApplicationData();
        private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();
        private readonly object syncRoot = new object();
        private SymbolsData symbolsData = new SymbolsData();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        private DataManager()
        {
            //Singleton pattern
            Logger.LogInfo("DataManager Created");
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public static DataManager Instance
        {
            get { return instance ?? (instance = new DataManager()); }
        }

        public string Version
        {
            get { return applicationData.Version; }
        }

            public string LoginPassword
        {
            get
            {
                lock (syncRoot)
                {
                    return applicationData.LoginPassword;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    applicationData.LoginPassword = value;
                }
            }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Public Methods  ------------------)
        public void LoadApplicationData()
        {
            lock (Instance)
            {
                FileStream fs = null;
                try
                {
                    Logger.Log();
                    if (!File.Exists(APPLICATION_DATA_FILE_NAME)) SaveApplicationData();
                    fs = new FileStream(APPLICATION_DATA_FILE_NAME, FileMode.Open);
                    applicationData = (ApplicationData)binaryFormatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    applicationData = new ApplicationData();
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }

        public void LoadSymbolsData()
        {
            lock (Instance)
            {
                FileStream fs = null;
                try
                {
                    Logger.Log();
                    if (!File.Exists(SYMBOLS_DATA_FILE_NAME)) SaveSymbolsData();
                    fs = new FileStream(SYMBOLS_DATA_FILE_NAME, FileMode.Open);
                    symbolsData = (SymbolsData)binaryFormatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); ;
                    symbolsData = new SymbolsData();
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }

        public void SaveApplicationData()
        {
            lock (Instance)
            {
                FileStream fs = null;
                try
                {
                    Logger.Log();
                    fs = new FileStream(APPLICATION_DATA_FILE_NAME, FileMode.Create);
                    binaryFormatter.Serialize(fs, applicationData);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); ;
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }

        public void SaveSymbolsData()
        {
            lock (Instance)
            {
                FileStream fs = null;
                try
                {
                    Logger.Log();
                    fs = new FileStream(SYMBOLS_DATA_FILE_NAME, FileMode.Create);
                    binaryFormatter.Serialize(fs, symbolsData);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); ;
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }
		#endregion (------------------  Public Methods  ------------------)


    }
}
