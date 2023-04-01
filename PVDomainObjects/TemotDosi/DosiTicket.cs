using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.TemotDosi
{
    [DataContract]
    public class DosiTicket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Vehicle { get; set; }  // XML:  numKNTType
        [DataMember]
        public string User { get; set; }
        
        [DataMember]
        public string Vin { get; set; }  // XML: specifics_fields_workshop.vin 
        [DataMember]
        public string CommentWorkshop { get; set; }  // XML: specifics_fields_workshop.comment_workshop

        [DataMember]
        public string Kba { get; set; }  // XML:  numKBAs
        [DataMember]
        public string KindOfVehicle { get; set; }  // XML:  ??? KindOfVehicle
        [DataMember]
        public string SuperVehicleId { get; set; }  // XML:  ??? SuperVehicleId

        [DataMember]
        public string Kw { get; set; }   // XML:  powerKW
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Hersteller { get; set; }  // XML:  make
        [DataMember]
        public string Modell { get; set; }  // XML:  model + cubicCapacityL
        [DataMember]
        public string Baujahr { get; set; }  // XML: year
        [DataMember]
        public string Motorcode { get; set; }  // XML: ????

        [DataMember]
        public List<DosiArtikel> Artikel { get; set; }

        [DataMember]
        public int Status { get; set; }

		//public string StatusText
		//{
		//    get
		//    {
		//        switch (Status)
		//        {

		//            case 0:
		//                return "Neu"; //Managers.TranslationManager.Translate("Kompass_Motortester_Ticketliste_Text_Status_Neu")
		//            case 1:
		//                return "Geöffnet";//Managers.TranslationManager.Translate("Kompass_Motortester_Ticketliste_Text_Status_Offen")
		//            default:
		//                return "Unbekannt";//Managers.TranslationManager.Translate("Kompass_Motortester_Ticketliste_Text_Status_Unbekannt")
		//        }
		//    }
		//}

		//public string DatumText
		//{
		//    get
		//    {
		//        return Date.ToString("dd.MM.yyyy HH:mm:ss"); //Managers.TranslationManager.Translate("Kompass_Motortester_Ticketliste_Text_Status_Unbekannt")
		//    }
		//}
    }
}
