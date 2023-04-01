using System;
using System.Runtime.Serialization;
            
namespace PV.DomainObjects.Stammdaten
{
    [DataContract]
    [Serializable]
    public class ZahlungsartInfos
    {
        [DataMember]
        public bool NurBarZahlung { get; set; }

        [DataMember]
        public Zahlungsart ZahlungsartVDB { get; set; }

        [DataMember]
        public bool NurRechnung { get; set; }

        [DataMember]
        public Zahlungsart SelectedZahlungsart { get; set; }

        [DataMember]
        public ShowZahlungsartTyp ShowZahlungsart { get; set; }
    }

    [Serializable]
    [DataContract]
    public enum Zahlungsart
    {
        [EnumMember]
        Rechnung_Preis = 1,
        [EnumMember]
        Barverkauf = 8,
        [EnumMember]
        None = 0
    };

    [Serializable]
    [DataContract]
    public enum ShowZahlungsartTyp
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        ShowZahlungsartWegenKKZ = 1,
        [EnumMember]
        ShowZahlungsartWegenKKZUndZahlungsmodusEinstellungen = 2,
        
    };
}
