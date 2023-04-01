using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.CMS
{
    [DataContract]
    public class StandortObject
    {
        #region Properties

        [DataMember]
        public int FirmaID { get; set; }
        
        [DataMember]
        public int StandortID { get; set; }

        [DataMember]
        public string NameFirma { get; set; }

        [DataMember]
        public string NameStandort { get; set; }

        #endregion
    }
}
