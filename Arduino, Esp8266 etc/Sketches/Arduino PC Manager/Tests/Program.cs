using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ArduinoCommunication;

namespace Tests
{
    class Program
    {
        private readonly ArduinoCommunicator m_communicator=new ArduinoCommunicator();

        public Program()
        {
            string[] coms = ArduinoCommunicator.FindArduinoComPorts();

            m_communicator.DataReceived += m_communicator_DataReceived;
            m_communicator.Start("");

            m_communicator.SetPinMode(13,PinFunctionEnum.Out);
            int v1 = m_communicator.GetValue(9);
            m_communicator.RequestAnalogRead(9);

           
             
                Console.WriteLine(m_communicator.GetValue(9));
                Thread.Sleep(500);
                Console.WriteLine(m_communicator.GetValue(9));

        


            Console.ReadLine();
            m_communicator.Stop();
        }

        void m_communicator_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e);
        }

       

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
