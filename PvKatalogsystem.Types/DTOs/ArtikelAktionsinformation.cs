using System;
using PvKatalogsystem.Types.Enums;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelAktionsinformation : DtoBase
    {
        [DataMember]
        public Aktionstyp AktionsTyp { get; set; }

        [DataMember]
        public long Aktionsnummer { get; set; }

        [DataMember]
        public string Aktionsanzeigename { get; set; }

        [DataMember]
        public string Aktionsbezeichnung { get; set; }

        [DataMember]
        public string Aktionsclaim { get; set; }

        [DataMember]
        public string Aktionslogo { get; set; }

        [DataMember]
        public string Aktionsnotiz { get; set; }

        [DataMember]
        public string Artikelanzeigename { get; set; }

        [DataMember]
        public string Artikelbeschreibung { get; set; }

        [DataMember]
        public string Artikelvorschaubild { get; set; }

        /// <summary>
        /// Aktion gültig ab
        /// </summary>
        [DataMember]
        public DateTime? AnzeigedatumMin { get; set; }

        /// <summary>
        /// Aktion gültig bis
        /// </summary>
        [DataMember]
        public DateTime AnzeigedatumMax { get; set; }

        [DataMember]
        public decimal? MengeMin { get; set; }

        [DataMember]
        public decimal MengeMax { get; set; }

        [DataMember]
        public bool ShowVerfuegbarkeit { get; set; }

        [DataMember]
        public bool ShowStreichpreis { get; set; }

        /// <summary>
        /// Nur für Bonusaktionen
        /// </summary>
        [DataMember]
        public decimal? Bonusfaktor { get; set; }

        /// <summary>
        /// Nur für Bonusaktionen
        /// </summary>
        [DataMember]
        public int? Bonuspunkte { get; set; }

        /// <summary>
        /// nur für Verkaufsaktionen
        /// </summary>
        [DataMember]
        public decimal? Verkaufsaktionspreis { get; set; }
    }
}
