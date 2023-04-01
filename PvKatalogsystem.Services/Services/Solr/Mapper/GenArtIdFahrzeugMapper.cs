using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class GenArtIdFahrzeugMapper
    {   
        public static List<string> Map(IEnumerable<string> docGenArtIdFahrzeug, string fzgIdent)
        {
            List<string> listGenArtFahrzeugId = new List<string>();

            foreach (var genArts in docGenArtIdFahrzeug.Where(x => x.Contains(fzgIdent)))
            {
                listGenArtFahrzeugId.Add(genArts);
            }

            return listGenArtFahrzeugId;
        }
    }
}
