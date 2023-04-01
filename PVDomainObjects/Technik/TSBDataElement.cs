using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class TSBDataElement
    {

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string remark { get; set; }

        [DataMember]
        public string image { get; set; }

        [DataMember]
        public string EOBDCode { get; set; }

        [DataMember]
        public string OECode { get; set; }

        [DataMember]
        public int? repairTime { get; set; }
        //ExtSmartLink[] smartLinks;
    }
}


//• text: this is a language dependent text which contains bulletin data
//• remark: this is a language dependent text which may contain (can be null) extra information
//• image: this is a text which may contain (can be null) a URL to an image
//• EOBDCode: this is a text which may contain (can be null) an EOBD code
//• OECode: this is a text which may contain (can be null) an OE code
//• repairTime: this is a number (integer) which may contain (can be null) the time to perform the
//specified repair. The value is a number with 2 decimals to which the decimal point has been
//moved 2 positions to the right (for example: 1.2 hours is represented as 120; 1.2h = 1 hour and
//60minutes*0.2 = 1 hour and 12 minutes)