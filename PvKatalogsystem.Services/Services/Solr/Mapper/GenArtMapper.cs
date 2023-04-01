using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using Absolute.SolrClient0900;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class GenArtMapper
    {
        private readonly static Regex _regexKnoten = new Regex(@"^(.+)\{(\d+)}¦(\d*)$", RegexOptions.Compiled);

         ////Breadcrumb_UNI:"1¦0¦Beleuchtung/Signalanlage{15703}¦Zusatzscheinwerfer/-einzelteile{15749}¦Arbeitsscheinwerfer/-einzelteile{15763}¦Arbeitsscheinwerfer{15765}¦Arbeitsscheinwerfer{1842}¦1"
        public static Dictionary<int, string> MapFacet(IDictionary<string,int> facet)
        {
            var result = new Dictionary<int, string>();
            foreach (var item in facet)
            {
                var match = _regexKnoten.Match(item.Key);
                
                if (!match.Success) continue;
                var displayName = match.Groups[1].Value;
                var id = int.Parse(match.Groups[2].Value);
                result.Add(id, displayName);
            }

            return result;
        }
    }
}
