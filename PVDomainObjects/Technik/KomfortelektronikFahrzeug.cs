/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines KomfortelektronikFahrzeugs
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines KomfortelektronikFahrzeugs
    /// </summary>
    [DataContract]
    [Serializable]
    public class KomfortelektronikFahrzeug : IFinderObject
    {
        #region Fields

        private int _FahrzeugTypId; // Das hier ist nicht die TypId, welche aus der TecDoc-DB gemappt wurde!!!
        private string _FahrzeugTyp;
        private int _ModellJahr;
        private string _GebautVon;
        private string _GebautBis;
        private string _MotorTyp;
        private string _Hubraum;
        private int _AnzahlZylinder;
        private string _LeistungKw;
        private string _LeistungPs;
        private string _Exportland;
        private string _ParentID;

        #endregion

        // --------------------------------------------------------------------------

        #region KomfortelektronikFahrzeug-Member

        /// <summary>
        /// Liefert Id des FahrzeugsTyps
        /// Das hier ist nicht die TypId, welche aus der TecDoc-DB gemappt wurde!!!
        /// </summary>
        [DataMember]
        public int FahrzeugTypId
        {
            get
            {
                return _FahrzeugTypId;
            }
            set
            {
                _FahrzeugTypId = value;
            }
        }

        public string FahrzeugTypModellJahr
        {
            get
            {
                return FahrzeugTyp + " " + ModellJahr;
            }
        }

        /// <summary>
        /// Name des FahrzeugTyps
        /// </summary>
        [DataMember]
        public string FahrzeugTyp
        {
            get
            {
                return _FahrzeugTyp;
            }
            set
            {
                _FahrzeugTyp = value;
            }
        }

        /// <summary>
        /// Liefert das Modelljahr
        /// </summary>
        [DataMember]
        public int ModellJahr
        {
            get
            {
                return _ModellJahr;
            }
            set
            {
                _ModellJahr = value;
            }
        }

        /// <summary>
        /// Datum ab wann das Fahrzeug gebaut wurde
        /// </summary>
        [DataMember]
        public string GebautVon
        {
            get
            {
                return _GebautVon;
            }
            set
            {
                _GebautVon = value;
            }
        }

        /// <summary>
        /// Datum bis wann das Fahrzeug gebaut wurde
        /// </summary>
        [DataMember]
        public string GebautBis
        {
            get
            {
                return _GebautBis;
            }
            set
            {
                _GebautBis = value;
            }
        }

        /// <summary>
        /// Liefert den Motortypen
        /// </summary>
        [DataMember]
        public string MotorTyp
        {
            get
            {
                return _MotorTyp;
            }
            set
            {
                _MotorTyp = value;
            }
        }

        /// <summary>
        /// Liefert die Größe des Hubraums in ccm
        /// </summary>
        [DataMember]
        public string Hubraum
        {
            get
            {
                return _Hubraum;
            }
            set
            {
                _Hubraum = value;
            }
        }

        /// <summary>
        /// Liefert die Anzahl der Zylinder
        /// </summary>
        [DataMember]
        public int AnzahlZylinder
        {
            get
            {
                return _AnzahlZylinder;
            }
            set
            {
                _AnzahlZylinder = value;
            }
        }

        /// <summary>
        /// Liefert die Leistung in kW
        /// </summary>
        [DataMember]
        public string LeistungKw
        {
            get
            {
                return _LeistungKw;
            }
            set
            {
                _LeistungKw = value;
            }
        }

        /// <summary>
        /// Liefert die Leistung in Ps
        /// </summary>
        [DataMember]
        public string LeistungPs
        {
            get
            {
                return _LeistungPs;
            }
            set
            {
                _LeistungPs = value;
            }
        }

        /// <summary>
        /// Liefert das Exportland
        /// </summary>
        [DataMember]
        public string Exportland
        {
            get
            {
                return _Exportland;
            }
            set
            {
                _Exportland = value;
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
                if(_ModellJahr != 0)
                    return _FahrzeugTyp + " " + _ModellJahr;

                return _FahrzeugTyp;
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
                _ParentID = value;
            }
        }

        /// <summary>
        /// Liefert die ID des Objektes
        /// </summary>
        string IFinderObject.Id
        {
            get
            {
                return _FahrzeugTypId.ToString();
            }
        }

        /// <summary>
        /// Liefert die Tiefe des Objektes im Finder
        /// </summary>
        public int Tiefe
        {
            get
            {
                return 3;
            }
            //set
            //{
            //    _Tiefe = value;
            //}
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
