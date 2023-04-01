/********************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    modulübergreifend   
 * Funktionen:  Eventargs welche einen Profilwechsel übermitteln
 ********************************************************************************************/

using System;
using PV.DomainObjects.Stammdaten;


namespace PV.DomainObjects
{
    /// <summary>
    /// Eventargs to submit profiles at ProfileChangedEvent
    /// </summary>
    public class ProfileChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_old">The old profile changed from</param>
        /// <param name="_new">The new profile changed to</param>
        public ProfileChangedEventArgs(Profil _old, Profil _new)
        {
            OldProfile = _old;
            NewProfile = _new;
        }

        /// <summary>
        /// Get or set the old profile changed from 
        /// </summary>
        public Profil OldProfile
        {
            get; set;
        }

        /// <summary>
        /// Get or set the new profile changed to 
        /// </summary>
        public Profil NewProfile
        {
            get;
            set;
        }
    }
}
