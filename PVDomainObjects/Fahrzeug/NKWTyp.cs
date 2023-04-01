/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeug-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines PKW-Typs
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    ///  Kapselt die Informationen und Funktionen eines PKW-Typs
    /// </summary>
    [DataContract]
    [Serializable]
    public class NKWTyp : FahrzeugTyp
    {
        private IList<string> _HerstellerIDs = new List<string>();

        /// <summary>
        /// Liefert und setzt die FederArt in Form einer Liste von KeyValuePair<string, string> 
        /// wobei der Key die Achsen benennt und das Value die FederArt angibt
        /// </summary>
        [DataMember]
        public List<KeyValuePair<string, string>> FederArt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die AchsKonfiguration
        /// </summary>
        [DataMember]
        public string AchsKonfiguration { get; set; }

        /// <summary>
        /// Liefert und setzt die Tonnage
        /// </summary>
        [DataMember]
        public int Tonnage
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Radstände in Form einer Liste von KeyValuePair<string, string> 
        /// wobei der Key die Achsen benennt und das Value den Abstand angibt
        /// </summary>
        [DataMember]
        public List<KeyValuePair<string, string>> Radstaende
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Radstände als String
        /// </summary>
        [DataMember]
        public string AchspositionRadstand
        {
            get
            {
                string back = string.Empty;
                if (Radstaende != null && Radstaende.Count > 0)
                {
                    foreach (KeyValuePair<string, string> radstaende in Radstaende)
                    {
                        back = string.Format("{0}\n{1} / {2}", back, radstaende.Key, radstaende.Value);
                    }
                    return back == string.Empty ? back : back.Substring(1, back.Length - 1);
                }
                return string.Empty;
            }
            set
            {
            }
        }

        /// <summary>
        /// Liefert und setzt die Untergrenze der Leistung in KW
        /// </summary>
        [DataMember]
        public int KWVon
        {
            get;
            set;
        }

        [DataMember]
        private int _KWBis;

        public NKWTyp()
        {
            AchsKonfiguration = string.Empty;
        }

        /// <summary>
        /// Liefert und setzt die Obergrenze der Leistung in KW
        /// </summary>
        [DataMember]
        public int KWBis
        {
            get
            {
                return _KWBis != 0 ? _KWBis : KWVon;
            }
            set
            {
                _KWBis = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Untergrenze der Leistung in PS
        /// </summary>
        [DataMember]
        public int PSVon
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Obergrenze der Leistung in KW
        /// </summary>
        [DataMember]
        public int PSBis
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
                if( KWVon != int.MaxValue && PSVon != int.MaxValue )
                    return string.Format( "{0} / {1}", KWVon, PSVon );
                if( KWVon != int.MaxValue )
                    return string.Format( "{0} / k.A", KWVon );
                if( PSVon != int.MaxValue )
                    return string.Format( "k.A. / {0}", PSVon );
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
                if( KWBis != int.MaxValue && PSBis != int.MaxValue )
                    return string.Format( "{0} / {1}", KWBis, PSBis );
                if( KWBis != int.MaxValue )
                    return string.Format( "{0} / k.A", KWBis );
                if( PSBis != int.MaxValue )
                    return string.Format( "k.A. / {0}", PSBis );
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
                if( KWVon != int.MaxValue && KWBis != int.MaxValue )
                    return string.Format( "{0} - {1}", KWVon, KWBis );
                if( KWVon != int.MaxValue )
                    return KWVon.ToString();
                if( KWBis != int.MaxValue )
                    return KWBis.ToString();
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
                if( PSVon != int.MaxValue && PSBis != int.MaxValue )
                    return string.Format( "{0} - {1}", PSVon, PSBis );
                if( PSVon != int.MaxValue )
                    return PSVon.ToString();
                if( PSBis != int.MaxValue )
                    return PSBis.ToString();
                return "k.A.";
            }
        }

        /// <summary>
        /// Liefert und setzt die Liste der HerstellerIDs
        /// </summary>
        [DataMember]
        public IList<string> HerstellerIDs
        {
            get
            {
                return _HerstellerIDs;
            }
            set
            {
                _HerstellerIDs = value;
            }
        }

        /// <summary>
        /// Liefert die HerstellerIDs als kommaseparierten String
        /// </summary>
        public string HerstellerIDString
        {
            get
            {
                string back = string.Empty;
                foreach( string id in HerstellerIDs )
                {
                    back = string.Format( "{0}, {1}", back, id.Trim() );
                }
                return string.IsNullOrEmpty( back ) ? back : back.Substring( 2 );
            }
        }
    }
}
