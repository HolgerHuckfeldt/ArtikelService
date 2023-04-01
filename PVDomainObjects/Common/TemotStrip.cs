using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Drawing;
using System.Windows;


namespace PV.DomainObjects.Common
{
    [Serializable]
    public class TemotStrip
    {
        public Int32 X0 { get; set; }
        public Int32 X1 { get; set; }
        public Int32 X2 { get; set; }
        public Int32 X3 { get; set; }
        public Int32 Y0 { get; set; }
        public Int32 Y1 { get; set; }
        public Int32 Y2 { get; set; }
        public Int32 Y3 { get; set; }
        public List<String> Artikelnummern { get; set; }
        public List<int> ArtikelIds { get; set; }

    }
}
