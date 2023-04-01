/*********************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikel-Identifikation   
 * Funktionen: Kapselt die Informationen und Funktionen eines Suchbaumeintrages der ArtikelIdentifikation
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;
using PV.Utilities.Misc;

namespace PV.DomainObjects.Artikel
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Suchbaumeintrages
    /// </summary>
    [DataContract]
    [Serializable] 
    public class SuchbaumEintrag: IFinderObject
    {
        #region Fields

        private int _Id;
        private int _Tiefe;
        private int _Parent;
        private int _ParentNeu;
        private int _IdNeu;
        private string _Bezeichnung;
        private int _Sortierung;
        private bool _HatGenerischeArtikel;
        private bool _UseNewId;
        private bool _IsDvse = false;

        // _HatRessource hier auf false, also also defaultverhalten.
        private bool _HatRessource = false;
        private int _TemotStripId;
        private string _RessourceIdentifier;

        //wird für Breadcrumb benötigt, kommt nicht von der DB
        private int _Kinder;
       // private IList<ArtikelKriteriumKGN> _GemeinsameKriterien = new List<ArtikelKriteriumKGN>();
        
        #endregion

        #region IEquatable<SuchbaumEintrag> Member

        /// <summary>
        /// Vergleicht einen Suchbaumeintrag mit einem übergebenen Suchbaumeintrag auf Gleichheit
        /// </summary>
        /// <param name="other">Der Suchbaumeintrag mit dem die Gleichheit geprüft werden soll</param>
        /// <returns>true bei Gleichheit</returns>
        public bool Equals( SuchbaumEintrag other )
        {
            return this.Id.Equals( other.Id );
        }

        #endregion

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
        /// Liefert und setzt die Id des Parent Eintrags in der Datenquelle (null bei Rootelementen)
        /// </summary>
        [DataMember]
        public int ParentNew
        {
            get
            {
                return _ParentNeu;
            }
            set
            {
                _ParentNeu = value;
            }
        }

        /// <summary>
        /// Liefert und setzt Id des Eintrags in der Datenquelle
        /// </summary>
        [DataMember]
        public int IdNew
        {
            get
            {
                return _IdNeu;
            }
            set
            {
                _IdNeu = value;
            }
        }
        
        [DataMember]
        public bool UseNewId
        {
            get
            {
                return _UseNewId;
            }
            set
            {
                _UseNewId = value;
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
                //IsNew = HighlightHelper.IsNew("artikel." + _Bezeichnung);
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
        /// Liefert die Info ob diesem Suchbaumeintrag GenischeArtikel zugeordnet sind
        /// </summary>
        [DataMember]
        public bool HatGenerischeArtikel
        {
            get
            {
                return _HatGenerischeArtikel;
            }
            set
            {
                _HatGenerischeArtikel = value;
            }
        }


        /// <summary>
        /// Liefert die Info ob diesem Suchbaumeintrag Ressourcen (Temot-Bilder z.B.) zugeordnet sind
        /// </summary>
        [DataMember]
        public bool HatRessource
        {
            get
            {
                return _HatRessource;
            }
            set
            {
                _HatRessource = value;
            }
        }

        /// <summary>
        /// Liefert den RessourceType zurück, wenn der Eintag Ressourcen hat.
        /// </summary>
        [DataMember]
        public int TemotStripId
        {
            get
            {
                return _TemotStripId;
            }

            set
            {
                _TemotStripId = value;
            }

        }

        /// <summary>
        /// Der eindeutige Bezeichner der Ressource, falls vorhanden.
        /// </summary>
        [DataMember]
        public string RessourceIdentifier
        {
            get
            {
                return _RessourceIdentifier;
            }
            set
            {
                _RessourceIdentifier = value;
            }
        }

        /// <summary>
        /// Liefert und setzt wieviele Kinder (Artikel) unter diesem Eintrag gefunden wurden
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

        public bool IsDvse
        {
            get
            {
                return _IsDvse;
            }
            set
            {
                _IsDvse = value;
            }
        }

        public string DvseLink
        {
            get; set;
        }

        [DataMember]
        public bool SuchknotenGrafik { get; set; }

        /// <summary>
        /// Liefert die gemeinstamen Kriterien aller Artikel welche unter einem SuchbaumKnoten(Element) hängen
        /// </summary>
        //[DataMember]
        //public IList<ArtikelKriteriumKGN> GemeinsameKriterien
        //{
        //    get
        //    {
        //        return _GemeinsameKriterien;
        //    }
        //    set
        //    {
        //        _GemeinsameKriterien = value;
        //    }
        //}

        #endregion

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
        /// Erforderlich für Testing!
        /// </summary>
        public string TestTagId
        {
            get
            {
                return string.Format("{0}", Id);
            }
        }

        /// <summary>
        /// Erforderlich für Testing!
        /// </summary>
        public string TestTagText
        {
            get
            {
                return Bezeichnung;
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

        //// <summary>
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

        public override string ToString()
        {
            return Bezeichnung;
        }
    }
}
