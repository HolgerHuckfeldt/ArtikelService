/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Kapselt die Informationen und Funktionen eines Wartungschecklisteitmes
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Technik;
using System.Windows;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Wartung
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Wartungschecklisteitems
    /// </summary>

    [Serializable]
    [KnownType(typeof(List<Arbeitsprozess>))]
    [KnownType(typeof(List<TechnikLinkTyp>))]
    [KnownType(typeof(List<Artikel.Artikel>))]
    [KnownType(typeof(List<int>))]
    public class WartungsChecklisteItem : ISerializable
    {

        #region Enum

        [Serializable]
        public enum TechnikLinkTyp
        {
            NICHT_DEFINIERT,
            ADJHEAD,
            LUBEGRP,
            REP_MAN,
            TDRW,
        }

        #endregion

        #region Fields

        private List<Arbeitsprozess> _arbeitswerte;
        private List<Artikel.Artikel> _artikelliste;
        private List<int> _tecDocGenArtNr;

        public WartungsChecklisteItem()
        {
            CheckBoxAW = true;
            IsDisclaimer = false;
        }

        #endregion

        // --------------------------------------------------------------------------

        #region WartungsChecklisteItem-Member

        /// <summary>
        /// Liefert Id des WartungsChecklistenPunkts
        /// </summary>
        [DataMember]
        public int WartungsChecklisteItemId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Id der WartungsCheckliste
        /// </summary>
        [DataMember]
        public int WartungsChecklisteId
        {
            get;
            set;
        }

        private int _wartungsChecklistePeriodeId;

        /// <summary>
        /// Liefert die Id der WartungsChecklistePeriode
        /// </summary>
        [DataMember]
        public int WartungsChecklistePeriodeId
        {
            get { return _wartungsChecklistePeriodeId; }
            set { _wartungsChecklistePeriodeId = value; }
        }

        /// <summary>
        /// Liefert die Position
        /// </summary>
        [DataMember]
        public int? Position
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert den Namen der Grupppe
        /// </summary>
        [DataMember]
        public string Gruppe
        {
            get;
            set;
        }

        public int GruppeId
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Beschreibung
        /// </summary>
        [DataMember]
        public string Beschreibung
        {
            get;
            set;
        }
        
  
        /// <summary>
        /// Liefert die Anmerkung
        /// </summary>
        [DataMember]
        public string Anmerkung
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt an, ob ein Ersatzteil benötigt wird.
        /// </summary>
        [DataMember]
        public bool ErsatzteileBenoetigt
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt an, welche Art der Detailinformationen das ist.
        /// </summary>
        [DataMember]
        public int DetailinformationTyp
        {
            get;
            set;
        }

        /// <summary>
        /// Hilfs-Boolean für die 1. Checkbox (benötigt für Print)
        /// </summary>
        [DataMember]
        public bool CheckBoxAW
        {
            get;
            set;
        }

        public bool CheckBoxAWFolge
        {
            get;
            set;
        }

        /// <summary>
        /// Hilfs-Boolean für die 1. Checkbox (benötigt für Print)
        /// </summary>
        [DataMember]
        public bool CheckBoxOK
        {
            get;
            set;
        }

        /// <summary>
        /// Hilfs-Boolean für die 2. Checkbox (benötigt für Print)
        /// </summary>
        [DataMember]
        public bool CheckBoxReperatur
        {
            get;
            set;
        }

        /// <summary>
        /// Hilfs-Boolean für die 3. Checkbox (benötigt für Print)
        /// </summary>
        [DataMember]
        public bool CheckBoxErledigt
        {
            get;
            set;
        }

        public string BeschreibungAnmErs
        {
            get
            {
                string beschr = Beschreibung;

                if (!String.IsNullOrEmpty(Anmerkung))
                {
                    beschr = String.Format("{0} ({1})", beschr, Anmerkung);
                }

                if (ErsatzteileBenoetigt)
                {
                    beschr = String.Format("{0}*", beschr);
                }

                return beschr;
            }
        }

        public bool HasTechnikLinks
        {
            get
            {
                if (TechnikLinkTypen == null) return false;
                return TechnikLinkTypen.Count == 0 ? false : true;
            }
        }

        public bool IsDisclaimer
        {
            get;
            set;
        }


        public string Disclaimer
        {
            get;
            set;
        }


        public bool IsEnabled
        {
            get { return true; }
        }


        [DataMember]
        public bool IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt an ob das Object eine zusätzliche Info ist
        /// </summary>
        [DataMember]
        public bool IsInfoItem
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt eine Liste zurück, welche LinkTypen es an dem Item gibt.
        /// </summary>
        [DataMember]
        public List<TechnikLinkTyp> TechnikLinkTypen
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt eine Liste mit InfoItem zurück.
        /// </summary>
        [DataMember]
        public List<WartungsChecklisteItem> InfoItems
        {
            get;
            set;
        }

        public bool HasEinstelldatenLink
        {
            get
            {
                if (TechnikLinkTypen == null) return false;
                if (TechnikLinkTypen.Contains(TechnikLinkTyp.ADJHEAD)) return true;
                return false;
            }
        }

        public bool ShowAssistentButton
        {
            get
            {
                return true;
            }
        }


        public bool HasRephandbuchLink
        {
            get
            {
                if (TechnikLinkTypen == null) return false;
                if (TechnikLinkTypen.Contains(TechnikLinkTyp.REP_MAN)) return true;
                return false;
            }
        }

        public bool HasTZLink
        {
            get
            {
                if (TechnikLinkTypen == null) return false;
                if (TechnikLinkTypen.Contains(TechnikLinkTyp.TDRW)) return true;
                return false;
            }
        }

        public bool HasSchmierMittelLink
        {
            get
            {
                if (TechnikLinkTypen == null) return false;
                if (TechnikLinkTypen.Contains(TechnikLinkTyp.LUBEGRP)) return true;
                return false;
            }
        }

        public bool HasSmartLinks
        {
            get
            {
                return false;
            }
        }





        public string InfoItemText
        {
            get
            {
                if (InfoItems != null && InfoItems.Count > 0)
                {

                    string result = string.Join("\n", InfoItems.Select(a => a.Beschreibung).ToArray());

                    return result;


                    //var item = InfoItems[0];
                    //return item.Beschreibung;
                }

                return "";
            }
        }

        public string InfoItemWert
        {
            get
            {
                if (InfoItems != null && InfoItems.Count > 0)
                {
                    string result = string.Join("\n", InfoItems.Select(a => a.Anmerkung).ToArray());

                    return result;

                    //var item = InfoItems[0];
                    //return item.Anmerkung;
                }

                return "";
            }
        }

        /// <summary>
        /// Enthält den angehängten Arbeitswert
        /// </summary>
        [DataMember]
        public List<Arbeitsprozess> Arbeitswerte
        {
            get
            {
                return _arbeitswerte ?? (_arbeitswerte = new List<Arbeitsprozess>());
            }
            set
            {
                _arbeitswerte = value;
            }
        }

        #region neu aus Zip

        /// <summary>
        /// Liefert und setzt den AWWert (Wahrscheinlich aus den einzelnen Arbeitsprozessen berechnet)
        /// </summary>
        [DataMember]
        public double AWWert
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die AWStunden (Wahrscheinlich aus den einzelnen Arbeitsprozessen berechnet)
        /// </summary>
        [DataMember]
        public double AWStunden
        {
            get;
            set;
        }

        private bool _optional;

        /// <summary>
        /// Wahr wenn der Wartungssatzes optional ist
        /// </summary>
        [DataMember]
        public bool IsOptional
        {
            get{ return _optional;}
            set{ _optional = value;}
        }

        [DataMember]
        public List<Artikel.Artikel> Artikelliste
        {
            get
            {
                return _artikelliste ?? (_artikelliste = new List<Artikel.Artikel>());
            }
            set { _artikelliste = value; }
        }

        [DataMember]
        public IList<int> TecDocGenArtNr
        {
            get
            {
                return _tecDocGenArtNr ?? (_tecDocGenArtNr = new List<int>());
            }
        }

        #endregion

        #endregion

        // --------------------------------------------------------------------------
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            info.AddValue("WartungsChecklisteItemId", WartungsChecklisteItemId);
            info.AddValue("WartungsChecklisteId", WartungsChecklisteId);
            info.AddValue("WartungsChecklistePeriodeId", WartungsChecklistePeriodeId);
            info.AddValue("Position", Position);
            info.AddValue("Gruppe", Gruppe);
            info.AddValue("Beschreibung", Beschreibung);
            info.AddValue("Anmerkung", Anmerkung);
            info.AddValue("ErsatzteileBenoetigt", ErsatzteileBenoetigt);
            info.AddValue("DetailinformationTyp", DetailinformationTyp);
            info.AddValue("CheckBoxAW", CheckBoxAW);
            info.AddValue("CheckBoxAWFolge", CheckBoxAWFolge);
            info.AddValue("CheckBoxOK", CheckBoxOK);
            info.AddValue("CheckBoxReperatur", CheckBoxReperatur);
            info.AddValue("CheckBoxErledigt", CheckBoxErledigt);
            info.AddValue("TechnikLinkTypen", TechnikLinkTypen);
            info.AddValue("Arbeitswerte", Arbeitswerte);
            info.AddValue("AWWert", AWWert);
            info.AddValue("AWStunden", AWStunden);
            info.AddValue("IsOptional", IsOptional);
            info.AddValue("Artikelliste", Artikelliste);
            info.AddValue("TecDocGenArtNr", TecDocGenArtNr);
            info.AddValue("InfoItems", InfoItems);
            info.AddValue("IsInfoItem", IsInfoItem);
            info.AddValue("IsDeleted", IsDeleted);
        }

        public WartungsChecklisteItem(SerializationInfo info, StreamingContext context)
        {
            var values = info.GetEnumerator();

            while (values.MoveNext())
            {
                switch (values.Name)
                {
                    case "WartungsChecklisteItemId":
                        WartungsChecklisteItemId = (int)values.Value;
                        break;
                    case "WartungsChecklisteId":
                        WartungsChecklisteId = (int)values.Value;
                        break;
                    case "WartungsChecklistePeriodeId":
                        WartungsChecklistePeriodeId = (int)values.Value;
                        break;
                    case "Position":
                        if (values.Value != null)
                            Position = (int)values.Value;
                        break;
                    case "Gruppe":
                        if (values.Value != null)
                            Gruppe = (string)values.Value;
                        break;
                    case "Beschreibung":
                        if (values.Value != null)
                            Beschreibung = (string)values.Value;
                        break;
                    case "Anmerkung":
                        if (values.Value != null)
                            Anmerkung = (string)values.Value;
                        break;
                    case "ErsatzteileBenoetigt":
                        ErsatzteileBenoetigt = (bool)values.Value;
                        break;
                    case "DetailinformationTyp":
                        DetailinformationTyp = (int)values.Value;
                        break;
                    case "CheckBoxAW":
                        CheckBoxAW = (bool)values.Value;
                        break;
                    case "CheckBoxAWFolge":
                        CheckBoxAWFolge = (bool)values.Value;
                        break;
                    case "CheckBoxOK":
                        CheckBoxOK = (bool)values.Value;
                        break;
                    case "CheckBoxReperatur":
                        CheckBoxReperatur = (bool)values.Value;
                        break;
                    case "CheckBoxErledigt":
                        CheckBoxErledigt = (bool)values.Value;
                        break;
                    case "TechnikLinkTypen":
                        TechnikLinkTypen = values.Value as List<TechnikLinkTyp>;
                        break;
                    case "Arbeitswerte":
                        _arbeitswerte = values.Value as List<Arbeitsprozess>;
                        break;
                    case "AWWert":
                        AWWert = (double)values.Value;
                        break;
                    case "AWStunden":
                        AWStunden = (double)values.Value;
                        break;
                    case "IsOptional":
                        IsOptional = (bool)values.Value;
                        break;
                    case "Artikelliste":
                        _artikelliste =
                            values.Value as List<Artikel.Artikel>;
                        break;
                    case "TecDocGenArtNr":
                        _tecDocGenArtNr = values.Value as List<int>;
                        break;

                    case "InfoItems":
                        InfoItems = values.Value as List<WartungsChecklisteItem>;
                        break;

                    case "IsInfoItem":
                        IsInfoItem = (bool)values.Value;
                        break;

                    case "IsDeleted":
                        IsDeleted = (bool)values.Value;
                        break;

                }
            }
        }
    }
}
