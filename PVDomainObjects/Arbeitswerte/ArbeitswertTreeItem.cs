/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Arbeitswerte   
 * Funktionen:  Suchbaumitems des Arbeitswerte-Suchbaums
 *********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjectInterfaces;
using System.Runtime.Serialization;


namespace PV.DomainObjects.Arbeitswerte
{
    /// <summary>
    /// Kapselt die Funktionalität eines Suchbaumitems des Arbeitswerte-Suchbaums
    /// </summary>
    [DataContract]
    [Serializable] 
    public class ArbeitswertTreeItem : IFinderObject, IEquatable<ArbeitswertTreeItem>
    {
        #region Fields

        private string _Nummer;
        private string _Parent;
        private string _Beschreibung;
        private int _Tiefe;
        private bool _isLeaf;

        #endregion

        #region Arbeitswert-Member

        /// <summary>
        /// Liefert oder setzt die Beschreibung
        /// </summary>
        [DataMember]
        public string Beschreibung
        {
            get
            {
                return _Beschreibung;
            }
            set
            {
                _Beschreibung = value;
            }
        }

        /// <summary>
        /// Liefert oder setzt das Elternelement, dieses ist null (oberste Ebene) oder ein anderes ArbeitswertTreeItem
        /// </summary>
        [DataMember]
        public string Parent
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
        /// Liefert oder setzt die Nummer
        /// </summary>
        [DataMember]
        public string Nummer
        {
            get
            {
                return _Nummer;
            }
            set
            {
                _Nummer = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Information ob es sich bei dem Knoten um ein Blatt handelt
        /// </summary>
        [DataMember]
        public bool IsLeaf
        {
            get
            {
                return _isLeaf;
            }
            set
            {
                _isLeaf = value;
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
        /// Liefert und setzt den anzuzeigende String für die erste Spalte in der Finderspalte
        /// </summary>
        public string Description
        {
            get
            {
                return Beschreibung;
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
                return Parent;
            }
        }

        /// <summary>
        /// Liefert und setzt die ID des Objektes
        /// </summary>
        public string Id
        {
            get
            {
                return Nummer;
            }
        }

        /// <summary>
        /// Liefert und setzt die Tiefe im Baum
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

        public bool IsNew
        {
            get;
            set;
        }

        #endregion

        #region IEquatable<ArbeitswertTreeItem> Member

        public bool Equals( ArbeitswertTreeItem other )
        {
            return this.Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            ArbeitswertTreeItem toCompare = obj as ArbeitswertTreeItem;
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
