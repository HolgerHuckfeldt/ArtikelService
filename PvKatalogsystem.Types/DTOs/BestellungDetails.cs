using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    public class BestellungDetails
    {
        public BestellungDetails()
        {
            Positionen = new List<BestellungDetailsPosition>();
            Fehlpositionen = new List<BestellungDetailsPosition>();
        }

        public virtual bool NurLoseWareAnzeigen
        {
            get;
            set;
        }

        public Int32 Id
        {
            get;
            set;
        }

        //public virtual MandantEntity Mandant
        //{
        //    get;
        //    set;
        //}

        public virtual DateTime Bestelldatum
        {
            get;
            set;
        }

        public virtual string Kundennummer
        {
            get;
            set;
        }

        public virtual bool IstSuperflexPaketWK
        {
            get;
            set;
        }

        public virtual bool IstDealBestellng
        {
            get;
            set;
        }

        public virtual string Auftragsnummer
        {
            get;
            set;
        }

        public virtual bool PraesentationsBBS
        {
            get;
            set;
        }

        public virtual bool IstPlusBestellung
        {
            get;
            set;
        }

        public virtual string BestellId
        {
            get;
            set;
        }

        public virtual string Text
        {
            get;
            set;
        }

        public virtual String StandortName
        {
            get;
            set;
        }

        public virtual String StandortStrasse
        {
            get;
            set;
        }

        public virtual String StandortPlz
        {
            get;
            set;
        }

        public virtual String StandortOrt
        {
            get;
            set;
        }

        public virtual String StandortTel
        {
            get;
            set;
        }

        public virtual String StandortFax
        {
            get;
            set;
        }

        public virtual string Kundenanschrift
        {
            get;
            set;
        }

        public virtual string Einkaufswert
        {
            get;
            set;
        }

        public virtual BestellungLiefermodus Liefermodus
        {
            get;
            set;
        }

        public virtual string Lieferant
        {
            get;
            set;
        }

        public virtual string Versandadresse
        {
            get;
            set;
        }

        public virtual string Benutzername
        {
            get;
            set;
        }

        public virtual string Profilname
        {
            get;
            set;
        }

        public virtual string BestellArt
        {
            get;
            set;
        }

        public string BestellArtAnzeige
        {
            get
            {
                string returnVal = BestellArt.ToString();

                if (returnVal.Contains("PlusWarenkorbOnline"))
                    returnVal = "Plus Warenkorb Online bestellt";
                else if (returnVal.Contains("PlusWarenkorbPräsentationsbestellung"))
                    returnVal = "Plus Warenkorb Präsentationsbestellung";

                return returnVal;
            }
        }

        public virtual string BestellnotizAngabe
        {
            get;
            set;
        }
        public virtual string BestellnotizBestellnummer
        {
            get;
            set;
        }

        public virtual long Debug_ResponseIdValidateWarenkorb
        {
            get;
            set;
        }

        public virtual long Debug_ResponseIdPerformBestellung
        {
            get;
            set;
        }

        public virtual IList<BestellungDetailsPosition> Positionen
        {
            get;
            set;
        }

        /// <summary>
        /// Fehlpositionen aus der Offline-Bestellung
        /// </summary>
        public virtual IList<BestellungDetailsPosition> Fehlpositionen
        {
            get;
            set;
        }

        public virtual int PlusUmsatz
        {
            get;
            set;
        }
        public virtual int PlusAktion
        {
            get;
            set;
        }
        public virtual int PlusKonzept
        {
            get;
            set;
        }

        public virtual int PlusOnline
        {
            get;
            set;
        }
        public virtual int PlusLiefer
        {
            get;
            set;
        }
        public virtual int PlusTausch
        {
            get;
            set;
        }
        public virtual int PlusGesamt
        {
            get;
            set;
        }

        public virtual string OfflineBestellId { get; set; }

        public virtual string FehlerText { get; set; }

        // DH: AuslöserKennzeichen (0 => Benutzer, 1 => VBA, 2 => VBI)
        //public virtual AusloeserKennzeichen AusloeserKennzeichen { get; set; }

        public byte[] StandortLogo { get; set; }
    }
}
