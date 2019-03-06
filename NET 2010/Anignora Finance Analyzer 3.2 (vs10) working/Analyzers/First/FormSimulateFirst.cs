using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AnignoLibrary.Helpers.InvokationHelpers;

namespace Analyzers.First
{
    public partial class FormSimulateFirst : Form
    {
        private Thread simulationThread;

        public FormSimulateFirst()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled=false;
            simulationThread=new Thread(SimulationThreadStart);
            simulationThread.Start();
        }

        private void SimulationThreadStart()
        {
            int smallAvgMin = (int)numericUpDownSmallAvgMin.Value;
            int smallAvgMax = (int)numericUpDownSmallAvgMax.Value;
            int largeAvgMin = (int)numericUpDownLargeAvgMin.Value;
            int largeAvgMax = (int)numericUpDownLargeAvgMax.Value;
            int negResMin = (int)numericUpDownNegResMin.Value;
            int negRevMax = (int)numericUpDownNegResMax.Value;
            int posResMin = (int)numericUpDownPosResMin.Value;
            int posResMax = (int)numericUpDownPosResMax.Value;
            int daysPosMin = (int)numericUpDownDaysPosMin.Value;
            int daysPosMax = (int)numericUpDownDaysPosMax.Value;
            DateTime dateFrom = dateTimePickerFrom.Value;
            DateTime dateTo = dateTimePickerTo.Value;

            for (int smallAvg = smallAvgMin; smallAvg <= smallAvgMax; smallAvg++)
            {
                for (int largeAvg = largeAvgMin; largeAvg <= largeAvgMax; largeAvg++)
                {
                    for (int negRes = negResMin; negRes <= negRevMax; negRes++)
                    {
                        for (int posRes = posResMin; posRes <= posResMax; posRes++)
                        {
                            for (int daysPos = daysPosMin; daysPos <= daysPosMax; daysPos++)
                            {
                                //nothing yet
                            }
                        }
                    }
                }
            }


            GenericInvoker.GenericInvoke(buttonStart, b => b.Enabled = true);
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            try
            {
                if (simulationThread != null) simulationThread.Abort();
            }
            catch
            {
                //nothing, thread aborted
            }
        }


    }
}
