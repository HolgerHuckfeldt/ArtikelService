using System;
using System.Collections.Generic;
using PV.DomainObjects.Bestellung;
using PV.DomainObjects.Warenkorb.Kalender;

namespace PV.DomainObjects.Warenkorb
{
    public interface IWarenkorb
    {
        long? BelegNummer
        {
            get;
            set;
        }

        string CreationUser
        {
            get;
            set;
        }

        string CreationProfil
        {
            get;
            set;
        }

        string StatusFailedText
        {
            get;
            set;
        }

        DateTime CreationTime
        {
            get;
            set;
        }

        string Titel
        {
            get;
            set;
        }

        Guid WarenkorbId
        {
            get;
        }

        long ResponseID_ValidateWarenkorb
        {
            get;
            set;
        }

        bool PerformBestellungAufruf
        {
            get;
            set;
        }

        long BestellId
        {
            get;
            set;
        }

        string OfflineBestellId
        {
            get;
            set;
        }

        bool VDBVerfuegbar
        {
            get;
            set;
        }

        Decimal EkSumme
        {
            get;
            set;
        }
        Boolean IstWarenkorbReserviert
        {
            get;
            set;
        }
        wkDay Liefertermin
        {
            get;
            set;
        }

        DateTime LieferterminDateTime
        {
            get;
            set;
        }

        IList<wkPosition> Positionen
        {
            get;
        }
        Liefermodi Lieferart
        {
            get;
            set;
        }
        IWarenkorbPosition Add( Artikel.Artikel artikel, decimal count );
        IWarenkorbPosition Add(Artikel.Artikel artikel, decimal count, Guid repDocGuid, bool throwOnWarenkorbChangedEvent);
        void Remove( Artikel.Artikel artikel );
        void SetPositions( IList<wkPosition> _positions );
        void OnWarenkorbChanged();
        List<Bonus> Bonuspunkte
        {
            get;
            set;
        }
        string BestellnotizAngabe
        {
            get;
            set;
        }
        string BestellnotizBestellnummer
        {
            get;
            set;
        }
        long Lieferbonus
        {
            get;
            set;
        }
        long LieferbonusInfo
        {
            get;
            set;
        }
    }
}
