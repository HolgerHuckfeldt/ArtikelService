using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.Utilities.Misc
{
    public abstract class ComparerBase<T> : Interfaces.ISortSchablone<T> where T : class
    {
        private List<PVItemListe<T>> _ListOfItemListen = new List<PVItemListe<T>>();

        protected void ProcessStrategies()
        {
            foreach (PVItemListe<T> itemListe in _ListOfItemListen)
            {
                itemListe.ProcessStrategies(true);
            }
        }

        public void RegisterItemListe(PVItemListe<T> _itemListe)
        {
            if (!_ListOfItemListen.Contains(_itemListe))
            {
                _ListOfItemListen.Add(_itemListe);
            }
        }

        public void UnRegisterItemListe(PVItemListe<T> _itemListe)
        {
            if (_ListOfItemListen.Contains(_itemListe))
            {
                _ListOfItemListen.Remove(_itemListe);
            }
        }

        public abstract System.Reflection.PropertyInfo GetPropertyForSort();

        #region Implementation of IComparer<Artikel>

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
        public abstract int Compare(T x, T y);

        #endregion
    }
}
