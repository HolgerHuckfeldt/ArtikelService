/*****************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Arbeitswerte
 * Funktionen: Abstrahiert die Schnittstelle aller ARbeitswerteManager und definiert seine Delegates 
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Artikel;
using PV.Interfaces;

namespace PV.Business.Services
{

    /// <summary>
    /// Beschreibt die Schnittstelle, welche ein Manager für Arbeitswerte erfüllen muss
    /// </summary>
    public interface IArbeitswerteBaseManager : IFinderManager, ISearchByStringManager
    {
        /// <summary>
        /// Liefert die Liste der sichtbaren (gefilterten) ArbeitsProzesse
        /// </summary>
        IList<Arbeitsprozess> ViewableArbeitsProzessListe
        {
            get;
        }

        string Disclaimer
        {
            get;
            set;
        }

        /// <summary>
        /// gibt an, ob die Arbeitswerte in der Artikelliste mit grafischer Suche (Temot, Auspuff, Lenkung) neu geladen werden müssen
        /// </summary>
        bool TemotArbeitswerteChange { get; set; }

        /// <summary>
        /// Liefert und setzt den selectierten ArbeitsProzess
        /// </summary>
        Arbeitsprozess SelectedArbeitsProzess
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        bool SindGenerischeDatenVisible
        {
            get;
        }

        IList<ArbeitswertTreeItem> Tree
        {
            get;
        }

        /// <summary>
        /// Lädt für einen Artikel die Arbeitswerte
        /// </summary>
        /// <param name="artikel">Der Artikel für welchen die Arbeitswerte geladen werden sollen</param>
        void LoadArbeitswerteAsync( Artikel artikel );

    }
}
