using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PvKatalogsystem.Types.Results;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class AutoSuggestMapper
    {
        private const char DELIMITER = '¦';
        private readonly static Regex _regex = new Regex(@"^(.+)\{(\d+)}$", RegexOptions.Compiled);
        private readonly static Regex _regexSynonym = new Regex(@"^(\d+)" + DELIMITER + "(.*)");

        public static IEnumerable<AutoSuggestItem> Map(IDictionary<string, int> facetResult, AutoSuggestItemTypes type,
            string filterQuery, int maxCount, IDictionary<string, int> facetResultMaster = null, IDictionary<string, int> facetResultSynonym = null)
        {
            var suggestList = new List<AutoSuggestItem>();

            var masterBezList = new Dictionary<string, string>();
            var synonymBezList = new Dictionary<string, string>();

            if (facetResultMaster != null && facetResultMaster.Count() > 0)
            {
                var regex = new Regex(@"^(\d+)" + DELIMITER + "(.*)");
                foreach (var key in facetResultMaster.Select(x => x.Key))
                {
                    var match = regex.Match(key);
                    if (!match.Success)
                    {
                        continue;
                    }
                    masterBezList.Add(match.Groups[1].Value, match.Groups[2].Value);
                }
            }

            if (facetResultSynonym != null && facetResultSynonym.Count() > 0)
            {
                foreach (var key in facetResultSynonym.Select(x => x.Key))
                {
                    var match = _regexSynonym.Match(key);
                    if (!match.Success)
                    {
                        continue;
                    }

                    if (match.Groups[2].Value.ToLower().Contains(filterQuery.ToLower()) && !synonymBezList.Any(x => x.Key == match.Groups[1].Value))
                    {
                        var displayName = EncodeAndHighlightKeyWords(match.Groups[2].Value.ToString(), filterQuery, "<em>", "</em>");

                        synonymBezList.Add(match.Groups[1].Value, displayName);
                    }
                }
            }

            foreach (var item in facetResult)
            {
                var input = string.Empty;
                var values = item.Key.Split('¦');

                switch (type)
                {
                    case AutoSuggestItemTypes.HerstellerUni:
                        input = values[0];
                        break;
                    case AutoSuggestItemTypes.HerstellerFahrzeug:
                        input = values[0];
                        break;
                    default:
                        input = values[values.Length - 2];
                        break;
                }

                var match = _regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }

                if (input.ToLower().Contains(filterQuery.ToLower()))
                {
                    var displayName = EncodeAndHighlightKeyWords(match.Groups[1].ToString(), filterQuery, "<em>", "</em>");
                    //var displayName = match.Groups[1].ToString();
                    //EncodeAndHighlightKeyWords(match.Groups[1].ToString(), filterQuery, "<em>", "</em>");

                    var addValue = new AutoSuggestItem()
                    {
                        DisplayName = displayName,
                        DisplayNameSort = match.Groups[1].ToString(),
                        ResultCount = item.Value,
                        Type = type,
                        GenArtId = int.Parse(match.Groups[2].Value)
                    };

                    if (masterBezList.ContainsKey(addValue.GenArtId.ToString()))
                    {
                        addValue.DisplayName = EncodeAndHighlightKeyWords(masterBezList[addValue.GenArtId.ToString()], filterQuery, "<em>", "</em>");
                    }

                    if (synonymBezList.ContainsKey(addValue.GenArtId.ToString()))
                    {
                        addValue.DisplayName += string.Format(" ({0})", synonymBezList[addValue.GenArtId.ToString()]);
                    }

                    suggestList.Add(addValue);
                }
                else if (synonymBezList.ContainsKey(match.Groups[2].Value))
                {
                    int genArtId = int.Parse(match.Groups[2].Value);

                    if (suggestList.Count(x => x.GenArtId == genArtId) == 0)
                    {
                        var addValue = new AutoSuggestItem()
                        {
                            DisplayName = string.Format("{0} ({1})", match.Groups[1].ToString(), synonymBezList[genArtId.ToString()]),
                            DisplayNameSort = match.Groups[1].ToString(),
                            ResultCount = item.Value,
                            Type = type,
                            GenArtId = genArtId
                        };

                        if (masterBezList.ContainsKey(addValue.GenArtId.ToString()))
                        {
                            addValue.DisplayName += ", " + EncodeAndHighlightKeyWords(masterBezList[addValue.GenArtId.ToString()], filterQuery, "<em>", "</em>");
                        }

                        suggestList.Add(addValue);
                    }
                }

                if (suggestList.Count > maxCount)
                {
                    break;
                }
            }

            return suggestList;//.OrderBy(x=>x.DisplayNameSort);
        }

        public static IEnumerable<AutoSuggestItem> MapHerstellerHLKArtikel(IDictionary<string, int> facetResult, AutoSuggestItemTypes type, string filterQuery,
          int MaxCount)
        {
            var suggestList = new List<AutoSuggestItem>();

            int i = 1;
            foreach (var item in facetResult)
            {
                if (item.Key.ToLower().Contains(filterQuery.ToLower()))
                {
                    var input = string.Empty;
                    string input2 = string.Empty;
                    string input3 = string.Empty;
                    var values = item.Key.Split('¦');
                    var filter = string.Empty;
                    input = values[0];
                    if (values.Length > 1)
                    {
                        input2 = values[1];
                    }

                    input3 = input;
                    if (!string.IsNullOrEmpty(input2))
                    {
                        input3 += string.Format(" ({0})", input2);
                    }

                    var displayName = EncodeAndHighlightKeyWords(input3, filterQuery, "<em>", "</em>");

                    if (!suggestList.Any(x => x.FilterQuery == input))
                    {
                        var addValue = new AutoSuggestItem()
                        {
                            DisplayName = displayName,
                            FilterQuery = input,
                            ResultCount = item.Value,
                            Type = type
                        };

                        suggestList.Add(addValue);

                        i++;
                    }
                }
                if (i > MaxCount)
                {
                    break;
                }
            }

            return suggestList;
        }
        /// <summary>
        /// Wraps matched strings in HTML span elements styled with a background-color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keywords">Whitespace-separated list of strings to be highlighted</param>
        /// <param name="cssClass">The Css color to apply</param>
        /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
        /// <returns>string</returns>
        private static string EncodeAndHighlightKeyWords(string text, string keywords, params string[] highlightBraces)
        {
            //Encode
            //text = encode(text);

            //Highlight
            if (text == String.Empty || keywords == String.Empty || highlightBraces == null || highlightBraces.Count() != 2)
                return text;
            var words = keywords.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return
                    words.Select(word => word.Trim()).Aggregate(text,
                             (current, pattern) =>
                             Regex.Replace(current,
                                             Regex.Escape(pattern),
                                               string.Format("§{0}?",
                                               "$0"),
                                               RegexOptions.IgnoreCase))
                                               .Replace("§", highlightBraces[0])
                                               .Replace("?", highlightBraces[1]);
        }
    }
}
