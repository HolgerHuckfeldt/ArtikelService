using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class TemotStripElement
    {
        public Int32 Id { get; set; }
        public Int32 StripElementsId { get; set; }
        /// <summary>
        /// kleine Hotspots über grossen -> von gross nach klein
        /// </summary>
        public Int32 SortNumber { get; set; }
        public Int32 HS_PosX { get; set; }
        public Int32 HS_PosY { get; set; }
        public Int32 HS_Width { get; set; }
        public Int32 HS_Height { get; set; }
    }
}
