using System;
using System.Collections.Generic;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Interfaces;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug
{
    public class AchseDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Indexed = true, Stored = true)]
        public string Id { get; set; }

        [SolrField(Name = "Breadcrumb", Indexed = true, Stored = true)]
        public string Breadcrumb { get; set; }

        [SolrField(Name = "Bezeichnung", Indexed = true, Stored = true)]
        public string Bezeichnung { get; set; }

        [SolrField(Name = "BaujahrMin", Indexed = true, Stored = true)]
        public DateTime? BaujahrMin { get; set; }

        [SolrField(Name = "BaujahrMax", Indexed = true, Stored = true)]
        public DateTime? BaujahrMax { get; set; }

        [SolrField(Name = "Hersteller", Indexed = true, Stored = true)]
        public string Hersteller { get; set; }

        [SolrField(Name = "Modell", Indexed = true, Stored = true)]
        public string Modell { get; set; }

        [SolrField(Name = "Achsnummer", Indexed = true, Stored = true)]
        public int Achsnummer { get; set; }

        [SolrField(Name = "Achskoerper", Indexed = true, Stored = true)]
        public string Achskoerper { get; set; }

        [SolrField(Name = "Achsausfuehrung", Indexed = true, Stored = true)]
        public string Achsausfuehrung { get; set; }

        [SolrField(Name = "Achsart", Indexed = true, Stored = true)]
        public string Achsart { get; set; }

        [SolrField(Name = "Bremsenausfuehrung", Indexed = true, Stored = true)]
        public string Bremsenausfuehrung { get; set; }

        [SolrField(Name = "Bremsengroesse", Indexed = true, Stored = true)]
        public ICollection<string> Bremsengroesse { get; set; }

        [SolrField(Name = "Spurweite", Indexed = false, Stored = true)]
        public ICollection<int> Spurweite { get; set; }

    }
}
