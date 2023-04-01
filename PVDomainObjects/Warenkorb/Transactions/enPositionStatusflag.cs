using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [DataContract]
    [Serializable]
    public enum enPositionStatusflag
    {
        [EnumMember]
        keineÄnderung,
        [EnumMember]
        ÄnderungDerMenge,
        [EnumMember]
        Artikelgelöscht,
        [EnumMember]
        neuerArtikel,
        [EnumMember]
        Artikelgetauscht,
        [EnumMember]
        Artikeltextanlegen_ändern,
        [EnumMember]
        Bestellzeitprüfen,
        [EnumMember]
        NET //Nachtexpress
    }

    [DataContract]
    [Serializable]
    public enum enBatteriestatus
    {
        [EnumMember]
        nichtgefüllteBatterie,
        [EnumMember]
        gefüllteBatterie
    }

    [DataContract]
    [Serializable]
    public enum enStatusResp
    {
        [EnumMember]
        reserviert,
        [EnumMember]
        StücklimitErreicht,
        [EnumMember]
        BestelllimitErreicht,
        [EnumMember]
        ArtikelNotFound,
        [EnumMember]
        Kreditlimit
    }

    [DataContract]
    [Serializable]
    public enum enVerfuegbarkeitResp
    {
        [EnumMember]
        nächsteTour,
        [EnumMember]
        heute,
        [EnumMember]
        plusZweiTage,
        [EnumMember]
        groesserZweiTage,
        [EnumMember]
        nichtVerfügbar,
        [EnumMember]
        nichtLieferbar
    }
}
