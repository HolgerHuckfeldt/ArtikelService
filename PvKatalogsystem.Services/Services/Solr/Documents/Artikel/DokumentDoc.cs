using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Interfaces;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Artikel
{
    public class DokumentDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Indexed = false, Stored = true)]
        public string Id { get; set; }

        [SolrField(Name = "Dokument", Indexed = false, Stored = true)]
        public ICollection<string> Dokument { get; set; }
    }
}
