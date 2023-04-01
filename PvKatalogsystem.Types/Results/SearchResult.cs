using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Results
{
    [Serializable]
    public class SearchResult
    {
        public SearchResult(int numFound, int startIndex, int rowCount)
        {
            NumFound = numFound;
            StartIndex = startIndex;
            RowCount = rowCount;
        }

        public int NumFound { get; private set; }
        public int StartIndex { get; private set; }
        public int RowCount { get; private set; }
    }
}
