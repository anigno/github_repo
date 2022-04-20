using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer.UI.Controls
{
    public partial class ucBrowserSimple : UserControl
    {
		#region (------------------  Const Fields  ------------------)
        public const string CATEGORY_STRING = " ucBrowserSimple";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public ucBrowserSimple()
        {
            InitializeComponent();
            HomePage = "www.google.com";
            Navigate(HomePage);
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        [Category(CATEGORY_STRING)]
        public string Url
        {
            get { return textBoxUrl.Text; }
            set
            {
                textBoxUrl.Text = value;
                Navigate(textBoxUrl.Text);
            }
        }

        [Category(CATEGORY_STRING)]
        public string HomePage { get; set; }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowserMain.GoBack();
        }

        private void buttonFw_Click(object sender, EventArgs e)
        {
            webBrowserMain.GoForward();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            webBrowserMain.Navigate(textBoxUrl.Text);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            webBrowserMain.Navigate(HomePage);
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Public Methods  ------------------)
        [Category(CATEGORY_STRING)]
        public void Navigate(string url)
        {
            webBrowserMain.Navigate(url);
            textBoxUrl.Text = url;
        }
		#endregion (------------------  Public Methods  ------------------)

        private void webBrowserMain_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.TargetFrameName == "")
            {
                textBoxUrl.Text = e.Url.AbsoluteUri;
            }
        }
    }
}