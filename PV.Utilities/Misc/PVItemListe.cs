using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using PV.Utilities.Interfaces;

namespace PV.Utilities.Misc
{
    [Serializable]
    public class PVItemListe<T> : IList<T>, INotifyCollectionChanged, INotifyPropertyChanged where T : class
    {
        private readonly List<T> _ItemListe = new List<T>();
        private List<T> _ViewableListe = new List<T>();

        private Int32 _SelectionIndex = -1;
        private T _LastSelectedItem = null;

        private bool _doStrategies = true;

        private readonly List<IFilterSchablone<T>> _FilterStrategies = new List<IFilterSchablone<T>>();
        private readonly List<ISortSchablone<T>> _SortStrategies = new List<ISortSchablone<T>>();
        private readonly MergeSort<T> _StableSort = new MergeSort<T>();

        public IList<T> GetAllItemsAsReadonly()
        {
            return new List<T>(_ItemListe);
        }

        public IList<T> GetViewableListeAsReadonly()
        {
            return new List<T>(_ViewableListe);
        }

        public void AddFilter(IFilterSchablone<T> filter)
        {
            if (_FilterStrategies.Contains(filter)) return;
            filter.RegisterItemListe(this);
            _FilterStrategies.Add(filter);
        }

        public void AddComparer(ISortSchablone<T> comparer)
        {
            if (_SortStrategies.Contains(comparer)) return;
            comparer.RegisterItemListe(this);
            _SortStrategies.Add(comparer);
        }

        public void RemoveComparer(ISortSchablone<T> comparer)
        {
            if (!_SortStrategies.Contains(comparer)) return;
            _SortStrategies.Remove(comparer);
        }

        public bool DoStrategies
        {
            get
            {
                return _doStrategies;
            }
            set
            {
                _doStrategies = value;
                if( _doStrategies)
                    this.ProcessStrategies(true);
            }
        }


        public void ProcessStrategies(bool doCollectionChanged)
        {

            if (DoStrategies)
            {
                PreProcessStrategies();

                T selectedItem = null;
                if (_SelectionIndex != -1 && _ViewableListe.Count > _SelectionIndex)
                {
                    selectedItem = _ViewableListe[SelectionIndex];
                }

                _ViewableListe.Clear();
                _ViewableListe.AddRange(_ItemListe);

                foreach (var strategie in FilterStrategies)
                {
                    List<T> tempListe = new List<T>();
                    foreach (T item in _ViewableListe)
                    {
                        if (strategie.Pass(item))
                        {
                            tempListe.Add(item);
                        }
                    }

                    _ViewableListe = tempListe;
                }

                List<IComparer<T>> comparers = new List<IComparer<T>>();
                foreach (ISortSchablone<T> sortSchablone in SortStrategies)
                {
                    if (sortSchablone.GetPropertyForSort() != null)
                    {
                        comparers.Add(sortSchablone);
                    }
                }

                if (comparers.Count > 0)
                {
                    _StableSort.SortList(_ViewableListe, new MultiComparer<T>(comparers));
                }

                if (selectedItem != null)
                {
                    if (_ViewableListe.Contains(selectedItem))
                    {
                        if (SelectionIndex != _ViewableListe.IndexOf(selectedItem))
                        {
                            SelectionIndex = _ViewableListe.IndexOf(selectedItem);
                            OnPropertyChanged("SelectionIndex");
                            OnPropertyChanged("SelectedItem");
                            OnPropertyChanged("PrevItem");
                            OnPropertyChanged("NextItem");
                        }
                    }
                }

                else if (_ViewableListe.Any())
                {
                    SelectionIndex = 0;
                    OnPropertyChanged("SelectionIndex");
                    OnPropertyChanged("SelectedItem");
                    OnPropertyChanged("PrevItem");
                    OnPropertyChanged("NextItem");
                }

                PostProcessStrategies();

                if (doCollectionChanged)
                {

                    try
                    {
                        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }
                    catch (Exception)
                    {
                        
                    }

                }
            }
        }

        protected virtual void PreProcessStrategies()
        {}

        protected virtual void PostProcessStrategies()
        {}

        private Int32 GetIIndex(Int32 i)
        {
            return _ItemListe.IndexOf(_ViewableListe[i]);
        }

        public List<IFilterSchablone<T>> FilterStrategies
        {
            get
            {
                return _FilterStrategies;
            }
        }

        public List<ISortSchablone<T>> SortStrategies
        {
            get
            {
                return _SortStrategies;
            }
        }

        public Int32 SelectionIndex
        {
            get
            {
                return _SelectionIndex;
            }
            set
            {
                if (_SelectionIndex != value)
                {
                    if (value >= 0 && _ViewableListe.Count > value)
                    {
                        _SelectionIndex = value;
                        OnPropertyChanged("SelectionIndex");
                        OnPropertyChanged("SelectedItem");
                        OnPropertyChanged("PrevItem");
                        OnPropertyChanged("NextItem");
                    }
                }
            }
        }


