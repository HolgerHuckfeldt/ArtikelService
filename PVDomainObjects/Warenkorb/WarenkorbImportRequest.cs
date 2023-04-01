using PV.DomainObjects.Artikel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class WarenkorbImportRequest
    {
        [DataMember]
        public List<string> ImportListe { get; set; }
        [DataMember]
        public WarenkorbImportStandards SelectedImportFilter { get; set; }

        [DataMember]
        public ArtikelProviderRequest<List<VdbArtikelId>> RequestForArtikelsuche { get; set; }

        [DataMember]
        public ArtikelProviderRequest<ArtikelNummernsucheArten> RequestForArtikelNummernsuche { get; set; }
    }
}
