using PvKatalogsystem.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class UebergabeFuerSolr
    {
        public int GenArtId { get; set; }
        public Suchbaumtyp SbTyp { get; set; }
        public Fahrzeugart FzgArt { get; set; }
        public int FzgId { get; set; }
        public int StartIndex { get; set; }
        public int RowCount { get; set; }
        public bool Mobile { get; set; }
        public List<int> GenArtList { get; set; }
        public int VorgaengerKnoten { get; set; }
        public int VorgaengerKnotenTiefe { get; set; }
        public int VorgaengerParentIdKnoten { get; set; }
        public bool SuchknotenGrafik { get; set; }
        public bool SuchstringFuerHersteller { get; set; }
        public String Suchstring { get; set; }
    }
}
