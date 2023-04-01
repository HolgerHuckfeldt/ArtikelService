using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Acceleration
{
    using System.Runtime.Serialization;

    using PV.DomainObjects.Artikel;
     
    [DataContract]
    public class ArtikelSearchInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public ArtikelProviderResult<Artikel> GetArtikelByArtikelNummer;
        [DataMember(EmitDefaultValue = false)]
        public ArtikelProviderResult<Artikel> GetArtikelByGebrauchsNummer;
        [DataMember(EmitDefaultValue = false)]
        public ArtikelProviderResult<Artikel> GetArtikelByVergleichsNummer;
        [DataMember(EmitDefaultValue = false)]
        public ArtikelProviderResult<Artikel> GetArtikelByReferenzNummer;
        [DataMember(EmitDefaultValue = false)]
        public ArtikelProviderResult<Artikel> GetArtikelByEAN;
        [DataMember(EmitDefaultValue = false)]
        public ArtikelProviderResult<Artikel> GetArtikelByMatchcode;

    }
}
