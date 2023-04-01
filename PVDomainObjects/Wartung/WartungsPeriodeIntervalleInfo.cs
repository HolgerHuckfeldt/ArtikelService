using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Wartung
{
    [DataContract]
    public class WartungsPeriodeIntervalleInfo
    {
        [DataMember]
        public int PeriodId;
        [DataMember]
        public string PeriodText;
        [DataMember]
        public List<WartungsChecklisteItem> Items = new List<WartungsChecklisteItem>();
    }
}
