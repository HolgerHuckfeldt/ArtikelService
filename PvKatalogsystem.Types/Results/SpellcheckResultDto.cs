using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Results
{
    public class SpellcheckResultDto
    {
        public string Word { get; set; }
        public string WordDisplay { get; set; }
        public int Freq { get; set; }
        public int OrderId { get; set; }
        public bool ValueCorrect { get; set; }
    }
}
