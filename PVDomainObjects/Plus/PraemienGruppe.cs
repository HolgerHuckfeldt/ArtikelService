using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PV.DomainObjects.Plus
{
    [Serializable]
    public class PraemienGruppe : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Name der Gruppe
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id des Knotens
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// Liste der zugehörigen Untergruppen
        /// </summary>
        public List<PraemienGruppe> Untergruppen { get; set; }

        /// <summary>
        /// bestimmt die Anzeigereihenfolge im Suchbaum
        /// </summary>
        public int Sortierung
        {
            get; set;
        }

        public List<int> GenArtIds { get; set; }

        #endregion Properties

        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name">Name der Gruppe</param>
        /// /// <param name="nodeid">NodeID</param>
        /// <param name="gruppe">Untergruppen</param>
        ///         /// <param name="sortierung">Anzeige-Position im Suchbaum</param>
        public PraemienGruppe(string name, int nodeid, List<PraemienGruppe> gruppe, int sortierung, List<int> genArtIds)
        {
            Name = name;
            NodeID = nodeid;
            Untergruppen = gruppe;
            Sortierung = sortierung;
            GenArtIds = genArtIds;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name">Name der Gruppe</param>
        /// <param name="nodeid">NodeID</param>
        public PraemienGruppe(string name, int nodeid)
        {
            Name = name;
            NodeID = nodeid;
            Sortierung = -1;
        }

        #endregion Konstruktor

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }


        #endregion

    }
}
