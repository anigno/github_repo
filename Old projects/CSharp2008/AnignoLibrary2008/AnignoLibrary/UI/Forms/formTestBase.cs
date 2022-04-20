using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.Helpers.InvokationHelpers;

namespace AnignoLibrary.UI.Forms
{
    public partial class formTestBase : Form
    {
        public formTestBase()
        {
            InitializeComponent();
        }

        public void AddLog(string format, params object[] objects)
        {
            AddLog(Color.LightGreen, format, objects);
        }

        public void AddLog(Color color, string format, params object[] objects)
        {
            string[] sa=new string[2];
            sa[0]=DateTime.Now.ToLongTimeString() +"."+DateTime.Now.Millisecond.ToString();
            sa[1]=string.Format(format,objects);
            ListViewItem lvi = new ListViewItem(sa);
            lvi.BackColor = color;
            ListViewInvokationHelper.ListView_ItemAdd_Invoked(listViewLog, InvokationTypeEnum.Async, lvi, true);
        }

        private void formTestBase_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
