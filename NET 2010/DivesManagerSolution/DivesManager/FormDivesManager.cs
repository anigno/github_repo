using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AnignoLibraryMobile.Misc;
using DivesManager.Data;

namespace DivesManager
{
    public partial class FormDivesManager : Form
    {
        private DataManager _mainData = null;

        public FormDivesManager(DataManager data)
        {
            _mainData=data;
            InitializeComponent();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (_mainData.MainDataCollection.Dives.Count >= 3)
            {
                if (!_mainData.IsKeyValid())
                {
                    MessageBox.Show("None registered version, Max dives data restricted", "Dives manager", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            _mainData.CreateNewDive();
            RefreshListViewDives();
        }

        private void RefreshListViewDives()
        {
            listViewDives.Items.Clear();
            foreach (DiveData d in _mainData.MainDataCollection.Dives)
            {
                ListViewItem lvi = GetDiveListViewItem(d);
                listViewDives.Items.Add(lvi);
            }
        }

        private ListViewItem GetDiveListViewItem(DiveData data)
        {
            int maxDepth = Math.Max(data.Dive1Depth, data.Dive2Depth);
            maxDepth = Math.Max(maxDepth, data.Dive3Depth);
            string[] sa = { data.DivePlace, StringHelper.GetPrinableDataString(data.DiveDateTime), maxDepth.ToString() };
            ListViewItem lvi = new ListViewItem(sa);
            lvi.Tag=data;
            return lvi;
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            RefreshListViewDives();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(listViewDives.SelectedIndices.Count==0)return;
            int index = listViewDives.SelectedIndices[0];
            if (MessageBox.Show("Delete dive data for " + _mainData.MainDataCollection.Dives[index].DivePlace + "?", "Dives manager", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
            {
                _mainData.MainDataCollection.Dives.RemoveAt(index);
                RefreshListViewDives();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDives.SelectedIndices.Count == 0) return;
            int index = listViewDives.SelectedIndices[0];
            FormDiveData f = new FormDiveData((DiveData)listViewDives.Items[index].Tag);
            f.ShowDialog();
            RefreshListViewDives();
        }

        private void buttonToMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDuplicate_Click(object sender, EventArgs e)
        {
            if (listViewDives.SelectedIndices.Count == 0) return;
            int index = listViewDives.SelectedIndices[0];
            if (_mainData.MainDataCollection.Dives.Count >= 3)
            {
                if (!_mainData.IsKeyValid())
                {
                    MessageBox.Show("None registered version, Max dives data restricted", "Dives manager", MessageBoxButtons.OK,MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            DiveData source = (DiveData)listViewDives.Items[index].Tag;
            _mainData.CreateNewDive(source);
            RefreshListViewDives();
        }
    }
}