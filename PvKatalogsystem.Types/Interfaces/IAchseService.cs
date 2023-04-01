using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IAchseService
    {
        List<Achse> GetAchseList(IEnumerable<int> idList);
        List<Achse> GetAchseListAll();
        List<Fahrzeugmodell> GetModellListAll();
        List<Fahrzeughersteller> GetHerstellerListAll();
    }
}
