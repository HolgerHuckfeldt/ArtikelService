using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
   [Serializable]
   [DataContract]
    public class ArtikelVerwandteArtikel:DtoBase
    {
        public ArtikelVerwandteArtikel()
        {
            Kann = new List<Artikel>();
            Soll = new List<Artikel>();
            Muss = new List<Artikel>();
            Zubehoer = new List<Artikel>();
            CrossSelling = new List<Artikel>();
        }

        [DataMember]
        public List<Artikel> Kann { get; set; }
        [DataMember]
        public List<Artikel> Soll { get; set; }
        [DataMember]
        public List<Artikel> Muss { get; set; }
        [DataMember]
        public List<Artikel> Zubehoer { get; set; }
        [DataMember]
        public List<Artikel> CrossSelling { get; set; } 

        public override string ToString()
        {
            return string.Format("Kann: {0}, Soll: {1}, Muss: {2}, Zubehör: {3}, CrossSelling: {4}", Kann.Count, Soll.Count, Muss.Count, Zubehoer.Count,CrossSelling.Count);
        }
    }

   public class VerwandterArtikel
   {
       public Artikel Ursprungsartikel { get; set; }
       public VerwandterArtikelTyp Typ { get; set; }
       public decimal Menge { get; set; }
   }

   public enum VerwandterArtikelTyp
   {
       Muss = 1,
       Kann = 2,
       Soll = 3,
       Zubehoer = 4,
       CrossSelling = 5
   }

   public static class VerwandterArtikelTypConverter
   {
       public static string ConvertToSolr(VerwandterArtikelTyp typ)
       {
           switch (typ)
           {
               case VerwandterArtikelTyp.Muss:
                   return "M";
               case VerwandterArtikelTyp.Soll:
                   return "S";
               case VerwandterArtikelTyp.Zubehoer:
                   return "Z";
               case VerwandterArtikelTyp.CrossSelling:
                   return "C";
               default:
                   return "K";
           }
       }

       public static VerwandterArtikelTyp ConvertFromSolr(string typ)
       {
           switch (typ)
           {
               case "M":
                   return VerwandterArtikelTyp.Muss;
               case "S":
                   return VerwandterArtikelTyp.Soll;
               case "Z":
                   return VerwandterArtikelTyp.Zubehoer;
               case "C":
                   return VerwandterArtikelTyp.CrossSelling;
               default:
                   return VerwandterArtikelTyp.Kann;
           }
       }
   }
}
