using System;
using System.Collections.Generic;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Fahrzeug;

namespace PV.Business.Services
{
    public interface IArtikelUnit
    {
        List<Artikel> GetArtikelByKatalogIds(List<ArtikelKatalogIdent> _katIds);

        List<Artikel> GetArtikelByVdbIds(List<VdbArtikelId> _vdbIds);
        
        List<Artikel> GetTecDocAlternativArtikelByArtNrUndDLNr(Artikel artikel);
        
        Artikel GetArtikelByVdbId(VdbArtikelId vdbId);

        List<Artikel> GetArtikelByTiREPIds(List<TiREPArtikelId> _tiIds);

        List<Artikel> GetArtikelByKatalogIds_VdbSync(List<ArtikelKatalogIdent> _katIds);

        List<Artikel> GetArtikelByKatalogIds_VdbSync_Pims1(List<ArtikelKatalogIdent> _katIds);

        List<Artikel> GetArtikelByVdbIds_VdbSync(List<VdbArtikelId> _vdbIds);

        void ProcessArtikelByVdb<T>(IList<T> artikelListe) where T : Artikel;

        Boolean ProcessArtikelByVdb_VdbSync<T>(IList<T> artikelListe) where T : Artikel;

        Boolean GetArtikelAdditions_VdbSync<T>(IList<T> artikelListe) where T : Artikel;

        List<Artikel> GetArtikelByGenArts_Async(IList<Int32> genArts, PKWTyp typ, IArtikelLoadingCustomer customer,
                                                Object customerId);

        void SetAbholVerfuegbarkeitAnzeigen(Boolean abholverfuegbarkeitanzeigen);

        Boolean GetAbholVerfuegbarkeitAnzeigen();

        RepDocArtikelInfo GetArtikelInfo_RepDoc(String HLKA, String ATNR);

        IList<VdbArtikelInfo> GetVdbArtikelInfo(List<Artikel> tmpArtikelliste);
    }
}
