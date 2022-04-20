using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace AnignoLibrary.Configuration
{
    public class Configurator<T> where T: new()
    {
        private static Configurator<T> _instance = null;
        private XmlSerializer _xs = new XmlSerializer(typeof(T));
        private string _dataFileName;
        private T _data = default(T);
        
        /// <summary>
        /// Gets the instanced data item held by the configurator
        /// </summary>
        public static T Data
        {
            get
            {
                return Instance._data;
            }
        }

        /// <summary>
        /// Initializes the configurator for requested data type an folder name in user's MyDocuments directory
        /// </summary>
        /// <param name="configurationFolderName"></param>
        public static void Initialize(string configurationFolderName)
        {
            _instance = new Configurator<T>();
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + configurationFolderName;
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            _instance._dataFileName = dataPath + "\\" + typeof(T).Name + ".XML";
            _instance.LoadData();
        }

        /// <summary>
        /// Updates the instanced data to file
        /// </summary>
        public static void Update()
        {
            Instance.SaveData();
        }

        private static Configurator<T> Instance
        {
            get
            {
                if (_instance == null) throw new Exception("Configurator exeption, Configurator wasn't initialized for: " + typeof(T).Name);
                return _instance;
            }
        }

        private void LoadData()
        {
            if (!File.Exists(_dataFileName))
            {
                Instance._data = new T();
                return;
            } 
            FileStream fs = new FileStream(_dataFileName, FileMode.Open);
            Instance._data = (T)_xs.Deserialize(fs);
            fs.Close();
        }

        private void SaveData()
        {
            FileStream fs = new FileStream(_dataFileName, FileMode.Create);
            _xs.Serialize(fs, Instance._data);
            fs.Close();
        }
    }
}