using System.Collections.Generic;
using System.Data;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.SqlQueries.Mapper
{
    public class VerwandteArtikelMapper
    {
        public static List<VerwandteArtikel> MapVerwandteArtikel(DataTable dataTable)
        {
            List<VerwandteArtikel> verwandteArtikel = new List<VerwandteArtikel>();
            foreach (DataRow row in dataTable.Rows)
            {
                verwandteArtikel.Add(new VerwandteArtikel() 
                { 
                    //ArtikelId = row.Field<int>("ArtikelId"),
                    UnterartikelId = row.Field<int>("UnterartikelId"),
                    Amount = row.Field<decimal>("Amount"),
                    SameKTypeOnly = row.Field<bool>("SameKTypeOnly"),
                    Typ = row.Field<string>("Typ"),

                });
            }

            return verwandteArtikel;
        }
    }
}
