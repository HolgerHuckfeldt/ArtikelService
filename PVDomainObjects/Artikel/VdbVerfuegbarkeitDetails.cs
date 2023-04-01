using PV.DomainObjects.Warenkorb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable] 
    public class VdbVerfuegbarkeitDetails
    {
        [DataMember]
        public DateTime? AbholDatum { get; set; }
        [DataMember]
        public wkVerfuegbarkeit Abholverfuegbarkeit { get; set; }
        [DataMember]
        public DateTime? LieferDatum { get; set; }
        [DataMember]
        public wkVerfuegbarkeit Lieferverfuegbarkeit { get; set; }
        [DataMember]
        public decimal Menge { get; set; }
    }
}
