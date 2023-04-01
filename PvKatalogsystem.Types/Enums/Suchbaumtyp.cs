using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Enums
{
    public class Suchbaumtyp
    {
        public static Suchbaumtyp Pkw = new Suchbaumtyp("PC");
        public static Suchbaumtyp Lkw = new Suchbaumtyp("CV");
        public static Suchbaumtyp Achse = new Suchbaumtyp("AX");
        public static Suchbaumtyp Motor = new Suchbaumtyp("ENG");
        public static Suchbaumtyp Universal = new Suchbaumtyp("UNI");
        public static Suchbaumtyp Incentive = new Suchbaumtyp("INCENTIVE");
        public static Suchbaumtyp Tankstelle = new Suchbaumtyp("TANKSTELLE");
        public static Suchbaumtyp Praemien = new Suchbaumtyp("PRAEMIEN");
        public static Suchbaumtyp Trainings = new Suchbaumtyp("TRAININGS");
        public static Suchbaumtyp Pitstop = new Suchbaumtyp("pistop");
        public static Suchbaumtyp None = new Suchbaumtyp("NONE");

        private Suchbaumtyp() { }
        private Suchbaumtyp(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        
    }
}
