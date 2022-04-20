using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AnignoLibrary.Misc.PerformanceCounters
{
    public class HighResolutionPerformanceCounter
    {
        #region Extern dlls
        // Retrieves the current value of the high-resolution performance counter
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        // Retrieves the frequency of the high-resolution performance counter
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);
        #endregion

        #region Fields
        private long _clockFrequency = 0;
        private long _start = 0;
        private long _stop = 0;
        #endregion

        public HighResolutionPerformanceCounter()
            : base()
        {
            QueryPerformanceFrequency(ref _clockFrequency);
            QueryPerformanceCounter(ref _start);
        }

        public void Reset()
        {
            QueryPerformanceCounter(ref _start);
        }

        public long GetMilliseconds()
        {
            QueryPerformanceCounter(ref _stop);
            return (_stop - _start) * 1000 / _clockFrequency;
        }

        public long GetMicroSeconds()
        {
            QueryPerformanceCounter(ref _stop);
            return (_stop - _start) * 1000000 / _clockFrequency-1;
        }
    }
}
