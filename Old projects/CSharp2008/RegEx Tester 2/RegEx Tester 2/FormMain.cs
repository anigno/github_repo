using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegEx_Tester_2
{
    public partial class FormMain : Form
    {
        private Regex regex;
        private Color COLOR_BAD_REGEX = Color.FromArgb(255, 192, 192);
        private Color COLOR_GOOD_REGEX = Color.FromArgb(192, 255, 192);
        public FormMain()
        {
            InitializeComponent();
        }

        private void textBoxRegex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listBoxResults.Items.Clear();
                regex = new Regex(textBoxRegex.Text, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                textBoxRegex.BackColor = COLOR_GOOD_REGEX;
                foreach (Match m in regex.Matches(richTextBoxInput.Text))
                {
                    listBoxResults.Items.Add(listBoxResults.Items.Count / 2 + 1 + ":" + m.Value);
                    listBoxResults.Items.Add("[" + m.Result("${DATA}") + "]");
                }
            }
            catch (ArgumentException aex)
            {
                textBoxRegex.BackColor = COLOR_BAD_REGEX;
                listBoxResults.Items.Add(aex.Message);
            }
        }





    }
}
