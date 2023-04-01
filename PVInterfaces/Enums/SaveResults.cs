using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PVInterfaces.Enums
{
    [DataContract]
    public enum SaveResults
    {
        [EnumMember]
        Ok,
        [EnumMember]
        NummerBesetzt,
        [EnumMember]
        KundeExistiertNicht,
        [EnumMember]
        SaveError,
        [EnumMember]
        LastMitarbeiter,
        [EnumMember]
        NoEmailAdress,
        [EnumMember]
        SMTPError,
        [EnumMember]
        NoUserFound
    }
}
