using System;
using System.Collections.Generic;
using PvKatalogsystem.Types.Enums;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class VdbArtikelinformationen : DtoBase
    {
        public VdbArtikelinformationen()
        {
            Bonuspunkte = new List<Bonustyp>();
            Identifikator = new VdbArtikelidentifikator();
        }

        [DataMember]
        public VdbArtikelidentifikator Identifikator { get; set; }
        [DataMember]
        public string Bezeichnung { get; set; }
        [DataMember]
        public decimal EkPreis { get; set; }
        [DataMember]
        public decimal Streichpreis { get; set; }
        [DataMember]
        public bool HasStaffelpreise { get; set; }
        [DataMember]
        public VdbVerfuegbarkeit Bestellverfuegbarkeit { get; set; }
        [DataMember]
        public VdbVerfuegbarkeit Abholverfuegbarkeit { get; set; }
        [DataMember]
        public List<Bonustyp> Bonuspunkte { get; set; }
        /// <summary>
        /// Sind die Infos von der Vdb geladen worden?
        /// </summary>
        [DataMember]
        public bool HasLoaded { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1:c}, Bestellverfügbarkeit: {2}, Abholverfügbarkeit: {3} {4}", Identifikator, EkPreis, Bestellverfuegbarkeit, Abholverfuegbarkeit, HasLoaded ? "(HasLoaded)" : "");
        }
    }
}
