using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArduinoCommunication;
using WpfServices;

namespace Arduino_PC_Manager_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArduinoCommunicationManager CommunicationManager { get; private set; }


        public MainWindow()
        {
            CommunicationManager = new ArduinoCommunicationManager();
            CommunicationManager.RequestSent += onCommunicationManagerRequestSent;
            DataContext = this;
            InitializeComponent();


        }

        void onDataGridDigitalOutputCellEditEnding(object p_sender, DataGridCellEditEndingEventArgs p_e)
        {
            PinData pinData = (PinData) p_e.Row.Item;
            TextBox textBox = (TextBox) p_e.EditingElement;
            int value;
            bool b=int.TryParse(textBox.Text, out value);
            if (b) CommunicationManager.SetDigitalPinValue(pinData.PinNumber, value);
        }

        private void onCommunicationManagerRequestSent(object p_sender, RequestSentEventArgs p_e)
        {
            CrossThreadedActivities.Do(this, () =>
                {
                    labelRequest.Content = p_e.PinType + " " + p_e.PinNumber;
                });
        }

        private void onDataGridAnalogOutputCellEditEnding(object p_sender, DataGridCellEditEndingEventArgs p_e)
        {
            PinData pinData = (PinData)p_e.Row.Item;
            TextBox textBox = (TextBox)p_e.EditingElement;
            int value;
            bool b = int.TryParse(textBox.Text, out value);
            if (b) CommunicationManager.SetAnalogPinValue(pinData.PinNumber, value);
        }
    }
}