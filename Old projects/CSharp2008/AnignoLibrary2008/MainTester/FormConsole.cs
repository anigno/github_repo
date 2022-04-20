using System.Windows.Forms;
using System.IO;
using AnignoLibrary.Communication.TimeSynchronize;
using System;
using AnignoLibrary.UI.Forms;

namespace MainTester
{
    public partial class FormConsole : Form
    {
        public FormConsole()
        {
            InitializeComponent();
            DateTime dt= NTPClient.GetServerTime(true);
        }










    }
}
