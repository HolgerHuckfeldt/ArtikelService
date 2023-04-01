using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class ArtikelStuecklistenMapper
    {
        private readonly static Regex _regexStuecklisten = new Regex(@"^(PV|TECDOC)¦(\d*)¦([\d\.]*)¦(\d*)¦(\d+)$", RegexOptions.Compiled);

        internal static ArtikelStuecklisten Map(IEnumerable<string> itemList, IEnumerable<Artikel> artikelList)
        {
            var stuecklisten = new ArtikelStuecklisten();

            foreach (var item in itemList)
            {
                //var match = _regexStuecklisten.Match(item);
                var match = item.Split('¦');
                if (match.Count() < 4)
                {
                    return null;
                }
                var id = match[3];

                var artikel = artikelList.FirstOrDefault(x => x.Id.ToString() == id);
                if (artikel == null)
                {
                    continue;
                }

                var sa = new Stuecklistenartikel(artikel);
                sa.Sortiernummer = long.Parse(match[1]);
                if (sa.Sortiernummer == 0)
                {
                    sa.Sortiernummer = long.MaxValue;
                }
                sa.Menge = decimal.Parse(match[2]);

                var typ = match[0];
                switch (typ)
                {
                    case "PV":
                        stuecklisten.PvStueckliste.Add(sa);
                        break;
                    case "TECDOC":
                        stuecklisten.TecdocStueckliste.Add(sa);
                        break;
                }
            }

            return stuecklisten;
        }
    }
}
