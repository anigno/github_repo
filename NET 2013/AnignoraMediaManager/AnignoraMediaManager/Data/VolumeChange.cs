using System.Xml.Serialization;
using AnignoraDataTypes.CommonTypes;

namespace AnignoraMediaManager.Data
{
    public class VolumeChange
    {
        [XmlIgnore]
        public int Id { get; private set; }
        public Time TimeStart { get; set; }
        public int Volume { get; set; }
        public int MusicType { get; set; }
        private static int s_uniqueId = 10000;
        private static readonly object s_syncRoot = new object();

        public VolumeChange()
        {
            lock (s_syncRoot)
            {
                Id = s_uniqueId++;
            }
        }
    }
}