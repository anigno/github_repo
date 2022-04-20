using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoBatteryMonitor
{
    public partial class FormMain : Form
    {
		#region (------------------  Fields  ------------------)
        BatteryMonitoringModule bm = new BatteryMonitoringModule(true, 1000);
        private DateTime prevTime = DateTime.MinValue;
        int prevInterval = -1;
        private int prevPower = -1;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormMain()
        {
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Event Handlers  ------------------)
        void bm_OnBatteryPowerRemainChanged(BatteryMonitoringModule batteryMonitoringModule, int batteryPowerRemain)
        {
            GenericInvoke(labelPower, c => c.Text = batteryPowerRemain + "%");
            notifyIconMain.Text = labelPower.Text;
            CalculateRemainTime(batteryPowerRemain);
        }

        void bm_OnPowerLineStatusChanged(BatteryMonitoringModule batteryMonitoringModule, bool isCharging)
        {
            GenericInvoke(labelCharging, c => c.BackColor = isCharging ? Color.LightGreen : Color.Red);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            bm.OnBatteryPowerRemainChanged += bm_OnBatteryPowerRemainChanged;
            bm.OnPowerLineStatusChanged += bm_OnPowerLineStatusChanged;
            bm.Start();
        }

        private void notifyIconMain_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                Visible = false;
                WindowState = FormWindowState.Minimized;
            }
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Static Methods  ------------------)
        public static void GenericInvoke<CONTROL>(CONTROL control, Action<CONTROL> actionDelegate) where CONTROL : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<CONTROL, Action<CONTROL>>(GenericInvoke), new object[] { control, actionDelegate });
            }
            else
            {
                actionDelegate(control);
            }
        }
		#endregion (------------------  Static Methods  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnClosing(CancelEventArgs e)
        {
            bm.Stop();
            base.OnClosing(e);
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void CalculateRemainTime(int currentPower)
        {
            if (prevPower != -1)
            {
                int interval = (int)(DateTime.Now - prevTime).TotalSeconds;
                if (interval > 300)
                {
                    prevInterval = -1;
                    return;
                }
                if (prevInterval == -1) prevInterval = interval;
                int remain;
                if (bm.IsCharging)
                {
                    remain = (interval + prevInterval) * (100 - currentPower) / 2;
                }
                else
                {
                    remain = (interval + prevInterval) * currentPower / 2;
                }
                prevInterval = interval;
                GenericInvoke(labelTimeRemain, c => c.Text = string.Format("{0}:{1:00}", remain / 60, remain % 60));
                notifyIconMain.Text = "P: " + currentPower + "%  T: " + labelTimeRemain.Text;
            }
            prevPower = currentPower;
            prevTime = DateTime.Now;
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}