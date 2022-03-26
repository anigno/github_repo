using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace ArduinoMonitor
{
    class Program
    {
        readonly SerialPort m_sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

        static void Main(string[] args)
        {
            new Program();
        }

        private Program()
        {
            m_sp.DtrEnable = true;
            m_sp.RtsEnable = true;
            m_sp.DataReceived += spDataReceived;
            m_sp.Open();
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }

        private void spDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToString("hh:mm:ss.fff"), m_sp.ReadExisting());
        }
    }
}
