using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AnignoProcessMonitorV3.ProcessMonitoring
{
    [DataContract(Name = "AnignoProcessMonitorV3", Namespace = "http://www.anignora.com")]
    public class MainData
    {

		#region (------  Fields  ------)


        [DataMember(Name = "ProcessesData")]
        public ProcessesDataDictionary ProcessesData = new ProcessesDataDictionary();

		#endregion (------  Fields  ------)

		#region (------  Properties  ------)


        [DataMember(Name = "BlockingEngage")]
        public bool BlockingEngage { get; set; }


		#endregion (------  Properties  ------)

    }

    [CollectionDataContract(ItemName = "ProcessData", KeyName = "KeyCommandLine", ValueName = "ProcessProperties")]
    public class ProcessesDataDictionary : Dictionary<string, ProcessData>
    {
}
}
