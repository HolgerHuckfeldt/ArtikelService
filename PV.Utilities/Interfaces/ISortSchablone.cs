using System.Collections.Generic;
using PV.Utilities.Misc;

namespace PV.Utilities.Interfaces
{
    public interface ISortSchablone <T> : IComparer<T> where T : class
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

        System.Reflection.PropertyInfo GetPropertyForSort();
    }
}
