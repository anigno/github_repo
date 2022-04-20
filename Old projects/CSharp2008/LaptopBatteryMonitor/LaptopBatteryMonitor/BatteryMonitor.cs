using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LaptopBatteryMonitor
{
    public delegate void OnBatteryPercentChangedDelegate(int newValue, PowerLineStatus status);

    public class BatteryMonitor
    {
        public event OnBatteryPercentChangedDelegate OnBatteryPercentChanged;

        private object _syncRoot = new object();
        private Timer _timerCheckBatteryPercentValue = new Timer();
        private int[] _intervalHistory;
        private int _prevBatteryLifePercent = 100;
        private int _newBatteryLifePercent = 100;
        private int _startMilliseconds;
        private int _endMilliseconds;
        private int _millisecondsRemain = 0;
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        public int BatteryLifePercent
        {
            get
            {
                lock (_syncRoot)
                {
                    //return 60 - DateTime.Now.Second;  //For testing, remain seconds should be equal to percent
                    return (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                }
            }
        }

        public int SecondsRemain
        {
            get
            {
                lock (_syncRoot)
                {
                    return _millisecondsRemain / 1000;
                }
            }
        }

        public PowerLineStatus PowerLineStatus
        {
            get
            {
                return SystemInformation.PowerStatus.PowerLineStatus;
            }
        }

        public int CpuUsage
        {
            get { return (int)(cpuCounter.NextValue()); }
        }

        public int FreeMemory
        {
            get { return (int)(ramCounter.NextValue()); }
        }

        public BatteryMonitor(int monitorInterval, int historyCount)
        {
            lock (_syncRoot)
            {
                _intervalHistory = new int[historyCount];
                for (int a = 0; a < historyCount; a++) _intervalHistory[a] = -1;
                _prevBatteryLifePercent = BatteryLifePercent;
                _timerCheckBatteryPercentValue.Interval = monitorInterval;
                _timerCheckBatteryPercentValue.Tick += new EventHandler(_timerCheckBatteryPercentValue_Tick);
                _timerCheckBatteryPercentValue.Start();
                _startMilliseconds = Environment.TickCount;
            }
        }

        void _timerCheckBatteryPercentValue_Tick(object sender, EventArgs e)
        {
            lock (_syncRoot)
            {
                _newBatteryLifePercent = BatteryLifePercent;
                if (_newBatteryLifePercent != _prevBatteryLifePercent)
                {
                    _endMilliseconds = Environment.TickCount;
                    for (int a = _intervalHistory.Length - 1; a > 0; a--)
                    {
                        if (_intervalHistory[a - 1] == -1)
                        {
                            _intervalHistory[a] = _endMilliseconds - _startMilliseconds;
                        }
                        else
                        {
                            _intervalHistory[a] = _intervalHistory[a - 1];
                        }
                    }
                    _intervalHistory[0] = _endMilliseconds - _startMilliseconds;
                    _startMilliseconds = _endMilliseconds;
                    _millisecondsRemain = 0;
                    for (int a = 0; a < _intervalHistory.Length; a++) _millisecondsRemain += _intervalHistory[a];
                    if (_newBatteryLifePercent < _prevBatteryLifePercent)
                    {
                        //Decreasing values, Offline
                        _millisecondsRemain = _millisecondsRemain * _newBatteryLifePercent / _intervalHistory.Length;
                        if (OnBatteryPercentChanged != null) OnBatteryPercentChanged(_newBatteryLifePercent, PowerLineStatus.Offline);
                    }
                    if (_newBatteryLifePercent > _prevBatteryLifePercent)
                    {
                        //Increasing values, Online
                        _millisecondsRemain = _millisecondsRemain * (100 - _newBatteryLifePercent) / _intervalHistory.Length;
                        if (OnBatteryPercentChanged != null) OnBatteryPercentChanged(_newBatteryLifePercent, PowerLineStatus.Online);
                    }
                    _prevBatteryLifePercent = _newBatteryLifePercent;
                }
            }
        }
    }
}