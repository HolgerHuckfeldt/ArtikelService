/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelidentifikation
* Funktionen: Schnittstelle des Managers für UniversalArtikel. Dieser entspricht 1:1 dem Artikelmanager
*             und ist nur für Unity erforderlich
*****************************************************************************************************/

namespace PV.Business.Services
{
    public interface IUniversalArtikelManager : IArtikelManager
    {
        bool SuchstringFuerHersteller { get; set; }

        bool IsStartseitenartikelsuche { get; set; }

        int AutosuggestGenArtId { get; set; }
    }
}
