/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Walter Licht   
* Modul:    Artikelsuche
* Funktionen: Abstrahiert die Schnittstelle
*****************************************************************************************************/
using System;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Warenkorb;
using PV.Utilities.Misc;

namespace PV.Business.Services
{
    public interface INotwendigeArtikelManager
    {
        /// <summary>
        /// Setzt mechanismen in Gang, die im System Notwendige Artikel zu dem Artikel suchen
        /// und gegebenenfalls eine UserNotification auslösen
        /// </summary>
        /// <param name="_artikel"></param>
        void RunNotwendigeArtikelQuery(Artikel _artikel, decimal menge);

        /// <summary>
        /// Die zuletzt gefundenen NetwendigenArtikel
        /// </summary>
        PVItemListe<VerwandterArtikel> LastFoundNotwendigeArtikel
        {
            get;
        }

        /// <summary>
        /// Artikel, für den zuletzt erfolgreich Notwendige Artikel abgefragt wurden.
        /// </summary>
        Artikel LastSuccessfullyQueriedArtikel
        { 
            get;
        }
    }
}
