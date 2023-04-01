using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    public class Herstellerpriorisierung
    {
        [DataMember]
        public int DLNr
        {
            get;
            set;
        }

        [DataMember]
        public int GenArtNr
        {
            get;
            set;
        }

        [DataMember]
        public int Prio
        {
            get;
            set;
        }
    }
}
