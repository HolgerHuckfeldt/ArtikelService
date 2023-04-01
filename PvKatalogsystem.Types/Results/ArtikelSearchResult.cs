using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Results
{
    [Serializable]
    public class ArtikelSearchResult : SearchResult
    {
        public ArtikelSearchResult(int numFound, int startIndex, int rowCount)
            : base(numFound, startIndex, rowCount)
        {
            Artikel = new List<Artikel>();
            IncentiveBundles = new List<IncentiveBundle>();
            Suchbaumknoten = new List<Suchbaumknoten>();
            BreadCrumbs = new Dictionary<string, string>();
            GenerischeArtikel = new Dictionary<int, string>();

        }

        public List<Artikel> Artikel { get; set; }
        public List<IncentiveBundle> IncentiveBundles { get; set; }
        public List<Suchbaumknoten> Suchbaumknoten { get; set; }
        public IDictionary<string, string> BreadCrumbs { get; set; }
        public IDictionary<int, string> GenerischeArtikel { get; set; }

    }
}
