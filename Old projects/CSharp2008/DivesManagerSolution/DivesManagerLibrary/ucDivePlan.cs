using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DivesManagerLibrary
{
    public delegate void OnPropertyChangedDelegate();

    public partial class ucDivePlan : UserControl
    {
        public event OnPropertyChangedDelegate OnPropertyChanged;
        public ucDivePlan()
        {
            InitializeComponent();
            comboBoxRestingTime.SelectedIndex = 0;
            comboBoxDepth.SelectedIndex = 0;
            comboBoxTime.SelectedIndex = 0;
        }

        public int RestingTime
        {
            get { return int.Parse(comboBoxRestingTime.SelectedItem.ToString()); }
            set { comboBoxRestingTime.Text = value.ToString(); }
        }

        public int Depth
        {
            get { return int.Parse(comboBoxDepth.SelectedItem.ToString()); }
            set { comboBoxDepth.Text = value.ToString(); }
        }

        public int Time
        {
            get { return int.Parse(comboBoxTime.SelectedItem.ToString()); }
            set { comboBoxTime.Text = value.ToString(); }
        }

        public string NewGroup
        {
            set { labelAutoSizeNewGroup.Text = value; }
        }

        public int MaxDepth
        {
            set { labelAutoSizeMaxTime.Text = value.ToString(); }
        }

        public int NitrogenDepth
        {
            set { labelAutoSizeNitrogenDebt.Text = value.ToString(); }
        }

        public string GroupAfterDive
        {
            set { labelAutoSizeGroupAfterDive.Text = value; }
        }

        public bool IsFirstDive
        {
            get { return !panelPreData.Visible; }
            set
            {
                panelPreData.Visible = !value;
                if (value)
                {
                    panelCurrentData.Top = 3;
                    Height = 60;
                    labelAutoSizeNitrogenDebt.Visible = false;
                    labelAutoSizeNitrogenDebtCaption.Visible = false;
                }
                else
                {
                    panelCurrentData.Top = 30;
                    Height = 90;
                    labelAutoSizeNitrogenDebt.Visible = true;
                    labelAutoSizeNitrogenDebtCaption.Visible = true;
                }
            }
        }

        private void RaisePropertyChangedEvent()
        {
            if (OnPropertyChanged != null) OnPropertyChanged();
        }

        private void comboBoxRestingTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent();
        }

        private void comboBoxDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent();
        }

        private void CheckMaxTime()
        {
            if(comboBoxTime.Text==string.Empty || labelAutoSizeMaxTime.Text==string.Empty)return;
            if (int.Parse(comboBoxTime.Text) > int.Parse(labelAutoSizeMaxTime.Text))
            {
                labelAutoSizeTimeCaption.ForeColor = Color.Red;
            }
            else
            {
                labelAutoSizeTimeCaption.ForeColor = SystemColors.ControlText;
            }
        }

        private void timerCheckMaxTime_Tick(object sender, EventArgs e)
        {
            CheckMaxTime();
        }
    }
}