using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    public class ArtikelSuchoptionen
    {
        public FahrzeugIdent Fahrzeug { get; set; }
        public Suchbaumtyp Suchbaumtyp { get; set; }
        public int GenArtId { get; set; }
        public IEnumerable<string> Herstellerkuerzel { get; set; }
        public bool ShowNurLieferbar { get; set; }
        public bool ShowAllPseudoartikel { get; set; }
        public bool SearchOnNumbers { get; set; }
        public float SpellCheckAccuracy { get; set; }
        public bool IsNfzUniversalArtikel { get; set; }
        public bool ShowGenArtFacets { get; set; }
        public IEnumerable<ArtikelAktionsFilter> AktionenOnTop { get; set; }
        public bool ShowOutletOnly { get; set; }
        public string TeaserId { get; set; }
        public IEnumerable<string> Artikelnummer { get; set; }
        public IDictionary<string, List<string>> HlkArtNr { get; set; }
        public Int64 Aktionsnummer { get; set; } 
    }

    public class ArtikelSuchoptionenFuerNummernsuche
    {
        public string Nummer { get; set; }
        public string Hersteller { get; set; }
        public bool NurLieferbareArtikelAnzeigen { get; set; }
        public bool KeinePseudoartikel { get; set; }
        public int StartIndex { get; set; }
        public int RowCount { get; set; }
        public ArtNummernsuche ArtNummernsuche { get; set; }
        public bool Mobile { get; set; }
        public string Teasertyp { get; set; }
        public Fahrzeugart FzgArt { get; set; }
        public int FzgId { get; set; }
        public Suchbaumtyp SbTyp { get; set; }
    }

    public class ArtikelSuchoptionenFuerGetSuchbaumknoten
    {
        public Suchbaumtyp Suchbaumtyp { get; set; }
        public Fahrzeugart FahrzeugArt { get; set; }
        public int FahrzeugId { get; set; }
        public bool Mobile { get; set; }
        public bool NurSensitiveArea { get; set; }
    }
}
