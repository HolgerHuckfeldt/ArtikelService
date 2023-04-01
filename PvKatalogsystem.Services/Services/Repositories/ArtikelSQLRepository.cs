using System;
using System.Data;
using System.IO;
using System.Reflection;
using ArtikelService.Services;
using Microsoft.Data.SqlClient;

namespace PvKatalogsystem.Services.Services.Repositories
{
    internal class ArtikelSQLRepository : BaseRepository
    {
        //private readonly SqlConnection _currentConnection;
        private Boolean _disposed = false;

        public static ArtikelSQLRepository GetInstanceInUnitOfWork(String connectionString)
        {
            return new ArtikelSQLRepository(connectionString);
        }

        private ArtikelSQLRepository(String connectionString)
            : base(connectionString)
        {
        }

        internal DataSet GetCsoFuerArtikelsuche()
        {
            DataSet queryResult = new DataSet();
            String query = GetEmbeddedSqlScript("Article.GetCsoFuerArtikelsuche");

            using (var connection = GetConnection())
            {
                var command = new SqlCommand(query, connection);

                new SqlDataAdapter(command).Fill(queryResult);
            }

            return queryResult;
        }

        //protected SqlConnection GetConnection()
        //{
        //    return _currentConnection;
        //}

        protected String GetEmbeddedSqlScript(String sqlScriptName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ArtikelService.PvKatalogsystem.SqlQueries." + sqlScriptName + ".sql");
            if (stream == null)
            {
                throw new ApplicationException(ErrorMessages.message_embedded_sqlscript_not_found);
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
