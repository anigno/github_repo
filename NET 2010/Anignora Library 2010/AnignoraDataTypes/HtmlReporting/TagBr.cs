
using System;

namespace AnignoraDataTypes.HtmlReporting
{
    public class TagBr : Tag
    {
        public TagBr()
            : base("BR")
        {
        }

        public override string ToString()
        {
            return "<BR>" + Environment.NewLine;
        }
    }
}