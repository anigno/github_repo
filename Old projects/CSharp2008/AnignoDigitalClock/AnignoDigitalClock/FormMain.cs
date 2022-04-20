using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AnignoDigitalClock
{
    public partial class FormMain : Form
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public FormMain()
        {
            InitializeComponent();
        }

        private void timerDateTimeRefresh_Tick(object sender, EventArgs e)
        {
            DateTime now=DateTime.Now;
            labelDate.Text = string.Format("{0:00}/{1:00}/{2:0000}", now.Day, now.Month, now.Year);
            labelTime.Text = string.Format("{0:00}:{1:00}:{2:00}", now.Hour, now.Minute, now.Second);
            labelStopWatch.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:0}", _stopwatch.Elapsed.Hours, _stopwatch.Elapsed.Minutes, _stopwatch.Elapsed.Seconds, _stopwatch.Elapsed.Milliseconds/100);
            notifyIconMain.Text = labelDate.Text + "\n" + labelTime.Text + "\n" + labelStopWatch.Text;
            if (now.Second == 0 && Visible==false)
            {
                Visible = true;
                timerSnap.Enabled = true;
                Opacity = 50;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _stopwatch.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _stopwatch.Stop();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _stopwatch.Reset();
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            Visible = !Visible;
        }

        private void timerSnap_Tick(object sender, EventArgs e)
        {
            timerSnap.Enabled = false;
            Visible = false;
            Opacity = 90;
        }

        private void timerBatteryLife_Tick(object sender, EventArgs e)
        {
            progressBarBatteryLife.Value = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            labelBattery.Visible = false;
            if (progressBarBatteryLife.Value < 65)
            {
                labelBattery.Visible = true;
                labelBattery.Text = progressBarBatteryLife.Value.ToString() + "%";
            }
            progressBarBatteryLife.ForeColor = labelBattery.ForeColor = Color.LightGreen;
            if (progressBarBatteryLife.Value < 20)
            {
                progressBarBatteryLife.ForeColor = labelBattery.ForeColor = Color.Orange;
            }
            if (progressBarBatteryLife.Value < 8)
            {
                progressBarBatteryLife.ForeColor = labelBattery.ForeColor = Color.Red;
                Visible = true;
            }
        }
    }
}
