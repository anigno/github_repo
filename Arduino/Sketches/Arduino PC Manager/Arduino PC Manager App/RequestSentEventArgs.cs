using System;
using ArduinoCommunication;

namespace Arduino_PC_Manager_App
{
    public class RequestSentEventArgs:EventArgs
    {
        public int PinNumber { get; private set; }
        public PinTypeEnum PinType { get; private set; }

        public RequestSentEventArgs(int p_pinNumber,PinTypeEnum p_pinType)
        {
            PinNumber = p_pinNumber;
            PinType = p_pinType;
        }
    }
}
