    /******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelidentifikation
* Funktionen: Schnittstelle des Managers für AchsArtikel. Dieser entspricht 1:1 dem Artikelmanager
*             und ist nur für Unity erforderlich
*****************************************************************************************************/

using PV.DomainObjects.Fahrzeug;
namespace PV.Business.Services
{
    public interface IAchsenArtikelManager : IArtikelManager
    {
        Achse CurrentTyp
        {
            get;
            set;
        }
    }
}
