using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IPkwService
    {
        List<Pkw> GetPkwList(IEnumerable<int> idList);
        List<Pkw> GetPkwListAll();
        List<Fahrzeugmodell> GetModellList();
        List<Fahrzeughersteller> GetHerstellerListAll();
    }
}
