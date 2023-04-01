using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    /// <summary>
    /// Ladestatus einer DomainObject Membercollection
    /// Aller Member einer solchen Collection haben eine gemeinsamme Datenquelle
    /// </summary>
    public enum MemberStatus
    {
        Unbekannt, //Nicht geladen
        Geladen, //geladen
        NichtVerfuegbar, //Der Datenprovider konnte keine Daten liefern
        WirdGeladen //kann von MT Prozessen gesetzt werden, um mehrmaliges Bearbieten eines Ladetasks zu vermeiden
    }
}
