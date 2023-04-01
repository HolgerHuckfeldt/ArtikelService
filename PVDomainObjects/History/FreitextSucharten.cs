using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.History
{
    [Serializable]
    public enum FreitextSucharten
    {
        PKWFreitextsuche,
        NKWFreitextsuche,
        AchsenFreitextsuche,
        MotorenFreitextsuche,

        PKWArtikelFreitextsuche,
        NKWArtikelFreitextsuche,
        AchsenArtikelFreitextsuche,
        MotorenArtikelFreitextsuche,
        UniversalArtikelFreitextsuche,
        NummernArtikelFreitextsuche,

        ArbeitswerteFreitextsuche,

        KundenFreitextsuche,
        EigeneArtikelFreitextsuche,
        EigeneAWFreitextsuche,
        KVAFreitextsuche,

        TechnikFreitextsuche,
        WartungFreitextsuche,
        WartungArbeitswertFreitextsuche,
        TrainingOrtFreitextsuche,
        TrainingKategorieFreitextsuche,

        PlusAuszugFreitextsuche,

        BestellungFreitextSuchHistory

    }
}
