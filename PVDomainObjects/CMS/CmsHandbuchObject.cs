using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.CMS
{
    [DataContract]
    public class CmsHandbuchObject
    {
        #region Properties

        [DataMember]
        public int KennzeichenID { get; set; }
        
        [DataMember]
        public string Kennzeichen { get; set; }

        [DataMember]
        public string Url { get; set; }

        #endregion
    }
}
