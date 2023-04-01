using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class TemotStripElement
    {
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public Int32 StripElementsId { get; set; }
        /// <summary>
        /// kleine Hotspots über grossen -> von gross nach klein
        /// </summary>
        [DataMember]
        public Int32 SortNumber { get; set; }
        [DataMember]
        public Int32 HS_PosX { get; set; }
        [DataMember]
        public Int32 HS_PosY { get; set; }
        [DataMember]
        public Int32 HS_Width { get; set; }
        [DataMember]
        public Int32 HS_Height { get; set; }
    }
}
