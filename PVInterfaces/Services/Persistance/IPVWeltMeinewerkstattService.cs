using System;
using System.Runtime.Serialization;


namespace PV.Persistance.Provider
{
    
    public interface IPVWeltMeineWerkstattService
    {
        
        Guid MWRegisterUser(MWAuthOutData profil, string ip);

        
        MWAuthOutData MWAuth(string guid, int meineWerkstattId);
    }

    [DataContract]
    public class MWAuthOutData
    {
        [DataMember]
        public int firma_id { get; set; }
        [DataMember]
        public int standort_id { get; set; }
        [DataMember]
        public int abteilung_id { get; set; }
        [DataMember]
        public int kundennummer { get; set; }
        [DataMember]
        public int versandadresse_id { get; set; }
        [DataMember]
        public int meinewerkstatt_id { get; set; }
    }
}
