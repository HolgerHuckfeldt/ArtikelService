/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelsuche
* Funktionen: Abstrahiert die Schnittstelle eines Artikelmanagers für Nummernsuche und definiert seine Delegates 
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using PV.Business.ManagedObjects;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;

namespace PV.Business.Services
{
    /// <summary>
    /// Definiert die Delegates für den Artikelmanager
    /// </summary>
    public interface INummernArtikelManager : IArtikelManager
    {
        /// <summary>
        /// Liefert den ManagerState (Busy/Ready)
        /// </summary>
        ManagerStates ManagerState { get; }       

        Int32 EANummerListCount { get; set; }

        Int32 GebrauchsNummerListCount { get; set; }

        Int32 ArtNummerListCount { get; set; }

        Int32 ArtEindeutigListCount { get; set; }

        Int32 VergleichsNummerListCount { get; set; }

        Int32 MatchcodeNummerListCount { get; set; }

        Int32 ReferenzNummerListCount { get; set; }

        bool Nummernsuche_BeliebigeNummer { get; set; }

        bool Nummernsuche_EindeutigeNummer { get; set; }

        bool Nummernsuche_Artikelnummer { get; set; }

        bool Nummernsuche_EANummer { get; set; }

        bool Nummernsuche_Gebrauchsnummer { get; set; }

        bool Nummernsuche_Referenznummer { get; set; }

        bool Nummernsuche_Vergleichsnummer { get; set; }

        bool Nummernsuche_Matchcode { get; set; }

        bool IsStartseitenartikelsuche { get; set; }

        new NummernsucheArtikelListe ArtikelListe { get; }

        /// <summary>
        /// Schnittstelle für die Freitextsuche
        /// </summary>
        /// <param name="artNr">Die zu suchende Artikelnummer</param>
        /// <param name="hlk">Der zu suchende HLK</param>
        void SearchByArtNrAndHlk(String artNr, String hlk);

		NummernsucheReferrer Referrer { get; set; }

        Artikel GetArtikel(string artikelnummer, string hlk);

        /// <summary>
        /// Setzt die Komplette Suche zurück
        /// </summary>
        void ResetSuche();
    }
	public enum NummernsucheReferrer
	{ 
		None,
		TeaserPvAngebote,
        TeaserPvBasics,
        Startseite
	}
}
