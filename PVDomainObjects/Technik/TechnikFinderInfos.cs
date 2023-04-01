using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class TechnikFinderInfos
    {
        [DataMember] public List<MotormanagementSystem> MotorManagement;

        [DataMember] public List<Reparaturhandbuch> Reparaturhandbuch;

        [DataMember] public List<Sicherungskasten> Sicherungskasten;

        [DataMember] public List<TechnischeZeichnungGruppe> TechnischeZeichnungGruppe;

    }
}