        public T PrevItem
        {
            get
            {
                Int32 index = _SelectionIndex - 1;
                if(index >= 0 && index < _ViewableListe.Count)
                {
                    return _ViewableListe[index];
                }
                return null;
            }
        }

        public T NextItem
        {
            get
            {
                Int32 index = _SelectionIndex + 1;
                if (index >= 0 && index < _ViewableListe.Count)
                {
                    return _ViewableListe[index];
                }
                return null;
            }
        }


        public T SelectedItem
        {
            get
            {
                if(_ViewableListe.Count == 0 || (_SelectionIndex > _ViewableListe.Count -1))
                {
                    _SelectionIndex = -1;
                }
                if (_SelectionIndex != -1)
                {
                    return _ViewableListe[_SelectionIndex];
                }
                return null;
            }
            set
            {
                if (_ViewableListe.Contains(value))
                {
                    Int32 newIndex = _ViewableListe.IndexOf(value);
                    if (newIndex != _SelectionIndex || (_LastSelectedItem != null && _LastSelectedItem != value))
                    {
                        _SelectionIndex = newIndex;
                        _LastSelectedItem = value;
                        OnPropertyChanged("SelectionIndex");
                        OnPropertyChanged("SelectedItem");
                        OnPropertyChanged("PrevItem");
                        OnPropertyChanged("NextItem");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SelectNext()
        {
            if (SelectionIndex + 1 < _ViewableListe.Count)
            {
                ++SelectionIndex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SelectPrev()
        {
            if (SelectionIndex > 0)
            {
                --SelectionIndex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SelectFirst()
        {
            if (_ViewableListe.Count > 0)
            {
                SelectionIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SelectLast()
        {
            if (_ViewableListe.Count > 0)
            {
                SelectionIndex = _ViewableListe.Count - 1;
            }
        }

        

        #region INotifyCollectionChanged Member

        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if(CollectionChanged != null)
            {
                CollectionChanged(this, args);
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion

        #region IList<T> Member

        public int IndexOf(T item)
        {
            return _ViewableListe.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _ItemListe.Insert(GetIIndex(index), item);
            ProcessStrategies(true);
            if (_ViewableListe.Count == 1)
            {
                _SelectionIndex = 0;
            }
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void RemoveAt(int index)
        {
            _ItemListe.RemoveAt(GetIIndex(index));
            ProcessStrategies(true);
            if (_ViewableListe.Count == 0)
            {
                _SelectionIndex = -1;
            }
            else if (_ViewableListe.Count <= _SelectionIndex)
            {
                _SelectionIndex = 0;
            }
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || _ViewableListe.Count <= index)
                    return null;
                return _ViewableListe[index];
            }
            set
            {
                _ItemListe[GetIIndex(index)] = value;
                ProcessStrategies(true);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        #endregion

        public void AddRange(IEnumerable<T> itemCollection, bool doCollectionChanged)
        {

            foreach (var item in itemCollection)
            {
                _ItemListe.Add(item);
            }

            ProcessStrategies(doCollectionChanged);
            if (_ViewableListe.Count == 1)
            {
                _SelectionIndex = 0;
            }
            //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        #region ICollection<T> Member

        public void Add(T item)
        {
            _ItemListe.Add(item);
            ProcessStrategies(true);
            if (_ViewableListe.Count == 1)
            {
                _SelectionIndex = 0;
            }
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Clear()
        {
            _ItemListe.Clear();
            ProcessStrategies(false);
            _SelectionIndex = -1;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(T item)
        {
            return _ViewableListe.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _ViewableListe.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _ViewableListe.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            if (_ItemListe.Remove(item))
            {
                ProcessStrategies(true);
                if (_ViewableListe.Count == 0)
                {
                    _SelectionIndex = -1;
                }
                else if (_ViewableListe.Count <= _SelectionIndex)
                {
                    _SelectionIndex = 0;
                }
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                return true;
            }
            return false;
        }

        #endregion

        #region IEnumerable<T> Member

        public IEnumerator<T> GetEnumerator()
        {
            return _ViewableListe.GetEnumerator();
        }

        #endregion

        #region IEnumerable Member

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _ViewableListe.GetEnumerator();
        }

        #endregion

        #region INotifyPropertyChanged Member

        protected void OnPropertyChanged(String _name)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        //public event SelectedItemChangedHandler SelectedItemChanged;

        public bool HasItems
        {
            get
            {
                return _ViewableListe.Any();
            }
        }

        public void NotifyPropertychange(string info)
        {
            OnPropertyChanged(info);
        }
    }
}
