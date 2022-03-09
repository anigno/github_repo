using System;

namespace TalentCalc.Configuration
{
    public class ParameterConfig
    {
        #region Constructors

        public ParameterConfig()
        {
            //nothing
        }

        public ParameterConfig(string p_name, double p_minVal, double p_maxVal, double p_step, double p_rtVal)
        {
            Name = p_name;
            MinVal = p_minVal;
            MaxVal = p_maxVal;
            Step = p_step;
            Last = p_minVal;
            RtVal = p_rtVal;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("ParameterConfig Name={0} Last={1:0.000}", Name, Last);
        }

        #endregion

        #region Public Properties

        public string Name { get; set; }
        public double MinVal { get; set; }
        public double MaxVal { get; set; }
        public double Step { get; set; }
        public double Last { get; set; }
        public double RtVal { get; set; }

        #endregion
    }
}