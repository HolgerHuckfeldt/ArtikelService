using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    public interface IArtikelProviderRequest
    {
        int Absatzgruppe { get; }
        int Kundengruppe { get; }
        int Firma { get; }
        int Standort { get; }
        int Abteilung { get; }
        bool IsPlusKunde { get; }
        bool IsPitStop { get; }
        string AlternativeCSO { get; }
        int? ProfilId { get; }
        bool IsStahlgruberAbfrage { get; }
    }
}
