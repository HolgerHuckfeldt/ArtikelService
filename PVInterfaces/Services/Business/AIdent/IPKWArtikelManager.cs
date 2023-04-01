/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelidentifikation
* Funktionen: Schnittstelle des Managers für PKWArtikel. Dieser entspricht 1:1 dem Artikelmanager
*             und ist nur für Unity erforderlich
*****************************************************************************************************/

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PV.DomainObjects.Dvse;

namespace PV.Business.Services
{
    public interface IPKWArtikelManager : IArtikelManager
    {
        bool SuchstringFuerHersteller { get; set; }

        bool IsStartseitenartikelsuche { get; set; }

        int AutosuggestGenArtId { get; set; }

        void LoadArtikelByNumberOrGenArtList(string nr, bool _mitWeiterenHerstellern, List<KeyValuePair<int,string>> genArts);

        /// <summary>
        /// Für Dvse-Grafiksuche. Obwohl über OE-Nummern gesucht wird, muss das in den PkwArtikelManager, nicht in den NummernArtikelManager.
        /// </summary>
        /// <param name="nr"></param>
        void LoadArtikelByOe(string nr);

        void DvseWeitereHersteller(bool weitereHersteller);

        void PrNummernFilter(bool set);

        DvseData DvseInfos
        {
            get;
        }

        string SendDvseAuth();

        string SendAuthToken(string destName);

    }
}
