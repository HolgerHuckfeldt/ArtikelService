using PvKatalogsystem.Types.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AutoSuggestItem = PvKatalogsystem.Types.Results.AutoSuggestItem;
using AutoSuggestItemTypes = PvKatalogsystem.Types.Enums.AutoSuggestItemTypes;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class SpellCheckingMapper
    {
        //private const char DELIMITER = '¦';
        //private readonly static Regex _regex = new Regex(@"^(.+)\{(\d+)}$", RegexOptions.Compiled);
        //private readonly static Regex _regexSynonym = new Regex(@"^(\d+)" + DELIMITER + "(.*)");

        //public static List<SpellcheckResultDto> Map(List<SpellcheckResult> resultOfSpellcheck)
        //{
        //    List<SpellcheckResultDto> returnList = new List<SpellcheckResultDto>();
        //    int freq = 0;
        //    foreach (var res in resultOfSpellcheck.Where(x => x.Word != null && x.Word.Length > 1))
        //    {
        //        freq = 0;
        //        //int.TryParse(res.Freq, out freq);
        //        returnList.Add(new SpellcheckResultDto
        //        {
        //            Freq = freq,
        //            Word = res.Word,
        //            WordDisplay = char.ToUpper(res.Word[0]) + res.Word.Substring(1)
        //        });
        //    }

        //    return returnList.ToList();
        //}

        //public static List<AutoSuggestItem> MapAutosuggest(List<SpellcheckResult> resultOfSpellcheck, AutoSuggestItemTypes type)
        //{
        //    List<AutoSuggestItem> returnList = new List<AutoSuggestItem>();
        //    int freq = 0;
        //    foreach (var res in resultOfSpellcheck.Where(x => x.Word != null && x.Word.Length > 1))
        //    {
        //        freq = 0;
        //        //int.TryParse(res.Freq, out freq);
        //        returnList.Add(new AutoSuggestItem
        //        {
        //            ResultCount = freq,
        //            FilterQuery = res.Word,
        //            DisplayName = char.ToUpper(res.Word[0]) + res.Word.Substring(1),
        //            Type = type,
        //            IsAutosuggestAusSpellcheck = true
        //        });
        //    }

        //    return returnList.ToList();
        //}

        //public static IEnumerable<AutoSuggestItem> MapFacetFields(IDictionary<string, int> facetResult, List<string> suggestListValue,
        //    IDictionary<string, int> facetResultSynonym = null, AutoSuggestItemTypes type = AutoSuggestItemTypes.Kategorie_Uni)
        //{
        //    var suggestList = new List<AutoSuggestItem>();
        //    var synonymBezList = new Dictionary<string, string>();

        //    if (facetResultSynonym != null && facetResultSynonym.Count() > 0)
        //    {
        //        foreach (var key in facetResultSynonym.Select(x => x.Key))
        //        {
        //            var match = _regexSynonym.Match(key);
        //            if (!match.Success)
        //            {
        //                continue;
        //            }
        //            var displayName = match.Groups[2].Value.ToString();

        //            if (!synonymBezList.Any(x => x.Key == match.Groups[1].Value) && suggestListValue.Any(x => x == displayName))
        //            {
        //                synonymBezList.Add(match.Groups[1].Value, displayName);
        //            }
        //        }
        //    }

        //    int genArtId = 0;
        //    foreach (var item in facetResult)
        //    {
        //        var input = string.Empty;
        //        var values = item.Key.Split(DELIMITER);
        //        var filter = string.Empty;

        //        input = values[values.Length - 2];
        //        filter = (item.Key.Length >= 4) ? item.Key.Substring(4) : null;

        //        var match = _regex.Match(input);
        //        if (!match.Success)
        //        {
        //            continue;
        //        }

        //        var displayName = match.Groups[1].ToString();

        //        genArtId = int.Parse(match.Groups[2].Value);
        //        if (!suggestList.Any(x => x.GenArtId == genArtId))
        //        {
        //            var addValue = new AutoSuggestItem()
        //            {
        //                DisplayName = displayName,
        //                FilterQuery = filter,
        //                OriginalName = displayName.ToLower(),
        //                ResultCount = item.Value,
        //                Type = type,
        //                GenArtId = genArtId
        //            };

        //            if (synonymBezList.ContainsKey(addValue.GenArtId.ToString()))
        //            {
        //                addValue.SynonymName += string.Format("{0}", synonymBezList[addValue.GenArtId.ToString()]);
        //                addValue.OriginalName += string.Format(" ({0})", synonymBezList[addValue.GenArtId.ToString()].ToLower());
        //            }

        //            suggestList.Add(addValue);
        //        }
        //    }

        //    return suggestList;
        //}

        //public static IEnumerable<AutoSuggestItem> MapFacetFieldsHersteller(IDictionary<string, int> facetResult, AutoSuggestItemTypes type)
        //{
        //    var suggestList = new List<AutoSuggestItem>();

        //    int genArtId = 0;
        //    foreach (var item in facetResult)
        //    {
        //        var input = string.Empty;
        //        var values = item.Key.Split('¦');

        //        switch (type)
        //        {
        //            case AutoSuggestItemTypes.HerstellerUni:
        //            case AutoSuggestItemTypes.HerstellerFahrzeug:
        //                input = values[0];
        //                break;
        //        }

        //        var match = _regex.Match(input);
        //        if (!match.Success)
        //        {
        //            continue;
        //        }

        //        var displayName = match.Groups[1].ToString();

        //        genArtId = int.Parse(match.Groups[2].Value);
        //        if (!suggestList.Any(x => x.GenArtId == genArtId))
        //        {
        //            var addValue = new AutoSuggestItem()
        //            {
        //                DisplayName = displayName,
        //                FilterQuery = displayName,
        //                OriginalName = displayName.ToLower(),
        //                ResultCount = item.Value,
        //                Type = type,
        //                GenArtId = genArtId
        //            };

        //            suggestList.Add(addValue);
        //        }
        //    }

        //    return suggestList;
        //}
    }
}
