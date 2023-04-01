using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    public class Suchbaumknoten
    {
        public string Bezeichnung { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public bool IsEndknoten { get; set; }
        public int TemotStripId { get; set; }
        public int Ebene { get; set; }
        public int Nummer { get; set; }
        public bool SuchknotenGrafik { get; set; }
        
        public bool IsTemotStrip { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {{{1}}} (ParentId: {2})", Bezeichnung, Id, ParentId);
        }
    }
}
