using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using ArtikelService.Services;
using Microsoft.Data.SqlClient;

namespace PvKatalogsystem.Services.Services.Repositories
{
    [Serializable]
    internal abstract class BaseRepository : IDisposable
    {
        protected BaseRepository(String connectionString)
        {
            _currentConnection = new SqlConnection(connectionString);
            _currentConnection.Open();
        }

        protected String GetEmbeddedSqlScript(String sqlScriptName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ArtikelService.PvKatalogsystem.Services.SqlQueries." + sqlScriptName + ".sql");
            if (stream == null)
            {
                throw new ApplicationException(ErrorMessages.message_embedded_sqlscript_not_found);
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        protected SqlConnection GetConnection()
        {
            return _currentConnection;
        }

        private readonly SqlConnection _currentConnection;
        private Boolean _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_currentConnection != null)
                    {
                        _currentConnection.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
