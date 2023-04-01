using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class wkUnterPosition
    {
        [DataMember]
        public wkVerfuegbarkeit Verfuegbarkeit
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Liefertour
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Bestellschlusszeit
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Selbstabholung
        {
            get;
            set;
        }

        private Decimal _menge;

        [DataMember]
        public Decimal Menge
        {
            get { return _menge;}
            set {_menge = value;}
        }

        [DataMember]
        public wkPositionStatus Status
        {
            get;
            set;
        }
    }
}
