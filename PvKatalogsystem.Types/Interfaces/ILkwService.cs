using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface ILkwService
    {
        List<Lkw> GetLkwList(IEnumerable<int> idList);
        List<Lkw> GetLkwListAll();
        List<Fahrzeugmodell> GetModellListAll();
        List<Fahrzeughersteller> GetHerstellerListAll();
    }
}
