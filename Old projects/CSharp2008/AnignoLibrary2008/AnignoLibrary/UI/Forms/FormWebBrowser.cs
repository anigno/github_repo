using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Forms
{
    public partial class FormWebBrowser : Form
    {

		#region Constructors (1) 

        public FormWebBrowser()
        {
            InitializeComponent();
        }

		#endregion Constructors 

		#region Event Handlers (3) 

        private void buttonNavigateBack_Click(object sender, EventArgs e)
        {
            webBrowserMain.GoBack();
        }

        private void buttonNavigateForward_Click(object sender, EventArgs e)
        {
            webBrowserMain.GoForward();
        }

        private void buttonNavigateTo_Click(object sender, EventArgs e)
        {
            webBrowserMain.Navigate(textBoxAddress.Text);
        }

		#endregion Event Handlers 

		#region Public Methods (1) 

        public void Navigate(string url)
        {
            textBoxAddress.Text=url;
            webBrowserMain.Navigate(url);
        }

		#endregion Public Methods 

    }
}
