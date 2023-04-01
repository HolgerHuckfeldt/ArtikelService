/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Eigene Artikel Verwaltung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Persistierung der Eigenen Artikel erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Stammdaten;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die Persistierung der Eigenen Artikel erfüllen muss
    /// </summary>
    public interface IEigeneArtikelPersistanceProvider
    {
        /// <summary>
        /// Liefert für eine Werkstatt die eigenen Artikel
        /// </summary>
        /// <param name="_werkstatt">Die Werkstatt</param>
        /// <returns>Liste der eigenen Artikel</returns>
        
        List<EigenerArtikel> GetEigenerArtikelListe(Werkstatt _werkstatt);

        /// <summary>
        /// Liefert die nächste freie Nummer in der DB für einen Eigenen Artikel
        /// </summary>
        /// <returns></returns>
        
        int GetNextEigenerArtikelNummer();

        /// <summary>
        /// Sichert einen übergebenen eigenen Artikel
        /// </summary>
        /// <param name="_eigenerArtikel">Der zu sichernde eigene Artikel</param>
        /// <rereturns>Das Ergebnis des Sicherns</rereturns>
        
        SaveResults Save(EigenerArtikel _eigenerArtikel);

        /// <summary>
        /// Löscht einen übergebenen eigenen Artikel
        /// </summary>
        /// <param name="_eigenerArtikelId">Die Guid des zu löschenden eigenen Artikels</param>
        /// <returns>Das Ergebnis des Löschens als SaveResult</returns>
        
        SaveResults Delete( Guid _eigenerArtikelId );

        /// <summary>
        /// Lädt einen eigenen Artikel ahand seiner ID
        /// </summary>
        /// <param name="_id">Die Artikelnummer des gesuchten Artikels</param>
        
        EigenerArtikel GetArtikelByArtikelnummer(long _id);

        
        EigenerArtikel GetArtikelByGuid(Guid _id);

        /// <summary>
        /// Liefert die nächste ID aus dem Nummernkreis für Durchlaufartikel
        /// </summary>
        /// <returns></returns>
        
        int GetNextDurchlaufartikelId();

        
        void ReleaseDurchlaufartikelId(int id);

        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
