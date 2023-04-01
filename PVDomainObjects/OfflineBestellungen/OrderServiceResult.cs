using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    [DataContract]
    public class OrderServiceResult
    {
        [DataMember]
        public String OfflineId
        {
            get;
            set;
        }
        
        [DataMember]
        public string Benutzername
        {
            get;
            set;
        }

        [DataMember]
        public String ErrorMessage
        {
            get;
            set;
        }
        [DataMember]
        public Boolean ErfolgreichBestellt
        {
            get;
            set;
        }
        [DataMember]
        public Boolean BatchProcessed
        {
            get;
            set;
        }
        [DataMember]
        public Bestellung BatchBestellung
        {
            get;
            set;
        }
    }
}
