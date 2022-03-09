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
    public partial class FormMain : Form
    {
        private DataManager _mainData = new DataManager();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            _mainData.SaveData();
            Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _mainData.LoadData();
            labelVersion.Text = "Anigno Dives Manager V" + DataManager.VERSION;
        }

        private void buttonDivePlanning_Click(object sender, EventArgs e)
        {
            FormDivesManager f = new FormDivesManager(_mainData);
            f.ShowDialog();
        }

        private void buttonTextPad_Click(object sender, EventArgs e)
        {
            FormTextPad f = new FormTextPad(_mainData);
            f.ShowDialog();
        }

        private void buttonDivingClubs_Click(object sender, EventArgs e)
        {
            FormDiveClubs f = new FormDiveClubs(_mainData);
            f.ShowDialog();
        }

        private void linkLabelAbout_Click(object sender, EventArgs e)
        {
            using (FormAbout f = new FormAbout(_mainData))
            {
                f.ShowDialog();
            }
        }
    }
}