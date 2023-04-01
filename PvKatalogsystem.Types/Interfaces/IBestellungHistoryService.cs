using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IBestellungHistoryService
    {
        BestellungDetails GetBestellungById(Int32 bestellungId, int profilId);
        List<BestellungInfo> FindTodayBestellungen(int profilId);
        List<BestellungInfo> FindYesterdayBestellungen(int profilId);
        List<BestellungInfo> FindBeforeYesterdayBestellungen(int profilId);
    }
}
