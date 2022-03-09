using System.Collections.Generic;

namespace AfaDataExtraction
{
    public interface IExtractionManager
    {
        event ExtractionManager.SymbolExtractedDelegate SymbolExtracted;
        void AddSymbolsWebNames(params string[] p_symbolsWebName);
        Dictionary<string, SymbolExtractedData> GetSymbolsRecentData();
        void Start();
        void Stop();
    }
}