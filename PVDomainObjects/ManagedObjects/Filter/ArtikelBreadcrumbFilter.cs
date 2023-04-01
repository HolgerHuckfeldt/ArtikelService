/***************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Filtert Artikel anhand einer Breadcrumb
 ***************************************************************************/

using System;
using System.Linq;

namespace PV.DomainObjects.ManagedObjects.Filter
{
    /// <summary>
    /// Filtert Artikel anhand einer Breadcrumb
    /// </summary>
    [Serializable]
    public class ArtikelBreadcrumbFilter : ArtikelFilterBase
    {
        private int? _FilterNode;

        /// <summary>
        /// Setzt und liefert die ID der Breadcrumbnode, nach der gefiltert werden soll
        /// </summary>
        public int? FilterNode
        {
            get
            {
                return _FilterNode;
            }
            set
            {
                _FilterNode = value;
                ProcessStrategies();
            }
        }

        #region Overrides of ArtikelFilterBase

        /// <summary>
        /// Hier muss die Schablone filtern!
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public override bool Pass( Artikel.Artikel _item )
        {
            if (FilterNode != null)
            {
                return _item.NodeIDs.Count(x => x.ParentNodeId == FilterNode.Value) > 0;
            }
            return true;
        }

        #endregion

        public override void Reset()
        {
            FilterNode = null;
            ProcessStrategies();
        }
    }
}
