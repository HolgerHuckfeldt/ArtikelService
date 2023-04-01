using System.Collections.Generic;
using System.Data;
using System.Linq;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.SqlQueries.Mapper
{
    public class CsoFuerArtikelsucheMapper
    {
        public static List<CsoFuerArtikelsuche> MapCsoFuerArtikelsuche(DataTable dataTable)
        {
            List<CsoFuerArtikelsuche> csoFuerArtikelsuche = new List<CsoFuerArtikelsuche>();
            foreach (DataRow row in dataTable.Rows)
            {
                csoFuerArtikelsuche.Add(new CsoFuerArtikelsuche()
                {
                    CountrySalesOrganisationsId = row.Field<int>("CountrySalesOrganisationsId"),
                    CsoCode = row.Field<string>("CsoCode"),
                    WeitereHersteller_beruecksichtigen = row.Field<bool>("WeitereHersteller_beruecksichtigen")
                });

                if (row.Field<string>("Cso_AnzeigeSuchbaum") != null)
                {
                    var anzeigeSuchbaum = row.Field<string>("Cso_AnzeigeSuchbaum").Split(';').ToList<string>();

                    csoFuerArtikelsuche.Last().AnzeigeSuchbaum = new List<string>();
                    csoFuerArtikelsuche.Last().AnzeigeSuchbaum.AddRange(anzeigeSuchbaum);
                }

                if (row.Field<string>("Cso_AnzeigeNummernsuche") != null)
                {
                    var anzeigeNummernsuche = row.Field<string>("Cso_AnzeigeNummernsuche").Split(';').ToList<string>();

                    csoFuerArtikelsuche.Last().AnzeigeNummernsuche = new List<string>();
                    csoFuerArtikelsuche.Last().AnzeigeNummernsuche.AddRange(anzeigeNummernsuche);
                }
                if (row.Field<string>("Cso_AnzeigeTeaser") != null)
                {
                    var anzeigeTeaser = row.Field<string>("Cso_AnzeigeTeaser").Split(';').ToList<string>();

                    csoFuerArtikelsuche.Last().AnzeigeTeaser = new List<string>();
                    csoFuerArtikelsuche.Last().AnzeigeTeaser.AddRange(anzeigeTeaser);
                }
                if (row.Field<string>("Cso_NichtAnzeigenSuchbaum") != null)
                {
                    var nichtAnzeigenSuchbaum = row.Field<string>("Cso_NichtAnzeigenSuchbaum").Split(';').ToList<string>();

                    csoFuerArtikelsuche.Last().NichtAnzeigenSuchbaum = new List<string>();
                    csoFuerArtikelsuche.Last().NichtAnzeigenSuchbaum.AddRange(nichtAnzeigenSuchbaum);
                }
                if (row.Field<string>("Cso_NichtAnzeigenNummernsuche") != null)
                {
                    var nichtAnzeigenNummernsuche = row.Field<string>("Cso_NichtAnzeigenNummernsuche").Split(';').ToList<string>();

                    csoFuerArtikelsuche.Last().NichtAnzeigenNummernsuche = new List<string>();
                    csoFuerArtikelsuche.Last().NichtAnzeigenNummernsuche.AddRange(nichtAnzeigenNummernsuche);
                }
                if (row.Field<string>("Cso_NichtAnzeigenTeaser") != null)
                {
                    var nichtanzeigeTeaser = row.Field<string>("Cso_NichtAnzeigenTeaser").Split(';').ToList<string>();

                    csoFuerArtikelsuche.Last().NichtAnzeigenTeaser = new List<string>();
                    csoFuerArtikelsuche.Last().NichtAnzeigenTeaser.AddRange(nichtanzeigeTeaser);
                }
                
            }

            return csoFuerArtikelsuche;
        }
    }
}
