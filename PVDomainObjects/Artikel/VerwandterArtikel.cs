using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class VerwandterArtikel : Artikel
    {
        [DataMember]
        public Int32 BenoetigteMenge { get; set; }

        [DataMember]
        public ArtikelVerwandtschaft Verwandschaft { get; set; }

        public Artikel ConvertToArtikel()
        {
            return this as Artikel;
        }
    }

    [DataContract]
    [Serializable]
    public class NotwendigerArtikel : Artikel
    {
        [DataMember]
        public Int32 BenoetigteMenge { get; set; }

        public Artikel ConvertToArtikel()
        {
            return this as Artikel;
        }
    }
}
