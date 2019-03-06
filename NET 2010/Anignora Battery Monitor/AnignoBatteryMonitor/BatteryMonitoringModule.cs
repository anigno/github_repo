using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace AnignoBatteryMonitor
{
    public class BatteryMonitoringModule
    {
		#region (------------------  Fields  ------------------)
        private readonly bool isRealBattery;
        private bool fakeIsCharge;
        private bool prevIsCharging = true;
        private float fakeBatteryLifePercent;
        private int prevBatteryPower = -1;
        private readonly Random RND = new Random(DateTime.Now.Millisecond);
        private readonly Timer timer = new Timer();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public BatteryMonitoringModule(bool isRealBattery, double interval)
        {
            this.isRealBattery = isRealBattery;
            fakeBatteryLifePercent = RND.Next(30, 100)/100f;
            timer.Interval=interval;
            timer.Elapsed += timer_Elapsed;

        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public bool IsCharging
        {
            get {
                if (isRealBattery)
                {
                    return (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online);
                }
                else
                {
                    return fakeIsCharge;
                }
            }
        }

        public int BatteryPowerRemain
        {
            get {
                if (isRealBattery)
                {
                    return (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                }
                else
                {
                    return (int)(fakeBatteryLifePercent * 100);
                }

            }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Events  ------------------)
        public event BatteryPowerRemainChangedDelegate OnBatteryPowerRemainChanged;

        public event PowerLineStatusChangedDelegate OnPowerLineStatusChanged;
		#endregion (------------------  Events  ------------------)


		#region (------------------  Delegates  ------------------)
        public delegate void BatteryPowerRemainChangedDelegate(BatteryMonitoringModule batteryMonitoringModule, int batteryPowerRemain);
        public delegate void PowerLineStatusChangedDelegate(BatteryMonitoringModule batteryMonitoringModule, bool isCharging);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Event Handlers  ------------------)
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int di = IsCharging ? 1 : -1;
            fakeBatteryLifePercent += RND.Next(1, 10) / 5000f * di;
            if (fakeBatteryLifePercent < 0 || fakeBatteryLifePercent > 100) fakeBatteryLifePercent = 50;
            int currentPower = BatteryPowerRemain;
            if (currentPower != prevBatteryPower)
            {
                if (OnBatteryPowerRemainChanged != null) OnBatteryPowerRemainChanged(this, currentPower);
                prevBatteryPower = currentPower;
            }
            bool currentIsCharging = IsCharging;
            if (currentIsCharging != prevIsCharging)
            {
                if (OnPowerLineStatusChanged != null) OnPowerLineStatusChanged(this, currentIsCharging);
                prevIsCharging = currentIsCharging;
            }

        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Public Methods  ------------------)
        public void SetFakeCharge(bool isCharge)
        {
            fakeIsCharge = isCharge;
            if (fakeIsCharge != prevIsCharging)
            {
                if (OnPowerLineStatusChanged != null) OnPowerLineStatusChanged(this, fakeIsCharge);
                prevIsCharging = fakeIsCharge;
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}