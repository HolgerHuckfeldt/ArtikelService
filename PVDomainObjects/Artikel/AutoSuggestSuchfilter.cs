using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class AutoSuggestSuchfilter
    {
        [DataMember]
        public int FahrzeugId { get; set; }
        [DataMember]
        public string Suchstring { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        public int MaxCount { get; set; }
        [DataMember]
        public ArtikelArt Suchbaumtyp { get; set; }
        [DataMember]
        public bool ShowBLieferanten { get; set; }
        [DataMember]
        public bool ShowHersteller { get; set; }
        [DataMember]
        public bool ShowPC { get; set; }
        [DataMember]
        public bool ShowUNI { get; set; }
    }
}
