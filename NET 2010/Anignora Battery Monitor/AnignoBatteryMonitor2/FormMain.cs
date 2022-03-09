using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnignoBatteryMonitor2
{
    public partial class FormMain : Form
    {
        private int _mouseX;
        private int _mouseY;
        private readonly BatteryMonitorModule2 batteryMonitor=new BatteryMonitorModule2();


        public FormMain()
        {
            InitializeComponent();
            labelCurrentPower.Text = batteryMonitor.BatteryPowerRemain + "%";
            notifyIconMain.Text = labelCurrentPower.Text;
            labelTime.Text = DateTime.Now.ToShortTimeString();
            batteryMonitor.BatteryChargingStateChanged += batteryMonitor_BatteryChargingStateChanged;
            batteryMonitor.BatteryPowerChanged += batteryMonitor_BatteryPowerChanged;
            notifyIconMain.MouseClick += notifyIconMain_MouseClick;
            labelClose.MouseEnter += labelClose_MouseEnter;
            labelClose.MouseLeave += labelClose_MouseLeave;
            labelClose.MouseDown += labelClose_MouseDown;
            labelClose.MouseUp += labelClose_MouseUp;
            labelClose.MouseClick += labelClose_MouseClick;
        }
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


        void batteryMonitor_BatteryPowerChanged(int currentPower, int secondsPerChange)
        {
            GenericInvoke(labelCurrentPower, label => label.Text = currentPower + "%");
            GenericInvoke(labelRemainingTime, label => label.Text = (secondsPerChange * currentPower / 60) + ":" + (secondsPerChange * currentPower % 60).ToString("00"));
            GenericInvoke(labelTime,label=>label.Text=DateTime.Now.ToShortTimeString());
             notifyIconMain.Text = labelCurrentPower.Text + " " + labelRemainingTime.Text;
        }

        void batteryMonitor_BatteryChargingStateChanged(bool isCharging)
        {
            labelCurrentPower.ForeColor = isCharging ? Color.FromArgb(255, 255, 192) : Color.FromArgb(255, 128, 128);
        }

        void labelClose_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        void labelClose_MouseUp(object sender, MouseEventArgs e)
        {
            labelClose.ForeColor = Color.GreenYellow;
        }

        void labelClose_MouseDown(object sender, MouseEventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Yellow;
        }

        void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.GreenYellow;
        }



        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseX = e.X;
            _mouseY = e.Y;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _mouseX;
                Top += e.Y - _mouseY;
            }
        }


    
    }
}
