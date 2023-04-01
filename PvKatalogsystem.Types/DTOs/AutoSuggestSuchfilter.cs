using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class AutoSuggestSuchfilter
    {
        public string Suchstring { get; set; }
        public int FahrzeugId { get; set; }
        public int MaxCount { get; set; }
        public PvKatalogsystem.Types.Enums.Suchbaumtyp Suchbaumtyp { get; set; }
        public string CsoCode { get; set; }
        public bool ShowBLieferanten { get; set; }
        public bool ShowHersteller { get; set; }
        public bool ShowPC { get; set; }
        public bool ShowUNI { get; set; }
        public float SpellCheckAccuracy { get; set; }
        public int MaxAutosuggestForSpellcheck { get; set; }
    }
}
