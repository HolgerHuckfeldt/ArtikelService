using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    [DataContract]
    public class SensitiveArea
    {
        public SensitiveArea()
        {
            ArtikelIds = new List<int>();
        }

        [DataMember]
        public Rectangle Coords { get; set; }

        [DataMember]
        public List<int> ArtikelIds { get; set; }

        [DataMember]
        public string BackgroundPictureFileName { get; set; }
    }
}
