using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class WarenkorbImportResponse
    {
        public WarenkorbImportResponse()
        {
            GefundeneWkPositionen = new List<wkPositionEinfach>();
            NichtGefundeneWkPositionen = new List<wkPositionEinfach>();
        }

        [DataMember]
        public List<wkPositionEinfach> GefundeneWkPositionen { get; set; }

        [DataMember]
        public List<wkPositionEinfach> NichtGefundeneWkPositionen { get; set; }

        [DataMember]
        public string Error { get; set; }
    }
}
