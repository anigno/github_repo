using System.Windows.Forms;

namespace AnignoLaptopBatteryMonitor.BatteryData
{
    public class RealBatteryData:BatteryDataBase
    {

		#region Constructors (1) 

        public RealBatteryData() : base(15000)
        {
        }

		#endregion Constructors 

		#region Overridden Properties (1) 

        public override int BatteryPowerPercentage
        {
            get { return (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100); }
        }

		#endregion Overridden Properties 

    }
}
