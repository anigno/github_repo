using System;

namespace AfaDataExtraction.Contango
{
    public class ContangoExtractedData
    {
        public float ValueA { get; private set; }
        public float ValueB { get; private set; }
        public DateTime ReadDate { get; private set; }

        public ContangoExtractedData(float p_valueA, float p_valueB, DateTime p_readDate)
        {
            ValueA = p_valueA;
            ValueB = p_valueB;
            ReadDate = p_readDate;
        }

        public float ContangoValue
        {
            get
            {
                float contangoVal = ValueB / ValueA - 1;
                return contangoVal;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}] A={1} B={2} Contango={3}", ReadDate, ValueA, ValueB, ContangoValue);
        }
    }
}