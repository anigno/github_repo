using System.ComponentModel;
using ArduinoCommunication;

namespace Arduino_PC_Manager_App
{
    public class PinData : INotifyPropertyChanged
    {
        private int m_pinValueRead;
        public PinFunctionEnum PinFunction { get; set; }
        public PinTypeEnum PinType { get; set; }
        public int PinNumber { get; set; }

        public int PinValueRead
        {
            get { return m_pinValueRead; }
            set
            {
                m_pinValueRead = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PinValueRead"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
