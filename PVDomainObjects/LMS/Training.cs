using System;
using System.Linq;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;
using PV.DomainObjects.Common;
using System.Collections.Generic;

namespace PV.DomainObjects.LMS
{
    [DataContract]
    [Serializable]
    public class Training : Artikel.Artikel, IFinderObject
    {
        #region Properties

        [DataMember]
        public String ArtNr { get; set; }

        [DataMember]
        public int DLNr { get; set; }

        [DataMember]
        public int GenArt { get; set; }

        [DataMember]
        public String Nummer { get; set; }

        [DataMember]
        public String Kategorie { get; set; }

        [DataMember]
        public String Titel { get; set; }

        public String AnzeigeTitel
        {
            get
            {
                return string.IsNullOrEmpty(Titel) ? Nummer : Titel;
            }
        }

        [DataMember]
        public String Zielgruppe { get; set; }

        [DataMember]
        public String Lernziel { get; set; }

        [DataMember]
        public String Inhalt { get; set; }

        [DataMember]
        public String KurzBeschreibung { get; set; }

        public String Sofortanzeigekriterien
        {
            get
            {
                string retValue = "";

                if (Kriterien != null && Kriterien.Count > 0)
                {
                    foreach (var krit in Kriterien.Where(x=>x.SofortAnzeige))
                    {
                        if (retValue.Length > 0)
                        {
                            retValue += " | ";
                        }
                        retValue += string.Format("{0}: {1}", krit.BezeichnungAbk, krit.KritWert);
                    }
                }

                return retValue;
            }
        }

        public IDictionary<string, string> Anzeigekriterien
        {
            get
            {
                IDictionary<string, string> retValue = new Dictionary<string, string>();

                retValue.Add("Kategorie", Kategorie);

                if (Kriterien != null && Kriterien.Count > 0)
                {
                    foreach (var krit in Kriterien)
                    {
                        retValue.Add(krit.BezeichnungAbk, krit.KritWert);
                    }
                }

                return retValue;
            }
        }

        [DataMember]
        public String ZeitString { get; set; }

        [DataMember]
        public String Voraussetzung { get; set; }

        [DataMember]
        public String Dauer { get; set; }

        [DataMember]
        public String SeminarInhalt { get; set; }

        [DataMember]
        public String ZusatzInfo { get; set; }

        [DataMember]
        public Decimal Preis { get; set; }

        public String PreisString
        {
            get
            {
                return Preis.ToString("N2") + " €";
            }
        }

        [DataMember]
        public int PreisPunkte { get; set; }

        [DataMember]
        public long PlusBonusPunkte { get; set; }

        [DataMember]
        public long PlusPunkte { get; set; }

        [DataMember]
        public bool AnerkanntAutofit { get; set; }

        [DataMember]
        public bool AnerkanntAutoprofi { get; set; }

        [DataMember]
        public bool AnerkanntTruckprofi { get; set; }

        [DataMember]
        public String VorgaengerArtNr { get; set; }

        [DataMember]
        public int VorgaengerDLNr { get; set; }

        [DataMember]
        public int VorgaengerGenArt { get; set; }

        public Training Vorgaenger { get; set; }

        [DataMember]
        public String NachfolgerArtNr { get; set; }

        [DataMember]
        public int NachfolgerDLNr { get; set; }

        [DataMember]
        public int NachfolgerGenArt { get; set; }

        public Training Nachfolger { get; set; }

        [DataMember]
        public int? NodeID { get; set; }

        [DataMember]
        public bool Trainingscard { get; set; }       

        #endregion

        #region IFinderObject Member

        ///// <summary>
        ///// Erforderlich für Testing!
        ///// </summary>
        //public string TestTag
        //{
        //    get
        //    {
        //        return string.Format("{0}", "");
        //    }
        //}

        /// <summary>
        /// Liefert und setzt den anzuzeigende String für die erste Spalte in der Finderspalte
        /// </summary>
        public string Description
        {
            get
            {
                return Titel;
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
                return GenArt.ToString();
            }
        }

        /// <summary>
        /// Liefert die Tiefe des Objektes im Finder
        /// </summary>
        public int Tiefe
        {
            get
            {
                return 2;
            }
        }

        public bool IsNew
        {
            get;
            set;
        }
        #endregion
    }
}
