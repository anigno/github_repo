using System;
using AfaDataExtraction.Contango;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems.SystemsExtended;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestContango
    {
        [Test]
        public void TestContangoManager()
        {
            ContangoManager contangoManager=new ContangoManager(4,60,new AfaSystemXivVxx("",1234,"1") );

        }

        [Test]
        public void TestContangoExtractor()
        {
            ContangoExtractor extractor = new ContangoExtractor();
            ContangoExtractedData lastContangoData = extractor.ExtractLastContangoData();
            Console.WriteLine("Contango={0} history length={1}", lastContangoData, extractor.ContangoExtractedData.Length);
            
            Assert.AreNotEqual(0, lastContangoData.ContangoValue);
            Assert.Greater(extractor.ContangoExtractedData.Length, 0);

            extractor.AddUpdate(lastContangoData);
            extractor.SaveContangoHistory();
        }

    }
}
