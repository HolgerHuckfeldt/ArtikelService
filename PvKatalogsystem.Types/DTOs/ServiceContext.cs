using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ServiceContext
    {

        public ServiceContext()
        {
        }

        public ServiceContext(string csoCode, string firmaStandortAbteilung, int absatzgruppe, int kundengruppe, int preisgruppe, string fSAForLogistik)
        {
            CsoCode = csoCode;
            FirmaStandortAbteilung = firmaStandortAbteilung;
            Absatzgruppe = absatzgruppe;
            Kundengruppe = kundengruppe;
            Preisgruppe = preisgruppe;
            FSAForLogistik = fSAForLogistik;
            CsoCodeZugelassen = new List<string>();
            CsoCodeNichtZugelassen = new List<string>();
        }

        [DataMember]
        public string CsoCode { get; set; }

        [DataMember]
        public List<string> CsoCodeZugelassen { get; set; }

        [DataMember]
        public List<string> CsoCodeNichtZugelassen { get; set; }

        [DataMember]
        public string FirmaStandortAbteilung { get; set; }

        [DataMember]
        public string FSAForLogistik { get; set; }

        [DataMember]
        public int Absatzgruppe { get; set; }

        [DataMember]
        public int Kundengruppe { get; set; }

        [DataMember]
        public int Preisgruppe { get; set; }

        [DataMember]
        public int Kundennummer { get; set; }

        [DataMember]
        public int BenutzerId { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public int ProfilId { get; set; }

        [DataMember]
        public int VersandadresseId { get; set; }

        [DataMember]
        public string SessionId { get; set; }

        [DataMember]
        public bool IsPraesentationsmodus { get; set; }

        [DataMember]
        public bool HasPlus { get; set; }

        [DataMember]
        public bool IsHandelsPartner { get; set; }
        
        [DataMember]
        public bool GesperrtOnlineBestellung { get; set; }

        public bool IstSuperflexpaketWk { get; set; }

        public bool IstDealBestellung { get; set; }

        public bool MitWeiterenHerstellern { get; set; }

        public bool IsStahlgruberAbfrage { get; set; }

        [DataMember]
        public bool WeitereHersteller_beruecksichtigen { get; set; }

        public int Firma
        {
            get
            {
                var result = 1;
                int.TryParse(FirmaStandortAbteilung.Substring(0, 3), out result);
                return result;
            }
        }

        public int Standort
        {
            get
            {
                var result = 1;
                int.TryParse(FirmaStandortAbteilung.Substring(4, 3).ToString(), out result);
                return result;
            }
        }

        public int Abteilung
        {
            get
            {
                var result = 1;
                int.TryParse(FirmaStandortAbteilung.Substring(8, 3).ToString(), out result);
                return result;
            }
        }
    }
}
