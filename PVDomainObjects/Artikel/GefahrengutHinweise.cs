using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable] 
    public class GefahrengutHinweise
    {

        public IList<KeyValuePair<String,String>> MembersAsList
        {
            get
            {
                var members = new List<KeyValuePair<string, string>>();
                
                if (!String.IsNullOrEmpty(AdrKlasse))
                    members.Add(new KeyValuePair<String, String>("ADR Klasse", AdrKlasse));
                if (!String.IsNullOrEmpty(VPG)) members.Add(new KeyValuePair<String, String>("VPG", VPG));
                if (!String.IsNullOrEmpty(UNNummer))
                    members.Add(new KeyValuePair<String, String>("UNNummer", UNNummer));
                if (!String.IsNullOrEmpty(AdrHandling))
                    members.Add(new KeyValuePair<String, String>("AdrHandling", AdrHandling));
                if (!String.IsNullOrEmpty(Gefahrgutzettel))
                    members.Add(new KeyValuePair<String, String>("Gefahrgutzettel", Gefahrgutzettel));
                if (!String.IsNullOrEmpty(AdrBez1)) members.Add(new KeyValuePair<String, String>("AdrBez1", AdrBez1));
                if (!String.IsNullOrEmpty(AdrBez2)) members.Add(new KeyValuePair<String, String>("AdrBez2", AdrBez2));
                if (!String.IsNullOrEmpty(AdrBez3)) members.Add(new KeyValuePair<String, String>("AdrBez3", AdrBez3));
                if (Rechenfaktor != 0m)
                    members.Add(new KeyValuePair<String, String>("Rechenfaktor", Rechenfaktor.ToString()));

                if (!String.IsNullOrEmpty(AusnahmenPims2)) members.Add(new KeyValuePair<String, String>("Ausnahmen", AusnahmenPims2));

                // Nicht mehr kompatibel mit dem Kompass. Müssen wir anders lösen.
                // if (!String.IsNullOrEmpty(Ausnahmen)) members.Add(new KeyValuePair<String, String>("Ausnahmen", Ausnahmen));

                if (!String.IsNullOrEmpty(Wassergefaehrdungsklasse))
                    members.Add(new KeyValuePair<String, String>("Wassergefaehrdungsklasse", Wassergefaehrdungsklasse));
                if (!String.IsNullOrEmpty(VBFKlasse))
                    members.Add(new KeyValuePair<String, String>("VBFKlasse", VBFKlasse));
                if (Verpackungsinhalt != 0)
                    members.Add(new KeyValuePair<String, String>("Verpackungsinhalt", Verpackungsinhalt.ToString()));
                if (Anzahl != 0) members.Add(new KeyValuePair<String, String>("Anzahl", Anzahl.ToString()));
                if (!String.IsNullOrEmpty(Dimension))
                    members.Add(new KeyValuePair<String, String>("Dimension", Dimension));
                if (!String.IsNullOrEmpty(Gefahrengutbezeichnung))
                    members.Add(new KeyValuePair<String, String>("Gefahrengutbezeichnung", Gefahrengutbezeichnung));
                if (!String.IsNullOrEmpty(RSaetze)) members.Add(new KeyValuePair<String, String>("RSaetze", RSaetze));
                if (!String.IsNullOrEmpty(SSaetze)) members.Add(new KeyValuePair<String, String>("SSaetze", SSaetze));
                if (GefahrenstoffKlasse1)
                    members.Add(new KeyValuePair<String, String>("GefahrenstoffKlasse1", String.Empty));
                if (GefahrenstoffKlasse2)
                    members.Add(new KeyValuePair<String, String>("GefahrenstoffKlasse2", String.Empty));
                if (GefahrenstoffKlasse3)
                    members.Add(new KeyValuePair<String, String>("GefahrenstoffKlasse3", String.Empty));
                if (GefahrenstoffKlasse4)
                    members.Add(new KeyValuePair<String, String>("GefahrenstoffKlasse4", String.Empty));
                if (!String.IsNullOrEmpty(Verpackungsart))
                    members.Add(new KeyValuePair<String, String>("Verpackungsart", Verpackungsart));
                if (!String.IsNullOrEmpty(SOVO)) members.Add(new KeyValuePair<String, String>("SOVO", SOVO));
                if (!String.IsNullOrEmpty(GefahrengutSymbol1))
                    members.Add(new KeyValuePair<String, String>("GefahrengutSymbol1", GefahrengutSymbol1));
                if (!String.IsNullOrEmpty(GefahrengutSymbol2))
                    members.Add(new KeyValuePair<String, String>("GefahrengutSymbol2", GefahrengutSymbol2));
                if (!String.IsNullOrEmpty(GefahrengutSymbol3))
                    members.Add(new KeyValuePair<String, String>("GefahrengutSymbol3", GefahrengutSymbol3));

                return members.AsReadOnly();
            }
        }



        /*************************************/

        [DataMember]
        public string AdrKlasse { get; set; }

        [DataMember]
        public string VPG { get; set; }

        [DataMember]
        public string UNNummer { get; set; }

        [DataMember]
        public string AdrHandling { get; set; }

        [DataMember]
        public string Gefahrgutzettel { get; set; }

        [DataMember]
        public string AdrBez1 { get; set; }

        [DataMember]
        public string AdrBez2 { get; set; }

        [DataMember]
        public string AdrBez3 { get; set; }

        [DataMember]
        public decimal Rechenfaktor { get; set; }

        // Nicht mehr kompatibel mit dem Kompass. Müssen wir anders lösen.
        //[DataMember]
        //public string Ausnahmen { get; set; }

        [DataMember]
        public bool Ausnahmen { get; set; }

        [DataMember]
        public string AusnahmenPims2 { get; set; }

        [DataMember]
        public string Wassergefaehrdungsklasse { get; set; }

        [DataMember]
        public string VBFKlasse { get; set; }

        [DataMember]
        public decimal Verpackungsinhalt { get; set; }

        [DataMember]
        public int Anzahl { get; set; }

        [DataMember]
        public string Dimension { get; set; }

        [DataMember]
        public string Gefahrengutbezeichnung { get; set; }

        [DataMember]
        public string RSaetze { get; set; }

        [DataMember]
        public string SSaetze { get; set; }

        /// <summary>
        /// brandgefährdende Stoffe
        /// </summary>
        [DataMember]
        public bool GefahrenstoffKlasse1 { get; set; }

        /// <summary>
        /// toxische Stoffe
        /// </summary>
        [DataMember]
        public bool GefahrenstoffKlasse2 { get; set; }

        /// <summary>
        /// reizende Stoffe
        /// </summary>
        [DataMember]
        public bool GefahrenstoffKlasse3 { get; set; }

        /// <summary>
        /// umweltgefährdende Stoffe
        /// </summary>
        [DataMember]
        public bool GefahrenstoffKlasse4 { get; set; }

        [DataMember]
        public string Verpackungsart { get; set; }

        /// <summary>
        /// Sonderverordnungen (Vorschriften) nach DIN
        /// </summary>
        [DataMember]
        public string SOVO { get; set; }

        [DataMember]
        public string GefahrengutSymbol1 { get; set; }

        [DataMember]
        public string GefahrengutSymbol2 { get; set; }

        [DataMember]
        public string GefahrengutSymbol3 { get; set; }
        
        [DataMember]
        public string GefahrengutSymbol1Uri
        {
            get
            {
                if (GefahrengutSymbol1 == null || GefahrengutSymbol1 == "")
                {
                    return null;
                }
                return string.Format("pv://katalog/{0}/{1}?type={2}", "bbk", GefahrengutSymbol1, "png");
            }
            set
            {
            }
        }

        [DataMember]
        public string GefahrengutSymbol2Uri
        {
            get
            {
                if (GefahrengutSymbol2 == null || GefahrengutSymbol2 == "")
                {
                    return null;
                }
                return string.Format("pv://katalog/{0}/{1}?type={2}", "bbk", GefahrengutSymbol2, "png");
            }
            set
            {
            }
        }

        [DataMember]
        public string GefahrengutSymbol3Uri
        {
            get
            {
                if (GefahrengutSymbol3 == null || GefahrengutSymbol3 == "")
                {
                    return null;
                }
                return string.Format("pv://katalog/{0}/{1}?type={2}", "bbk", GefahrengutSymbol3, "png");
            }
            set
            {
            }
        }
    }
}
