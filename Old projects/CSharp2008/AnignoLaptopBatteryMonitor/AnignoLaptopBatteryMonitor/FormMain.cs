using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnignoLaptopBatteryMonitor.BatteryData;
using AnignoLibrary.UI.Forms;

namespace AnignoLaptopBatteryMonitor
{
    public partial class FormMain : FormBorderless
    {

		#region Fields (2) 


        private readonly Queue<long> _samples = new Queue<long>();
        private const int MAX_SAMPLES = 3;
        private readonly BatteryDataBase _bd = new RealBatteryData();

		#endregion Fields 

		#region Constructors (1) 

        public FormMain()
        {
            InitializeComponent();
            _bd.OnBatteryPowerChanged += _bd_OnBatteryPowerChanged;
            anignoProgressBarPower.Value = _bd.BatteryPowerPercentage;
            anignoProgressBarPower.Text = anignoProgressBarPower.Value + "%";
            anignoProgressBarMinutes.Value = anignoProgressBarPower.Value * 2;
            anignoProgressBarMinutes.Text = (int)anignoProgressBarMinutes.Value + "m";
        }

		#endregion Constructors 

		#region Event Handlers (3) 

        void _bd_OnBatteryPowerChanged(int changeDeltaPower, long changeDeltaMs)
        {
            if (DesignMode) return;
            _samples.Enqueue(changeDeltaMs/changeDeltaPower);
            if (_samples.Count > MAX_SAMPLES) _samples.Dequeue();
            anignoProgressBarPower.Value = _bd.BatteryPowerPercentage;
            anignoProgressBarPower.Text = anignoProgressBarPower.Value + "%";
            anignoProgressBarMinutes.Value = CalculateRemainMinutes((int)anignoProgressBarPower.Value);
            anignoProgressBarMinutes.Text = (int)anignoProgressBarMinutes.Value + "m";
            notifyIconMain.Text = notifyIconMain.BalloonTipText = anignoProgressBarPower.Value + "% " + (int)anignoProgressBarMinutes.Value+"m";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Visible = !Visible;
            }
        }

		#endregion Event Handlers 

		#region Private Methods (1) 

        private int CalculateRemainMinutes(int currentPower)
        {
            long sum = 0;
            foreach (long sample in _samples)
            {
                sum += -sample;
            }
            sum = sum / _samples.Count * currentPower / 1000 / 60;
            return (int) sum;
        }

		#endregion Private Methods 

    }
}
