using System.Windows.Forms;
using AnignoLaptopBatteryMonitor.BatteryData;

namespace AnignoLaptopBatteryMonitor
{
    public class BatteryStatus : ProgressBar
    {
        BatteryDataBase _batteryData = new FakeBatteryData();

        public BatteryStatus()
        {
            Minimum = 0;
            Maximum = 100;
            Value = _batteryData.GetBatteryPower();
        }


        



    }
}