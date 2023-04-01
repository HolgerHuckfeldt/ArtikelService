/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Stellt die Suchbaum-Einträge zur Verfügung
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;

namespace PV.DomainObjects.Wartung
{
    [Serializable]
    public class WartungSuchbaumEintrag : IFinderObject, IEquatable<WartungSuchbaumEintrag>
    {
        #region Fields

        private int _Id;
        private int _Tiefe;
        private int _Parent;
        private string _Bezeichnung;
        private int _Sortierung;
        private PeriodenTyp _PeriodenTyp;
        private bool _HatGenerischeDaten;

        //wird für Breadcrumb benötigt, kommt nicht von der DB
        private int _Kinder;

        #endregion

        // --------------------------------------------------------------------------

        #region SuchbaumEintrag Member

        /// <summary>
        /// Liefert und setzt Id des Eintrags in der Datenquelle
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
        /// Liefert und setzt die Tiefe des Eintrags in der Baumhirarchie
        /// </summary>
        [DataMember]
        public int Tiefe
        {
            get
            {
                return _Tiefe;
            }
            set
            {
                _Tiefe = value;
            }
        }


        /// <summary>
        /// Liefert und setzt die Id des Parent Eintrags in der Datenquelle (null bei Rootelementen)
        /// </summary>
        [DataMember]
        public int Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                _Parent = value;
            }
        }


        /// <summary>
        /// Liefert und setzt die Bezeichnung
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
        /// Liefert und setzt Sortierungsreihenfolge auf gleicher Ebene
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
        /// Liefert und setzt den PeriodenTyp
        /// </summary>
        [DataMember]
        public PeriodenTyp PeriodenTyp
        {
            get
            {
                return _PeriodenTyp;
            }
            set
            {
                _PeriodenTyp = value;
            }
        }

        /// <summary>
        /// Liefert die Info ob diesem Suchbaumeintrag GenerischeDaten zugeordnet sind
        /// </summary>
        [DataMember]
        public bool HatGenerischeDaten
        {
            get
            {
                return _HatGenerischeDaten;
            }
            set
            {
                _HatGenerischeDaten = value;
            }
        }

        /// <summary>
        /// Liefert und setzt wieviele Kinder unter diesem Eintrag gefunden wurden
        /// Wird für Breadcrumb benötigt, kommt nicht von der DB
        /// </summary>
        [DataMember]
        public int Kinder
        {
            get
            {
                return _Kinder;
            }
            set
            {
                _Kinder = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------

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
                return Parent.ToString();
            }
        }


        public bool DoSingle
        {
            get; set;
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

        public bool IsNew
        {
            get;
            set;
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (WartungSuchbaumEintrag)) return false;
            return Equals((WartungSuchbaumEintrag) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Id;
                result = (result*397) ^ _Tiefe;
                result = (result*397) ^ _Parent;
                result = (result*397) ^ (_Bezeichnung != null ? _Bezeichnung.GetHashCode() : 0);
                result = (result*397) ^ _Sortierung;
                result = (result*397) ^ _PeriodenTyp.GetHashCode();
                result = (result*397) ^ _HatGenerischeDaten.GetHashCode();
                result = (result*397) ^ _Kinder;
                return result;
            }
        }

        public static bool operator ==(WartungSuchbaumEintrag left, WartungSuchbaumEintrag right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WartungSuchbaumEintrag left, WartungSuchbaumEintrag right)
        {
            return !Equals(left, right);
        }

        // --------------------------------------------------------------------------
        public bool Equals(WartungSuchbaumEintrag other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._Id == _Id && other._Tiefe == _Tiefe && other._Parent == _Parent && Equals(other._Bezeichnung, _Bezeichnung) && other._Sortierung == _Sortierung && Equals(other._PeriodenTyp, _PeriodenTyp) && other._HatGenerischeDaten.Equals(_HatGenerischeDaten) && other._Kinder == _Kinder;
        }
    }
}
