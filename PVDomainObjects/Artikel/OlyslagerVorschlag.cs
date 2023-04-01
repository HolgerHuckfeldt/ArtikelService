using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class OlyslagerVorschlag
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ArtikelNummer { get; set; }
        [DataMember]
        public string AlternativeArtikelNummern { get; set; }
        [DataMember]
        public List<string> BackupInfos { get; set; }
        [DataMember]
        public IList<string> Kapazitaeten { get; set; }
        [DataMember]
        public List<string> Einsaetze { get; set; }
        [DataMember]
        public string SelectedEinsatz { get; set; }
        [DataMember]
        public List<string> Intervalle { get; set; }
        [DataMember]
        public string OlyslagerId { get; set; }
        [DataMember]
        public OelInfo OelInfoEmpfehlung
        {
            get;
            set;
        }
    }
}
