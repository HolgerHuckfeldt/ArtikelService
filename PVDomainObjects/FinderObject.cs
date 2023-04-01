    /*******************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Modulübergreifend   
 * Funktionen:  Ein Objekt, welches im Finder angezeigt werden kann
 *******************************************************************/
using System;
using PV.DomainObjectInterfaces;

namespace PV.DomainObjects
{
    /// <summary>
    /// Ein Objekt, welches die Oberflächen im Finder anzeigen können
    /// </summary>
    [Serializable] 
    public class FinderObject: IFinderObject
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public FinderObject()
        {
            IsNew = false;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="_desc">Die Description</param>
        /// <param name="_parent">Die ParentID</param>
        /// <param name="_id">Die ID</param>
        /// <param name="_tiefe">Die Tiefe</param>
        public FinderObject( string _desc, string _parent, string _id, int _tiefe ) 
        {
            Description = _desc;
            ParentID = _parent;
            Id = _id;
            Tiefe = _tiefe;
            IsNew = false;
        }

        #region Fields

        private string _Description;
        private string _ParentID;
        private string _ID;
        private int _Tiefe;

        #endregion

        #region Properties

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
                return _Description;
            }
            set
            {
                _Description = value;
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
                return _ParentID;
            }
            set
            {
                _ParentID  = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die ID des Objektes
        /// </summary>
        public string Id
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Tiefe im Baum
        /// </summary>
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

        #region IFinderObject Member


       

        #endregion
    }
}
