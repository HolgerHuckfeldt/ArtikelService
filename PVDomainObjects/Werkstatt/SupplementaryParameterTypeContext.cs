using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Stammdaten
{
    [Serializable]
    [DataContract]
    public class SupplementaryParameterTypeContext
    {
        /// <summary>
        /// ÜbergabeTyp wie z.B. CustomerNumber 
        /// </summary>
        [DataMember]
        public EnumSupplementaryParameterType SupplementaryParameterType { get; set; }

        /// <summary>
        /// Wert wie z.B. StahlgruberKundennummer
        /// </summary>
        [DataMember]
        public string ParameterValue { get; set; }
    }

    [Serializable]
    [DataContract]
    public enum EnumSupplementaryParameterType
    {
        [EnumMember]
        CustomerNumber
    }
}
