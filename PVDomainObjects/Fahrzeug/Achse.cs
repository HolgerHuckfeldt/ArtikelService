/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Achs-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen einer Achse
 ************************************************************************************/

using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer Achse
    /// </summary>
    [Serializable]
    [DataContract]
    public class Achse : IEquatable<Achse>
    {
        #region Properties

        /// <summary>
        /// Liefert und setzt die ID in der Datenquelle
        /// </summary>
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert uns setzt die VehicleId in der Datenquelle
        /// </summary>
        [DataMember]
        public int VehicleId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung des Herstellers
        /// </summary>
        [DataMember]
        public string HerstellerBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die ID des Herstellers
        /// </summary>
        [DataMember]
        public int HerstellerId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung des Modells/der Baureihe
        /// </summary>
        [DataMember]
        public string ModellBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die ID des Modells/der Baureihe
        /// </summary>
        [DataMember]
        public int ModellId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung der Achse selbst
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Achsnummer der Achse selbst
        /// </summary>
        [DataMember]
        public int Achsnummer { get; set; }

        /// <summary>
        /// Liefert und setzt die Bezeichnung der Achse selbst
        /// </summary>
        public IList<string> Bremsgroessen
        {
            get
            {
                return ( from pair in BremsgroesseBezeichnung
                         select pair.Key ).ToList();
            }
        }

        /// <summary>
        /// Liefert die Liste der Bremsgroessen als Kommaseparierten String
        /// </summary>
        public string BremsgroessenString
        {
            get
            {
                String back = String.Empty;
                foreach( KeyValuePair<string, string> pair in BremsgroesseBezeichnung )
                {
                    if( string.IsNullOrEmpty( pair.Key ) )
                        back = string.Format( "{0}\n{1}", back, pair.Value );
                    else if( string.IsNullOrEmpty( pair.Value ) )
                        back = string.Format( "{0}\n{1}", back, pair.Key );
                    else
                        back = string.Format( "{0}\n{1} - {2}", back, pair.Key, pair.Value );
                }
                return string.IsNullOrEmpty( back ) ? back : back.Substring( 1 );
            }
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze der Achslast
        /// </summary>
        [DataMember]
        public int AchslastVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die obere Grenze der Achslast
        /// </summary>
        [DataMember]
        public int AchslastBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze der Achslast als String
        /// </summary
        public string AchslastVonString
        {
            get
            {
                return AchslastVon == int.MinValue ? "k.A." : AchslastVon.ToString();
            }
        }

        /// <summary>
        /// Liefert und setzt die obere Grenze der Achslast als String
        /// </summary>
        public string AchslastBisString
        {
            get
            {
                return AchslastBis == int.MaxValue ? "k.A." : AchslastBis.ToString();
            }
        }

        /// <summary>
        /// Liefert und setzt die AchsArt
        /// </summary>
        [DataMember]
        public string AchsArt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen String der zulässigen Achslast
        /// </summary>
        public string AchsLastString
        {
            get
            {
                string min = AchslastVon != int.MinValue ? AchslastVon.ToString() : String.Empty;
                string max = AchslastBis != int.MaxValue ? AchslastBis.ToString() : string.Empty;
                return !string.IsNullOrEmpty( min ) || !string.IsNullOrEmpty( max )
                           ? string.Format( "{0} - {1}", min, max )
                           : "k.A.";
            }
        }

        /// <summary>
        /// Liefert und setzt die AchsAusfuehrung
        /// </summary>
        [DataMember]
        public string AchsAusfuehrung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Art des AchsKörpers
        /// </summary>
        [DataMember]
        public string AchsKoerper
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Art der Bremsausführung
        /// </summary>
        [DataMember]
        public string BremsAusfuehrung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Beginn der Bauzeit
        /// </summary>
        [DataMember]
        public DateTime BaujahrVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Ende der Bauzeit
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
                return bauvon == string.Empty && baubis == string.Empty
                           ? "k.A."
                           : string.Format( "{0} - {1}", bauvon, baubis );
            }
        }

        /// <summary>
        /// Liefert und setzt die Radbefestigung
        /// </summary>
        [DataMember]
        public string Radbefestigung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Spurweite
        /// </summary>
        [DataMember]
        public int Spurweite
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Nabensystem
        /// </summary>
        [DataMember]
        public string Nabensystem
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bremsgröße und Bezeichnung in Form einer Liste von KeyValuePair<string, string> 
        /// wobei der Key die Bremsgröße benennt und das Value die Bezeichnung angibt
        /// </summary>
        [DataMember]
        public List<KeyValuePair<string, string>> BremsgroesseBezeichnung
        {
            get;
            set;
        }
        #endregion

        #region IEquatable<Achse> Member

        public bool Equals( Achse other )
        {
            return Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            Achse toCompare = obj as Achse;
            if( toCompare != null )
                return toCompare.Id == Id;
            return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
