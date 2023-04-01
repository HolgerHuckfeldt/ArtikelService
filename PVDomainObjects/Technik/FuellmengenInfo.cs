using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class FuellmengenInfo 
    {
        [DataMember]
        public decimal Von
        {
            get;
            set;
        }
        [DataMember]
        public decimal Bis
        {
            get;
            set;
        }
        [DataMember]
        public decimal Durchschnitt
        {
            get;
            set;
        }
        [DataMember]
        public bool Benutzbar
        {
            get;
            set;
        }
        [DataMember]
        public bool Eindeutig
        {
            get;
            set;
        }
    }
}
