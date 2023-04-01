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
    [KnownType( typeof( FahrzeugTyp ) )]
    [DataContract]
    [Serializable]
    public class PKWTyp : FahrzeugTyp
    {

        #region Fields

        private string _KraftstoffaufbereitungBezeichnung = string.Empty;
        private string _AntriebsartBezeichnung = string.Empty;
        private string _BremsArtBezeichnung = string.Empty;
        private string _BremsSystemBezeichnung = string.Empty;
        private string _KatalysatorArtBezeichnung = string.Empty;
        private string _GetriebeArtBezeichnung = string.Empty;
        private PRInfos _prInfios = null;
        private List<string> _KBANummern;

        #endregion

        #region Properties


        public PRInfos PrInfos
        {
            get
            {
                return _prInfios;
            }
            set
            {
                _prInfios = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die KBANummer
        /// </summary>
        [DataMember]
        public List<string> KBANummern
        {
            get
            {
                if( _KBANummern == null )
                    _KBANummern = new List<string>();
                return _KBANummern;
            }
            set
            {
                _KBANummern = value;
            }
        }

        /// <summary>
        /// Liefert uns setzt die Motorleistung in KW
        /// </summary>
        [DataMember]
        public int KW
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert uns setzt die Motorleistung in PS
        /// </summary>
        [DataMember]
        public int PS
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert einen String der Form "KW / PS"
        /// </summary>
        [DataMember]
        public string Leistungsstring
        {
            get
            {
                return string.Format( "{0} / {1}", KW != int.MaxValue ? KW.ToString() : "-", PS != int.MaxValue ? PS.ToString() : "-" );
            }
            // ReSharper disable ValueParameterNotUsed
            // necessarry for WCF
            set
            // ReSharper restore ValueParameterNotUsed
            {
            }
        }

        /// <summary>
        /// Liefert uns setzt die Anzahl der Zylinder
        /// </summary>
        [DataMember]
        public int Zylinder
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert uns setzt die Anzahl der Türen
        /// </summary>
        [DataMember]
        public int Tueren
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert uns setzt den Tankinhalt
        /// </summary>
        [DataMember]
        public int TankInhalt
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert uns setzt die Information ob ABS vorhanden ist
        /// </summary>
        [DataMember]
        public string ABS
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert uns setzt die Information ob ASR vorhanden ist
        /// </summary>
        [DataMember]
        public string ASR
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert uns setzt die Bezeichnung der Kraftstoffaufbereitung
        /// </summary>
        [DataMember]
        public string KraftstoffaufbereitungBezeichnung
        {
            get
            {
                return _KraftstoffaufbereitungBezeichnung;
            }
            set
            {
                _KraftstoffaufbereitungBezeichnung = value;
            }
        }


        /// <summary>
        /// Liefert uns setzt die Bezeichnung der Antriebsart
        /// </summary>
        [DataMember]
        public string AntriebsartBezeichnung
        {
            get
            {
                return _AntriebsartBezeichnung;
            }
            set
            {
                _AntriebsartBezeichnung = value;
            }
        }


        /// <summary>
        /// Liefert uns setzt die Bezeichnung der Bremsart
        /// </summary>
        [DataMember]
        public string BremsArtBezeichnung
        {
            get
            {
                return _BremsArtBezeichnung;
            }
            set
            {
                _BremsArtBezeichnung = value;
            }
        }


        /// <summary>
        /// Liefert uns setzt die Bezeichnung des Bremssystems
        /// </summary>
        [DataMember]
        public string BremsSystemBezeichnung
        {
            get
            {
                return _BremsSystemBezeichnung;
            }
            set
            {
                _BremsSystemBezeichnung = value;
            }
        }


        /// <summary>
        /// Liefert uns setzt die Anzahl der Ventile
        /// </summary>
        [DataMember]
        public int Ventile
        {
            get;
            set;
        }




        /// <summary>
        /// Liefert uns setzt die Bezeichnung des Katalysators
        /// </summary>
        [DataMember]
        public string KatalysatorArtBezeichnung
        {
            get
            {
                return _KatalysatorArtBezeichnung;
            }
            set
            {
                _KatalysatorArtBezeichnung = value;
            }
        }


        /// <summary>
        /// Liefert uns setzt die Bezeichnung der Getriebeart
        /// </summary>
        [DataMember]
        public string GetriebeArtBezeichnung
        {
            get
            {
                return _GetriebeArtBezeichnung;
            }
            set
            {
                _GetriebeArtBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert einen string aller KBA-Nummern in Kleinbuchstaben
        /// </summary>
        public string KompressedKBA
        {
            get
            {
                string result = string.Empty;

                if (KBANummern != null && KBANummern.Count > 0)
                {
                    foreach (string kbaNummern in KBANummern)
                    {
                        result = string.Format("{0};{1}", result, kbaNummern.ToLower());
                    }
                    return result.Substring(1, result.Length - 1);
                }
                return string.Empty;
            }
        }

        public List<string> KompressedListKBA
        {
            get
            {
                List<string> result = new List<string>();

                if (KBANummern != null && KBANummern.Count > 0)
                {
                    foreach (string kbaNummern in KBANummern)
                    {
                        result.Add(kbaNummern.ToLower());
                    }
                }
                return result;
            }
        }

        public string KompressedBezeichnung
        {
            get
            {
                if (Bezeichnung != null)
                {
                    return Bezeichnung.Replace(" ", string.Empty).Replace(".", string.Empty);
                    //return System.Text.RegularExpressions.Regex.Replace(Bezeichnung, @"[^\w\.@-]", "");
                }

                return string.Empty;
            }
        }

        #endregion
    }
}
