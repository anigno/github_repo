using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LaptopBatteryMonitor
{
    public partial class FormMain : Form
    {
        private BatteryMonitor _monitor = new BatteryMonitor(1000, 3);

        public FormMain()
        {
            InitializeComponent();
            UpdateFormControls();
            _monitor.OnBatteryPercentChanged += new OnBatteryPercentChangedDelegate(_monitor_OnBatteryPercentChanged);
        }

        private void UpdateFormControls()
        {
            labelStatus.Text = _monitor.PowerLineStatus.ToString();
            labelTime.Text = string.Format("{0}:{1:00}", _monitor.SecondsRemain / 60, _monitor.SecondsRemain % 60);
            labelPower.Text = _monitor.BatteryLifePercent.ToString() + " %";
            labelCpu.Text = _monitor.CpuUsage + " %";
            labelMemory.Text = _monitor.FreeMemory + " Mb";
        }

        void _monitor_OnBatteryPercentChanged(int newValue, PowerLineStatus status)
        {
            UpdateFormControls();
            radioButtonChangeFlicker.Checked = !radioButtonChangeFlicker.Checked;
        }

        private void timerRefreshDisplay_Tick(object sender, EventArgs e)
        {
            UpdateFormControls();
        }

        private void notifyIconMain_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }
    }
}
