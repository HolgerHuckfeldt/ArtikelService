using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using PV.DomainObjects.Stammdaten;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public sealed class VdbUserInfo
    {
        [DataMember]
        public int Kundenummer { get; set; }
        [DataMember]
        public int Standort { get; set; }
        [DataMember]
        public int Abteilung { get; set; }
        [DataMember]
        public int Firma { get; set; }
        [DataMember]
        public int Versandadresse { get; set; }
        [DataMember]
        public bool HandelspartnerVDBProvider { get; set; }

        /// <summary>
        /// Übergabe von CustomerNumber wie z.B. StahlgruberKundennummer
        /// </summary>
        [DataMember]
        public List<SupplementaryParameterTypeContext> SupplementaryParameterType
        {
            get;
            set;
        }

        /// <summary>
        /// z.B. PV oder Stahlgruber, kommt von RoutingID
        /// </summary>
        [DataMember]
        public int Supplier { get; set; }
    }
}
