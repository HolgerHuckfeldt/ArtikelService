/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Kundenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines KundenFahrzeuges
 *              Eine KundenFahrzeuges ist die Oberklasse aller Fahrzeuge, 
 *              welche man einem Kunden zuordnen kann (PKW, NKW)
 ************************************************************************************/
using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Kunden
{
    [Serializable]
    [DataContract]
    [KnownType( typeof( KundenNKW ) )]
    [KnownType( typeof( KundenPKW ) )]
    public abstract class KundenFahrzeug : KundenRessourceBase
    {
        #region Props
        [DataMember]
        private string _Kennzeichen = string.Empty;

        /// <summary>
        /// Das Kennzeichen des Fahrzeugs
        /// </summary>
        public string Kennzeichen
        {
            get
            {
                return _Kennzeichen;
            }
            set
            {
                _Kennzeichen = value;
                string pattern = @"[^\w\d]";
                Regex rgx = new Regex( pattern );

                string kompressed = rgx.Replace( _Kennzeichen, string.Empty );
                KompressedKennzeichen = kompressed;
            }
        }

        /// <summary>
        /// Das um alles außer Buchstaben und Digits bereinigte Kennzeichen des Fahrzeugs
        /// </summary>
        [DataMember]
        public string KompressedKennzeichen
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Datum der Erstzulassung
        /// </summary>
        [DataMember]
        public DateTime? Erstzulassung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Kilometerstand des Fahrzeuges
        /// </summary>
        [DataMember]
        public int? Kilometerstand
        {
            get;
            set;
        }

        #endregion
    }
}
