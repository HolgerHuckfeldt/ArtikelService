using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using PV.DomainObjects.Fahrzeug;


namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class Gebrauchsmuster : INotifyPropertyChanged
    {
        private IList<PKWTyp> _PKWListe = new List<PKWTyp>();
        private IList<NKWTyp> _NKWListe = new List<NKWTyp>();
        private IList<Achse> _AchsenListe = new List<Achse>();
        private IList<Motor> _MotorenListe = new List<Motor>();

        [DataMember]
        public IList<PKWTyp> PKWListe
        {
            get
            {
                return _PKWListe.
                    OrderBy( pkw => pkw.HerstellerBezeichnung ).
                    ThenBy( pkw => pkw.ModellBezeichnung ).
                    ToList();
            }
            set
            {
                _PKWListe = value;
                OnPropertyChanged( "PKWListe" );
            }
        }



        [DataMember]
        public IList<NKWTyp> NKWListe
        {
            get
            {
                return
                    _NKWListe.
                    OrderBy( nkw => nkw.HerstellerBezeichnung )
                    .ThenBy( nkw => nkw.ModellBezeichnung )
                    .ToList();
            }
            set
            {
                _NKWListe = value;
                OnPropertyChanged( "NKWListe" );
            }
        }

        [DataMember]
        public IList<Achse> AchsenListe
        {
            get
            {
                return
                    _AchsenListe.
                    OrderBy( achse => achse.HerstellerBezeichnung ).
                    ThenBy( achse => achse.Bezeichnung ).
                    ToList();
            }
            set
            {
                _AchsenListe = value;
                OnPropertyChanged( "AchsenListe" );
            }
        }

        [DataMember]
        public IList<Motor> MotorenListe
        {
            get
            {
                return
                    _MotorenListe.
                    OrderBy( motor => motor.HerstellerBezeichnung ).
                    ThenBy( motor => motor.Bezeichnung ).
                    ToList();
            }
            set
            {
                _MotorenListe = value;
                OnPropertyChanged( "MotorenListe" );
            }
        }



        #region INotifyPropertyChanged Member

        private void OnPropertyChanged( String _name )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( _name ) );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
