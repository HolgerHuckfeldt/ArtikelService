using System;
using PV.DomainObjects.Fahrzeug;
/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelidentifikation
* Funktionen: Schnittstelle des Managers für MotorenArtikel. Dieser entspricht 1:1 dem Artikelmanager
*             und ist nur für Unity erforderlich
*****************************************************************************************************/

namespace PV.Business.Services
{
    public interface IMotorenArtikelManager : IArtikelManager
    {
        Motor CurrentTyp
        {
            get;
            set;
        }
    }
}
