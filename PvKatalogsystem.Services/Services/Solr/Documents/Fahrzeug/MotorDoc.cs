using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug
{
    public class MotorDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Indexed = true, Stored = true)]
        public string Id { get; set; }

        [SolrField(Name = "Motorcode", Indexed = true, Stored = true)]
        public string Motorcode { get; set; }

        [SolrField(Name = "BaujahrMin", Indexed = true, Stored = true)]
        public DateTime? BaujahrMin { get; set; }

        [SolrField(Name = "BaujahrMax", Indexed = true, Stored = true)]
        public DateTime? BaujahrMax { get; set; }

        [SolrField(Name = "Motornummer", Indexed = true, Stored = true)]
        public int Motornummer { get; set; }

        [SolrField(Name = "LeistungPsMin", Indexed = true, Stored = true)]
        public int? LeistungPsMin { get; set; }

        [SolrField(Name = "LeistungKwMin", Indexed = true, Stored = true)]
        public int? LeistungKwMin { get; set; }

        [SolrField(Name = "LeistungPsMax", Indexed = true, Stored = true)]
        public int? LeistungPsMax { get; set; }

        [SolrField(Name = "LeistungKwMax", Indexed = true, Stored = true)]
        public int? LeistungKwMax { get; set; }

        [SolrField(Name = "HubraumMin", Indexed = true, Stored = true)]
        public int? HubraumMin { get; set; }

        [SolrField(Name = "HubraumMax", Indexed = true, Stored = true)]
        public int? HubraumMax { get; set; }

        [SolrField(Name = "Kraftstoffart", Indexed = true, Stored = true)]
        public string Kraftstoffart { get; set; }

        [SolrField(Name = "Motorart", Indexed = true, Stored = true)]
        public string Motorart { get; set; }

        [SolrField(Name = "Hersteller", Indexed = true, Stored = true)]
        public string Hersteller { get; set; }
    }
}
