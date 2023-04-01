using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Fahrzeug;


namespace PV.DomainObjects.Acceleration
{
    [DataContract]
    public class PkwSelectInfos
    {
        [DataMember(EmitDefaultValue = false)]
        public PkwInformation PkwInformation;
        [DataMember(EmitDefaultValue = false)]
        public IList<Modell> PkwModellList;
        [DataMember(EmitDefaultValue = false)]
        public IList<PKWTyp> PkwTypeList;
        [DataMember(EmitDefaultValue = false)]
        public List<SuchbaumEintrag> ArtikelSuchbaumList;
        [DataMember(EmitDefaultValue = false)]
        public IList<ArbeitswertTreeItem> ArbeitswerteSuchbaum;
        [DataMember(EmitDefaultValue = false)]
        public List<PV.DomainObjects.Technik.Fahrzeug> TechnikFahrzeugeList;
        [DataMember(EmitDefaultValue = false)]
        public int MapToVivid;
    }
}
