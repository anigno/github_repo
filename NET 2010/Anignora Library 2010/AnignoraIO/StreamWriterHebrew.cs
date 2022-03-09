using System.Text;
using System.IO;

namespace AnignoraIO
{
    public class StreamWriterHebrew : StreamWriter
    {
        internal static readonly Encoding HEBREW_ENCODING = Encoding.GetEncoding("windows-1255");

        public StreamWriterHebrew(string path, bool append)
            : base(path, append, HEBREW_ENCODING)
        {
        }
    }
}