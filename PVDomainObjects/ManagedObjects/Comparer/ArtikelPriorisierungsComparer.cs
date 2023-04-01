/********************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Sortiert Artikel nach Ihrer Herstellerpriorisierung
 ********************************************************************************************************/

using System;
using System.Collections.Generic;

namespace PV.DomainObjects.ManagedObjects.Comparer
{
    /// <summary>
    /// Sortiert Artikel nach Ihrer Herstellerpriorisierung
    /// </summary>
    [Serializable]
    public class ArtikelPriorisierungsComparer : ArtikelComparerBase
    {
        /// <summary>
        /// Die Priorisierungen der Datenlieferantennummern
        /// </summary>
        public Dictionary<Int64, int> Priorisierungen
        {
            get;
            set;
        }

        public override System.Reflection.PropertyInfo GetPropertyForSort()
        {
            return typeof(Artikel.Artikel).GetProperty("VKPreis");
        }

        #region Overrides of ComparerBase<Artikel>

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// Value 
        ///                     Condition 
        ///                     Less than zero
        ///                 <paramref name="x"/> is less than <paramref name="y"/>.
        ///                     Zero
        ///                 <paramref name="x"/> equals <paramref name="y"/>.
        ///                     Greater than zero
        ///                 <paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.
        ///                 </param><param name="y">The second object to compare.
        ///                 </param>
        public override int Compare( Artikel.Artikel x, Artikel.Artikel y )
        {
            if ( Priorisierungen == null )
                return 0;
            if ( Priorisierungen.ContainsKey( x.DatenlieferantenNummer ) && Priorisierungen.ContainsKey( y.DatenlieferantenNummer ) )
                return Priorisierungen[ x.DatenlieferantenNummer ].CompareTo( Priorisierungen[ y.DatenlieferantenNummer ] );
            if ( Priorisierungen.ContainsKey( x.DatenlieferantenNummer ) && !Priorisierungen.ContainsKey( y.DatenlieferantenNummer ) )
                return -1;
            if ( !Priorisierungen.ContainsKey( x.DatenlieferantenNummer ) && !Priorisierungen.ContainsKey( y.DatenlieferantenNummer ) )
                return 0;
            //if ( !Priorisierungen.ContainsKey( x.DatenlieferantenNummer ) && Priorisierungen.ContainsKey( y.DatenlieferantenNummer ) )
            return 1;
        }

        #endregion
    }
}
