using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    [DataContract]
    public class BestellungFaultPosition
    {

        [DataMember]
        public Int32 Positionsnummer
        {
            get;
            set;
        }

        [DataMember]
        public String HLKA
        {
            get;
            set;
        }

        [DataMember]
        public String ATNR
        {
            get;
            set;
        }

        [DataMember]
        public String Text1
        {
            get;
            set;
        }

        [DataMember]
        public String Text2
        {
            get;
            set;
        }

        [DataMember]
        public Int32 StatusVDB
        {
            get;
            set;
        }

        [DataMember]
        public Decimal Menge
        {
            get;
            set;
        }

        [DataMember]
        public Boolean FlagAlternative
        {
            get;
            set;
        }
    }
}
