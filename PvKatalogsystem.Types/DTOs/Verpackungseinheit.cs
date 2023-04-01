
namespace PvKatalogsystem.Types.DTOs
{
    public class Verpackungseinheit : DtoBase
    {
        public Verpackungseinheit()
        {
            Faktor = -1;
        }

        public string Bezeichnung { get; set; }
        public decimal Faktor { get; set; }
        public decimal Menge { get; set; }
        public bool IsGanzzahl { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", Bezeichnung, Faktor, IsGanzzahl ? "(IsGanzzahl)" : "");
        }
    }
}
