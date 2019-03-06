using System;

namespace AfaDataExtraction.Contango
{
    public class ContangoDataExtractedEventArgs:EventArgs
    {
        public ContangoExtractedData[] ContangoData { get; private set; }
        public bool IsSucceeded { get; private set; }

        public ContangoDataExtractedEventArgs(ContangoExtractedData[] p_contangoData,bool p_isSucceeded)
        {
            ContangoData = p_contangoData;
            IsSucceeded = p_isSucceeded;
        }
    }
}
