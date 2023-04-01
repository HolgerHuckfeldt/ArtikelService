using System.Collections.Generic;
using System.Collections;
using System;
using System.Runtime.Serialization;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class TopProdukt : DtoBase
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public TopProduktType Typ { get; set; }
        [DataMember]
        public decimal TopProduktWert { get; set; }
        [DataMember]
        public decimal TopProduktFaktor { get; set; }
        [DataMember]
        public string Notiz { get; set; }
        [DataMember]
        public int UrsprungsArtikelId { get; set; }
        [DataMember]
        public bool SameKTypeOnly { get; set; }
    }
}
