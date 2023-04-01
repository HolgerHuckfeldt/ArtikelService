using System;
using System.Collections.Generic;
using System.Linq;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.ManagedObjects.Comparer;
using PV.DomainObjects.ManagedObjects.Filter;
using PV.Utilities.Misc;

namespace PV.DomainObjects.ManagedObjects
{
    [Serializable]
    public class FinderArtikelListe : PVItemListe<Artikel.Artikel>
    {
        private readonly ArtikelPVSortimentsComparer _SortimentsComparer = new ArtikelPVSortimentsComparer();
        private readonly ArtikelPropertyComparer _PropertyComparer = new ArtikelPropertyComparer();
        private readonly ArtikelPriorisierungsComparer _PriorisierungsComparer = new ArtikelPriorisierungsComparer();

        private readonly ArtikelPflichtkriterienFilter _PflichtkriterienFilter = new ArtikelPflichtkriterienFilter();
        private readonly ArtikelBreadcrumbFilter _BreadcrumbFilter = new ArtikelBreadcrumbFilter();
        private readonly ArtikelTemotFilter _TemotFilter = new ArtikelTemotFilter();

        private List<string> _filterSortierreihenfolge = new List<string>();

        public IList<FilterKriterium> FilterKriterien
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert den Comparer für PV-Sortiment
        /// </summary>
        public ArtikelPVSortimentsComparer SortimentsComparer
        {
            get
            {
                return _SortimentsComparer;
            }
        }

        /// <summary>
        /// Liefert den Comparer für Properties
        /// </summary>
        public ArtikelPropertyComparer PropertyComparer
        {
            get
            {
                return _PropertyComparer;
            }
        }

        /// <summary>
        /// Liefert den Comparer für Priorisierung
        /// </summary>
        public ArtikelPriorisierungsComparer PriorisierungsComparer
        {
            get
            {
                return _PriorisierungsComparer;
            }
        }

        /// <summary>
        /// Liefert den PflichtkriterienFilter
        /// </summary>
        public ArtikelPflichtkriterienFilter PflichtkriterienFilter
        {
            get
            {
                return _PflichtkriterienFilter;
            }
        }

        /// <summary>
        /// Liefert den Breadcrumbfilter
        /// </summary>
        public ArtikelBreadcrumbFilter BreadcrumbFilter
        {
            get
            {
                return _BreadcrumbFilter;
            }
        }

