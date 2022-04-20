using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DivesManager.Data;

namespace DivesManager
{
    public partial class FormTextPad : Form
    {
        DataManager _mainData=null;

        public FormTextPad(DataManager data)
        {
            _mainData=data;
            InitializeComponent();
            
            textBoxTextPad.Text = _mainData.MainDataCollection.TextPadString;
        }

        private void textBoxTextPad_TextChanged(object sender, EventArgs e)
        {
            _mainData.MainDataCollection.TextPadString = textBoxTextPad.Text;
        }

        private void buttonToMain_Click(object sender, EventArgs e)
        {
            inputPanel1.Enabled = false;
            Close();
        }

        private void inputPanel_EnabledChanged(object sender, EventArgs e)
        {
            //if (!inputPanel1.Enabled) inputPanel1.Enabled = true;
        }
    }
}