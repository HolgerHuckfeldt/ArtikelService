/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeug/Achs-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines PKW-Modells
 ************************************************************************************/

using System;
using System.Configuration;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;

namespace PV.DomainObjects.Fahrzeug
{
    [Serializable]
    [DataContract]
    public class Modell : IFinderObject, IEquatable<Modell>
    {
        #region Fields

        //[DataMember]
        //private string _IndexdatumStart = ConfigManager.Instance.GetSetting("IndexdatumBegin");
        //[DataMember]
        //private string _IndexdatumEnd = ConfigManager.Instance.GetSetting("IndexdatumEnd");

        private int _Id;
        private int _ModellId;
        private string _Bezeichnung;
        private int _HerstellerId;
        private int _Sortierung;
        private DateTime _BaujahrVon;
        private DateTime _BaujahrBis;

        #endregion

        #region FahrzeugModell-Member

        /// <summary>
        /// Liefert die ID des Modells in der Datenquelle
        /// </summary>
        [DataMember]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        /// <summary>
        /// Liefert die ID des Modells in der Datenquelle
        /// </summary>
        [DataMember]
        public int ModellId
        {
            get
            {
                return _ModellId;
            }
            set
            {
                _ModellId = value;
            }
        }


        /// <summary>
        /// Der Name es Modells
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get
            {
                return _Bezeichnung != null ? _Bezeichnung.Trim() : string.Empty;
            }
            set
            {
                _Bezeichnung = value;
            }
        }


        /// <summary>
        /// Liefert die ID des Herstellers(Parent) in der Datenquelle
        /// </summary>
        [DataMember]
        public int HerstellerId
        {
            get
            {
                return _HerstellerId;
            }
            set
            {
                _HerstellerId = value;
            }
        }


        /// <summary>
        /// Liefert die Sortierreihenfolge der initialen Anzeige der Modelle
        /// </summary>
        [DataMember]
        public int Sortierung
        {
            get
            {
                return _Sortierung;
            }
            set
            {
                _Sortierung = value;
            }
        }


        /// <summary>
        /// Liefert das Baujahr von wann das Model gebaut wurde
        /// </summary>
        [DataMember]
        public DateTime BaujahrVon
        {
            get
            {
                return _BaujahrVon;
            }
            set
            {
                _BaujahrVon = value;
            }
        }


        /// <summary>
        /// Liefert das Baujahr bis wann das Model gebaut wurde
        /// </summary>
        [DataMember]
        public DateTime BaujahrBis
        {
            get
            {
                return _BaujahrBis;
            }
            set
            {
                _BaujahrBis = value;
            }
        }

        #endregion

        #region IFinderObject Member

        /// <summary>
        /// Erforderlich für Testing!
        /// </summary>
        public string TestTag
        {
            get
            {
                return string.Format("{0}", Id);
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die erste Spalte in der Finderspalte
        /// </summary>
        public string Description
        {
            get
            {
                return Bezeichnung;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die zweite Spalte in der Finderspalte
        /// </summary>
        public string Description2
        {
            get
            {
                string bauvon = BaujahrVon.ToString( "MM.yyyy" ) != "01.1850"
                                   ? BaujahrVon.ToString( "MM.yy" )
                                   : string.Empty;
                string baubis = BaujahrBis.ToString( "MM.yyyy" ) != "01.2020"
                                    ? BaujahrBis.ToString( "MM.yy" )
                                    : string.Empty;
                if ( bauvon == string.Empty && baubis == string.Empty )
                    return "k.A.";
                return string.Format( "{0} - {1}", bauvon, baubis );
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die dritte Spalte in der Finderspalte
        /// </summary>
        public string Description3
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die vierte Spalte in der Finderspalte
        /// </summary>
        public string Description4
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die fünfte Spalte in der Finderspalte
        /// </summary>
        public string Description5
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die sechste Spalte in der Finderspalte
        /// </summary>
        public string Description6
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die siebente Spalte in der Finderspalte
        /// </summary>
        public string Description7
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die achte Spalte in der Finderspalte
        /// </summary>
        public string Description8
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die neunte Spalte in der Finderspalte
        /// </summary>
        public string Description9
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die zehnte Spalte in der Finderspalte
        /// </summary>
        public string Description10
        {
            get
            {
                return null;
            }
        }


        /// <summary>
        /// Liefert die ID des Parent
        /// </summary>
        public string ParentID
        {
            get
            {
                return HerstellerId.ToString();
            }
        }

        /// <summary>
        /// Liefert die ID des Objektes
        /// </summary>
        string IFinderObject.Id
        {
            get
            {
                return Id.ToString();
            }
        }

        /// <summary>
        /// Liefert die Tiefe des Objektes im Finder
        /// </summary>
        public int Tiefe
        {
            get
            {
                return 2;
            }
        }

        public bool IsNew
        {
            get;
            set;
        }

        #endregion

        #region IEquatable<FahrzeugModell> Member


        public bool Equals( Modell _other )
        {
            return Id == _other.Id;
        }

        public override bool Equals( object _obj )
        {
            Modell toCompare = _obj as Modell;
            if ( toCompare != null )
                return toCompare.Id == Id;
            return base.Equals( _obj );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        #endregion
    }
}