        /// <summary>
        /// Liefert den TemotFilter
        /// </summary>
        public ArtikelTemotFilter TemotFilter
        {
            get
            {
                return _TemotFilter;
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public FinderArtikelListe()
        {
            AddComparer(SortimentsComparer);
            AddComparer( PropertyComparer );
            AddComparer( PriorisierungsComparer );

            //ToDo: Pflichtkriterien implementieren!!!
            AddFilter( PflichtkriterienFilter );
            AddFilter( BreadcrumbFilter );
            AddFilter( TemotFilter );
        }

        public void SetSortimentsComparer(bool mitSortimentsComparer)
        {
            if (mitSortimentsComparer)
            {
                if (SortStrategies.Contains(SortimentsComparer))
                    return;

                AddComparer(SortimentsComparer);
            }
            else
            {
                RemoveComparer(SortimentsComparer);
            }
        }

        /// <summary>
        /// Kalkuliert die Liste der Filterkriterien für Liste einschränken
        /// </summary>
        /// <returns>Liste von FilterKriterien</returns>
        private IList<FilterKriterium> CalculateFilterKriterien()
        {
            //Nach Pütz folgende Funktionsweise des Filters (Email 02.05.2012 16:01)
            //1. Hersteller Filter immer an der 1. Position
            //2. ab dem zweiten gewählten Filter bezieht sich der Filterinhalt auf die aktuelle Liste
            //3. bei jedem Filter ist es möglich die Auswahl wieder rückgängig zu machen / Filterinhalt und Artikelliste ändert ich dynamisch
            //4. auch die NICHT Pflichtkriterien dynamisch anbieten / nach der aktuellen Regel
            //5. die Sortierung/ Reihenfolge der Filter immer bei beibehalten und hinzukomende Filter nachträglich aufführen
            //6. unterer Rand in der Höhe auf ca. 4mm (wie oben) begrenzen
            //7. gibt zu einem Filter nur noch ein Kriterium dann wird dieses automatisch ausgewählt, so das der User die Auswahl sehen kann

            List<FilterKriterium> back = new List<FilterKriterium>();
            //Wenn es noch keine Artikel gibt
            var allItems = GetViewableListeAsReadonly();
            //var allItems = GetAllItemsAsReadonly();

            if (allItems.Count == 0 || this.Count == 0)
            {
                _filterSortierreihenfolge = new List<string>();
                return back;
            }
            //Der Filter "Liste eingrenzen" funktioniert auf Basis des Pflichtkriteriums und 
            //Wenn alle GEMEINSAMEN gesucht werden müssen nur die des ersten berücksichtigt werden,
            //denn wenn er sie nicht hat, können die nicht GEMEINSAM sein.
            //Für weitere Fragen sich bitte an Thomas wenden
            //Thomas: Jetzt soll auch nach dem Hersteller gefiltert werden können.

            var herstellerFilter = allItems.GroupBy(hersteller => hersteller.HerstellerName).Select(group => 
                        new { Name = group.Key,
                              Hersteller = group.Select(x => x.HerstellerName)
                        }).OrderBy(group => group.Hersteller.First());

            FilterKriterium herstellerKrit = new FilterKriterium
            {
                KritBez = "Hersteller",
                KritKurzBez = "Hersteller"
            };

            foreach (var herst in herstellerFilter)
            {
                herstellerKrit.KritWerteHash.Add(herst.Hersteller.First());
            }

            back.Add(herstellerKrit);
            
            //Thomas im Pims2 gibt es keine Pflichtkriterien
            if (allItems.Count() > 0)
            {
                var artikelKriterien = allItems.SelectMany(x => x.AlleKriterien).Where(s => s.SofortAnzeige == true).GroupBy(y => y.BezeichnungLang);

                foreach (var krit in artikelKriterien)
                {
                    int artikelkriterienCount = 0;
                    List<ArtikelKriterium> artikelkriterienAll = new List<ArtikelKriterium>();

                    foreach (var art in allItems)
                    {
                        var artkritAll = art.AlleKriterien.Where(x => x.BezeichnungLang == krit.Key && x.SofortAnzeige == true);

                        if (artkritAll != null && artkritAll.Count() > 0)
                            artikelkriterienCount++;
                        else
                            continue;
                        
                        foreach (var kritVal in artkritAll)
                        {
                            artikelkriterienAll.Add(kritVal);
                        }
                    }
                    
                    //Thomas: Kriterium wird als Filter angezeigt, wenn er mindestens in 50% der Artikel vorkommt
                    if (artikelkriterienCount >= allItems.Count() / 2)
                    {
                        FilterKriterium fk = new FilterKriterium
                        {
                            KritBez = artikelkriterienAll.First().BezeichnungLang,
                            KritBezEinheit = artikelkriterienAll.First().BezeichnungEinheit,
                            KritKurzBez = artikelkriterienAll.First().BezeichnungAbk,
                            IsNameFettdruck = artikelkriterienAll.First().IsNameFettdruck
                        };

                        foreach (var artkrit in artikelkriterienAll.GroupBy(x => x.KritWert))
                        {
                            if (!string.IsNullOrEmpty(artkrit.Key))
                            {
                                fk.KritWerteHash.Add(artkrit.Key);
                            }
                        }

                        back.Add(fk);
                        //if (fk.KritWerte.Count > 0)
                        //    back.Add(fk);
                    }
                }
            }

            back = filterkriterienSortieren(back);
            return back;
        }

        private List<FilterKriterium> filterkriterienSortieren(List<FilterKriterium> filterkriterien)
        {
            var returnVal = new List<FilterKriterium>();
            _filterSortierreihenfolge.RemoveAll(x => filterkriterien.Count(y => y.KritBez == x) == 0);

            foreach (var kritBez in _filterSortierreihenfolge)
            {
                returnVal.Add(filterkriterien.Where(x=>x.KritBez == kritBez).First());
            }

            foreach (var krit in filterkriterien)
            {
                if (returnVal.Count(x => x.KritBez == krit.KritBez) == 0)
                {
                    returnVal.Add(krit);
                    _filterSortierreihenfolge.Add(krit.KritBez);
                }
            }

            return returnVal;
        }

        public void SelectFilterKriterium( FilterKriterium _krit, int _index )
        {
            PflichtkriterienFilter.SetFilterKriterium( _krit.KritBez, _krit.KritWerte.ToList()[ _index ] );
        }

        public void SelectFilterAttribute(FilterKriterium _krit, List<string> attribute)
        {
            PflichtkriterienFilter.SetFilterAttribute(_krit.KritBez, attribute);
        }

        public void EntferneFilterKriterium(FilterKriterium _krit)
        {
            PflichtkriterienFilter.RemoveFilterKriterium(_krit.KritBez);
        }

        public void SelectFilterHersteller(List<string> hersteller)
        {
            PflichtkriterienFilter.SetFilterHersteller(hersteller);
        }

        public void ResetKriterienFilter()
        {
            PflichtkriterienFilter.Reset();
        }

        protected override void PreProcessStrategies()
        {
            // Not implemented!
        }

        protected override void PostProcessStrategies()
        {
            FilterKriterien = CalculateFilterKriterien();
        }

        public int MengeToSet { get; set; }
    }
}
