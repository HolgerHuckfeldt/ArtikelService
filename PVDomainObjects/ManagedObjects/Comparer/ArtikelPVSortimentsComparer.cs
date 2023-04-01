/********************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Sortiert Artikel danach ob sie zum PV Sortiment gehören.
 *              PV-Sortimentsartikel sind dabei kleiner als Nicht-PV-Sortimentsartikel
 ********************************************************************************************************/

using System;

namespace PV.DomainObjects.ManagedObjects.Comparer
{
    /// <summary>
    /// Sortiert Artikel danach ob sie zum PV Sortiment gehören.
    /// </summary>
    [Serializable]
    public class ArtikelPVSortimentsComparer : ArtikelComparerBase
    {
        #region Overrides of ComparerBase<Artikel>

        public override System.Reflection.PropertyInfo GetPropertyForSort()
        {
            return typeof(Artikel.Artikel).GetProperty("VKPreis");
        }

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
            Int32 cx = (!string.IsNullOrEmpty(x.HLK) || x.HatStueckliste) ? 0 : 1;
            Int32 cy = (!string.IsNullOrEmpty(y.HLK) || y.HatStueckliste) ? 0 : 1;

            return cx.CompareTo(cy);
        }

        #endregion
    }
}
