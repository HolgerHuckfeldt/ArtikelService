using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using System.Runtime.Serialization;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Artikel
{
    [DataContract]
    public class ArtikelSortDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Stored = true, Indexed = true)]
        public string Id { get; set; }

        [SolrField(Name = "Aktionsnummer", Stored = true, Indexed = true)]
        public string Aktionsnummer { get; set; }

        [SolrField(Name = "AktionsnummerAbsatzgruppe_*", Stored = true, Indexed = true)]
        public ICollection<long> AktionsnummerAbsatzgruppe { get; set; }

        [SolrField(Name = "AktionsnummerKundengruppe_*", Stored = true, Indexed = true)]
        public ICollection<long> AktionsnummerKundengruppe { get; set; }

        [SolrField(Name = "Artikelnummer", Stored = false, Indexed = true)]
        public string Artikelnummer { get; set; }       

        [SolrField(Name = "ArtikelnummerSuche", Stored = false, Indexed = true)]
        public string ArtikelnummerSuche { get; set; }

        [SolrField(Name = "Breadcrumb_*", Stored = false, Indexed = true)]
        public ICollection<string> Breadcrumb { get; set; }

        [SolrField(Name = "CsoCode", Stored = true, Indexed = true)]
        public string CsoCode { get; set; }

        [SolrField(Name = "EaNummer", Stored = false, Indexed = true)]
        public ICollection<string> EaNummer { get; set; }

        [SolrField(Name = "FahrzeugId", Stored = false, Indexed = true)]
        public ICollection<string> FahrzeugId { get; set; }

        [SolrField(Name = "GebrauchsnummerSuche", Stored = false, Indexed = true)]
        public ICollection<string> GebrauchsnummerSuche { get; set; }

        [SolrField(Name = "GenArtId", Stored = false, Indexed = true)]
        public ICollection<int> GenArtId { get; set; }

        [SolrField(Name = "GenArtNummer", Stored = false, Indexed = true)]
        public ICollection<int> GenArtNummer { get; set; }
        
        [SolrField(Name = "Hersteller", Stored = false, Indexed = true)]
        public string Hersteller { get; set; }

        [SolrField(Name = "Herstellernummer", Stored = false, Indexed = true)]
        public Int64 Herstellernummer { get; set; }

        [SolrField(Name = "IsIncentiveBundle", Stored = false, Indexed = true)]
        public bool IsIncentiveBundle { get; set; }

        [SolrField(Name = "IsLieferbar", Stored = false, Indexed = true)]
        public bool IsLieferbar { get; set; }

        [SolrField(Name = "IsPseudoartikel", Stored = false, Indexed = true)]
        public bool IsPseudoartikel { get; set; }

        [SolrField(Name = "Marketingbezeichnung", Stored = false, Indexed = true)]
        public string Marketingbezeichnung { get; set; }

        [SolrField(Name = "ReferenznummerSuche", Stored = false, Indexed = true)]
        public ICollection<string> ReferenznummerSuche { get; set; }

        [SolrField(Name = "Suchbaumtyp", Stored = false, Indexed = true)]
        public string Suchbaumtyp { get; set; }

        [SolrField(Name = "Suchbaumknoten_*", Stored = false, Indexed = true)]
        public ICollection<string> Suchbaumknoten { get; set; }

        [SolrField(Name = "TeaserTyp", Stored = false, Indexed = true)]
        public ICollection<string> TeaserTyp { get; set; }

        [SolrField(Name = "TeaserId", Stored = true, Indexed = true)]
        public string TeaserId { get; set; }

        [SolrField(Name = "VdbArtikelnummer", Stored = false, Indexed = true)]
        public string VdbArtikelnummer { get; set; }

        [SolrField(Name = "VdbHerstellerkuerzel", Stored = false, Indexed = true)]
        public string VdbHerstellerkuerzel { get; set; }

        [SolrField(Name = "Vergleichsnummer", Stored = false, Indexed = true)]
        public ICollection<string> Vergleichsnummer { get; set; }

        [SolrField(Name = "Verkaufspreis_*", Stored = false, Indexed = true)]
        public decimal Verkaufspreis { get; set; }

        [SolrField(Name = "IsNfzUniversalArtikel", Stored = false, Indexed = true)]
        public bool IsNfzUniversalArtikel { get; set; }


    }
}
