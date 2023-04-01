/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelsuche
* Funktionen: Abstrahiert die Schnittstelle des Artikelmanagers und definiert seine Delegates 
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.ManagedObjects;
using PV.Interfaces;
using PV.Utilities.Interfaces;
using PV.Utilities.Misc;
using PV.DomainObjects.Warenkorb;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Artikelmanagers
    /// </summary>
    public interface IArtikelManager : IFinderManager, ISearchByStringManager
    {
        #region Properties

        bool NeueArtikelsuche
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt und liefert die Artikelliste
        /// </summary>
        FinderArtikelListe ArtikelListe
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der Incentive Artikel
        /// </summary>
        IncentiveArtikelListe Incentives
        { 
            get;
        }

        /// <summary>
        /// Liefert die Liste der Artikel für das Modul PV:Empfiehlt (Kompass Startseite)
        /// </summary>
        PVItemListe<Artikel> TeaserIncentiveArtikel
        {
            get;
        }

        PVItemListe<Artikel> BonusArtikel { get; }

        /// <summary>
        /// Liefert die Liste der Artikel für das Modul PV:Angebote (Kompass Startseite)
        /// </summary>
        PVItemListe<Artikel> TeaserArtikel
        {
            get;
        }

        PVItemListe<Artikel> TeaserPvBasicsArtikel
        {
            get;
        }

        PVItemListe<Artikel> TeaserPvBasicsArtikelList
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt die Liste der Breadcrumbs zum aktuellen Artiken, 
        /// wobei eine Breadcrumb eine Liste von Suchbaumeinträgen darstellt.
        /// </summary>
        IList<IList<SuchbaumEintrag>> ArtikelSuchBreadcrumbListe
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt für ein T-Mod Bild die Ressource
        /// </summary>
        string RessourcePictureUri
        {
            get;
            set;
        }

        #endregion

        #region SetMethoden

        /// <summary>
        /// Methode zum Selektieren des Suchbaumeintrags durch die Oberfläche
        /// </summary>
        /// <param name="_eintrag">Die ID des zu setzende Suchbaumeintrag</param>
        void SelectSuchBaumEintragByID( int _eintrag );

        /// <summary>
        /// Methode zum Selektieren des Suchbaumeintrags durch die Oberfläche
        /// </summary>
        /// <param name="_eintrag">Der zu setzende Suchbaumeintrag als SuchbaumEintrag</param>
        void SelectSuchBaumEintrag( SuchbaumEintrag _eintrag );

        
        /// <summary>
        /// Methode zum Selektieren des eines BreadcrumbEndpunktes durch die Oberfläche
        /// </summary>
        /// <remarks>Wird der BreadcrumbEndpunktes mit dieser Methode gesetzt, wird ViewableArtikellist gefiltert </remarks>
        /// <param name="_eintrag">Der zu setzende BreadcrumbEndpunktes</param>
        void SetCurrentArtikelSuchBreadcrumb( SuchbaumEintrag _eintrag );

        void GetArtikelByWeitereHersteller(bool mitWeiterenHerstellern);

        int SetSortVerfuegbarkeit(wkVerfuegbarkeit verfuegbarkeit);

        #endregion
    }
}
