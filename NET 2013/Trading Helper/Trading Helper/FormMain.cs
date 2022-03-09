using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AnignoraCommunication.RSS;
using System.IO;

namespace Trading_Helper
{
    public partial class FormMain : Form
    {
		#region (------  Fields  ------)

        private readonly RssReader rssRdr = new RssReader();

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            InitializeComponent();
            dataGridViewRss.MouseEnter += dataGridViewRss_MouseEnter;
        }

        void dataGridViewRss_MouseEnter(object sender, EventArgs e)
        {
            dataGridViewRss.Focus();
        }

       

		#endregion (------  Constructors  ------)

		#region (------  Delegates  ------)

        private delegate void f(string s, RssHeader r);

		#endregion (------  Delegates  ------)

		#region (------  Private Methods  ------)

        private void AddRssToGrid(RssItem[] items, string descriptor)
        {
            bool isSortOnNewRowAdded = false;
            for (int a = items.Length-1; a >= 0;a-- )
                {
                    if (!IsRssItemExists(items[a].Guid))
                    {
                        int i = dataGridViewRss.Rows.Add(items[a].PubDate.ToString(), descriptor, items[a].Title, items[a].Link);
                        DataGridViewRow row = dataGridViewRss.Rows[i];
                        row.Tag = items[a].Guid;
                        isSortOnNewRowAdded = true;
                        notifyIconMain.BalloonTipTitle = descriptor;
                        notifyIconMain.BalloonTipText = items[a].Title;
                        notifyIconMain.Tag = items[a].Link;
                        notifyIconMain.ShowBalloonTip(60000);
                    }
                }
            if (isSortOnNewRowAdded)
            {
                dataGridViewRss.Sort(dataGridViewRss.Columns[0], ListSortDirection.Descending);
            }
        }

        private void dataGridViewRss_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string link = dataGridViewRss.Rows[e.RowIndex].Cells["ColumnLink"].Value.ToString();
            webBrowserMain.Navigate(link);
            webBrowserMain.Focus();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader("RssSymbols.txt");
            List<string> rssUrlList=new List<string>();
            while (tr.Peek() > 0)
            {
                string rssUrl = tr.ReadLine();
                rssUrlList.Add(rssUrl);
            }
            tr.Close();
            rssRdr.OnRssFeedRead += rssRdr_OnRssFeedRead;
            rssRdr.StartAsyncReading(1000, rssUrlList.ToArray());
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            rssRdr.StopAsyncReading();
        }

        private bool IsRssItemExists(string guid)
        {
            foreach (DataGridViewRow row in dataGridViewRss.Rows)
            {
                if ((string)(row.Tag) == guid) return true;
            }
            return false;
        }

        private void notifyIconMain_BalloonTipClicked(object sender, EventArgs e)
        {
            Process p=new Process();
            p.StartInfo.FileName = "IExplore.exe";
            p.StartInfo.Arguments = notifyIconMain.Tag.ToString();
            p.Start();
        }

        void rssRdr_OnRssFeedRead(string sUrl, RssHeader rssHeader)
        {
            if (InvokeRequired)
            {
                try
                {
                    if (IsDisposed) return;
                    Invoke(new f(rssRdr_OnRssFeedRead), sUrl, rssHeader);
                }
                finally 
                {
                    //Dispose problem
                }
            }
            else
            {
                Text = "Trading Helper - " + rssHeader.Descriptor;
                AddRssToGrid(rssHeader.RssItems, rssHeader.Descriptor);
            }
        }

        private void textBoxPercentage_TextChanged(object sender, EventArgs e)
        {
            float f;
            if (float.TryParse(textBoxPercentage.Text, out f))
            {
                listViewPecentage.Items.Clear();
                for (int a = -6; a <= 6; a++)
                {
                    ListViewItem item = new ListViewItem(new[] { a + "%", string.Format("{0:0.00}", f * a / 100), string.Format("{0:0.00}", f + f * a / 100) });
                    if (a < 0) item.BackColor = Color.Pink;
                    if (a > 0) item.BackColor = Color.LightGreen;
                    listViewPecentage.Items.Add(item);
                }
            }
        }

		#endregion (------  Private Methods  ------)
    }
}
