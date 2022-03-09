using System;

namespace FinanceAnalizer2.Data
{
    /// <summary>
    /// Holds data that could be calculated
    /// </summary>
    public class DayChangedDataAnalyzed: DayChangeData
    {
		#region (------------------  Properties  ------------------)
        public DateTime DateTimeUpdated { get; set; }

        public int AnalizedOne { get; set; }

        public int AnalizedTwo { get; set; }


        public bool Hit { get; set; }

        public float Change { get; set; }

        
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        public override string ToString()
        {
            return string.Format("{0} DateUpdated:{1} AnalyzeOne:{2} AnalyzeTwo:{3}", base.ToString(), DateTimeUpdated.ToString(@"dd/MM/yyyy hh:mm:ss"),AnalizedOne,AnalizedTwo);
        }
		#endregion (------------------  Overridden Methods  ------------------)

    }
}
