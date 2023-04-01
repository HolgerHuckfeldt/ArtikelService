using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Artikel
{
    public class NummernDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Stored = true, Indexed = true)]
        public string Id { get; set; }

        [SolrField(Name = "Gebrauchsnummer", Stored = true, Indexed = false)]
        public ICollection<string> Gebrauchsnummer { get; set; }

        [SolrField(Name = "EaNummer", Stored = true, Indexed = true)]
        public ICollection<string> EaNummer { get; set; }

        [SolrField(Name = "Referenznummer", Stored = true, Indexed = false)]
        public ICollection<string> Referenznummer { get; set; }
        
        [SolrField(Name = "Ersatzartikelnummer", Stored = true, Indexed = false)]
        public ICollection<string> Ersatzartikelnummer { get; set; }
    }
}
