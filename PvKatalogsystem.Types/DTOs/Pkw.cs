using System;
using System.Collections.Generic;

namespace PvKatalogsystem.Types.DTOs
{
    public class Pkw : DtoBase
    {
        public Pkw()
        {
            Motorcodes = new List<string>();
        }
        public int Id { get; set; }
        public int KTypNummer { get; set; }
        public Fahrzeugmodell Modell { get; set; }
        public string Typ { get; set; }
        public DateTime? BaujahrVon { get; set; }
        public DateTime? BaujahrBis { get; set; }
        public int?  LeistungKw { get; set; }
        public int? LeistungPs { get; set; }
        public int? Zylinder { get; set; }
        public int? Ventile { get; set; }
        public int? Hubraum { get; set; }     //ccm
        public List<string> Motorcodes { get; set; }
        public string Kraftstoffart { get; set; }
        public string Bauart { get; set; }
        public string Motorart { get; set; }
        public string Kraftstoffaufbereitung { get; set; }
        public string Antriebsart { get; set; }
        public List<string> KbaNummern { get; set; }


        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", Id, Modell.Bezeichnung, Typ);
        }
    }
}
