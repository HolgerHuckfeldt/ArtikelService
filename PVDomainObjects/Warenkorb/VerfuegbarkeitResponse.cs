using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class VerfuegbarkeitResponse
    {
        [DataMember]
        public string HLK { get; set; }
        [DataMember]
        public string Artikelnummer { get; set; }
        [DataMember]
        public wkVerfuegbarkeit Verfuegbarkeit { get; set; }

    }
}
