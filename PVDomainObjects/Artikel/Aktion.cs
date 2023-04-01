using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class Aktion
    {
        /// <summary>
        /// Wenn gesetzt, haben wir eine Bonusaktion,
        /// sonst Preisaktion
        /// </summary>
        [DataMember]
        public bool IstBonusaktion
        {
            get; set;
        }

        /// <summary>
        /// Wenn gesetzt, muss ein Streichpreis angezeigt werden
        /// </summary>
        [DataMember]
        public bool ZeigeStreichpreis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Namen der Aktion
        /// </summary>
        [DataMember]
        public virtual string Aktionsname
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Namen der Aktion
        /// </summary>
        [DataMember]
        public virtual string Aktionsclaim
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Aktionslogo
        /// </summary>
        [DataMember]
        public virtual PvImage Aktionslogo
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Miniaturansicht des Aktionsartikelbildes
        /// </summary>
        [DataMember]
        public virtual PvImage Aktionsartikelthumb
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung des Aktionsartikels
        /// </summary>
        [DataMember]
        public virtual string Aktionsartikelbezeichnung
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Beschreibung des Aktionsartikels
        /// </summary>
        [DataMember]
        public virtual string Aktionsartikelbeschreibung
        {
            get;
            set;
        }

      

        /// <summary>
        /// Legt fest, ob die zeitl. Gültigkeit angezeigt werden soll
        /// </summary>
        [DataMember]
        public virtual bool IsGueltigBisVisible
        {
            get;
            set;
        }

        /// <summary>
        /// Gültigkeitdato des Aktions 
        /// </summary>
        [DataMember]
        public virtual DateTime GueltigBisDato
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die maximale Bestellmenge; 0=> Keine Begrenzung
        /// </summary>
        [DataMember]
        public virtual int Bestelllimit
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Logo
        /// </summary>
        [DataMember]
        public virtual PvImage Logo
        {
            get; 
            set;
        }

        /// <summary>
        /// Liefert und setzt die Staffeln in der die Aktion gültig ist
        /// </summary>
        [DataMember]
        public virtual List<PreisStaffel> Staffeln
        {
            get;
            set;
        }
    }
}
