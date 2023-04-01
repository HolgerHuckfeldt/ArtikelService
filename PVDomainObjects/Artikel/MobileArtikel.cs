using PV.DomainObjects.Common;
using PV.DomainObjects.Warenkorb;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace PV.DomainObjects.Artikel
{
    [DataContract]
    public class MobileArtikel
    {
        [DataMember]
        public string VDBArtikelnummer = string.Empty;
        [DataMember]
        public decimal EKPreis;

        [DataMember]
        public virtual int ArtikelId
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Artikelnummer
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal VKPreis
        {
            get;
            set;
        }

        [DataMember]
        public virtual wkVerfuegbarkeit Verfuegbarkeit
        {
            get;
            set;
        }
        [DataMember]
        public virtual string HLK
        {
            get;
            set;
        }
        [DataMember]
        public virtual IList<ArtikelKriterium> Kriterien
        {
            get;
            set;
        }

        [DataMember]
        public virtual IList<ArtikelKriterium> TypKriterien
        {
            get;
            set;
        }

        [DataMember]
        public virtual IList<ArtikelDokument> Dokumente
        {
            get;
            set;
        }

        [DataMember]
        public virtual IList<ArtikelLink> Links
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Bezeichnung
        {
            get;
            set;
        }
        [DataMember]
        public virtual string GenArtBezeichnung
        {
            get;
            set;
        }
        [DataMember]
        public virtual string HerstellerKurzName
        {
            get;
            set;
        }
        [DataMember]
        public virtual IList<PvImage> Bilder
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal MengeneinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal TechMengeneinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public virtual String MengeneinheitBezeichnung
        {
            get;
            set;
        }

        [DataMember]
        public virtual String TechMengeneinheitBezeichnung
        {
            get;
            set;
        }

        [DataMember]
        public virtual String MengeneinheitSchluessel
        {
            get;
            set;
        }

        [DataMember]
        public virtual String TechMengeneinheitSchluessel
        {
            get;
            set;
        }

        [DataMember]
        public decimal PreiseinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public decimal InvPreiseinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public virtual int BenoetigteMenge
        {
            get;
            set;
        }

        [DataMember]
        public ArtikelVerwandtschaft Verwandschaft
        {
            get;
            set;
        }

        [DataMember]
        public bool HasStaffelpreise
        {
            get;
            set;
        }

        [DataMember]
        public virtual List<PreisStaffel> StaffelPreise
        {
            get;
            set;
        }

        public MobileArtikel()
        {
        }

        public MobileArtikel(Artikel o)
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
            this.PreiseinheitFaktor = o.PreiseinheitFaktor;
            this.InvPreiseinheitFaktor = PreiseinheitFaktor == 0 ? 0 : 1 / PreiseinheitFaktor; 
            this.StaffelPreise = new List<PreisStaffel>();

        }

        public MobileArtikel(VerwandterArtikel o)
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
            this.TechMengeneinheitBezeichnung = o.TechMengeneinheitBezeichnung;
            this.TechMengeneinheitFaktor = o.TechMengeneinheitFaktor;
            this.TechMengeneinheitSchluessel = o.TechMengeneinheitSchluessel;
            this.PreiseinheitFaktor = o.PreiseinheitFaktor;
            this.InvPreiseinheitFaktor = PreiseinheitFaktor == 0 ? 0 : 1 / PreiseinheitFaktor; 
            this.BenoetigteMenge = o.BenoetigteMenge;
            this.Verwandschaft = o.Verwandschaft;
            this.StaffelPreise = new List<PreisStaffel>();
        }
    }
}
