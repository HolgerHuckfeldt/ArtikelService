using System;
using PV.Utilities.Misc;

namespace PV.Utilities.Interfaces
{
    public interface IFilterSchablone <T> where T : class
    {
        /// <summary>
        /// Registriert die ItemListe bei dieser Schablone.
        /// 
        /// Die ItemListe muss registriert werden, damit wenn die Filtereinstellungen geändert werden
        /// die ItemListe alle Strategies neu Filtern lassen kann
        /// 
        /// Eine Filterstrategie ruft in diesem Fall ProcessStrategies der ItemListe auf.
        /// </summary>
        /// <param name="_itemListe"></param>
        void RegisterItemListe(PVItemListe<T> _itemListe);

        /// <summary>
        /// UnRegistriert die ItemListe bei dieser Schablone.
        /// 
        /// Die ItemListe muss registriert werden, damit wenn die Filtereinstellungen geändert werden
        /// die ItemListe alle Strategies neu Filtern lassen kann
        /// 
        /// Eine Filterstrategie ruft in diesem Fall ProcessStrategies der ItemListe auf.
        /// </summary>
        /// <param name="_itemListe"></param>
        void UnRegisterItemListe(PVItemListe<T> _itemListe);

        /// <summary>
        /// Hier muss die Schablone filtern!
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        Boolean Pass(T _item);

        /// <summary>
        /// Resettet den Filter
        /// </summary>
        void Reset();

    }
}
