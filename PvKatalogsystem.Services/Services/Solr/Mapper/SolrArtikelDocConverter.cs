using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using Absolute.SolrClient0900;
using Newtonsoft.Json.Linq;
using PvKatalogsystem.Services.Services.Solr.Documents.Artikel;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    public class SolrArtikelDocConverter : ISolrConvert
    {

        public object ConvertXml(XPathNodeIterator o, Dictionary<string, string> dynamicFieldMap)
        {
            ArtikelDoc result = new ArtikelDoc();

            while (o.MoveNext())
            {
                var fieldNode = o.Current;
                var fieldNodeName = fieldNode.SelectSingleNode("@name").Value;

                var key = fieldNodeName;

                if (dynamicFieldMap.ContainsKey(key))
                {
                    key = dynamicFieldMap[key];
                }
                switch (key)
                {
                    case "Id":
                        result.Id = GetNodeValue(fieldNode);
                        break;
                    case "AltteilKennzeichen":
                        result.AltteilKennzeichen = GetNodeValue(fieldNode);
                        break;
                    case "Artikelnummer":
                        result.Artikelnummer = GetNodeValue(fieldNode);
                        break;
                    case "ArtikelnummerSuche":
                        result.ArtikelnummerSuche = GetNodeValue(fieldNode);
                        break;
                    case "Bezeichnung":
                        result.Bezeichnung = GetNodeValue(fieldNode);
                        break;
                    case "EinheitenProVerpackung":
                        result.EinheitenProVerpackung = GetNodeValueInt(fieldNode);
                        break;
                    case "HasMaterialCertification":
                        result.HasMaterialCertification = GetNodeValueBool(fieldNode);
                        break;
                    case "Hersteller":
                        result.Hersteller = GetNodeValue(fieldNode);
                        break;
                    case "HerstellerHLK":
                        result.HerstellerHLK = GetNodeValue(fieldNode);
                        break;
                    case "HerstellerHLKSuche":
                        result.HerstellerHLKSuche = GetNodeValue(fieldNode);
                        break;
                    case "Herstellernummer":
                        result.Herstellernummer = GetNodeValueInt(fieldNode);
                        break;
                    case "DLNr":
                        result.DLNr = GetNodeValueInt(fieldNode);
                        break;
                    case "IsAltteil":
                        result.IsAltteil = GetNodeValueBool(fieldNode);
                        break;
                    case "IsIncentiveBundle":
                        result.IsIncentiveBundle = GetNodeValueBool(fieldNode);
                        break;
                    case "IsLieferbar":
                        result.IsLieferbar = GetNodeValueBool(fieldNode);
                        break;
                    case "IsStahlgruberArtikel":
                        result.IsStahlgruberArtikel = GetNodeValueBool(fieldNode);
                        break;
                    case "IsPseudoartikel":
                        result.IsPseudoartikel = GetNodeValueBool(fieldNode);
                        break;
                    case "IsRemanufacturedPart":
                        result.IsRemanufacturedPart = GetNodeValueBool(fieldNode);
                        break;
                    case "IsSelfServicePackage":
                        result.IsSelfServicePackage = GetNodeValueBool(fieldNode);
                        break;
                    case "IsVerpackungseinheitGanzzahl":
                        result.IsVerpackungseinheitGanzzahl = GetNodeValueBool(fieldNode);
                        break;
                    case "Katalognummer":
                        result.Katalognummer = GetNodeValue(fieldNode);
                        break;
                    case "MengeProEinheit":
                        result.MengeProEinheit = GetNodeValueDecimal(fieldNode);
                        break;
                    case "Pfandwert":
                        result.Pfandwert = GetNodeValueDouble(fieldNode);
                        break;
                    case "PitstopWarengruppe":
                        result.PitstopWarengruppe = GetNodeValue(fieldNode);
                        break;
                    case "PreiseinheitBezeichnung":
                        result.PreiseinheitBezeichnung = GetNodeValue(fieldNode);
                        break;
                    case "PreiseinheitMenge":
                        result.PreiseinheitMenge = GetNodeValueDecimal(fieldNode);
                        break;
                    case "PreisEinheitUmrechnungsFaktor":
                        result.PreisEinheitUmrechnungsFaktor = GetNodeValueDecimal(fieldNode);
                        break;
                    case "PvManagerGruppe":
                        result.PvManagerGruppe = GetNodeValueInt(fieldNode);
                        break;
                    case "MengenEinheitsFaktor":
                        result.MengenEinheitsFaktor = GetNodeValueDecimal(fieldNode);
                        break;
                    case "TechnischeMengeneinheitBezeichnung":
                        result.TechnischeMengeneinheitBezeichnung = GetNodeValue(fieldNode);
                        break;
                    case "VdbArtikelnummer":
                        result.VdbArtikelnummer = GetNodeValue(fieldNode);
                        break;
                    case "VdbArtikelzustand":
                        result.VdbArtikelzustand = GetNodeValueInt(fieldNode);
                        break;
                    case "VdbHerstellerkuerzel":
                        result.VdbHerstellerkuerzel = GetNodeValue(fieldNode);
                        break;
                    case "Verkaufspreis_*":
                        result.Verkaufspreis = GetNodeValueDecimal(fieldNode);
                        break;
                    case "Verkaufspreis_Kompass":
                        result.Verkaufspreis_Kompass = GetNodeValueDecimal(fieldNode);
                        break;
                    case "Verkaufspreis_KompassPitstop":
                        result.Verkaufspreis_KompassPitstop = GetNodeValueDecimal(fieldNode);
                        break;
                    case "Verkaufspreis_KompassStahlgruber":
                        result.Verkaufspreis_KompassStahlgruber = GetNodeValueDecimal(fieldNode);
                        break;
                    case "VerpackungseinheitBezeichnung":
                        result.VerpackungseinheitBezeichnung = GetNodeValue(fieldNode);
                        break;
                    case "Vorschaubild":
                        result.Vorschaubild = GetNodeValue(fieldNode);
                        break;
                    case "PitstopVorschaubild":
                        result.PitstopVorschaubild = GetNodeValue(fieldNode);
                        break;
                    case "Warengruppe":
                        result.Warengruppe = GetNodeValue(fieldNode);
                        break;

                    case "Zusatzbezeichnung":
                          {
                            result.Zusatzbezeichnung = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Zusatzbezeichnung.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "ZusatzbezeichnungB2C":
                        {
                            result.ZusatzbezeichnungB2C = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.ZusatzbezeichnungB2C.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;

                    case "Information":
                        {
                            result.Information = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Information.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;

                    case "Matchcode":
                        {
                            result.Matchcode = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Matchcode.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Herstellersortiernummer":
                        {
                            result.Herstellersortiernummer = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Herstellersortiernummer.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Gebrauchsnummer":
                        {
                            result.Gebrauchsnummer = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Gebrauchsnummer.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Aktionsnummer":
                        {
                            result.Aktionsnummer = new List<int?>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Aktionsnummer.Add(GetNodeValueInt(xArr.Current));
                            }
                        }
                        break;
                    case "Attributblock_*":
                        {
                            result.Attributblock = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Attributblock.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "VerwandteGenArtikel":
                        {
                            result.VerwandteGenArtikel = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.VerwandteGenArtikel.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "CsoCode":
                        {
                            result.CsoCode = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.CsoCode.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "EaNummer":
                        {
                            result.EaNummer = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.EaNummer.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "AktionsnummerKundengruppe_*":
                        {
                            result.AktionsnummerKundengruppe = new List<long>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.AktionsnummerKundengruppe.Add(GetNodeValueInt(xArr.Current));
                            }
                        }
                        break;
                    case "Logistikinfo_*":
                        {
                            result.Logistikinfo = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Logistikinfo.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "ReferenznummerSuche":
                        {

                            result.ReferenznummerSuche = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.ReferenznummerSuche.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Attribut":
                        {

                            result.Attribut = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Attribut.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Referenznummer":
                        {
                            result.Referenznummer = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Referenznummer.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Tauschartikel_*":
                        {
                            result.Tauschartikel = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Tauschartikel.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "ReferenznummerEindeutig":
                        {
                            result.ReferenznummerEindeutig = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.ReferenznummerEindeutig.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "VergleichsnummerEindeutig":
                        {
                            result.VergleichsnummerEindeutig = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.VergleichsnummerEindeutig.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Dokument":
                        {
                            result.Dokument = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Dokument.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "GebrauchsnummerSuche":
                        {
                            result.GebrauchsnummerSuche = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.GebrauchsnummerSuche.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "GebrauchsnummerEindeutig":
                        {
                            result.GebrauchsnummerEindeutig = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.GebrauchsnummerEindeutig.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Aktionsinfo":
                        {

                            result.Aktionsinfo = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Aktionsinfo.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "GenerischerArtikel":
                        {
                            result.GenerischerArtikel = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.GenerischerArtikel.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Vergleichsnummer":
                        {
                            result.Vergleichsnummer = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Vergleichsnummer.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Synonym":
                        {
                            result.Synonym = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Synonym.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Ersatzartikelnummer":
                        {
                            result.Ersatzartikelnummer = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Ersatzartikelnummer.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "Link":
                        {
                            result.Link = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.Link.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;
                    case "EaNummerEindeutig":
                        {
                            result.EaNummerEindeutig = new List<string>();
                            var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                            while (xArr.MoveNext())
                            {
                                result.EaNummerEindeutig.Add(GetNodeValue(xArr.Current));
                            }
                        }
                        break;

                    default:
                        
                        break;
                }

            }
            return result;
        }

        public object ConvertJson(JToken o, Dictionary<string, string> dynamicFieldMap)
        {

            string sOut = "";

            ArtikelDoc result = new ArtikelDoc();

            foreach (var child in o.Children())
            {

                if (child is JProperty)
                {
                    var s = (child as JProperty);

                    var key = s.Name;

                    if (dynamicFieldMap.ContainsKey(key))
                    {
                        key = dynamicFieldMap[key];
                    }

                    switch (key)
                    {

                        case "Id":
                            result.Id = s.Value.Value<string>();
                            break;
                        case "AltteilKennzeichen":
                            result.AltteilKennzeichen = s.Value.Value<string>();
                            break;
                        case "Artikelnummer":
                            result.Artikelnummer = s.Value.Value<string>();
                            break;
                        case "ArtikelnummerSuche":
                            result.ArtikelnummerSuche = s.Value.Value<string>();
                            break;
                        case "Bezeichnung":
                            result.Bezeichnung = s.Value.Value<string>();
                            break;
                        case "EinheitenProVerpackung":
                            result.EinheitenProVerpackung = s.Value.Value<int>();
                            break;
                        case "HasMaterialCertification":
                            result.HasMaterialCertification = s.Value.Value<bool>();
                            break;
                        case "Hersteller":
                            result.Hersteller = s.Value.Value<string>();
                            break;
                        case "HerstellerHLK":
                            result.HerstellerHLK = s.Value.Value<string>();
                            break;
                        case "HerstellerHLKSuche":
                            result.HerstellerHLKSuche = s.Value.Value<string>();
                            break;
                        case "Herstellernummer":
                            result.Herstellernummer = s.Value.Value<int>();
                            break;
                        case "DLNr":
                            result.DLNr = s.Value.Value<int>();
                            break;
                        case "IsAltteil":
                            result.IsAltteil = s.Value.Value<bool>();
                            break;
                        case "IsIncentiveBundle":
                            result.IsIncentiveBundle = s.Value.Value<bool>();
                            break;
                        case "IsLieferbar":
                            result.IsLieferbar = s.Value.Value<bool>();
                            break;
                        case "IsStahlgruberArtikel":
                            result.IsStahlgruberArtikel = s.Value.Value<bool>();
                            break;
                        case "IsPseudoartikel":
                            result.IsPseudoartikel = s.Value.Value<bool>();
                            break;
                        case "IsRemanufacturedPart":
                            result.IsRemanufacturedPart = s.Value.Value<bool>();
                            break;
                        case "IsSelfServicePackage":
                            result.IsSelfServicePackage = s.Value.Value<bool>();
                            break;
                        case "IsVerpackungseinheitGanzzahl":
                            result.IsVerpackungseinheitGanzzahl = s.Value.Value<bool>();
                            break;
                        case "Katalognummer":
                            result.Katalognummer = s.Value.Value<string>();
                            break;
                        case "MengeProEinheit":
                            result.MengeProEinheit = s.Value.Value<decimal>();
                            break;
                        case "Pfandwert":
                            result.Pfandwert = s.Value.Value<double>();
                            break;
                        case "PitstopWarengruppe":
                            result.PitstopWarengruppe = s.Value.Value<string>();
                            break;
                        case "PreiseinheitBezeichnung":
                            result.PreiseinheitBezeichnung = s.Value.Value<string>();
                            break;
                        case "PreiseinheitMenge":
                            result.PreiseinheitMenge = s.Value.Value<decimal>();
                            break;
                        case "PreisEinheitUmrechnungsFaktor":
                            result.PreisEinheitUmrechnungsFaktor = s.Value.Value<decimal>();
                            break;
                        case "PvManagerGruppe":
                            result.PvManagerGruppe = s.Value.Value<int>();
                            break;
                        case "MengenEinheitsFaktor":
                            result.MengenEinheitsFaktor = s.Value.Value<decimal>();
                            break;
                        case "TechnischeMengeneinheitBezeichnung":
                            result.TechnischeMengeneinheitBezeichnung = s.Value.Value<string>();
                            break;
                        case "VdbArtikelnummer":
                            result.VdbArtikelnummer = s.Value.Value<string>();
                            break;
                        case "VdbArtikelzustand":
                            result.VdbArtikelzustand = s.Value.Value<int>();
                            break;
                        case "VdbHerstellerkuerzel":
                            result.VdbHerstellerkuerzel = s.Value.Value<string>();
                            break;
                        case "Verkaufspreis_*":
                            result.Verkaufspreis = s.Value.Value<decimal>();
                            break;
                        case "Verkaufspreis_Kompass":
                            result.Verkaufspreis_Kompass = s.Value.Value<decimal>();
                            break;
                        case "Verkaufspreis_KompassPitstop":
                            result.Verkaufspreis_KompassPitstop = s.Value.Value<decimal>();
                            break;
                        case "Verkaufspreis_KompassStahlgruber":
                            result.Verkaufspreis_KompassStahlgruber = s.Value.Value<decimal>();
                            break;
                        case "VerpackungseinheitBezeichnung":
                            result.VerpackungseinheitBezeichnung = s.Value.Value<string>();
                            break;
                        case "Vorschaubild":
                            result.Vorschaubild = s.Value.Value<string>();
                            break;
                        case "PitstopVorschaubild":
                            result.PitstopVorschaubild = s.Value.Value<string>();
                            break;
                        case "Warengruppe":
                            result.Warengruppe = s.Value.Value<string>();
                            break;
                        case "Matchcode":
                            result.Matchcode = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Matchcode.Add(oo.Value<string>());

                            }
                            break;
                        case "Herstellersortiernummer":
                            result.Herstellersortiernummer = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Herstellersortiernummer.Add(oo.Value<string>());

                            }
                            break;
                        case "Gebrauchsnummer":
                            result.Gebrauchsnummer = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Gebrauchsnummer.Add(oo.Value<string>());

                            }
                            break;
                        case "Aktionsnummer":
                            result.Aktionsnummer = new List<int?>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Aktionsnummer.Add(oo.Value<int>());

                            }
                            break;
                        case "Attributblock_*":
                            result.Attributblock = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Attributblock.Add(oo.Value<string>());

                            }
                            break;
                        case "VerwandteGenArtikel":
                            result.VerwandteGenArtikel = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.VerwandteGenArtikel.Add(oo.Value<string>());

                            }
                            break;
                        case "CsoCode":
                            result.CsoCode = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.CsoCode.Add(oo.Value<string>());

                            }
                            break;
                        case "EaNummer":
                            result.EaNummer = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.EaNummer.Add(oo.Value<string>());

                            }

                            break;
                        case "AktionsnummerKundengruppe_*":
                            result.AktionsnummerKundengruppe = new List<long>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.AktionsnummerKundengruppe.Add(oo.Value<long>());

                            }
                            break;
                        case "Logistikinfo_*":
                            result.Logistikinfo = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Logistikinfo.Add(oo.Value<string>());

                            }
                            break;
                        case "ReferenznummerSuche":

                            result.ReferenznummerSuche = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.ReferenznummerSuche.Add(oo.Value<string>());

                            }
                            break;
                        case "Attribut":

                            result.Attribut = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Attribut.Add(oo.Value<string>());

                            }
                            break;
                        case "Referenznummer":

                            result.Referenznummer = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Referenznummer.Add(oo.Value<string>());

                            }
                            break;
                        case "Tauschartikel_*":
                            result.Tauschartikel = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Tauschartikel.Add(oo.Value<string>());

                            }
                            break;
                        case "ReferenznummerEindeutig":
                            result.ReferenznummerEindeutig = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.ReferenznummerEindeutig.Add(oo.Value<string>());

                            }
                            break;
                        case "VergleichsnummerEindeutig":
                            result.VergleichsnummerEindeutig = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.VergleichsnummerEindeutig.Add(oo.Value<string>());

                            }
                            break;
                        case "Dokument":
                            result.Dokument = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Dokument.Add(oo.Value<string>());

                            }
                            break;
                        case "GebrauchsnummerSuche":
                            result.GebrauchsnummerSuche = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.GebrauchsnummerSuche.Add(oo.Value<string>());

                            }
                            break;
                        case "GebrauchsnummerEindeutig":
                            result.GebrauchsnummerEindeutig = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.GebrauchsnummerEindeutig.Add(oo.Value<string>());

                            }
                            break;
                        case "Aktionsinfo":

                            result.Aktionsinfo = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Aktionsinfo.Add(oo.Value<string>());

                            }
                            break;
                        case "GenerischerArtikel":

                            result.GenerischerArtikel = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.GenerischerArtikel.Add(oo.Value<string>());

                            }
                            break;
                        case "Vergleichsnummer":

                            result.Vergleichsnummer = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Vergleichsnummer.Add(oo.Value<string>());

                            }
                            break;
                        case "Synonym":

                            result.Synonym = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Synonym.Add(oo.Value<string>());

                            }
                            break;
                        case "Ersatzartikelnummer":

                            result.Synonym = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                // result.Ersatzartikelnummer.Add(oo.Value<string>());

                            }
                            break;
                        case "Link":
                            result.Link = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.Link.Add(oo.Value<string>());

                            }
                            break;
                        case "EaNummerEindeutig":
                            result.EaNummerEindeutig = new List<string>();
                            foreach (var oo in s.Value.Values())
                            {
                                result.EaNummerEindeutig.Add(oo.Value<string>());

                            }
                            break;

                        default:
                            sOut += "case \"" + (child as JProperty).Name + "\":\r\n" +
                                    "result." + s.Name + "=" + "s.Value<string>();\r\n" +

                                    " break;\r\n";

                            break;

                    }
                }
                else
                {

                }

            }

            return result;
        }

        private static string GetNodeValue(XPathNavigator node)
        {
            var value = node.Value;
            if (node.Name == "double")
            {
                value = value.Replace(".", ",");
            }
            return value;
        }

        private static int GetNodeValueInt(XPathNavigator node)
        {
            return (int)System.Convert.ChangeType(node.Value, typeof(int));
        }

        private static bool GetNodeValueBool(XPathNavigator node)
        {
            return (bool)System.Convert.ChangeType(node.Value, typeof(bool));
        }

        private static double GetNodeValueDouble(XPathNavigator node)
        {
            return (double)System.Convert.ChangeType(node.Value, typeof(double), NumberFormatInfo.InvariantInfo);
        }

        private static decimal GetNodeValueDecimal(XPathNavigator node)
        {
            return (decimal)System.Convert.ChangeType(node.Value, typeof(decimal),NumberFormatInfo.InvariantInfo);
        }

    }
}
