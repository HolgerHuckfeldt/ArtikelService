using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelVerwendetIn : DtoBase
    {
        public ArtikelVerwendetIn()
        {
            Pkws = new List<Pkw>();
            Lkws = new List<Lkw>();
            Motoren = new List<Motor>();
            Achsen = new List<Achse>();
        }

        [DataMember]
        public List<Pkw> Pkws { get; set; } 	//PassengerCars
        [DataMember]
        public List<Lkw> Lkws { get; set; }	//CommercialVehicles
        [DataMember]
        public List<Motor> Motoren { get; set; }   //Engines
        [DataMember]
        public List<Achse> Achsen { get; set; }   //Axles

        public override string ToString()
        {
            return string.Format("Pkws={0},Lkws={1},Motoren={2},Achsen={3}", 
                                Pkws.Count.ToString(), Lkws.Count.ToString(), Motoren.Count.ToString(), Achsen.Count.ToString());
        }
    }
}
