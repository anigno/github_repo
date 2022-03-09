using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using TalentCalc.Configuration;
using TalentCalc.Data;
using TalentCalc.Systems;

namespace Tests
{
    public class Test01
    {
        #region Public Methods

        [Test]
        public void TestFixRawData()
        {
            RawData[] rawA = new RawData[] {
                new RawData(new DateTime(1, 1, 9)) { Close = 9 },
                new RawData(new DateTime(1, 1, 8)) { Close = 8 },
                new RawData(new DateTime(1, 1, 7)) { Close = 7 },
                new RawData(new DateTime(1, 1, 5)) { Close = 5 },
                new RawData(new DateTime(1, 1, 3)) { Close = 3 },
                new RawData(new DateTime(1, 1, 1)) { Close = 1 },

            };
            RawData[] rawB = new RawData[] {
                new RawData(new DateTime(1, 1, 7)) { Close = 7 },
                new RawData(new DateTime(1, 1, 6)) { Close = 6 },
                new RawData(new DateTime(1, 1, 3)) { Close = 3 },
                };
            RawData[][] fixRawDataAB = SystemBase.FixRawData(rawA, rawB);
            RawData[][] fixRawDataBA = SystemBase.FixRawData(rawB, rawA);
        }


        [Test]
        public void TestIncreaseParametersRecurse()
        {
            List<ParameterConfig> parameters = new List<ParameterConfig>();
            parameters.Add(new ParameterConfig() { Name = "ParameterA", MinVal = 1, MaxVal = 4, Last = 1, RtVal = 3, Step = 1 });
            parameters.Add(new ParameterConfig() { Name = "BuyParam", MinVal = 5, MaxVal = 9, Last = 5, RtVal = 6, Step = 1 });
            bool b;
            do
            {
                Debug.WriteLine("[{0}] [{1}]", parameters[0], parameters[1]);
                b = SystemHelper.IncreaseParametersRecurse(0, parameters);
            } while (b);
            Debug.WriteLine("***");
            do
            {
                Debug.WriteLine("[{0}] [{1}]", parameters[0], parameters[1]);
                b = SystemHelper.IncreaseParametersRecurse(0, parameters);
            } while (b);
        }

        #endregion
    }
}