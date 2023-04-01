using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelDetails
    {
        public ArtikelDetails()
        {
            Artikel = new Artikel();
            Dokumente = new List<Dokument>();
            Links = new List<Link>();
            Gefahrguthinweise = new Dictionary<string, string>();
            SonstigeNummern = new ArtikelSonstigeNummern();
            Stuecklisten = new ArtikelStuecklisten();
            Tauschartikel = new ArtikelTauschartikel();
            VerwandteArtikel = new ArtikelVerwandteArtikel();
            Logistik = new ArtikelLogistik();
            VerwendetIn = new ArtikelVerwendetIn();
            Staffelpreise = new List<ArtikelStaffelpreis>();
        }

        public ArtikelDetails(Artikel artikel)
            : this()
        {
            Artikel = artikel;
        }

        [DataMember]
        public Artikel Artikel { get; set; }
        [DataMember]
        public ArtikelStuecklisten Stuecklisten { get; set; }
        [DataMember]
        public ArtikelTauschartikel Tauschartikel { get; set; }
        [DataMember]
        public ArtikelVerwandteArtikel VerwandteArtikel { get; set; }
        [DataMember]
        public ArtikelVerwendetIn VerwendetIn { get; set; }
        [DataMember]
        public ArtikelLogistik Logistik { get; set; }
        [DataMember]
        public Dictionary<string, string> Gefahrguthinweise { get; set; }
        [DataMember]
        public List<Dokument> Dokumente { get; set; }
        [DataMember]
        public List<Link> Links { get; set; }
        [DataMember]
        public ArtikelSonstigeNummern SonstigeNummern { get; set; }
        [DataMember]
        public List<ArtikelStaffelpreis> Staffelpreise { get; set; }

    }
}
