using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug
{
    public class PkwDoc : ISolrDocument
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

        [SolrField(Name = "KTypNummer", Stored = true, Indexed = true)]
        public int KTypNummer { get; set; }

        [SolrField(Name = "Motorcode", Stored = true, Indexed = true)]
        public ICollection<string> Motorcode { get; set; }

        [SolrField(Name = "Bauart", Stored = true, Indexed = true)]
        public string Bauart { get; set; }

        [SolrField(Name = "BaujahrMin", Stored = true, Indexed = true)]
        public DateTime BaujahrMin { get; set; }

        [SolrField(Name = "BaujahrMax", Stored = true, Indexed = true)]
        public DateTime? BaujahrMax { get; set; }

        [SolrField(Name = "Baujahr", Stored = false, Indexed = true)]
        public ICollection<int> Baujahr { get; set; }

        [SolrField(Name = "LeistungPs", Stored = true, Indexed = true)]
        public int? LeistungPs { get; set; }

        [SolrField(Name = "LeistungKw", Stored = true, Indexed = true)]
        public int? LeistungKw { get; set; }

        [SolrField(Name = "Hubraum", Stored = true, Indexed = true)]
        public int? Hubraum { get; set; }

        [SolrField(Name = "Kraftstoffart", Stored = true, Indexed = true)]
        public string Kraftstoffart { get; set; }

        [SolrField(Name = "Zylinder", Stored = true, Indexed = false)]
        public int? Zylinder { get; set; }

        [SolrField(Name = "Ventile", Stored = true, Indexed = false)]
        public int? Ventile { get; set; }

        [SolrField(Name = "Antriebsart", Stored = true, Indexed = false)]
        public string Antriebsart { get; set; }

        [SolrField(Name = "Motorart", Stored = true, Indexed = false)]
        public string Motorart { get; set; }

        [SolrField(Name = "Kraftstoffaufbereitung", Stored = true, Indexed = false)]
        public string Kraftstoffaufbereitung { get; set; }


    }
}
