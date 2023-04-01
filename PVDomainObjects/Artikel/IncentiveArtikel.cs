using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class IncentiveArtikel : Artikel
    {
        /// <summary>
        /// Intervalle fuer Olyslager
        /// </summary>
        public IList<string> Intervalle { get; set; }

        /// <summary>
        /// Kapazitaeten fuer Olyslager
        /// </summary>
        public IList<string> Kapazitaeten { get; set; }

        /// <summary>
        /// Liefert und setzt das Incentive-Bundle-Bild
        /// </summary>
        [DataMember]
        public virtual PvImage IncentiveBundleBild
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Incentive-Bundle-Thumbnail
        /// </summary>
        [DataMember]
        public virtual PvImage IncentiveBundleThumb
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Display Type
        /// </summary>
        [DataMember]
        public virtual int IncentiveArticleDisplayTypes
        {
            get; set;
        }

        /// <summary>
        /// Liefert und setzt den Incentive-Bundle-Herstellernamen
        /// </summary>
        [DataMember]
        public virtual string IncentiveBundleHerstellername
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Incentive-Bundle-Bezeichnung
        /// </summary>
        [DataMember]
        public virtual string IncentiveBundleBezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Incentive-Bundle-Claim
        /// </summary>
        [DataMember]
        public virtual string IncentiveBundleClaim
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Incentive-Bundle-Sofortanzeige
        /// </summary>
        [DataMember]
        public virtual IEnumerable<string> IncentiveBundleSofortanzeige
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Incentive-Bundle-Beschreibung
        /// </summary>
        [DataMember]
        public virtual string IncentiveBundleBeschreibung
        {
            get;
            set;
        }

        [DataMember]
        public String IncentiveArtikelName
        {
            get; set;
        }

        [DataMember]
        public String IncentivArtikelHerstellerName
        {
            get; set;
        }

        [DataMember]
        public PvImage IncentivArtikelBild
        {
            get; set;
        }

        [DataMember]
        public String IncentiveArtikelNummer
        {
            get; set;
        }

        [DataMember]
        public int IncentiveArtikelDatenlieferantenNummer
        { 
            get; set;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Artikelnummer: " + ArtikelNummer);
            sb.AppendLine("Datenlieferantennummer: " + DatenlieferantenNummer.ToString());
            sb.AppendLine("GenArtNr: " + GenArtNr.ToString());
            return sb.ToString();
        }
    }
}
