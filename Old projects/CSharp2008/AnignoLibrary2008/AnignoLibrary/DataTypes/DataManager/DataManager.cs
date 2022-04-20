using System;
using System.IO;
using System.Xml.Serialization;
using LoggingProvider;
using System.Threading;

namespace AnignoLibrary.DataTypes.DataManager
{
    /// <summary>
    /// Serialization data manager using XmlSerializer. Automatically loads and saves data, item delivered as template.
    /// Thread safe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class DataManager<T> where T : class, new() 
    {


        #region Fields and consts
        private const string DEFAULT_DATA_FILE_PARTIAL_PATH = "\\_Anigno Documents\\_ApplicationsData";
        //private const string DEFAULT_DATA_FILE_NAME = "Data.xml";
        private static StaticDestructor _staticDestructor = new StaticDestructor();
        private static string _dataFilePath;
        private static string _dataFileName;
        private static readonly object _syncRoot = new object();
        private static T _dataItem;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the data file's full path, if the path doesn't exists,
        /// it will be created on first usage. Path must end with path delimitter.
        /// (value must be set before any use of data item!)
        /// </summary>
        public static string DataFilePath
        {
            get
            {
                lock (_syncRoot)
                {
                    return _dataFilePath;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _dataFilePath = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data file's name, if the path doesn't exists,
        /// it will be created on first usage
        /// (value must be set before any use of data item!)
        /// </summary>
        public static string DataFileName
        {
            get
            {
                lock (_syncRoot)
                {
                    return _dataFileName;
                }
            }
            set {
                lock (_syncRoot)
                {
                    _dataFileName = value;
                }
            }
        }

        /// <summary>
        /// Gets the data item class managed by this DataManager,
        /// only one DataManager exists per data item
        /// </summary>
        public static T DataItem
        {
            get
            {
                lock (_syncRoot)
                {
                    lock (_syncRoot)
                    {
                            if (_dataItem == null)
                            {
                                LoadDataItem();
                            }
                            return _dataItem;
                    }
                }
            }
        }
        #endregion

        #region CTOR and DTOR
        static DataManager()
        {
            lock (_syncRoot)
            {
                _dataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + DEFAULT_DATA_FILE_PARTIAL_PATH;
                _dataFileName = typeof(T) + ".XML";
            }
        }

        private class StaticDestructor
        {
            ~StaticDestructor()
            {
                SaveDataItem();
            }
    }

        #endregion

        #region Public
        /// <summary>
        /// Force DataItem read from file, used to create a starting point at user's application for
        /// first data item access (Eg. Sorting)
        /// </summary>
        public static void ForceDataItemRead()
        {
            lock (_syncRoot)
            {
                T temp = DataItem;
            }
        }

        /// <summary>
        /// Save current data to file
        /// </summary>
        public static void UpdateSavedData()
        {
            lock (_syncRoot)
            {
                SaveDataItem();
            }
        }

        #endregion

        #region Private
        /// <summary>
        /// Saves the data item to DataFilePath and DataFileName, if path and file doesn't exists,
        /// They will be created.
        /// </summary>
        /// <returns>string.Empty is succeeded, else return the exception message</returns>
        private static string SaveDataItem()
        {
            Logger.LogInfo("DataManager SaveDataItem() <{0}>",typeof(T));
            lock (_syncRoot)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                FileStream fs=null;
                try
                {
                    string path = Path.GetDirectoryName(FilePath);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Create backup of previous file
                    if (File.Exists(FilePath))
                    {
                        File.Copy(FilePath, FilePath + ".bck", true);
                    }
                    fs = new FileStream(FilePath, FileMode.Create);
                    if (_dataItem == null) _dataItem = new T();
                    xs.Serialize(fs, _dataItem);
                }
                catch (IOException ioEx)
                {
                    return ioEx.Message;
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
                return string.Empty;
            }
        }

        private static string FilePath
        {
            get { return _dataFilePath + "\\" + _dataFileName; }
        }
        /// <summary>
        /// Loads the data item from DataFilePath and DataFileName, if path and file doesn't exists,
        /// They will be created.
        /// </summary>
        /// <returns>string.Empty if succeeded, else return the exception message</returns>
        private static string LoadDataItem()
        {
            Logger.LogInfo("DataManager LoadDataItem() <{0}>", typeof(T));
            lock (_syncRoot)
            {
                if (File.Exists(FilePath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(FilePath, FileMode.Open);
                        _dataItem = xs.Deserialize(fs) as T;
                    }
                    catch (IOException ioEx)
                    {
                        return ioEx.Message;
                    }
                    finally
                    {
                        if (fs != null) fs.Close();
                    }
                    return string.Empty;
                }
                return SaveDataItem();
            }
        }
        #endregion
    }
}