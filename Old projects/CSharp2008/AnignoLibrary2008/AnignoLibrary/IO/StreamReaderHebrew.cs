using System.IO;

namespace AnignoLibrary.IO
{
    public class StreamReaderHebrew : StreamReader
    {
        public StreamReaderHebrew(string path)
            : base(path, StreamWriterHebrew.HEBREW_ENCODING)
        {
        }
    }
}