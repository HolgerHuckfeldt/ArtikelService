using System;
using PV.DomainObjectInterfaces;
using System.Runtime.Serialization;

namespace PV.DomainObjects.LMS
{
    [DataContract]
    [Serializable]
    public class TrainingsOrt : IFinderObject, IEquatable<TrainingsOrt>
    {
        #region fields

        private String _stadt;
        private String _postleitzahl;
        private String _strasse;
        private String _zusatzInfo;

        #endregion

        #region Properties

        [DataMember]
        public String Bezeichnung { get; set; }

        public String StadtPLZ
        {
            get
            {
                return Stadt + " (" + Postleitzahl + ")";
            }
        }


        [DataMember]
        public String Postleitzahl
        {
            get { return _postleitzahl; }
            set { _postleitzahl = value; }
        }

        [DataMember]
        public String Stadt
        {
            get { return _stadt; }
            set { _stadt = value; }
        }

        [DataMember]
        public String Strasse
        {
            get { return _strasse; }
            set { _strasse = value; }
        }

        [DataMember]
        public String ZusatzInfo
        {
            get { return _zusatzInfo; }
            set { _zusatzInfo = value; }
        }

        [DataMember]
        public String Gebaeude { get; set; }

        [DataMember]
        public String Stockwerk { get; set; }

        [DataMember]
        public String Stadtteil { get; set; }

        [DataMember]
        public String Telefon { get; set; }

        [DataMember]
        public String Fax { get; set; }

        [DataMember]
        public Decimal StandortID { get; set; }

        [DataMember]
        public Decimal FirmaID { get; set; }

        [DataMember]
        public Decimal Abteilung { get; set; }

        [DataMember]
        public Decimal ADADSI { get; set; }

        [DataMember]
        public Decimal ADVADR { get; set; }

        [DataMember]
        public String ADADSB { get; set; }

        [DataMember]
        public bool LMSOrt { get; set; }

        #endregion

        #region IFinderObject Member

        /// <summary>
        /// Erforderlich für Testing!
        /// </summary>
        public string TestTag
        {
            get
            {
                return string.Format("{0}", "");
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die erste Spalte in der Finderspalte
        /// </summary>
        public string Description
        {
            get
            {
                return String.Format("{0} ({1})", Stadt, Postleitzahl);
            }
        }

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die zweite Spalte in der Finderspalte
        /// </summary>
        public string Description2
        {
            get
            {
                return null;
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
                return null;
            }
        }

        /// <summary>
        /// Liefert die ID des Objektes
        /// </summary>
        string IFinderObject.Id
        {
            get
            {
                return StandortID.ToString();
            }
        }

        /// <summary>
        /// Liefert die Tiefe des Objektes im Finder
        /// </summary>
        public int Tiefe
        {
            get
            {
                return 1;
            }
        }

        public bool IsNew
        {
            get;
            set;
        }
        #endregion

        #region Equatable Override

        public override bool Equals(object obj)
        {
            //if (ReferenceEquals(null, obj)) return false;
            //if (ReferenceEquals(this, obj)) return true;
            //if (obj.GetType() != typeof (TrainingsOrt)) return false;
            //return Equals((TrainingsOrt) obj);
            if(obj == null)
                return false;

            if (obj is TrainingsOrt)
                return Equals(obj as TrainingsOrt);

            return false;
        }

        public bool Equals(TrainingsOrt ort)
        {
            //if (ReferenceEquals(null, ort)) return false;
            //if (ReferenceEquals(this, ort)) return true;
            //return Equals(ort._stadt.ToLower(), _stadt.ToLower()) && Equals(ort._postleitzahl, _postleitzahl) && Equals(ort._strasse.ToLower(), _strasse.ToLower());// && Equals(ort._zusatzInfo, _zusatzInfo);
            if(ort == null)
                return false;

            return ort.Stadt.ToLower() == Stadt.ToLower() && ort.Postleitzahl == Postleitzahl;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (_stadt != null ? _stadt.GetHashCode() : 0);
                result = (result*397) ^ (_postleitzahl != null ? _postleitzahl.GetHashCode() : 0);
                result = (result*397) ^ (_strasse != null ? _strasse.GetHashCode() : 0);
                result = (result*397) ^ (_zusatzInfo != null ? _zusatzInfo.GetHashCode() : 0);
                return result;
            }
        }


        #endregion

    }
}
