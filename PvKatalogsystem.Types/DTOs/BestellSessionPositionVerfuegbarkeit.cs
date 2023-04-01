using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    public class BestellSessionVerfuegbarkeitsinfo
    {
        public int Id { get; set; }

        /// <summary>
        /// Verfuegbarkeit der Unterposition
        /// </summary>
        public VdbVerfuegbarkeit Verfuegbarkeit { get; set; }

        /// <summary>
        /// AbholVerfuegbarkeit der Unterposition
        /// </summary>
        public VdbVerfuegbarkeit AbholVerfuegbarkeit { get; set; }

        /// <summary>
        /// Lieferdatum der Unterposition
        /// </summary>
        public DateTime? Liefertour { get; set; }

        public string LiefertourString { get; set; }
        public string LiefertourString2 { get; set; }

        /// <summary>
        /// Lieferdatum der Unterposition
        /// </summary>
        public DateTime? Abholzeitpunkt { get; set; }

        public string SelbstabholungString { get; set; }
        public string SelbstabholungString2 { get; set; }

        /// <summary>
        /// Reservierungszeit der Unterposition in der VDB
        /// </summary>
        public DateTime? Bestellschlusszeit { get; set; }

        public Decimal Menge { get; set; }

        /// <summary>
        /// Angabe des VDB-Status einer Unterposition: Neu, Reserviert, StuecklimitErreicht,
        /// BestelllimitErreicht, ArtikelNotFound, Kreditlimit, NichtLieferbar
        /// </summary>
        public BestellungPositionStatus Status { get; set; }

        public string UnterpositionCaption { get; set; }
        public string UnterpositionText { get; set; }

        public bool UnterpositionHinweisVisible { get; set; }
    }
}
