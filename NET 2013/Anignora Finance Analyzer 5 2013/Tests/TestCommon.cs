using System.Collections.Generic;
using AnignoraDataTypes;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestCommon
    {
        [Test]
        public void TestAddReplace()
        {
            List<int> myList=new List<int>();
            myList.AddReplace(1, (p_i2, p_i1) => p_i2 == p_i1);
            myList.AddReplace(2, (p_i2, p_i1) => p_i2 == p_i1);
            myList.AddReplace(2, (p_i2, p_i1) => p_i2 == p_i1);
            myList.AddReplace(3, (p_i2, p_i1) => p_i2 == p_i1);
            Assert.AreEqual(3,myList.Count);
        }
    }
}
