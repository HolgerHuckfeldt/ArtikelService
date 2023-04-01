using System;
using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class News
    {
        //News			
        //Text		
        //Typ		
        //Fehlercode (allg.)
        [DataMember]
        public List<string> NewsN { get; set; } //Liefert dem Kompass-System eine Liste 
        //aktuell gültiger Informationen zur VDB. 
        //Liegen neue Infos vor, muss die NewsID, 
        //die von jeder VDB Methode zurückgeliefert wird, geändert werden.
        [DataMember]
        public List<int> Typ { get; set; } //Typ der Systemnachricht, vorläufig immer 0
    }

    [DataContract]
    [Serializable]
    public class KontoInfos
    {
        //Kontostand verfügbar
        //Kontostand gesamt
        //Kontostand zweckgebunden
        //Monatliches Kreditlimit
        //Fehlercode (allg.)
        [DataMember]
        public long KontostandVerfuegbar { get; set; } //Saldo des Bonuskontos, alle Bonuspunkte,
        //die am aktuellen Systemdatum verfügbar sind
        [DataMember]
        public long KontostandGesamt { get; set; } //Saldo des Bonuskontos, alle Bonuspunkte
        [DataMember]
        public long KontostandZweckgebunden { get; set; } //Saldo des Bonuskontos, alle zweckgebundenen Bonuspunkte
        [DataMember]
        public long MonatlichesKreditlimit { get; set; }
        [DataMember]
        public bool VDBVerfuegbar { get; set; }
        [DataMember]
        public string Fehlercode { get; set; } //Abfrage des monatlichen Kreditlimits (nicht noch verfügbare Bestellsumme)
        //relevant für Madiamaster
    }

    [DataContract]
    [Serializable]
    public class Kontoauszug
    {
        private List<Transaktionen> _ViewableBuchungen;

        public List<Transaktionen> ViewableBunchungen
        {
            get
            {
                if (_ViewableBuchungen == null)
                    return Transaktion;
                return _ViewableBuchungen;
            }

            set
            {
                _ViewableBuchungen = value;
            }
        }

        [DataMember]
        public int KontostandVerfuegbarkeit { get; set; } //Saldo des Bonuskontos, alle Bonuspunkte,
        //die am aktuellen Systemdatum verfügbar sind
        [DataMember]
        public long KontostandGesamt { get; set; } //Saldo des Bonuskontos, alle Bonuspunkte
        [DataMember]
        public long KontostandZweckgebunden { get; set; } //Saldo des Bonuskontos, alle zweckgebundenen Bonuspunkte
        [DataMember]
        public string Fehlercode { get; set; } //Titel, Zusatz, Betrag, verfügbar ab
        [DataMember]
        public List<Transaktionen> Transaktion { get; set; }
        [DataMember]
        public List<string> UmsatzartenListe { get; set; }
        [DataMember]
        public string UmsatzartSelectedValue { get; set; }
        [DataMember]
        public bool VDBVerfuegbar { get; set; }
    }

    [DataContract]
    [Serializable]
    public class Transaktionen
    {
        //Bezeichnung		
        //Bestellnummer		
        //Buchungsdatum		
        //Punktebetrag		
        //Sperrkennzeichen		
        //Verfügbarkeit		
        //Zweckgebundenheit	
        public string BestellnummerDatum
        {
            get
            {
                string _BestellnummerDatum = "";
                _BestellnummerDatum = BezeichnungBestellnummerDatum;
                return _BestellnummerDatum;
            }
        } //Bezeichnung der Tansaktion 
        [DataMember]
        public string Bezeichnung { get; set; } //Bezeichnung der Tansaktion 
        [DataMember]
        public string BezeichnungBestellnummerDatum { get; set; } //Bezeichnung der Tansaktion 
        [DataMember]
        public long Bestellnummer { get; set; } //Bei Boni auf Basis Bestellung: Refernez zu Bestellung
        [DataMember]
        public String Buchungsdatum { get; set; } //Datum der Buchung
        [DataMember]
        public DateTime BuchungsdatumDateTime { get; set; } //Datum der Buchung
        [DataMember]
        public int BonusPunkteNichtZweckgebunden { get; set; } //Betrag der Transaktion
        [DataMember]
        public int BonusPunkteZweckgebunden { get; set; } //Betrag der Transaktion
        [DataMember]
        public int BonusPunkteGesperrt { get; set; } //Betrag der Transaktion
        [DataMember]
        public int BonusPunkteNichtGesperrt { get; set; } //Betrag der Transaktion
        [DataMember]
        public bool Sperrkennzeichen { get; set; } //Kennzeichen  für manuelle Freigabe
        [DataMember]
        public bool Zweckgebundenheit { get; set; } //Zweckgebundenheit ja/nein
        [DataMember]
        public string ZweckgebundenheitString { get; set; } //Zweckgebundenheit ja/nein
        [DataMember]
        public String Verfuegbarkeitsdatum { get; set; } //Datum der Verfügbarkeit
        [DataMember]
        public DateTime VerfuegbarkeitsdatumDateTime { get; set; }
        [DataMember]
        public decimal Soll { get; set; } //Zweckgebundenheit ja/nein
        [DataMember]
        public decimal Haben { get; set; } //Datum der Verfügbarkeit
    }

    [DataContract]
    [Serializable]
    public class ExternPunkte
    {
        //Buchungsart
        //Betrag
        //Bezeichnung
        //Bonusart
        //Zweckgebundenhe
        //Sperrkennzeichen
        //Verfügbarkeit
        //Fehlercode (allg.)
        [DataMember]
        public int Buchungsart { get; set; } //Gutschrift oder Lastschrift +1/-1
        [DataMember]
        public long Betrag { get; set; } //Zu buchender Wert
        [DataMember]
        public string Bezeichnung { get; set; } //Bezeichnung der Transaktion
        [DataMember]
        public string Bonusart { get; set; }  //eigenglich ein Bonus-Typ, muss noch definiert werden
        //Art des Bonus (Umsatz-, Aktions-, Konzeptbonus ...)
        [DataMember]
        public bool Zweckgebundenheit { get; set; } //Flag, ob Bonus zweckgebunden ist oder nicht
        [DataMember]
        public string Sperrkennzeichen { get; set; } //Kennzeichen für manuelle Freigabe bei unbestimmter Verfügbarkeit
        [DataMember]
        public DateTime Verfügbarkeit { get; set; } //Datum, ab dem Bonus gültig ist; 
        //(zu klären: Wie gehen wir mit unbestimmter Gültigkeit um? 
        //Antwort: Sperrkennzeichen)
        [DataMember]
        public string Fehlercode { get; set; }

    }
}
