using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace AnignoLibrary.Misc
{
    [TestFixture]
    public class CommandLineParser
    {
		#region (------------------  Fields  ------------------)
        private Dictionary<string,string> commands=new Dictionary<string, string>();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Tests  ------------------)
        [Test]
        public void Test_CommandLineParser()
        {
            CommandLineParser commandLineParser=new CommandLineParser(@"prog.exe a b=5 c=roni d e=ami /R");
            Assert.AreEqual("a", commandLineParser["a"]);
            Assert.AreEqual("5", commandLineParser["b"]);
            Assert.AreEqual("roni", commandLineParser["c"]);
            Assert.AreEqual("d", commandLineParser["d"]);
            Assert.AreEqual("ami", commandLineParser["e"]);
            Assert.AreEqual("/R", commandLineParser["/R"]);
            Assert.AreEqual(null, commandLineParser["NotExist"]);
        }
		#endregion (------------------  Tests  ------------------)


		#region (------------------  Constructors  ------------------)
        public CommandLineParser(string commandLineString)
        {
            MatchCollection mco = Regex.Matches(commandLineString, @"(?<DATA>[^ ]*=(""[^""]*""))|(?<DATA>([^ ]*=[^ ]*))");
            foreach (Match m in mco)
            {
                string part = m.Value;
                string[] itemParts = part.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                commands.Add(itemParts[0].Trim().ToUpper(), itemParts[1].Trim(new [] { '\"', ' ' }));
            }
        }

        public CommandLineParser()
            : this("")
        {
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public string this[string key]
        {
            get
            {
                if (commands.ContainsKey(key.ToUpper()))
                {
                    return commands[key.ToUpper()];
                }
                return null;
            }
        }
		#endregion (------------------  Properties  ------------------)
    }
}
