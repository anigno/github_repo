using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Win32;

namespace CustomControlsExample
{
    [ContentProperty("FileName")]
    public partial class FileInputBox
    {
		#region (------  Fields  ------)
        public static readonly RoutedEvent s_fileNameChangedRoutedEvent = EventManager.RegisterRoutedEvent("FileNameChanged",RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileInputBox));
        public static readonly DependencyProperty s_fileNameDependencyProperty = DependencyProperty.Register("FileName", typeof(string), typeof(FileInputBox));
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event RoutedEventHandler FileNameChanged
        {
            add { AddHandler(s_fileNameChangedRoutedEvent, value); }
            remove { RemoveHandler(s_fileNameChangedRoutedEvent, value); }
        }
		#endregion (------  Events  ------)

		#region (------  Constructors  ------)
        public FileInputBox()
        {
            InitializeComponent();
            TheTextBox.TextChanged += onTextChanged;
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public string FileName
        {
            get { return (string)GetValue(s_fileNameDependencyProperty); }
            set { SetValue(s_fileNameDependencyProperty, value); }
        }
		#endregion (------  Properties  ------)

		#region (------  Events Handlers  ------)
        void onTextChanged(object p_sender, TextChangedEventArgs p_e)
        {
            p_e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(s_fileNameChangedRoutedEvent);
            RaiseEvent(args);
        }

        private void onTheButtonClick(object p_sender, RoutedEventArgs p_e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) // Result could be true, false, or null
                FileName = openFileDialog.FileName;
        }
		#endregion (------  Events Handlers  ------)
    }
}
