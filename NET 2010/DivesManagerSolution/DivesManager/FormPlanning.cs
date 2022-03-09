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
    public partial class FormPlanning : Form
    {
        private DiveData _divedata = null;
        private bool _isLoaded=false;

        public FormPlanning(DiveData diveData)
        {
            InitializeComponent();
            _divedata = diveData;
            RefreshFormControls();
        }

        private void RefreshFormControls()
        {
            labelPlace.Text = _divedata.DivePlace;
            ucDivePlan1.Depth = _divedata.Dive1Depth;
            ucDivePlan1.Time = _divedata.Dive1Time;
            ucDivePlan1.MaxDepth = DivingTablesHelper.GetMaxTimeForDepth(_divedata.Dive1Depth, 0);
            DecompressionGroupEnum groupAfterDive1=DivingTablesHelper.GetDecompGroup(_divedata.Dive1Depth, _divedata.Dive1Time, 0);
            ucDivePlan1.GroupAfterDive = groupAfterDive1.ToString();

            ucDivePlan2.Depth = _divedata.Dive2Depth;
            ucDivePlan2.Time = _divedata.Dive2Time;
            ucDivePlan2.RestingTime = _divedata.Dive2RestingTime;
            DecompressionGroupEnum groupAfterResting2=DivingTablesHelper.GetGroupAfterResting(groupAfterDive1, _divedata.Dive2RestingTime);
            ucDivePlan2.NewGroup = groupAfterResting2.ToString();
            int nitrogenBeforeDive2 = DivingTablesHelper.GetNitrogenDebt(groupAfterResting2, _divedata.Dive2Depth);
            ucDivePlan2.NitrogenDepth = nitrogenBeforeDive2;
            ucDivePlan2.MaxDepth = DivingTablesHelper.GetMaxTimeForDepth(_divedata.Dive2Depth, nitrogenBeforeDive2);
            ucDivePlan2.GroupAfterDive = DivingTablesHelper.GetDecompGroup(_divedata.Dive2Depth, _divedata.Dive2Time, nitrogenBeforeDive2).ToString();
            DecompressionGroupEnum groupAfterDive2 = DivingTablesHelper.GetDecompGroup(_divedata.Dive2Depth, _divedata.Dive2Time, nitrogenBeforeDive2);

            ucDivePlan3.Depth = _divedata.Dive3Depth;
            ucDivePlan3.Time = _divedata.Dive3Time;
            ucDivePlan3.RestingTime = _divedata.Dive3RestingTime;
            DecompressionGroupEnum groupAfterResting3 = DivingTablesHelper.GetGroupAfterResting(groupAfterDive2, _divedata.Dive3RestingTime);
            ucDivePlan3.NewGroup = groupAfterResting3.ToString();
            int nitrogenBeforeDive3 = DivingTablesHelper.GetNitrogenDebt(groupAfterResting3, _divedata.Dive3Depth);
            ucDivePlan3.NitrogenDepth = nitrogenBeforeDive3;
            ucDivePlan3.MaxDepth = DivingTablesHelper.GetMaxTimeForDepth(_divedata.Dive3Depth, nitrogenBeforeDive3);
            ucDivePlan3.GroupAfterDive = DivingTablesHelper.GetDecompGroup(_divedata.Dive3Depth, _divedata.Dive3Time, nitrogenBeforeDive3).ToString();

            _isLoaded = true;
        }

        private void UpdateData()
        {
            _divedata.Dive1Depth = ucDivePlan1.Depth;
            _divedata.Dive1Time = ucDivePlan1.Time;

            _divedata.Dive2RestingTime = ucDivePlan2.RestingTime;
            _divedata.Dive2Depth = ucDivePlan2.Depth;
            _divedata.Dive2Time = ucDivePlan2.Time;

            _divedata.Dive3RestingTime = ucDivePlan3.RestingTime;
            _divedata.Dive3Depth = ucDivePlan3.Depth;
            _divedata.Dive3Time = ucDivePlan3.Time;

            RefreshFormControls();
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ucDivePlan1_OnPropertyChanged()
        {
            if(_isLoaded)UpdateData();
        }

        private void ucDivePlan2_OnPropertyChanged()
        {
            if (_isLoaded) UpdateData();
        }

        private void ucDivePlan3_OnPropertyChanged()
        {
            if (_isLoaded) UpdateData();
        }
    }
}