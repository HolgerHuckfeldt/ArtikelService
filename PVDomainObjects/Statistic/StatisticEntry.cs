using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Statistic
{
    [DataContract]
    public class StatisticEntry
    {
        [DataMember]
        public string Location;
        [DataMember]
        public string ExtraInfo;
        [DataMember]
        public int  KType;
    }
}
