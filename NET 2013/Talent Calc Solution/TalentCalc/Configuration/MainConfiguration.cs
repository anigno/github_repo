using System;
using System.IO;
using AnignoraDataTypes.Configurations;

namespace TalentCalc.Configuration
{
    public class MainConfiguration : IConfiguration
    {
        #region Public Methods

        public void SetDefaults()
        {
            RefIndexName = @"RawData\RefIndex\eurostoxx600.csv";
            RawDataFolder = @"RawData\Europe";
            StartDate = new DateTime(2006, 1, 1);
            //StartDate = new DateTime(2010, 1, 1);
            //StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;
            //RefIndexName = @"RawData\RefIndex\eurostoxx600.csv";
        }

        #endregion

        #region Public Properties

        public string RawDataFolder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RefIndexName { get; set; }

        #endregion
    }
}