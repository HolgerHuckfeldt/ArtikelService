using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    public class BestellRequest
    {
        public string Kommentar { get; set; }

        public VdbUserInfo VdbUserInfo { get; set; }

        public long BestellId { get; set; }

        public string Zahlweise { get; set; }

        public string KundenEigeneBestellnummer { get; set; }

        public long Lieferbonus { get; set; }

        public DateTime? Lieferzeitpunkt { get; set; }

        public BestellungLiefermodus Lieferart { get; set; }

        public bool Storno { get; set; }

        public string OfflineBestellId { get; set; }
    }
}
