using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Mail.Smtp
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public class SmtpMessage
    {
        /// <summary>
        /// Semikolon-separiert.
        /// </summary>
        [DataMember]
        public string Sender;
        /// <summary>
        /// Semikolon-separiert.
        /// </summary>
        [DataMember]
        public string Recipients;

        /// <summary>
        /// Semikolon-separiert.
        /// </summary>
        [DataMember]
        public string Cc;

        /// <summary>
        /// Semikolon-separiert.
        /// </summary>
        [DataMember]
        public string Bcc;

        /// <summary>
        /// Die Überschrift
        /// </summary>
        [DataMember]
        public string Subject;

        /// <summary>
        /// Der Mail-Body. Wenn es eine HTML-Mail ist, dann muss BodyIsHtml auf true gesetzt werden.
        /// </summary>
        [DataMember]
        public string Body;

        /// <summary>
        /// Gibt an, ob der Body ein Html-Inhalt ist.
        /// </summary>
        [DataMember]
        public bool BodyIsHtml;

        /// <summary>
        /// Wird zur Zeit nicht unterstützt. 
        /// Müsste man auch ändern, wir müssten byte[] übergeben, nicht strings.
        /// </summary>
        [DataMember] public List<SmtpAttachment> Attachements = new List<SmtpAttachment>();

        /// <summary>
        /// AlternateView
        /// </summary>
        [DataMember]
        public SmtpMessageAlternateView AlternateView;
        
        /// <summary>
        /// Zur Zeit nicht benutzt
        /// </summary>
        [DataMember]
        public bool RequestDeliveryReport;

        /// <summary>
        /// Zur Zeit nicht benutzt
        /// </summary>
        [DataMember]
        public bool RequestReadReceipt;
    }
}
