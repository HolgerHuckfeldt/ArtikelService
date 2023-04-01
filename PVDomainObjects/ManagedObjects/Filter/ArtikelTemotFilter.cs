/***************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Filtert Artikel nach TI-Numern
 ***************************************************************************/

using System;
using System.Collections.Generic;

namespace PV.DomainObjects.ManagedObjects.Filter
{
    /// <summary>
    /// Filtert Artikel nach TI-Numern
    /// </summary>
    [Serializable]
    public class ArtikelTemotFilter : ArtikelFilterBase
    {
        private IList<string> _Artikelnummern;
        private IList<int> _ArtikelIds;

        /// <summary>
        /// Setzt die Liste der Nummern, nach welchen gefiltert werden soll
        /// </summary>
        public IList<string> Artikelnummern
        {
            get
            {
                return _Artikelnummern;
            }
            set
            {
                _Artikelnummern = value; 
                
                ProcessStrategies();
            }
        }

        public IList<int> ArtikelIds
        {
            get
            {
                return _ArtikelIds;
            }
            set
            {
                _ArtikelIds = value;

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
            if (ArtikelIds != null)
                return ArtikelIds.Contains(_item.ArtikelId);

            return Artikelnummern == null || Artikelnummern.Contains( _item.TiNumber );
        }

        /// <summary>
        /// Setzt den Filter zurück
        /// </summary>
        public override void Reset()
        {
            Artikelnummern = null;
            ArtikelIds = null;
        }

        #endregion
    }
}
