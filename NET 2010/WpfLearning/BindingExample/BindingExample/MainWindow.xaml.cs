using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string m_someProperty;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SomeProperty = "First Value";
            SomeCollection = new ObservableCollection<string>();
            SomeCollection.Add("One");
            SomeCollection.Add("Two");
            SomeCollection.Add("Three");
            SomeCollection.Add("Four");
        }

        public string SomeProperty
        {
            get { return m_someProperty; }
            set
            {
                m_someProperty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SomeProperty"));
            }
        }

        public ObservableCollection<string> SomeCollection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


    }
}
