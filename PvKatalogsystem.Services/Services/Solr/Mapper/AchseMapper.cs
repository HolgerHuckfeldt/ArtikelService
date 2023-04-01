using System.Collections.Generic;
using System.Text.RegularExpressions;
using PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class AchseMapper
    {
        private static readonly Regex _regexBremsengroesse = new Regex(@"^(.*)¦(.+)$", RegexOptions.Compiled);

        internal static Achse Map(AchseDoc doc)
        {
            var achse = new Achse();
            achse.Id = int.Parse(doc.Id);
            achse.Achsart = doc.Achsart;
            achse.Ausfuehrung = doc.Achsausfuehrung;
            if (doc.Bremsengroesse != null)
            {
                foreach (var item in doc.Bremsengroesse)
                {
                    var match = _regexBremsengroesse.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    achse.Bremsengroesse.Add(match.Groups[2].Value);
                }
            }
            if (!string.IsNullOrEmpty(doc.Breadcrumb))
            {
                achse.Modell = FahrzeugmodellMapper.Map(doc.Breadcrumb);
            }
            achse.Typ = doc.Bezeichnung;
            achse.Achsnummer = doc.Achsnummer;
            achse.BaujahrVon = doc.BaujahrMin;
            achse.BaujahrBis = doc.BaujahrMax;
            return achse;
        }

        internal static List<Achse> Map(IEnumerable<AchseDoc> docList)
        {
            var result = new List<Achse>();
            foreach (var doc in docList)
            {
                result.Add(Map(doc));
            }
            return result;
        }
    }
}
