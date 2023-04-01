using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Stuecklistenartikel
    {
        public Stuecklistenartikel(Artikel artikel)
        {
            Ursprungsartikel = artikel;
        }

        [DataMember]
        public Artikel Ursprungsartikel { get; set; }
        [DataMember]
        public decimal Menge { get; set; }
        [DataMember]
        public long Sortiernummer { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}: {2} {3}", Ursprungsartikel.Artikelnummer, Ursprungsartikel.Bezeichnung, Menge, Ursprungsartikel.Mengeneinheitsbezeichnung);
        }
    }
}
