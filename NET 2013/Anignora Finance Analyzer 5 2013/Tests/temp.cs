using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Temp
    {
        [Test]
        public void LinqTest()
        {
            string[] sa = new string[] {"A", "B", "A", "C", "A"};
            var v1 = sa.Select((p_s, p_i) => new {p_s, p_i}).
                Where(p_newType => p_newType.p_s == "A").
                Select(p_newType => p_newType.p_i).ToArray();

        }
    }
}