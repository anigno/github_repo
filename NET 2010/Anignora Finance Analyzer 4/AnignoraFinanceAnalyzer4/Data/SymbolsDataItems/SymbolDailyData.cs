using System;
using System.Threading;

namespace AnignoraFinanceAnalyzer4.Data.SymbolsDataItems
{
  
    [Serializable]
    public class SymbolDailyData
    {
		#region (------  Fields  ------)

        public static readonly DateTime MINIMUM_DATE = new DateTime(2000, 1, 1).Date;
        private static int uniqueIdGenerator;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public SymbolDailyData(string descriptor,SymbolDailyData dayChange)
            : this(descriptor)
        {
            Update(dayChange);
        }

        public SymbolDailyData(string descriptor)
        {
            UniqueId = Interlocked.Increment(ref uniqueIdGenerator);

            ReadDate = MINIMUM_DATE;
            Descriptor = descriptor;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

   //Minimum extracting date
        public float Close { get; set; }

        public string Descriptor { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Open { get; set; }

        public DateTime ReadDate { get; set; }

        public int UniqueId { get; set; }

        public float Volume { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

        public float GetSymbolMultiplier()
        {
            int a = Descriptor.IndexOf(" ");
            if (a < 0) return 1.0f;
            return float.Parse(Descriptor.Substring(a)); 
        }

        public static string GetStockNameWithoutMultiplier(string stockDescriptor)
        {
            int a = stockDescriptor.IndexOf(" ");
            if (a < 0) return stockDescriptor;
            return stockDescriptor.Substring(0, a);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",Descriptor, ReadDate.ToShortDateString());
        }

        public void Update(SymbolDailyData dayChange)
        {
            Descriptor = dayChange.Descriptor;
            ReadDate = dayChange.ReadDate.Date;
            Open = dayChange.Open;
            High = dayChange.High;
            Low = dayChange.Low;
            Close = dayChange.Close;
            Volume = dayChange.Volume;
        }

		#endregion (------  Public Methods  ------)

    }
}