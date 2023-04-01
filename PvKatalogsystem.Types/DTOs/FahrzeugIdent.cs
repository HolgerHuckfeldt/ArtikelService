using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    public class FahrzeugIdent
    {
        public FahrzeugIdent(Fahrzeugart fzgArt, int fzgId)
        {
            Fahrzeugart = fzgArt;
            FahrzeugId = fzgId;
        }

        public Fahrzeugart Fahrzeugart { get; set; }
        public int FahrzeugId { get; set; }
    }
}
