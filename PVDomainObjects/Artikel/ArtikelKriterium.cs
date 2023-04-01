/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikel-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines ArtikelKriteriums
 ***********************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines ArtikelKriteriums
    /// </summary>
    [DataContract]
    [Serializable] 
    public class ArtikelKriterium
    {
        #region Fields

        private string _BezeichnungLang;
        private string _BezeichnungAbk;
        private string _BezeichnungEinheit;
        private string _KritWert;

        #endregion

        #region IEquatable<ArtikelKriterium> Member

        /// <summary>
        /// Vergleicht ein ArtikelKriterium mit einem übergebenen ArtikelKriterium auf Gleichheit
        /// </summary>
        /// <param name="other">Das ArtikelKriterium mit dem die Gleichheit geprüft werden soll</param>
        /// <returns>true bei Gleichheit</returns>
        public bool Equals( ArtikelKriterium other )
        {
            return Typ.Equals( other.Typ ) && BezeichnungLang.Equals( other.BezeichnungAbk ) && KritWert.Equals( other.KritWert );
        }

        #endregion

        #region ArtikelKriterium Member


        /// <summary>
        /// Liefert und setzt die Laufende Nummer 
        /// </summary>
        [DataMember]
        public string LfdNr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Sortier Nummer 
        /// </summary>
        [DataMember]
        public string SortNr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Kriterientyp
        /// </summary>
        [DataMember]
        public string Typ
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Info ob es sich um ein Sofortanzeigekriterium handelt
        /// </summary>
        [DataMember]
        public bool SofortAnzeige
        {
            get;
            set;
        }

        [DataMember]
        public bool HideName { get; set; }

        [DataMember]
        public bool IsNameFettdruck { get; set; }


        /// <summary>
        /// Liefert und setzt die Bezeichnung des Kriteriums
        /// </summary>
        [DataMember]
        public string BezeichnungLang
        {
            get
            {
                return _BezeichnungLang != null ? _BezeichnungLang.Trim() : string.Empty;
            }
            set
            {
                _BezeichnungLang = value;
            }
        }


        /// <summary>
        /// Liefert und setzt die Abkürzung der Bezeichnung des Kriteriums
        /// </summary>
        [DataMember]
        public string BezeichnungAbk
        {
            get
            {
                return _BezeichnungAbk != null ? _BezeichnungAbk.Trim() : string.Empty;
            }
            set
            {
                _BezeichnungAbk = value;
            }
        }


        /// <summary>
        /// Liefert und setzt die Bezeichnung der Einheit des Kriteriums
        /// </summary>
        [DataMember]
        public string BezeichnungEinheit
        {
            get
            {
                return _BezeichnungEinheit != null ? _BezeichnungEinheit.Trim() : string.Empty;
            }
            set
            {
                _BezeichnungEinheit = value;
            }
        }


        /// <summary>
        /// Liefert und setzt den Wert des Kriteriums
        /// </summary>
        [DataMember]
        public string KritWert
        {
            get
            {
                return _KritWert != null ? _KritWert.Trim() : string.Empty;
            }
            set
            {
                _KritWert = value;
            }
        }

        /// <summary>
        /// Liefert das AnzeigeLabel für dieses Kriterium
        /// </summary>
        public string Label
        {
            get
            {
                return string.IsNullOrEmpty( BezeichnungEinheit )
                           ? BezeichnungLang
                           : string.Format( "{0} [{1}]", BezeichnungLang, BezeichnungEinheit );
            }
        }

        /// <summary>
        /// Liefert und setzt den Boolwert Pflichtkriterium ja oder nein
        /// </summary>
        [DataMember]
        public bool Pflichtkriterium
        {
            get;
            set;
        }

        [DataMember]
        public int LinkageId
        {
            get;
            set;
        }

        #endregion
    }
}
