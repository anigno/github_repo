using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DivesManager.Data;
using AnignoLibraryMobile.Misc;

namespace DivesManager
{
    public partial class FormAbout : Form
    {
        DataManager _dataManager=null;
        public FormAbout(DataManager data)
        {
            _dataManager=data;
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            labelAutoSizeVersion.Text = "Version " + DataManager.VERSION;
            textBoxKey.Text = _dataManager.MainDataCollection.Key;
            labelDeviceId.Text = DeviceIdHelper.GetDeviceKey("AnignoDivesManager").ToString();
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            _dataManager.MainDataCollection.Key = textBoxKey.Text;
            if (_dataManager.IsKeyValid())
            {
                labelKeyValid.Text = "OK";
                labelKeyValid.ForeColor = Color.LightGreen;
            }
            else
            {
                labelKeyValid.Text = "X";
                labelKeyValid.ForeColor = Color.Red;
            }
        }

        private void FormAbout_Closing(object sender, CancelEventArgs e)
        {
            inputPanel1.Enabled = false;
        }
    }
}