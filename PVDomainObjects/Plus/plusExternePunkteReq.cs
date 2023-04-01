using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Plus
{
    [Serializable]
    public class plusExternePunkteRequest
    {
        public string Bezeichnung { get; set; }
        public int Bonuspunkte { get; set; }
        public BonustypExtP Bonustyp { get; set; }
        //Zweggebunden, Gesperrt
        public List<Transaktionsflag> Transaktionsflags { get; set; }
        public DateTime Verfuegbarkeitsdatum { get; set; }

        public VdbUserInfo VdbUserInfo { get; set; }
    }

    [Serializable]
    public enum BonustypExtP
    {

        Summe,
        Umsatz,
        Umsatzposition,
        Aktion,
        Aktionposition,
        Online,
        Konzept,
        Konzeptposition,
        Tausch,
        Tauschposition,
        KompassBestellBonus,
        KompassBestellBonusposition,
        Liefer,
        Lieferposition,
    }

    [Serializable]
    public sealed class VdbUserInfo
    {
        public int Kundenummer { get; set; }
        public int Standort { get; set; }
        public int Abteilung { get; set; }
        public int Firma { get; set; }
        public int Versandadresse { get; set; }
    }

    [Serializable]
    public enum Transaktionsflag
    {
        Zweckgebunden,
        Gesperrt,
    }
}
