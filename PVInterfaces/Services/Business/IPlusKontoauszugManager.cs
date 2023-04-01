using System;
using System.Collections.Generic;
using PV.DomainObjects.Warenkorb;

namespace PV.Business.Services
{
    public interface IPlusKontoauszugManager : ISearchByStringManager
    {

        Kontoauszug LoadKontoAuszug(DateTime _MinValue, DateTime _MaxValue, string Umsatzart);
        void SearchByStringZuruecksetzen();

        void OnPlusKontostandChanged();

        string Searchstring
        { get; set; }

        List<Transaktionen> Buchungen
        { get; set; }

        Kontoauszug Kontoauszug
        { get; set; }
    }
}
