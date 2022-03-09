using System.IO.Ports;
using AnignoraDataTypes.Configurations;

namespace SamplesProviders.Configuration
{
    public class SerialBytesSamplesProvidersConfig : IConfiguration
    {
        public string CommPort { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }

        public float FromLow { get; set; }
        public float FromHigh { get; set; }
        public float ToLow { get; set; }
        public float ToHigh { get; set; }

        public void SetDefaults()
        {
            CommPort = "Com4";
            BaudRate = 115200;
            Parity = Parity.None;
            DataBits = 8;

            FromLow = 0;
            FromHigh = 255;
            ToLow = 0;
            ToHigh = 0;
        }
    }
}
