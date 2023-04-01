using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class SuchknotenAndTyp
    {
        [DataMember]
        public ArtikelArt Art { get; set;}

        [DataMember]
        public SuchbaumEintrag Knoten { get; set; }

        [DataMember]
        public List<int> GenArtKnotenListe { get; set; }

        [DataMember]
        public bool MitWeiterenHerstellern { get; set; }

        [DataMember]
        public bool Mobile { get; set; }

        [DataMember]
        public int? Typ { get; set; }

        [DataMember]
        public int? VehicleId { get; set; }

        [DataMember]
        public int VorgaengerKnoten { get; set; }

        [DataMember]
        public int VorgaengerParentIdKnoten { get; set; }

        [DataMember]
        public int VorgaengerKnotenTiefe { get; set; }

        [DataMember]
        public bool SuchstringFuerHersteller { get; set; }

        [DataMember]
        public String Suchstring { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Knoten: " + Knoten.Id + "(" + Knoten.Bezeichnung + ")");
            sb.AppendLine("Art: " + Art.ToString());
            if (Typ != null)
                sb.AppendLine("Typ: " + Typ.Value);
            return sb.ToString();
        }
    }
}
