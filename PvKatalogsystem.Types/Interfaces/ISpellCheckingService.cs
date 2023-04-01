using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface ISpellCheckingService
    {
        
        List<SpellcheckResultDto> GetSpellCheckResult(ServiceContext context, ArtikelSuchoptionen optionen, string suchtext);

        
        IEnumerable<AutoSuggestItem> GetSpellCheckResultForAutosuggest(ServiceContext context, AutoSuggestSuchfilter filter);
    }
}
