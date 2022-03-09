using System;
using System.IO;
using System.Xml.Serialization;
using AnignoLibraryMobile.Misc;

namespace DivesManager.Data
{
    public class DataManager
    {
        private const int DEVICE_KEY_MULTIPLIER = 131;
        private readonly string _diveDataFile = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\DiveData.txt";
        public const string VERSION = "1.2";
        public DataCollection MainDataCollection = new DataCollection();

        public void CreateNewDive()
        {
            DiveData d = new DiveData();
            MainDataCollection.Dives.Insert(0, d);
        }

        public void CreateNewDive(DiveData duplicateDive)
        {
            DiveData d = new DiveData();
            d.DiveName = duplicateDive.DiveName;
            d.DivePlace = duplicateDive.DivePlace;
            d.DiveDateTime = duplicateDive.DiveDateTime;
            d.DiveSuit = duplicateDive.DiveSuit;
            d.DiveWeight = duplicateDive.DiveWeight;
            d.Dive1Depth = duplicateDive.Dive1Depth;
            d.Dive1RestingTime = duplicateDive.Dive1RestingTime;
            d.Dive1Time = duplicateDive.Dive1Time;
            d.Dive2Depth = duplicateDive.Dive2Depth;
            d.Dive2RestingTime = duplicateDive.Dive2RestingTime;
            d.Dive2Time = duplicateDive.Dive2Time;
            d.Dive3Depth = duplicateDive.Dive3Depth;
            d.Dive3RestingTime = duplicateDive.Dive3RestingTime;
            d.Dive3Time = duplicateDive.Dive3Time;
            MainDataCollection.Dives.Insert(0, d);
        }

        public void SaveData()
        {
            XmlSerializer xs = new XmlSerializer(typeof(DataCollection));
            FileStream fs = new FileStream(_diveDataFile, FileMode.Create);
            xs.Serialize(fs, MainDataCollection);
            fs.Close();
        }

        public void LoadData()
        {
            if (!File.Exists(_diveDataFile)) SaveData();
            XmlSerializer xs = new XmlSerializer(typeof(DataCollection));
            FileStream fs = new FileStream(_diveDataFile, FileMode.Open);
            object o = xs.Deserialize(fs);
            MainDataCollection = (DataCollection)o;
            fs.Close();
        }

        public bool IsKeyValid()
        {
            if (MainDataCollection.Key == string.Empty) return false;
            int deviceKey = DeviceIdHelper.GetDeviceKey("AnignoDivesManager");
            if (int.Parse(MainDataCollection.Key) == deviceKey * DEVICE_KEY_MULTIPLIER) return true;
            return false;
        }
    }
}