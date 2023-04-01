/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelsuche
* Funktionen: Abstrahiert die Schnittstelle
*****************************************************************************************************/

using PV.DomainObjects.Artikel;
using PV.Utilities.Misc;

namespace PV.Business.Services
{
    public interface IZubehoerListenManager
    {
        /// <summary>
        /// Liefert Verwandte Artikel zu dem Artikel UND seinem generischen Artikel
        /// </summary>
        /// <param name="_artikel"></param>
        /// <returns>Observable Collection</returns>
        PVItemListe<Artikel> GetZubehoerListeAsync( Artikel _artikel );

        PVItemListe<Artikel> LoadZubehoerListeByArtikel( Artikel _artikel );
    }
}
