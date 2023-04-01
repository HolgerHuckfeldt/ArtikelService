using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class TemotStrip
    {
        public TemotStrip()
        {
            StripElements = new List<TemotStripElement>();
            StripElementsIdArticleIds = new List<KeyValuePair<int, int>>();
        }

        public String StripImageUri { get; set; }
        public Int32 ImgWidth { get; set; }
        public Int32 ImgHeight { get; set; }
        public List<TemotStripElement> StripElements { get; set; }
        public List<KeyValuePair<int, int>> StripElementsIdArticleIds { get; set; }
    }
}
