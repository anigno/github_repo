using System.IO;
using System.Text;

namespace AnignoraIO
{
    public class StreamReaderHebrew : StreamReader
    {
        public StreamReaderHebrew(string path)
            : base(path, (Encoding) StreamWriterHebrew.HEBREW_ENCODING)
        {
        }
    }
}