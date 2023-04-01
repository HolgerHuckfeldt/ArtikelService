/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeug-Identifikation   
 * Funktionen:  Oberklasse für PKW und NKW Typen
 ************************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    /// Oberklasse für PKW und NKW Typen
    /// </summary>
    [DataContract]
    [KnownType( typeof( PKWTyp ) )]
    [KnownType( typeof( NKWTyp ) )]

    [Serializable]
    public class FahrzeugTyp : IEquatable<FahrzeugTyp>
    {
        #region Fields

        [DataMember]
        private string _IndexdatumEnd = ConfigurationManager.AppSettings[ "IndexdatumEnd"];
        [DataMember]
        private string _IndexdatumStart = ConfigurationManager.AppSettings[ "IndexdatumBegin" ];
        private string _Bezeichnung = string.Empty;
        private string _ModellBezeichnung = string.Empty;
        private string _HerstellerBezeichnung = string.Empty;
        private string _MotorartBezeichnung = string.Empty;
        private string _KraftstoffArtBezeichnung = string.Empty;
        private IList<String> _Motorcodes;
        private string _AufbauArtBezeichnung = string.Empty;
        private IList<int> _Spannung;
        private int _id;
        private int _VehicleId;

        #endregion

        #region Properties

        /// <summary>
        /// Liefert uns setzt die ID in der Datenquelle
        /// </summary>
        [DataMember]
        public int Id
        {
            get
            {
                // 02.08.2012 Holger / Rudi
                // PIMS1: In der Id stand die KTypeNr (TecDoc Nr)
                // PIMS2: In Id steht die Datenbank-ID, benötigt wird aber die KTypeNr, damit Arbeitswerte, Technik und Wartung funktionieren
                //        deswegen liefern wir hier die KTypeNr zurück

                // 02.08.2012 Andi
                // Bitte lasst es auf _id. Ich werde die Fahrzeuge im Hybrid mit den Ktypnummern füttern!


                //if (KTypeNr != 0)
                //    return KTypeNr;
                //else
                    return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die VehicleId in der Datenquelle
        /// </summary>
        [DataMember]
        public int VehicleId
        {
            get
            {
                return _VehicleId;
            }
            set
            {
                _VehicleId = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt den Namen
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get
            {
                return _Bezeichnung;
            }
            set
            {
                _Bezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt den Modellname
        /// </summary>
        [DataMember]
        public string ModellBezeichnung
        {
            get
            {
                return _ModellBezeichnung;
            }
            set
            {
                _ModellBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die ModellId
        /// </summary>
        [DataMember]
        public int ModellId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt den Herstellername
        /// </summary>
        [DataMember]
        public string HerstellerBezeichnung
        {
            get
            {
                return _HerstellerBezeichnung;
            }
            set
            {
                _HerstellerBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die HerstellerId
        /// </summary>
        [DataMember]
        public int HerstellerId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt die KTypeNr in der Datenquelle
        /// </summary>
        [DataMember]
        public int KTypeNr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt die Sortierreihenfolge
        /// </summary>
        [DataMember]
        public int Sortierung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt das Jahr ab/seit wann der Typ gebaut wurde/wird
        /// </summary>
        [DataMember]
        public DateTime BaujahrVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt das Jahr bis wann der Typ gebaut wurde
        /// </summary>
        [DataMember]
        public DateTime BaujahrBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen String der Form "BaujahrVon - BaujahrBis" im Format "MM.YY - MM.YY"
        /// </summary>
        public string Bauspanne
        {
            get
            {
                string bauvon = BaujahrVon.ToString( "MM.yyyy" ) != "01.1850"
                                    ? BaujahrVon.ToString( "MM.yy" )
                                    : string.Empty;
                string baubis = BaujahrBis.ToString( "MM.yyyy" ) != "01.2020"
                                    ? BaujahrBis.ToString( "MM.yy" )
                                    : string.Empty;
                if( bauvon == string.Empty && baubis == string.Empty )
                    return "k.A.";
                return string.Format( "{0} - {1}", bauvon, baubis );
            }
            // ReSharper disable ValueParameterNotUsed
            // necessary for WCF
            set
            // ReSharper restore ValueParameterNotUsed
            {
            }
        }

        /// <summary>
        /// Liefert uns setzt den Hubraum (technisch)
        /// </summary>
        [DataMember]
        public int CcmTechnisch
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt die Spannungen
        /// </summary>
        [DataMember]
        public IList<int> Spannung
        {
            get
            {
                if( _Spannung == null )
                {
                    _Spannung = new List<int>();
                }
                return _Spannung;
            }
            set
            {
                _Spannung = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die Bezeichnung der Kraftstoffart
        /// </summary>
        [DataMember]
        public string KraftstoffArtBezeichnung
        {
            get
            {
                return _KraftstoffArtBezeichnung;
            }
            set
            {
                _KraftstoffArtBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die Bezeichnung des Motors
        /// </summary>
        [DataMember]
        public string MotorartBezeichnung
        {
            get
            {
                return _MotorartBezeichnung;
            }
            set
            {
                _MotorartBezeichnung = value;
            }
        }

        [DataMember]
        public List<MotorInfo> MotorInfos
        {
            get; set;
        }


        /// <summary>
        /// Liefert und setzt die Liste der Motorcodes
        /// </summary>
        [DataMember]
        public IList<string> Motorcodes
        {
            get
            {
                if( _Motorcodes == null )
                {
                    _Motorcodes = new List<string>();
                }
                return _Motorcodes;
            }
            set
            {
                _Motorcodes = value;
            }
        }

        /// <summary>
        /// Liefert die Liste der Motorcodes als umbruchsepariert String
        /// </summary>
        public string MotorcodeString
        {
            get
            {
                String back = String.Empty;
                foreach( String mc in Motorcodes.OrderBy( s => s ).ToList() )
                {
                    if( !string.IsNullOrEmpty( mc ) )
                        back = string.Format( "{0}\n{1}", back, mc );
                }
                return string.IsNullOrEmpty( back ) ? back : back.Substring( 1 );
            }
        }

        /// <summary>
        /// Liefert die Liste der Motorcodes als kommaseparierten String fuer RepDoc
        /// </summary>
        public string RepDocMotorcodeString
        {
            get
            {
                String back = String.Empty;
                foreach (String mc in Motorcodes.OrderBy(s => s).ToList())
                {
                    if (!string.IsNullOrEmpty(mc))
                        back = string.Format("{0},{1}", back, mc);
                }
                return string.IsNullOrEmpty(back) ? back : back.Substring(1);
            }
        }

        /// <summary>
        /// Liefert uns setzt die Bezeichnung der Aufbauart
        /// </summary>
        [DataMember]
        public string AufbauArtBezeichnung
        {
            get
            {
                if (string.IsNullOrEmpty(_AufbauArtBezeichnung))
                {
                    return string.Empty;
                }

                return _AufbauArtBezeichnung;
            }
            set
            {
                _AufbauArtBezeichnung = value;

                if (string.IsNullOrEmpty(_AufbauArtBezeichnung))
                {
                    _AufbauArtBezeichnung = string.Empty;
                }
            }
        }

        /// <summary>
        /// Liefert die um alle nicht alfanumerischen Zeichen bereinigten Motorcodes
        /// </summary>
        [DataMember]
        public string KompressedMotorcodes
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// Liefert die Stringrepräsentation
        /// </summary>
        /// <returns>Ein String</returns>
        public override string ToString()
        {
            return Bezeichnung;
        }

        #region IEquatable<FahrzeugTyp> Member


        public bool Equals( FahrzeugTyp other )
        {
            return Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            FahrzeugTyp toCompare = obj as FahrzeugTyp;
            return toCompare != null ? toCompare.Id == Id : base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
