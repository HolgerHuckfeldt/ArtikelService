using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.Utilities.Misc
{
    public class MergeSort<T>
    {
        private IComparer<T> _Comparer;
        public T[] SortArray(T[] array, IComparer<T> _comparer)
        {
            _Comparer = _comparer;
            merge_sort(ref array);
            return array;
        }


        public void SortList(IList<T> list, IComparer<T> _comparer)
        {
            T[] a = SortArray(list.ToArray(), _comparer);
            list.Clear();
            foreach (T artikel in a)
            {
                list.Add(artikel);
            }
        }


        private void merge_sort(ref T[] a)
        {

            if (a.Length <= 1)
                return;



            int middle = a.Length / 2;
            T[] left = new T[middle];
            T[] right = new T[a.Length - middle];


            Array.Copy(a, left, middle);
            Array.Copy(a, middle, right, 0, a.Length - middle);

            merge_sort(ref left);
            merge_sort(ref right);

            a = merge(left, right);

        }



        private T[] merge(T[] left, T[] right)
        {

            Queue<T> result = new Queue<T>(left.Length + right.Length);
            Queue<T> _left = new Queue<T>(left);
            Queue<T> _right = new Queue<T>(right);

            while (_left.Count > 0 && _right.Count > 0)
            {
                if (_Comparer.Compare(_left.Peek(),_right.Peek()) <= 0)
                    result.Enqueue(_left.Dequeue());
                else
                    result.Enqueue(_right.Dequeue());
            }



            while (_left.Count() > 0)
                result.Enqueue(_left.Dequeue());

            while (_right.Count() > 0)
                result.Enqueue(_right.Dequeue());

            return result.ToArray();
        }
    }
}
