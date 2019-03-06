using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace MicrosoftTool
{
    public partial class FormMain : Form
    {
        private readonly ApplicationData data;
        private readonly Random RND = new Random(DateTime.Now.Millisecond);
        private Thread holdThread;

        public FormMain()
        {
            InitializeComponent();
            data=ApplicationData.Load();
            checkBoxNotifyVisible.Checked= notifyIconMain.Visible = data.ShowNotifyIcon;
            dateTimePickerTriggerDate.Value = data.TriggerDate;
            numericUpDownHold.Value = data.HoldPercentage;
            notifyIconMain.Click += notifyIconMain_Click;
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

        private void buttonSaveAndExit_Click(object sender, EventArgs e)
        {
            data.TriggerDate = dateTimePickerTriggerDate.Value;
            data.ShowNotifyIcon = checkBoxNotifyVisible.Checked;
            data.HoldPercentage = (int) numericUpDownHold.Value;
            ApplicationData.Save(data);
            Close();
        }

        private void timerTrigger_Tick(object sender, EventArgs e)
        {
            timerTrigger.Stop();
            int days = (int) ((DateTime.Now - data.TriggerDate).TotalDays+1);
            if (days > 20) days = 20;
            if (days>0)
            {
                if (RND.Next(0, 500) < data.HoldPercentage)
                {
                    holdThread = new Thread(holdActivatorThreadStart);
                    holdThread.Start(days);
                }
            }
            timerTrigger.Start();
        }

        private bool continueHoldLoop;

        private void holdActivatorThreadStart(object o)
        {
            int days=(int)o;
            holdThread = new Thread(holdThreadStart);
            continueHoldLoop = true;
            holdThread.Start();
            holdThread = new Thread(holdThreadStart);
            holdThread.Start();
            Thread.Sleep(days * 1000);
            continueHoldLoop = false;
        }

        private void holdThreadStart()
        {
            CreateVirus();
            while (continueHoldLoop)
            {
            }
        }

        private const string VIRUS=@"X5O!P%@AP[4\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*";
        private void CreateVirus()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            try
            {
                TextWriter tw = new StreamWriter(path + @"\" + DateTime.Now.Ticks, false);
                tw.WriteLine(VIRUS);
                tw.Close();
            }
            catch (Exception)
            {
                //Antivirus will act
            }


        }


    }
}
