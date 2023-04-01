using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class FahrzeugmodellMapper
    {
        private static readonly Regex _regexItems = new Regex("^(.+)¦(.+)$", RegexOptions.Compiled);
        private static readonly Regex _regexModell = new Regex(@"^(.+)\{(\d+)\}\{([\d\.]*)\}\{([\d\.]*)\}$", RegexOptions.Compiled);
        private static readonly Regex _regexModell1 = new Regex(@"^{(\d+)\}\{([\d\.]*)\}\{([\d\.]*)\}$", RegexOptions.Compiled);
        private static readonly Regex _regexDate = new Regex(@"^(\d{2})\.(\d{4})$", RegexOptions.Compiled);

        public static Fahrzeugmodell Map(string docBreadcrumb)
        {
            var match = _regexItems.Match(docBreadcrumb);
            if (!match.Success)
            {
                return null;
            }
            var hersteller = FahrzeugherstellerMapper.Map(match.Groups[1].Value);

            var modelString = match.Groups[2].Value;

            match = _regexModell.Match(modelString);
            if (!match.Success)
            {
                match = _regexModell1.Match(modelString);

                if (!match.Success)
                    return null;

                var modell1 = new Fahrzeugmodell();
                //modell1.Bezeichnung = match.Groups[1].Value;
                modell1.Id = int.Parse(match.Groups[1].Value);
                var matchDate1 = _regexDate.Match(match.Groups[2].Value);
                if (matchDate1.Success)
                {
                    modell1.BaujahrVon = new DateTime(int.Parse(matchDate1.Groups[2].Value), int.Parse(matchDate1.Groups[1].Value), 1);
                }
                matchDate1 = _regexDate.Match(match.Groups[4].Value);
                if (matchDate1.Success)
                {
                    modell1.BaujahrBis = new DateTime(int.Parse(matchDate1.Groups[2].Value), int.Parse(matchDate1.Groups[1].Value), 1);
                }
                modell1.Hersteller = hersteller;
                return modell1;

            }

            var modell = new Fahrzeugmodell();
            modell.Bezeichnung = match.Groups[1].Value;

            modell.Id = int.Parse(match.Groups[2].Value);

            //File.AppendAllText( outFileName, modell.Id + ";" + modell.Bezeichnung + "\r\n");


            var matchDate = _regexDate.Match(match.Groups[3].Value);
            if (matchDate.Success)
            {
                modell.BaujahrVon = new DateTime(int.Parse(matchDate.Groups[2].Value), int.Parse(matchDate.Groups[1].Value), 1);
            }
            matchDate = _regexDate.Match(match.Groups[4].Value);
            if (matchDate.Success)
            {
                modell.BaujahrBis = new DateTime(int.Parse(matchDate.Groups[2].Value), int.Parse(matchDate.Groups[1].Value), 1);
            }
            modell.Hersteller = hersteller;
            return modell;
        }
    }
}
