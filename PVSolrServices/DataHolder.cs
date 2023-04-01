using PvKatalogsystem.Types.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVSolrServices
{
    public class DataHolder
    {
        private static readonly object InstanceLock = new object();

        private IList<CsoFuerArtikelsuche> _csoFuerArtikelsuche;

        private static DataHolder _instance;

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
            List<CsoFuerArtikelsuche> result = new List<CsoFuerArtikelsuche>(); // _artikelSQLService.GetCsoFuerArtikelsuche();
            result.Add(new CsoFuerArtikelsuche()
            {
                CountrySalesOrganisationsId= 102,
                CsoCode = "001",
                AnzeigeSuchbaum = new List<string>(){"001"},
                AnzeigeNummernsuche = new List<string>(){"001","104","105","106","107","108","109","113","114","115","117","119","122","123","125","NONE"},
                AnzeigeTeaser = new List<string>(){"001"},
                NichtAnzeigenSuchbaum = new List<string>(){"9988","6666","7777","8888"},
                NichtAnzeigenNummernsuche = new List<string>(){"9988","6666","7777","8888"},
                NichtAnzeigenTeaser = new List<string>(){"9988","6666","7777","8888"},
                WeitereHersteller_beruecksichtigen = true
            });
            return result;
        }


    }
}
