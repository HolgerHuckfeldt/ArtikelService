using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    [DataContract]
    public class BonusZuordnung
    {
        [DataMember]
        public Decimal Wert
        {
            get;
            set;
        }

        [DataMember]
        public Bonustyp Typ
        {
            get;
            set;
        }
    }
}
