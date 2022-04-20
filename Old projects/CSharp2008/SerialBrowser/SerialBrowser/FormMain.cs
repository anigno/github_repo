using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoggingProvider;
using Microsoft.Win32;

namespace SerialBrowser
{
    public partial class FormMain : Form
    {
        const string RegistryRoot = "HKEY_CURRENT_USER";
        private string _currentPageString = string.Empty;
        public FormMain()
        {
            Logger.Log();
            InitializeComponent();
            string postfix = RegistryHelper.ReadApplicationData("SerialBrowser", "Postfix");
            string prefix = RegistryHelper.ReadApplicationData("SerialBrowser", "Prefix");
            string current = RegistryHelper.ReadApplicationData("SerialBrowser", "Current");
            string increment = RegistryHelper.ReadApplicationData("SerialBrowser", "Increment");
            string history = RegistryHelper.ReadApplicationData("SerialBrowser", "History");
            
            textBoxPrefix.Text = prefix == null ? "" : prefix;
            textBoxPostfix.Text = postfix == null ? "" : postfix;
            numericUpDownCurrent.Value = current == null ? 1 : int.Parse(current);
            numericUpDownIncrement.Value = increment == null ? 1 : int.Parse(increment);
            textBoxHistory.Text = history == null ? "" : history;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            decimal start = numericUpDownCurrent.Value;
            decimal end = numericUpDownCurrent.Value + numericUpDownCount.Value;
            for (decimal d = start; d < end; d++)
            {
                string under10 = (checkBoxAddition.Checked && start < 10 ? "0" : "");
                string nextPageString = string.Format("{0}{1}{2}{3}", textBoxPrefix.Text, under10, start, textBoxPostfix.Text);
                TabPage tp = new TabPage(start.ToString());
                tp.ToolTipText = nextPageString;
                tabControlMain.TabPages.Add(tp);
                WebBrowser w = new WebBrowser();
                tp.Controls.Add(w);
                tp.Tag = nextPageString;
                w.Dock = DockStyle.Fill;
                w.Navigate(nextPageString);
                Logger.Log(SeverityEnum.Debug, nextPageString);
                start += numericUpDownIncrement.Value;
                numericUpDownCurrent.Value = start;
            }
        }

        private void tabControlMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedIndex=tabControlMain.SelectedIndex;
            tabControlMain.TabPages.Remove(tabControlMain.SelectedTab);
            if (tabControlMain.TabPages.Count > 0)
            {
                tabControlMain.SelectedTab = tabControlMain.TabPages[selectedIndex % tabControlMain.TabPages.Count];
            }
        }

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {
            RegistryHelper.WriteApplicationData("SerialBrowser", "Prefix",textBoxPrefix.Text);
        }

        private void textBoxPostfix_TextChanged(object sender, EventArgs e)
        {
            RegistryHelper.WriteApplicationData("SerialBrowser", "Postfix",textBoxPostfix.Text);
        }

        private void numericUpDownCurrent_ValueChanged(object sender, EventArgs e)
        {
            RegistryHelper.WriteApplicationData("SerialBrowser", "Current", numericUpDownCurrent.Value.ToString());
        }

        private void tabControlMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null) textBoxSelected.Text = (string)(e.TabPage.Tag);

        }

        private void numericUpDownIncrement_ValueChanged(object sender, EventArgs e)
        {
            RegistryHelper.WriteApplicationData("SerialBrowser", "Increment", numericUpDownIncrement.Value.ToString());
        }

        private void textBoxHistory_TextChanged(object sender, EventArgs e)
        {
            RegistryHelper.WriteApplicationData("SerialBrowser", "History", textBoxHistory.Text);
        }
    }
}
