using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using ArduinoCommunication;

namespace Arduino_PC_Manager_App
{
    public class ArduinoCommunicationManager :INotifyPropertyChanged
    {
		#region (------  Constants  ------)
        public const int REQUEST_DELAY_MS = 100;
		#endregion (------  Constants  ------)

		#region (------  Fields  ------)
        private readonly ArduinoCommunicator m_arduinoCommunicator=new ArduinoCommunicator();
        private readonly Thread m_readThread;
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public event EventHandler<RequestSentEventArgs> RequestSent = delegate { };
		#endregion (------  Events  ------)

		#region (------  Constructors  ------)
         public ArduinoCommunicationManager()
        {
            PinsAnalogIn=new ObservableCollection<PinData>();
            PinsAnalogOut=new ObservableCollection<PinData>();
            PinsDigitalIn=new ObservableCollection<PinData>();
            PinsDigitalOut=new ObservableCollection<PinData>();
            initInOutPins();
            m_arduinoCommunicator.DataReceived += onArduinoCommunicatorDataReceived;
            m_readThread=new Thread(readThreadStart);
            m_readThread.IsBackground = true;
            string[] arduinoComs = ArduinoCommunicator.FindArduinoComPorts();
             if(arduinoComs.Length==0)throw new Exception("No Arduino was found");
            m_arduinoCommunicator.Start(arduinoComs[0]);
            m_readThread.Start();
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public ObservableCollection<PinData> PinsAnalogIn { get; set; }

        public ObservableCollection<PinData> PinsAnalogOut { get; set; }

        public ObservableCollection<PinData> PinsDigitalIn { get; set; }

        public ObservableCollection<PinData> PinsDigitalOut { get; set; }
		#endregion (------  Properties  ------)

		#region (------  Events Handlers  ------)
        void onArduinoCommunicatorDataReceived(object p_sender, DataReceivedEventArgs p_e)
        {
            PinData pinData;
            if (p_e.PinType == PinTypeEnum.Digital)
            {
                pinData = PinsDigitalIn.SingleOrDefault(p_data => { return p_data.PinNumber == p_e.PinNumber && p_data.PinFunction == PinFunctionEnum.In; });
            }
            else
            {
                pinData = PinsAnalogIn.SingleOrDefault(p_data => { return p_data.PinNumber == p_e.PinNumber && p_data.PinFunction == PinFunctionEnum.In; });
            }
            if (pinData != default(PinData))
            {
                pinData.PinValueRead = p_e.PinValue;
            }
            else
            {
                pinData.PinValueRead = -9999;
            }
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Public Methods  ------)
        public void SetAnalogPinValue(int p_pinNumber,int p_value)
        {
            m_arduinoCommunicator.AnalogWrite(p_pinNumber,p_value);
        }

        public void SetDigitalPinValue(int p_pinNumber,int p_value)
        {
            m_arduinoCommunicator.DigitalWrite(p_pinNumber,p_value);
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private void initInOutPins()
        {
            PinsAnalogIn.Add(new PinData { PinNumber = 0, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Analog });
            PinsAnalogIn.Add(new PinData { PinNumber = 1, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Analog });
            PinsAnalogIn.Add(new PinData { PinNumber = 2, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Analog });
            PinsAnalogIn.Add(new PinData { PinNumber = 3, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Analog });
            PinsAnalogIn.Add(new PinData { PinNumber = 4, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Analog });
            PinsAnalogIn.Add(new PinData { PinNumber = 5, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Analog });

            PinsAnalogOut.Add(new PinData { PinNumber = 9, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Analog });
            PinsAnalogOut.Add(new PinData { PinNumber = 10, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Analog });
            PinsAnalogOut.Add(new PinData { PinNumber = 11, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Analog });

            PinsDigitalIn.Add(new PinData { PinNumber = 0, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Digital });
            PinsDigitalIn.Add(new PinData { PinNumber = 1, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Digital });
            PinsDigitalIn.Add(new PinData { PinNumber = 2, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Digital });
            PinsDigitalIn.Add(new PinData { PinNumber = 3, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Digital });
            PinsDigitalIn.Add(new PinData { PinNumber = 12, PinFunction = PinFunctionEnum.In, PinType = PinTypeEnum.Digital });

            PinsDigitalOut.Add(new PinData { PinNumber = 4, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Digital });
            PinsDigitalOut.Add(new PinData { PinNumber = 5, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Digital });
            PinsDigitalOut.Add(new PinData { PinNumber = 6, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Digital });
            PinsDigitalOut.Add(new PinData { PinNumber = 7, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Digital });
            PinsDigitalOut.Add(new PinData { PinNumber = 8, PinFunction = PinFunctionEnum.Out, PinType = PinTypeEnum.Digital });


        }

        private void readThreadStart()
        {
            while (true)
            {
                foreach (PinData pinData in PinsAnalogIn)
                {
                    m_arduinoCommunicator.RequestAnalogRead(pinData.PinNumber);
                    RequestSent(this, new RequestSentEventArgs(pinData.PinNumber, PinTypeEnum.Analog));
                    Thread.Sleep(REQUEST_DELAY_MS);
                }
                foreach (PinData pinData in PinsDigitalIn)
                {
                    m_arduinoCommunicator.RequestDigitalRead(pinData.PinNumber);
                    RequestSent(this, new RequestSentEventArgs(pinData.PinNumber, PinTypeEnum.Digital));
                    Thread.Sleep(REQUEST_DELAY_MS);
                }
            }
        }
		#endregion (------  Private Methods  ------)
    }
}
