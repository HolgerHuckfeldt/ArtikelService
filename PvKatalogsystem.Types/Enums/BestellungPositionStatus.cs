using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Enums
{
    public enum BestellungPositionStatus
    {
        Reserviert = 0,
        StuecklimitErreicht = 1,
        BestelllimitErreicht = 2,
        ArtikelNotFound = 3,
        Kreditlimit = 4,
        NachtexpressNichtmoeglich = 7,
        UnterpositionNichtLieferbar = 8,
        NichtLieferbar = 9,
        Neu = 99
    }

}
