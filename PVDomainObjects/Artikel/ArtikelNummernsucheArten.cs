using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ArtikelNummernsucheArten
    {
        public ArtikelNummernsucheArten()
        {
            ServiceRequestArten = new List<string>();
        }

        [DataMember]
        public bool Nummernsuche_Artikelnummer { get; set; }
        [DataMember]
        public bool Nummernsuche_Gebrauchsnummer { get; set; }
        [DataMember]
        public bool Nummernsuche_Vergleichsnummer { get; set; }
        [DataMember]
        public bool Nummernsuche_Referenznummer { get; set; }
        [DataMember]
        public bool Nummernsuche_EANummer { get; set; }
        [DataMember]
        public bool Nummernsuche_Eindeutig { get; set; }
        [DataMember]
        public bool Nummernsuche_Matchcode { get; set; }

        [DataMember]
        public int? Typ { get; set; }

        [DataMember]
        public int? VehicleId { get; set; }

        [DataMember]
        public ArtikelArt Art { get; set; }

        [DataMember]
        public string Suchstring { get; set; }

        [DataMember]
        public string ArtikelnummerMitTrennzeichen { get; set; }

        [DataMember]
        public string Hersteller { get; set; }

        [DataMember]
        public List<string> ServiceRequestArten { get; set; }

        [DataMember]
        public bool Mobile { get; set; }

		[DataMember]
		public string TeaserTyp { get; set; }

        [DataMember]
        public DateTime StatistikEingetragen { get; set; }
	}

    [DataContract]
    [Serializable]
    public class ArtikelOENummerForDVSE
    {
        [DataMember]
        public int? Typ { get; set; }

        [DataMember]
        public int? VehicleId { get; set; }

        [DataMember]
        public ArtikelArt Art { get; set; }

        [DataMember]
        public string Suchstring { get; set; }

        [DataMember]
        public string Hersteller { get; set; }

    }
}
