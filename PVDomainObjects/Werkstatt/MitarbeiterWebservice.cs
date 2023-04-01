using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Stammdaten
{
    [Serializable]
    [DataContract]
    public class MitarbeiterWebservice
    {
        [DataMember]
        private string _Vorname = string.Empty;
        [DataMember]
        private string _Nachname = string.Empty;
        [DataMember]
        private string _Firmenname = string.Empty;
        [DataMember]
        private int _ProfilId;
        [DataMember]
        private int _Kundennummer;
        [DataMember]
        private string _Email;

        /// <summary>
        /// Liefert und setzt den Vornamen
        /// </summary>
        [DataMember]
        public string Vorname
        {
            get
            {
                return _Vorname;
            }
            set
            {
                _Vorname = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Familiennamen
        /// </summary>
        [DataMember]
        public string Nachname
        {
            get
            {
                return _Nachname;
            }
            set
            {
                _Nachname = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Firmennamen
        /// </summary>
        [DataMember]
        public string Firmenname
        {
            get
            {
                return _Firmenname;
            }
            set
            {
                _Firmenname = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die ProfilId
        /// </summary>
        [DataMember]
        public int ProfilId
        {
            get
            {
                return _ProfilId;
            }
            set
            {
                _ProfilId = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Kundennummer
        /// </summary>
        [DataMember]
        public int Kundennummer
        {
            get
            {
                return _Kundennummer;
            }
            set
            {
                _Kundennummer = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Email
        /// </summary>
        [DataMember]
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
    }
}
