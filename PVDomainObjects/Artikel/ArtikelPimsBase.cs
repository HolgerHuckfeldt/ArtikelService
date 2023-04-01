using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;

namespace PV.DomainObjects.Artikel
{
    public class ArtikelPimsBase
    {
        private IList<PVBildInfoObject> _Bilder; //PIMS
        private IList<int> _KnotenIds = new List<int>(); //PIMS


        /*
         * TecDoc /Pims Artikelbasisdaten
         *
         * 
         * 
         * Fahrzeug-/Motor- bzw. Achsverknüpfung des Artikels
         * TecDoc / Pims
         */
        /// <summary>
        /// TecDocXTyp steht für KTyp,NTyp, Motor- oder Achsnummer
        /// </summary>
        [DataMember]
        public Int32 PimsBaseTecDocXTypArtLink { get; set; }

        /// <summary>
        /// Laufende Nummer in der Verknüpfung zum TecDoc XTyp
        /// </summary>
        [DataMember]
        public Int32 PimsBaseLfdNrArtLink { get; set; }

        [DataMember]
        public IList<ArtikelKriterium> PimsBaseTypKriterienArtLink
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Liste der NodeIDs der übergeordneten Suchbaumnodes
        /// </summary>
        [DataMember]
        public IList<int> PimsBaseKnotenIdsArtLink
        {
            get
            {
                if (_KnotenIds == null)
                    _KnotenIds = new ObservableCollection<int>();
                return _KnotenIds;
            }
            set
            {
                _KnotenIds = value;
            }
        }

        [DataMember]
        public Boolean PimsBaseArtikelIsLinked { get; set; }

        /*
         * Basisdaten, die für alle TecDoc/PimsArtikel zutreffen
         */

        [DataMember]
        public IList<ArtikelKriterium> PimsBaseKriterien
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt Baugruppe
        /// </summary>
        [DataMember]
        public int? PimsBaseBaugruppe
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die BaugruppenBezeichnung
        /// </summary>
        [DataMember]
        public string PimsBaseBaugruppenBezeichnung
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Bezeichnung
        /// </summary>
        [DataMember]
        public string PimsBaseBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung des Generischen Artikels
        /// </summary>
        [DataMember]
        public string PimsBaseGenArtBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Marketing-Bezeichnung
        /// </summary>
        [DataMember]
        public string PimsBaseMarketingBezeichnung
        {
            get;
            set;
        }



        /// <summary>
        /// Liefert und setzt die Info ob es sich um eine SB gerechte Verpackung handelt (laut TECDOC Doku)
        /// </summary>
        [DataMember]
        public bool PimsBaseSBGerecht
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt ob Materialkennzeichnungspflicht besteht (laut TECDOC Doku)
        /// </summary>
        [DataMember]
        public bool PimsBaseMaterialkennzeichnungspflicht
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt ob es sich um Zubehör handelt (laut TECDOC Doku)
        /// </summary>
        [DataMember]
        public bool PimsBaseZubehoer
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Losgröße 1 (vielfaches von VPE - laut TECDOC Doku)
        /// </summary>
        [DataMember]
        public int PimsBaseLosGr1
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt Losgröße 2 (vielfaches von VPE - laut TECDOC Doku)
        /// </summary>
        [DataMember]
        public int PimsBaseLosGr2
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Herstellerlogo
        /// </summary>
        [DataMember]
        public PVBildInfoObject PimsBaseHerstellerLogo
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Nummer des Bildes
        /// </summary>
        [DataMember]
        public IList<PVBildInfoObject> PimsBaseBilder
        {
            get
            {
                if (_Bilder == null)
                    _Bilder = new ObservableCollection<PVBildInfoObject>();
                return _Bilder;
            }
            set
            {
                _Bilder = value;
            }
        }

        /// <summary>
        /// Liefert das erste Bild an dem Artikel
        /// </summary>
        public PVBildInfoObject PimsBaseFirstBild
        {
            get
            {
                if (_Bilder == null || _Bilder.Count == 0)
                {
                    return new PVBildInfoObject();
                }
                foreach (PVBildInfoObject bild in PimsBaseBilder)
                {
                    if (bild.Dateityp.ToUpper() != "PDF")
                        return bild;
                }
                return new PVBildInfoObject();

            }
        }

        /// <summary>
        /// Liefert und setzt den VKPreis
        /// </summary>
        [DataMember]
        public decimal PimsBaseVKPreis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Herstellername
        /// </summary>
        [DataMember]
        public string PimsBaseHerstellerName
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt den HerstellerKurzName
        /// </summary>
        [DataMember]
        public string PimsBaseHerstellerKurzName
        {
            get;
            set;
        }

    }
}
