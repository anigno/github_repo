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
    public partial class FormClubEdit : Form
    {
        private ClubData _clubData = null;

        public FormClubEdit(ClubData data)
        {
            _clubData = data;
            InitializeComponent();
            textBoxName.Text = _clubData.ClubName;
            textBoxAddress.Text = _clubData.ClubAddress;
            textBoxPhones.Text = _clubData.ClubPhone;
            textBoxPrices.Text = _clubData.ClubPrices;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            _clubData.ClubName = textBoxName.Text;
            _clubData.ClubAddress = textBoxAddress.Text;
            _clubData.ClubPhone = textBoxPhones.Text;
            _clubData.ClubPrices = textBoxPrices.Text;
            inputPanel1.Enabled = false;
            Close();
        }
    }
}