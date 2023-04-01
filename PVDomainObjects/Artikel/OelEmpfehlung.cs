using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class OelEmpfehlung
    {
        [DataMember]
        public List<OlyslagerType> SelectableTypes
        {
            get;
            set;
        }

        public bool TypIsSelected
        {
            get;
            set;
        }

        [DataMember]
        public string GenArt
        {
            get;
            set;
        }
    }
}
