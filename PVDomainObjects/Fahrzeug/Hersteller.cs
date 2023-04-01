/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeug-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Fahrzeugherstellers
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Fahrzeugherstellers
    /// </summary>
    [Serializable]
    [DataContract]
    public class Hersteller : IFinderObject, IEquatable<Hersteller>
    {
        #region Fields

        private int _Id;
        private int _HerstellerId;
        private String _Bezeichnung;
        private string _Kurzbezeichnung;

        #endregion

        #region Hersteller-Member

        /// <summary>
        /// Liefert Id des Herstellers in der Datenquelle
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
        /// Liefert die Hersteller-Id aus Tecdoc
        /// </summary>
        [DataMember]
        public int HerstellerId
        {
            get
            {
                return _HerstellerId;
            }
            set
            {
                _HerstellerId = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Name des Herstellers
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
        /// Liefert und setzt die Kurzbezeichnung des Herstellers
        /// </summary>
        [DataMember]
        public string Kurzbezeichnung
        {
            get
            {
                return _Kurzbezeichnung != null ? _Kurzbezeichnung.Trim() : string.Empty;
            }
            set
            {
                _Kurzbezeichnung = value;
            }
        }

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
                return Id.ToString();
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

        #region IEquatable<Hersteller> Member

        public bool Equals( Hersteller other )
        {
            return this.Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            Hersteller toCompare = obj as Hersteller;
            if( toCompare != null )
                return toCompare.Id == this.Id;
            else
                return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
