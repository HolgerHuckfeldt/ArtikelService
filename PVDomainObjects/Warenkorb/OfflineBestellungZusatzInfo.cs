using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    class OfflineBestellungZusatzInfo
    {
        [DataMember]
        public string OfflineId { get; set; }
        [DataMember]
        public DateTime BestellZeit { get; set; }
        [DataMember]
        public string BestellUser { get; set; }
        [DataMember]
        public string Firmenname { get; set; }
        [DataMember]
        public string Firmenzusatz { get; set; }
        [DataMember]
        public string Bezeichnung { get; set; }
        [DataMember]
        public string PVStandortFax { get; set; }
        [DataMember]
        public string PVFirmaName { get; set; }
        [DataMember]
        public string PVStandortName { get; set; }
        [DataMember]
        public string PVStandortOrt { get; set; }
        [DataMember]
        public string PVStandortPLZ { get; set; }
        [DataMember]
        public string PVStandortStrasse { get; set; }
        [DataMember]
        public string PVStandortTelefon { get; set; }
        [DataMember]
        public string VersandAdresseOrt { get; set; }
        [DataMember]
        public string VersandAdressePLZ { get; set; }
        [DataMember]
        public string VersandAdresseStrasse { get; set; }        
    }
}
