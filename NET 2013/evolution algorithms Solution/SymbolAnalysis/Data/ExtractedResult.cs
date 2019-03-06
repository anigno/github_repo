using System;

namespace SymbolAnalysis.Data
{
    public class ExtractedResult
    {
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public double Volume { get; set; }
    }
}