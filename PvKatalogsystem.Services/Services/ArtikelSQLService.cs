using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using PvKatalogsystem.Services.Services.Repositories;
using PvKatalogsystem.Services.SqlQueries.Mapper;
using PvKatalogsystem.Types.DTOs;

namespace ArtikelService.Services
{
    public class ArtikelSQLService
    {
        private readonly String _connectionStringexterneArtikeldaten;

        public ArtikelSQLService( String connectionStringexterneArtikeldaten)
        {
            //_katalogDatabaseConnection = connectionString;
            _connectionStringexterneArtikeldaten = connectionStringexterneArtikeldaten;
            //_kundendatenUndProfileConnectionString = kundendatenUndProfileConnectionString;
        }

        public List<CsoFuerArtikelsuche> GetCsoFuerArtikelsuche()
        {
            using (var repository = ArtikelSQLRepository.GetInstanceInUnitOfWork(_connectionStringexterneArtikeldaten))
            {
                try
                {
                    List<CsoFuerArtikelsuche> result = new List<CsoFuerArtikelsuche>();
                    DataSet csoFuerArtikelsucheSet = repository.GetCsoFuerArtikelsuche();

                    if (csoFuerArtikelsucheSet != null && csoFuerArtikelsucheSet.Tables.Count > 0)
                    {
                        result = CsoFuerArtikelsucheMapper.MapCsoFuerArtikelsuche(csoFuerArtikelsucheSet.Tables[0]);
                    }

                    return result;
                }
                catch (Exception ex)
                {

                }

                return new List<CsoFuerArtikelsuche>();
            }
        }

        protected String GetEmbeddedSqlScript(String sqlScriptName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PvKatalogsystem.Services.SqlQueries." + sqlScriptName + ".sql");
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
