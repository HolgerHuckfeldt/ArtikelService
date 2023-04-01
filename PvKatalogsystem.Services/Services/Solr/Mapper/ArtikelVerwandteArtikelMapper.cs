using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class ArtikelVerwandteArtikelMapper
    {
        internal static ArtikelVerwandteArtikel Map(List<KeyValuePair<int, string>> itemList,
            IEnumerable<Artikel> artikelList, List<KeyValuePair<int, decimal>> benoetigteMengeList)
        {
            var verwandteArtikel = new ArtikelVerwandteArtikel();

            foreach (var item in itemList)
            {
                var artikel = artikelList.FirstOrDefault(x => x.Id == item.Key);
                var benoetigteMenge = benoetigteMengeList.First(x => x.Key == item.Key).Value;

                if (artikel == null)
                {
                    continue;
                }

                artikel.BenoetigteMenge = benoetigteMenge;
                
                switch (item.Value)
                {
                    case "K":
                        verwandteArtikel.Kann.Add(artikel);
                        break;
                    case "M":
                        verwandteArtikel.Muss.Add(artikel);
                        break;
                    case "S":
                        verwandteArtikel.Soll.Add(artikel);
                        break;
                    default:
                        verwandteArtikel.Zubehoer.Add(artikel);
                        break;
                }
            }

            return verwandteArtikel;
        }
    }
}
