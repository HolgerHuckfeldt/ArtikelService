using System;
using System.Runtime.Serialization;
namespace PV.DomainObjects.Arbeitswerte
{
    /// <summary>
    /// Klasse zum Speichern der ArbeitswertKriterien
    /// </summary>
    [DataContract]
    [Serializable]
    public class ArbeitswertKriterium
    {
        /// <summary>
        /// Liefert oder setet die Abkürzung der Kriterienbezeichnung
        /// </summary>
        [DataMember]
        public string KritBezeichnungAbk
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert oder setzt den Langnamen der Kriterienbezeichnung
        /// </summary>
        [DataMember]
        public string KritBezeichnungLang
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert oder setzt due Bezeichnung der Einheit des Kriteriums
        /// </summary>
        [DataMember]
        public string EinheitBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert oder setzt den Wert des Kriteriums
        /// </summary>
        [DataMember]
        public string KritWert
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert oder setzt die ABkürzung des Kriterientyps
        /// N - Numerisch
        /// A - Alphanumerisch
        /// V - ohne Wert
        /// B - Boolean
        /// D - Datum YYYYMM
        /// K - Key
        /// </summary>
        [DataMember]
        public string KritTyp
        {
            get;
            set;
        }
    }
}
