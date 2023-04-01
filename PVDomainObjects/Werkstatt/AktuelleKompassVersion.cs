using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Stammdaten
{
    [DataContract]
    public class AktuelleKompassVersion
    {
        [DataMember] public int ProfilId { get; set; }

        [DataMember] public Version CurrentVersion { get; set; }

        [DataMember] public DateTime Zeitpunkt { get; set; }

        [DataMember] public bool UsesPipe { get; set; }
    }
}
