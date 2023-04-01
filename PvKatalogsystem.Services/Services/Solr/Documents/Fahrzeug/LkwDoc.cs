using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug
{
    public class LkwDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Stored = true, Indexed = true)]
        public string Id { get; set; }

        [SolrField(Name = "Breadcrumb", Stored = true, Indexed = true)]
        public string Breadcrumb { get; set; }

        [SolrField(Name = "Hersteller", Stored = true, Indexed = true)]
        public string Hersteller { get; set; }

        [SolrField(Name = "Modell", Stored = true, Indexed = true)]
        public string Modell { get; set; }

        [SolrField(Name = "Bezeichnung", Stored = true, Indexed = true)]
        public string Bezeichnung { get; set; }

        [SolrField(Name = "KbaNummer", Stored = true, Indexed = true)]
        public ICollection<string> KbaNummer { get; set; }

        [SolrField(Name = "NTypNummer", Stored = true, Indexed = true)]
        public int NTypNummer { get; set; }

        [SolrField(Name = "Motorcode", Stored = true, Indexed = true)]
        public ICollection<string> Motorcode { get; set; }

        [SolrField(Name = "Bauart", Stored = true, Indexed = true)]
        public string Bauart { get; set; }

        [SolrField(Name = "BaujahrMin", Stored = true, Indexed = true)]
        public DateTime? BaujahrMin { get; set; }

        [SolrField(Name = "BaujahrMax", Stored = true, Indexed = true)]
        public DateTime? BaujahrMax { get; set; }

        [SolrField(Name = "Baujahr", Stored = false, Indexed = true)]
        public ICollection<int> Baujahr { get; set; }

        [SolrField(Name = "LeistungPsMin", Stored = true, Indexed = true)]
        public int? LeistungPsMin { get; set; }

        [SolrField(Name = "LeistungKwMin", Stored = true, Indexed = true)]
        public int? LeistungKwMin { get; set; }

        [SolrField(Name = "LeistungPsMax", Stored = true, Indexed = true)]
        public int? LeistungPsMax { get; set; }

        [SolrField(Name = "LeistungKwMax", Stored = true, Indexed = true)]
        public int? LeistungKwMax { get; set; }

        [SolrField(Name = "Hubraum", Stored = true, Indexed = true)]
        public int? Hubraum { get; set; }

        [SolrField(Name = "Tonnage", Stored = true, Indexed = true)]
        public decimal? Tonnage { get; set; }

        [SolrField(Name = "Achse", Stored = true, Indexed = true)]
        public string Achse { get; set; }

        [SolrField(Name = "Radstand", Stored = true, Indexed = false)]
        public ICollection<string> Radstand { get; set; }

        [SolrField(Name = "Federung", Stored = true, Indexed = false)]
        public ICollection<string> Federung { get; set; }

        [SolrField(Name = "Motorart", Stored = true, Indexed = false)]
        public string Motorart { get; set; }

    }
}
