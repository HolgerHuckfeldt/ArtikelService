using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Artikel
{
    public class VerwandteArtikelDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Stored = true, Indexed = true)]
        public string Id { get; set; }
        
        [SolrField(Name = "VerwandteArtikel", Stored = true, Indexed = false)]
        public ICollection<string> VerwandteArtikel { get; set; }
    }
}
