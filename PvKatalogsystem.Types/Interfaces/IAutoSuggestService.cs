using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Results;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{

    public interface IAutoSuggestService
    {
        
        IEnumerable<AutoSuggestItem> LoadFreetextSuggestion(ServiceContext context, AutoSuggestSuchfilter filter);
    }
}
