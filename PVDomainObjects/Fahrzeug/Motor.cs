/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Motor-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Motors
 ************************************************************************************/

using System;
using System.Configuration;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Motors
    /// </summary>
    [Serializable]
    [DataContract]
    public class Motor
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
        /// Liefert und setzt den HerstellerNamen
        /// </summary>
        [DataMember]
        public string HerstellerBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Motorcode
        /// </summary>
        [DataMember]
        public string Motorcode
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Motornummer
        /// </summary>
        [DataMember]
        public int Motornummer 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Liefert  den komprimierten Motorcode
        /// </summary>
        public string CompressedMotorcode
        {
            get
            {
                if ( !string.IsNullOrEmpty( Motorcode ) )
                {
                    return new Regex( @"[^\w\d]" ).Replace( Motorcode, string.Empty );
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Liefert und setzt den Baubeginn
        /// </summary>
        [DataMember]
        public DateTime BaujahrVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Bauende
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
                if ( bauvon == string.Empty && baubis == string.Empty )
                    return "k.A.";
                return string.Format( "{0} - {1}", bauvon, baubis );
            }
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze der Leistung in KW
        /// </summary>
        [DataMember]
        public int LeistungKWVon
        {
            get;
            set;
        }

        private int _LeistungKWBis;

        /// <summary>
        /// Liefert und setzt die obere Grenze der Leistung in KW
        /// </summary>
        [DataMember]
        public int LeistungKWBis
        {
            get
            {
                return _LeistungKWBis != 0 ? _LeistungKWBis : LeistungKWVon;
            }
            set
            {
                _LeistungKWBis = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze der Leistung in PS
        /// </summary>
        [DataMember]
        public int LeistungPSVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die obere Grenze der Leistung in PS
        /// </summary>
        [DataMember]
        public int LeistungPSBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Umdrehungen der unteren Leistungsgrenze
        /// </summary>
        [DataMember]
        public int UmdrehungenLeistungVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Umdrehungen der oberen Leistungsgrenze
        /// </summary>
        [DataMember]
        public int UmdrehungenLeistungBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen String der Form "KW / PS" für die Untergrenze der Leistung an
        /// </summary>
        public string VonLeistungsstring
        {
            get
            {
                if ( LeistungKWVon != int.MaxValue && LeistungPSVon != int.MaxValue )
                    return string.Format( "{0} / {1}", LeistungKWVon, LeistungPSVon );
                if ( LeistungKWVon != int.MaxValue )
                    return LeistungKWVon.ToString();
                if ( LeistungPSVon != int.MaxValue )
                    return LeistungPSVon.ToString();
                return "k.A.";
            }
        }

        /// <summary>
        /// Liefert einen String der Form "KW / PS" für die Obergrenze der Leistung an
        /// </summary>
        public string BisLeistungsstring
        {
            get
            {
                if ( LeistungKWBis != int.MaxValue && LeistungPSBis != int.MaxValue )
                    return string.Format( "{0} / {1}", LeistungKWBis, LeistungPSBis );
                if ( LeistungKWBis != int.MaxValue )
                    return LeistungKWBis.ToString();
                if ( LeistungPSBis != int.MaxValue )
                    return LeistungPSBis.ToString();
                return "k.A.";
            }
        }

        /// <summary>
        /// Liefert einen String der Form "von - bis" für die Leistung in KW
        /// </summary>
        public string KWLeistungsstring
        {
            get
            {
                if ( LeistungKWVon != int.MaxValue && LeistungKWBis != int.MaxValue )
                    return string.Format( "{0} - {1}", LeistungKWVon, LeistungKWBis );
                if ( LeistungKWVon != int.MaxValue )
                    return LeistungKWVon.ToString();
                if ( LeistungKWBis != int.MaxValue )
                    return LeistungKWBis.ToString();
                return "k.A.";
            }
        }

        /// <summary>
        /// Liefert einen String der Form "von - bis" für die Leistung in PS
        /// </summary>
        public string PSLeistungsstring
        {
            get
            {
                if ( LeistungPSVon != int.MaxValue && LeistungPSBis != int.MaxValue )
                    return string.Format( "{0} - {1}", LeistungPSVon, LeistungPSBis );
                if ( LeistungPSVon != int.MaxValue )
                    return LeistungPSVon.ToString();
                if ( LeistungPSBis != int.MaxValue )
                    return LeistungPSBis.ToString();
                return "k.A.";
            }
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze des Drehmoment
        /// </summary>
        [DataMember]
        public int DrehmomentVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die obere Grenze des Drehmoment
        /// </summary>
        [DataMember]
        public int DrehmomentBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Umdrehungen der unteren DrehmomentGrenze
        /// </summary>
        [DataMember]
        public int UmdrehungenDrehmomentVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Umdrehungen der oberen Drehmomentgrenze
        /// </summary>
        [DataMember]
        public int UmdrehungenDrehmomentBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze des Hubraumes
        /// </summary>
        [DataMember]
        public int HubraumVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die obere Grenze des Hubraumes
        /// </summary>
        [DataMember]
        public int HubraumBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen String der Form "von - bis" für den Hubraum
        /// </summary>
        public string Hubraumstring
        {
            get
            {
                if ( HubraumVon != int.MaxValue && HubraumBis != int.MaxValue )
                    return string.Format( "{0} - {1}", HubraumVon, HubraumBis );
                if ( HubraumVon != int.MaxValue )
                    return HubraumVon.ToString();
                if ( HubraumBis != int.MaxValue )
                    return HubraumBis.ToString();
                return "k.A.";
            }
        }

        /// <summary>
        /// Liefert und setzt die Anzahl der Zylinder
        /// </summary>
        [DataMember]
        public int Zylinder
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Anzahl der Ventile
        /// </summary>
        [DataMember]
        public int Ventile
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die untere Grenze der Verdichtung
        /// </summary>
        [DataMember]
        public double VerdichtungVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die obere Grenze der Verdichtung
        /// </summary>
        [DataMember]
        public double VerdichtungBis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Größe der Bohrung
        /// </summary>
        [DataMember]
        public double Bohrung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Größe des Hubs
        /// </summary>
        [DataMember]
        public double Hub
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Anzahl der KurbelwellenLager
        /// </summary>
        [DataMember]
        public int KurbelwellenLager
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die MotorblockBauart
        /// </summary>
        [DataMember]
        public string MotorblockBauart
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Kraftstoff
        /// </summary>
        [DataMember]
        public string Kraftstoff
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Kraftstoffaufbereitung
        /// </summary>
        [DataMember]
        public string Kraftstoffaufbereitung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den ZylinderBauart
        /// </summary>
        [DataMember]
        public string ZylinderBauart
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die MotorSteuerung
        /// </summary>
        [DataMember]
        public string MotorSteuerung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Abgasnorm
        /// </summary>
        [DataMember]
        public string Abgasnorm
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Aufladung
        /// </summary>
        [DataMember]
        public string Aufladung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Ventilsteuerung
        /// </summary>
        [DataMember]
        public string Ventilsteuerung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Kühlung
        /// </summary>
        [DataMember]
        public string Kuehlung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die MotorArt
        /// </summary>
        [DataMember]
        public string MotorArt
        {
            get;
            set;
        }

        #endregion
    }
}
