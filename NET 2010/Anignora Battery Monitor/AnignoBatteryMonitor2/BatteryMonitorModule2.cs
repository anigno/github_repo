using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer=System.Timers.Timer;
using System.Diagnostics;

namespace AnignoBatteryMonitor2
{
    public class BatteryMonitorModule2
    {
        private readonly Timer timer = new Timer(1000);
        private int lastPower = -1;
        private readonly Stopwatch stopwatch=new Stopwatch();
        private bool lastIsCharging=true;
        public delegate void BatteryChangedDelegate(int currentPower, int secondsPerChange);
        public delegate void BatteryChargingStateChangedDelegate(bool isCharging);
        public event BatteryChargingStateChangedDelegate BatteryChargingStateChanged;
        public event BatteryChangedDelegate BatteryPowerChanged;
        private long lastMilliseconds = -1;


        public BatteryMonitorModule2()
        {
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void RaiseBatteryPowerChanged()
        {
            long avgMilliseconds = (stopwatch.ElapsedMilliseconds + lastMilliseconds) / 2;
            if (BatteryPowerChanged != null) BatteryPowerChanged(BatteryPowerRemain, (int)(avgMilliseconds / 1000));
        }

        private void RaiseBatteryChargingStateChanged()
        {
            if (BatteryChargingStateChanged != null) BatteryChargingStateChanged(IsCharging);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (BatteryPowerRemain != lastPower)
            {
                if (lastIsCharging != IsCharging)
                {
                    RaiseBatteryChargingStateChanged();
                    lastIsCharging = IsCharging;
                }
                if (lastPower != -1) RaiseBatteryPowerChanged();
                lastPower = BatteryPowerRemain;
                lastMilliseconds = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
                stopwatch.Start();
            }
        }

        public bool IsCharging
        {
            get
            {
                return (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online);
            }
        }

        public int BatteryPowerRemain
        {
            get
            {
                return (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            }
        }
    }
}