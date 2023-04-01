using System.Collections.Generic;
using System.Collections;
using System;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelLogistik : DtoBase
    {
        public ArtikelLogistik()
        {
            Logistikinformationen = new List<KeyValuePair<string,string>>();
            Verpackungseinheiten = new List<KeyValuePair<string, string>>();
        }

        [DataMember]
        public List<KeyValuePair<string, string>> Logistikinformationen { get; set; }
        [DataMember]
        public List<KeyValuePair<string, string>> Verpackungseinheiten { get; set; }
    }
}
