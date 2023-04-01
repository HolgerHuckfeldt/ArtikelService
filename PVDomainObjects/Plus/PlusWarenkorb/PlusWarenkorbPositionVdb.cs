using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Plus.PlusWarenkorb
{
    public class PlusWarenkorbPositionVdb
    {
        public PlusWarenkorbPositionVdb(Decimal menge, Int32 positionsNummer, String vdbArtikelnummer, String hlk, int preisBonuspunkte)
        {
            Menge = menge;
            PositionsNummer = positionsNummer;
            VdbArtikelnummer = vdbArtikelnummer;
            Hlk = hlk;
            PreisBonuspunkte = preisBonuspunkte;
        }

        public String VdbArtikelnummer { get; private set; }
        public String Hlk { get; private set; }
        public Decimal Menge { get; private set; }
        public int PreisBonuspunkte { get; private set; }
        public Int32 PositionsNummer { get; private set; }
    }
}
