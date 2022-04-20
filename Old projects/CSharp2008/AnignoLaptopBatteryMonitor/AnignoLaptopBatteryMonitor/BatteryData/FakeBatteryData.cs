using System;
using System.Windows.Forms;

namespace AnignoLaptopBatteryMonitor.BatteryData
{
    public class FakeBatteryData : BatteryDataBase
    {

		#region Fields (3) 


        private float _currentBatteryPower = 100;

        private Random RND = new Random(DateTime.Now.Millisecond);
        private Timer _timer=new Timer();

		#endregion Fields 

		#region Constructors (1) 

        public FakeBatteryData()
            : base(15000)
        {
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

		#endregion Constructors 

		#region Overridden Properties (1) 

        public override int BatteryPowerPercentage
        {
            get
            {
                return (int)_currentBatteryPower;
            }
        }

		#endregion Overridden Properties 

		#region Event Handlers (1) 

        void _timer_Tick(object sender, EventArgs e)
        {
            _currentBatteryPower -= RND.Next(5, 30) / 1000f;
        }

		#endregion Event Handlers 

    }
}
