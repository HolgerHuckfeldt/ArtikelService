using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace PV.DomainObjects.Common
{
    [Serializable]
    public class TemotExplosion : INotifyPropertyChanged
    {
        private String _uri = string.Empty;
  
        private Boolean _Loaded;
        private List<TemotStrip> _Strips;

        public TemotExplosion(String uri)
        {
            _uri = uri;
        }

        public String URI { get { return _uri; } }


        public Boolean Loaded
        {
            get
            {
                return _Loaded;
            }
            set
            {
                _Loaded = value;
                OnPropertyChanged("Loaded");
            }
        }

        public List<String> Artikelnummern
        {
            get
            {
                List<String> n = new List<String>();
                if(_Strips != null)
                {
                    foreach (TemotStrip s in _Strips)
                    {
                        if (s.Artikelnummern != null)
                        {
                            n.AddRange(s.Artikelnummern);
                        }
                    }
                }
                return n;
            }
        }


        public List<TemotStrip> Strips
        {
            get
            {
                return _Strips;
            }
            set
            {
                _Strips = value;
                OnPropertyChanged("Artikelnummern");
            }
        }


        #region INotifyPropertyChanged Member

        private void OnPropertyChanged(String property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
