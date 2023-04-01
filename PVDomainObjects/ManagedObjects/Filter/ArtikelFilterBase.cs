/***************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Base aller Artikelfilter
 ***************************************************************************/

using System;
using System.Collections.Generic;
using PV.Utilities.Interfaces;
using PV.Utilities.Misc;

namespace PV.DomainObjects.ManagedObjects.Filter
{
    /// <summary>
    /// Base aller Artikelfilter
    /// </summary>
    [Serializable]
    public abstract class ArtikelFilterBase : IFilterSchablone<Artikel.Artikel>
    {
        protected List<PVItemListe<Artikel.Artikel>> _ListOfItemListen = new List<PVItemListe<Artikel.Artikel>>();


        /// <summary>
        /// Registriert die ItemListe bei dieser Schablone.
        /// 
        /// Die ItemListe muss registriert werden, damit wenn die Filtereinstellungen geändert werden
        /// die ItemListe alle Strategies neu Filtern lassen kann
        /// 
        /// Eine Filterstrategie ruft in diesem Fall ProcessStrategies der ItemListe auf.
        /// </summary>
        /// <param name="_itemListe"></param>
        public void RegisterItemListe(PVItemListe<Artikel.Artikel> _itemListe)
        {
            if (!_ListOfItemListen.Contains(_itemListe))
            {
                _ListOfItemListen.Add(_itemListe);
            }
        }


        /// <summary>
        /// UnRegistriert die ItemListe bei dieser Schablone.
        /// 
        /// Die ItemListe muss registriert werden, damit wenn die Filtereinstellungen geändert werden
        /// die ItemListe alle Strategies neu Filtern lassen kann
        /// 
        /// Eine Filterstrategie ruft in diesem Fall ProcessStrategies der ItemListe auf.
        /// </summary>
        /// <param name="_itemListe"></param>
        public void UnRegisterItemListe(PVItemListe<Artikel.Artikel> _itemListe)
        {
            if (_ListOfItemListen.Contains(_itemListe))
            {
                _ListOfItemListen.Remove(_itemListe);
            }
        }

        /// <summary>
        /// Hier muss die Schablone filtern!
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public abstract bool Pass( Artikel.Artikel _item );

        /// <summary>
        /// Leitet ProcessStrategies an alle Itemlisten weiter
        /// </summary>
        protected void ProcessStrategies()
        {
            foreach ( PVItemListe<Artikel.Artikel> itemListe in _ListOfItemListen )
            {
                itemListe.ProcessStrategies(true);
            }
        }

        /// <summary>
        /// Setzt den Filter zurück
        /// </summary>
        public abstract void Reset();
    }
}