using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace HTMLExtractor
{
    public partial class formConsole : Form
    {
        public formConsole()
        {
            InitializeComponent();
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            listViewLinks.Items.Clear();
            WebClient webClient = new WebClient();
            byte[] buffer = webClient.DownloadData(textBoxURL.Text);
            string sPage = Encoding.ASCII.GetString(buffer);
            string listRegex = @"<A[^>]*?HREF\s*=\s*[""']?([^'"" >]+?)[ '""]?>";
            Regex regex1 = new Regex(listRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex regex2 = new Regex(@"http://.*[^ ""'\\]{2}", RegexOptions.IgnoreCase);
            MatchCollection mCol = regex1.Matches(sPage);
            foreach (Match m in mCol)
            {
                Match mLink = regex2.Match(m.Value);
                if (mLink.Value != string.Empty)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { listViewLinks.Items.Count.ToString(), mLink.Value });
                    lvi.Tag = mLink.Value;
                    listViewLinks.Items.Add(lvi);
                }
            }
        }

        private void listBoxLinks_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void buttonFwd_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void listViewLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLinks.SelectedItems.Count == 0) return;
            textBoxCurrentLink.Text = listViewLinks.SelectedItems[0].Tag.ToString();
            webBrowser1.Navigate(textBoxCurrentLink.Text);
        }
    }
}
