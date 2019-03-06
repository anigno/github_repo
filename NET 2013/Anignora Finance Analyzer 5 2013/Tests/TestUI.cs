using System.Windows.Forms;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestUi
    {
        [Test, Ignore]
        public void Test()
        {
            //Starting UI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTest());

        }
    }
}
