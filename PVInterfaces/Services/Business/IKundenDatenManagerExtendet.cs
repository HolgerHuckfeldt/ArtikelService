/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Kunden Identifikation
* Funktionen: Abstrahiert die Schnittstelle des erweiterten KundenManagers und definiert seine Delegates 
*****************************************************************************************************/

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des erweiterten KundenManagers und definiert seine Delegates
    /// </summary>
    public interface IKundenDatenManagerExtendet:IKundenDatenManager
    {
        /// <summary>
        /// Sucht Kunden, deren Kundennummer, Firmenname, Name, Vorname, PLZ, Ort, Strasse OHNE das Kennzeichen
        /// </summary>
        /// <param name="_toSearch">Der String nach dem gesucht werden soll</param>
        void SearchKundeSimpleByString( string _toSearch );

        /// <summary>
        /// Sucht Kunden anhand eines Kennzeichens der ihm zugeordneten Fahrzeuge
        /// </summary>
        /// <param name="_kennzeichen">Das Kennzeichen</param>
        void SearchByKennzeichen( string _kennzeichen );
    }
}
