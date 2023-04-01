/***************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Filtert Artikel nach Suchherkunft
 ***************************************************************************/

using System;
using PV.DomainObjects.Artikel;

namespace PV.DomainObjects.ManagedObjects.Filter
{
    /// <summary>
    /// Filtert Artikel nach Suchherkunft
    /// </summary>
    [Serializable]
    public class NummernsucheArtikelFilter : ArtikelFilterBase
    {
        #region IFilterSchablone<Artikel> Member

        private Artikel_Nummernsuche.FoundBy? _Filter;

        public NummernsucheArtikelFilter()
        {
            PVDomainObjectBase.RegisterClassDataTyp(this,typeof(Artikel_Nummernsuche),"NummernSucheListe");
        }

        public Artikel_Nummernsuche.FoundBy? Filter
        { 
            get
            {
                return _Filter;
            }
        }

        /// <summary>
        /// Hier muss die Schablone filtern!
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public override bool Pass(Artikel.Artikel _item)
        {
            try
            {
                _item.AddUserReferenz(this);
                if (_Filter != null)
                {
                    bool retValue = (_item.AccesUserData(this) as Artikel_Nummernsuche).IsFoundBy == _Filter;

                    if(!retValue)
                    {
                        if (_item.GefundenUeberListe.Contains(_Filter.Value))
                            retValue = true;
                    }

                    return retValue;
                }

                return true;
            }
            finally
            {
                _item.ReleaseUserReferenz(this);
            }
        }


        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der ArtikelNummer gefunden wurden
        /// </summary>
        public void FilterByArtikelNummer()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.Artikelnummer;
            ProcessStrategies();
        }

        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der EindeutigNummer gefunden wurden
        /// </summary>
        public void FilterByEindeutigNummer()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.Eindeutignummer;
            ProcessStrategies();
        }

        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der GebrauchsNummer gefunden wurden
        /// </summary>
        public void FilterByGebrauchsNummer()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.Gebrauchsnummer;
            ProcessStrategies();
        }

        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der Vergleichs-Nummer gefunden wurden
        /// </summary>
        public void FilterByVergleichsNummer()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.Vergleichsnummer;
            ProcessStrategies();
        }

        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der Refernz-Nummer gefunden wurden
        /// </summary>
        public void FilterByReferenzNummer()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.Referenznummer;
            ProcessStrategies();
        }

        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der Refernz-Nummer gefunden wurden
        /// </summary>
        public void FilterByMatchcode()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.Matchcode;
            ProcessStrategies();
        }

        /// <summary>
        /// Filtert die Ergebnisse danach ob sie anhand der OE-Nummer gefunden wurden
        /// </summary>
        public void FilterByEANummer()
        {
            _Filter = Artikel_Nummernsuche.FoundBy.EANummer;
            ProcessStrategies();
        }
        
        /// <summary>
        /// Setzt die Filter auf alle Ergebnisse zurück
        /// </summary>
        public override void Reset()
        {
            _Filter = null;
            ProcessStrategies();
        }



        #endregion
    }
}