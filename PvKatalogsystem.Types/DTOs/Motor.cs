using System;

namespace PvKatalogsystem.Types.DTOs
{
    public class Motor : DtoBase
    {
        public int Id { get; set; }
        public int Motornummer { get; set; }
        public Fahrzeughersteller Hersteller { get; set; }
        public DateTime? BaujahrVon { get; set; }
        public DateTime? BaujahrBis { get; set; }
        public int? HubraumVon { get; set; }  //ccm
        public int? HubraumBis { get; set; }  //ccm
        public int? LeistungKwVon { get; set; }
        public int? LeistungPsVon { get; set; }
        public int? LeistungKwBis { get; set; }
        public int? LeistungPsBis { get; set; }
        public string Motorart { get; set; }
        public string Kraftstoffart { get; set; }
        public string Motorcode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Id, Hersteller);
        }
    }
}
