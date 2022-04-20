using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace AnignoLaptopBatteryMonitor.BatteryData
{
    public abstract class BatteryDataBase
    {

		#region Fields (4) 


        private int _lastBatteryPowerPercentage;

        private long _lastStopWatchCountMs;
        private Stopwatch _stopWatch=new Stopwatch();
        private Timer _periodicTimer=new Timer();

		#endregion Fields 

		#region Constructors (1) 

        protected BatteryDataBase(int sampleIntervalMs)
        {
            _lastBatteryPowerPercentage = BatteryPowerPercentage;
            _stopWatch.Start();
            _lastStopWatchCountMs = _stopWatch.ElapsedMilliseconds;
            _periodicTimer.Interval = sampleIntervalMs;
            _periodicTimer.Tick += _periodicTimer_Tick;
            _periodicTimer.Start();
        }

		#endregion Constructors 

		#region Read only Properties (1) 

        public abstract int BatteryPowerPercentage
        {
            get;
        }

		#endregion Read only Properties 

		#region Events (1) 

        public event BatteryPowerChangedDelegate OnBatteryPowerChanged;

		#endregion Events 

		#region Delegates (1) 

        public delegate void BatteryPowerChangedDelegate(int changeDeltaPower, long changeDeltaMs);

		#endregion Delegates 

		#region Event Handlers (1) 

        void _periodicTimer_Tick(object sender, EventArgs e)
        {
            if (_lastBatteryPowerPercentage != BatteryPowerPercentage)
            {
                int tempBatteryPower = BatteryPowerPercentage;
                long tempStopWatch = _stopWatch.ElapsedMilliseconds;
                int powerDelta = tempBatteryPower - _lastBatteryPowerPercentage;
                long deltaMs=tempStopWatch-_lastStopWatchCountMs;
                _lastStopWatchCountMs = tempStopWatch;
                _lastBatteryPowerPercentage = tempBatteryPower;
                if (OnBatteryPowerChanged != null) OnBatteryPowerChanged(powerDelta, deltaMs);
            }
        }

		#endregion Event Handlers 

    }
}