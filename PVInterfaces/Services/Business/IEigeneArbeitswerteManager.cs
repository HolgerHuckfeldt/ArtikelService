/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       Eigene Arbeitswerte Verwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle des Managers und definiert dessen Delegates
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using PV.Utilities.Interfaces;
using PVInterfaces.Enums;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Managers und definiert dessen Delegates
    /// </summary>
    public interface IEigeneArbeitswerteManager : ISearchByStringManager
    {
        /// <summary>
        /// Liefert die Liste der eigenen Arbeitswerte, welche die Werkstatt hat
        /// </summary>
        IList<EigenerArbeitswert> EigenerAWListe
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der sichtbaren eigenen Arbeitswerte
        /// </summary>
        IList<EigenerArbeitswert> ViewableEigenerAWListe
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den selektierten eigenen Arbeitswert
        /// </summary>
        EigenerArbeitswert SelectedEigenerAW
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen teilweise initialisierten (z.B. Nummer) neuen Arbeitswert
        /// </summary>
        /// <returns></returns>
        EigenerArbeitswert GetEmptyEigenenArbeitswert();

        /// <summary>
        /// Liefert die nächste ID aus dem Durchlaufaw-Nummernkreis
        /// </summary>
        /// <returns></returns>
        int GetNextDurchlaufarbeitswertNummer();

        /// <summary>
        /// Wieder freigeben
        /// </summary>
        /// <param name="nummer"></param>
        void ReleaseDurchlaufarbeitswertNummer(int nummer);

        /// <summary>
        /// Sichert einen übergebenen eigenen Arbeitswert
        /// </summary>
        /// <param name="_eigenerArbeitswert">Der zu sichernde eigene Arbeitswert</param>
        SaveResults Save( EigenerArbeitswert _eigenerArbeitswert );

        /// <summary>
        /// Löscht einen übergebenen eigenen Arbeitswert
        /// </summary>
        /// <param name="_eigenerArbeitswert">Der zu löschende eigene Arbeitswert</param>
        SaveResults Delete( EigenerArbeitswert _eigenerArbeitswert );

        /// <summary>
        /// Resettet die Viewable Liste auf alle vorhandenen Arbeitswerte
        /// </summary>
        void ResetEigeneArbeitswertListe();

        /// <summary>
        /// Reloadet die Viewable Liste entweder auf alle vorhandenen eigenen Arbeitswerte oder auf die letzten Suchergebnisse
        /// </summary>
        void ReloadViewableEigeneArbeitswertListe();

    }
}
