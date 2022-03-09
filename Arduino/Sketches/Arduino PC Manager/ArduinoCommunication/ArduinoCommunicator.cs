using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace ArduinoCommunication
{
    public class ArduinoCommunicator
    {
		#region (------  Constants  ------)
        public const string ARDUINO_END_OF_DATA_LINE = "@";
		#endregion (------  Constants  ------)

		#region (------  Fields  ------)
        private string m_lastData = "";
        SerialPort m_sp;
        private readonly Dictionary<int,int> m_values=new Dictionary<int, int>();
        public static readonly string[] s_dataSplitter = new[] { "[#]" };
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event EventHandler<DataReceivedEventArgs> DataReceived = delegate { };

        public event EventHandler SimpleEchoReceived = delegate { };
		#endregion (------  Events  ------)

		#region (------  Constructors  ------)
         public ArduinoCommunicator()
        {
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)
         void onSerialPortDataReceived(object p_sender, SerialDataReceivedEventArgs p_e)
        {
            string line=m_sp.ReadExisting();
            parseReceivedData(line);
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Public static Methods  ------)
        public static string[] FindArduinoComPorts()
        {
            List<string> foundArduinoComs=new List<string>();
            for (int a = 0; a < 15; a++)
            {
                string portName = "COM" + a;
                ArduinoCommunicator ac = new ArduinoCommunicator();
                bool bResult = ac.Start(portName);
                if (bResult)
                {
                    ac.SimpleEchoReceived += (p_sender, p_args) =>
                        {
                            foundArduinoComs.Add(portName);
                            ac.Stop();
                        };
                    ac.RequestEcho();
                }
            }
            return foundArduinoComs.ToArray();
        }
		#endregion (------  Public static Methods  ------)

		#region (------  Public Methods  ------)
        public void AnalogWrite(int p_pinNumber,int p_value)
        {
            string format = string.Format("a_{0:00}_{1:0000}", p_pinNumber, p_value);
            sendStringToSerial(format);
        }

        public void DigitalWrite(int p_pinNumber, int p_value)
        {
            string format = string.Format("d_{0:00}_{1:0000}", p_pinNumber, p_value);
            sendStringToSerial(format);
        }

        public int GetValue(int p_pinNumber)
        {
            if (m_values.ContainsKey(p_pinNumber)) return m_values[p_pinNumber];
            return -9999;
        }

        public void RequestAnalogRead(int p_pinNumber)
        {
            string format = string.Format("A_{0:00}", p_pinNumber);
            sendStringToSerial(format);
        }

          public void RequestDigitalRead(int p_pinNumber)
        {
            string format = string.Format("D_{0:00}", p_pinNumber);
            sendStringToSerial(format);
        }

        public void RequestEcho()
        {
            sendStringToSerial("ECHO");
        }

        public void SetPinMode(int p_pinNumber,PinFunctionEnum p_piIo)
        {
            string format = string.Format("S_{0:00}_{1}", p_pinNumber, p_piIo);
            sendStringToSerial(format);
        }

        public bool Start(string p_comPort)
        {
            m_sp = new SerialPort(p_comPort, 9600, Parity.None, 8, StopBits.One);
            m_sp.DtrEnable = true;
            m_sp.RtsEnable = true;
            m_sp.DataReceived += onSerialPortDataReceived;
            try
            {
                m_sp.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Stop()
        {
            m_sp.DataReceived -= onSerialPortDataReceived;
            m_sp.Close();

        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private void parseReceivedData(string p_data)
        {
            p_data = m_lastData + p_data;
            while (p_data.IndexOf(ARDUINO_END_OF_DATA_LINE) >= 0)
            {
                int a = p_data.IndexOf(ARDUINO_END_OF_DATA_LINE);
                string line = p_data.Substring(0,a);
                p_data = p_data.Substring(a+1);
                if (line.Contains("SimpleEcho"))
                {
                    SimpleEchoReceived(this,new EventArgs());
                }
                if (line.Contains("ValueRead"))
                {
                    PinTypeEnum pinType = line.Contains("Analog") ? PinTypeEnum.Analog : PinTypeEnum.Digital;
                    string[] dataItems = line.Split(s_dataSplitter, StringSplitOptions.RemoveEmptyEntries);
                    if (dataItems.Length < 4)
                    {
                        return;
                    }
                    int pinNumber = int.Parse(dataItems[1]);
                    int pinValue = int.Parse(dataItems[3]);
                    if (!m_values.ContainsKey(pinNumber))
                    {
                        m_values.Add(pinNumber, pinValue);
                    }
                    m_values[pinNumber] = pinValue;
                    DataReceived(this, new DataReceivedEventArgs(pinNumber, pinValue,pinType));
                }
            }
            m_lastData = p_data;
        }

        private void sendStringToSerial(string p_s)
        {
            try
            {
                m_sp.WriteLine(p_s);
            }
            catch (Exception ex)
            {
            }
        }
		#endregion (------  Private Methods  ------)
    }
}
