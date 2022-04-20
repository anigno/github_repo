using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoggingProvider;
using System.Threading;

namespace LoggingServiceTester
{
    public partial class formTester : Form
    {
        Random RND = new Random(DateTime.Now.Millisecond);

        public formTester()
        {
            InitializeComponent();
        }

        private void formConsole_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int b = RND.Next()%4;
            SeverityEnum severity = (SeverityEnum)b;
            severity = SeverityEnum.Debug;
            Logger.Log(severity, "message time" + DateTime.Now.ToLongTimeString());
            //Logger.LogDebug(@"subject: [BackupToEmail] Sent on: 10/06/2009 File: 2000 טיול לדרום אמריקה.Z06");
            Logger.LogDebug(@"subject: [BackupToEmail] Sent on: 10/06/2009 File: 2000.Z06");
            Logger.LogDebug(@"subject: [BackupToEmail] Sent on: ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 995; a++)
            {
                button1_Click(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 20; a++)
            {
                button1_Click(null, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int r = RND.Next() % 2;
            for (int b = 0; b < r; b++)
            {
                button1_Click(null, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logger.LogDebug(@"subject: [BackupToEmail] Sent on: 10/06/2009 File: 2000 טיול לדרום אמריקה.Z06");
        }
    }
}
