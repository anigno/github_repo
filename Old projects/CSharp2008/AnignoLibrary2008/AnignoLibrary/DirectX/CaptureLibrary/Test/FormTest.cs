using System;
using System.Windows.Forms;
using DirectX.Capture;

namespace AnignoLibrary.DirectX.CaptureLibrary.Test
{
    public partial class FormTest : Form
    {

		#region Constructors (1) 

        public FormTest()
        {
            InitializeComponent();
            Filters filters = new Filters();
            foreach (Filter a in filters.AudioCompressors)
            {
                listBoxAudioCompressors.Items.Add(a.Name);
            }
            foreach (Filter a in filters.AudioInputDevices)
            {
                listBoxAudioInputDevices.Items.Add(a.Name);
            }
            foreach (Filter a in filters.VideoCompressors)
            {
                listBoxVideoCompressors.Items.Add(a.Name);
            }
            foreach (Filter a in filters.VideoInputDevices)
            {
                listBoxVideoInputDevices.Items.Add(a.Name);
            }
        }

		#endregion Constructors 

        private void listBoxAudioInputDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
