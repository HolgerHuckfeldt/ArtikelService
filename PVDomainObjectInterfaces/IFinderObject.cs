/*******************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Modulübergreifend   
 * Funktionen:  Beschreibt die Schnittstelle eines FinderObjects
 *******************************************************************/

namespace PV.DomainObjectInterfaces
{
    /// <summary>
    /// Beschreibt die Schnittstelle eines FinderObjects
    /// </summary>
    public interface IFinderObject
    {
        /// <summary>
        /// Erforderlich für Testing!
        /// </summary>
        string TestTag
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die erste Spalte in der Finderspalte
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die zweite Spalte in der Finderspalte
        /// </summary>
        string Description2
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die dritte Spalte in der Finderspalte
        /// </summary>
        string Description3
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die vierte Spalte in der Finderspalte
        /// </summary>
        string Description4
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die fünfte Spalte in der Finderspalte
        /// </summary>
        string Description5
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die sechste Spalte in der Finderspalte
        /// </summary>
        string Description6
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die siebente Spalte in der Finderspalte
        /// </summary>
        string Description7
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die achte Spalte in der Finderspalte
        /// </summary>
        string Description8
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die neunte Spalte in der Finderspalte
        /// </summary>
        string Description9
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die zehnte Spalte in der Finderspalte
        /// </summary>
        string Description10
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt die ID des Parents
        /// </summary>
        string ParentID
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt die ID des Objektes
        /// </summary>
        string Id
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt die Tiefe im Baum
        /// </summary>
        int Tiefe
        {
            get;
        }

        bool IsNew
        {
            get;
            set;
        }
    }
}
