using System;

namespace AnignoraFinanceAnalyzer.Data
{
    public class CommonParams
    {
        public const string APPLICATION_NAME = "Anignora Finance Analyzer";
        public static readonly DateTime MINIMUM_DATE = new DateTime(1990, 1, 1).Date;
        public static readonly DateTime NEVER_UPDATED_DATETIME = DateTime.MinValue;

        public enum SignalEnum
        {
            None,
            Long,
            Short
        }

        public enum SignalResultEnum
        {
            None,
            Hit,
            Miss
        }

        public static string ApplicationHeader
        {
            get { return APPLICATION_NAME + @" " + DataManager.Instance.Version; }
        }

    }
}