using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class ArtikelBestandsInfo : INotifyPropertyChanged
    {
        #region events
        public virtual event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertiesChanged()
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs("Typ"));
            PropertyChanged(this, new PropertyChangedEventArgs("DefaultInfo"));
            PropertyChanged(this, new PropertyChangedEventArgs("Titel"));
            PropertyChanged(this, new PropertyChangedEventArgs("InfoListe"));

            DefaultInfo.NotifyPropertiesChanged();
            foreach (ArtikelBestandsInfoItem item in InfoListe) item.NotifyPropertiesChanged();
        }
        #endregion

        //public string IconUri { get; set; }
        public ArtikelBestandsInfoSourceType Typ { get; set; }
        public ArtikelBestandsInfoItem DefaultInfo { get; set; }
        public string Titel { get; set; }
        public List<ArtikelBestandsInfoItem> InfoListe { get; set; }

        public ArtikelBestandsInfo()
        {
            //IconUri = string.Empty;
            Typ = ArtikelBestandsInfoSourceType.Unknown;
            DefaultInfo = new ArtikelBestandsInfoItem();
            Titel = string.Empty;
            InfoListe = new List<ArtikelBestandsInfoItem>();
        }

        public void SetDefaultInfo(string key, string value)
        {
            DefaultInfo = new ArtikelBestandsInfoItem { Key = key, Value = value };
        }
        public void AddInfo(string key, string value)
        {
            InfoListe.Add(new ArtikelBestandsInfoItem { Key = key, Value = value });
        }
    }

    public class ArtikelBestandsInfoItem : INotifyPropertyChanged
    {
        #region events
        public virtual event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertiesChanged()
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs("Key"));
            PropertyChanged(this, new PropertyChangedEventArgs("Value"));
        }
        #endregion

        public string Key { get; set; }
        public string Value { get; set; }
    }

    public enum ArtikelBestandsInfoSourceType{
        ProfiCar,
        PvManager,
        Unknown
    }
}
