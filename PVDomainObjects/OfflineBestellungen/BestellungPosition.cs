using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    [DataContract]
    public class BestellungPosition
    {
        [DataMember]
        public List<BonusZuordnung> BonuspunkteList
        {
            get;
            set;
        }

        [DataMember]
        public List<BestellungUnterposition> Unterpositionen
        {
            get;
            set;
        }

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
        public Decimal Bonuspunkte
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
    }
}
