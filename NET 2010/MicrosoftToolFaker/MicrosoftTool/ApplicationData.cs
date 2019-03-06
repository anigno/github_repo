using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MicrosoftTool
{
    public class ApplicationData
    {
        public bool ShowNotifyIcon=true;
        public DateTime TriggerDate = DateTime.Now;
        public int HoldPercentage = 100;
        private const string FILE_NAME = "ApplicationData.xml";

        public static ApplicationData Load()
        {
            if (!File.Exists(FILE_NAME))
            {
                Save(new ApplicationData());
            }
            XmlSerializer xs=new XmlSerializer(typeof(ApplicationData));
            FileStream fs=new FileStream(FILE_NAME,FileMode.Open);
            object o=xs.Deserialize(fs);
            fs.Close();
            return (ApplicationData) o;
        }

        public static void Save(ApplicationData data)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ApplicationData));
            FileStream fs = new FileStream(FILE_NAME, FileMode.Create);
            xs.Serialize(fs, data);
            fs.Close();
        }

    }
}
