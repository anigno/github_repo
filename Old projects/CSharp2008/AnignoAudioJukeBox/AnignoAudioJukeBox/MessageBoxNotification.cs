using System;
using System.Windows.Forms;

namespace AnignoAudioJukeBox
{
    public partial class MessageBoxNotification : Form
    {
        public MessageBoxNotification()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string Message
        {
            set { labelMessage.Text = value; }
        }

        public static void Show(string message)
        {
            MessageBoxNotification f=new MessageBoxNotification();
            f.Message = message;
            f.ShowDialog();
        }
    }
}
