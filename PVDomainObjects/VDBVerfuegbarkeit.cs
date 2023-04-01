using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects
{
    [Serializable]
    public class VerfuegbarkeitEigenschaften
    {
        [DataMember]
        public VDBVerfuegbarkeit Verfuegbarkeitskennzeichen { get; set; }
        public DateTime bestellschlusszeit { get; set; }
        public Boolean bestellschlusszeitSpecified { get; set; }
        public DateTime Lieferzeitpunkt { get; set; }
        public long Menge { get; set; }
        public DateTime Abholzeitpunkt { get; set; }
    }

    [Serializable]
    public enum VDBVerfuegbarkeit
    {
        naechsteTour,
        heute,
        naechsterWerktag,
        uebernaechsterTag,
        groesserUebernaechsterTag,
        rueckstand,
        nichtBestellbar,
        OfflineVDB,
        TecCom
    }
}
