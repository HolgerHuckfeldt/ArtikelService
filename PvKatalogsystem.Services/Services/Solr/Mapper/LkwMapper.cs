using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class LkwMapper
    {
        private static readonly Regex _regexRadstand = new Regex(@"^(.*)¦(\d+)$", RegexOptions.Compiled);
        private static readonly Regex _regexFederung = new Regex(@"^(.*)¦(.+)$", RegexOptions.Compiled);

        internal static Lkw Map(LkwDoc doc)
        {
            var lkw = new Lkw();
            lkw.Id = int.Parse(doc.Id);
            if (!string.IsNullOrEmpty(doc.Breadcrumb))
            {
                lkw.Modell = FahrzeugmodellMapper.Map(doc.Breadcrumb);
            }
            lkw.Bauart = doc.Bauart;
            lkw.BaujahrBis = doc.BaujahrMax;
            lkw.BaujahrVon = doc.BaujahrMin;
            lkw.Hubraum = doc.Hubraum;
            lkw.LeistungKwVon = doc.LeistungKwMin;
            lkw.LeistungPsVon = doc.LeistungPsMin;
            lkw.LeistungKwBis = doc.LeistungKwMax;
            lkw.LeistungPsBis = doc.LeistungPsMax;
            lkw.Achse = doc.Achse;
            lkw.Tonnage = doc.Tonnage;
            lkw.NTypNummer = doc.NTypNummer;
            if (doc.Motorcode != null)
            {
                lkw.Motorcodes = doc.Motorcode.ToList();                
            }
            if (doc.Radstand != null)
            {
                foreach (var item in doc.Radstand)
                {
                    var match = _regexRadstand.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var key = match.Groups[1].Value;
                    var value = int.Parse(match.Groups[2].Value);
                    lkw.Radstaende.Add(new KeyValuePair<string, int>(key, value));
                }
            }
            if (doc.Federung != null)
            {
                foreach (var item in doc.Federung)
                {
                    var match = _regexFederung.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var key = match.Groups[1].Value;
                    var value = match.Groups[2].Value;
                    lkw.Federungen.Add(new KeyValuePair<string, string>(key, value));
                }
            }
            lkw.Typ = doc.Bezeichnung;
            return lkw;
        }

        public static List<Lkw> Map(IEnumerable<LkwDoc> docList)
        {
            var result = new List<Lkw>();
            foreach (var doc in docList)
            {
                result.Add(Map(doc));
            }
            return result;
        }
    }
}
