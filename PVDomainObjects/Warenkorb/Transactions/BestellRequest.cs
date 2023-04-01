using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Bestellung;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class BestellRequest
    {
        [DataMember]
        public string Kommentar { get; set; }

        public int ProfilId { get; set; }

        [DataMember]
        public VdbUserInfo VdbUserInfo { get; set; }

        [DataMember]
        public long BestellId { get; set; }

        [DataMember]
        public string OfflineBestellId { get; set; }

        [DataMember]
        public string Zahlweise { get; set; }

        [DataMember]
        public string KundenEigeneBestellnummer { get; set; }

        [DataMember]
        public long Lieferbonus { get; set; }

        [DataMember]
        public DateTime Lieferzeitpunkt { get; set; }

        [DataMember]
        public Liefermodi Lieferart { get; set; }

        [DataMember]
        public bool Storno { get; set; }

        [DataMember]
        public bool ShowPreise { get; set; }

        [DataMember]
        public bool ShowPlus { get; set; }

        public List<BestellPositionInfos> BestellPosition  { get; set; }

        public string BestelltVon { get; set; }

        public string Benutzername { get; set; }
    }
}
