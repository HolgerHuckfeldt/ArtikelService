/********************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    modulübergreifend   
 * Funktionen:  Eventargs to submit user at UserChangedEvent
 ********************************************************************************************/

using System;
using PV.DomainObjects.Stammdaten;


namespace PV.DomainObjects
{
    /// <summary>
    /// Eventargs to submit user at UserChangedEvent
    /// </summary>
    public class UserChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_old">The old user changed from</param>
        /// <param name="_new">The new user changed to</param>
        public UserChangedEventArgs( Mitarbeiter _old, Mitarbeiter _new )
        {
            OldUser = _old;
            NewUser = _new;
        }

        /// <summary>
        /// Get or set the old user changed from 
        /// </summary>
        public Mitarbeiter OldUser
        {
            get; set;
        }

        /// <summary>
        /// Get or set the new user changed to 
        /// </summary>
        public Mitarbeiter NewUser
        {
            get;
            set;
        }
    }
}
