using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.Results
{
    [Serializable]
    public class AutoSuggestItem
    {

        public String DisplayNameSort { get; set; }
        public String DisplayName { get; set; }
        public bool NichtMehrBeruecksichtigen { get; set; }
        public String SynonymName { get; set; }
        public String FilterQuery { get; set; }
        public String OriginalName { get; set; }
        public Int32 ResultCount { get; set; }
        public AutoSuggestItemTypes Type { get; set; }
        public int GenArtId { get; set; }
        public bool ValueCorrect { get; set; }
        public bool IsAutosuggestAusSpellcheck { get; set; }
    }

    
}
