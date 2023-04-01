/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Kunden Identifikation
* Funktionen: Abstrahiert die Schnittstelle des KundenManagers und definiert seine Delegates 
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Kunden;
using PV.Utilities.Interfaces;
using PVInterfaces.Enums;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Businesslayers zum Frontend bezüglich der Kundendaten
    /// </summary>
    public interface IKundenDatenManager : ISearchByStringManager
    {
        /// <summary>
        /// Liefert die Liste der anzeigbaren Kunden
        /// </summary>
        IList<Kunde> ViewableKundenListe
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den selektierten Kunden
        /// </summary>
        Kunde SelectedKunde
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen leeren Kunden
        /// </summary>
        /// <returns>Ein Kundenobjekt</returns>
        Kunde GetEmptyKunde();

        /// <summary>
        /// Speichert einen Kunden
        /// </summary>
        /// <param name="_kunde">Der zu speichernde Kunde</param>
        /// <returns>Das Ergebnis des Speicherns als SaveResult</returns>
        SaveResults SaveKunde( Kunde _kunde );

        /// <summary>
        /// Löscht einen Kunden
        /// </summary>
        /// <param name="_kunde">Der zu löschende Kunde</param>
        /// <returns>Das Ergebnis des Löschens als SaveResult</returns>
        SaveResults DeleteKunde( Kunde _kunde );

        /// <summary>
        /// Resetet die ViewableKundenListe, so dass sie alle Kunden der KundenListe enthält
        /// </summary>
        void ClearViewableKundenListe();

        /// <summary>
        /// Setzt einen Typen anhand seiner Ressource anhand seines RessourceStrings
        /// </summary>
        /// <param name="_toSet">Der zu setzende String</param>
        void SetTypByRessourceUri( string _toSet );

        /// <summary>
        /// Liefert den in einem HistoryEntry verschlüsselten PKW, NKW, die Achse oder den Motor
        /// </summary>
        /// <param name="toSet">Das HistoryEntry</param>
        /// <returns>PKW, NKW, Achse oder Motor als Object</returns>
        int GetTypByRessourceUriPubi(string toSet);

        /// <summary>
        /// Reloadet die ViewableKundenliste anhand der letzten Suchmethode
        /// </summary>
        void ReloadViewableKundenListe();
    }
}
