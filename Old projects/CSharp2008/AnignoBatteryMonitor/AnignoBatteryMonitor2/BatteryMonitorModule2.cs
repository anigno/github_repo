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
        private bool lastIsCharging=false;
        public delegate void BatteryChangedDelegate(int currentPower, int secondsPerChange);
        public delegate void BatteryChargingStateChangedDelegate(bool isCharging);
        public event BatteryChargingStateChangedDelegate BatteryChargingStateChanged;
        public event BatteryChangedDelegate BatteryPowerChanged;


        public BatteryMonitorModule2()
        {
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void RaiseBatteryPowerChanged()
        {
            if (BatteryPowerChanged != null) BatteryPowerChanged(BatteryPowerRemain,(int) (stopwatch.ElapsedMilliseconds/1000));
        }

        private void RaiseBatteryChargingStateChanged()
        {
            if (BatteryChargingStateChanged != null) BatteryChargingStateChanged(IsCharging);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (BatteryPowerRemain != lastPower)
            {
                if(lastIsCharging!=IsCharging)RaiseBatteryChargingStateChanged();
                if (lastPower != -1) RaiseBatteryPowerChanged();
                lastPower = BatteryPowerRemain;
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