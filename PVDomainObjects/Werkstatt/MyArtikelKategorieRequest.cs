using PV.DomainObjects.Stammdaten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Stammdaten
{
    [Serializable]
    [DataContract]
    public class MyArtikelKategorieRequest
    {
        [DataMember]
        public int ArtikelId { get; set; }
        [DataMember]
        public int ProfilId { get; set; }
        [DataMember]
        public MyArtikelKategorien MyArtikelKategorie { get; set; }
    }
}
