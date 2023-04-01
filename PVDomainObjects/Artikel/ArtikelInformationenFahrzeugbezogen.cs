using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ArtikelInformationenFahrzeugbezogen
    {
        [DataMember]
        public virtual KeyValuePair<string, string> SofortArtikelInformationenOhneRTF { get; set; }
        [DataMember]
        public virtual int LinkageId { get; set; }
    }
}
