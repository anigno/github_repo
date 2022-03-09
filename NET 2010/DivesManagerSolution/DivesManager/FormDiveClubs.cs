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
    public partial class FormDiveClubs : Form
    {
        private DataManager _mainData=null;

        public FormDiveClubs(DataManager data)
        {
            _mainData=data;
            InitializeComponent();
            RefreshListViewClubs();
        }

        private void RefreshListViewClubs()
        {
            listViewClubs.Items.Clear();
            foreach (ClubData data in _mainData.MainDataCollection.ClubDataList)
            {
                ListViewItem lvi = new ListViewItem(new string[] { data.ClubName, data.ClubPhone });
                listViewClubs.Items.Add(lvi);
                lvi.Tag=data;
            }
        }

        private void buttonToMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (!_mainData.IsKeyValid())
            {
                MessageBox.Show("None registered version, Dive clubs unavaliable", "Dives manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            ClubData data=new ClubData();
            _mainData.MainDataCollection.ClubDataList.Insert(0, data);
            RefreshListViewClubs();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listViewClubs.SelectedIndices.Count == 0) return;
            int index = listViewClubs.SelectedIndices[0];
            if (MessageBox.Show("Delete club data for " + _mainData.MainDataCollection.ClubDataList[index].ClubName + "?", "Dives manager", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
            {
                _mainData.MainDataCollection.ClubDataList.RemoveAt(index);
                RefreshListViewClubs();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewClubs.SelectedIndices.Count == 0) return;
            int index = listViewClubs.SelectedIndices[0];
            FormClubEdit f = new FormClubEdit((ClubData)listViewClubs.Items[index].Tag);
            f.ShowDialog();
            RefreshListViewClubs();
        }
    }
}