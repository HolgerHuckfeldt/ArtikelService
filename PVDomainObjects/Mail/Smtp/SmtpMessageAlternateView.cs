using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Mail.Smtp
{
    [DataContract]
    [Serializable]
    public class SmtpMessageAlternateView
    {
        [DataMember]
        public string HtmlBody;

        [DataMember]
        public List<SmtpMessageLinkedResource> LinkedResources = new List<SmtpMessageLinkedResource>();
    }
}
