using System;

namespace ArduinoCommunication
{
    public class DataReceivedEventArgs:EventArgs
    {
        public int PinNumber { get; private set; }
        public int PinValue { get; private set; }
        public PinTypeEnum PinType { get; private set; }

        public DataReceivedEventArgs(int p_pinNumber, int p_value, PinTypeEnum p_pinType)
        {
            PinNumber = p_pinNumber;
            PinValue = p_value;
            PinType = p_pinType;
        }

        public override string ToString()
        {
            return string.Format("PinNumber={0} PinValue={1}",PinNumber,PinValue);
        }
    }
}
