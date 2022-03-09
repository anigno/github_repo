using System.Collections.Generic;

namespace AfaDataExtraction
{
    public class SymbolExtractedDataEqualityComparerByReadDate : IEqualityComparer<SymbolExtractedData>
    {
        #region (------  Public Methods  ------)

        public bool Equals(SymbolExtractedData p_x, SymbolExtractedData p_y)
        {
            return p_x.DateRead.Date == p_y.DateRead.Date;
        }

        public int GetHashCode(SymbolExtractedData p_obj)
        {
            return p_obj.DateRead.GetHashCode();
        }

        #endregion (------  Public Methods  ------)
    }
}