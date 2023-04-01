using System;
using System.Runtime.Serialization;


namespace PV.Persistance.Provider
{
    
    public interface IPVWeltMediaMasterService
    {
        
        MMAuthOutData MMAuth(string ip, string guid);

        
        Guid MMRegisterUser(MMAuthOutData profil, string ip);

        
        int MMPlusPunkteCollect(string aktion, int firma_id, int standort_id, int abteilung_id, int kundennummer, int versandadresse_id,
                                    int punkte, string auftragsnummer, int position, float netto, string artikelbezeichnung, int menge,
                                    string lieferant, string liefername, string lieferansprechpartner, string lieferstrasse, string lieferplz,
                                    string lieferort, DateTime datum);

        
        int MMPlusPunktePay(string aktion, int firma_id, int standort_id, int abteilung_id, int kundennummer, int versandadresse_id,
                                    int punkte, string auftragsnummer, int position, float netto, string artikelbezeichnung, int menge,
                                    string lieferant, string liefername, string lieferansprechpartner, string lieferstrasse, string lieferplz,
                                    string lieferort, DateTime datum);

        
        bool MMFtpUpload();

        
        string GetMediaManagerToken(string stahlgruberKundennummer, string ip);

        
        string GetAutofitToken(string stahlgruberKundennummer, string ip);

        
        string GetCaraluxToken(string stahlgruberKundennummer, string ip);
    }

    [DataContract]
    public class MMAuthOutData
    {
        [DataMember]
        public int firma_id { get; set; }
        [DataMember]
        public int standort_id { get; set; }
        [DataMember]
        public int abteilung_id { get; set; }
        [DataMember]
        public int kundennummer { get; set; }
        [DataMember]
        public int versandadresse_id { get; set; }
        [DataMember]
        public int konzeptkennzeichen_id { get; set; }      // Nur das aktuelle Kennzeichen
        [DataMember]
        public string email_for_confirmations { get; set; } // kommt aus dem VDB Webservice GetLogin 
        [DataMember]
        public int errcode { get; set; }                    // "GUID aus Firma ID, Standort ID, Abetilung ID, Kundennummer und Versandadresse ID"    
        [DataMember]
        public string firstname { get; set; }               // Hier ist der aktuell eingeloggte Benutzer gemeint 
        [DataMember]
        public string surname { get; set; }                 // Hier ist der aktuell eingeloggte Benutzer gemeint 
        [DataMember]
        public string name { get; set; }                    // Kundendaten Tabelle: Firmenname   mm.name
        [DataMember]
        public string street { get; set; }                  // Kundendaten Tabelle: Straße   
        [DataMember]
        public string postal_code { get; set; }             // Kundendaten Tabelle: PLZ  
        [DataMember]
        public string location { get; set; }                // Kundendaten Tabelle: Ort  
        [DataMember]
        public string phone { get; set; }                   // Kundendaten Tabelle: Telefon Vorwahl + Telefon Rufnummer  
        [DataMember]
        public string email { get; set; }                   // Kundendaten Tabelle: Telefon 
        [DataMember]
        public string website { get; set; }                 // Kundendaten Tabelle: Webseite 
        [DataMember]
        public string kontonummer { get; set; }             //  Kundendaten Tabelle: Kontonummer
        [DataMember]
        public string bank { get; set; }                    // Kundendaten Tabelle: Bank
        [DataMember]
        public string blz { get; set; }                     // Kundendaten Tabelle: BLZ
        [DataMember]
        public string registergerichtundnummer { get; set; }// Kundendaten Tabelle: Registergericht und -nummer
        [DataMember]
        public string sitzdergesellschaft { get; set; }     // Kundendaten Tabelle: Sitz der Gesellschaft
        [DataMember]
        public string steuernummer { get; set; }            // Kundendaten Tabelle: Steuernummer
        [DataMember]
        public string umsatzsteuerid { get; set; }          // Kundendaten Tabelle: Umsatzsteuer-ID
        [DataMember]
        public int pv_plus_teilnehmer { get; set; }         // 0 = NEIN; 1 = JA Derzeit sind alle Standorte automatisch Mitglieder im PV:PLUS Programm. Daher immer 1.
        [DataMember]
        public float budgetlimit { get; set; }              // kommt aus dem VDB Webservice GetLogin 
        [DataMember]
        public int points { get; set; }                     // Aktuelle PV:PLUS Punkte, die im MM für Einkäufe zur Verfügung stehen.
        [DataMember]
        public bool praesentation { get; set; }             // Ob PräsentationsModus
        [DataMember]
        public bool hat_tuev_kkz { get; set; }              // Ob Tuev-Konzeptkennzeichen hat
        [DataMember]
        public bool hat_disq_kkz { get; set; }              // 19.01.2017, Konzeptkennzeichen 89 = DISQ für Autofitties 

    }
        
}