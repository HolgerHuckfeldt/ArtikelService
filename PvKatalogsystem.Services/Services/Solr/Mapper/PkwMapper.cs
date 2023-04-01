using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class PkwMapper
    {
        internal static Pkw Map(PkwDoc doc)
        {
            var pkw = new Pkw();
            pkw.Id = int.Parse(doc.Id);
            pkw.Typ = doc.Bezeichnung;
            if (!string.IsNullOrEmpty(doc.Breadcrumb))
            {
                pkw.Modell = FahrzeugmodellMapper.Map(doc.Breadcrumb);
            }
            if (doc.Motorcode != null)
            {
                pkw.Motorcodes = doc.Motorcode.ToList();
            }
            pkw.Bauart = doc.Bauart;
            pkw.BaujahrVon = doc.BaujahrMin;
            pkw.BaujahrBis = doc.BaujahrMax;
            pkw.Hubraum = doc.Hubraum;
            pkw.Kraftstoffart = doc.Kraftstoffart;
            pkw.KTypNummer = doc.KTypNummer;
            pkw.LeistungKw = doc.LeistungKw;
            pkw.LeistungPs = doc.LeistungPs;
            pkw.Zylinder = doc.Zylinder;
            pkw.Ventile = doc.Ventile;
            pkw.Motorart = doc.Motorart;
            pkw.Kraftstoffaufbereitung = doc.Kraftstoffaufbereitung;
            pkw.Antriebsart = doc.Antriebsart;
            

            if (doc.KbaNummer != null)
            {
                pkw.KbaNummern = doc.KbaNummer.ToList();
            }

            return pkw;
        }

        internal static List<Pkw> Map(IEnumerable<PkwDoc> docList)
        {
            var result = new List<Pkw>();
            foreach (var doc in docList)
            {
                if (doc != null)
                    result.Add(Map(doc));
            }

            //var l1 = result.Where(s => s.Modell == null).ToList();
            //var l2 = result.Where(s => s.Modell != null && s.Modell.Hersteller == null).ToList();
            //var l3 = result.Where(s => s.Typ == null).ToList();

            //Sort List of PKW: brand then model then typ
            var sortedResult = result.OrderBy(x => (x.Modell != null && x.Modell.Hersteller!=null) ? x.Modell.Hersteller.Name:"XXXX").ThenBy(x => x.Modell != null?x.Modell.Bezeichnung:"").ThenBy(x => x.Typ ?? "").ToList();

            return sortedResult;
        }
    }
}
