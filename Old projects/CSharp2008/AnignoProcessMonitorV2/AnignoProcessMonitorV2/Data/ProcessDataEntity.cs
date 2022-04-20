using System.Diagnostics;
using System.IO;
using System.ComponentModel;

namespace AnignoProcessMonitorV2.Data
{
    public class ProcessDataEntity
    {

		#region Fields (5) 


        public string ProcessDescriptor;
        public string ProcessDescription;

        public bool ProcessAnnounceAllow;
        private bool _processAllowed;
        private bool _isSystemProcess;

		#endregion Fields 

		#region Properties (2) 


        public bool IsSystemProcess
        {
            get { return _isSystemProcess; }
            set
            {
                _isSystemProcess = value;
                if (value)
                {
                    ProcessAllowed = true;
                }
            }
        }

        public bool ProcessAllowed
        {
            get { return _processAllowed; }
            set { _processAllowed = value | IsSystemProcess; }
        }


		#endregion Properties 

    }
}