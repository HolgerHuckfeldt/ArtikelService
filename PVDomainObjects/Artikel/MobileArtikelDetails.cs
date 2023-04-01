using PV.DomainObjects.Common;
using PV.DomainObjects.Warenkorb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    public class MobileArtikelDetails : MobileArtikel
    {
        public MobileArtikelDetails()
        {

        }

        public MobileArtikelDetails(Artikel o)
        {
            this.ArtikelId = o.ArtikelId;
            this.Artikelnummer = o.ArtikelNummer;
            this.VDBArtikelnummer = o.VDBArtikelNummer;
            this.EKPreis = o.EKPreis;
            this.Kriterien = o.Kriterien;
            this.TypKriterien = o.TypKriterien;
            this.Dokumente = o.Dokumente;
            this.Bilder = o.Bilder;
            this.HerstellerKurzName = o.HerstellerName;
            this.Bezeichnung = o.Bezeichnung;
            this.HLK = o.HLK;
            this.VKPreis = o.VKPreis;
            this.GenArtBezeichnung = o.GenArtBezeichnung;
            this.Verfuegbarkeit = o.Verfuegbarkeit;
            this.MengeneinheitBezeichnung = o.MengeneinheitBezeichnung;
            this.MengeneinheitFaktor = o.MengeneinheitFaktor;
            this.MengeneinheitSchluessel = o.MengeneinheitSchluessel;
            this.TechMengeneinheitBezeichnung = o.TechMengeneinheitBezeichnung;
            this.TechMengeneinheitFaktor = o.TechMengeneinheitFaktor;
            this.TechMengeneinheitSchluessel = o.TechMengeneinheitSchluessel;
            this.Dokumente = o.Dokumente;
            this.Links = o.Links;
            this.EinheitenProVerpackung = o.EinheitenProVerpackung;
            this.MengeProEinheit = o.MengeProEinheit;
            this.Einheit = o.Einheit;
            this.Verpackungsart = o.Verpackungsart;
            this.KZSB = o.KZSB;
            this.KZAT = o.KZAT;
            this.KZMat = o.KZMat;
            this.KZZub = o.KZZub;
            this.PreiseinheitFaktor = o.PreiseinheitFaktor;
            this.InvPreiseinheitFaktor = PreiseinheitFaktor == 0 ? 0 : 1 / PreiseinheitFaktor; 

            this.VerwandteArtikel = new List<MobileArtikel>();
            Logistik = new List<SerializableDictionary>();
            ArtikelInformationen = new List<SerializableDictionary>();

            if (o.ArtikelInformationenOhneRTF != null)
            {
                foreach (var info in o.ArtikelInformationenOhneRTF)
                {
                    ArtikelInformationen.Add(new SerializableDictionary
                        {
                            Key = info.Key,
                            Value = info.Value
                        });
                }
            }
        }

        [DataMember]
        public List<SerializableDictionary> Logistik
        {
            get;
            set;
        }

        [DataMember]
        public virtual List<MobileArtikel> VerwandteArtikel
        {
            get;
            set;
        }

        [DataMember]
        public NummernTransport Nummern
        {
            get;
            set;
        }

        //[DataMember]
        //public virtual List<PreisStaffel> StaffelPreise
        //{
        //    get;
        //    set;
        //}

        [DataMember]
        public virtual IList<SerializableDictionary> ArtikelInformationen
        {
            get;
            set;
        }

        /// <summary>
        /// Einheiten pro Verpackung
        /// </summary>
        [DataMember]
        public int EinheitenProVerpackung { get; set; }

        /// <summary>
        /// Menge pro Einheit
        /// </summary>
        [DataMember]
        public decimal MengeProEinheit { get; set; }

        /// <summary>
        /// Einheit
        /// </summary>
        [DataMember]
        public string Einheit { get; set; }

        [DataMember]
        public string Verpackungsart { get; set; }

        [DataMember]
        public bool KZMat { get; set; }

        [DataMember]
        public bool KZAT { get; set; }

        [DataMember]
        public bool KZZub { get; set; }

        [DataMember]
        public bool KZSB { get; set; }
    }
}
