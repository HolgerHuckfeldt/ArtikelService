using ArtikelService.Services;
using PvKatalogsystem.Types.DTOs;

namespace ArtikelService
{
    public class DataHolder
    {
        private static readonly object InstanceLock = new object();

        private static DataHolder _instance = null;

        private readonly ArtikelSQLService _artikelSQLService;

        /// <summary>
        /// Liefert die einzige Instanz des Singleton
        /// </summary>
        public static DataHolder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        _instance = new DataHolder();
                    }
                }

                return _instance;
            }
        }

        private DataHolder()
        {
            _artikelSQLService = new ArtikelSQLService("Data Source=10.29.6.40;Initial Catalog=ExterneArtikeldaten;Persist Security Info=True;User ID=pimsimport;Password=pimsimport");
        }


        private IList<CsoFuerArtikelsuche> _csoFuerArtikelsuche;

        public IList<CsoFuerArtikelsuche> CsoFuerArtikelsuche
        {
            get
            {
                if (_csoFuerArtikelsuche == null || _csoFuerArtikelsuche.Count == 0)
                {
                    _csoFuerArtikelsuche = LoadCsoFuerArtikelsuche();
                }
                return _csoFuerArtikelsuche;
            }
        }

        private List<CsoFuerArtikelsuche> LoadCsoFuerArtikelsuche()
        {
            List<CsoFuerArtikelsuche> result = _artikelSQLService.GetCsoFuerArtikelsuche();

            return result;
        }


    }
}
