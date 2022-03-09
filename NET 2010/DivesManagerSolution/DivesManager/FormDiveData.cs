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
    public partial class FormDiveData : Form
    {
        private DiveData _diveData=null;

        public FormDiveData(DiveData diveData)
        {
            InitializeComponent();
            _diveData = diveData;
            UpdateFormControls();
        }

        private void UpdateFormControls()
        {
            dateTimePickerDiveDateTime.Value = _diveData.DiveDateTime;
            textBoxPlace.Text = _diveData.DivePlace;
            comboBoxDiveWeght.Text = _diveData.DiveWeight.ToString();
            comboBoxDiveSuit.SelectedIndex = _diveData.DiveSuit;
        }

        private void textBoxPlace_GotFocus(object sender, EventArgs e)
        {
            inputPanel1.Enabled = true;
        }

        private void textBoxPlace_LostFocus(object sender, EventArgs e)
        {
            inputPanel1.Enabled = false;
        }

        private void textBoxPlace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return) inputPanel1.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _diveData.DivePlace = textBoxPlace.Text;
            _diveData.DiveDateTime = dateTimePickerDiveDateTime.Value;
            _diveData.DiveWeight = int.Parse(comboBoxDiveWeght.SelectedItem.ToString());
            _diveData.DiveSuit = comboBoxDiveSuit.SelectedIndex;
        }


        private void buttonPlan_Click(object sender, EventArgs e)
        {
            _diveData.DivePlace = textBoxPlace.Text;
            FormPlanning f = new FormPlanning(_diveData);
            f.ShowDialog();
        }
    }
}