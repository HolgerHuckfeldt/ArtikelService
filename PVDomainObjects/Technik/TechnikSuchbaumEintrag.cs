/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Stellt die Suchbaum-Einträge zur Verfügung
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;
using PV.Utilities.Misc;

namespace PV.DomainObjects.Technik
{
    [Serializable] 
    public class TechnikSuchbaumEintrag : IFinderObject
    {
        #region Fields

        private int _Id;
        private int _Tiefe;
        private int _Parent;
        private string _Bezeichnung;
        private int _Sortierung;
        private Enum _EnumWert;
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
                //IsNew = HighlightHelper.IsNew("technik."+Bezeichnung);
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
        /// Liefert und setzt den Enum-Wert
        /// </summary>
        [DataMember]
        public Enum EnumWert
        {
            get
            {
                return _EnumWert;
            }
            set
            {
                _EnumWert = value;
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

        // --------------------------------------------------------------------------
    }
}
