using System;
using System.Collections.Generic;

namespace PV.Utilities.Misc
{
    public class MultiComparer<T> : IComparer<T>
    {
        private IList<IComparer<T>> _Comparers;

        public MultiComparer(IList<IComparer<T>> _comparers)
        {
            _Comparers = _comparers;
        }

        #region IComparer<T> Member

        public int Compare(T x, T y)
        {
            foreach (IComparer<T> comparer in _Comparers)
            {
                Int32 c = comparer.Compare(x, y);
                if(c != 0)
                {
                    return c;
                }
            }
            return 0;
        }

        #endregion
    }
}
