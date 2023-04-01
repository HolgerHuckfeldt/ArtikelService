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
    public interface IStuecklistenManager
    {
        /// <summary>
        /// Liefert Stuecklisten zu dem Artikel
        /// </summary>
        /// <param name="_artikel"></param>
        /// <returns>Observable Collection</returns>
        void LoadStuecklisteToArtikelAsync(Artikel _artikel);
        void LoadStuecklisteToByArtikelnummernUndHerstellernAsync(Artikel artikel, string artikelnummern, string hersteller);
        //IList<StuecklistenArtikel> GetStuecklisteAsync(Artikel _artikel);
        PVItemListe<Artikel> LoadTecDocStuecklisteByArtikel( Artikel _artikel );
        PVItemListe<Artikel> LoadPVStuecklisteByArtikel( Artikel _artikel );
    }
}
