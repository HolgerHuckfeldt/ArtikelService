using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class FahrzeugherstellerMapper
    {
        private static readonly Regex _regexHersteller = new Regex(@"^(.+)\{(\d+)\}$", RegexOptions.Compiled);

        internal static Fahrzeughersteller Map(string docHersteller)
        {
            var match = _regexHersteller.Match(docHersteller);
            if (!match.Success)
            {
                return null;
            }
            var hersteller = new Fahrzeughersteller();
            hersteller.Name = match.Groups[1].Value;
            hersteller.Id = int.Parse(match.Groups[2].Value);
            return hersteller;
        }
    }
}
