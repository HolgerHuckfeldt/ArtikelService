using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using Absolute.SolrClient0900;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class SuchbaumknotenMapper
    {
        private const char DELIMITER = '¦';

        private static readonly Regex _regexKnoten = new Regex(@"^(.*)\{(\d+)}$", RegexOptions.Compiled);
        private static readonly Regex _regexNewline = new Regex("(\r\n|\r|\n)");

        public static List<Suchbaumknoten> Map(string docBreadcrumb)
        {
            var result = new List<Suchbaumknoten>();
            var items = docBreadcrumb.Split('¦');

            int? parentId = null;
            for (var i = 2; i < items.Length - 1; i++)
            {
                var item = items[i];
                item = Regex.Replace(item, @"(\r\n|\r|\n)", ""); //https://absolutehh.atlassian.net/browse/PV-1358

                var match = _regexKnoten.Match(item);
                if (!match.Success)
                {
                    continue;
                }
                var knoten = new Suchbaumknoten();
                knoten.Bezeichnung = match.Groups[1].Value;
                knoten.Id = int.Parse(match.Groups[2].Value);
                knoten.Ebene = i - 2;
                knoten.ParentId = parentId;
                if (i == items.Length - 2)
                {
                    knoten.IsEndknoten = true;
                }
                parentId = knoten.Id;
                result.Add(knoten);
            }
            return result;
        }

        public static List<Suchbaumknoten> Map(IEnumerable<string> docBreadcrumbList, List<string> genArtIds = null,
            List<string> genArtFahrzeugIds = null, int vorgaengerKnoten = 0,
            int vorgaengerKnotenTiefe = 0, int vorgaengerParentIdKnoten = 0, int singleGenArtId = 0, IEnumerable<string> genartMasterbezFieldResult = null)
        {
            var masterBezList = new Dictionary<string, string>();
            if (genartMasterbezFieldResult != null && genartMasterbezFieldResult.Count() > 0)
            {
                var regex = new Regex(@"^(\d+)" + DELIMITER + "(.*)");
                foreach (var key in genartMasterbezFieldResult)
                {
                    var match = regex.Match(key);
                    if (!match.Success)
                    {
                        continue;
                    }
                    masterBezList.Add(match.Groups[1].Value, match.Groups[2].Value);
                }
            }

            var result = new List<Suchbaumknoten>();
            if (genArtIds == null && genArtFahrzeugIds == null)
            {
                foreach (var item in docBreadcrumbList)
                {
                    //if (item.Contains("PKW"))
                    //    throw new FieldAccessException();

                    foreach (var knoten in Map(item))
                    {
                        if (knoten.IsEndknoten || !result.Any(x => (x.Id == knoten.Id && !x.IsEndknoten && !knoten.IsEndknoten) || (x.Id == knoten.Id && x.IsEndknoten && knoten.IsEndknoten)))
                        {
                            if (knoten.Ebene == vorgaengerKnotenTiefe && vorgaengerKnoten > 0 && vorgaengerKnoten != knoten.Id)
                            {
                                break;
                            }
                            else if (knoten.IsEndknoten &&
                                vorgaengerKnotenTiefe > 0 &&
                                vorgaengerKnoten > 0 && (vorgaengerKnoten == knoten.Id)
                                && vorgaengerParentIdKnoten != knoten.ParentId)
                            {
                                break;
                            }
                            else if (knoten.IsEndknoten && singleGenArtId > 0 && knoten.Id != singleGenArtId)
                            {
                                break;
                            }

                            if (knoten.IsEndknoten && masterBezList.ContainsKey(knoten.Id.ToString()))
                            {
                                knoten.Bezeichnung = masterBezList[knoten.Id.ToString()];
                            }
                            
                            result.Add(knoten);
                        }
                    }
                }
            }
            else if (genArtIds != null)
            {
                var resGenArtIds = genArtIds.SelectMany(x => x.Split(DELIMITER));

                foreach (var item in docBreadcrumbList)
                {
                    var knotenResult = Map(item);
                    if (knotenResult.Count > 0 && resGenArtIds.Count(x => x == knotenResult[knotenResult.Count - 1].Id.ToString()) > 0)
                    {
                        foreach (var knoten in knotenResult)
                        {
                            if (knoten.IsEndknoten || !result.Any(x => x.Id == knoten.Id))
                            {
                                if (knoten.IsEndknoten && masterBezList.ContainsKey(knoten.Id.ToString()))
                                {
                                    knoten.Bezeichnung = masterBezList[knoten.Id.ToString()];
                                }

                                result.Add(knoten);
                            }
                        }
                    }
                }
            }
            else
            {
                var resGenArtIds = genArtFahrzeugIds.SelectMany(x => x.Split(DELIMITER));
                var breadcrumbs = new List<List<Suchbaumknoten>>();

                foreach (var item in docBreadcrumbList)
                {
                    var knotenResult = Map(item);

                    if (knotenResult.Count > 0 && resGenArtIds.Count(x => x == knotenResult[knotenResult.Count - 1].Id.ToString()) > 0)
                    {
                        breadcrumbs.Add(knotenResult);
                    }
                }
                breadcrumbs = breadcrumbs.OrderBy(x => x.First().Bezeichnung).ToList();

                foreach (var knotenResult in breadcrumbs)
                {
                    foreach (var knoten in knotenResult)
                    {
                        if (knoten.IsEndknoten || !result.Any(x => x.Id == knoten.Id))
                        {
                            result.Add(knoten);
                        }
                    }
                }
            }
            return result;
        }

        ////Breadcrumb_UNI:"1¦0¦Beleuchtung/Signalanlage{15703}¦Zusatzscheinwerfer/-einzelteile{15749}¦Arbeitsscheinwerfer/-einzelteile{15763}¦Arbeitsscheinwerfer{15765}¦Arbeitsscheinwerfer{1842}¦1"
        public static Dictionary<string, string> MapBreadCrumbs(IDictionary<string, int> docBreadcrumbList)
        {
            var result = new Dictionary<string, string>();
            foreach (var item in docBreadcrumbList)
            {
                var values = item.Key.Split('¦');
                var match = _regexKnoten.Match(values[values.Length - 2]);
                
                if (!match.Success) continue;
                var displayName = string.Format("{0}",match.Groups[1]);
                if (!result.ContainsKey(match.Groups[2].Value)) result.Add(match.Groups[2].Value, displayName);
            }

            return result;
        }

        public static List<string> MapGenArtIds(IEnumerable<string> docGenArtIds, string fzgId, string fzgArtName)
        {
            var result = new List<string>();

            //string fzgArtNamefzgId = DELIMITER + fzgArtName + fzgId;

            result.AddRange(docGenArtIds);
            //foreach (var item in docGenArtIds)
            //{
            //    result.Add(item);
            //}

            return result;
        }
    }
}
