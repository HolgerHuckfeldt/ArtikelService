using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Mail.Smtp
{
    [DataContract]
    [Serializable]
    public class SmtpMessageLinkedResource
    {

        [DataMember]
        public string ResourceUrl;

        [DataMember]
        public string ResourceId;

        public SmtpMessageLinkedResource(string url, string id)
        {
            ResourceId = id;
            ResourceUrl = url;
        }
        public SmtpMessageLinkedResource()
        {
        }
      
    }
}
