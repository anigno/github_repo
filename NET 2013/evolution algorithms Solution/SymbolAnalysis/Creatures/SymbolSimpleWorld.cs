using System.Collections.Generic;
using SymbolAnalysis.Data;

namespace SymbolAnalysis.Creatures
{
    public class SymbolSimpleWorld
    {
        public ExtractedResult[] ExtractedResults { get; private set; }
        public Dictionary<sbyte[], float> DnaScoresDictionary { get; private set; }
    }
}