/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       Eigene Artikel Verwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle des Managers und definiert dessen Delegates
 *********************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using PVInterfaces.Enums;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Managers und definiert dessen Delegates
    /// </summary>
    public interface IEigeneArtikelManager : ISearchByStringManager
    {
        /// <summary>
        /// Liefert die Liste aller eigenen Artikel
        /// </summary>
        IList<EigenerArtikel> EigeneArtikelListe
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der sichtbaren eigenen Artikel
        /// </summary>
        IList<EigenerArtikel> ViewableEigenerArtikelListe
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den selektierten eigenen Artikel
        /// </summary>
        EigenerArtikel SelectedEigenerArtikel
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen teilweise initialisierten (z.B. Nummer) neuen eigenen Artikel
        /// </summary>
        /// <returns>Der neue Artikel</returns>
        EigenerArtikel GetEmptyEigenenArtikel();

        /// <summary>
        /// Sichert einen übergebenen eigenen Artikel
        /// </summary>
        /// <param name="_eigenerArtikel">Der zu sichernde eigene Artikel</param>
        SaveResults Save( EigenerArtikel _eigenerArtikel );

        /// <summary>
        /// Löscht einen übergebenen eigenen Arbeitswert
        /// </summary>
        /// <param name="_eigenerArtikel">Der zu löschende eigene Artikel</param>
        SaveResults Delete( EigenerArtikel _eigenerArtikel );

        /// <summary>
        /// Resettet die Viewable Liste auf alle vorhandenen Artikel
        /// </summary>
        void ResetEigeneArtikelListe();

        /// <summary>
        /// Reloadet die Viewable Liste entweder auf alle vorhandenen eigenen Artikel oder auf die letzten Suchergebnisse
        /// </summary>
        void ReloadViewableEigeneArtikelListe();

        /// <summary>
        /// Liefert die entspr. nächste Nummer.
        /// </summary>
        /// <returns></returns>
        int GetNextDurchlaufartikelNummer();

        /// <summary>
        /// Wieder freigeben
        /// </summary>
        /// <param name="nummer"></param>
        void ReleaseDurchlaufartikelNummer(int nummer);
    }
}