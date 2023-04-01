using System.Collections.Generic;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Plus;
using PV.DomainObjects.Warenkorb;
using System;

namespace PV.Business.Services
{
    ///// <summary>
    ///// Mögliche Sortierungstypen der Prämienartikel
    ///// </summary>
    //public enum PraemienArtikelSortierung
    //{
    //    Aufsteigend,
    //    Absteigend
    //}

    ///// <summary>
    ///// Mögliche Filtertypen der Prämienartikel
    ///// </summary>
    //public enum PraemienArtikelFilter
    //{
    //    Alle,
    //    Bis10000,
    //    Bis5000,
    //    Bis1500,
    //    Bis1000,
    //    Unter1000
    //}

    

    public interface IPlusManager : ISearchByStringManager
    {
        #region Properties PrämienArtikel

        string SelectedPraemienArtikelNummer
        { get; }

        PraemienArtikel SelectedPraemienArtikel
        { get; set; }

        PraemienGruppe SelectedPraemienArtikelGruppe
        { get; set; }

        List<PraemienGruppe> PraemienGruppen
        { get; set; }

        List<PraemienArtikel> AlleArtikel
        { get; }

        List<PraemienArtikel> AlleArtikelFuerSuche
        { get; }

        List<PraemienArtikel> ViewablePraemienArtikelListe
        { get; set; }

        PraemienArtikelSortierung AktuelleSortierung
        { get; set; }

        PraemienArtikelFilter AktuellerFilter
        { get; set; }

        List<PraemienArtikel> TeaserArtikelPageOne
        {
            get; set;
        }

        List<PraemienArtikel> TeaserArtikelPageTwo
        {
            get;
            set;
        }

        List<PraemienArtikel> PraemienArtikelTeaserTopBonus
        {
            get;
            set;
        }

        IList<PraemienArtikel> StartseiteGutschriftenListe
        {
            get;
        }

        IList<PraemienArtikel> StartseiteArtikelListe
        {
            get;
        }

        #endregion Properties PrämienArtikel

        #region Properties Buchungen

        List<Transaktionen> Buchungen
        { get; set; }

        Kontoauszug Kontoauszug
        { get; set; }

        #endregion Properties Buchungen

        IList<SuchbaumEintrag> SuchbaumListe
        {
            get; set;
        }

        void ResetSearchField();

        void ReloadPraemienGruppen();
        void LoadAgbFooter(out string firma, out string adresse, out string gf, out string kontakt, out string rechtsform, out string web);
        //void SelectPrev();

        //void SelectNext();

        //int SelectionIndex
        //{
        //    get;
        //}

        //void LoadPraemienGruppen();

        //void LoadKontoAuszug();
    }
}
