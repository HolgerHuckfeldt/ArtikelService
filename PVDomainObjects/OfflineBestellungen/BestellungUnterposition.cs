using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    [DataContract]
    public class BestellungUnterposition
    {


        [DataMember]
        public Int32 Unterpositionsnummer
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
        public Decimal EKPreis
        {
            get;
            set;
        }

        [DataMember]
        public Decimal EKPreisSumme
        {
            get;
            set;
        }

        [DataMember]
        public Int32 Lieferart
        {
            get;
            set;
        }

        [DataMember]
        public Nullable<DateTime> Lieferzeitpunkt
        {
            get;
            set;
        }

        [DataMember]
        public Nullable<DateTime> Abholzeitpunkt
        {
            get;
            set;
        }

        [DataMember]
        public Int32 VerfuegbarkeitKennzeichen
        {
            get;
            set;
        }
    }
}
