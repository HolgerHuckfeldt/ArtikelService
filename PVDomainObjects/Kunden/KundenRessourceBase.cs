/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Kundenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen einer KundenRessourceBase
 *              Eine KundenRessourceBase ist die Oberklasse aller Ressourcen, 
 *              welche man einem Kunden zuordnen kann (PKW, NKW, Achse, Motor)
 ************************************************************************************/

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Kunden
{
    [Serializable]
    [DataContract]
    [KnownType( typeof( KundenAchse ) )]
    [KnownType( typeof( KundenMotor ) )]
    [KnownType( typeof( KundenFahrzeug ) )]
    public abstract class KundenRessourceBase
    {
        /// <summary>
        /// Der Konstruktor
        /// </summary>
        public KundenRessourceBase()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Liefert und setzt die ID des Objektes in der DB
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die URI der Ressource
        /// </summary>
        [DataMember]
        public string RessourceUri
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Displaystring
        /// </summary>
        [DataMember]
        public string RessourceDisplayString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Ressourcenart
        /// </summary>
        [DataMember]
        public KundenRessourcenArt RessourcenArt
        {
            get;
            set;
        }
        public override string ToString()
        {
            return RessourceDisplayString;
        }

        #region IEquatable Member

        public bool Equals( KundenRessourceBase other )
        {
            return Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            KundenRessourceBase toCompare = obj as KundenRessourceBase;
            if ( toCompare != null )
                return toCompare.Id == Id;

            return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

    }
}
