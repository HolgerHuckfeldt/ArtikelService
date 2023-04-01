using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.CMS
{
    [DataContract]
    public class CmsHpObject
    {
        #region Properties

        [DataMember]
        public int FirmaID { get; set; }
        
        [DataMember]
        public int StandortID { get; set; }

        [DataMember]
        public string Bezeichnung { get; set; }

        [DataMember]
        public byte[] Logo { get; set; }

        #endregion
    }
}
