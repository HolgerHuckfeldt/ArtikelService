
using System.Collections;
namespace PvKatalogsystem.Types.Enums
{
    public class Fahrzeugart
    {
        public static Fahrzeugart Ohne = new Fahrzeugart(null);
        public static Fahrzeugart Pkw = new Fahrzeugart("PC");
        public static Fahrzeugart Lkw = new Fahrzeugart("CV");
        public static Fahrzeugart Motor = new Fahrzeugart("ENG");
        public static Fahrzeugart Achse = new Fahrzeugart("AX");

        public Fahrzeugart() {}
        public Fahrzeugart(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }
}
