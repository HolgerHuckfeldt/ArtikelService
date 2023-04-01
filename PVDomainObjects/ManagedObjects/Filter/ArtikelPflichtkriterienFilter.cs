/***************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  Filtert Artikel nach Kriterien
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using PV.DomainObjects.Artikel;

namespace PV.DomainObjects.ManagedObjects.Filter
{
    /// <summary>
    /// Filtert Artikel nach Kriterien
    /// </summary>
    [Serializable]
    public class ArtikelPflichtkriterienFilter : ArtikelFilterBase
    {
        private Dictionary<string, string> _Filterkriterien = new Dictionary<string, string>();

        /// <summary>
        /// Liefert und setzt die Liste der Filterkriterien und ihrer Werte
        /// </summary>
        public Dictionary<string, string> Filterkriterien
        {
            get
            {
                return _Filterkriterien;
            }
            set
            {
                _Filterkriterien = value;
                ProcessStrategies();
            }
        }

        public List<string> FilterHersteller = new List<string>();
        public List<AttributListe> FilterAttribute = new List<AttributListe>();

        /// <summary>
        /// Fügt der Liste der Filterkriterien ein neues Kriterium hinzu oder setzt dessen Wert neu
        /// </summary>
        /// <param name="_name">Der Kriterienname</param>
        /// <param name="_value">Der Kriterienwert</param>
        public void SetFilterKriterium(string _name, string _value)
        {

            if (Filterkriterien.Keys.Contains(_name))
                Filterkriterien[_name] = _value;
            else
                Filterkriterien.Add(_name, _value);

            ProcessStrategies();
        }

        public void SetFilterAttribute(string _name, List<string> _value)
        {
            AttributListe filterAttribut = FilterAttribute.FirstOrDefault(x => x.Key == _name);

            if (filterAttribut == null && _value != null && _value.Count > 0)
            {
                FilterAttribute.Add(new AttributListe()
                {
                    Key = _name,
                    Werte = _value
                });
            }
            else
            {
                if (_value != null && _value.Count > 0)
                {
                    filterAttribut.Werte = _value;
                }
                else
                {
                    FilterAttribute.Remove(filterAttribut);
                }
            }

            ProcessStrategies();
        }

        public void SetFilterHersteller(List<string> hersteller)
        {
            FilterHersteller = hersteller;

            ProcessStrategies();
        }

        /// <summary>
        /// Entfernt ein Kriterium aus der Liste der Filterkriterien
        /// </summary>
        /// <param name="_name">Das zu entfernende Kriterium</param>
        public void RemoveFilterKriterium(string _name)
        {
            if (Filterkriterien.Keys.Contains(_name))
                Filterkriterien.Remove(_name);

            ProcessStrategies();
        }

        public override void Reset()
        {
            Filterkriterien.Clear();
            FilterHersteller.Clear();
            FilterAttribute = new List<AttributListe>();

            ProcessStrategies();
        }

        #region Overrides of ArtikelFilterBase

        /// <summary>
        /// Hier muss die Schablone filtern!
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public override bool Pass(Artikel.Artikel _item)
        {
            bool result = true;

            if (FilterHersteller.Count(x => x == _item.HerstellerName) == 0 &&
                FilterHersteller.Count > 0)
            {
                result = false;
                return result;
            }

            if (Filterkriterien != null && Filterkriterien.Count > 0)
            {
                foreach (KeyValuePair<string, string> keyValuePair in Filterkriterien)
                {
                    //KeyValuePair<string, string> pair = keyValuePair;
                    ArtikelKriterium kriterium =
                                           _item.AlleKriterien.Where(krit => krit.BezeichnungLang == keyValuePair.Key &&
                                               krit.KritWert == keyValuePair.Value).FirstOrDefault();
                    if (kriterium == null)
                    {
                        result = false;
                        return result;
                    }
                }
            }
            if (FilterAttribute != null && FilterAttribute.Any() && FilterAttribute.Any(x=>x.Werte!=null && x.Werte.Any()))
            {
                foreach (AttributListe attr in FilterAttribute)
                {
                    if (attr.Werte != null & attr.Werte.Count > 0)
                    {
                        ArtikelKriterium artikelKriteriumN =
                            _item.AlleKriterien.Where(krit => krit.BezeichnungLang == attr.Key).FirstOrDefault(wert => attr.Werte.Any(x => x == wert.KritWert));

                        if (artikelKriteriumN == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
