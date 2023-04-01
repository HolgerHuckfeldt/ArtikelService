using PV.Business.Services;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.ManagedObjects;
using PV.DomainObjects.Stammdaten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.Business.Services
{
    public interface IMeinSortimentArtikelManager : IArtikelManager
    {
        FinderArtikelListe LoadMeinSortimentArtikel();
        void LoadMeinSortimentArtikelOhneArtList();
        void ResetSearch();
        List<Artikel> MeinSortimentArtikelliste { get; set; }
        void SaveMeinSortimentArtikel(MyArtikelKategorien kategorie, Artikel art);
        bool SaveMeinSortiment(List<MyArtikelKategorien> meinSortiment);
        bool MeinSortimentArtikelLoaded { get; set; }
    }
}
