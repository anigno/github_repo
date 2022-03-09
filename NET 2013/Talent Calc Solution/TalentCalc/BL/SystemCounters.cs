using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentCalc.BL
{
    public class SystemCounters
    {
        #region Constructors

        public SystemCounters()
        {
            m_cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        #endregion

        #region Public Properties

        public int CpuCounter
        {
            get { return (int) m_cpuCounter.NextValue(); }
        }

        #endregion

        #region Fields

        private readonly PerformanceCounter m_cpuCounter;

        #endregion
    }
}