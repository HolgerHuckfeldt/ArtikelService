using System;
using System.Collections.Generic;
using PV.DomainObjects;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.ManagedObjects;
using PV.DomainObjects.ManagedObjects.Comparer;
using PV.DomainObjects.ManagedObjects.Filter;
using PV.Utilities.Misc;

namespace PV.Business.ManagedObjects
{
    [Serializable]
    public class NummernsucheArtikelListe : PVItemListe<Artikel>
    {
        private readonly NummernsucheArtikelFilter _Filter = new NummernsucheArtikelFilter();
        private readonly ArtikelPVSortimentsComparer _SortimentsComparer = new ArtikelPVSortimentsComparer();
        private readonly ArtikelPropertyComparer _PropertyComparer = new ArtikelPropertyComparer();
        private List<Artikel> _TempArtikelResultListe = new List<Artikel>();

        private List<Artikel> _RealTempArtikelResultListe = new List<Artikel>();

        public ArtikelPVSortimentsComparer SortimentsComparer
        {
          get
          {
              return _SortimentsComparer;
          }
        }

        public NummernsucheArtikelFilter Filter
        {
            get
            {
                return _Filter;
            }
        }

        public ArtikelPropertyComparer PropertyComparer
        {
            get
            {
                return _PropertyComparer;
            }
        }


        public NummernsucheArtikelListe()
        {
            //UserDataTypes für Artikel DO Registrieren
            PVDomainObjectBase.RegisterClassDataTyp(this, typeof(Artikel_Nummernsuche), "NummernSucheListe");

            AddFilter(_Filter);
            //AddComparer(_SortimentsComparer);
            AddComparer(_PropertyComparer);
        }

        public void Start()
        {
            _RealTempArtikelResultListe.Clear();
        }

        public void End()
        {
            //NummernSuche / Artikel "DDF1625" Sortierung stimmt nicht nach Breadcrumb (#10116496)
            _PropertyComparer.SetPropertyForSort("");
            AddRange(_RealTempArtikelResultListe, true);
        }

        private int count = 0;

        public void AddArtikelOfArtikelnummernResult(IList<Artikel> artList)
        {
            _TempArtikelResultListe.Clear();

            foreach (Artikel artikel in artList)
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche) artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.Artikelnummer;
                _TempArtikelResultListe.Add( artikel );
            }

            count++;

            bool doUpdate = (count >= 3 ? true:false);

            _RealTempArtikelResultListe.AddRange(_TempArtikelResultListe);

            if (doUpdate)
            { 
                count = 0;
            }
        }

        public void AddArtikelOfEindeutignummernResult(IList<Artikel> artList)
        {
            //_TempArtikelResultListe.Clear();

            foreach (Artikel artikel in artList)
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche)artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.Eindeutignummer;
                //_TempArtikelResultListe.Add(artikel);
                if (Count > 0)
                    Insert(0, artikel);
                else
                    Add(artikel);
            }
            //aufgrund von Performancegründen kein insert, da wenn die Artikelliste mehrere hundert Einträge hat ...
           // AddRange(_TempArtikelResultListe, false);
        }

        public void AddArtikelOfReferenznummernResult(IList<Artikel> artList)
        {
            _TempArtikelResultListe.Clear();

            foreach (Artikel artikel in artList)
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche)artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.Referenznummer;
                _TempArtikelResultListe.Add(artikel);
            }

            bool doUpdate = (count >= 3 ? true : false);

            _RealTempArtikelResultListe.AddRange(_TempArtikelResultListe);

            //AddRange(_TempArtikelResultListe, doUpdate);
            if (doUpdate)
                count = 0;
        }

        public void AddArtikelOfMatchcodeResult(IList<Artikel> artList)
        {
            _TempArtikelResultListe.Clear();

            foreach (Artikel artikel in artList)
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche)artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.Matchcode;
                _TempArtikelResultListe.Add(artikel);
            }

            bool doUpdate = (count >= 3 ? true : false);

            _RealTempArtikelResultListe.AddRange(_TempArtikelResultListe);

            //AddRange(_TempArtikelResultListe, doUpdate);
            if (doUpdate)
                count = 0;
        }

        public void AddArtikelOfGebrauchsnummernResult(IList<Artikel> artList)
        {
            _TempArtikelResultListe.Clear();

            foreach ( Artikel artikel in artList )
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche) artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.Gebrauchsnummer;
                _TempArtikelResultListe.Add( artikel );
            }

            bool doUpdate = (count >= 3 ? true : false);

            _RealTempArtikelResultListe.AddRange(_TempArtikelResultListe);


            //AddRange(_TempArtikelResultListe, doUpdate);
            if (doUpdate)
                count = 0;
        }

        public void AddArtikelOfVergleichsnummernResult(IList<Artikel> artList)
        {
            _TempArtikelResultListe.Clear();

            foreach ( Artikel artikel in artList )
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche) artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.Vergleichsnummer;
                _TempArtikelResultListe.Add( artikel );
            }
            bool doUpdate = (count >= 3 ? true : false);

            _RealTempArtikelResultListe.AddRange(_TempArtikelResultListe);

            //AddRange(_TempArtikelResultListe, doUpdate);
            if (doUpdate)
                count = 0;
        }

        public void AddArtikelOfEANummernResult(IList<Artikel> artList)
        {
            _TempArtikelResultListe.Clear();

            foreach ( Artikel artikel in artList )
            {
                artikel.AddUserReferenz(this);
                ((Artikel_Nummernsuche) artikel.AccesUserData(this)).IsFoundBy = Artikel_Nummernsuche.FoundBy.EANummer;
                _TempArtikelResultListe.Add( artikel );
            }
            bool doUpdate = (count >= 3 ? true : false);

            _RealTempArtikelResultListe.AddRange(_TempArtikelResultListe);

            //AddRange(_TempArtikelResultListe, doUpdate);
            if (doUpdate)
                count = 0;
        }

        #region Overrides of PVItemListe<Artikel>

        protected override void PreProcessStrategies()
        {
            //Do nothing
        }

        protected override void PostProcessStrategies()
        {
            //Do nothing
        }

        #endregion
    }
}
