using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PvKatalogsystem.Services.Services.Solr.Documents.Artikel;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class DokumentMapper
    {
        private readonly static Regex _regexDokument = new Regex(@"^(\d+)¦(.*)¦(.*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled);

        internal static Dokument Map(string dokument)
        {
            return doMap(dokument);
        }

        internal static List<Dokument> Map(DokumentDoc dokumentDocument)
        {
            List<Dokument> dokumentList = new List<Dokument>();
            if (dokumentDocument.Dokument != null)
            {
                foreach (string dokument in dokumentDocument.Dokument)
                {
                    dokumentList.Add(doMap(dokument));
                }
            }
            return dokumentList;
        }

        private static Dokument doMap(string dokumentstring)
        {
            if (dokumentstring != null)
            {
                var match = _regexDokument.Match(dokumentstring);
                if (!match.Success)
                {
                    return null;
                }
                var dokument = new Dokument();
                dokument.Sortiernummer = long.Parse(match.Groups[1].Value);
                dokument.Dokumenttyp = match.Groups[2].Value;
                dokument.Bezeichnung = match.Groups[3].Value;
                dokument.Dateityp = match.Groups[4].Value;
                dokument.Dateiname = match.Groups[5].Value;
                dokument.Fileformat = match.Groups[6].Value;
                return dokument;
            }
            else
                return null;
        }
    }
}
