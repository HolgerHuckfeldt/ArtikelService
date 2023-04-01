using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using PvKatalogsystem.Types.Enums;
using PvKatalogsystem.Services.Services.Solr.Documents.Artikel;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class ArtikelDetailsMapper
    {
        private readonly static Regex _regexTauschartikel = new Regex(@"^(PV|TECDOC)¦([\d\-:Z\040]*)¦(\d*)$", RegexOptions.Compiled);
        private readonly static Regex _regexVerwandteArtikel = new Regex(@"^([KSMZC]{1})¦(\d{1})¦([01]{1})¦(\d*)¦(\d*)$", RegexOptions.Compiled); //K¦1¦0¦27898333¦1
        private readonly static Regex _regexVerwandteArtikelGrad = new Regex(@"^.¦(\d*)", RegexOptions.Compiled);
        private readonly static Regex _regexLink = new Regex(@"^(\d*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled);
        private readonly static Regex _regexGefahrgutinformation = new Regex(@"^(.*)¦(.*)$", RegexOptions.Compiled);
        private readonly static Regex _regexGebrauchsnummer = new Regex(@"^[01]+¦(.*)$", RegexOptions.Compiled);
        private readonly static Regex _regexLogistikinformation = new Regex(@"^(.*)¦(.*)$", RegexOptions.Compiled);
        private readonly static Regex _regexReferenznummer = new Regex(@"^(.+)¦(.+)$", RegexOptions.Compiled);
        private readonly static Regex _regexErsatzartikelnummer = new Regex(@"^(OLD|NEW)¦(.*)$", RegexOptions.Compiled);

        public static ArtikelDetails Map(ArtikelDoc doc, IEnumerable<Artikel> subArtikel, bool isPitstop = false)
        {
            var artikel = ArtikelMapper.Map(doc, isPitstop: isPitstop);
            if (artikel == null)
            {
                return null;
            }
            var artikelDetails = new ArtikelDetails(artikel);
            
            // Stücklisten Artikel
            MapStueckliste(doc, subArtikel, artikelDetails);

            // Tauschartikel Ids
            MapTauschartikel(doc, subArtikel, artikelDetails);

            // Verwandte Artikel Ids
            MapVerwandteArtikel(doc, subArtikel, artikelDetails);
            
            // Dokumente
            MapDokumente(doc, artikelDetails);
            
            // Links
            MapLinks(doc, artikelDetails);
            
            // Gefahrgut
            MapGefahrgutinfos(doc, artikelDetails);
            
            // Logistik
            MapLogistikinfos(doc, artikelDetails);
            
            // Nummern
            MapNummern(doc, artikelDetails);

            return artikelDetails;
        }

        private static void MapNummern(ArtikelDoc doc, ArtikelDetails artikelDetails)
        {
            var nummern = new ArtikelSonstigeNummern();

            if (doc.Gebrauchsnummer != null)
            {
                foreach (var item in doc.Gebrauchsnummer)
                {
                    var match = _regexGebrauchsnummer.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var nummer = match.Groups[1].Value;
                    nummern.Gebrauchsnummern.Add(nummer);
                }
            }

            if (doc.EaNummer != null)
            {
                nummern.EaNummern = doc.EaNummer.ToList();
            }

            if (doc.Referenznummer != null)
            {
                foreach (var item in doc.Referenznummer)
                {
                    var match = _regexReferenznummer.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var nummer = new Referenznummer();
                    nummer.Hersteller = match.Groups[1].Value;
                    nummer.Nummer = match.Groups[2].Value;
                    nummern.OeReferenznummern.Add(nummer);
                }
            }

            if (doc.Vergleichsnummer != null)
            {
                nummern.Vergleichsnummern = doc.Vergleichsnummer.ToList();
            }

            if (doc.Ersatzartikelnummer != null)
            {
                foreach (var item in doc.Ersatzartikelnummer)
                {
                    var match = _regexErsatzartikelnummer.Match(item);
                    if (!match.Success)
                    { 
                        continue;
                    }
                    var typ = match.Groups[1].Value;
                    var nummer = match.Groups[2].Value;
                    switch (typ)
                    {
                        case "OLD":
                            nummern.ErsetzteArtikelnummern.Add(nummer);
                            break;
                        case "NEW":
                            nummern.ErsetzendeArtikelnummern.Add(nummer);
                            break;
                    }
                }
            }
            artikelDetails.SonstigeNummern = nummern;
        }

        private static void MapLogistikinfos(ArtikelDoc doc, ArtikelDetails artikelDetails)
        {
            if (doc.Logistikinfo != null)
            {
                artikelDetails.Logistik = new ArtikelLogistik();
                foreach (var item in doc.Logistikinfo)
                {
                    var match = _regexLogistikinformation.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var key = match.Groups[1].Value;
                    var value = match.Groups[2].Value;
                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    artikelDetails.Logistik.Verpackungseinheiten.Add(new KeyValuePair<string, string>(key, decimal.Parse(value).ToString(".##")));
                }
            }
        }

        private static void MapGefahrgutinfos(ArtikelDoc doc, ArtikelDetails artikelDetails)
        {
            if (doc.Gefahrgutinformation != null)
            {
                artikelDetails.Gefahrguthinweise = new Dictionary<string, string>();
                foreach (var item in doc.Gefahrgutinformation)
                {
                    var match = _regexGefahrgutinformation.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var key = match.Groups[1].Value;
                    var value = match.Groups[2].Value;
                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value) || artikelDetails.Gefahrguthinweise.ContainsKey(key))
                    {
                        continue;
                    }
                    artikelDetails.Gefahrguthinweise.Add(key, value);
                }
            }
        }

        private static void MapLinks(ArtikelDoc doc, ArtikelDetails artikelDetails)
        {
            if (doc.Link != null)
            {
                foreach (var item in doc.Link)
                {
                    var match = _regexLink.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var link = new Link();
                    link.Sortiernummer = long.Parse(match.Groups[1].Value);
                    link.Bezeichnung = match.Groups[2].Value;
                    link.Uri = match.Groups[3].Value;
                    link.Beschreibung = match.Groups[4].Value;
                    artikelDetails.Links.Add(link);
                }
            }
        }

        private static void MapDokumente(ArtikelDoc doc, ArtikelDetails artikelDetails)
        {
            if (doc.Dokument != null)
            {
                foreach (string dokument in doc.Dokument)
                {
                    artikelDetails.Dokumente.Add(DokumentMapper.Map(dokument));
                }
            }
        }

        private static void MapVerwandteArtikel(ArtikelDoc doc, IEnumerable<Artikel> subArtikel, ArtikelDetails artikelDetails)
        {
            if (doc.VerwandteArtikel != null)
            {
                var verwandteArtikel = new ArtikelVerwandteArtikel();
                // Erst nach Grad sortieren
                var list = doc.VerwandteArtikel.ToList();
                list.Sort(delegate(string a, string b)
                {
                    var matchA = _regexVerwandteArtikelGrad.Match(a);
                    var matchB = _regexVerwandteArtikelGrad.Match(b);
                    if (!matchA.Success && !matchB.Success) return 0;
                    if (!matchA.Success) return -1;
                    if (!matchB.Success) return 1;
                    return a.CompareTo(b);
                });
                // In die jeweilige Liste einsortieren
                foreach (var item in doc.VerwandteArtikel)
                {
                    var match = _regexVerwandteArtikel.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var id = match.Groups[4].Value;
                    var artikel = subArtikel.FirstOrDefault(x => x.Id.ToString() == id);
                    if (artikel == null)
                    {
                        continue;
                    }
                    var typ = match.Groups[1].Value;
                    switch (typ)
                    {
                        case "K":
                            verwandteArtikel.Kann.Add(artikel);
                            break;
                        case "S":
                            verwandteArtikel.Soll.Add(artikel);
                            break;
                        case "M":
                            verwandteArtikel.Muss.Add(artikel);
                            break;
                        case "Z":
                            verwandteArtikel.Zubehoer.Add(artikel);
                            break;
                        case "C":
                            verwandteArtikel.CrossSelling.Add(artikel);
                            break;
                    }
                }
                artikelDetails.VerwandteArtikel = verwandteArtikel;
            }
        }

        private static void MapStueckliste(ArtikelDoc doc, IEnumerable<Artikel> subArtikel, ArtikelDetails artikelDetails)
        {
            if (doc.Stueckliste != null)
            {
                var listen = ArtikelStuecklistenMapper.Map(doc.Stueckliste, subArtikel);
                artikelDetails.Stuecklisten = listen;
            }
        }

        private static void MapTauschartikel(ArtikelDoc doc, IEnumerable<Artikel> subArtikel, ArtikelDetails artikelDetails)
        {
            if (doc.Tauschartikel != null)
            {
                var tauschartikel = new ArtikelTauschartikel();
                foreach (var item in doc.Tauschartikel)
                {
                    var match = _regexTauschartikel.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var id = match.Groups[3].Value;
                    var artikel = subArtikel.FirstOrDefault(x => x.Id.ToString() == id);
                    if (artikel == null)
                    {
                        continue;
                    }
                    var typ = match.Groups[1].Value;
                    var abDatum = DateTime.Parse(match.Groups[2].Value);
                    if (abDatum > DateTime.Now)
                    {
                        continue;
                    }
                    switch (typ)
                    {
                        case "PV":
                            tauschartikel.PvTauschartikel.Add(artikel);
                            break;
                        case "TECDOC":
                            tauschartikel.TecdocTauschartikel.Add(artikel);
                            break;
                    }
                }
                artikelDetails.Tauschartikel = tauschartikel;
            }
        }
    }
}
