using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;

namespace Testing
{
    [TestFixture]
    public class Program
    {
        [Test]
        public void TestCommonMap()
        {
            float f;
            f = CommonHelper.Map(0, 0, 255, -12, 12);
            Assert.AreEqual(-12,f,0.1);
            f = CommonHelper.Map(128, 0, 255, -12, 12);
            Assert.AreEqual(0, f, 0.1);
            f = CommonHelper.Map(255, 0, 255, -12, 12);
            Assert.AreEqual(12, f, 0.1);

            f = CommonHelper.Map(0f, -1, 1, -12, 12);
            Assert.AreEqual(0, f, 0.1);
            f = CommonHelper.Map(-1f, -1, 1, -12, 12);
            Assert.AreEqual(-12, f, 0.1);
            f = CommonHelper.Map(1f, -1, 1, -12, 12);
            Assert.AreEqual(12, f, 0.1);
        }

        static void Main(string[] args)
        {
        }
    }
}
