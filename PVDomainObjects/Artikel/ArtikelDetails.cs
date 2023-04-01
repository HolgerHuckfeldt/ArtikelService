using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using PV.DomainObjects.Arbeitswerte;
using PV.Utilities.Misc;


namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class ArtikelDetails : INotifyPropertyChanged
    {
        void OnPropertyChanged( String _property )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( _property ) );
            }
        }
        PVItemListe<Artikel> _HerstellerZubehoerListe;
        PVItemListe<Artikel> _VerwandteArtikel;
        private bool _HatVerwandteArtikel;
        PVItemListe<Artikel> _StueckListePV;
        PVItemListe<Artikel> _StueckListeHersteller;
        //List<ArtikelDokument> _Dokumente;
        List<OEHersteller> _OENummern;
        List<String> _Gebrauchsnummern;
        List<String> _EANummern;
        ErsetzteArtikelnummer _ErsetztArtikelnummer;
        Gebrauchsmuster _VerwendetIn;
        IList<Arbeitsprozess> _VerwandteArbeitswerte;
        private List<KeyValuePair<String, String>> _Logistik;


        public Artikel ArtikelRef
        {
            get;
            set;
        }

        public List<KeyValuePair<String, String>> Logistik
        {
            get
            {
                return _Logistik;
            }
            set
            {
                _Logistik = value;
                OnPropertyChanged( "Logistik" );
            }
        }

        public Gebrauchsmuster VerwendetIn
        {
            get
            {
                return _VerwendetIn;
            }
            set
            {
                _VerwendetIn = value;
                OnPropertyChanged( "VerwendetIn" );
            }
        }

        public IList<Arbeitsprozess> VerwandteArbeitswerte
        {
            get
            {
                return _VerwandteArbeitswerte;
            }
            set
            {
                _VerwandteArbeitswerte = value;
                OnPropertyChanged( "VerwandteArbeitswerte" );
            }
        }

        public List<OEHersteller> OENummern
        {
            get
            {
                return _OENummern;
            }
            set
            {
                _OENummern = value;
                OnPropertyChanged( "OENummern" );
                OnPropertyChanged( "HatNummern" );
            }
        }


        public List<String> Gebrauchsnummern
        {
            get
            {
                return _Gebrauchsnummern;
            }
            set
            {
                _Gebrauchsnummern = value;
                OnPropertyChanged( "Gebrauchsnummern" );
                OnPropertyChanged( "HatNummern" );
            }
        }


        public List<String> EANummern //todo: Nummer für die Visibility zusammenfassen
        {
            get
            {
                return _EANummern;
            }
            set
            {
                _EANummern = value;
                OnPropertyChanged( "EANummern" );
                OnPropertyChanged( "HatNummern" );
            }
        }


        public ErsetzteArtikelnummer ErsetzteArtikelnummern
        {
            get
            {
                return _ErsetztArtikelnummer;
            }
            set
            {
                _ErsetztArtikelnummer = value;
                OnPropertyChanged( "ErsetzteArtikelnummern" );
                OnPropertyChanged( "HatNummern" );
            }
        }

        public bool HatNummern
        {
            get
            {
                return (ErsetzteArtikelnummern != null || EANummern != null || Gebrauchsnummern != null || OENummern != null) ? true : false;
            }
        }


        public List<ArtikelDokument> Dokumente
        {
            get
            {
                return ArtikelRef.Dokumente.ToList();
            }
            //set
            //{
            //    _Dokumente = value;
            //    OnPropertyChanged( "Dokumente" );
            //    OnPropertyChanged( "Einbauanleitungen" );
            //    OnPropertyChanged( "Sicherheitsdatenblaetter" );
            //    OnPropertyChanged( "Sonstiges" );
            //}
        }

        public List<ArtikelDokument> Einbauanleitungen
        {
            get
            {
                //if ( Dokumente != null )
                //if ( ArtikelRef.Dokumente != null )
                return (from t in ArtikelRef.Dokumente.ToList() where t.Typ == DokumentenTyp.Einbauanleitung select t).ToList();


                //return new List<ArtikelDokument>();
            }
        }

        public List<ArtikelDokument> Sicherheitsdatenblaetter
        {
            get
            {
                //if ( ArtikelRef.Dokumente != null )
                return (from t in ArtikelRef.Dokumente.ToList() where t.Typ == DokumentenTyp.Sicherheitsdatenblatt select t).ToList();

                //return new List<ArtikelDokument>();
            }
        }

        public List<ArtikelDokument> Sonstiges
        {
            get
            {
                //if ( Dokumente != null )
                return (from t in ArtikelRef.Dokumente.ToList() where t.Typ == DokumentenTyp.Sonstiges select t).ToList();

                //return new List<ArtikelDokument>();
            }
        }

        public List<ArtikelLink> EinbauanleitungenLinks
        {
            get
            {
                if (ArtikelRef.Links != null)
                    return (from t in ArtikelRef.Links.ToList() where t.Typ == DokumentenTyp.Einbauanleitung select t).ToList();

                return new List<ArtikelLink>();
            }
        }

        public List<ArtikelLink> SicherheitsdatenblaetterLinks
        {
            get
            {
                if (ArtikelRef.Links != null)
                    return (from t in ArtikelRef.Links.ToList() where t.Typ == DokumentenTyp.Sicherheitsdatenblatt select t).ToList();

                return new List<ArtikelLink>();
            }
        }

        public List<ArtikelLink> SonstigesLinks
        {
            get
            {
                if (ArtikelRef.Links != null)
                    return (from t in ArtikelRef.Links.ToList() where t.Typ == DokumentenTyp.Sonstiges select t).ToList();

                return new List<ArtikelLink>();
            }
        }


        public PVItemListe<Artikel> HerstellerZubehoerListe
        {
            get
            {
                return _HerstellerZubehoerListe;
            }
            set
            {
                _HerstellerZubehoerListe = value;
                OnPropertyChanged( "HatVerwandteArtikel" );
                OnPropertyChanged( "HerstellerZubehoerListe" );

            }
        }

        public PVItemListe<Artikel> VerwandteArtikel
        {
            get
            {
                return _VerwandteArtikel;
            }
            set
            {
                _VerwandteArtikel = value;
                OnPropertyChanged( "HatVerwandteArtikel" );
                OnPropertyChanged( "VerwandteArtikel" );
                OnPropertyChanged( "MussArtikelListe" );
                OnPropertyChanged( "KannArtikelListe" );
                OnPropertyChanged( "SollArtikelListe" );

            }
        }

        public bool HatVerwandteArtikel
        {
            get
            {
                if ( (_VerwandteArtikel != null && _VerwandteArtikel.Count > 0) || (_HerstellerZubehoerListe != null && _HerstellerZubehoerListe.Count > 0) )
                {
                    _HatVerwandteArtikel = true;
                }
                else
                {
                    _HatVerwandteArtikel = false;
                }

                return _HatVerwandteArtikel;
            }
        }

        public PVItemListe<Artikel> MussArtikelListe
        {
            get
            {
                if ( VerwandteArtikel == null || (from art in VerwandteArtikel where art.GetType() == typeof( VerwandterArtikel ) &&
                                                      ((VerwandterArtikel)art).Verwandschaft == ArtikelVerwandtschaft.Muss select art).Count() == 0 )
                    return null;

                List<Artikel> tempArtListe =
                            (from art in VerwandteArtikel
                             where
                                art.GetType() == typeof( VerwandterArtikel ) &&
                                        ((VerwandterArtikel)art).Verwandschaft == ArtikelVerwandtschaft.Muss
                             select art).ToList();
                PVItemListe<Artikel> resultList = new PVItemListe<Artikel>();
                resultList.AddRange(tempArtListe, true);
                return resultList;
            }
        }

        public PVItemListe<Artikel> KannArtikelListe
        {
            get
            {
                if ( VerwandteArtikel == null || (from art in VerwandteArtikel where art.GetType() == typeof( VerwandterArtikel ) &&
                                                      ((VerwandterArtikel)art).Verwandschaft == ArtikelVerwandtschaft.Kann select art).Count() == 0 )
                    return null;

                List<Artikel> tempArtListe =
                            (from art in VerwandteArtikel
                             where
                                 art.GetType() == typeof( VerwandterArtikel ) &&
                                         ((VerwandterArtikel)art).Verwandschaft == ArtikelVerwandtschaft.Kann
                             select art).ToList();
                PVItemListe<Artikel> resultList = new PVItemListe<Artikel>();
                resultList.AddRange(tempArtListe, true);
                return resultList;
            }
        }

        public PVItemListe<Artikel> SollArtikelListe
        {
            get
            {
                if ( VerwandteArtikel == null || (from art in VerwandteArtikel where art.GetType() == typeof( VerwandterArtikel )
                                                      && ((VerwandterArtikel)art).Verwandschaft == ArtikelVerwandtschaft.Soll select art).Count() == 0 )
                    return null;

                List<Artikel> tempArtListe =
                            (from art in VerwandteArtikel
                             where
                                 art.GetType() == typeof( VerwandterArtikel ) &&
                                         ((VerwandterArtikel)art).Verwandschaft == ArtikelVerwandtschaft.Soll
                             select art).ToList();
                PVItemListe<Artikel> resultList = new PVItemListe<Artikel>();
                resultList.AddRange(tempArtListe, true);
                return resultList;
            }
        }

        public PVItemListe<Artikel> StueckListePV
        {
            get
            {
                return _StueckListePV;
            }
            set
            {
                _StueckListePV = value;

                if (_StueckListePV != null && _StueckListePV.Any())
                {
                    foreach (var art in _StueckListePV)
                    {
                        art.IsStuecklistenartikelInArtikelDetails = true;
                    }
                }

                OnPropertyChanged( "StueckListePV" );
            }
        }

        public PVItemListe<Artikel> StueckListeHersteller
        {
            get
            {
                return _StueckListeHersteller;
            }
            set
            {
                _StueckListeHersteller = value;

                if (_StueckListeHersteller != null && _StueckListeHersteller.Any())
                {
                    foreach (var art in _StueckListeHersteller)
                    {
                        art.IsStuecklistenartikelInArtikelDetails = true;
                    }
                }

                OnPropertyChanged( "StueckListeHersteller" );
            }
        }



        #region INotifyPropertyChanged Member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
