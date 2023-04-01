using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using PvKatalogsystem.Services.Services.Solr.Documents.Fahrzeug;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
    internal class MotorMapper
    {
        internal static Motor Map(MotorDoc doc)
        {
            var motor = new Motor();
            motor.Id = int.Parse(doc.Id);
            motor.BaujahrBis = doc.BaujahrMax;
            motor.BaujahrVon = doc.BaujahrMin;
            if (!string.IsNullOrEmpty(doc.Hersteller))
            {
                motor.Hersteller = FahrzeugherstellerMapper.Map(doc.Hersteller);
            }
            motor.HubraumVon = doc.HubraumMin;
            motor.HubraumBis = doc.HubraumMax;
            motor.Kraftstoffart = doc.Kraftstoffart;
            motor.LeistungKwBis = doc.LeistungKwMax;
            motor.LeistungKwVon = doc.LeistungKwMin;
            motor.LeistungPsBis = doc.LeistungPsMax;
            motor.LeistungPsVon = doc.LeistungPsMin;
            motor.Motorart = doc.Motorart;
            motor.Motorcode = doc.Motorcode;
            motor.Motornummer = doc.Motornummer;
            return motor;
        }

        internal static List<Motor> Map(IEnumerable<MotorDoc> docList)
        {
            var result = new List<Motor>();
            foreach (var doc in docList)
            {
                result.Add(Map(doc));
            }
            return result;
        }
    }
}
