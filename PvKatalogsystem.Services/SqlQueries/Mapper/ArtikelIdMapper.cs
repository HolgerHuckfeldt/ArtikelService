using System.Collections.Generic;
using System.Data;

namespace PvKatalogsystem.Services.SqlQueries.Mapper
{
    public class ArtikelIdMapper
    {
        public static List<int> MapArtikelIds(DataTable dataTable)
        {
            List<int> artikelIds = new List<int>();

            foreach (DataRow row in dataTable.Rows)
            {
                artikelIds.Add(row.Field<int>("ArtikelId"));
            }

            return artikelIds;
        }
    }
}
