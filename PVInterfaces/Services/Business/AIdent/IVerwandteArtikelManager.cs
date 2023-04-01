/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Walter Licht   
* Modul:    Artikelsuche
* Funktionen: Abstrahiert die Schnittstelle
*****************************************************************************************************/
using PV.DomainObjects.Artikel;
using PV.Utilities.Misc;

namespace PV.Business.Services
{
    public interface IVerwandteArtikelManager
    {
        /// <summary>
        /// Liefert Verwandte Artikel zu dem Artikel UND seinem generischen Artikel
        /// </summary>
        /// <param name="_artikel"></param>
        /// <returns>Observable Collection</returns>
        PVItemListe<Artikel> GetVerwandteArtikelAsync( Artikel _artikel );
        PVItemListe<Artikel> LoadVerwandteArtikelByArtikel(Artikel _artikel, bool _mitZubehoer);
    }
}
